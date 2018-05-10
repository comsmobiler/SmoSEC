using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using SMOSEC.CommLib;
using SMOSEC.Domain.Entity;
using SMOSEC.DTOs.OutputDTO;
using Smobiler.Core;
using Smobiler.Core.Controls;

namespace SMOSEC.UI.MasterData
{
    partial class frmAssetsDetail : Smobiler.Core.Controls.MobileForm
    {
        public string AssId;
        private string LocationId;
        private string TypeId;
        private string ManagerId;
        private AutofacConfig _autofacConfig = new AutofacConfig();//调用配置类
        private string LastUser;

        private void btnPrint_Press(object sender, EventArgs e)
        {
            try
            {
                Toast("抱歉，打印功能暂时无法使用");
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        private void btnLog_Press(object sender, EventArgs e)
        {
            try
            {
                frmPrShow prShow = new frmPrShow {AssId = AssId};
                Show(prShow);
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        private void btnEdit_Press(object sender, EventArgs e)
        {
            try
            {
                frmAssetsDetailEdit assetsDetailEdit = new frmAssetsDetailEdit {AssId = AssId};
                Show(assetsDetailEdit, (MobileForm sender1, object args) =>
                {
                    if (assetsDetailEdit.ShowResult == ShowResult.Yes)
                    {
                        ShowResult = ShowResult.Yes;
                        Bind();
                    }
                });
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
//                txtNote.Text = outputDto.Note;
                txtEDate.Text = outputDto.ExpiryDate.ToString("yyyy-MM-dd");
//                txtName.Text = outputDto.Name;
//                txtPrice.Text = outputDto.Price.ToString();
//                txtSpe.Text = outputDto.Specification;
                txtAssId1.Text = outputDto.AssId;
//                ImgPicture.ResourceID = outputDto.Image;

                txtBuyDate.Text= outputDto.BuyDate.ToString("yyyy-MM-dd");
                txtDep.Text = outputDto.DepartmentId;
                txtLocation1.Text = outputDto.LocationName;
                txtManager.Text = outputDto.ManagerName;
                txtName1.Text = outputDto.Name;
                txtPlace1.Text = outputDto.Place;
                txtPrice1.Text = outputDto.Price.ToString();
                txtSN1.Text = outputDto.SN;
                txtSPE1.Text = outputDto.Specification;
                txtType.Text = outputDto.TypeName;
                txtUnit1.Text = outputDto.Unit;
                txtVendor1.Text = outputDto.Vendor;
                image2.ResourceID = outputDto.Image;
                txtNote1.Text = outputDto.Note;
                LocationId = outputDto.LocationId;
                TypeId = outputDto.TypeId;
                if (string.IsNullOrEmpty(outputDto.CurrentUser))
                {
                    btnChange.Visible = false;
                    btnChange.Enabled = false;
                    btnLog.Location= new System.Drawing.Point(47, 2);
                    btnEdit.Location= new System.Drawing.Point(174, 2);
                }

            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        private void frmAssetsDetail_KeyDown(object sender, KeyDownEventArgs e)
        {
            if (e.KeyCode == KeyCode.Back)
            {
                ShowResult = ShowResult.Yes;
                Close();

            }
                
        }

        private void frmAssetsDetail_Load(object sender, EventArgs e)
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

        private void btnCopy_Press(object sender, EventArgs e)
        {
            try
            {
                frmAssetsCreate assetsCreate = new frmAssetsCreate
                {
                    DatePickerBuy = {Value = DatePickerBuy.Value},
                    txtDepart = {Text = txtDep.Text},
                    DatePickerExpiry = {Value = DatePickerExpiry.Value},
                    ImgPicture = {ResourceID = ImgPicture.ResourceID},
                    LocationId = LocationId,
                    btnLocation = {Text = txtLocation1.Text},
                    ManagerId = ManagerId,
                    txtManager = {Text = txtManager.Text},
                    txtName = {Text = txtName.Text},
                    txtNote = {Text = txtNote.Text},
                    txtPlace = {Text = txtPlace.Text},
                    txtPrice = {Text = txtPrice.Text},
                    txtSpe = {Text = txtSpe.Text},
                    TypeId = TypeId,
                    btnType = {Text = txtType.Text},
                    txtUnit = {Text = txtUnit.Text},
                    txtVendor = {Text = txtVendor.Text}
//                    txtSN = {Text = txtVendor.Text}
                };
                //                CreateUser = UserId,
//                CurrentUser = "",
                //                assetsInputDto.LocationId = LocationId;
                //                ModifyUser = UserId,


                //                assetsInputDto.TypeId = TypeId;


                Show(assetsCreate);
                Close();
//                Show(assetsCreate, (MobileForm sender1, object args) =>
//                {
//                    if (assetsCreate.ShowResult == ShowResult.Yes)
//                    {
//                        ShowResult = ShowResult.Yes;
//                        Bind();
//                    }
//                });
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }

        }

        private void btnChange_Press(object sender, EventArgs e)
        {
            try
            {
                popCurrentUser.Groups.Clear();
                PopListGroup poli = new PopListGroup();
                popCurrentUser.Groups.Add(poli);
                poli.Title = "使用者变更";
                List<coreUser> users = _autofacConfig.coreUserService.GetAll();
                foreach (coreUser Row in users)
                {
                    poli.AddListItem(Row.USER_NAME, Row.USER_ID);
                }
                Assets assets = _autofacConfig.orderCommonService.GetAssetsByID(txtAssId1.Text);
                foreach (PopListItem Item in poli.Items)
                {
                    if (Item.Value == assets.CURRENTUSER)
                    {
                       popCurrentUser.SetSelections(Item);
                       LastUser = assets.CURRENTUSER;
//                       ASSID = lblID.BindDataValue.ToString();
                    }
                }
                popCurrentUser.ShowDialog();

            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
            
        }

        private void popCurrentUser_Selected(object sender, EventArgs e)
        {
            try
            {
                if (popCurrentUser.Selection.Value != LastUser)     //如果更换了使用者
                {
                    ReturnInfo RInfo = _autofacConfig.AssetsService.ChangeUser(AssId, popCurrentUser.Selection.Value, Client.Session["UserID"].ToString());
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
    }
}