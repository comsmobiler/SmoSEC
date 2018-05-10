using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SMOSEC.DTOs.OutputDTO;
using Smobiler.Core;
using Smobiler.Core.Controls;
using ListView = Smobiler.Core.Controls.ListView;

namespace SMOSEC.UI.AssetsManager
{
    partial class frmBoDetail : Smobiler.Core.Controls.MobileForm
    {
        private AutofacConfig _autofacConfig = new AutofacConfig();//µ˜”√≈‰÷√¿‡

        public string BoId;
        private void frmBODetail_KeyDown(object sender, KeyDownEventArgs e)
        {
            if (e.KeyCode == KeyCode.Back)
                Close();
        }

        private void frmBODetail_Load(object sender, EventArgs e)
        {
            Bind();
        }

        public void Bind()
        {
            try
            {
                AssBorrowOrderOutputDto assBorrowOrderOutput = _autofacConfig.AssetsService.GetBobyId(BoId);
                txtBOMan.Text = assBorrowOrderOutput.Borrower;
                txtHMan.Text = assBorrowOrderOutput.Brhandleman;
                txtLocation.Text = assBorrowOrderOutput.Locationid;
                txtNote.Text = assBorrowOrderOutput.Note;
                DPickerCO.Value = assBorrowOrderOutput.Borrowdate;
                DPickerRs.Value = assBorrowOrderOutput.Eptreturndate;
                DataTable rowsTable = _autofacConfig.AssetsService.GetRowsByBoid(BoId);
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