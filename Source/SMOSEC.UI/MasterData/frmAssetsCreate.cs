using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SMOSEC.Application.Services;
using SMOSEC.CommLib;
using SMOSEC.Domain.Entity;
using SMOSEC.DTOs.InputDTO;
using Smobiler.Core;
using Smobiler.Core.Controls;

namespace SMOSEC.UI.MasterData
{
    partial class frmAssetsCreate : Smobiler.Core.Controls.MobileForm
    {
        public string UserId;
        public string TypeId;
        public string LocationId;
        public string ManagerId;

        private AutofacConfig _autofacConfig = new AutofacConfig();//调用配置类

        private void btnSave_Press(object sender, EventArgs e)
        { 
            try
            {
                AssetsInputDto assetsInputDto = new AssetsInputDto
                {
                    AssId = txtAssID.Text,
                    BuyDate = DatePickerBuy.Value,
                    CreateUser = UserId,
                    CurrentUser = "",
                    DepartmentId = txtDepart.Text,
                    ExpiryDate = DatePickerExpiry.Value,
                    Image = ImgPicture.ResourceID,
                    //                assetsInputDto.LocationId = LocationId;
                    LocationId = LocationId,
                    Manager =ManagerId,
                    ModifyUser = UserId,
                    Name = txtName.Text,
                    Note = txtNote.Text,
                    Place = txtPlace.Text,
                    Price = decimal.Parse(txtPrice.Text),
                    Specification = txtSpe.Text,
                    //                assetsInputDto.TypeId = TypeId;
                    TypeId = TypeId,
                    Unit = txtUnit.Text,
                    Vendor = txtVendor.Text,
                    SN = txtSN.Text
                };
                ReturnInfo returnInfo = _autofacConfig.SettingService.AddAssets(assetsInputDto);
                if (returnInfo.IsSuccess)
                {
                    ShowResult = ShowResult.Yes;
                    Close();
//                    FrmAssetsDetail assetsDetail=new FrmAssetsDetail(){AssId = returnInfo.ErrorInfo};
//                    Show(assetsDetail);
//                    Close();
                    Toast("添加成功.资产编号为"+returnInfo.ErrorInfo);
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

        private void btnType_Press(object sender, EventArgs e)
        {
            try
            {
                PopType.Groups.Clear();
                PopListGroup typeGroup = new PopListGroup();
                typeGroup.Title = "资产类型";
                var typelist = _autofacConfig.assTypeService.GetAll();
                foreach (var type in typelist)
                {
                    PopListItem item = new PopListItem
                    {
                        Value = type.TYPEID,
                        Text = type.NAME
                    };
                    typeGroup.Items.Add(item);
                }
                PopType.Groups.Add(typeGroup);
                if (!string.IsNullOrEmpty(btnType.Text))
                {
                    foreach (PopListItem row in PopType.Groups[0].Items)
                    {
                        if (row.Text == btnType.Text)
                        {
                            PopType.SetSelections(row);
                        }
                    }
                }
                PopType.ShowDialog();
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
            
        }

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



        private void PanelImg_Press(object sender, EventArgs e)
        {
            CamPicture.GetPhoto();
        }


        private void PopLocation_Selected(object sender, EventArgs e)
        {
            try
            {
                if (PopLocation.Selection == null) return;
                btnLocation.Text = PopLocation.Selection.Text;
                LocationId = PopLocation.Selection.Value;
                AssLocation location = _autofacConfig.assLocationService.GetByID(LocationId);
                coreUser manager = _autofacConfig.coreUserService.GetUserByID(location.MANAGER);
                ManagerId = location.MANAGER;
                txtManager.Text = manager.USER_NAME;
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        private void PopType_Selected(object sender, EventArgs e)
        {
            try
            {
                if (PopType.Selection == null) return;
                btnType.Text = PopType.Selection.Text;
                TypeId = PopType.Selection.Value;                
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        private void CamPicture_ImageCaptured(object sender, BinaryResultArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(e.error))
                {
                    e.SaveFile(UserId + DateTime.Now.ToString("yyyyMMddHHmm") + ".png");
                    ImgPicture.ResourceID = UserId + DateTime.Now.ToString("yyyyMMddHHmm");
                    ImgPicture.Refresh();
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        private void frmAssetsCreate_KeyDown(object sender, KeyDownEventArgs e)
        {
            if (e.KeyCode == KeyCode.Back)
                Close();
        }

        private void frmAssetsCreate_Load(object sender, EventArgs e)
        {
            try
            {
                DatePickerExpiry.Value = DateTime.Now.AddYears(1);
                UserId = Session["UserID"].ToString();
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

//        private void btnManager_Press(object sender, EventArgs e)
//        {
//            try
//            {
//                PopManager.Groups.Clear();
//                PopListGroup manGroup = new PopListGroup();
//                PopManager.Title = "管理人选择";
//                List<coreUser> users = _autofacConfig.coreUserService.GetDealInAdmin();
//                foreach (coreUser Row in users)
//                {
//                    manGroup.AddListItem(Row.USER_NAME, Row.USER_ID);
//                }
//                PopManager.Groups.Add(manGroup);
//                if (btnManager.Tag != null)   //如果已有选中项，则显示选中效果
//                {
//                    foreach (PopListItem Item in manGroup.Items)
//                    {
//                        if (Item.Value == btnManager.Tag.ToString())
//                            PopManager.SetSelections(Item);
//                    }
//                }
//                PopManager.ShowDialog();
//
//            }
//            catch (Exception ex)
//            {
//                Toast(ex.Message);
//            }
//        }

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

        private void barcodeScanner1_BarcodeScanned(object sender, BarcodeResultArgs e)
        {
            try
            {
                string barCode = e.Value;
                txtSN.Text = barCode;

            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        private void PopManager_Selected(object sender, EventArgs e)
        {
//            try
//            {
//                if (PopManager.Selection != null)
//                {
//                    btnManager.Text = PopManager.Selection.Text;
//                    ManagerId = PopManager.Selection.Value;
//                }
//            }
//            catch (Exception ex)
//            {
//                Toast(ex.Message);
//            }
        }

        private void r2000Scanner1_BarcodeDataCaptured(object sender, Smobiler.Device.R2000BarcodeScanEventArgs e)
        {
            try
            {
                string barCode = e.Data;
                txtSN.Text = barCode;
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
                txtSN.Text = RFID;
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }
    }
}