using System;
using System.Collections.Generic;
using System.Data;
using Smobiler.Core.Controls;
using SMOSEC.CommLib;
using SMOSEC.Domain.Entity;
using SMOSEC.DTOs.InputDTO;

namespace SMOSEC.UI.AssetsManager
{
    partial class frmRtoCreate : Smobiler.Core.Controls.MobileForm
    {
        #region 变量
        private AutofacConfig _autofacConfig = new AutofacConfig();//调用配置类

        public List<string> AssIdList = new List<string>();

        public DataTable AssTable = new DataTable();
        public string LocationId;
        public string RtoManId;
        public string HManId;
        private string UserId;
        

        #endregion

        /// <summary>
        /// 添加归还单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Press(object sender, EventArgs e)
        {
            try
            {
                AssReturnOrderInputDto assReturnOrderInput = new AssReturnOrderInputDto()
                {
                    AssIds = AssIdList,
                    RETURNDATE = DPickerCO.Value,
                    RETURNER = RtoManId,
                    HANDLEMAN = HManId,
                    CREATEUSER = UserId,
                    LOCATIONID = LocationId,
                    MODIFYUSER = UserId,
                    NOTE = txtNote.Text
                };
                ReturnInfo returnInfo = _autofacConfig.AssetsService.AddAssReturnOrder(assReturnOrderInput);
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
        /// 选择归还人
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBOMan_Press(object sender, EventArgs e)
        {
            try
            {
                PopRTMan.Groups.Clear();
                PopListGroup manGroup = new PopListGroup();
                PopRTMan.Title = "归还人选择";
                List<coreUser> users = _autofacConfig.coreUserService.GetAll();
                foreach (coreUser Row in users)
                {
                    manGroup.AddListItem(Row.USER_NAME, Row.USER_ID);
                }
                PopRTMan.Groups.Add(manGroup);
                if (btnBOMan.Tag != null)   //如果已有选中项，则显示选中效果
                {
                    foreach (PopListItem Item in manGroup.Items)
                    {
                        if (Item.Value == btnBOMan.Tag.ToString())
                            PopRTMan.SetSelections(Item);
                    }
                }
                PopRTMan.ShowDialog();

            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        /// <summary>
        /// 手机扫描二维码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImgBtnForBarcode_Press(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtLocation.Text))
                {
                    throw new Exception("请先选择区域");
                }
                else
                {
                     barcodeScanner1.GetBarcode();
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }


        /// <summary>
        /// 归还人选中后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PopRTMan_Selected(object sender, EventArgs e)
        {
            try
            {
                if (PopRTMan.Selection != null)
                {
                    btnBOMan.Text = PopRTMan.Selection.Text;
                    if (RtoManId != null && RtoManId != PopRTMan.Selection.Value)
                    {
                        ClearInfo();
                    }
                    RtoManId = PopRTMan.Selection.Value;
                    coreUser user = _autofacConfig.coreUserService.GetUserByID(RtoManId);
                    LocationId = user.USER_LOCATIONID;

                    AssLocation location = _autofacConfig.assLocationService.GetByID(LocationId);
                    if (location != null)
                    {
                        txtLocation.Text = location.NAME;
                        coreUser manager = _autofacConfig.coreUserService.GetUserByID(location.MANAGER);
                        HManId = location.MANAGER;
                        if (manager != null) txtHMan.Text = manager.USER_NAME;
                    }
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        /// <summary>
        /// 按回退键时关闭当前窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmRtoCreate_KeyDown(object sender, KeyDownEventArgs e)
        {
            if (e.KeyCode == KeyCode.Back)
                Close();
        }

        /// <summary>
        /// 界面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmRtoCreate_Load(object sender, EventArgs e)
        {
            try
            {
                if (AssTable.Columns.Count == 0)
                {
                    AssTable.Columns.Add("IMAGE");
                    AssTable.Columns.Add("ASSID");
                    AssTable.Columns.Add("NAME");
                    AssTable.Columns.Add("TYPE");
                    AssTable.Columns.Add("SN");
                }
                DataColumn[] keys = new DataColumn[1];
                keys[0] = AssTable.Columns["ASSID"];
                AssTable.PrimaryKey = keys;

                UserId = Client.Session["UserID"].ToString();
                UserId = Session["UserID"].ToString();
                if (Client.Session["Role"].ToString() == "SMOSECUser")
                {
                    RtoManId = UserId;
                    var user = _autofacConfig.coreUserService.GetUserByID(UserId);
                    btnBOMan.Text = user.USER_NAME;
                    btnBOMan.Enabled = false;
                    btnBOMan1.Enabled = false;
                    LocationId = user.USER_LOCATIONID;

                    AssLocation location = _autofacConfig.assLocationService.GetByID(LocationId);
                    if (location != null)
                    {
                        txtLocation.Text = location.NAME;
                        coreUser manager = _autofacConfig.coreUserService.GetUserByID(location.MANAGER);
                        HManId = location.MANAGER;
                        if (manager != null) txtHMan.Text = manager.USER_NAME;
                    }
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        /// <summary>
        /// 行项数据绑定
        /// </summary>
        public void BindListView()
        {
            try
            {
                ListAss.DataSource = AssTable;
                ListAss.DataBind();
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }

        }

        /// <summary>
        /// 清空行项和相关数据
        /// </summary>
        private void ClearInfo()
        {
            AssTable.Rows.Clear();
            AssIdList.Clear();
            BindListView();
        }

        /// <summary>
        /// 添加行项和相关数据
        /// </summary>
        /// <param name="assId">资产编号</param>
        /// <param name="sn">序列号</param>
        /// <param name="image">图片</param>
        /// <param name="name">名称</param>
        public void AddAss(string assId, string sn, string image, string name)
        {
            try
            {
                if (AssIdList.Contains(assId))
                {

                }
                else
                {
                    DataRow row = AssTable.NewRow();
                    row["ASSID"] = assId;
                    row["SN"] = sn;
                    row["IMAGE"] = image;
                    row["NAME"] = name;
                    row["TYPE"] = "BO";
                    AssTable.Rows.Add(row);
                    AssIdList.Add(assId);
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }

        }

        /// <summary>
        /// 移除行项和相关数据
        /// </summary>
        /// <param name="assId">资产编号</param>
        public void RemoveAss(string assId)
        {
            try
            {
                DataRow row = AssTable.Rows.Find(assId);
                AssTable.Rows.Remove(row);
                AssIdList.Remove(assId);
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        /// <summary>
        /// 手持物理按键扫描到二维码数据时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void r2000Scanner1_BarcodeDataCaptured(object sender, Smobiler.Device.R2000BarcodeScanEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(RtoManId))
                {
                    throw new Exception("请先选择归还人");
                }
                else
                {
                    string barCode = e.Data;
                    DataTable info = _autofacConfig.SettingService.GetBorrowedAssEx(LocationId, barCode, RtoManId);
                    if (info.Rows.Count == 0)
                    {
                        throw new Exception("未在该用户的借用物品中找到该物品");
                    }
                    else
                    {
                        DataRow row = info.Rows[0];
                        AddAss(row["ASSID"].ToString(), barCode, row["IMAGE"].ToString(), row["NAME"].ToString());
                        BindListView();
                    }
                }

            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        /// <summary>
        /// 手持物理按键扫描到RFID数据时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void r2000Scanner1_RFIDDataCaptured(object sender, Smobiler.Device.R2000RFIDScanEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(RtoManId))
                {
                    throw new Exception();
                }
                else
                {
                    string RFID = e.Epc;
                    DataTable info = _autofacConfig.SettingService.GetBorrowedAssEx(LocationId, RFID, RtoManId);
                    if (info.Rows.Count == 0)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        DataRow row = info.Rows[0];
                        AddAss(row["ASSID"].ToString(), RFID, row["IMAGE"].ToString(), row["NAME"].ToString());
                        BindListView();
                    }
                }

            }
            catch (Exception ex)
            {
                if (ex.Message != "引发类型为“System.Exception”的异常。")
                {
                    Toast(ex.Message);
                }
            }
        }

        /// <summary>
        /// 手机扫描到二维码数据时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barcodeScanner1_BarcodeScanned_1(object sender, BarcodeResultArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(RtoManId))
                {
                    throw new Exception("请先选择归还人");
                }
                else
                {
                    string barCode = e.Value;
                    DataTable info = _autofacConfig.SettingService.GetBorrowedAssEx(LocationId, barCode, RtoManId);
                    if (info.Rows.Count == 0)
                    {
                        throw new Exception("未在该用户的借用物品中找到该物品");
                    }
                    else
                    {
                        DataRow row = info.Rows[0];
                        AddAss(row["ASSID"].ToString(), barCode, row["IMAGE"].ToString(), row["NAME"].ToString());
                        BindListView();
                    }
                }

            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        /// <summary>
        /// 点击“扫描添加”时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelScan_Press(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtLocation.Text))
                {
                    throw new Exception("请先选择区域");
                }
                else
                {
                    barcodeScanner1.GetBarcode();
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }
    }
}