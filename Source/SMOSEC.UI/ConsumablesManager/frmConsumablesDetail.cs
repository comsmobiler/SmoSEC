using System;
using SMOSEC.CommLib;
using Smobiler.Core.Controls;

namespace SMOSEC.UI.ConsumablesManager
{
    partial class frmConsumablesDetail : Smobiler.Core.Controls.MobileForm
    {
        private AutofacConfig _autofacConfig = new AutofacConfig();//调用配置类
        public string CID;

        private void PanelImg_Press(object sender, EventArgs e)
        {

        }

        private void btnQuant_Press(object sender, EventArgs e)
        {
            try
            {
                frmConQuant conQuant = new frmConQuant {CID = CID};
                Show(conQuant);
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        private void btnEdit_Press(object sender, EventArgs e)
        {
            try
            {
                frmConsumablesDetailEdit conEdit = new frmConsumablesDetailEdit() { CID = CID };
                Form.Show(conEdit, (MobileForm sender1, object args) =>
                {
                    if (conEdit.ShowResult == ShowResult.Yes)
                    {
                        ShowResult = ShowResult.Yes;
                        Bind();
                    }
                });
//                Show(conEdit);
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        private void frmConsumablesDetail_KeyDown(object sender, KeyDownEventArgs e)
        {
            if (e.KeyCode == KeyCode.Back)
            {
//                ShowResult = ShowResult.None;
                Close();
            }
                
        }

        private void frmConsumablesDetail_Load(object sender, EventArgs e)
        {
            try
            {
                Bind();
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        private void Bind()
        {
            try
            {
                var consumables = _autofacConfig.ConsumablesService.GetConsumablesByID(CID);
                txtAssID.Text = consumables.CID;
                txtCeiling.Text = consumables.SAFECEILING.ToString();
                txtFloor.Text = consumables.SAFEFLOOR.ToString();
                txtName.Text = consumables.NAME;
                txtNote.Text = consumables.NOTE;
                txtSPQ.Text = consumables.SPQ.ToString();
                txtSpe.Text = consumables.SPECIFICATION;
                txtUnit.Text = consumables.UNIT;
                ImgPicture.ResourceID = consumables.IMAGE;
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        private void btnDelete_Press(object sender, EventArgs e)
        {
            try
            {
                ReturnInfo returnInfo = _autofacConfig.ConsumablesService.DeleteConsumables(CID);
                if (returnInfo.IsSuccess)
                {
                    ShowResult = ShowResult.Yes;
                    Toast("删除成功.");
                    Close();
                }
                else
                {
                    Toast(returnInfo.ErrorInfo);
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }
    }
}