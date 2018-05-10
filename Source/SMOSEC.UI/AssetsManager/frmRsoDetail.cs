using System;
using System.Data;
using SMOSEC.DTOs.OutputDTO;
using Smobiler.Core.Controls;

namespace SMOSEC.UI.AssetsManager
{
    partial class frmRsoDetail : Smobiler.Core.Controls.MobileForm
    {
        private AutofacConfig _autofacConfig = new AutofacConfig();//µ˜”√≈‰÷√¿‡

        public string RsoId;

        private void FrmRsoDetail_KeyDown(object sender, KeyDownEventArgs e)
        {
            if (e.KeyCode == KeyCode.Back)
                Close();
        }

        private void FrmRsoDetail_Load(object sender, EventArgs e)
        {
            Bind();
        }

        public void Bind()
        {
            try
            {
                AssRestoreOrderOutputDto assRestoreOrderOutput = _autofacConfig.AssetsService.GetRsobyId(RsoId);
                txtRSMan.Text = assRestoreOrderOutput.Restorer;
                txtHMan.Text = assRestoreOrderOutput.Handleman;
                txtLocation.Text = assRestoreOrderOutput.LocationName ;
                txtNote.Text = assRestoreOrderOutput.Note;
                DPickerRs.Value = assRestoreOrderOutput.Restoredate;
                DataTable rowsTable = _autofacConfig.AssetsService.GetRowsByRsoid(RsoId);
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