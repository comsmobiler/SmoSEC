using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using SMOSEC.DTOs.InputDTO;
using SMOSEC.UI.Layout;
using Smobiler.Core.Controls;

namespace SMOSEC.UI.ConsumablesManager
{
    partial class frmConsumablesChoose: Smobiler.Core.Controls.MobileForm
    {
        #region 变量
        private AutofacConfig _autofacConfig = new AutofacConfig();//调用配置类
        public DataTable ConTable;  //耗材表格
        public List<string> ConList;  //耗材
        public string LocationId;  //区域编号

        public OperationType OperationType;  //操作类型

        public List<WarehouseReceiptRowInputDto> WrList=new List<WarehouseReceiptRowInputDto>();  //入库单行项
        public List<OutboundOrderRowInputDto> OoList=new List<OutboundOrderRowInputDto>();  //出库单行项
        public string UserId; //用户编号
        

        #endregion

        /// <summary>
        /// 当全选发生变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Checkall_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (Checkall.Checked)
                {
                    switch (OperationType)
                    {
                        case OperationType.出库:
                            foreach (var row in listViewCon.Rows)
                            {

                                frmConChooseExLayout CRow = (frmConChooseExLayout)row.Control;
                                CRow.CheckBox1.Checked = true;
                                decimal Quant;
                                if (decimal.TryParse(CRow.lblQuant.Text, out Quant) == false)
                                {
                                    throw new Exception("耗材编号" + CRow.LblCId.Text + "的库存格式不正确。");
                                }
                                decimal Quantity;
                                if (decimal.TryParse(CRow.numeric1.Value.ToString(), out Quantity) == false)
                                {
                                    throw new Exception("耗材编号" + CRow.LblCId.Text + "的数量格式不正确。");
                                }
                                decimal Money;
                                if (decimal.TryParse(CRow.numeric2.Value.ToString(), out Money) == false)
                                {
                                    throw new Exception("耗材编号" + CRow.LblCId.Text + "的金额格式不正确。");
                                }
                                if (Quantity > Quant)
                                {
                                    throw new Exception("耗材编号" + CRow.LblCId.Text + "库存不足。");
                                }
                                AddCon(CRow.LblCId.Text, Quant, Quantity, Money, CRow.Image.ResourceID, CRow.lblName.Text);
                            }
                            break;
                        case OperationType.入库:
                            foreach (var row in listViewCon.Rows)
                            {
                                frmConChooseLayout CRows = (frmConChooseLayout)row.Control;
                                CRows.CheckBox1.Checked = true;
                                decimal Quantity;
                                if (decimal.TryParse(CRows.numeric1.Value.ToString(), out Quantity) == false)
                                {
                                    throw new Exception("耗材编号" + CRows.LblCId.Text + "的数量格式不正确。");
                                }
                                decimal Money;
                                if (decimal.TryParse(CRows.numeric2.Value.ToString(), out Money) == false)
                                {
                                    throw new Exception("耗材编号" + CRows.LblCId.Text + "的金额格式不正确。");
                                }
                                AddCon(CRows.LblCId.Text, 0, Quantity, Money, CRows.Image.ResourceID, CRows.lblName.Text);
                            }
                            break;
                    }
                }
                else
                {
                    switch (OperationType)
                    {
                        case OperationType.出库:
                            foreach (var row in listViewCon.Rows)
                            {

                                frmConChooseExLayout CRow = (frmConChooseExLayout)row.Control;
                                CRow.CheckBox1.Checked = false;                                
                            }
                            break;
                        case OperationType.入库:
                            foreach (var row in listViewCon.Rows)
                            {
                                frmConChooseLayout CRows = (frmConChooseLayout)row.Control;
                                CRows.CheckBox1.Checked = false;
                                
                            }
                            break;
                    }
                    ConTable.Rows.Clear();
                    ConList.Clear();
                    
                    ;

                }

            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }

            
        }

        /// <summary>
        /// 保存行项数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Press(object sender, EventArgs e)
        {
            try
            {
                //如果是出库，判断库存够不够
                GetCon();
                ShowResult = ShowResult.Yes;
                Close();
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        /// <summary>
        /// 搜索耗材
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void plSearch_Press(object sender, EventArgs e)
        {
            try
            {
                GetRows();
                Bind(txtFactor.Text);
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        /// <summary>
        /// 按回退键，则关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmConsumablesChoose_KeyDown(object sender, KeyDownEventArgs e)
        {
            if (e.KeyCode == KeyCode.Back)
                Close();
        }

        /// <summary>
        /// 初始化界面时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmConsumablesChoose_Load(object sender, EventArgs e)
        {
            try
            {
                //给对应的操作选择不同的行项模板
                switch (OperationType)
                {
                    case OperationType.入库:
                        listViewCon.TemplateControlName = "frmConChooseLayout";
                        break;
                    case OperationType.出库:
                        listViewCon.TemplateControlName = "frmConChooseExLayout";
                        break;
                }
                Bind(null);
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }


        private void Bind(string name)
        {
            try
            {
                if (ConTable == null)
                {
                    ConTable=new DataTable();
                }
                if (ConList == null)
                {
                    ConList=new List<string>();
                }
                if (ConTable.Columns.Count == 0)
                {
                    ConTable.Columns.Add("IMAGE");
                    ConTable.Columns.Add("CID");
                    ConTable.Columns.Add("NAME");
                    ConTable.Columns.Add("TYPE");
                    ConTable.Columns.Add("QUANT");
                    ConTable.Columns.Add("QUANTITY");
                    ConTable.Columns.Add("MONEY");
                    //                    AssTable.Columns.Add("IsChecked", Type.GetType("System.Boolean"));
                    //                    AssTable.Columns.Add("IsChecked");
                }
                DataColumn[] keys = new DataColumn[1];
                keys[0] = ConTable.Columns["CID"];
                ConTable.PrimaryKey = keys;

                DataTable conTable = new DataTable();
                switch (OperationType)
                {
                    case OperationType.入库:
                        conTable = _autofacConfig.ConsumablesService.GetConListByName(name);
                        foreach (DataRow row in conTable.Rows)
                        {
                            if (ConList.Contains(row["CID"].ToString()))
                            {
                                WarehouseReceiptRowInputDto dto = WrList.Find(a => a.CID == row["CID"].ToString());
                                row["QUANTITY"] = dto.QUANTITY;
                                row["MONEY"] = dto.MONEY;
                                row["IsChecked"] = true;
                            }
                        }
                        break;
                    case OperationType.出库:
                        conTable = _autofacConfig.ConsumablesService.GetConListByLocationAndName(LocationId, name);
                        if (conTable.Rows.Count > 0)
                        {
                            foreach (DataRow row in conTable.Rows)
                            {
                                if (ConList.Contains(row["CID"].ToString()))
                                {
                                    OutboundOrderRowInputDto dto = OoList.Find(a => a.CID == row["CID"].ToString());
                                    row["QUANTITY"] = dto.QUANTITY;
                                    row["MONEY"] = dto.MONEY;
                                    row["IsChecked"] = true;
                                }
                            }
                        }
                        
                        break;
                }
//                foreach (DataRow row in conTable.Rows)
//                {
//                    if (ConList.Contains(row["CID"].ToString()))
//                    {
//                        row["IsChecked"] = true;
//                    }
//                }

                listViewCon.Rows.Clear();
                if (conTable.Rows.Count > 0)
                {
                    listViewCon.DataSource = conTable;
                    listViewCon.DataBind();
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }

        }

        public void AddCon(string CId, decimal Quant,decimal Quantity,decimal Money, string image, string name)
        {
            try
            {
                if (ConList.Contains(CId))
                {
                    DataRow row = ConTable.Rows.Find(CId);
                    row["QUANT"] = Quant;
                    row["QUANTITY"] = Quantity;
                    row["MONEY"] = Money;
//                    throw new Exception("已添加过该资产。");
                }
                else
                {
                    DataRow row = ConTable.NewRow();
                    row["CID"] = CId;
                    row["IMAGE"] = image;
                    row["NAME"] = name;
                    row["QUANT"] = Quant;
                    row["QUANTITY"] = Quantity;
                    row["MONEY"] = Money;
                    //                    row["IsChecked"] = true;
                    switch (OperationType)
                    {
                        case OperationType.入库:
                            row["TYPE"] = "WR";
                            break;
                        case OperationType.出库:
                            row["TYPE"] = "OO";
                            break;                        
                    }
                    ConTable.Rows.Add(row);
                    ConList.Add(CId);
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }

        }
        public void RemoveCon(string CId)
        {
            try
            {
                DataRow row = ConTable.Rows.Find(CId);
                ConTable.Rows.Remove(row);
                ConList.Remove(CId);
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        public void UpdateCheckState()
        {
            try
            {
                //                int selectcount = 0;
                if (listViewCon.Rows.Count == ConList.Count)
                {
                    Checkall.Checked = true;
                }
                else
                {
                    Checkall.Checked = false;
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        private void GetRows()
        {
//            OoList.Clear();
//            WrList.Clear();
            switch (OperationType)
            {
                case OperationType.出库:
                    foreach (var row in listViewCon.Rows)
                    {

                        frmConChooseExLayout CRow = (frmConChooseExLayout)row.Control;
                        if (ConList.Contains(CRow.LblCId.Text))
                        {
                            decimal Quant;
                            if (decimal.TryParse(CRow.lblQuant.Text, out Quant) == false)
                            {
                                throw new Exception("耗材编号" + CRow.LblCId.Text + "的库存格式不正确。");
                            }
                            decimal Quantity;
                            if (decimal.TryParse(CRow.numeric1.Value.ToString(), out Quantity) == false)
                            {
                                throw new Exception("耗材编号" + CRow.LblCId.Text + "的数量格式不正确。");
                            }
                            decimal Money;
                            if (decimal.TryParse(CRow.numeric2.Value.ToString(), out Money) == false)
                            {
                                throw new Exception("耗材编号" + CRow.LblCId.Text + "的金额格式不正确。");
                            }
                            if (Quantity > Quant)
                            {
                                throw new Exception("耗材编号" + CRow.LblCId.Text + "库存不足。");
                            }
                            AddCon(CRow.LblCId.Text, Quant, Quantity, Money, CRow.Image.ResourceID, CRow.lblName.Text);
                            if (OoList.Any(a => a.CID == CRow.LblCId.Text))
                            {
                                OutboundOrderRowInputDto dto = OoList.Find(a => a.CID == CRow.LblCId.Text);
                                dto.MONEY = Money;
                                dto.QUANTITY = Quantity;
                            }
                            else
                            {
                                OutboundOrderRowInputDto rowInput = new OutboundOrderRowInputDto
                                {
                                    CID = CRow.LblCId.Text,
                                    MONEY = Money,
                                    NOTE = "",
                                    QUANTITY = Quantity
                                };
                                OoList.Add(rowInput);
                            }
                            
                        }
                    }
                    break;
                case OperationType.入库:
                    foreach (var row in listViewCon.Rows)
                    {
                        frmConChooseLayout CRows = (frmConChooseLayout)row.Control;
                        if (ConList.Contains(CRows.LblCId.Text))
                        {
                            decimal Quantity;
                            if (decimal.TryParse(CRows.numeric1.Value.ToString(), out Quantity) == false)
                            {
                                throw new Exception("耗材编号" + CRows.LblCId.Text + "的数量格式不正确。");
                            }
                            decimal Money;
                            if (decimal.TryParse(CRows.numeric2.Value.ToString(), out Money) == false)
                            {
                                throw new Exception("耗材编号" + CRows.LblCId.Text + "的金额格式不正确。");
                            }
                            AddCon(CRows.LblCId.Text, 0, Quantity, Money, CRows.Image.ResourceID, CRows.lblName.Text);
                            if (WrList.Any(a => a.CID == CRows.LblCId.Text))
                            {
                                WarehouseReceiptRowInputDto dto = WrList.Find(a => a.CID == CRows.LblCId.Text);
                                dto.MONEY = Money;
                                dto.QUANTITY = Quantity;
                            }
                            else
                            {
                                WarehouseReceiptRowInputDto rowInput = new WarehouseReceiptRowInputDto
                                {
                                    CID = CRows.LblCId.Text,
                                    MONEY = Money,
                                    NOTE = "",
                                    QUANTITY = Quantity
                                };
                                WrList.Add(rowInput);
                            }
                        }
                    }
                    break;
            }


//            foreach (var row in listViewCon.Rows)
//            {
//
//                OperCreateConExLayout CRow = (OperCreateConExLayout)row.Control;
//                decimal Quant;
//                if (decimal.TryParse(CRow.lblQuant.Text, out Quant) == false)
//                {
//                    throw new Exception("耗材编号" + CRow.lblCId.Text + "的库存格式不正确。");
//                }
//                decimal Quantity;
//                if (decimal.TryParse(CRow.numQuant.Value.ToString(), out Quantity) == false)
//                {
//                    throw new Exception("耗材编号" + CRow.lblCId.Text + "的数量格式不正确。");
//                }
//                decimal Money;
//                if (decimal.TryParse(CRow.numMoney.Value.ToString(), out Money) == false)
//                {
//                    throw new Exception("耗材编号" + CRow.lblCId.Text + "的金额格式不正确。");
//                }
//                if (Quantity > Quant)
//                {
//                    throw new Exception("耗材编号" + CRow.lblCId.Text + "库存不足。");
//                }
//                OutboundOrderRowInputDto rowInput = new OutboundOrderRowInputDto
//                {
//                    CID = CRow.lblCId.Text,
//                    MONEY = Money,
//                    NOTE = CRow.txtRNote.Text,
//                    QUANTITY = Quantity
//                };
//                rowsInputDtos.Add(rowInput);
//            }
        }

        private void GetCon()
        {
            switch (OperationType)
            {
                case OperationType.出库:
                    ConTable.Rows.Clear();
                    ConList.Clear();
                    foreach (var row in listViewCon.Rows)
                    {

                        frmConChooseExLayout CRow = (frmConChooseExLayout) row.Control;
                        if (CRow.CheckBox1.Checked)
                        {
                            decimal Quant;
                            if (decimal.TryParse(CRow.lblQuant.Text, out Quant) == false)
                            {
                                throw new Exception("耗材编号" + CRow.LblCId.Text + "的库存格式不正确。");
                            }
                            decimal Quantity;
                            if (decimal.TryParse(CRow.numeric1.Value.ToString(), out Quantity) == false)
                            {
                                throw new Exception("耗材编号" + CRow.LblCId.Text + "的数量格式不正确。");
                            }
                            decimal Money;
                            if (decimal.TryParse(CRow.numeric2.Value.ToString(), out Money) == false)
                            {
                                throw new Exception("耗材编号" + CRow.LblCId.Text + "的金额格式不正确。");
                            }
                            if (Quantity > Quant)
                            {
                                throw new Exception("耗材编号" + CRow.LblCId.Text + "库存不足。");
                            }
                            AddCon(CRow.LblCId.Text, Quant, Quantity, Money, CRow.Image.ResourceID, CRow.lblName.Text);
                        }
                    }
                    break;
                case OperationType.入库:
                    ConTable.Rows.Clear();
                    ConList.Clear();
                    foreach (var row in listViewCon.Rows)
                    {
                        frmConChooseLayout CRows = (frmConChooseLayout) row.Control;
                        if (CRows.CheckBox1.Checked)
                        {
                            decimal Quantity;
                            if (decimal.TryParse(CRows.numeric1.Value.ToString(), out Quantity) == false)
                            {
                                throw new Exception("耗材编号" + CRows.LblCId.Text + "的数量格式不正确。");
                            }
                            decimal Money;
                            if (decimal.TryParse(CRows.numeric2.Value.ToString(), out Money) == false)
                            {
                                throw new Exception("耗材编号" + CRows.LblCId.Text + "的金额格式不正确。");
                            }
                            AddCon(CRows.LblCId.Text, 0, Quantity, Money, CRows.Image.ResourceID, CRows.lblName.Text);
                        }
                    }
                    break;
            }

            
        }
    }
}