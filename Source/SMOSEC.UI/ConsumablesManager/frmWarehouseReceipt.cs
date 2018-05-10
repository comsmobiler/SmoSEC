using System;
using System.Data;
using Smobiler.Core.Controls;

namespace SMOSEC.UI.ConsumablesManager
{
    partial class frmWarehouseReceipt : Smobiler.Core.Controls.MobileForm
    {
        private AutofacConfig _autofacConfig = new AutofacConfig();//µ÷ÓÃÅäÖÃÀà
        private void btnAdd_Press(object sender, EventArgs e)
        {
            frmWRCreate wrCreate = new frmWRCreate();
            Show(wrCreate, (MobileForm sender1, object args) =>
            {
                if (wrCreate.ShowResult == ShowResult.Yes)
                {
                    Bind();
                }
            });
        }

        private void frmWarehouseReceipt_KeyDown(object sender, KeyDownEventArgs e)
        {
            if (e.KeyCode == KeyCode.Back)
                Client.Exit();
        }

        private void Bind()
        {
            try
            {
                DataTable wrList = _autofacConfig.ConsumablesService.GetWRListByUserId("");
                if (wrList != null && wrList.Rows.Count > 0)
                {
                    gridAssRows.DataSource = wrList;
                    gridAssRows.DataBind();
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }

        }

        private void frmWarehouseReceipt_Load(object sender, EventArgs e)
        {
            Bind();
        }
    }
}