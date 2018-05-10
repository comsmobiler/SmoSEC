using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Smobiler.Core;
using Smobiler.Core.Controls;

namespace SMOSEC.UI.AssetsManager
{
    partial class frmRestoreOrder : Smobiler.Core.Controls.MobileForm
    {
        private AutofacConfig _autofacConfig = new AutofacConfig();//µ÷ÓÃÅäÖÃÀà
        private void btnAdd_Press(object sender, EventArgs e)
        {
            try
            {
                frmRsoCreate frmRsoCreate = new frmRsoCreate();
                Show(frmRsoCreate, (MobileForm sender1, object args) =>
                {
                    if (frmRsoCreate.ShowResult == ShowResult.Yes)
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

        private void FrmRestoreOrder_KeyDown(object sender, KeyDownEventArgs e)
        {
            if (e.KeyCode == KeyCode.Back)
                Client.Exit();
        }

        private void FrmRestoreOrder_Load(object sender, EventArgs e)
        {
            Bind();
        }

        private void Bind()
        {
            try
            {
                DataTable assborrowTable = _autofacConfig.AssetsService.GetRsoByUserId("");
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