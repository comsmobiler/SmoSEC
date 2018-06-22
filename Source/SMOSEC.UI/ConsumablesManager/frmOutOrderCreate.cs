using System;
using System.Collections.Generic;
using System.Data;
using Smobiler.Core.Controls;
using SMOSEC.CommLib;
using SMOSEC.Domain.Entity;
using SMOSEC.DTOs.InputDTO;
using SMOSEC.UI.Layout;

namespace SMOSEC.UI.ConsumablesManager
{
    partial class frmOutOrderCreate : Smobiler.Core.Controls.MobileForm
    {
        #region 变量
        private AutofacConfig _autofacConfig = new AutofacConfig();//调用配置类
        private string TypeId;
        private string HManId;
        private string LocationId;
        public DataTable ConTable;
        public List<string> ConList;

        private List<OutboundOrderRowInputDto> rowsInputDtos=new List<OutboundOrderRowInputDto>();
        private string UserId;
        #endregion

        /// <summary>
        /// 创建出库单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Press(object sender, EventArgs e)
        {
            try
            {
                GetRows();
                int TId = int.Parse(TypeId);
                OutboundOrderInputDto outboundOrderInput = new OutboundOrderInputDto()
                {
                    BUSINESSDATE=DPickerCO.Value,
                    MODIFYUSER = UserId,
                    CREATEUSER = UserId,
                    HANDLEDATE = DateTime.Now,
                    LOCATIONID = LocationId,
                    NOTE = txtNote.Text,
                    HANDLEMAN = HManId,
                    RowInputDtos = rowsInputDtos,
                    TYPE = TId
                };
                ReturnInfo returnInfo = _autofacConfig.ConsumablesService.AddOutboundOrder(outboundOrderInput);
                if (returnInfo.IsSuccess)
                {
                    ShowResult = ShowResult.Yes;
                    Toast("添加成功");
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

        /// <summary>
        /// 选择出库类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBOMan_Press(object sender, EventArgs e)
        {
            try
            {
                PopBOMan.Groups.Clear();
                PopListGroup manGroup = new PopListGroup();
                PopBOMan.Title = "出库类型选择";
                manGroup.AddListItem("退货", "1");
                manGroup.AddListItem("领用", "2");
                PopBOMan.Groups.Add(manGroup);
                if (btnBOMan.Tag != null)   //如果已有选中项，则显示选中效果
                {
                    foreach (PopListItem Item in manGroup.Items)
                    {
                        if (Item.Value == btnBOMan.Tag.ToString())
                            PopBOMan.SetSelections(Item);
                    }
                }
                PopBOMan.ShowDialog();

            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        /// <summary>
        /// 选择区域
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLocation_Press(object sender, EventArgs e)
        {
            try
            {
                PopLocation.Groups.Clear();
                PopListGroup locationGroup = new PopListGroup();
                List<AssLocation> locations = _autofacConfig.assLocationService.GetEnableAll();
                foreach (var location in locations)
                {
                    PopListItem item = new PopListItem
                    {
                        Value = location.LOCATIONID,
                        Text = location.NAME
                    };
                    locationGroup.Items.Add(item);
                }
                PopLocation.Groups.Add(locationGroup);
                if (!string.IsNullOrEmpty(btnLocation.Text))
                {
                    foreach (PopListItem row in PopLocation.Groups[0].Items)
                    {
                        if (row.Text == btnLocation.Text)
                        {
                            PopLocation.SetSelections(row);
                        }
                    }
                }
                PopLocation.ShowDialog();
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        /// <summary>
        /// 按回退，关闭当前窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmOutOrderCreate_KeyDown(object sender, KeyDownEventArgs e)
        {
            if (e.KeyCode == KeyCode.Back)
                Close();
        }

        /// <summary>
        /// 创建出库单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Press(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(btnLocation.Text))
                {
                    throw new Exception("请先选择区域.");
                }
                GetCon();
                frmConsumablesChoose consumablesChoose = new frmConsumablesChoose
                {
                    ConList = ConList,
                    ConTable = ConTable,
                    LocationId = LocationId,
                    OperationType = OperationType.出库,
                    OoList = rowsInputDtos
                };
                Show(consumablesChoose, (MobileForm sender1, object args) =>
                {
                    if (consumablesChoose.ShowResult == ShowResult.Yes)
                    {
                        ConTable = consumablesChoose.ConTable;
                        ConList = consumablesChoose.ConList;
                        BindListView();
                    }
                });

            }
            catch (Exception ex)
            {
               Toast(ex.Message);
            }
        }

        /// <summary>
        /// 选择区域后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PopLocation_Selected(object sender, EventArgs e)
        {
            try
            {

                if (PopLocation.Selection != null)
                {

                    if (string.IsNullOrEmpty(btnLocation.Text))
                    {
                        LocationId = PopLocation.Selection.Value;
                    }
                    btnLocation.Text = PopLocation.Selection.Text;
                    AssLocation location = _autofacConfig.assLocationService.GetByID(LocationId);
                    if (location != null)
                    {
                        coreUser manager = _autofacConfig.coreUserService.GetUserByID(location.MANAGER);
                        HManId = location.MANAGER;
                        if (manager != null) txtHMan.Text = manager.USER_NAME;
                    }
                    if (LocationId != null && LocationId != PopLocation.Selection.Value)
                    {
                        LocationId = PopLocation.Selection.Value;
                        ClearInfo();
                    }
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        /// <summary>
        /// 清空相关的数据
        /// </summary>
        private void ClearInfo()
        {
            ConTable.Rows.Clear();
            ConList.Clear();
            BindListView();
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        public void BindListView()
        {
            try
            {
                listViewCon.DataSource = ConTable;
                listViewCon.DataBind();
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }

        }

        /// <summary>
        /// 得到行项数据
        /// </summary>
        private void GetRows()
        {
            rowsInputDtos.Clear();
            foreach (var row in listViewCon.Rows)
            {

                OperCreateConExLayout CRow = (OperCreateConExLayout)row.Control;
                decimal Quant;
                if (decimal.TryParse(CRow.lblQuant.Text, out Quant) == false)
                {
                    throw new Exception("耗材编号" + CRow.lblCId.Text + "的库存格式不正确。");
                }
                decimal Quantity;
                if (decimal.TryParse(CRow.numQuant.Value.ToString(), out Quantity) == false)
                {
                    throw new Exception("耗材编号" + CRow.lblCId.Text + "的数量格式不正确。");
                }
                decimal Money;
                if (decimal.TryParse(CRow.numMoney.Value.ToString(), out Money) == false)
                {
                    throw new Exception("耗材编号" + CRow.lblCId.Text + "的金额格式不正确。");
                }
                if (Quantity > Quant)
                {
                    throw new Exception("耗材编号" + CRow.lblCId.Text + "库存不足。");
                }
                OutboundOrderRowInputDto rowInput = new OutboundOrderRowInputDto
                {
                    CID = CRow.lblCId.Text,
                    MONEY = Money,
                    NOTE = CRow.txtRNote.Text,
                    QUANTITY = Quantity
                };
                rowsInputDtos.Add(rowInput);
            }
        }

        /// <summary>
        /// 得到行项数据
        /// </summary>
        private void GetCon()
        {
            foreach (var row in listViewCon.Rows)
            {

                OperCreateConExLayout CRow = (OperCreateConExLayout)row.Control;
                decimal Quant;
                if (decimal.TryParse(CRow.lblQuant.Text, out Quant) == false)
                {
                    throw new Exception("耗材编号" + CRow.lblCId.Text + "的库存格式不正确。");
                }
                decimal Quantity;
                if (decimal.TryParse(CRow.numQuant.Value.ToString(), out Quantity) == false)
                {
                    throw new Exception("耗材编号" + CRow.lblCId.Text + "的数量格式不正确。");
                }
                decimal Money;
                if (decimal.TryParse(CRow.numMoney.Value.ToString(), out Money) == false)
                {
                    throw new Exception("耗材编号" + CRow.lblCId.Text + "的金额格式不正确。");
                }
                if (Quantity > Quant)
                {
                    throw new Exception("耗材编号" + CRow.lblCId.Text + "库存不足。");
                }
                DataRow Drow = ConTable.Rows.Find(CRow.lblCId.Text);
                Drow["QUANT"] = Quant;
                Drow["QUANTITY"] = Quantity;
                Drow["MONEY"] = Money;
            }

        }

        /// <summary>
        /// 界面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmOutOrderCreate_Load(object sender, EventArgs e)
        {
            try
            {
                if (ConTable == null)
                {
                    ConTable = new DataTable();
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
                }
                DataColumn[] keys = new DataColumn[1];
                keys[0] = ConTable.Columns["CID"];
                ConTable.PrimaryKey = keys;

                UserId = Client.Session["UserID"].ToString();
                if (Client.Session["Role"].ToString() == "SMOSECAdmin")
                {
                    var user = _autofacConfig.coreUserService.GetUserByID(UserId);
                    LocationId = user.USER_LOCATIONID;
                    var location = _autofacConfig.assLocationService.GetByID(LocationId);
                    btnLocation.Text = location.NAME;
                    btnLocation.Enabled = false;
                    btnLocation1.Enabled = false;
                    txtHMan.Text = user.USER_NAME;
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }
        
        /// <summary>
        /// 移除耗材
        /// </summary>
        /// <param name="CID"></param>
        public void RemoveCon(string CID)
        {
            try
            {
                DataRow row=ConTable.Rows.Find(CID);
                ConTable.Rows.Remove(row);
                ConList.Remove(CID);
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        /// <summary>
        /// 选中处理人后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PopBOMan_Selected(object sender, EventArgs e)
        {
            if (PopBOMan.Selection != null)
            {
                TypeId = PopBOMan.Selection.Value;
                btnBOMan.Text = PopBOMan.Selection.Text;
            }
        }
    }
}