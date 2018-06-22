using System;
using System.Data;
using Smobiler.Core.Controls;
using SMOSEC.DTOs.OutputDTO;

namespace SMOSEC.UI.AssetsManager
{
    partial class frmCoDetail : Smobiler.Core.Controls.MobileForm
    {
        #region 变量
        private AutofacConfig _autofacConfig = new AutofacConfig();//调用配置类

        public string CoId; //领用单编号        

        #endregion


        /// <summary>
        /// 手机按回退时关闭当前窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmCoDetail_KeyDown(object sender, KeyDownEventArgs e)
        {
            if (e.KeyCode == KeyCode.Back)
                Close();
        }

        /// <summary>
        /// 界面初始化时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmCoDetail_Load(object sender, EventArgs e)
        {
            Bind();
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        public void Bind()
        {
            try
            {
                AssCollarOrderOutputDto assCollarOrderOutput = _autofacConfig.AssetsService.GetCobyId(CoId);
                if (assCollarOrderOutput != null)
                {
                    txtCOMan.Text = assCollarOrderOutput.Userid;
                    txtHMan.Text = assCollarOrderOutput.Handleman;
                    txtLocation.Text = assCollarOrderOutput.Locationid;
                    txtNote.Text = assCollarOrderOutput.Note;
                    DPickerCO.Value = assCollarOrderOutput.Collardate;
                    if (assCollarOrderOutput.Eptrestoredate != null)
                    {
                        DPickerRs.Value = assCollarOrderOutput.Eptrestoredate.Value;    
                    }
                    txtDep.Text = assCollarOrderOutput.Inusedep;
                    txtPlace.Text = assCollarOrderOutput.Place;
                }
                DataTable rowsTable = _autofacConfig.AssetsService.GetRowsByCoid(CoId);
                if (rowsTable != null)
                {
                    ListAss.DataSource = rowsTable;
                    ListAss.DataBind();
                }
                
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }
    }
}