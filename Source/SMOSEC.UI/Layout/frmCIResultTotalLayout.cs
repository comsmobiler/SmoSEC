using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smobiler.Core;
using Smobiler.Core.Controls;
using SMOSEC.UI.ConsumablesManager;

namespace SMOSEC.UI.Layout
{
    ////ToolboxItem用于控制是否添加自定义控件到工具箱，true添加，false不添加
    //[System.ComponentModel.ToolboxItem(true)]
    partial class frmCIResultTotalLayout : Smobiler.Core.Controls.MobileUserControl
    {
        #region 定义变量
        public String CID;       //耗材编号
        #endregion
        /// <summary>
        /// 取消操作，关闭当前弹出框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Press(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 确定操作，进行数量盘点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Press(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtRealAmount.Text)) throw new Exception("实盘数量不能为空!");
                if (System.Text.RegularExpressions.Regex.IsMatch(txtRealAmount.Text.Trim(), "^\\d+$")==false){
                    throw new Exception("请输入数字!");
                }
                this.Close();          //关闭当前弹出框
                ((frmConInventoryResult)Form).AddConToDictionary(CID, Convert.ToDecimal(txtRealAmount.Text));
            }
            catch(Exception ex)
            {
                Form.Toast(ex.Message);
            }
        }
    }
}