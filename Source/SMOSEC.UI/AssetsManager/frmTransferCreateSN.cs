using System;
using System.Collections.Generic;
using Smobiler.Core.Controls;
using SMOSEC.DTOs.InputDTO;
using SMOSEC.Domain.Entity;
using SMOSEC.CommLib;
using SMOSEC.UI.Layout;
using System.Data;
using SMOSEC.DTOs.Enum;

namespace SMOSEC.UI.AssetsManager
{
    partial class frmTransferCreateSN : Smobiler.Core.Controls.MobileForm
    {
        #region "definition"
        AutofacConfig autofacConfig = new AutofacConfig();     //调用配置类
        public List<AssetsOrderRow> SNRowData;   //开启SN行项
        public TOInputDto TransferData = new TOInputDto();         //调拨单信息
        private String SN;       //序列号
        #endregion
        /// <summary>
        /// 加载数据
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
        /// 调入管理员选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDealInMan_Press(object sender, EventArgs e)
        {
            try
            {
                popDealInMan.Groups.Clear();       //数据清空
                PopListGroup poli = new PopListGroup();
                popDealInMan.Groups.Add(poli);
                poli.Title = "调入管理员选择";
                List<coreUser> users = autofacConfig.coreUserService.GetDealInAdmin();
                foreach (coreUser Row in users)
                {
                    poli.AddListItem(Row.USER_NAME, Row.USER_ID);
                }
                if (btnDealMan.Tag != null)   //如果已有选中项，则显示选中效果
                {
                    foreach (PopListItem Item in poli.Items)
                    {
                        if (Item.Value == btnDealMan.Tag.ToString())
                            popDealInMan.SetSelections(Item);
                    }
                }
                popDealInMan.ShowDialog();
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }
        /// <summary>
        /// 选择调入管理员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void popDealInMan_Selected(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(popDealInMan.Selection.Text) == false)
            {
                btnDealInMan.Text = popDealInMan.Selection.Text + "   > ";
                btnDealInMan.Tag = popDealInMan.Selection.Value;         //调入管理员编号
            }
        }
        /// <summary>
        /// 区域选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLocation_Press(object sender, EventArgs e)
        {
            try
            {
                popLocation.Groups.Clear();       //数据清空
                PopListGroup poli = new PopListGroup();
                popLocation.Groups.Add(poli);
                poli.Title = "调入区域选择";
                List<AssLocation> users = autofacConfig.assLocationService.GetEnableAll();
                foreach (AssLocation Row in users)
                {
                    poli.AddListItem(Row.NAME, Row.LOCATIONID);
                }
                if (btnLocation.Tag != null)   //如果已有选中项，则显示选中效果
                {
                    foreach (PopListItem Item in poli.Items)
                    {
                        if (Item.Value == btnLocation.Tag.ToString())
                            popLocation.SetSelections(Item);
                    }
                }
                popLocation.ShowDialog();
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }
        /// <summary>
        /// 选择区域
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void popLocation_Selected(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(popLocation.Selection.Text) == false)
                {
                    if (btnLocation.Tag == null)     //如果已有选择区域
                    {

                        btnLocation.Text = popLocation.Selection.Text + "   > ";
                        btnLocation.Tag = popLocation.Selection.Value;         //区域编号
                    }
                    else
                    {
                        if (SNRowData != null)       //如果已有选择行项
                        {
                            if (popLocation.Selection.Value != btnLocation.Tag.ToString())
                            {
                                MessageBox.Show("更换调入区域将会清空所选资产，是否更换？", "系统提示", MessageBoxButtons.YesNo, (object sender1, MessageBoxHandlerArgs args) =>
                                {
                                    try
                                    {
                                        if (args.Result == ShowResult.Yes)
                                        {
                                            SNRowData.Clear();
                                            Bind();          //重新绑定数据
                                            btnLocation.Text = popLocation.Selection.Text + "   > ";
                                            btnLocation.Tag = popLocation.Selection.Value;         //区域编号
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Toast(ex.Message);
                                    }
                                });
                            }
                        }
                        else       //没有选择行项
                        {
                            btnLocation.Text = popLocation.Selection.Text + "   > ";
                            btnLocation.Tag = popLocation.Selection.Value;         //区域编号
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
        /// 选择处理人
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
        /// 扫描条码添加资产
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void betGet_Press(object sender, EventArgs e)
        {
            try
            {
                if (btnLocation.Tag == null) throw new Exception("请选择调入区域!");
                BarcodeScanner1.GetBarcode();
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
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
                if (assets.LOCATIONID == btnLocation.Tag.ToString()) throw new Exception("该资产已在目的区域!");
                Data.ASSID = assets.ASSID;
                Data.LOCATIONID = assets.LOCATIONID;
                Data.IMAGE = assets.IMAGE;
                Data.QTY = 0;
                Data.SN = SN;
                if (SNRowData != null)
                {
                    foreach (AssetsOrderRow Row in SNRowData)
                    {
                        if (Data.ASSID == Row.ASSID && Data.SN == Row.SN)
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
        /// 创建调拨单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Press(object sender, EventArgs e)
        {
            try
            {
                if (btnDealInMan.Tag == null)
                    throw new Exception("调入管理员不能为空");
                else
                    TransferData.MANAGER = btnDealInMan.Tag.ToString();     //调入管理员

                if (btnLocation.Tag == null)
                    throw new Exception("调入区域不能为空");
                else
                    TransferData.DESLOCATIONID = btnLocation.Tag.ToString();     //调入区域

                if (btnDealMan.Tag == null)
                    throw new Exception("处理人不能为空");
                else
                    TransferData.HANDLEMAN = btnDealMan.Tag.ToString();     //处理人

                TransferData.TRANSFERDATE = DatePicker.Value;   //维修花费
                TransferData.NOTE = txtNote.Text;                           //备注
                TransferData.STATUS = 0;                                    //维修单状态
                TransferData.ISSNCONTROL = (Int32)ISSNCONTROL.启用;         //是否属于SN
                TransferData.CREATEUSER = Client.Session["UserID"].ToString();      //创建用户
                TransferData.CREATEDATE = DateTime.Now;

                List<AssTransferOrderRow> Data = new List<AssTransferOrderRow>();
                if (ListAssetsSN.Rows.Count == 0) throw new Exception("调拨行项不能为空!");
                foreach (ListViewRow Row in ListAssetsSN.Rows)
                {
                    frmOrderCreateSNLayout Layout = Row.Control as frmOrderCreateSNLayout;
                    AssetsOrderRow RowData = Layout.getData();
                    AssTransferOrderRow assRow = new AssTransferOrderRow();

                    assRow.IMAGE = RowData.IMAGE;
                    assRow.ASSID = RowData.ASSID;
                    assRow.INTRANSFERQTY = RowData.QTY;
                    assRow.SN = RowData.SN;
                    assRow.LOCATIONID = RowData.LOCATIONID;
                    assRow.STATUS = RowData.STATUS;
                    assRow.CREATEDATE = DateTime.Now;
                    Data.Add(assRow);
                }
                TransferData.Rows = Data;
                ReturnInfo r = autofacConfig.assTransferOrderService.AddAssTransferOrder(TransferData, OperateType.资产);
                if (r.IsSuccess)
                {
                    ShowResult = ShowResult.Yes;
                    Form.Close();          //创建成功
                    Toast("创建调拨单成功!");
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
        /// 当手持扫描到条码时
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
                if (assets.LOCATIONID == btnLocation.Tag.ToString()) throw new Exception("该资产已在目的区域!");
                Data.ASSID = assets.ASSID;
                Data.LOCATIONID = assets.LOCATIONID;
                Data.IMAGE = assets.IMAGE;
                Data.QTY = 0;
                Data.SN = SN;
                if (SNRowData != null)
                {
                    foreach (AssetsOrderRow Row in SNRowData)
                    {
                        if (Data.ASSID == Row.ASSID && Data.SN == Row.SN)
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
        /// 当手持扫描到RFID时
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
                if (assets.LOCATIONID == btnLocation.Tag.ToString()) throw new Exception();
                Data.ASSID = assets.ASSID;
                Data.LOCATIONID = assets.LOCATIONID;
                Data.IMAGE = assets.IMAGE;
                Data.QTY = 0;
                Data.SN = SN;
                if (SNRowData != null)
                {
                    foreach (AssetsOrderRow Row in SNRowData)
                    {
                        if (Data.ASSID == Row.ASSID && Data.SN == Row.SN)
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
                if (ex.Message != "引发类型为“System.Exception”的异常。")
                {
                    Toast(ex.Message);
                }
            }
        }
    }
}