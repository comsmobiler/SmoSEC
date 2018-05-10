using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMOSEC.CommLib;
using SMOSEC.Domain.Entity;
using SMOSEC.DTOs.InputDTO;
using SMOSEC.DTOs.OutputDTO;
using Smobiler.Core;
using Smobiler.Core.Controls;

namespace SMOSEC.UI.MasterData
{
    partial class frmAssetsDetailEdit : Smobiler.Core.Controls.MobileForm
    {
        public string UserId;
        public string TypeId;
        public string LocationId;
        public string ManagerId;
        public string CurrentUserId;

        AutofacConfig _autofacConfig = new AutofacConfig();//调用配置类

        public string AssId;

        private void Button1_Press(object sender, EventArgs e)
        {
            try
            {
                AssetsInputDto assetsInputDto = new AssetsInputDto
                {
                    AssId = txtAssID.Text,
                    BuyDate = DatePickerBuy.Value,
                    CreateUser = UserId,
                    CurrentUser = CurrentUserId,
                    DepartmentId = txtDepart.Text,
                    //                assetsInputDto.ExpiryDate = datep.Value;
                    Image = ImgPicture.ResourceID,
                    LocationId = LocationId,
                    Manager = ManagerId,
                    ModifyUser = UserId,
                    Name = txtName.Text,
                    Note = txtNote.Text,
                    Place = txtPlace.Text,
                    Price = decimal.Parse(txtPrice.Text),
                    Specification = txtSpe.Text,
//                    TypeId = TypeId,
                    TypeId = TypeId,
                    Unit = txtUnit.Text,
                    Vendor = txtVendor.Text,
                    ExpiryDate = DatePickerExpiry.Value,
                    SN = txtSN.Text
                };
                ReturnInfo returnInfo = _autofacConfig.SettingService.UpdateAssets(assetsInputDto);
                if (returnInfo.IsSuccess)
                {
                    ShowResult = ShowResult.Yes;
                    Close();
                    Toast("修改成功.");
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

        private void btnSerialShow_Press(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSpe_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUnit_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSPQ_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal price;
                if (decimal.TryParse(txtPrice.Text, out price) == false)
                {
                    throw new Exception("请输入正确的金额。");
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        private void DatePickerBuy_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtEDate_TextChanged(object sender, EventArgs e)
        {

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

        private void PanelImg_Press(object sender, EventArgs e)
        {
            CamPicture.GetPhoto();
        }

        private void txtNote_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEDateUnit_Press(object sender, EventArgs e)
        {

        }

        private void PopEDateUnit_Selected(object sender, EventArgs e)
        {

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

        private void Bind()
        {

            try
            {
                AssetsOutputDto outputDto = _autofacConfig.SettingService.GetAssetsByID(AssId);
                txtAssID.Text = outputDto.AssId;
                ImgPicture.ResourceID = outputDto.Image;
                txtNote.Text = outputDto.Note;
                DatePickerExpiry.Value = outputDto.ExpiryDate;
                txtName.Text = outputDto.Name;
                txtPrice.Text = outputDto.Price.ToString();
                txtSpe.Text = outputDto.Specification;
                txtNote.Text = outputDto.Note;
                txtPlace.Text = outputDto.Place;
                txtSN.Text = outputDto.SN;
                txtUnit.Text = outputDto.Unit;
                txtVendor.Text = outputDto.Vendor;
                txtDepart.Text = outputDto.DepartmentId;

                btnType.Text = outputDto.TypeName;
                TypeId = outputDto.TypeId;
                txtLocation.Text = outputDto.LocationName;
                LocationId = outputDto.LocationId;
                txtManager.Text = outputDto.ManagerName;
                ManagerId = outputDto.Manager;
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        private void frmAssetsDetailEdit_KeyDown(object sender, KeyDownEventArgs e)
        {
            if (e.KeyCode == KeyCode.Back)
            {
//                ShowResult = ShowResult.None;
                Close();

            }
            
        }

        private void frmAssetsDetailEdit_Load(object sender, EventArgs e)
        {
            try
            {
                Bind();
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
    }
}