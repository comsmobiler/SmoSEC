using System;
using System.Data;
using SMOSEC.DTOs.OutputDTO;
using Smobiler.Core.Controls;

namespace SMOSEC.UI.ConsumablesManager
{
    partial class frmOutOrderDetail : Smobiler.Core.Controls.MobileForm
    {
        private AutofacConfig _autofacConfig = new AutofacConfig();//调用配置类      
        public string OOId;

        private void frmOutOrderDetail_KeyDown(object sender, KeyDownEventArgs e)
        {
            if (e.KeyCode == KeyCode.Back)
                Close();
        }

        private void frmOutOrderDetail_Load(object sender, EventArgs e)
        {
            Bind();
        }

        public void Bind()
        {
            try
            {
                OutboundOrderOutputDto outboundOrder = _autofacConfig.ConsumablesService.GetOutboundOrderById(OOId);
                txtType.Text = outboundOrder.TYPENAME;
                txtHMan.Text = outboundOrder.HANDLEMANNAME;
                txtLocation.Text = outboundOrder.LOCATIONNAME;
                txtNote.Text = outboundOrder.NOTE;
                DPickerCO.Value = outboundOrder.BUSINESSDATE;
                txtType.Text = outboundOrder.TYPE == 1 ? "退货" : "领用";

                DataTable rowsTable = _autofacConfig.ConsumablesService.GetOORowListByOOId(OOId);
                ListAss.DataSource = rowsTable;
                ListAss.DataBind();
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }
    }
}