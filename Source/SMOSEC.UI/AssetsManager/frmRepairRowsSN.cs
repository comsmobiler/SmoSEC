using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smobiler.Core;
using Smobiler.Core.Controls;
using SMOSEC.Domain.Entity;
using SMOSEC.DTOs.Enum;

namespace SMOSEC.UI.AssetsManager
{
    partial class frmRepairRowsSN : Smobiler.Core.Controls.MobileForm
    {
        #region "definition"
        AutofacConfig autofacConfig = new AutofacConfig();     //调用配置类
        #endregion
        /// <summary>
        /// 创建维修单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Press(object sender, EventArgs e)
        {
            frmRepairCreateSN frm = new frmRepairCreateSN();
            Show(frm, (MobileForm sender1, object args) => {
                if (frm.ShowResult == ShowResult.Yes)
                {
                    Bind();   //重新加载数据
                }
            });
        }
        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmRepairRowsSN_Load(object sender, EventArgs e)
        {
            Bind();
        }
        /// <summary>
        /// 加载数据
        /// </summary>
        public void Bind()
        {
            try
            {
                List<AssRepairOrder> Data = new List<AssRepairOrder>();
                if (Client.Session["Role"].ToString() == "SMOSECUser")
                {
                    Data = autofacConfig.assRepairOrderService.GetByUser(Client.Session["UserID"].ToString());
                }
                else
                {
                    Data = autofacConfig.assRepairOrderService.GetByUser(null);
                }
                if (Data.Count > 0)
                {
                    listRepairOrder.DataSource = Data;
                    listRepairOrder.DataBind();
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }
        /// <summary>
        /// 手机自带返回键操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmRepairRowsSN_KeyDown(object sender, KeyDownEventArgs e)
        {
            if (e.KeyCode == KeyCode.Back) Client.Exit();
        }
    }
}