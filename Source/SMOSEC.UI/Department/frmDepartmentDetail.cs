using System;
using System.Collections.Generic;
using System.Linq;
using Smobiler.Core.Controls;
using SMOSEC.DTOs.OutputDTO;
using SMOSEC.Domain.Entity;
using SMOSEC.DTOs.Enum;
using SMOSEC.CommLib;

namespace SMOSEC.UI.Department
{

    // ******************************************************************
    // 文件版本： SmoONE 1.0
    // Copyright  (c)  2016-2017 Smobiler 
    // 创建时间： 2016/11
    // 主要内容：  部门详情界面
    // ******************************************************************
    partial class frmDepartmentDetail : Smobiler.Core.Controls.MobileForm
    {
        #region "definition"
        /// <summary>
        /// 部门编号
        /// </summary>
        public string D_ID;
        AutofacConfig AutofacConfig = new AutofacConfig();//调用配置类
        #endregion

        /// <summary>
        /// 初始化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmDepartmentDetail_Load(object sender, EventArgs e)
        {
            Bind();
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        private void Bind()
        {
            try
            {

                //根据部门编号获取部门数据
                DepartmentDto department = AutofacConfig.DepartmentService.GetDepartmentByDepID(D_ID);
                lblName.Text = department.NAME;
                //获取部门人员数据
                if (string.IsNullOrEmpty(department.MANAGER) == false)
                {
                    coreUser user = AutofacConfig.coreUserService.GetUserByID(department.MANAGER);
                    if (user != null)
                    {
                        lblLeader.Text = user.USER_NAME;
                    }
                }
                if (string.IsNullOrEmpty(department.IMAGEID) == false)
                {
                    imgPortrait.ResourceID = department.IMAGEID;
                    imgPortrait.Refresh();
                }
                else
                {
                    imgPortrait.ResourceID = "bumenicon";
                }
                List<coreUser> listDepUser = AutofacConfig.coreUserService.GetUserByDepID(D_ID);
                if (listDepUser.Count > 0)
                {
                    gridUserData.Rows.Clear();
                    foreach (coreUser userinfo in listDepUser)
                    {
                        if (userinfo.USER_ID.Equals(department.MANAGER))
                        {
                            listDepUser.Remove(userinfo);
                            break;
                        }
                    }
                    gridUserData.Rows.Clear();//清空部门人员列表数据
                    if (listDepUser.Count > 0)
                    {
                        foreach (coreUser userinfo in listDepUser)
                        {
                            if (string.IsNullOrEmpty(userinfo.USER_IMAGEID) == true)
                            {
                                switch (userinfo.USER_SEX)
                                {
                                    case (int)Sex.男:
                                        userinfo.USER_IMAGEID = "male";
                                        break;
                                    case (int)Sex.女:
                                        userinfo.USER_IMAGEID = "female";
                                        break;
                                }
                            }
                            //else
                            //{
                            //    userinfo.U_Portrait = userinfo.U_Portrait;
                            //}
                        }
                    }
                    gridUserData.DataSource = listDepUser;
                    gridUserData.DataBind();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 手机自带回退按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmDepartmentDetail_KeyDown(object sender, KeyDownEventArgs e)
        {
            if (e.KeyCode == KeyCode.Back)
            {
                Close();         //关闭当前页面
            }
        }
        /// <summary>
        /// 标题栏图片按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmDepartmentDetail_TitleImageClick(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// 跳转到编辑界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmDepartmentCreate frm = new frmDepartmentCreate();
            frm.D_ID = D_ID;
            Show(frm, (MobileForm form, object args) =>
            {
                if (frm.ShowResult == ShowResult.Yes)
                {
                    ShowResult = ShowResult.Yes;
                    Bind();
                }
            });

        }
        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {

            //bool isDelDep = false;//是否删除部门
            MessageBox.Show("是否确定删除部门？", "部门", MessageBoxButtons.YesNo, (Object s1, MessageBoxHandlerArgs args1) =>
               {
                   if (args1.Result == Smobiler.Core.Controls.ShowResult.Yes)
                   {
                       //如果部门人员人数大于0，则弹出提示框在删除部门，否则直接删除
                       if (gridUserData.Rows.Count > 0)
                       {
                           MessageBox.Show(lblName.Text + "已分配部门人员是否删除？", "删除部门", MessageBoxButtons.YesNo, (Object s, MessageBoxHandlerArgs args) =>
                           {
                               if (args.Result == Smobiler.Core.Controls.ShowResult.Yes)
                               {

                                   //isDelDep = true;
                                   try
                                   {
                                       ReturnInfo result = AutofacConfig.DepartmentService.DeleteDepartment(D_ID);
                                       if (result.IsSuccess == true)
                                       {
                                           ShowResult = ShowResult.Yes;
                                           Close();
                                           Toast("部门已删除！", ToastLength.SHORT);
                                       }
                                       else
                                       {
                                           throw new Exception(result.ErrorInfo);
                                       }
                                   }
                                   catch (Exception ex)
                                   {
                                       Toast(ex.Message, ToastLength.SHORT);
                                   }
                               }
                           });
                       }
                       else
                       {
                           //isDelDep = true;
                           ReturnInfo result = AutofacConfig.DepartmentService.DeleteDepartment(D_ID);
                           if (result.IsSuccess == true)
                           {
                               ShowResult = ShowResult.Yes;
                               Close();
                               Toast("部门已删除！", ToastLength.SHORT);
                           }
                           else
                           {
                               Toast(result.ErrorInfo, ToastLength.SHORT);
                           }
                       }
                       //if (isDelDep == true)
                       //{
                       //    ReturnInfo result = AutofacConfig.departmentService.DeleteDepartment(D_ID);
                       //    if (result.IsSuccess == true)
                       //    {
                       //        ShowResult = ShowResult.Yes;
                       //        Close();
                       //        Toast("部门已删除！", ToastLength.SHORT);
                       //    }
                       //    else
                       //    {
                       //        throw new Exception(result.ErrorInfo);
                       //    }
                       //}
                   }
               });
        }
    }
}