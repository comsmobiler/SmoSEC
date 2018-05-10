using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Smobiler.Core;
using Smobiler.Core.Controls;
using SMOSEC.CommLib;
using SMOSEC.Domain.Entity;
using SMOSEC.UI.AssetsManager;

namespace SMOSEC.UI.MasterData
{


    partial class frmAssets : Smobiler.Core.Controls.MobileForm
    {
        private AutofacConfig _autofacConfig = new AutofacConfig();//调用配置类

        public string SelectAssId;

        private void frmAssets_KeyDown(object sender, KeyDownEventArgs e)
        {
            if (e.KeyCode == KeyCode.Back)
                Client.Exit();
        }

        public void Bind()
        {
            try
            {
                DataTable table = _autofacConfig.SettingService.GetAllAss();
                gridAssRows.Cells.Clear();
                table.Columns.Add("ChangeText");
                table.Columns.Add("IsChecked");
                foreach (DataRow Row in table.Rows)
                {
                    if (String.IsNullOrEmpty(Row["CurrentUser"].ToString()) == false)
                    {
                        Row["ChangeText"] = "使用人更换";
                    }
                    if(Row["AssId"].ToString()==SelectAssId)
                    {
                        Row["IsChecked"] = true;
                    }
                    else
                    {
                        Row["IsChecked"] = false;
                    }
                }
                if (table.Rows.Count > 0)
                {
                    gridAssRows.DataSource = table;
                    gridAssRows.DataBind();
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        private void frmAssets_Load(object sender, EventArgs e)
        {
            try
            {
                Bind();
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }

        }
        public String ASSID;          //更改使用者的资产编号  
        public String LastUser;       //上个使用者编号
        /// <summary>
        /// 更换使用者
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void popCurrentUser_Selected(object sender, EventArgs e)
        {
            try
            {
                if (popCurrentUser.Selection.Value != LastUser)     //如果更换了使用者
                {
                    ReturnInfo RInfo = _autofacConfig.AssetsService.ChangeUser(ASSID, popCurrentUser.Selection.Value, Client.Session["UserID"].ToString());
                    if (RInfo.IsSuccess)
                    {
                        Toast("更改使用者成功!");
                        LastUser = popCurrentUser.Selection.Value;
                    }
                    else
                    {
                        throw new Exception(RInfo.ErrorInfo);
                    }
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        private void ImgBtnForAssId_Press(object sender, EventArgs e)
        {
            try
            {
                barcodeScanner1.GetBarcode();
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
                string barCode = e.Data;
                DataTable table = _autofacConfig.SettingService.GetAssetsBySN(barCode);
                gridAssRows.Cells.Clear();
                table.Columns.Add("ChangeText");
                table.Columns.Add("IsChecked");
                foreach (DataRow Row in table.Rows)
                {
                    if (String.IsNullOrEmpty(Row["CurrentUser"].ToString()) == false)
                    {
                        Row["ChangeText"] = "使用人更换";
                    }
                    if (Row["AssId"].ToString() == SelectAssId)
                    {
                        Row["IsChecked"] = true;
                    }
                    else
                    {
                        Row["IsChecked"] = false;
                    }
                }
                if (table.Rows.Count > 0)
                {
                    gridAssRows.DataSource = table;
                    gridAssRows.DataBind();
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
                string RFID = e.Epc;
                DataTable table = _autofacConfig.SettingService.GetAssetsBySN(RFID);
                gridAssRows.Cells.Clear();
                table.Columns.Add("ChangeText");
                table.Columns.Add("IsChecked");
                foreach (DataRow Row in table.Rows)
                {
                    if (String.IsNullOrEmpty(Row["CurrentUser"].ToString()) == false)
                    {
                        Row["ChangeText"] = "使用人更换";
                    }
                    if (Row["AssId"].ToString() == SelectAssId)
                    {
                        Row["IsChecked"] = true;
                    }
                    else
                    {
                        Row["IsChecked"] = false;
                    }
                }
                if (table.Rows.Count > 0)
                {
                    gridAssRows.DataSource = table;
                    gridAssRows.DataBind();
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        private void frmAssets_ActionButtonPress(object sender, ActionButtonPressEventArgs e)
        {

            try
            {
                switch (e.Index)
                {
                    case 0:
                        frmAssetsCreate assCreate = new frmAssetsCreate();
                        Show(assCreate, (MobileForm sender1, object args) =>
                        {
                            if (assCreate.ShowResult == ShowResult.Yes)
                            {
                                Bind();
                            }

                        });
                        break;
                    case 1:
                        //资产复制
                        try
                        {
                            if (string.IsNullOrEmpty(SelectAssId))
                            {
                                throw new Exception("请先选择资产.");
                            }
                            var assets = _autofacConfig.SettingService.GetAssetsByID(SelectAssId);

                            frmAssetsCreate assetsCreate = new frmAssetsCreate
                            {
                                DatePickerBuy = { Value = assets.BuyDate },
                                txtDepart = { Text = assets.DepartmentId },
                                DatePickerExpiry = { Value = assets.ExpiryDate },
                                ImgPicture = { ResourceID = assets.Image },
                                LocationId = assets.LocationId,
                                btnLocation = { Text = assets.LocationName },
                                ManagerId = assets.Manager,
                                txtManager = { Text = assets.ManagerName },
                                txtName = { Text = assets.Name },
                                txtNote = { Text = assets.Note },
                                txtPlace = { Text = assets.Place },
                                txtPrice = { Text = assets.Price.ToString()},
                                txtSpe = { Text = assets.Specification },
                                TypeId = assets.TypeId,
                                btnType = { Text = assets.TypeName },
                                txtUnit = { Text = assets.Unit},
                                txtVendor = { Text = assets.Vendor }
                            };

                            Show(assetsCreate, (MobileForm sender1, object args) =>
                                {
                                    if (assetsCreate.ShowResult == ShowResult.Yes)
                                    {
                                        Bind();
                                    }

                                }
                            );
                        }
                        catch (Exception ex)
                        {
                            Toast(ex.Message);
                        }
                        break;                        ;
                    case 2:
                        //资产领用
                        frmCollarOrder frmCO = new frmCollarOrder();
                        Form.Show(frmCO);
                        break;
                    case 3:
                        //资产借用
                        frmBorrowOrder frmBO = new frmBorrowOrder();
                        Form.Show(frmBO);
                        break;
                    case 4:
                        //维修登记
                        frmRepairRowsSN frmR = new frmRepairRowsSN();
                        this.Form.Show(frmR);
                        break;
                    case 5:
                        //报废
                        frmScrapRowsSN frmS = new frmScrapRowsSN();
                        this.Form.Show(frmS);
                        break;
                    case 6:
                        //调拨
                        frmTransferRowsSN frmT = new frmTransferRowsSN();
                        this.Form.Show(frmT);
                        break;
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }

        }

        private void barcodeScanner1_BarcodeScanned(object sender, BarcodeResultArgs e)
        {
            try
            {
                string barCode = e.Value;
                DataTable table = _autofacConfig.SettingService.GetAssetsBySN(barCode);
                gridAssRows.Cells.Clear();
                table.Columns.Add("ChangeText");
                table.Columns.Add("IsChecked");
                foreach (DataRow Row in table.Rows)
                {
                    if (String.IsNullOrEmpty(Row["CurrentUser"].ToString()) == false)
                    {
                        Row["ChangeText"] = "使用人更换";
                    }
                    if (Row["AssId"].ToString() == SelectAssId)
                    {
                        Row["IsChecked"] = true;
                    }
                    else
                    {
                        Row["IsChecked"] = false;
                    }
                }
                if (table.Rows.Count > 0)
                {
                    gridAssRows.DataSource = table;
                    gridAssRows.DataBind();
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        private void txtFactor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable table = _autofacConfig.SettingService.QueryAssets(txtSnOrName.Text);
                gridAssRows.Cells.Clear();
                table.Columns.Add("ChangeText");
                table.Columns.Add("IsChecked");
                foreach (DataRow Row in table.Rows)
                {
                    if (String.IsNullOrEmpty(Row["CurrentUser"].ToString()) == false)
                    {
                        Row["ChangeText"] = "使用人更换";
                    }
                    if (Row["AssId"].ToString() == SelectAssId)
                    {
                        Row["IsChecked"] = true;
                    }
                    else
                    {
                        Row["IsChecked"] = false;
                    }
                }
                if (table.Rows.Count > 0)
                {
                    gridAssRows.DataSource = table;
                    gridAssRows.DataBind();
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }
    }
}