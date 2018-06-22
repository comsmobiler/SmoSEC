using System;
using SMOSEC.UI.ConsumablesManager;

namespace SMOSEC.UI.Layout
{
    ////ToolboxItem用于控制是否添加自定义控件到工具箱，true添加，false不添加
    //[System.ComponentModel.ToolboxItem(true)]
    partial class frmOutboundOrderLayout : Smobiler.Core.Controls.MobileUserControl
    {
        /// <summary>
        /// 点击，查看出库单详情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Panel1_Press(object sender, EventArgs e)
        {
            try
            {
                frmOutOrderDetail boDetail = new frmOutOrderDetail {OOId = LblID.BindDataValue.ToString()};
                Form.Show(boDetail);
            }
            catch (Exception ex)
            {
                Parent.Form.Toast(ex.Message);
            }
        }
    }
}