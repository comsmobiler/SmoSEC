using System;
using System.Data;
using SMOSEC.DTOs.OutputDTO;
using Smobiler.Core.Controls;

namespace SMOSEC.UI.ConsumablesManager
{
    partial class frmOutOrderDetail : Smobiler.Core.Controls.MobileForm
    {
        #region 变量
        private AutofacConfig _autofacConfig = new AutofacConfig();//调用配置类      
        public string OOId;
        

        #endregion

        /// <summary>
        /// 按回退时，关闭当前窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmOutOrderDetail_KeyDown(object sender, KeyDownEventArgs e)
        {
            if (e.KeyCode == KeyCode.Back)
                Close();
        }

        /// <summary>
        /// 初始化界面时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmOutOrderDetail_Load(object sender, EventArgs e)
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
                OutboundOrderOutputDto outboundOrder = _autofacConfig.ConsumablesService.GetOutboundOrderById(OOId);
                if (outboundOrder != null)
                {
                    txtType.Text = outboundOrder.TYPENAME;
                    txtHMan.Text = outboundOrder.HANDLEMANNAME;
                    txtLocation.Text = outboundOrder.LOCATIONNAME;
                    txtNote.Text = outboundOrder.NOTE;
                    DPickerCO.Value = outboundOrder.BUSINESSDATE;
                    txtType.Text = outboundOrder.TYPE == 1 ? "退货" : "领用";
                }

                DataTable rowsTable = _autofacConfig.ConsumablesService.GetOORowListByOOId(OOId);
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