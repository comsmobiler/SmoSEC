using System;
using System.Data;
using Smobiler.Core.Controls;

namespace SMOSEC.UI.ConsumablesManager
{
    partial class frmConsumables : Smobiler.Core.Controls.MobileForm
    {
        private AutofacConfig _autofacConfig = new AutofacConfig();//µ÷ÓÃÅäÖÃÀà
        private void btnAdd_Press(object sender, EventArgs e)
        {
            try
            {
                frmConsumablesCreate consumablesCreate=new frmConsumablesCreate();
                Show(consumablesCreate, (MobileForm sender1, object args) =>
                {
                    if (consumablesCreate.ShowResult == ShowResult.Yes)
                    {
                        Bind();
                    }
                });
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        private void frmConsumables_KeyDown(object sender, KeyDownEventArgs e)
        {
            if (e.KeyCode == KeyCode.Back)
                Client.Exit();
        }

        private void frmConsumables_Load(object sender, EventArgs e)
        {
            Bind();
        }

        public void Bind()
        {
            try
            {
                
                DataTable conTable = _autofacConfig.ConsumablesService.GetConList();
                ListViewCon.Rows.Clear();
                if (conTable.Rows.Count > 0)
                {
                    ListViewCon.DataSource = conTable;
                    ListViewCon.DataBind();
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }
    }
}