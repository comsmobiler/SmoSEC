using System;
using Smobiler.Core.Controls;
using SMOSEC.DTOs.InputDTO;
using System.Data;
using SMOSEC.UI.Layout;
using System.Collections.Generic;
using SMOSEC.Domain.Entity;

namespace SMOSEC.UI.ConsumablesManager
{
    partial class frmTransferConsChoose : Smobiler.Core.Controls.MobileForm
    {
        #region "definition"
        AutofacConfig autofacConfig = new AutofacConfig();     //调用配置类
        public List<ConsumablesOrderRow> RowData = new List<ConsumablesOrderRow>();    //未开启SN行项
        public String LocInID;           //调入区域编号
        #endregion
        /// <summary>
        /// 根据名称进行查询资产
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void plSearch_Press(object sender, EventArgs e)
        {
            Bind(txtFactor.Text);
        }
        /// <summary>
        /// 全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Checkall_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //if(tpvAssets.PageIndex==0)     //未开启SN资产
                //{
                foreach (ListViewRow Row in ListAssets.Rows)
                {
                    frmAssetsLayout Layout = Row.Control as frmAssetsLayout;
                    Layout.setCheck(Checkall.Checked);
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }
        /// <summary>
        /// 更新全选状态
        /// </summary>
        public void upCheckState()
        {
            Int32 selectQty = 0;        //当前选择行项数
                                        //if (tpvAssets.PageIndex == 0)
                                        //{
            foreach (ListViewRow Row in ListAssets.Rows)
            {
                frmAssetsLayout Layout = Row.Control as frmAssetsLayout;
                selectQty += Layout.checkNum();
            }
            if (selectQty == ListAssets.Rows.Count)
                Checkall.Checked = true;          //选中所有行项时
            else
                Checkall.Checked = false;        //没有选中所有行项
        }
        /// <summary>
        /// 选择资产完毕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Press(object sender, EventArgs e)
        {
            try
            {
                if (RowData.Count > 0) RowData.Clear();
                foreach (ListViewRow Row in ListAssets.Rows)
                {
                    frmAssetsLayout Layout = Row.Control as frmAssetsLayout;
                    if (Layout.getData() != null)
                    {
                        RowData.Add(Layout.getData());     //添加未开启SN资产信息
                    }
                }
                ShowResult = ShowResult.Yes;
                Form.Close();       //关闭当前页面
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }
        /// <summary>
        /// 切换显示ListView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tpvAssets_PageIndexChanged(object sender, EventArgs e)
        {
            upCheckState();      //更新全选框状态
        }
        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAssetsChoose_Load(object sender, EventArgs e)
        {
            Bind(null);
        }
        /// <summary>
        /// 数据绑定
        /// </summary>
        /// <param name="Name"></param>
        public void Bind(String Name)
        {
            try
            {
                DataTable tableAssets = new DataTable();       //未开启SN的资产列表
                tableAssets.Columns.Add("CHECK");              //资产编号
                tableAssets.Columns.Add("CID");                //耗材编号
                tableAssets.Columns.Add("NAME");               //资产名称 
                tableAssets.Columns.Add("LOCATIONID");         //区域编号
                tableAssets.Columns.Add("LOCATIONNAME");       //区域名称
                tableAssets.Columns.Add("IMAGE");              //图片编号
                tableAssets.Columns.Add("QUANTITY");          //空闲数量
                tableAssets.Columns.Add("SELECTQTY");      //选择数量

                List<ConQuant> listAss = new List<ConQuant>();
                if (String.IsNullOrEmpty(Name))     //查询所有耗材
                    listAss = autofacConfig.orderCommonService.GetUnUseCon(LocInID,null);
                else
                {
                    Consumables consumables = autofacConfig.orderCommonService.GetConsByName(Name);
                    listAss = autofacConfig.orderCommonService.GetUnUseCon(LocInID,consumables.CID);
                }
                foreach (ConQuant Row in listAss)   
                {
                    Consumables cons = autofacConfig.orderCommonService.GetConsByID(Row.CID);
                    AssLocation location = autofacConfig.assLocationService.GetByID(Row.LOCATIONID);
                    if (RowData.Count > 0)
                    {
                        Boolean isAdd = false;
                        foreach (ConsumablesOrderRow HaveRow in RowData)
                        {
                            if (HaveRow.CID == Row.CID && HaveRow.LOCATIONID == Row.LOCATIONID)
                            {
                                tableAssets.Rows.Add(true, Row.CID, cons.NAME,Row.LOCATIONID, location.NAME, cons.IMAGE,Row.QUANTITY,HaveRow.QTY);
                                isAdd = true;
                                break;
                            }
                        }
                        if (isAdd == false)
                            tableAssets.Rows.Add(false, Row.CID, cons.NAME, Row.LOCATIONID, location.NAME, cons.IMAGE, Row.QUANTITY, 0);
                    }
                    else
                    {
                        tableAssets.Rows.Add(false, Row.CID, cons.NAME, Row.LOCATIONID, location.NAME, cons.IMAGE, Row.QUANTITY, 0);
                    }
                }

                if (tableAssets.Rows.Count > 0)
                {
                    ListAssets.DataSource = tableAssets;
                    ListAssets.DataBind();
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }
    }
}