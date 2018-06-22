using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smobiler.Core;
using Smobiler.Core.Controls;
using SMOSEC.CommLib;
using SMOSEC.Domain.Entity;
using SMOSEC.DTOs.InputDTO;

namespace SMOSEC.UI.AssetsManager
{
    /// <summary>
    /// 添加盘点单界面
    /// </summary>
    partial class frmAssInventoryCreate : Smobiler.Core.Controls.MobileForm
    {
        #region  定义变量
        private AutofacConfig _autofacConfig = new AutofacConfig();//调用配置类

        public string LocationId;
        public string HManId;
        private string UserId;
        public string typeId;
        public string DepId;
        #endregion

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Press(object sender, EventArgs e)
        {
            try
            {
                AssInventoryInputDto assInventoryInput = new AssInventoryInputDto()
                {
                    HANDLEMAN = HManId,
                    CREATEUSER = UserId,
                    LOCATIONID = LocationId,
                    TYPEID = typeId,
                    DEPARTMENTID = DepId,
                    IsEnd = false,
                    MODIFYUSER = UserId,
                    NAME = txtName.Text
                };
                ReturnInfo returnInfo = _autofacConfig.AssInventoryService.AddAssInventory(assInventoryInput);
                if (returnInfo.IsSuccess)
                {
                    ShowResult = ShowResult.Yes;
                    Toast("添加成功");
                    Close();
                }
                else
                {
                    throw new Exception(returnInfo.ErrorInfo);
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        /// <summary>
        /// 选择盘点区域
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLocation_Press(object sender, EventArgs e)
        {
            try
            {
                popLocation.Groups.Clear();
                PopListGroup locationGroup = new PopListGroup();
                popLocation.Title = "区域选择";
                List<AssLocation> locations = _autofacConfig.assLocationService.GetAll();
                foreach (var location in locations)
                {
                    PopListItem item = new PopListItem
                    {
                        Value = location.LOCATIONID,
                        Text = location.NAME
                    };
                    locationGroup.Items.Add(item);
                }
                popLocation.Groups.Add(locationGroup);

                if (!string.IsNullOrEmpty(LocationId))
                {
                    foreach (PopListItem row in popLocation.Groups[0].Items)
                    {
                        if (row.Value == LocationId)
                        {
                            popLocation.SetSelections(row);
                        }
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
        /// 盘点人选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnManager_Press(object sender, EventArgs e)
        {
            try
            {
                popMan.Groups.Clear();
                PopListGroup manGroup = new PopListGroup {Title = "盘点人选择"};
                List<coreUser> users = _autofacConfig.coreUserService.GetAll();
                foreach (coreUser Row in users)
                {
                    manGroup.AddListItem(Row.USER_NAME, Row.USER_ID);
                }
                popMan.Groups.Add(manGroup);
                if (!string.IsNullOrEmpty(HManId))   //如果已有选中项，则显示选中效果
                {
                    foreach (PopListItem Item in manGroup.Items)
                    {
                        if (Item.Value == HManId)
                            popMan.SetSelections(Item);
                    }
                }
                popMan.ShowDialog();

            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        /// <summary>
        /// 资产类型选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnType_Press(object sender, EventArgs e)
        {
            try
            {
                popType.Groups.Clear();
                PopListGroup typeGroup = new PopListGroup {Title = "资产类型"};
                var typelist = _autofacConfig.assTypeService.GetAll();
                PopListItem first = new PopListItem
                {
                    Text = "全部",
                    Value = ""
                };
                typeGroup.Items.Add(first);
                foreach (var type in typelist)
                {
                    PopListItem item = new PopListItem
                    {
                        Value = type.TYPEID,
                        Text = type.NAME
                    };
                    typeGroup.Items.Add(item);
                }
                popType.Groups.Add(typeGroup);
                if (!string.IsNullOrEmpty(typeId))
                {
                    foreach (PopListItem row in popType.Groups[0].Items)
                    {
                        if (row.Value == typeId)
                        {
                            popType.SetSelections(row);
                        }
                    }
                }
                popType.ShowDialog();
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        /// <summary>
        /// 部门选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDep_Press(object sender, EventArgs e)
        {
            try
            {
                popDep.Groups.Clear();
                PopListGroup depGroup = new PopListGroup {Title = "部门"};
                var deplist = _autofacConfig.DepartmentService.GetAllDepartment();
                PopListItem first = new PopListItem
                {
                    Text = "全部",
                    Value = ""
                };
                depGroup.Items.Add(first);
                foreach (var dep in deplist)
                {
                    PopListItem item = new PopListItem
                    {
                        Value = dep.DEPARTMENTID,
                        Text = dep.NAME
                    };
                    depGroup.Items.Add(item);
                }
                popDep.Groups.Add(depGroup);
                if (!string.IsNullOrEmpty(DepId))
                {
                    foreach (PopListItem row in popDep.Groups[0].Items)
                    {
                        if (row.Value == DepId)
                        {
                            popDep.SetSelections(row);
                        }
                    }
                }
                popDep.ShowDialog();
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        /// <summary>
        /// 界面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAssInventoryCreate_Load(object sender, EventArgs e)
        {
            try
            {
                UserId = Client.Session["UserID"].ToString();
                if (Client.Session["Role"].ToString() == "SMOSECAdmin")
                {
                    var user = _autofacConfig.coreUserService.GetUserByID(UserId);
                    LocationId = user.USER_LOCATIONID;
                    var location = _autofacConfig.assLocationService.GetByID(LocationId);
                    if (location != null) btnLocation.Text = location.NAME;
                    btnLocation.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        /// <summary>
        /// 盘点人选择后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void popMan_Selected(object sender, EventArgs e)
        {
            try
            {
                if (popMan.Selection != null)
                {
                    btnManager.Text = popMan.Selection.Text + "   > ";
                    HManId = popMan.Selection.Value;
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        /// <summary>
        /// 区域选中后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void popLocation_Selected(object sender, EventArgs e)
        {
            try
            {
                if (popLocation.Selection != null)
                {
                    btnLocation.Text = popLocation.Selection.Text + "   > ";
                    LocationId = popLocation.Selection.Value;
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        /// <summary>
        /// 资产类型选中后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void popType_Selected(object sender, EventArgs e)
        {
            try
            {
                if (popType.Selection != null)
                {
                    btnType.Text = popType.Selection.Text + "   > ";
                    typeId = popType.Selection.Value;
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        /// <summary>
        /// 部门选中后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void popDep_Selected(object sender, EventArgs e)
        {
            try
            {
                if (popDep.Selection != null)
                {
                    btnDep.Text = popDep.Selection.Text + "   > ";
                    DepId = popDep.Selection.Value;
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }
    }
}