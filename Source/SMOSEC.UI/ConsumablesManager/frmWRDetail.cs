using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SMOSEC.DTOs.OutputDTO;
using Smobiler.Core;
using Smobiler.Core.Controls;

namespace SMOSEC.UI.ConsumablesManager
{
    partial class frmWRDetail : Smobiler.Core.Controls.MobileForm
    {
        private AutofacConfig _autofacConfig = new AutofacConfig();//µ˜”√≈‰÷√¿‡
        public string WRID;

        private void frmWRDetail_KeyDown(object sender, KeyDownEventArgs e)
        {
            if (e.KeyCode == KeyCode.Back)
                Close();
        }

        private void frmWRDetail_Load(object sender, EventArgs e)
        {
            Bind();
        }

        public void Bind()
        {
            try
            {
                WarehouseReceiptOutputDto warehouseReceipt = _autofacConfig.ConsumablesService.GetWarehouseReceiptById(WRID);
                txtVendor.Text = warehouseReceipt.VENDOR;
                txtHMan.Text = warehouseReceipt.HANDLEMANNAME;
                txtLocatin.Text = warehouseReceipt.LOCATIONNAME;
                txtNote.Text = warehouseReceipt.NOTE;
                DPickerCO.Value = warehouseReceipt.BUSINESSDATE;

                DataTable rowsTable = _autofacConfig.ConsumablesService.GetWRRowListByWRId(WRID);
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