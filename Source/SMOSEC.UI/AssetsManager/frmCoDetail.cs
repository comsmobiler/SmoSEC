using System;
using System.Data;
using SMOSEC.DTOs.OutputDTO;
using Smobiler.Core.Controls;

namespace SMOSEC.UI.AssetsManager
{
    partial class frmCoDetail : Smobiler.Core.Controls.MobileForm
    {
        private AutofacConfig _autofacConfig = new AutofacConfig();//µ˜”√≈‰÷√¿‡

        public string CoId;


        private void FrmCoDetail_KeyDown(object sender, KeyDownEventArgs e)
        {
            if (e.KeyCode == KeyCode.Back)
                Close();
        }

        private void FrmCoDetail_Load(object sender, EventArgs e)
        {
            Bind();
        }

        public void Bind()
        {
            try
            {
                AssCollarOrderOutputDto assBorrowOrderOutput = _autofacConfig.AssetsService.GetCobyId(CoId);
                txtCOMan.Text = assBorrowOrderOutput.Userid;
                txtHMan.Text = assBorrowOrderOutput.Handleman;
                txtLocation.Text = assBorrowOrderOutput.Locationid;
                txtNote.Text = assBorrowOrderOutput.Note;
                DPickerCO.Value = assBorrowOrderOutput.Collardate;
                if (assBorrowOrderOutput.Eptrestoredate != null)
                {
                    DPickerRs.Value = assBorrowOrderOutput.Eptrestoredate.Value;    
                }
                
                DataTable rowsTable = _autofacConfig.AssetsService.GetRowsByCoid(CoId);
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