using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smobiler.Core;
using Smobiler.Core.Controls;
using SMOSEC.UI.Layout;
using System.Data;
using SMOSEC.Application.Services;
using SMOSEC.Domain.Entity;
using SMOSEC.DTOs.Enum;

namespace SMOSEC.UI.MasterData
{
    partial class frmAssetsTypeRows : Smobiler.Core.Controls.MobileForm
    {
        #region "definition"
        AutofacConfig autofacConfig = new AutofacConfig();//调用配置类
        public Int32 MaxLevel = 3;         //最深层级
        public Int32 NowLevel = 1;     //当前层级
        public String ID;              //选择资产分类编号
        #endregion
        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAssetsTypeRows_Load(object sender, EventArgs e)
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
                            if(Row.ISENABLE== (int)IsEnable.禁用)
                            {
                                Node.TextColor = System.Drawing.Color.Red;
                            }
                            treeAssetsType.Nodes.Add(Node);
                        }
                    }
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
                        if (Row.ISENABLE == (int)IsEnable.禁用)
                        {
                            Node.TextColor = System.Drawing.Color.Red;
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
                        if (Row.ISENABLE == (int)IsEnable.禁用)
                        {
                            Node.TextColor = System.Drawing.Color.Red;
                        }
                        TreeData.Nodes.Add(Node);
                    }
                }
            }
            return TreeData;
        }
        /// <summary>
        /// 添加下级资产分类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IBAdd_Press(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(ID))  throw new Exception("请先选择父类资产类别");
                if (autofacConfig.assTypeService.GetByID(ID).TLEVEL == 3) throw new Exception("当前所选类别为最低级，无法创建下级!");
                frmAssetsTypeCreateLayout frm = new frmAssetsTypeCreateLayout();
                frm.isCreateSon = true;
                frm.ID = ID;
                ShowDialog(frm);
            }
            catch(Exception ex)
            {
                Toast(ex.Message);
            }
        }
        /// <summary>
        /// 进行编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IBEdit_Press(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(ID)) throw new Exception("请先选择要操作的资产类别");
                AssetsType assetsType= autofacConfig.assTypeService.GetByID(ID);
                frmLocationRowsButtonLayout frm = new frmLocationRowsButtonLayout();
                if (assetsType.ISENABLE == (int)IsEnable.启用)
                {
                    frm.Enable = true;
                }
                else
                {
                    frm.Enable = false; 
                }
                frm.ID = ID;
                DialogOptions Dialog = new DialogOptions {
                    JustifyAlign = LayoutJustifyAlign.FlexEnd,
                    Padding = new Padding(0)
                };
                ShowDialog(frm,Dialog);
            }
            catch(Exception ex)
            {
                Toast(ex.Message);
            }
        }
        /// <summary>
        /// 新建资产分类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Press(object sender, EventArgs e)
        {
            frmAssetsTypeCreateLayout frm = new frmAssetsTypeCreateLayout();
            frm.isCreate = true;
            frm.plFID.Visible = false;
            frm.plFName.Visible = false;
            frm.plFDate.Visible = false;
            frm.Height = 220;
            this.ShowDialog(frm);
        }
        /// <summary>
        /// 选择资产
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeAssetsType_NodePress(object sender, TreeViewClickEventArgs e)
        {
            ID = e.Value;        //所选资产分类编号
            lblName.Text = e.Text;      //所选资产分类名称
        }
        /// <summary>
        /// 手机自带返回键操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAssetsTypeRows_KeyDown(object sender, KeyDownEventArgs e)
        {
            if (e.KeyCode == KeyCode.Back)
                Client.Exit();
        }
    }
}