using System;
using System.Collections.Generic;
using Smobiler.Core.Controls;
using SMOSEC.DTOs.InputDTO;
using SMOSEC.Domain.Entity;
using System.Data;
using SMOSEC.UI.Layout;
using SMOSEC.CommLib;
using SMOSEC.DTOs.Enum;

namespace SMOSEC.UI.AssetsManager
{
    partial class frmRepairCreateSN : Smobiler.Core.Controls.MobileForm
    {
        #region "definition"
        AutofacConfig autofacConfig = new AutofacConfig();     //调用配置类
        public List<AssetsOrderRow> SNRowData;   //开启SN行项
        public ROInputDto RepairData = new ROInputDto();         //维修单信息
        private String SN;       //序列号
        #endregion
        /// <summary>
        /// 创建报修单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Press(object sender, EventArgs e)
        {
            try
            {
                if (btnDealMan.Tag ==null)
                    throw new Exception("处理人不能为空");
                else
                    RepairData.HANDLEMAN = btnDealMan.Tag.ToString();     //处理人                
                if (String.IsNullOrEmpty(txtPrice.Text) == false)
                    RepairData.COST = Convert.ToDecimal(txtPrice.Text);   //维修花费
                if (String.IsNullOrEmpty(txtContent.Text))
                    throw new Exception("维修内容不能为空!");
                else
                    RepairData.REPAIRCONTENT = txtContent.Text;               //维修内容

                RepairData.APPLYDATE = DatePicker.Value;                  //业务日期
                RepairData.NOTE = txtNote.Text;                           //备注
                RepairData.STATUS = 0;                                    //维修单状态
                RepairData.ISSNCONTROL = (Int32)ISSNCONTROL.启用;         //是否属于SN
                RepairData.CREATEUSER = Client.Session["UserID"].ToString();      //创建用户
                RepairData.CREATEDATE = DateTime.Now;             

                List<AssRepairOrderRow> Data = new List<AssRepairOrderRow>();
                if (ListAssetsSN.Rows.Count == 0) throw new Exception("维修行项不能为空!");
                foreach (ListViewRow Row in ListAssetsSN.Rows)
                {
                    frmOrderCreateSNLayout Layout = Row.Control as frmOrderCreateSNLayout;
                    AssetsOrderRow RowData = Layout.getData();
                    AssRepairOrderRow assRow = new AssRepairOrderRow();

                    assRow.IMAGE = RowData.IMAGE;
                    assRow.ASSID = RowData.ASSID;
                    assRow.WAITREPAIRQTY = RowData.QTY;
                    assRow.SN = RowData.SN;
                    assRow.LOCATIONID = RowData.LOCATIONID;
                    assRow.STATUS = RowData.STATUS;
                    assRow.CREATEDATE = DateTime.Now;
                    Data.Add(assRow);
                }
                RepairData.Rows = Data;
                ReturnInfo r = autofacConfig.assRepairOrderService.AddAssRepairOrder(RepairData);
                if (r.IsSuccess)
                {
                    ShowResult = ShowResult.Yes;
                    Form.Close();          //创建成功
                    Toast("创建维修单成功!");
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
        /// 处理人选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDealMan_Press(object sender, EventArgs e)
        {
            try
            {
                popDealMan.Groups.Clear();       //数据清空
                PopListGroup poli = new PopListGroup();
                popDealMan.Groups.Add(poli);
                poli.Title = "处理人选择";
                List<coreUser> users = autofacConfig.coreUserService.GetAdmin();
                foreach (coreUser Row in users)
                {
                    poli.AddListItem(Row.USER_NAME, Row.USER_ID);
                }
                if (btnDealMan.Tag != null)   //如果已有选中项，则显示选中效果
                {
                    foreach (PopListItem Item in poli.Items)
                    {
                        if (Item.Value == btnDealMan.Tag.ToString())
                            popDealMan.SetSelections(Item);
                    }
                }
                popDealMan.ShowDialog();
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }
        /// <summary>
        /// 添加数据
        /// </summary>
        public void Bind()
        {
            try
            {
                DataTable tableAssets = new DataTable();       //未开启SN的资产列表
                tableAssets.Columns.Add("ASSID");              //资产编号
                tableAssets.Columns.Add("NAME");               //资产名称 
                tableAssets.Columns.Add("IMAGE");              //图片编号
                tableAssets.Columns.Add("SN");                 //序列号
                if (SNRowData.Count > 0)
                {
                    foreach (AssetsOrderRow Row in SNRowData)
                    {
                        Assets assets = autofacConfig.orderCommonService.GetAssetsByID(Row.ASSID);
                        tableAssets.Rows.Add(Row.ASSID, assets.NAME, assets.IMAGE, Row.SN);
                    }
                }
                ListAssetsSN.DataSource = tableAssets;
                ListAssetsSN.DataBind();
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }
        /// <summary>
        /// 删除当前所选行项
        /// </summary>
        /// <param name="ASSID"></param>
        /// <param name="SN"></param>
        public void ReMoveAssSN(String ASSID, String SN)
        {
            try
            {
                foreach (AssetsOrderRow Row in SNRowData)
                {
                    if (Row.ASSID == ASSID && Row.SN == SN)
                    {
                        SNRowData.Remove(Row);
                        break;
                    }
                }
                Bind();       //刷新当前页面
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }
        /// <summary>
        /// 扫码添加资产
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void betGet_Press(object sender, EventArgs e)
        {
            BarcodeScanner1.GetBarcode();
        }
        /// <summary>
        /// 处理人选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void popDealMan_Selected(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(popDealMan.Selection.Text) == false)
            {
                btnDealMan.Text = popDealMan.Selection.Text + "   > ";
                btnDealMan.Tag = popDealMan.Selection.Value;         //处理人编号
            }
        }
        /// <summary>
        /// 扫描到条码时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BarcodeScanner1_BarcodeScanned(object sender, BarcodeResultArgs e)
        {
            try
            {
                AssetsOrderRow Data = new AssetsOrderRow();
                if (string.IsNullOrEmpty(e.error))
                {
                    SN = e.Value;
                }
                else
                    throw new Exception(e.error);
                Assets assets = autofacConfig.orderCommonService.GetUnusedAssetsBySN(SN);
                if (assets == null) throw new Exception("不存在序列号为" + SN + "的闲置资产");
                Data.ASSID = assets.ASSID;
                Data.LOCATIONID = assets.LOCATIONID;
                Data.IMAGE = assets.IMAGE;
                Data.QTY = 0;
                Data.SN = SN;
                if (SNRowData !=null)
                {
                    foreach(AssetsOrderRow Row in SNRowData)
                    {
                        if (Data.ASSID == Row.ASSID)
                            throw new Exception("该资产已添加，请勿重复添加!");
                    }
                    SNRowData.Add(Data);
                }
                else
                {
                    List<AssetsOrderRow> Datas = new List<AssetsOrderRow>();
                    Datas.Add(Data);
                    SNRowData = Datas;
                }
                Bind();        //重新绑定数据
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }
        /// <summary>
        /// 手持按键扫描到条码时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void r2000Scanner1_BarcodeDataCaptured(object sender, Smobiler.Device.R2000BarcodeScanEventArgs e)
        {
            try
            {
                AssetsOrderRow Data = new AssetsOrderRow();
                SN = e.Data;
                Assets assets = autofacConfig.orderCommonService.GetUnusedAssetsBySN(SN);
                if (assets == null) throw new Exception("不存在序列号为" + SN + "的闲置资产");
                Data.ASSID = assets.ASSID;
                Data.LOCATIONID = assets.LOCATIONID;
                Data.IMAGE = assets.IMAGE;
                Data.QTY = 0;
                Data.SN = SN;
                if (SNRowData != null)
                {
                    foreach (AssetsOrderRow Row in SNRowData)
                    {
                        if (Data.ASSID == Row.ASSID)
                            throw new Exception("该资产已添加，请勿重复添加!");
                    }
                    SNRowData.Add(Data);
                }
                else
                {
                    List<AssetsOrderRow> Datas = new List<AssetsOrderRow>();
                    Datas.Add(Data);
                    SNRowData = Datas;
                }
                Bind();        //重新绑定数据
            }
            catch(Exception ex)
            {
                Toast(ex.Message);
            }
        }
        /// <summary>
        /// 手持按键扫描到RFID时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void r2000Scanner1_RFIDDataCaptured(object sender, Smobiler.Device.R2000RFIDScanEventArgs e)
        {
            try
            {
                AssetsOrderRow Data = new AssetsOrderRow();
                SN = e.Epc;
                Assets assets = autofacConfig.orderCommonService.GetUnusedAssetsBySN(SN);
                if (assets == null) throw new Exception();
                Data.ASSID = assets.ASSID;
                Data.LOCATIONID = assets.LOCATIONID;
                Data.IMAGE = assets.IMAGE;
                Data.QTY = 0;
                Data.SN = SN;
                if (SNRowData != null)
                {
                    foreach (AssetsOrderRow Row in SNRowData)
                    {
                        if (Data.ASSID == Row.ASSID)
                            throw new Exception();
                    }
                    SNRowData.Add(Data);
                }
                else
                {
                    List<AssetsOrderRow> Datas = new List<AssetsOrderRow>();
                    Datas.Add(Data);
                    SNRowData = Datas;
                }
                Bind();        //重新绑定数据
            }
            catch (Exception ex)
            {
                if(ex.Message!= "引发类型为“System.Exception”的异常。")
                {
                    Toast(ex.Message);
                }                
            }
        }
    }
}