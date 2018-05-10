using System;
using System.Collections.Generic;
using System.Data;
using SMOSEC.CommLib;
using SMOSEC.Domain.Entity;
using SMOSEC.DTOs.InputDTO;
using SMOSEC.UI.Layout;
using Smobiler.Core.Controls;

namespace SMOSEC.UI.ConsumablesManager
{
    partial class frmWRCreate : Smobiler.Core.Controls.MobileForm
    {
        private AutofacConfig _autofacConfig = new AutofacConfig();//调用配置类
        private string LocationId;
        private string HManId;
        public DataTable ConTable;
        public List<string> ConList;
        private string UserId;
        private List<WarehouseReceiptRowInputDto> rowsInputDtos=new List<WarehouseReceiptRowInputDto>();
        private void btnSave_Press(object sender, EventArgs e)
        {
            try
            {
                GetRows();
                WarehouseReceiptInputDto warehouseReceiptInput = new WarehouseReceiptInputDto()
                {
                    BUSINESSDATE = DPickerCO.Value,
                    MODIFYUSER = UserId,
                    CREATEUSER = UserId,
                    HANDLEDATE = DateTime.Now,
                    LOCATIONID = LocationId,
                    NOTE = txtNote.Text,
                    HANDLEMAN = HManId,
                    RowInputDtos= rowsInputDtos,
                    VENDOR = txtVendor.Text
                };
                ReturnInfo returnInfo = _autofacConfig.ConsumablesService.AddWarehouseReceipt(warehouseReceiptInput);
                if (returnInfo.IsSuccess)
                {
                    ShowResult = ShowResult.Yes;
                    Toast("添加成功");
                    Close();
                }
                else
                {
                    Toast(returnInfo.ErrorInfo);
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

//        private void btnHMan_Press(object sender, EventArgs e)
//        {
//            try
//            {
//                PopHMan.Groups.Clear();
//                PopListGroup hManGroup = new PopListGroup();
//                PopHMan.Title = "处理人选择";
//                List<coreUser> users = _autofacConfig.coreUserService.GetAdmin();
//                foreach (coreUser Row in users)
//                {
//                    hManGroup.AddListItem(Row.USER_NAME, Row.USER_ID);
//                }
//                PopHMan.Groups.Add(hManGroup);
//                if (btnHMan.Tag != null)   //如果已有选中项，则显示选中效果
//                {
//                    foreach (PopListItem Item in hManGroup.Items)
//                    {
//                        if (Item.Value == btnHMan.Tag.ToString())
//                            PopHMan.SetSelections(Item);
//                    }
//                }
//                PopHMan.ShowDialog();
//
//
//            }
//            catch (Exception ex)
//            {
//                Toast(ex.Message);
//            }
//        }


        private void btnLocation_Press(object sender, EventArgs e)
        {
            try
            {
                PopLocation.Groups.Clear();
                PopListGroup locationGroup = new PopListGroup();
                List<AssLocation> locations = _autofacConfig.assLocationService.GetEnableAll();
                foreach (var location in locations)
                {
                    PopListItem item = new PopListItem
                    {
                        Value = location.LOCATIONID,
                        Text = location.NAME
                    };
                    locationGroup.Items.Add(item);
                }
                PopLocation.Groups.Add(locationGroup);
                if (!string.IsNullOrEmpty(btnLocation.Text))
                {
                    foreach (PopListItem row in PopLocation.Groups[0].Items)
                    {
                        if (row.Text == btnLocation.Text)
                        {
                            PopLocation.SetSelections(row);
                        }
                    }
                }
                PopLocation.ShowDialog();
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }


        private void frmWRCreate_KeyDown(object sender, KeyDownEventArgs e)
        {
            if (e.KeyCode == KeyCode.Back)
                Close();
        }


        private void PopHMan_Selected(object sender, EventArgs e)
        {
//            try
//            {
//                if (PopHMan.Selection != null)
//                {
//                    btnHMan.Text = PopHMan.Selection.Text;
//                    HManId = PopHMan.Selection.Value;
//                }
//            }
//            catch (Exception ex)
//            {
//                Toast(ex.Message);
//            }
        }

        private void PopLocation_Selected(object sender, EventArgs e)
        {
            try
            {

                if (PopLocation.Selection != null)
                {

                    if (string.IsNullOrEmpty(btnLocation.Text))
                    {
                        LocationId = PopLocation.Selection.Value;
                    }
                    btnLocation.Text = PopLocation.Selection.Text;
                    AssLocation location = _autofacConfig.assLocationService.GetByID(LocationId);
                    coreUser manager = _autofacConfig.coreUserService.GetUserByID(location.MANAGER);
                    HManId = location.MANAGER;
                    txtHMan.Text = manager.USER_NAME;
                    if (LocationId != null && LocationId != PopLocation.Selection.Value)
                    {
                        LocationId = PopLocation.Selection.Value;
                        ClearInfo();
                    }
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        private void ClearInfo()
        {
            ConTable.Rows.Clear();
            BindListView();
        }

        public void BindListView()
        {
            try
            {
                listViewCon.DataSource = ConTable;
                listViewCon.DataBind();
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }

        }

        private void btnAdd_Press(object sender, EventArgs e)
        {
            try
            {
//                if (string.IsNullOrEmpty(btnLocation.Text))
//                {
//                    throw new Exception("请先选择区域.");
//                }
                GetCon();
                GetRows();
                frmConsumablesChoose consumablesChoose = new frmConsumablesChoose
                {
                    ConList = ConList,
                    ConTable = ConTable,
                    LocationId = LocationId,
                    OperationType = OperationType.入库,
                    WrList = rowsInputDtos
                };
                Show(consumablesChoose, (MobileForm sender1, object args) =>
                {
                    if (consumablesChoose.ShowResult == ShowResult.Yes)
                    {
                        ConTable = consumablesChoose.ConTable;
                        ConList = consumablesChoose.ConList;
                        BindListView();
                    }
                });

            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        private void GetRows()
        {
            rowsInputDtos.Clear();
            foreach (var row in listViewCon.Rows)
            {

                OperCreateConLayout CRow = (OperCreateConLayout)row.Control;
                decimal Quantity;
                if (decimal.TryParse(CRow.numQuant.Value.ToString(), out Quantity) == false)
                {
                    throw new Exception("耗材编号" + CRow.lblASSID.Text + "的数量格式不正确。");
                }
                decimal Money;
                if (decimal.TryParse(CRow.numMoney.Value.ToString(), out Money) == false)
                {
                    throw new Exception("耗材编号" + CRow.lblASSID.Text + "的金额格式不正确。");
                }
                WarehouseReceiptRowInputDto rowInput = new WarehouseReceiptRowInputDto
                {
                    CID = CRow.lblASSID.Text,
                    MONEY = Money,
                    NOTE = CRow.txtRNote.Text,
                    QUANTITY = Quantity
                };
                rowsInputDtos.Add(rowInput);
            }
        }

        private void GetCon()
        {
            //            rowsInputDtos.Clear();
            foreach (var row in listViewCon.Rows)
            {

                OperCreateConLayout CRow = (OperCreateConLayout)row.Control;                
                decimal Quantity;
                if (decimal.TryParse(CRow.numQuant.Value.ToString(), out Quantity) == false)
                {
                    throw new Exception("耗材编号" + CRow.lblASSID.Text + "的数量格式不正确。");
                }
                decimal Money;
                if (decimal.TryParse(CRow.numMoney.Value.ToString(), out Money) == false)
                {
                    throw new Exception("耗材编号" + CRow.lblASSID.Text + "的金额格式不正确。");
                }
                DataRow Drow = ConTable.Rows.Find(CRow.lblASSID.Text);
                Drow["QUANT"] = 0;
                Drow["QUANTITY"] = Quantity;
                Drow["MONEY"] = Money;
            }

        }
        private void frmWRCreate_Load(object sender, EventArgs e)
        {
            try
            {
                if (ConTable == null)
                {
                    ConTable=new DataTable();
                }
                if (ConTable.Columns.Count == 0)
                {
                    ConTable.Columns.Add("IMAGE");
                    ConTable.Columns.Add("CID");
                    ConTable.Columns.Add("NAME");
                    ConTable.Columns.Add("TYPE");
                    ConTable.Columns.Add("QUANT");
                    ConTable.Columns.Add("QUANTITY");
                    ConTable.Columns.Add("MONEY");
                }
                DataColumn[] keys = new DataColumn[1];
                keys[0] = ConTable.Columns["CID"];
                ConTable.PrimaryKey = keys;

                UserId = Client.Session["UserID"].ToString();
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }
    }
}