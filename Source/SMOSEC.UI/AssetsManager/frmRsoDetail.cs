using System;
using System.Data;
using Smobiler.Core.Controls;
using SMOSEC.DTOs.OutputDTO;

namespace SMOSEC.UI.AssetsManager
{
    partial class frmRsoDetail : Smobiler.Core.Controls.MobileForm
    {
        #region 变量
        private AutofacConfig _autofacConfig = new AutofacConfig();//调用配置类

        public string RsoId;      //退库单编号  
        #endregion

        /// <summary>
        /// 按回退键时关闭当前窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmRsoDetail_KeyDown(object sender, KeyDownEventArgs e)
        {
            if (e.KeyCode == KeyCode.Back)
                Close();
        }

        /// <summary>
        /// 界面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmRsoDetail_Load(object sender, EventArgs e)
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
                AssRestoreOrderOutputDto assRestoreOrderOutput = _autofacConfig.AssetsService.GetRsobyId(RsoId);
                if (assRestoreOrderOutput != null)
                {
                    txtHMan.Text = assRestoreOrderOutput.Handleman;
                    txtLocation.Text = assRestoreOrderOutput.LocationName ;
                    txtNote.Text = assRestoreOrderOutput.Note;
                    DPickerRs.Value = assRestoreOrderOutput.Restoredate;
                    txtPlace.Text = assRestoreOrderOutput.Place;
                }
                DataTable rowsTable = _autofacConfig.AssetsService.GetRowsByRsoid(RsoId);
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