using System;
using System.Data;
using Smobiler.Core.Controls;
using SMOSEC.UI.AssetsManager;
using Smobiler.Device;
using SMOSEC.DTOs.OutputDTO;
using System.Collections.Generic;
using SMOSEC.Domain.Entity;

namespace SMOSEC.UI.MasterData
{

    /// <summary>
    /// 资产列表界面
    /// </summary>
    partial class frmAssets : Smobiler.Core.Controls.MobileForm
    {
        #region 变量
        private AutofacConfig _autofacConfig = new AutofacConfig();//调用配置类

        public string SelectAssId;  //当前选择的资产

        private string UserId;
        private string LocatinId;

        #endregion
        /// <summary>
        /// 按回退键，关闭客户端
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAssets_KeyDown(object sender, KeyDownEventArgs e)
        {
            if (e.KeyCode == KeyCode.Back)
                Client.Exit();
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        public void Bind()
        {
            try
            {
                LocatinId = "";
                if (Client.Session["Role"].ToString() != "ADMIN")
                {
                    var user = _autofacConfig.coreUserService.GetUserByID(UserId);
                    LocatinId = user.USER_LOCATIONID;
                }

                DataTable table = _autofacConfig.SettingService.GetAllAss(LocatinId);
                gridAssRows.Cells.Clear();
                table.Columns.Add("IsChecked");
                foreach (DataRow Row in table.Rows)
                {
                    if (Row["AssId"].ToString() == SelectAssId)
                    {
                        Row["IsChecked"] = true;
                    }
                    else
                    {
                        Row["IsChecked"] = false;
                    }
                }
                if (table.Rows.Count > 0)
                {
                    gridAssRows.DataSource = table;
                    gridAssRows.DataBind();
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        /// <summary>
        /// 界面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAssets_Load(object sender, EventArgs e)
        {
            try
            {
                UserId = Client.Session["UserID"].ToString();
                Bind();
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }

        }

        /// <summary>
        /// 手持物理按键扫二维码，扫描到数据时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void r2000Scanner1_BarcodeDataCaptured(object sender, Smobiler.Device.R2000BarcodeScanEventArgs e)
        {
            try
            {
                string barCode = e.Data;
                DataTable table = _autofacConfig.SettingService.GetAssetsBySN(barCode, LocatinId);
                gridAssRows.Cells.Clear();
                table.Columns.Add("IsChecked");
                foreach (DataRow Row in table.Rows)
                {
                    if (Row["AssId"].ToString() == SelectAssId)
                    {
                        Row["IsChecked"] = true;
                    }
                    else
                    {
                        Row["IsChecked"] = false;
                    }
                }
                if (table.Rows.Count > 0)
                {
                    gridAssRows.DataSource = table;
                    gridAssRows.DataBind();
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }

        }

        /// <summary>
        /// 手持物理按键扫描RFID，扫描到RFID信息时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void r2000Scanner1_RFIDDataCaptured(object sender, Smobiler.Device.R2000RFIDScanEventArgs e)
        {
            try
            {
                string RFID = e.Epc;
                DataTable table = _autofacConfig.SettingService.GetAssetsBySN(RFID, LocatinId);
                gridAssRows.Cells.Clear();
                table.Columns.Add("IsChecked");
                foreach (DataRow Row in table.Rows)
                {
                    if (Row["AssId"].ToString() == SelectAssId)
                    {
                        Row["IsChecked"] = true;
                    }
                    else
                    {
                        Row["IsChecked"] = false;
                    }
                }
                if (table.Rows.Count > 0)
                {
                    gridAssRows.DataSource = table;
                    gridAssRows.DataBind();
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        /// <summary>
        /// 点击ActionButton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAssets_ActionButtonPress(object sender, ActionButtonPressEventArgs e)
        {

            try
            {
                switch (e.Index)
                {
                    case 0:     //资产新增
                        try
                        {
                            if (Client.Session["Role"].ToString() == "SMOSECUser") throw new Exception("当前用户没有权限添加资产!");
                            frmAssetsCreate assetsCreate = new frmAssetsCreate();
                            Show(assetsCreate, (MobileForm sender1, object args) =>
                            {
                                if (assetsCreate.ShowResult == ShowResult.Yes)
                                {
                                    Bind();
                                }

                            });
                        }
                        catch (Exception ex)
                        {
                            Toast(ex.Message);
                        }
                        break;
                    case 1:
                        //资产复制
                        try
                        {
                            if (Client.Session["Role"].ToString() == "SMOSECUser") throw new Exception("当前用户没有权限添加资产!");
                            if (string.IsNullOrEmpty(SelectAssId))
                            {
                                throw new Exception("请先选择资产.");
                            }
                            var assets = _autofacConfig.SettingService.GetAssetsByID(SelectAssId);

                            frmAssetsCreate assetsCreate = new frmAssetsCreate
                            {
                                DatePickerBuy = { Value = assets.BuyDate },
                                DepId = assets.DepartmentId,
                                btnDep = { Text = assets.DepartmentName + "   > " },
                                DatePickerExpiry = { Value = assets.ExpiryDate },
                                ImgPicture = { ResourceID = assets.Image },
                                LocationId = assets.LocationId,
                                btnLocation = { Text = assets.LocationName },
                                ManagerId = assets.Manager,
                                txtManager = { Text = assets.ManagerName },
                                txtName = { Text = assets.Name },
                                txtNote = { Text = assets.Note },
                                txtPlace = { Text = assets.Place },
                                txtPrice = { Text = assets.Price.ToString() },
                                txtSpe = { Text = assets.Specification },
                                btnType = { Tag = assets.TypeId, Text = assets.TypeName },
                                txtUnit = { Text = assets.Unit },
                                txtVendor = { Text = assets.Vendor }
                            };

                            Show(assetsCreate, (MobileForm sender1, object args) =>
                            {
                                if (assetsCreate.ShowResult == ShowResult.Yes)
                                {
                                    Bind();
                                }

                            });
                        }
                        catch (Exception ex)
                        {
                            Toast(ex.Message);
                        }
                        break;
                    case 2:
                        //资产领用
                        frmCollarOrder frmCO = new frmCollarOrder();
                        Form.Show(frmCO);
                        break;
                    case 3:
                        //资产借用
                        frmBorrowOrder frmBO = new frmBorrowOrder();
                        Form.Show(frmBO);
                        break;
                    case 4:
                        //维修登记
                        frmRepairRowsSN frmR = new frmRepairRowsSN();
                        this.Form.Show(frmR);
                        break;
                    case 5:
                        //报废
                        frmScrapRowsSN frmS = new frmScrapRowsSN();
                        this.Form.Show(frmS);
                        break;
                    case 6:
                        //调拨
                        frmTransferRowsSN frmT = new frmTransferRowsSN();
                        this.Form.Show(frmT);
                        break;
                    case 7:
                        try
                        {
                            if (string.IsNullOrEmpty(SelectAssId))
                            {
                                throw new Exception("请先选择资产.");
                            }
                            AssetsOutputDto outputDto = _autofacConfig.SettingService.GetAssetsByID(SelectAssId);
                            PosPrinterEntityCollection Commands = new PosPrinterEntityCollection();
                            Commands.Add(new PosPrinterProtocolEntity(PosPrinterProtocol.Initial));
                            Commands.Add(new PosPrinterProtocolEntity(PosPrinterProtocol.EnabledBarcode));
                            Commands.Add(new PosPrinterProtocolEntity(PosPrinterProtocol.AbsoluteLocation));
                            Commands.Add(new PosPrinterBarcodeEntity(PosBarcodeType.CODE128Height, "62"));
                            Commands.Add(new PosPrinterBarcodeEntity(PosBarcodeType.CODE128, outputDto.SN));
                            //Commands.Add(new PosPrinterBarcodeEntity(PosBarcodeType.CODE128, "E2000017320082231027BD"));
                            Commands.Add(new PosPrinterProtocolEntity(PosPrinterProtocol.DisabledBarcode));
                            Commands.Add(new PosPrinterContentEntity(System.Environment.NewLine));
                            Commands.Add(new PosPrinterProtocolEntity(PosPrinterProtocol.Cut));

                            posPrinter1.Print(Commands, (obj, args) =>
                            {
                                if (args.isError == true)
                                    this.Toast("Error: " + args.error);
                                else
                                    this.Toast("打印成功");
                            });
                        }
                        catch (Exception ex)
                        {
                            Toast(ex.Message);
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
        /// 手机二维码扫描到二维码信息时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barcodeScanner1_BarcodeScanned(object sender, BarcodeResultArgs e)
        {
            try
            {
                string barCode = e.Value;
                DataTable table = _autofacConfig.SettingService.GetAssetsBySN(barCode, LocatinId);
                gridAssRows.Cells.Clear();
                table.Columns.Add("IsChecked");
                foreach (DataRow Row in table.Rows)
                {
                    if (Row["AssId"].ToString() == SelectAssId)
                    {
                        Row["IsChecked"] = true;
                    }
                    else
                    {
                        Row["IsChecked"] = false;
                    }
                }
                if (table.Rows.Count > 0)
                {
                    gridAssRows.DataSource = table;
                    gridAssRows.DataBind();
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }
        /// <summary>
        /// 按照SN或者名称模糊匹配查询资产
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFactor_TextChanged(object sender, EventArgs e)
        {
            SearchData();
        }
        /// <summary>
        /// 手机扫描二维码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imageButton1_Press(object sender, EventArgs e)
        {
            try
            {
                barcodeScanner1.GetBarcode();
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }
        /// <summary>
        /// 部门选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDep_Press(object sender, EventArgs e)
        {
            try
            {
                popDep.Groups.Clear();       //数据清空
                PopListGroup poli = new PopListGroup();
                popDep.Groups.Add(poli);
                poli.AddListItem("全部", null);
                List<DepartmentDto> deps = _autofacConfig.DepartmentService.GetAllDepartment();
                foreach (DepartmentDto Row in deps)
                {
                    poli.AddListItem(Row.NAME, Row.DEPARTMENTID);
                }
                if (btnDep.Tag != null)   //如果已有选中项，则显示选中效果
                {
                    foreach (PopListItem Item in poli.Items)
                    {
                        if (Item.Value == btnDep.Tag.ToString())
                            popDep.SetSelections(Item);
                    }
                }
                popDep.ShowDialog();
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }
        /// <summary>
        /// 选择了部门
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void popDep_Selected(object sender, EventArgs e)
        {
            setBtnTag(popDep, btnDep);
        }
        /// <summary>
        /// 资产状态选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStatus_Press(object sender, EventArgs e)
        {
            popStatus.ShowDialog();
        }
        /// <summary>
        /// 选择了状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void popStatus_Selected(object sender, EventArgs e)
        {
            setBtnTag(popStatus, btnStatus);
        }
        /// <summary>
        /// 资产类别选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnType_Press(object sender, EventArgs e)
        {
            try
            {
                popType.Groups.Clear();       //数据清空
                PopListGroup poli = new PopListGroup();
                popType.Groups.Add(poli);
                poli.AddListItem("全部", null);
                List<AssetsType> types = _autofacConfig.assTypeService.GetAllFirstLevel();
                foreach (AssetsType Row in types)
                {
                    poli.AddListItem(Row.NAME, Row.TYPEID);
                }
                if (btnType.Tag != null)   //如果已有选中项，则显示选中效果
                {
                    foreach (PopListItem Item in poli.Items)
                    {
                        if (Item.Value == btnType.Tag.ToString())
                            popType.SetSelections(Item);
                    }
                }
                popType.ShowDialog();
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }
        /// <summary>
        /// 选择了资产大类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void popType_Selected(object sender, EventArgs e)
        {
            setBtnTag(popType, btnType);
        }
        /// <summary>
        /// 选择了部门/资产状态/资产大类
        /// </summary>
        /// <param name="popList"></param>
        /// <param name="button"></param>
        public void setBtnTag(PopList popList, Button button)
        {
            if (String.IsNullOrEmpty(popList.Selection.Text) == false)
            {
                if (button.Tag == null)
                {
                    button.Tag = popList.Selection.Value;         //选择大类编号
                    SearchData();
                }
                else if (popList.Selection.Value != button.Tag.ToString())
                {
                    button.Tag = popList.Selection.Value;         //选择大类编号
                    SearchData();
                }
            }
        }
        /// <summary>
        /// 数据绑定
        /// </summary>
        public void SearchData()
        {
            try
            {
                String DepId = btnDep.Tag == null ? null : btnDep.Tag.ToString();     //选择部门编号
                String Status = btnStatus.Tag == null ? null : btnStatus.Tag.ToString();   //选择资产状态
                String Type = btnType.Tag == null ? null : btnType.Tag.ToString();
                DataTable table = _autofacConfig.SettingService.QueryAssets(txtNote.Text, LocatinId, DepId, Status, Type);
                gridAssRows.Cells.Clear();
                table.Columns.Add("IsChecked");
                foreach (DataRow Row in table.Rows)
                {
                    if (Row["AssId"].ToString() == SelectAssId)
                    {
                        Row["IsChecked"] = true;
                    }
                    else
                    {
                        Row["IsChecked"] = false;
                    }
                }
                if (table.Rows.Count > 0)
                {
                    gridAssRows.DataSource = table;
                    gridAssRows.DataBind();
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }
    }
}