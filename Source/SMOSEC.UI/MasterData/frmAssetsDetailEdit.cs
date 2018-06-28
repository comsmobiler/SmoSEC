using System;
using Smobiler.Core.Controls;
using SMOSEC.CommLib;
using SMOSEC.DTOs.InputDTO;
using SMOSEC.DTOs.OutputDTO;

namespace SMOSEC.UI.MasterData
{
    /// <summary>
    /// 资产修改
    /// </summary>
    partial class frmAssetsDetailEdit : Smobiler.Core.Controls.MobileForm
    {
        #region 变量
        public string UserId;  //用户编号
        public string TypeId; //类型编号
        public string LocationId;  //区域编号
        public string ManagerId;  //管理员编号
        public string CurrentUserId;  //当前用户编号

        AutofacConfig _autofacConfig = new AutofacConfig();//调用配置类

        public string DepId; //部门编号
        public string AssId;  //资产编号
        

        #endregion

        /// <summary>
        /// 修改资产
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    DepartmentId = DepId,
                    Image = ImgPicture.ResourceID,
                    LocationId = LocationId,
                    Manager = ManagerId,
                    ModifyUser = UserId,
                    Name = txtName.Text,
                    Note = txtNote.Text,
                    Place = txtPlace.Text,
                    Specification = txtSpe.Text,
                    TypeId = TypeId,
                    Unit = txtUnit.Text,
                    Vendor = txtVendor.Text,
                    ExpiryDate = DatePickerExpiry.Value,
                    SN = txtSN.Text
                };
                if (String.IsNullOrEmpty(txtPrice.Text) == false)
                    assetsInputDto.Price = decimal.Parse(txtPrice.Text);
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

        /// <summary>
        /// 价格改变时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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


        /// <summary>
        /// 资产类型选择时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 点击上传图片时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PanelImg_Press(object sender, EventArgs e)
        {
            CamPicture.GetPhoto();
        }

        
        /// <summary>
        /// 资产类型选中后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 获取到图片数据后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void Bind()
        {

            try
            {
                AssetsOutputDto outputDto = _autofacConfig.SettingService.GetAssetsByID(AssId);
                if (outputDto != null)
                {
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
                    txtDepart.Text = outputDto.DepartmentName;

                    btnType.Text = outputDto.TypeName;
                    TypeId = outputDto.TypeId;
                    txtLocation.Text = outputDto.LocationName;
                    LocationId = outputDto.LocationId;
                    txtManager.Text = outputDto.ManagerName;
                    ManagerId = outputDto.Manager;
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        /// <summary>
        /// 按回退键时，关闭当前窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAssetsDetailEdit_KeyDown(object sender, KeyDownEventArgs e)
        {
            if (e.KeyCode == KeyCode.Back)
            {
                Close();

            }
            
        }

        /// <summary>
        /// 界面初始化时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 手机扫二维码添加SN
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

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

        /// <summary>
        /// 手持物理按键扫描二维码，扫描到二维码数据时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 手持物理按键扫描RFID，扫描到RFID时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 手机扫描到二维码时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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