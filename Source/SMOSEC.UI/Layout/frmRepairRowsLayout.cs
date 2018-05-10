using System;
using Smobiler.Core.Controls;
using SMOSEC.UI.AssetsManager;

namespace SMOSEC.UI.Layout
{
    ////ToolboxItem用于控制是否添加自定义控件到工具箱，true添加，false不添加
    //[System.ComponentModel.ToolboxItem(true)]
    partial class frmRepairRowsLayout : Smobiler.Core.Controls.MobileUserControl
    {
        /// <summary>
        /// 点击查看报修单详情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void plContent_Press(object sender, EventArgs e)
        {
            try
            {
                    frmRepairDetailSN frm = new frmRepairDetailSN();
                    frm.ROID = lblID.BindDataValue.ToString();
                    Form.Show(frm, (MobileForm sender1, object args) => {
                        if (frm.ShowResult == ShowResult.Yes)
                        {
                            ((frmRepairRowsSN)Form).Bind();        //重新绑定数据
                        }
                    });
            }
            catch(Exception ex)
            {
                Form.Toast(ex.Message);
            }
        }
    }
}