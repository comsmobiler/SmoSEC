using System;
using System.Data;
using Smobiler.Core.Controls;

namespace SMOSEC.UI.ConsumablesManager
{
    partial class frmOutboundOrder : Smobiler.Core.Controls.MobileForm
    {
        private AutofacConfig _autofacConfig = new AutofacConfig();//µ÷ÓÃÅäÖÃÀà
        private void btnAdd_Press(object sender, EventArgs e)
        {
            frmOutOrderCreate outOrderCreate = new frmOutOrderCreate();
            Show(outOrderCreate, (MobileForm sender1, object args) =>
            {
                if (outOrderCreate.ShowResult == ShowResult.Yes)
                {
                    Bind();
                }
            });
        }

        private void frmOutboundOrder_KeyDown(object sender, KeyDownEventArgs e)
        {
            if (e.KeyCode == KeyCode.Back)
                Client.Exit();
        }

        private void frmOutboundOrder_Load(object sender, EventArgs e)
        {
            Bind();
        }

        private void Bind()
        {
            try
            {
                DataTable ooList = _autofacConfig.ConsumablesService.GetOOListByUserId("");
                if (ooList != null && ooList.Rows.Count > 0)
                {
                    gridAssRows.DataSource = ooList;
                    gridAssRows.DataBind();
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }

        }


    }
}