using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smobiler.Core;
using Smobiler.Core.Controls;
using SMOSEC.Domain.Entity;
using SMOSEC.CommLib;
using SMOSEC.UI.MasterData;

namespace SMOSEC.UI.UserInfo
{
    partial class frmRegister : Smobiler.Core.Controls.MobileForm
    {
        #region "definition"
        AutofacConfig autofacConfig = new AutofacConfig();     //调用配置类
        public String Tel;        //电话号码
        public String VCode;      //验证码
        public Boolean isPwd1;       //新密码是否显示密码字符变量
        private Boolean isPwd2;     //确认密码是否显示密码字符变量
        #endregion
        /// <summary>
        /// 新密码是否显示密码字符
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tpPwd1_Press(object sender, EventArgs e)
        {
            if (isPwd1 == false)
            {
                txtPwd1.SecurityMode = true;
                //设置textbox为密码字符
                fontPwd1.ResourceID = "eye-slash";
                isPwd1 = true;
            }
            {
                txtPwd1.SecurityMode = false;
                //textbox密码字符为空时，显示明文
                fontPwd1.ResourceID = "eye";
                isPwd1 = false;
            }
        }
        /// <summary>
        /// 确认密码是否显示密码字符
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tpPwd2_Press(object sender, EventArgs e)
        {
            if (isPwd2 == false)
            {
                txtPwd2.SecurityMode = false;
                //设置textbox为密码字符
                fontPwd2.ResourceID = "eye-slash";
                isPwd2 = true;
            }
            else
            {
                txtPwd2.SecurityMode = false;
                //textbox密码字符为空时，显示明文
                fontPwd2.ResourceID = "eye";
            }
        }
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Press(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text.Trim().Length < 0) throw new Exception("请输入昵称");
                String pwd1 = txtPwd1.Text.Trim();
                String pwd2 = txtPwd2.Text.Trim();
                if (pwd1.Length <= 0) throw new Exception("请输入新密码!");
                if (pwd1.Length < 6 || pwd1.Length > 12) throw new Exception("新密码必须为6-12位!");
                if (pwd2.Length <= 0) throw new Exception("请输入确认密码!");
                if (pwd2.Length < 6 || pwd2.Length > 12) throw new Exception("新密码必须为6-12位!");
                if (pwd1.Equals(pwd2) == false) throw new Exception("两次密码输入不一致，请检查!");
                if(String.IsNullOrEmpty(radioGroup1.CheckedButton.Value)) throw new Exception("请选择角色!");
                if(radioGroup1.CheckedButton.Value != "ADMIN")     //用户必须选择区域，管路员可以不选
                {
                    if (btnLocation.Tag == null) throw new Exception("请选择所属区域");
                }
                

                coreUser UserData = new coreUser();
                UserData.USER_ID = Tel;
                if(btnLocation.Tag !=null)
                    UserData.USER_LOCATIONID = btnLocation.Tag.ToString();
                UserData.USER_NAME = txtName.Text;
                UserData.USER_PASSWORD = pwd1;
                UserData.USER_PHONE = Tel;
                UserData.USER_LANGUAGE = 0;
                UserData.USER_ROLE = radioGroup1.CheckedButton.Value;

                ReturnInfo RInfo = autofacConfig.coreUserService.AddUser(UserData);
                if (RInfo.IsSuccess)
                {
                    Client.Session["UserID"] = Tel;
					Client.Session["Role"] = radioGroup1.CheckedButton.Value;
                    //关闭当前界面
                    this.Close();
                    frmAssets frm = new frmAssets();
                    //跳转到资产主界面
                    Show(frm);
                }
                else
                {
                    throw new Exception(RInfo.ErrorInfo);
                }
            }
            catch(Exception ex)
            {
                Toast(ex.Message);
            }
        }
        /// <summary>
        /// 选择区域
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
        /// 选择所属区域后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void popLocation_Selected(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(popLocation.Selection.Text) == false)
                {
                    btnLocation.Text = popLocation.Selection.Text + "   > ";
                    btnLocation.Tag = popLocation.Selection.Value;         //区域编号
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }
    }
}