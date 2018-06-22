using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMOSEC.UI.AssetsManager;
using Smobiler.Core;
using Smobiler.Core.Controls;

namespace SMOSEC.UI.Layout
{
    ////ToolboxItem用于控制是否添加自定义控件到工具箱，true添加，false不添加
    //[System.ComponentModel.ToolboxItem(true)]
    partial class BorrowOrderLayout : Smobiler.Core.Controls.MobileUserControl
    {
        /// <summary>
        /// 点击，查看借用单详情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Panel1_Press(object sender, EventArgs e)
        {
            try
            {
                frmBoDetail boDetail = new frmBoDetail {BoId = LblID.BindDataValue.ToString()};
                Form.Show(boDetail);
            }
            catch (Exception ex)
            {
                Parent.Form.Toast(ex.Message);
            }
        }
    }
}