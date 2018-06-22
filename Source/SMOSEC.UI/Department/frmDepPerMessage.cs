using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smobiler.Core;
using Smobiler.Core.Controls;
using SMOSEC.Domain.Entity;

namespace SMOSEC.UI.Department
{
    partial class frmDepPerMessage : Smobiler.Core.Controls.MobileForm
    {
        #region "definition"
        AutofacConfig autofacConfig = new AutofacConfig();     //调用配置类
        public String UserID;        //用户名
        #endregion
        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmDepPerMessage_Load(object sender, EventArgs e)
        {
            try
            {
                coreUser UserData = autofacConfig.coreUserService.GetUserByID(UserID);
                if (UserData.USER_SEX != null)
                {
                    if (Convert.ToInt32(UserData.USER_SEX) == 0)
                        lblSex.Text = "男";
                    else
                        lblSex.Text = "女";
                }
                if (UserData.USER_IMAGEID == null)
                {
                    if (Convert.ToInt32(UserData.USER_SEX) == 0)
                        imgUser.ResourceID = "male";
                    else
                        imgUser.ResourceID = "female";
                }
                else
                {
                    imgUser.ResourceID = UserData.USER_IMAGEID;
                }
                AssLocation assLocation = autofacConfig.assLocationService.GetByID(UserData.USER_LOCATIONID);
                lblLocation.Text = assLocation.NAME;
                if (UserData.USER_ADDRESS != null) lblAddress.Text = UserData.USER_ADDRESS;
                if (UserData.USER_EMAIL != null) lblEmail.Text = UserData.USER_EMAIL;
                lblID.Text = UserID;
                if (UserData.USER_NAME != null)
                {
                    lblName.Text = UserData.USER_NAME;
                }
                else
                {
                    lblName.Text = UserID;
                }
                if (UserData.USER_PHONE != null) lblPhone.Text = UserData.USER_PHONE;
                if (UserData.USER_EMAIL != null) lblEmail.Text = UserData.USER_EMAIL;
                if (UserData.USER_BIRTHDAY != null) dpkBirthday.Value = (DateTime)UserData.USER_BIRTHDAY;
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }
    }
}