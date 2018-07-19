using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smobiler.Core;
using Smobiler.Core.Controls;
using SMOSEC.CommLib;
using SMOSEC.DTOs.Enum;
using SMOSEC.UI.MasterData;

namespace SMOSEC.UI.Layout
{
    ////ToolboxItem用于控制是否添加自定义控件到工具箱，true添加，false不添加
    //[System.ComponentModel.ToolboxItem(true)]
    partial class frmLcoationRowsLayout : Smobiler.Core.Controls.MobileUserControl
    {
        #region "definition"
        AutofacConfig autofacConfig = new AutofacConfig();//调用配置类
        #endregion
        /// <summary>
        /// 对当前行项区域进行编辑或删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void plEdit_Press(object sender, EventArgs e)
        {
            frmLocationRowsButtonLayout frm = new frmLocationRowsButtonLayout();
            frm.ID = lblName.BindDataValue.ToString();     //区域编号
            frm.LocName = lblName.BindDisplayValue.ToString();      //区域名称
            DialogOptions dialog = new DialogOptions();
            dialog.JustifyAlign = LayoutJustifyAlign.FlexEnd;
            dialog.Padding = new Padding(0);
            this.Form.ShowDialog(frm,dialog);
        }
        public void setColor()
        {
            if (lblEnable.Text == "启用")
            {
                lblEnable.ForeColor = System.Drawing.Color.DodgerBlue;
            }
            else
            {
                lblEnable.ForeColor = System.Drawing.Color.Red;
            }
        }
        /// <summary>
        /// 启用或者禁用区域
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void plEnable_Press(object sender, EventArgs e)
        {
            if (lblEnable.Text == "启用")
            {
                MessageBox.Show("你确定要启用该区域吗?", "系统提醒", MessageBoxButtons.OKCancel, (object sender1, MessageBoxHandlerArgs args) =>
                {
                    try
                    {
                        if (args.Result == ShowResult.OK)     //启用该区域
                        {
                            ReturnInfo r = autofacConfig.assLocationService.ChangeEnable(lblName.BindDataValue.ToString(),IsEnable.启用);
                            if (r.IsSuccess == true)
                            {
                                this.Form.Toast("区域启用成功");
                                ((frmLocationRows)Form).Bind();      //刷新数据
                            }
                            else
                            {
                                throw new Exception(r.ErrorInfo);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Form.Toast(ex.Message);
                    }
                });
            }
            else
            {
                MessageBox.Show("你确定要禁用该区域吗?", "系统提醒", MessageBoxButtons.OKCancel, (object sender1, MessageBoxHandlerArgs args) =>
                {
                    try
                    {
                        if (args.Result == ShowResult.OK)     //禁用该区域
                        {
                            ReturnInfo r = autofacConfig.assLocationService.ChangeEnable(lblName.BindDataValue.ToString(), IsEnable.禁用);
                            if (r.IsSuccess == true)
                            {
                                this.Form.Toast("区域禁用成功");
                                ((frmLocationRows)Form).Bind();      //刷新数据
                            }
                            else
                            {
                                throw new Exception(r.ErrorInfo);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Form.Toast(ex.Message);
                    }
                });
            }
        }
    }
}