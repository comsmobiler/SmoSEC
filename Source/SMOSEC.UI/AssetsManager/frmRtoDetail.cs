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
    partial class frmRtoDetail : Smobiler.Core.Controls.MobileForm
    {
        private AutofacConfig _autofacConfig = new AutofacConfig();//µ˜”√≈‰÷√¿‡

        public string RtoId;
        private void FrmRtoDetail_KeyDown(object sender, KeyDownEventArgs e)
        {
            if (e.KeyCode == KeyCode.Back)
                Close();
        }

        private void FrmRtoDetail_Load(object sender, EventArgs e)
        {
            Bind();
        }

        public void Bind()
        {
            try
            {
                AssReturnOrderOutputDto assBorrowOrderOutput = _autofacConfig.AssetsService.GetRtobyId(RtoId);
                txtBOMan.Text = assBorrowOrderOutput.Returner;
                txtHMan.Text = assBorrowOrderOutput.Handleman;
                txtLocation.Text = assBorrowOrderOutput.Locationid;
                txtNote.Text = assBorrowOrderOutput.Note;
                DPickerCO.Value = assBorrowOrderOutput.Returndate;
                DataTable rowsTable = _autofacConfig.AssetsService.GetRowsByRtoid(RtoId);
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