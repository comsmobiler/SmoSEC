using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Smobiler.Core;
using Smobiler.Core.Controls;

namespace SMOSEC.UI.AssetsManager
{
    partial class frmBorrowOrder : Smobiler.Core.Controls.MobileForm
    {
        private AutofacConfig _autofacConfig = new AutofacConfig();//µ÷ÓÃÅäÖÃÀà
        private void btnAdd_Press(object sender, EventArgs e)
        {
            try
            {
                frmBoCreate frmBoCreate=new frmBoCreate();
                Show(frmBoCreate, (MobileForm sender1, object args) =>
                {
                    if (frmBoCreate.ShowResult == ShowResult.Yes)
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

        private void FrmBorrowOrder_KeyDown(object sender, KeyDownEventArgs e)
        {
            if (e.KeyCode == KeyCode.Back)
                Client.Exit();
        }

        private void FrmBorrowOrder_Load(object sender, EventArgs e)
        {
            Bind();
        }

        private void Bind()
        {
            try
            {
                DataTable assborrowTable = _autofacConfig.AssetsService.GetBoByUserId("");
                ListViewBorrow.Rows.Clear();
                if (assborrowTable.Rows.Count > 0)
                {
                    ListViewBorrow.DataSource = assborrowTable;
                    ListViewBorrow.DataBind();
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }

        }
    }
}