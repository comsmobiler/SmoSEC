using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smobiler.Core;
using Smobiler.Core.Controls;
using SMOSEC.UI.AssetsManager;
using SMOSEC.Domain.Entity;
using SMOSEC.DTOs.Enum;

namespace SMOSEC.UI.Layout
{
    ////ToolboxItem用于控制是否添加自定义控件到工具箱，true添加，false不添加
    //[System.ComponentModel.ToolboxItem(true)]
    partial class frmAssSNRDLayout : Smobiler.Core.Controls.MobileUserControl
    {
        /// <summary>
        /// 更改选中状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Check_CheckedChanged(object sender, EventArgs e)
        {
            ((frmRepairDealSN)Form).upCheckState();
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
        /// 获取行项数据
        /// </summary>
        /// <returns></returns>
        public AssRepairOrderRow getData()
        {
            if (Check.Checked)
            {
                AssRepairOrderRow Data = new AssRepairOrderRow();
                Data.ROROWID = Check.BindDataValue.ToString();
                Data.IMAGE = imgAss.BindDisplayValue.ToString();
                Data.ASSID = lblName.BindDataValue.ToString();
                Data.SN = lblSN.BindDataValue.ToString();
                Data.REPAIREDQTY = 1;
                Data.STATUS = 1;
                return Data;
            }
            else
            {
                return null;
            }
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
            ((frmRepairDealSN)Form).upCheckState();
        }
    }
}