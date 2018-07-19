using System;
using System.Collections.Generic;
using Smobiler.Core.Controls;
using SMOSEC.DTOs.InputDTO;
using SMOSEC.Domain.Entity;
using SMOSEC.UI.Layout;
using SMOSEC.CommLib;
using System.Data;
using SMOSEC.DTOs.Enum;

namespace SMOSEC.UI.ConsumablesManager
{
    partial class frmTransferCreate : Smobiler.Core.Controls.MobileForm
    {
        #region "definition"
        AutofacConfig autofacConfig = new AutofacConfig();     //调用配置类
        public List<ConsumablesOrderRow> RowData = new List<ConsumablesOrderRow>();    //未开启SN行项
        public TOInputDto TransferData = new TOInputDto();        //维修单信息
        public String CID;               //耗材编号
        #endregion
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
                TransferData.CREATEUSER = Client.Session["UserID"].ToString();      //创建用户
                TransferData.CREATEDATE = DateTime.Now;

                List<AssTransferOrderRow> Data = new List<AssTransferOrderRow>();
                if (ListAssets.Rows.Count == 0) throw new Exception("调拨行项不能为空!");
                foreach (ListViewRow Row in ListAssets.Rows)
                {
                    frmOrderCreateLayout Layout = Row.Control as frmOrderCreateLayout;
                    ConsumablesOrderRow RowData = Layout.getData();
                    AssTransferOrderRow assRow = new AssTransferOrderRow();

                    assRow.IMAGE = RowData.IMAGE;
                    assRow.CID = RowData.CID;
                    assRow.INTRANSFERQTY = RowData.QTY;
                    assRow.LOCATIONID = RowData.LOCATIONID;
                    assRow.STATUS = RowData.STATUS;
                    assRow.CREATEDATE = DateTime.Now;
                    Data.Add(assRow);
                }
                TransferData.Rows = Data;
                ReturnInfo r = autofacConfig.assTransferOrderService.AddAssTransferOrder(TransferData,OperateType.耗材);
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
        /// 数据加载
        /// </summary>
        public void Bind()
        {
            try
            {
                DataTable tableAssets = new DataTable();       //未开启SN的资产列表
                tableAssets.Columns.Add("CID");              //资产编号
                tableAssets.Columns.Add("NAME");               //资产名称 
                tableAssets.Columns.Add("LOCATIONID");         //区域编号 
                tableAssets.Columns.Add("LOCATIONNAME");       //区域名称
                tableAssets.Columns.Add("IMAGE");              //图片编号
                tableAssets.Columns.Add("QUANTITY");          //空闲数量
                tableAssets.Columns.Add("SELECTQTY");          //选择数量
                if (RowData.Count > 0)
                {
                    foreach (ConsumablesOrderRow Row in RowData)
                    {
                        ConQuant conQuant = autofacConfig.orderCommonService.GetUnUseConByCID(Row.CID,Row.LOCATIONID);
                        Consumables con = autofacConfig.orderCommonService.GetConsByID(Row.CID);
                        AssLocation Loc = autofacConfig.assLocationService.GetByID(Row.LOCATIONID);
                        tableAssets.Rows.Add(Row.CID, con.NAME, Row.LOCATIONID, Loc.NAME, con.IMAGE, conQuant.QUANTITY, Row.QTY);
                    }
                }
                ListAssets.DataSource = tableAssets;
                ListAssets.DataBind();
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }
        /// <summary>
        /// 删除当前选择行项
        /// </summary>
        /// <param name="ASSID"></param>
        public void ReMoveAss(String CID)
        {
            foreach (ConsumablesOrderRow Row in RowData)
            {
                if (Row.CID == CID)
                {
                    RowData.Remove(Row);
                    break;
                }
            }
            Bind();       //刷新当前页面
        }
        /// <summary>
        /// 资产添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Press(object sender, EventArgs e)
        {
            try
            {
                if (btnLocation.Tag == null) throw new Exception("请选择调入区域!");
                List<ConsumablesOrderRow> Data = new List<ConsumablesOrderRow>();
                foreach (ListViewRow Row in ListAssets.Rows)
                {
                    frmOrderCreateLayout Layout = Row.Control as frmOrderCreateLayout;
                    Data.Add(Layout.getData());
                }

                frmTransferConsChoose frm = new frmTransferConsChoose();
                frm.RowData = Data;
                frm.LocInID = btnLocation.Tag.ToString();
                Show(frm, (MobileForm sender1, object args) =>
                {
                    if (frm.ShowResult == ShowResult.Yes)
                    {
                        //重新加载数据
                        RowData = frm.RowData;
                        Bind();
                    }
                });
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
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
                ConsumablesOrderRow Data = new ConsumablesOrderRow();
                if (string.IsNullOrEmpty(e.error))
                    CID = e.Value;
                else
                    throw new Exception(e.error);
                List<ConQuant> assList = autofacConfig.orderCommonService.GetUnUseCon(btnLocation.Tag.ToString(),CID);
                if (assList.Count > 1)
                {
                    popConLoc.Groups.Clear();
                    PopListGroup poli = new PopListGroup();
                    popConLoc.Groups.Add(poli);
                    foreach (ConQuant Row in assList)
                    {
                        if (Row.LOCATIONID != btnLocation.Tag.ToString())
                        {
                            AssLocation Loc = autofacConfig.assLocationService.GetByID(Row.LOCATIONID);
                            poli.AddListItem(Loc.NAME, Row.LOCATIONID);
                        }                       
                    }
                    popConLoc.ShowDialog();
                }
                else
                {
                    if(assList[0].LOCATIONID== btnLocation.Tag.ToString()) throw new Exception("该资产已在目的区域!");
                    Consumables cons = autofacConfig.orderCommonService.GetConsByID(CID);
                    Data.CID = CID;
                    Data.LOCATIONID = assList[0].LOCATIONID;
                    Data.IMAGE = cons.IMAGE;
                    Data.QTY = 0;
                    if (RowData.Count > 0)
                    {
                        RowData.Add(Data);
                    }
                    else
                    {
                        List<ConsumablesOrderRow> Datas = new List<ConsumablesOrderRow>();
                        Datas.Add(Data);
                        RowData = Datas;
                    }
                    Bind();
                }
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
        /// 选择区域
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void popLocation_Selected(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(popLocation.Selection.Text) == false)     //选中了某个区域
                {
                    if (btnLocation.Tag == null)     //如果之前没有选择区域
                    {
                        btnLocation.Text = popLocation.Selection.Text + "   > ";
                        btnLocation.Tag = popLocation.Selection.Value;         //区域编号                  
                    }
                    else           //之前选择了区域
                    {
                        if (RowData.Count > 0)       //如果已有选择行项
                        {
                            if (popLocation.Selection.Value != btnLocation.Tag.ToString())
                            {
                                MessageBox.Show("更换调入区域将会清空所选资产，是否更换？", "系统提示", MessageBoxButtons.YesNo, (object sender1, MessageBoxHandlerArgs args) =>
                                {
                                    try
                                    {
                                        if (args.Result == ShowResult.Yes)
                                        {
                                            RowData.Clear();
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
        /// 耗材选定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void popConLoc_Selected(object sender, EventArgs e)
        {
            try
            {
                if(String.IsNullOrEmpty(popConLoc.Selection.Text) == false)
                {
                    Consumables cons = autofacConfig.orderCommonService.GetConsByID(CID);
                    ConsumablesOrderRow Data = new ConsumablesOrderRow();
                    Data.CID = CID;
                    Data.LOCATIONID = popConLoc.Selection.Value;
                    Data.IMAGE = cons.IMAGE;
                    Data.QTY = 0;
                    if (RowData.Count > 0)
                    {
                        RowData.Add(Data);
                    }
                    else
                    {
                        List<ConsumablesOrderRow> Datas = new List<ConsumablesOrderRow>();
                        Datas.Add(Data);
                        RowData = Datas;
                    }
                    Bind();
                }            
            }
            catch(Exception ex)
            {
                Toast(ex.Message);
            }
        }
    }
}