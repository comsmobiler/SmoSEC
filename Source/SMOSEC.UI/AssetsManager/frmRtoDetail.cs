using System;
using System.Data;
using Smobiler.Core.Controls;
using SMOSEC.DTOs.OutputDTO;

namespace SMOSEC.UI.AssetsManager
{
    partial class frmRtoDetail : Smobiler.Core.Controls.MobileForm
    {
        #region 变量
        private AutofacConfig _autofacConfig = new AutofacConfig();//调用配置类

        public string RtoId;   //归还单编号
        
        #endregion

        /// <summary>
        /// 按回退键时关闭当前窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmRtoDetail_KeyDown(object sender, KeyDownEventArgs e)
        {
            if (e.KeyCode == KeyCode.Back)
                Close();
        }

        /// <summary>
        /// 界面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmRtoDetail_Load(object sender, EventArgs e)
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
                AssReturnOrderOutputDto assBorrowOrderOutput = _autofacConfig.AssetsService.GetRtobyId(RtoId);
                if (assBorrowOrderOutput != null)
                {
                    txtHMan.Text = assBorrowOrderOutput.Handleman;
                    txtLocation.Text = assBorrowOrderOutput.Locationid;
                    txtNote.Text = assBorrowOrderOutput.Note;
                    DPickerCO.Value = assBorrowOrderOutput.Returndate;
                }
                DataTable rowsTable = _autofacConfig.AssetsService.GetRowsByRtoid(RtoId);
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