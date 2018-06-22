using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smobiler.Core;
using Smobiler.Core.Controls;
using SMOSEC.Domain.Entity;
using SMOSEC.DTOs.InputDTO;
using SMOSEC.CommLib;

namespace SMOSEC.UI.ConsumablesManager
{
    partial class frmConInventoryEdit : Smobiler.Core.Controls.MobileForm
    {
        #region  定义变量
        private AutofacConfig _autofacConfig = new AutofacConfig();//调用配置类

        public string IID;
        #endregion
        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmConInventoryEdit_Load(object sender, EventArgs e)
        {
            try
            {
                String UserId = Client.Session["UserID"].ToString();
                var assInventory = _autofacConfig.ConInventoryService.GetConInventoryById(IID);
                txtName.Text = assInventory.NAME;
                btnManager.Text = assInventory.HANDLEMANNAME + "   > ";
                btnManager.Tag = assInventory.HANDLEMAN;
                btnLocation.Text = assInventory.LOCATIONNAME + "   > ";
                btnLocation.Tag = assInventory.LOCATIONID;
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }
        /// <summary>
        /// 区域选择
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
                List<AssLocation> users = _autofacConfig.assLocationService.GetAll();
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
        /// 盘点人选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnManager_Press(object sender, EventArgs e)
        {
            try
            {
                popMan.Groups.Clear();
                PopListGroup manGroup = new PopListGroup { Title = "盘点人选择" };
                List<coreUser> users = _autofacConfig.coreUserService.GetAll();
                foreach (coreUser Row in users)
                {
                    manGroup.AddListItem(Row.USER_NAME, Row.USER_ID);
                }
                popMan.Groups.Add(manGroup);
                if (btnManager.Tag != null)   //如果已有选中项，则显示选中效果
                {
                    foreach (PopListItem Item in manGroup.Items)
                    {
                        if (Item.Value == btnManager.Tag.ToString())
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
        /// 选择盘点人
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void popMan_Selected(object sender, EventArgs e)
        {
            if (popMan.Selection != null)
            {
                btnManager.Text = popMan.Selection.Text + "   > ";
                btnManager.Tag = popMan.Selection.Value;
            }
        }
        /// <summary>
        /// 选择区域
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void popLocation_Selected(object sender, EventArgs e)
        {
            try
            {
                if (popLocation.Selection != null)
                {
                    if(popLocation.Selection.Value != btnLocation.Tag.ToString())
                    {
                        AssLocation loc = _autofacConfig.assLocationService.GetByID(popLocation.Selection.Value);
                        var assInventory = _autofacConfig.ConInventoryService.GetConInventoryById(IID);
                        if(loc.LOCATIONID != assInventory.LOCATIONID)
                        {
                            if (loc.ISLOCKED == 1) throw new Exception("该区域已锁定, 请重新选择!");
                        }                   
                        if (loc.ISENABLE == 0) throw new Exception("该区域已禁用, 请重新选择!");
                        btnLocation.Text = popLocation.Selection.Text + "   > ";
                        btnLocation.Tag = popLocation.Selection.Value;
                    }                   
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }
        /// <summary>
        /// 保存盘点修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Press(object sender, EventArgs e)
        {
            try
            {
                AddCIResultInputDto conInventoryInput = new AddCIResultInputDto()
                {
                    IID = IID,
                    HANDLEMAN = btnManager.Tag.ToString(),
                    LocationId = btnLocation.Tag.ToString(),
                    UserId = Client.Session["UserID"].ToString(),
                    Name = txtName.Text
                };
                ReturnInfo returnInfo = _autofacConfig.ConInventoryService.UpdateInventoryOnly(conInventoryInput);
                if (returnInfo.IsSuccess)
                {
                    ShowResult = ShowResult.Yes;
                    Toast("修改成功");
                    Close();
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
    }
}