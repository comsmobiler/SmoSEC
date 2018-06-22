using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Smobiler.Core;
using Smobiler.Core.Controls;
using SMOSEC.DTOs.Enum;
using SMOSEC.UI.Layout;

namespace SMOSEC.UI.AssetsManager
{
    /// <summary>
    /// 盘点单列表
    /// </summary>
    partial class frmAssInventory : Smobiler.Core.Controls.MobileForm
    {
        #region  定义变量
        private AutofacConfig _autofacConfig = new AutofacConfig();//调用配置类
        #endregion

        /// <summary>
        /// 初始化界面时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAssInventory_Load(object sender, EventArgs e)
        {
            Bind();
        }

        //按ActionButton时触发
        private void frmAssInventory_ActionButtonPress(object sender, ActionButtonPressEventArgs e)
        {
            switch (e.Index)
            {
                case 0:
                    frmAssInventoryCreate assInventoryCreate=new frmAssInventoryCreate();
                    Show(assInventoryCreate, (MobileForm sender1, object args) =>
                    {
                        if (assInventoryCreate.ShowResult == ShowResult.Yes)
                        {
                            Bind();
                        }
                    });

                    break;
                default:
                    break;
            }
        }

        //绑定数据
        public void Bind()
        {
            try
            {

                string LocationId = "";
                string UserId = Session["UserID"].ToString();
                if (Client.Session["Role"].ToString() == "SMOSECAdmin")
                {
                    var user = _autofacConfig.coreUserService.GetUserByID(UserId);
                    LocationId = user.USER_LOCATIONID;
                }

                DataTable assInventoryList = _autofacConfig.AssInventoryService.GetAssInventoryList(Client.Session["Role"].ToString() == "SMOSECUser" ? Client.Session["UserID"].ToString() : "",LocationId);
                listView.Rows.Clear();
                if (assInventoryList.Rows.Count > 0)
                {
                    listView.DataSource = assInventoryList;
                    listView.DataBind();
                }
                foreach (var row in listView.Rows)
                {
                    frmAssInventoryLayout layout = (frmAssInventoryLayout) row.Control;
                    switch (layout.label1.Text)
                    {
                        case "盘点结束":
                            layout.label1.ForeColor= Color.FromArgb(43, 125, 43);
                            break;
                        case "盘点中":
                            layout.label1.ForeColor = Color.FromArgb(43, 140, 255);
                            layout.btnStart.Text = "继续盘点";
                            break;
                        case "盘点未开始":
                            layout.label1.ForeColor = Color.FromArgb(211, 215, 217);
                            break;
                    }
                }

            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        //如果按了回退键，则关闭
        private void frmAssInventory_KeyDown(object sender, KeyDownEventArgs e)
        {
            if (e.KeyCode == KeyCode.Back)
                Client.Exit();
        }

        /// <summary>
        /// 添加盘点单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Press(object sender, EventArgs e)
        {
            try
            {
                frmAssInventoryCreate assInventoryCreate = new frmAssInventoryCreate();
                Show(assInventoryCreate, (MobileForm sender1, object args) =>
                {
                    if (assInventoryCreate.ShowResult == ShowResult.Yes)
                    {
                        Bind();
                    }
                });
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            } 
        }
    }
}