using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Smobiler.Core;
using Smobiler.Core.Controls;

namespace SMOSEC.UI.AssetsManager
{
    partial class frmCollarOrder : Smobiler.Core.Controls.MobileForm
    {
        private AutofacConfig _autofacConfig = new AutofacConfig();//µ÷ÓÃÅäÖÃÀà

        private void btnAdd_Press(object sender, EventArgs e)
        {
            try
            {
                frmCoCreate frmCoCreate= new frmCoCreate();
                Show(frmCoCreate, (MobileForm sender1, object args) =>
                {
                    if (frmCoCreate.ShowResult == ShowResult.Yes)
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

        private void FrmCollarOrder_KeyDown(object sender, KeyDownEventArgs e)
        {
            if (e.KeyCode == KeyCode.Back)
                Client.Exit();
        }

        private void FrmCollarOrder_Load(object sender, EventArgs e)
        {
            Bind();
        }

        private void Bind()
        {
            try
            {
                DataTable assborrowTable = _autofacConfig.AssetsService.GetCoByUserId("");
                ListViewCO.Rows.Clear();
                if (assborrowTable.Rows.Count > 0)
                {
                    ListViewCO.DataSource = assborrowTable;
                    ListViewCO.DataBind();
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }

        }
    }
}