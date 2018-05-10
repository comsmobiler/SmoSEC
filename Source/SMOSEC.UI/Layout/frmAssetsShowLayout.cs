using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smobiler.Core;
using Smobiler.Core.Controls;

namespace SMOSEC.UI.Layout
{
    ////ToolboxItem用于控制是否添加自定义控件到工具箱，true添加，false不添加
    //[System.ComponentModel.ToolboxItem(true)]
    partial class frmAssetsShowLayout : Smobiler.Core.Controls.MobileUserControl
    {
        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAssetsShowLayout_Load(object sender, EventArgs e)
        {
            if (Form.ToString() == "SMOSEC.UI.AssetsManager.frmRepairDetail")
                lblNumber.DisplayFormat = "待维修数量: {0}";
            else if (Form.ToString() == "SMOSEC.UI.AssetsManager.frmScrapDetail")
                lblNumber.DisplayFormat = "报废数量: {0}";
            else if ((Form.ToString() == "SMOSEC.UI.AssetsManager.frmTransferDetail"))
                lblNumber.DisplayFormat = "待确认数量: {0}";
        }
    }
}