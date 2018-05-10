using System;
using Smobiler.Core.Controls;
using SMOSEC.UI.AssetsManager;
using SMOSEC.UI.ConsumablesManager;

namespace SMOSEC.UI.Layout
{
    ////ToolboxItem用于控制是否添加自定义控件到工具箱，true添加，false不添加
    //[System.ComponentModel.ToolboxItem(true)]
    partial class frmTransferRowsLayout : Smobiler.Core.Controls.MobileUserControl
    {
        /// <summary>
        /// 查看调拨单详情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void plContent_Press(object sender, EventArgs e)
        {
            try
            {
                if (Form.ToString() == "SMOSEC.UI.AssetsManager.frmTransferRowsSN")
                {
                    frmTransferDetailSN frm = new frmTransferDetailSN();
                    frm.TOID = lblID.BindDataValue.ToString();
                    Form.Show(frm, (MobileForm sender1, object args) => {
                        if (frm.ShowResult == ShowResult.Yes)
                        {
                            ((frmTransferRowsSN)Form).Bind();        //重新绑定数据
                        }
                    });             
                }
                else if (Form.ToString() == "SMOSEC.UI.ConsumablesManager.frmTransferRows")
                {
                    frmTransferDetail frm = new frmTransferDetail();
                    frm.TOID = lblID.BindDataValue.ToString();
                    Form.Show(frm, (MobileForm sender1, object args) => {
                        if (frm.ShowResult == ShowResult.Yes)
                        {
                            ((frmTransferRows)Form).Bind();        //重新绑定数据
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                Form.Toast(ex.Message);
            }
        }
    }
}