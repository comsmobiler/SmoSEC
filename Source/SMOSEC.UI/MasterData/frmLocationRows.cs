using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smobiler.Core;
using Smobiler.Core.Controls;
using SMOSEC.UI.Layout;
using System.Data;
using SMOSEC.Domain.Entity;

namespace SMOSEC.UI.MasterData
{
    partial class frmLocationRows : Smobiler.Core.Controls.MobileForm
    {
        #region "definition"
        AutofacConfig autofacConfig = new AutofacConfig();//调用配置类
        #endregion
        /// <summary>
        /// 创建区域弹出框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Press(object sender, EventArgs e)
        {
            frmLocationCreateLayout frm = new frmLocationCreateLayout();
            frm.isCreate = true;
            this.ShowDialog(frm);
        }
        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmLocationRows_Load(object sender, EventArgs e)
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
                DataTable table = new DataTable();
                List<AssLocation> locs = autofacConfig.assLocationService.GetAll();
                table.Columns.Add("LOCATIONID");
                table.Columns.Add("NAME");
                table.Columns.Add("IMGENABLE");
                table.Columns.Add("TEXTENABLE");
                foreach(AssLocation Row in locs)
                { 
                    if (Row.ISENABLE == 1)      //启用
                    {
                        table.Rows.Add(Row.LOCATIONID,Row.NAME,"off","禁用");
                    }
                    else
                    {
                        table.Rows.Add(Row.LOCATIONID, Row.NAME, "on", "启用");
                    }
                }
                if (table.Rows.Count > 0)
                {
                    listLocation.DataSource = table;
                    listLocation.DataBind();
                }
                foreach (ListViewRow Row in listLocation.Rows)   //根据启用或者禁用，设置对应颜色
                {
                    frmLcoationRowsLayout frm=Row.Control as frmLcoationRowsLayout;
                    frm.setColor();         
                }
            }
            catch(Exception ex)
            {
                Toast(ex.Message);
            }
        }
        /// <summary>
        /// 手机自带返回键操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmLocationRows_KeyDown(object sender, KeyDownEventArgs e)
        {
            if(e.KeyCode == KeyCode.Back)
                Client.Exit();
        }
    }
}