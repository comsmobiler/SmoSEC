using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Smobiler.Core;
using Smobiler.Core.Controls;
using SMOSEC.Domain.Entity;
using SMOSEC.UI.MasterData;

namespace SMOSEC.UI.Layout
{
    ////ToolboxItem用于控制是否添加自定义控件到工具箱，true添加，false不添加
    //[System.ComponentModel.ToolboxItem(true)]
    partial class frmAssTypeChooseLayout : Smobiler.Core.Controls.MobileUserControl
    { 
        #region "definition"
        AutofacConfig autofacConfig = new AutofacConfig();//调用配置类
        public Int32 MaxLevel = 3;         //最深层级
        public Int32 NowLevel = 1;     //当前层级
        public String ID;              //选择资产分类编号
        public string typeId;
        public string typeName;
        public bool IsCreate;
        #endregion
        /// <summary>
        /// 关闭当前弹出页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void plClose_Press(object sender, EventArgs e)
        {
            this.Close();
        }

        private void treeAssetsType_NodePress(object sender, TreeViewClickEventArgs e)
        {
            if (IsCreate)
            {
                ((frmAssetsCreate)Form).btnType.Tag = e.Value;    //所选资产分类编号
                ((frmAssetsCreate)Form).btnType.Text = e.Text;    //所选资产分类名称
            }
            else
            {
                ((frmAssetsDetailEdit)Form).btnType.Tag = e.Value;   //所选资产分类编号
                ((frmAssetsDetailEdit)Form).btnType.Text = e.Text;   //所选资产分类名称
            }
            this.Close();
        }

        private void frmAssTypeChooseLayout_Load(object sender, EventArgs e)
        {
            Bind();
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        public void Bind()
        {
            try
            {
                treeAssetsType.Nodes.Clear();       //数据清除
                List<AssetsType> Data = autofacConfig.assTypeService.GetAll();
                if (Data.Count > 0)
                {
                    foreach (AssetsType Row in Data)
                    {
                        if (Row.TLEVEL == 1)
                        {
                            TreeViewNode Node = new TreeViewNode(Row.NAME, null, "一", Row.TYPEID);
                            TreeViewNode SonNode = getData(2, Data, Row.TYPEID);
                            if (SonNode.Nodes.Count > 0)
                            {
                                foreach (TreeViewNode SonRow in SonNode.Nodes)
                                {
                                    Node.Nodes.Add(SonRow);
                                }
                            }
                            treeAssetsType.Nodes.Add(Node);
                        }
                    }
                    ChangeNodeColor(treeAssetsType.Nodes);
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        /// <summary>
        /// 添加子级资产分类(总共三级)
        /// </summary>
        /// <param name="Level"></param>
        /// <param name="Data"></param>
        /// <param name="ParentID"></param>
        /// <returns></returns>
        public TreeViewNode getData(Int32 Level, List<AssetsType> Data, String ParentID)
        {
            TreeViewNode TreeData = new TreeViewNode();
            if (Level < MaxLevel)
            {
                foreach (AssetsType Row in Data)
                {
                    if (Row.TLEVEL == Level && Row.PARENTTYPEID == ParentID)
                    {
                        TreeViewNode Node = new TreeViewNode(Row.NAME, null, "二", Row.TYPEID);
                        TreeViewNode SonNode = getData(Level + 1, Data, Row.TYPEID);
                        if (SonNode.Nodes.Count > 0)
                        {
                            foreach (TreeViewNode SonRow in SonNode.Nodes)
                            {
                                Node.Nodes.Add(SonRow);
                            }
                        }
                        TreeData.Nodes.Add(Node);
                    }
                }
            }
            else if (Level == MaxLevel)
            {
                foreach (AssetsType Row in Data)
                {
                    if (Row.TLEVEL == Level && Row.PARENTTYPEID == ParentID)
                    {
                        TreeViewNode Node = new TreeViewNode(Row.NAME, null, "三", Row.TYPEID);
                        TreeData.Nodes.Add(Node);
                    }
                }
            }
            return TreeData;
        }

        public void ChangeNodeColor(TreeViewNodeCollection nodes)
        {
            foreach (TreeViewNode node in nodes)
            {
                if (node.Value == typeId)
                {
                    node.TextColor = Color.Red;
                    return;
                }
                if (node.Nodes.Count > 0)
                {
                    ChangeNodeColor(node.Nodes);
                }
            }
        }
    }
}