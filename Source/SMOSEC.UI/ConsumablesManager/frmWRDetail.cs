using System;
using System.Data;
using Smobiler.Core.Controls;
using SMOSEC.DTOs.OutputDTO;

namespace SMOSEC.UI.ConsumablesManager
{
    partial class frmWRDetail : Smobiler.Core.Controls.MobileForm
    {
        #region 变量
        private AutofacConfig _autofacConfig = new AutofacConfig();//调用配置类
        public string WRID; //入库单编号
        

        #endregion

        /// <summary>
        /// 按回退键，关闭当前窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmWRDetail_KeyDown(object sender, KeyDownEventArgs e)
        {
            if (e.KeyCode == KeyCode.Back)
                Close();
        }

        /// <summary>
        /// 界面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmWRDetail_Load(object sender, EventArgs e)
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
                WarehouseReceiptOutputDto warehouseReceipt = _autofacConfig.ConsumablesService.GetWarehouseReceiptById(WRID);
                if (warehouseReceipt != null)
                {
                    txtVendor.Text = warehouseReceipt.VENDOR;
                    txtHMan.Text = warehouseReceipt.HANDLEMANNAME;
                    txtLocatin.Text = warehouseReceipt.LOCATIONNAME;
                    txtNote.Text = warehouseReceipt.NOTE;
                    DPickerCO.Value = warehouseReceipt.BUSINESSDATE;
                }

                DataTable rowsTable = _autofacConfig.ConsumablesService.GetWRRowListByWRId(WRID);
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