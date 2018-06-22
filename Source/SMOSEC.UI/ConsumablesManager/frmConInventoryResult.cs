using System;
using System.Collections.Generic;
using Smobiler.Core.Controls;
using System.Data;
using SMOSEC.DTOs.Enum;
using System.Drawing;
using System.Windows.Forms;
using ListView = Smobiler.Core.Controls.ListView;
using SMOSEC.UI.Layout;
using SMOSEC.CommLib;
using SMOSEC.DTOs.InputDTO;
using SMOSEC.Domain.Entity;

namespace SMOSEC.UI.ConsumablesManager
{
    partial class frmConInventoryResult : Smobiler.Core.Controls.MobileForm
    {
        #region  定义变量
        private AutofacConfig _autofacConfig = new AutofacConfig();//调用配置类
        public string IID; //盘点单编号
        private string UserId;  //用户编号
        private DataTable waiTable = new DataTable(); //待盘点的资产
        private DataTable alreadyTable = new DataTable(); //已盘点的资产
        private Dictionary<string, List<decimal>> conDictionary = new Dictionary<string, List<decimal>>();  //资产
        private List<string> conList;  //资产的初始列表

        private ListView waitListView = new ListView();
        private ListView alreadyListView = new ListView();

        public string LocationId;
        public InventoryStatus Status;
        #endregion
        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmConInventoryResult_Load(object sender, EventArgs e)
        {
            try
            {
                UserId = Client.Session["UserID"].ToString();
                //添加各表格的列
                if (waiTable.Columns.Count == 0)
                {
                    waiTable.Columns.Add("RESULTNAME");
                    waiTable.Columns.Add("CID");
                    waiTable.Columns.Add("Image");
                    waiTable.Columns.Add("Name");
                    waiTable.Columns.Add("Specification");
                    waiTable.Columns.Add("Total");
                    waiTable.Columns.Add("RealAmount");
                }
                DataColumn[] keys = new DataColumn[1];
                keys[0] = waiTable.Columns["CID"];
                waiTable.PrimaryKey = keys;

                //添加各表格的列
                if (alreadyTable.Columns.Count == 0)
                {
                    alreadyTable.Columns.Add("RESULTNAME");
                    alreadyTable.Columns.Add("CID");
                    alreadyTable.Columns.Add("Image");
                    alreadyTable.Columns.Add("Name");
                    alreadyTable.Columns.Add("Specification");
                    alreadyTable.Columns.Add("Total");
                    alreadyTable.Columns.Add("RealAmount");
                }
                DataColumn[] keys2 = new DataColumn[1];
                keys2[0] = alreadyTable.Columns["CID"];
                alreadyTable.PrimaryKey = keys2;

                //添加ListView到tabpageview
                waitListView.TemplateControlName = "frmCIResultLayout";
                waitListView.ShowSplitLine = true;
                waitListView.SplitLineColor = Color.FromArgb(230, 230, 230);
                waitListView.Dock = DockStyle.Fill;
                tabPageView1.Controls.Add(waitListView);

                alreadyListView.TemplateControlName = "frmCIResultLayout";
                alreadyListView.ShowSplitLine = true;
                alreadyListView.SplitLineColor = Color.FromArgb(230, 230, 230);
                alreadyListView.Dock = DockStyle.Fill;
                tabPageView1.Controls.Add(alreadyListView);

                var inventory = _autofacConfig.ConInventoryService.GetConInventoryById(IID);
                lblName.Text = inventory.NAME;
                lblHandleMan.Text = inventory.HANDLEMANNAME;
                lblCount.Text = inventory.TOTAL.ToString();
                lblLocatin.Text = inventory.LOCATIONNAME;
                Status = (InventoryStatus)inventory
                    .STATUS;

                if (Status == InventoryStatus.盘点结束 || Status == InventoryStatus.盘点未开始)
                {
                    panelScan.Visible = false;
                }
                //获得需要盘点的资产列表
                conList = _autofacConfig.ConInventoryService.GetPendingInventoryList(IID);

                //得到盘点单当前的所有行项
                conDictionary = _autofacConfig.ConInventoryService.GetResultDictionary(IID);

                //得到待盘点的资产列表
                var waiTable1 = _autofacConfig.ConInventoryService.GetPendingInventoryTable(IID, LocationId);
                foreach (DataRow row in waiTable1.Rows)
                {
                    DataRow Row = waiTable.NewRow();
                    Row["CID"] = row["CID"].ToString();
                    Row["RESULTNAME"] = row["RESULTNAME"].ToString();
                    Row["Image"] = row["Image"].ToString();
                    Row["Name"] = row["Name"].ToString();
                    Row["Specification"] = row["Specification"].ToString();
                    Row["Total"] = row["Total"].ToString();
                    Row["RealAmount"] = row["RealAmount"].ToString();

                    waiTable.Rows.Add(Row);
                }
                if (inventory.TOTAL == 0)
                {
                    lblCount.Text = waiTable1.Rows.Count.ToString();
                }


                //得到已盘点的资产列表
                var alreadyTable1 = _autofacConfig.ConInventoryService.GetConInventoryResultsByIID(IID, ResultStatus.已盘点);
                foreach (DataRow row in alreadyTable1.Rows)
                {
                    DataRow Row = alreadyTable.NewRow();
                    Row["CID"] = row["CID"].ToString();
                    Row["RESULTNAME"] = row["RESULTNAME"].ToString();
                    Row["Image"] = row["Image"].ToString();
                    Row["Name"] = row["Name"].ToString();
                    Row["Specification"] = row["Specification"].ToString();
                    Row["Total"] = row["Total"].ToString();
                    Row["RealAmount"] = row["RealAmount"].ToString();

                    alreadyTable.Rows.Add(Row);
                }

                if (Status == InventoryStatus.盘点结束 || Status == InventoryStatus.盘点未开始)
                {
                    Form.ActionButton.Enabled = false;
                }

                //绑定数据
                Bind();
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }
        /// <summary>
        /// 数据加载
        /// </summary>
        private void Bind()
        {
            try
            {
                waitListView.Rows.Clear();
                waitListView.DataSource = waiTable;
                waitListView.DataBind();

                alreadyListView.Rows.Clear();
                alreadyListView.DataSource = alreadyTable;
                alreadyListView.DataBind();

                tabPageView1.Titles = new string[] {
                    "待盘点(" + waiTable.Rows.Count.ToString() + ")",
                    "已盘点(" + alreadyTable.Rows.Count.ToString() + ")" };

                foreach (var row in alreadyListView.Rows)
                {
                    frmCIResultLayout layout = (frmCIResultLayout)row.Control;
                    if (layout.label2.Text == "盘亏")
                        layout.label2.ForeColor = Color.Red;
                    else if (layout.label2.Text == "盘盈")
                        layout.label2.ForeColor = Color.FromArgb(43, 140, 255);
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }
        /// <summary>
        /// 盘点上传或盘点结束
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmConInventoryResult_ActionButtonPress(object sender, ActionButtonPressEventArgs e)
        {
            try
            {
                ReturnInfo rInfo = new ReturnInfo();
                switch (e.Index)
                {
                    case 0:
                        //上传结果
                        ConInventoryInputDto inputDto = new ConInventoryInputDto
                        {
                            IID = IID,
                            IsEnd = false,
                            ConDictionary = conDictionary,
                            LOCATIONID = LocationId,
                            CREATEUSER = UserId
                        };
                        inputDto.IsEnd = false;
                        rInfo = _autofacConfig.ConInventoryService.UpdateInventory(inputDto);
                        Toast(rInfo.IsSuccess ? "上传结果成功!" : rInfo.ErrorInfo);
                        break;
                    case 1:
                        //盘点结束
                        Dictionary<string, List<decimal>> conDictionary2 = new Dictionary<string, List<decimal>>();
                        foreach (var key in conDictionary.Keys)
                        {
                            if (conDictionary[key][1] == (int)ResultStatus.待盘点)
                            {
                                List<decimal> list = new List<decimal>();
                                list.Add(0);
                                list.Add(Convert.ToDecimal((int)ResultStatus.盘亏));
                                conDictionary2.Add(key, list);
                            }
                            else
                            {
                                conDictionary2.Add(key, conDictionary[key]);
                            }
                        }

                        ConInventoryInputDto inputDto2 = new ConInventoryInputDto
                        {
                            IID = IID,
                            LOCATIONID = LocationId,
                            IsEnd = false,
                            ConDictionary = conDictionary2
                        };
                        inputDto2.IsEnd = true;
                        rInfo = _autofacConfig.ConInventoryService.UpdateInventory(inputDto2);
                        if (rInfo.IsSuccess)
                        {
                            ShowResult = ShowResult.Yes;
                            Close();
                            Toast("盘点结束成功.");
                        }
                        else
                        {
                            Toast(rInfo.ErrorInfo);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }
        /// <summary>
        /// 耗材扫描
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barcodeScanner1_BarcodeScanned(object sender, BarcodeResultArgs e)
        {
            try
            {
                string CID = e.Value.ToUpper();
                var con = _autofacConfig.ConsumablesService.GetConsumablesByID(CID);
                if (con != null)
                {
                    ConInventoryResult result = _autofacConfig.ConInventoryService.GetResultByCID(IID, CID);
                    if (result != null)
                    {
                        if (result.RESULT.ToString() != "0") throw new Exception("该耗材已盘点完毕,请勿重复盘点!");
                        frmCIResultTotalLayout frm = new frmCIResultTotalLayout();
                        DataTable conq = _autofacConfig.ConsumablesService.GetQuants(LocationId, CID);
                        frm.lblNumber.Text = conq.Rows[0]["QUANTITY"].ToString();
                        frm.CID = CID;
                        Form.ShowDialog(frm);
                    }
                    else        //盘盈
                    {
                        frmCIResultTotalLayout frm = new frmCIResultTotalLayout();
                        DataTable conq = _autofacConfig.ConsumablesService.GetQuants(LocationId, CID);
                        frm.plNumber.Visible = false;
                        frm.Height = 120;
                        frm.CID = CID;
                        Form.ShowDialog(frm);
                    }


                }
                else
                {
                    Toast("未找到对应的耗材!");
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }
        /// <summary>
        /// 盘点耗材，刷新界面
        /// </summary>
        /// <param name="CID"></param>
        /// <param name="RealNumber"></param>
        public void AddConToDictionary(string CID, Decimal RealAmount)
        {
            if (conList.Contains(CID))
            {
                //如果本来是需要盘点的，状态改为已盘点
                conDictionary[CID][0] = RealAmount;
                //如果待盘点的datatable存在该资产，从待盘点中删除，并加入到已盘点datatable
                DataRow row = waiTable.Rows.Find(CID);
                if (row != null)
                {
                    DataRow alreadyRow = alreadyTable.NewRow();
                    alreadyRow["CID"] = row["CID"].ToString();
                    alreadyRow["Image"] = row["Image"].ToString();
                    alreadyRow["Name"] = row["Name"].ToString();
                    alreadyRow["Specification"] = row["Specification"].ToString();
                    alreadyRow["Total"] = row["Total"].ToString();
                    alreadyRow["RealAmount"] = RealAmount;
                    if (Convert.ToDecimal(row["Total"]) < RealAmount)
                    {
                        alreadyRow["RESULTNAME"] = "盘盈";
                        conDictionary[CID][1] = (int)ResultStatus.盘盈;
                    }
                    else if (Convert.ToDecimal(alreadyRow["Total"]) > RealAmount)
                    {
                        alreadyRow["RESULTNAME"] = "盘亏";
                        conDictionary[CID][1] = (int)ResultStatus.盘亏;
                    }
                    else
                    {
                        alreadyRow["RESULTNAME"] = "存在";
                        conDictionary[CID][1] = (int)ResultStatus.存在;
                    }
                    alreadyTable.Rows.Add(alreadyRow);
                    waiTable.Rows.Remove(row);
                }
                else
                {
                    if (conDictionary[CID][1] != (int)ResultStatus.盘盈)
                    {
                        DataRow Arow = alreadyTable.Rows.Find(CID);
                        if (Convert.ToDecimal(Arow["Total"]) < RealAmount)
                        {
                            conDictionary[CID][1] = (int)ResultStatus.盘盈;
                            Arow["RealAmount"] = RealAmount;
                            Arow["RESULTNAME"] = "盘盈";
                        }
                        else if (Convert.ToDecimal(Arow["Total"]) > RealAmount)
                        {
                            conDictionary[CID][1] = (int)ResultStatus.盘亏;
                            Arow["RealAmount"] = RealAmount;
                            Arow["RESULTNAME"] = "盘亏";
                        }
                        else
                        {
                            conDictionary[CID][1] = (int)ResultStatus.存在;
                            Arow["RealAmount"] = RealAmount;
                            Arow["RESULTNAME"] = "";
                        }
                    }
                    else
                    {
                        DataRow Arow = alreadyTable.Rows.Find(CID);
                        if (Convert.ToDecimal(Arow["Total"]) < RealAmount)
                        {
                            Arow["RealAmount"] = RealAmount;
                        }
                        else if (Convert.ToDecimal(Arow["Total"]) >= RealAmount)
                        {
                            if (Convert.ToDecimal(Arow["Total"]) > RealAmount)
                            {
                                conDictionary[CID][1] = (int)ResultStatus.盘亏;
                                Arow["RESULTNAME"] = "盘亏";
                            }
                            else
                            {
                                conDictionary[CID][1] = (int)ResultStatus.存在;
                                Arow["RESULTNAME"] = "";
                            }
                        }
                    }
                }
            }
            else
            {
                //如果本来是不需要盘点的，状态改为盘盈
                if (!conDictionary.ContainsKey(CID))
                {
                    List<decimal> list = new List<decimal>();
                    list.Add(RealAmount);
                    list.Add(Convert.ToDecimal((int)ResultStatus.盘盈));
                    conDictionary.Add(CID, list);
                }
                DataRow row = alreadyTable.Rows.Find(CID);
                if (row == null)
                {
                    var con = _autofacConfig.ConsumablesService.GetConsumablesByID(CID);

                    DataRow moreRow = alreadyTable.NewRow();
                    moreRow["CID"] = con.CID;
                    moreRow["RESULTNAME"] = "盘盈";
                    moreRow["Image"] = con.IMAGE;
                    moreRow["Name"] = con.NAME;
                    moreRow["Specification"] = con.SPECIFICATION;
                    moreRow["Total"] = 0;
                    moreRow["RealAmount"] = RealAmount;
                    alreadyTable.Rows.Add(moreRow);
                }
                else
                {
                    row["RealAmount"] = RealAmount;
                }
            }
            Bind();
        }
        /// <summary>
        /// 二维码扫描
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelScan_Press(object sender, EventArgs e)
        {
            if (Status == InventoryStatus.盘点结束 || Status == InventoryStatus.盘点未开始)
            {
                Toast("盘点未开始或已经结束.");
            }
            else
            {
                barcodeScanner1.GetBarcode();
            }
        }
    }
}