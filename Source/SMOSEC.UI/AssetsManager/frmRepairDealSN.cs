using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smobiler.Core;
using Smobiler.Core.Controls;
using SMOSEC.DTOs.InputDTO;
using SMOSEC.Domain.Entity;
using System.Data;
using SMOSEC.UI.Layout;
using SMOSEC.CommLib;
using SMOSEC.DTOs.Enum;

namespace SMOSEC.UI.AssetsManager
{
    partial class frmRepairDealSN : Smobiler.Core.Controls.MobileForm
    {
        #region "definition"
        AutofacConfig autofacConfig = new AutofacConfig();     //调用配置类
        public String ROID;     //报修单编号
        #endregion
        /// <summary>
        /// 全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Checkall_CheckedChanged(object sender, EventArgs e)
        {
            foreach (ListViewRow Row in ListAssetsSN.Rows)
            {
                frmAssSNRDLayout Layout = Row.Control as frmAssSNRDLayout;
                Layout.setCheck(Checkall.Checked);
            }
        }
        /// <summary>
        /// 更新全选框状态
        /// </summary>
        public void upCheckState()
        {
            if (getNum() == ListAssetsSN.Rows.Count)
                Checkall.Checked = true;          //选中所有行项时
            else
                Checkall.Checked = false;        //没有选中所有行项
        }
        /// <summary>
        /// 计算当前选择行数
        /// </summary>
        /// <returns></returns>
        public Int32 getNum()
        {
            Int32 selectQty = 0;        //当前选择行项数
                                        //if (tpvAssets.PageIndex == 0)
                                        //{
            foreach (ListViewRow Row in ListAssetsSN.Rows)
            {
                frmAssSNRDLayout Layout = Row.Control as frmAssSNRDLayout;
                selectQty += Layout.checkNum();
            }
            return selectQty;
        }
        /// <summary>
        /// 确认维修
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Press(object sender, EventArgs e)
        {
            try
            {
                if (getNum() == 0) throw new Exception("请选择确认行项!");

                ROInputDto BasicData = new ROInputDto();
                BasicData.MODIFYDATE = DateTime.Now;
                BasicData.MODIFYUSER = Client.Session["UserID"].ToString();
                BasicData.ROID = ROID;

                List<AssRepairOrderRow> Data = new List<AssRepairOrderRow>();
                foreach (ListViewRow Row in ListAssetsSN.Rows)
                {
                    frmAssSNRDLayout Layout = Row.Control as frmAssSNRDLayout;
                    Data.Add(Layout.getData());
                }
                BasicData.Rows = Data;
                ReturnInfo r = autofacConfig.assRepairOrderService.UpdateAssRepairOrder(BasicData);
                if (r.IsSuccess)
                {
                    ShowResult = ShowResult.Yes;
                    Form.Close();
                    Toast("确认维修成功!");
                }
                else
                {
                    throw new Exception(r.ErrorInfo);
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }
        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmRepairDealSN_Load(object sender, EventArgs e)
        {
            Bind();
        }
        /// <summary>
        /// 加载数据
        /// </summary>
        public void Bind()
        {
            try
            {
                ROInputDto ROData = autofacConfig.assRepairOrderService.GetByID(ROID);
                coreUser User = autofacConfig.coreUserService.GetUserByID(ROData.HANDLEMAN);
                lblDealMan.Text = User.USER_NAME;
                DatePicker.Value = ROData.APPLYDATE;
                if (ROData.COST != 0)
                    lblPrice.Text = ROData.COST.ToString();
                lblContent.Text = ROData.REPAIRCONTENT;
                if (String.IsNullOrEmpty(ROData.NOTE)) lblNote.Text = ROData.NOTE;

                DataTable tableAssets = new DataTable();       //未开启SN的资产列表
                tableAssets.Columns.Add("ROROWID");           //报修单行项编号
                tableAssets.Columns.Add("ASSID");              //资产编号
                tableAssets.Columns.Add("NAME");               //资产名称
                tableAssets.Columns.Add("IMAGE");              //图片编号
                tableAssets.Columns.Add("SN");                 //序列号
                foreach (AssRepairOrderRow Row in ROData.Rows)
                {
                    Assets assets = autofacConfig.orderCommonService.GetAssetsByID(Row.ASSID);
                    if (Row.STATUS == 0)
                    {
                        tableAssets.Rows.Add(Row.ROROWID, Row.ASSID, assets.NAME , Row.IMAGE, Row.SN);
                    }
                }
                if (tableAssets.Rows.Count > 0)
                {
                    ListAssetsSN.DataSource = tableAssets;
                    ListAssetsSN.DataBind();
                }
            }
            catch(Exception ex)
            {
                Toast(ex.Message);
            }
        }
    }
}