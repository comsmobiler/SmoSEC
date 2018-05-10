using SMOSEC.UI.ConsumablesManager;
using System;

namespace SMOSEC.UI.Layout
{
    ////ToolboxItem用于控制是否添加自定义控件到工具箱，true添加，false不添加
    //[System.ComponentModel.ToolboxItem(true)]
    partial class frmWRLayout : Smobiler.Core.Controls.MobileUserControl
    {
        private void Panel1_Press(object sender, EventArgs e)
        {
            try
            {
                frmWRDetail boDetail = new frmWRDetail() { WRID = LblID.BindDataValue.ToString() };
                Form.Show(boDetail);
            }
            catch (Exception ex)
            {
                Parent.Form.Toast(ex.Message);
            }
        }
    }
}