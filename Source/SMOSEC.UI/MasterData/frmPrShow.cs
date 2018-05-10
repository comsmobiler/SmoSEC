using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SMOSEC.DTOs.Enum;
using Smobiler.Core;
using Smobiler.Core.Controls;

namespace SMOSEC.UI.MasterData
{
    partial class frmPrShow : Smobiler.Core.Controls.MobileForm
    {
        public string AssId;
        AutofacConfig _autofacConfig = new AutofacConfig();//µ˜”√≈‰÷√¿‡

        private void frmPRShow_KeyDown(object sender, KeyDownEventArgs e)
        {
            try
            {
                if (e.KeyCode == KeyCode.Back)
                    Close();
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        private void frmPRShow_Load(object sender, EventArgs e)
        {
            try
            {
//                string a= Enum.GetName(typeof(STATUS),STATUS.œ–÷√);
//                Toast(a);
                DataTable table = _autofacConfig.SettingService.GetRecords(AssId);
                GridView1.DataSource = table;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }
    }
}