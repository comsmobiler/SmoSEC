using System;
using SMOSEC.UI.ConsumablesManager;
using Smobiler.Core.Controls;

namespace SMOSEC.UI.Layout
{
    ////ToolboxItem用于控制是否添加自定义控件到工具箱，true添加，false不添加
    //[System.ComponentModel.ToolboxItem(true)]
    partial class frmConsumablesLayout : Smobiler.Core.Controls.MobileUserControl
    {
        private void touchPanel1_Press(object sender, EventArgs e)
        {
            try
            {
                frmConsumablesDetail consumablesDetail = new frmConsumablesDetail {CID = lblID.BindDataValue.ToString()};
                Form.Show(consumablesDetail, (MobileForm sender1, object args) =>
                                {
                                    if (consumablesDetail.ShowResult == ShowResult.Yes)
                                    {
                                        frmConsumables consumables = (frmConsumables) Form;
                                        consumables.Bind();
                                    }
                                });
//                Form.Show(consumablesDetail);
            }
            catch (Exception ex)
            {
                Form.Toast(ex.Message);
            }
        }

        private void touchPanel1_LongPress(object sender, EventArgs e)
        {

        }
    }
}