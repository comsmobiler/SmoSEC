using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smobiler.Core;
using Smobiler.Core.Controls;
using SMOSEC.UI.AssetsManager;
using SMOSEC.Domain.Entity;

namespace SMOSEC.UI.Layout
{
    ////ToolboxItem用于控制是否添加自定义控件到工具箱，true添加，false不添加
    //[System.ComponentModel.ToolboxItem(true)]
    partial class frmAssSNSDLayout : Smobiler.Core.Controls.MobileUserControl
    {
        /// <summary>
        /// 更改选中状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Check_CheckedChanged(object sender, EventArgs e)
        {
            ((frmScrapDealSN)Form).upCheckState();
        }
        /// <summary>
        /// 获取行项数据
        /// </summary>
        /// <returns></returns>
        public AssScrapOrderRow getData()
        {
            if (Check.Checked)
            {
                AssScrapOrderRow Data = new AssScrapOrderRow();
                Data.SOROWID = Check.BindDataValue.ToString();
                Data.IMAGE = imgAss.BindDisplayValue.ToString();
                Data.ASSID = lblName.BindDataValue.ToString();
                Data.SN = lblSN.BindDataValue.ToString();
                Data.RETURNQTY = 1;
                Data.STATUS = 1;
                return Data;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获取当前行是否选中
        /// </summary>
        /// <returns></returns>
        public int checkNum()
        {
            if (Check.Checked)
                return 1;
            else
                return 0;
        }
        /// <summary>
        /// 设置CheckBox状态
        /// </summary>
        /// <param name="state"></param>
        public void setCheck(Boolean state)
        {
            Check.Checked = state;
        }
        /// <summary>
        /// 点击修改选中状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void plRow_Press(object sender, EventArgs e)
        {
            if (Check.Checked)
                Check.Checked = false;
            else
                Check.Checked = true;
            ((frmScrapDealSN)Form).upCheckState();
        }
    }
}