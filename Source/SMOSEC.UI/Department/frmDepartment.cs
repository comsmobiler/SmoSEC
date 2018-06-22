using System;
using System.Collections.Generic;
using Smobiler.Core.Controls;
using SMOSEC.UI;
using SMOSEC.DTOs.OutputDTO;
using SMOSEC.Domain.Entity;
using SMOSEC.DTOs.Enum;
using SMOSEC.UI.UserInfo;

namespace SMOSEC.UI.Department
{
    // ******************************************************************
    // 文件版本： SmoONE 1.0
    // Copyright  (c)  2016-2017 Smobiler 
    // 创建时间： 2016/11
    // 主要内容：  部门列表界面
    // ******************************************************************
    partial class frmDepartment : Smobiler.Core.Controls.MobileForm
    {
        #region "definition"
        public DepartmentMode Mode; //客户展示模式
        AutofacConfig AutofacConfig = new AutofacConfig();//调用配置类
        #endregion

        /// <summary>
        /// 初始化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmDepartment_Load(object sender, EventArgs e)
        {
            Mode = DepartmentMode.列表;
            Bind();
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void Bind()
        {
            try
            {
                //获取所有部门数据
                List<DepartmentDto> listDep = AutofacConfig.DepartmentService.GetAllDepartment();
                switch (Mode)
                {
                    case DepartmentMode.列表:
                        gridDepData.Rows.Clear();//清空部门列表数据
                        btnDMode.Text = DepartmentMode.层级 + "展示";
                        break;
                    case DepartmentMode.层级:
                        treeDepData.Nodes.Clear();//清空部门层级数据
                        btnDMode.Text = DepartmentMode.列表 + "展示";
                        break;
                }

                if (listDep.Count > 0)
                {
                    btnDMode.Visible = true;

                    lblInfor.Visible = false;
                    foreach (DepartmentDto dep in listDep)
                    {
                        if (string.IsNullOrEmpty(dep.IMAGEID) == true)
                        {
                            dep.IMAGEID = "bumenicon";
                        }

                    }
                    switch (Mode)
                    {
                        case DepartmentMode.列表:
                            gridDepData.Visible = true;
                            treeDepData.Visible = false;
                            gridDepData.DataSource = listDep;
                            gridDepData.DataBind();
                            break;
                        case DepartmentMode.层级:
                            gridDepData.Visible = false;
                            treeDepData.Visible = true;
                            foreach (DepartmentDto dep in listDep)
                            {
                                TreeViewNode node = new TreeViewNode(dep.NAME, null, dep.IMAGEID, (int)TreeMode.dep + "," + dep.DEPARTMENTID);
                                node.TextColor = System.Drawing.Color.FromArgb(45, 45, 45);
                                List<coreUser> listDepUser = AutofacConfig.coreUserService.GetUserByDepID(dep.DEPARTMENTID);
                                if (listDepUser.Count > 0)
                                {
                                    foreach (coreUser user in listDepUser)
                                    {
                                        string Name = "";
                                        if (dep.MANAGER.Equals(user.USER_ID))
                                        {
                                            Name = user.USER_NAME + "  负责人";
                                        }
                                        else
                                        {
                                            Name = user.USER_NAME;
                                        }
                                        string portrait = "";
                                        if (string.IsNullOrEmpty(user.USER_IMAGEID) == true)
                                        {
                                            switch (user.USER_SEX)
                                            {
                                                case (int)Sex.男:
                                                    portrait = "male";
                                                    break;
                                                case (int)Sex.女:
                                                    portrait = "female";
                                                    break;
                                            }
                                        }
                                        else
                                        {
                                            portrait = user.USER_IMAGEID;
                                        }
                                        TreeViewNode node1 = new TreeViewNode(Name, null, portrait, (int)TreeMode.user + "," + user.USER_ID);
                                        node1.TextColor = System.Drawing.Color.FromArgb(145, 145, 145);
                                        node.Nodes.Add(node1);
                                    }

                                }
                                treeDepData.Nodes.Add(node);
                            }
                            break;
                    }

                }
                else
                {
                    // btnDMode.Visible = false;
                    lblInfor.Visible = true;

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
        private void frmDepartment_KeyDown(object sender, KeyDownEventArgs e)
        {
            if (e.KeyCode == KeyCode.Back)
                Client.Exit();
        }
        /// <summary>
        /// 标题栏图片按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmDepartment_TitleImageClick(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// 跳转到创建部门界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, EventArgs e)
        {
            frmDepartmentCreate frm = new frmDepartmentCreate();
            Show(frm, (MobileForm form, object args) =>
                {
                    if (frm.ShowResult == ShowResult.Yes)
                    {
                        Bind();
                    }
                });

        }

        /// <summary>
        /// treeDepData点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeDepData_NodeSelected(object sender, TreeViewClickEventArgs e)
        {

            // string ID = treeDepData.SelectedNode.Value;
            string ID = e.Value;
            switch (Convert.ToInt32(ID.Split(',')[0]))
            {
                case (int)TreeMode.dep:
                    frmDepartmentDetail frm = new frmDepartmentDetail();
                    frm.D_ID = ID.Split(',')[1];
                    Show(frm, (MobileForm form, object args) =>
                    {
                        if (frm.ShowResult == ShowResult.Yes)
                        {
                            Mode = DepartmentMode.层级;
                            Bind();
                        }
                    });
                    break;
                case (int)TreeMode.user:
                    frmDepPerMessage frmMes = new frmDepPerMessage();
                    frmMes.UserID = ID.Split(',')[1];
                    Show(frmMes);
                    break;
            }

        }

        /// <summary>
        /// 部门显示模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDLayout_Click(object sender, EventArgs e)
        {
            switch (Mode)
            {
                case DepartmentMode.列表:
                    Mode = DepartmentMode.层级;
                    break;
                case DepartmentMode.层级:
                    Mode = DepartmentMode.列表;
                    break;
            }
            Bind();
        }
    }
}