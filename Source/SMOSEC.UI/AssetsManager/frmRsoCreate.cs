using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SMOSEC.CommLib;
using SMOSEC.Domain.Entity;
using SMOSEC.DTOs.InputDTO;
using Smobiler.Core.Controls;

namespace SMOSEC.UI.AssetsManager
{
    partial class frmRsoCreate : Smobiler.Core.Controls.MobileForm
    {
        private AutofacConfig _autofacConfig = new AutofacConfig();//调用配置类

        public List<string> AssIdList = new List<string>();

        public DataTable AssTable = new DataTable();
        public string LocationId;
        public string RtoManId;
        public string HManId;
        private string UserId;

        private void btnConfirm_Press(object sender, EventArgs e)
        {
            try
            {
                AssRestoreOrderInputDto assRestoreOrder = new AssRestoreOrderInputDto()
                {
                    AssIds = AssIdList,
                    RESTOREDATE = DPickerRs.Value,
                    RESTORER = RtoManId,
//                    Restorer = "897",
                    HANDLEMAN = HManId,
//                    HandleMan = "498",
                    CREATEUSER = UserId,
                    PLACE = txtPlace.Text,
//                    EptReturnDate = DPickerRs.Value,
                    LOCATIONID = LocationId,
//                    LocationId = "54",
                    MODIFYUSER = UserId,
                    NOTE = txtNote.Text
                };                
                ReturnInfo returnInfo = _autofacConfig.AssetsService.AddAssRestoreOrder(assRestoreOrder);
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

//        private void btnLocation_Press(object sender, EventArgs e)
//        {
//            try
//            {
//                PopLocation.Groups.Clear();
//                PopListGroup locationGroup = new PopListGroup();
//                List<AssLocation> locations = _autofacConfig.assLocationService.GetAll();
//                foreach (var location in locations)
//                {
//                    PopListItem item = new PopListItem
//                    {
//                        Value = location.LOCATIONID,
//                        Text = location.NAME
//                    };
//                    locationGroup.Items.Add(item);
//                }
//                PopLocation.Groups.Add(locationGroup);
//                if (!string.IsNullOrEmpty(btnLocation.Text))
//                {
//                    foreach (PopListItem row in PopLocation.Groups[0].Items)
//                    {
//                        if (row.Text == btnLocation.Text)
//                        {
//                            PopLocation.SetSelections(row);
//                        }
//                    }
//                }
//                PopLocation.ShowDialog();
//            }
//            catch (Exception ex)
//            {
//                Toast(ex.Message);
//            }
//        }

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

        private void btnRSMan_Press(object sender, EventArgs e)
        {
            try
            {
                PopRSMan.Groups.Clear();
                PopListGroup manGroup = new PopListGroup();
                PopRSMan.Title = "退库人选择";
                List<coreUser> users = _autofacConfig.coreUserService.GetAll();
                foreach (coreUser Row in users)
                {
                    manGroup.AddListItem(Row.USER_NAME, Row.USER_ID);
                }
                PopRSMan.Groups.Add(manGroup);
                if (btnRSMan.Tag != null)   //如果已有选中项，则显示选中效果
                {
                    foreach (PopListItem Item in manGroup.Items)
                    {
                        if (Item.Value == btnRSMan.Tag.ToString())
                            PopRSMan.SetSelections(Item);
                    }
                }
                PopRSMan.ShowDialog();

            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        private void ImgBtnForBarcode_Press(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtLocation.Text))
                {
                    throw new Exception("请先选择区域");
                }
                else
                {
                      barcodeScanner1.GetBarcode();
//                    r2000Scanner1.BarcodeScan();
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        //private void btnAdd_Press(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(btnLocation.Text))
        //        {
        //            throw new Exception("请先选择区域。");
        //        }
        //        else
        //        {
        //            //判断
        //            frmSourceChoose frmSourceChoose = new frmSourceChoose
        //            {
        //                AssTable = AssTable,
        //                LocationId = LocationId,
        //                AssIdList = AssIdList,
        //                OperationType = OperationType.退库
        //            };
        //            Show(frmSourceChoose, (MobileForm sender1, object args) =>
        //            {
        //                if (frmSourceChoose.ShowResult == ShowResult.Yes)
        //                {
        //                    AssTable = frmSourceChoose.AssTable;
        //                    AssIdList = frmSourceChoose.AssIdList;
        //                    BindListView();
        //                }
        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Toast(ex.Message);
        //    }
        //}

        private void FrmRsoCreate_KeyDown(object sender, KeyDownEventArgs e)
        {
            if (e.KeyCode == KeyCode.Back)
                Close();
        }

        private void FrmRsoCreate_Load(object sender, EventArgs e)
        {
            try
            {
                if (AssTable.Columns.Count == 0)
                {
                    AssTable.Columns.Add("IMAGE");
                    AssTable.Columns.Add("ASSID");
                    AssTable.Columns.Add("NAME");
                    AssTable.Columns.Add("TYPE");
                    AssTable.Columns.Add("SN");
                }
                DataColumn[] keys = new DataColumn[1];
                keys[0] = AssTable.Columns["ASSID"];
                AssTable.PrimaryKey = keys;

                UserId = Client.Session["UserID"].ToString();
                //                btnLocation.Text = "54";
                //                LocationId = "54";

                //                ListView listView=new ListView();
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
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
//                if (PopLocation.Selection != null)
//                {
//                    if (string.IsNullOrEmpty(btnLocation.Text))
//                    {
//                        LocationId = PopLocation.Selection.Value;
//                    }
//                    btnLocation.Text = PopLocation.Selection.Text;
//                    if (LocationId != null && LocationId != PopLocation.Selection.Value)
//                    {
//                        LocationId = PopLocation.Selection.Value;
//                        ClearInfo();
//                    }
//                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        private void PopRSMan_Selected(object sender, EventArgs e)
        {
            try
            {
                if (PopRSMan.Selection != null)
                {
                    btnRSMan.Text = PopRSMan.Selection.Text;
                    if (RtoManId != null && RtoManId != PopRSMan.Selection.Value)
                    {
//                        RtoManId = PopLocation.Selection.Value;
                        ClearInfo();
                    }

                    RtoManId = PopRSMan.Selection.Value;
                    coreUser user= _autofacConfig.coreUserService.GetUserByID(RtoManId);
                    LocationId = user.USER_LOCATIONID;
                    
                    AssLocation location = _autofacConfig.assLocationService.GetByID(LocationId);
                    txtLocation.Text = location.NAME;
                    coreUser manager = _autofacConfig.coreUserService.GetUserByID(location.MANAGER);
                    HManId = location.MANAGER;
                    txtHMan.Text = manager.USER_NAME;
                    
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        

        public void BindListView()
        {
            try
            {
                ListAss.DataSource = AssTable;
                ListAss.DataBind();
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }

        }

        private void ClearInfo()
        {
            AssTable.Rows.Clear();
            AssIdList.Clear();
            BindListView();
        }

        public void AddAss(string assId, string sn, string image, string name)
        {
            try
            {
                if (AssIdList.Contains(assId))
                {
//                    throw new Exception("已添加过该资产。");
                }
                else
                {
                    DataRow row = AssTable.NewRow();
                    row["ASSID"] = assId;
                    row["SN"] = sn;
                    row["IMAGE"] = image;
                    row["NAME"] = name;
                    row["TYPE"] = "RSO";
                    AssTable.Rows.Add(row);
                    AssIdList.Add(assId);
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }

        }

        public void RemoveAss(string assId)
        {
            try
            {
                DataRow row = AssTable.Rows.Find(assId);
                AssTable.Rows.Remove(row);
                AssIdList.Remove(assId);
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        private void r2000Scanner1_BarcodeDataCaptured(object sender, Smobiler.Device.R2000BarcodeScanEventArgs e)
        {
            try
            {


                if (string.IsNullOrEmpty(txtLocation.Text))
                {
                    throw new Exception("请先选择退库人");
                }
                else
                {
                    string barCode = e.Data;
                    DataTable info = _autofacConfig.SettingService.GetInUseAssEx(LocationId, barCode, RtoManId);
                    if (info.Rows.Count == 0)
                    {
                        throw new Exception("未在领用的物品中找到该物品");
                    }
                    else
                    {
                        DataRow row = info.Rows[0];
                        AddAss(row["ASSID"].ToString(), barCode, row["IMAGE"].ToString(), row["NAME"].ToString());
                        BindListView();
                    }
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        private void r2000Scanner1_RFIDDataCaptured(object sender, Smobiler.Device.R2000RFIDScanEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtLocation.Text))
                {
                    throw new Exception();
                }
                else
                {
                    string RFID = e.Epc;
                    DataTable info = _autofacConfig.SettingService.GetInUseAssEx(LocationId, RFID, RtoManId);
                    if (info.Rows.Count == 0)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        DataRow row = info.Rows[0];
                        AddAss(row["ASSID"].ToString(), RFID, row["IMAGE"].ToString(), row["NAME"].ToString());
                        BindListView();
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message != "引发类型为“System.Exception”的异常。")
                {
                    Toast(ex.Message);
                }
            }
        }

        private void barcodeScanner1_BarcodeScanned_1(object sender, BarcodeResultArgs e)
        {
            try
            {


                if (string.IsNullOrEmpty(txtLocation.Text))
                {
                    throw new Exception("请先选择退库人");
                }
                else
                {
                    string barCode = e.Value;
                    DataTable info = _autofacConfig.SettingService.GetInUseAssEx(LocationId, barCode, RtoManId);
                    if (info.Rows.Count == 0)
                    {
                        throw new Exception("未在领用的物品中找到该物品");
                    }
                    else
                    {
                        DataRow row = info.Rows[0];
                        AddAss(row["ASSID"].ToString(), barCode, row["IMAGE"].ToString(), row["NAME"].ToString());
                        BindListView();
                    }
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }
    }
}