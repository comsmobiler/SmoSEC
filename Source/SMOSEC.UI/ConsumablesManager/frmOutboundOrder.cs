using System;
using System.Data;
using Smobiler.Core.Controls;

namespace SMOSEC.UI.ConsumablesManager
{
    partial class frmOutboundOrder : Smobiler.Core.Controls.MobileForm
    {
        #region 变量
        private AutofacConfig _autofacConfig = new AutofacConfig();//调用配置类
        

        #endregion 

        /// <summary>
        /// 添加出库单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Press(object sender, EventArgs e)
        {
            frmOutOrderCreate outOrderCreate = new frmOutOrderCreate();
            Show(outOrderCreate, (MobileForm sender1, object args) =>
            {
                if (outOrderCreate.ShowResult == ShowResult.Yes)
                {
                    Bind();
                }
            });
        }

        /// <summary>
        /// 按回退，则关闭当前窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmOutboundOrder_KeyDown(object sender, KeyDownEventArgs e)
        {
            if (e.KeyCode == KeyCode.Back)
                Client.Exit();
        }

        /// <summary>
        /// 初始化界面时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmOutboundOrder_Load(object sender, EventArgs e)
        {
            Bind();
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
                DataTable ooList = _autofacConfig.ConsumablesService.GetOOListByUserId(Client.Session["Role"].ToString() == "SMOSECUser" ? Client.Session["UserID"].ToString() : "",LocationId);
                if (ooList != null && ooList.Rows.Count > 0)
                {
                    gridAssRows.DataSource = ooList;
                    gridAssRows.DataBind();
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }

        }


    }
}