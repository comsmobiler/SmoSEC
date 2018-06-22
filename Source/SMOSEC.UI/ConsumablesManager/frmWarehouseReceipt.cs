using System;
using System.Data;
using Smobiler.Core.Controls;

namespace SMOSEC.UI.ConsumablesManager
{
    partial class frmWarehouseReceipt : Smobiler.Core.Controls.MobileForm
    {
        #region 变量
        private AutofacConfig _autofacConfig = new AutofacConfig();//调用配置类
        #endregion

        /// <summary>
        /// 添加入库单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Press(object sender, EventArgs e)
        {
            frmWRCreate wrCreate = new frmWRCreate();
            Show(wrCreate, (MobileForm sender1, object args) =>
            {
                if (wrCreate.ShowResult == ShowResult.Yes)
                {
                    Bind();
                }
            });
        }

        /// <summary>
        /// 按回退键时，关闭当前窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmWarehouseReceipt_KeyDown(object sender, KeyDownEventArgs e)
        {
            if (e.KeyCode == KeyCode.Back)
                Client.Exit();
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void Bind()
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
                if (Client.Session["Role"].ToString() == "SMOSECUser")
                {
                    panel1.Visible = false;
                }

                DataTable wrList = _autofacConfig.ConsumablesService.GetWRListByUserId(Client.Session["Role"].ToString() == "SMOSECUser" ? Client.Session["UserID"].ToString() : "",LocationId);
                if (wrList != null && wrList.Rows.Count > 0)
                {
                    gridAssRows.DataSource = wrList;
                    gridAssRows.DataBind();
                }
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
        private void frmWarehouseReceipt_Load(object sender, EventArgs e)
        {
            Bind();
        }
    }
}