using System;
using SMOSEC.UI.AssetsManager;
using SMOSEC.UI.MasterData;
using SMOSEC.UI.UserInfo;
using Smobiler.Core.Controls;
using SMOSEC.UI.ConsumablesManager;
using SMOSEC.UI.Department;

namespace SMOSEC.UI.Layout
{
    ////ToolboxItem用于控制是否添加自定义控件到工具箱，true添加，false不添加
    //[System.ComponentModel.ToolboxItem(true)]
    partial class LeftMenu : Smobiler.Core.Controls.MobileUserControl
    {
        /// <summary>
        /// 显示固定资产子项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SNAssetsManager_Press(object sender, EventArgs e)
        {
            if (SNAssets.Visible)
            {
                lblSNAssetsManager.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                lblSNAssetsShow.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                imgSNAssets.ResourceID = "zichan1";
                SNAssets.Visible = false;
                SNJieyong.Visible = false;
                SNGuiHuan.Visible = false;
                SNLingYong.Visible = false;
                SNTuiKu.Visible = false;
                SNDiaoBo.Visible = false;
                SNWeiXiu.Visible = false;
                SNBaoFei.Visible = false;
                SNPanDian.Visible = false;
                SNZiChanFenLei.Visible = false;
                SNQuYu.Visible = false;
                SNBuMen.Visible = false;
                lblSNAssetsShow.Text = ">";
            }
            else
            {
                lblSNAssetsManager.ForeColor = System.Drawing.Color.FromArgb(93, 155, 251);
                lblSNAssetsShow.ForeColor = System.Drawing.Color.FromArgb(93, 155, 251);
                imgSNAssets.ResourceID = "zichan2";
                lblConsumables.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                lblConsumablesShow.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                imgCons.ResourceID = "haocai1";
                SNAssets.Visible = true;
                SNJieyong.Visible = true;
                SNGuiHuan.Visible = true;
                SNLingYong.Visible = true;
                SNTuiKu.Visible = true;
                SNWeiXiu.Visible = true;
                SNBaoFei.Visible = true;
                lblSNAssetsShow.Text = "﹀";
                switch (Client.Session["Role"].ToString())
                {
                    case "SMOSECAdmin":
                        SNDiaoBo.Visible = true;
                        SNPanDian.Visible = true;
                        break;
                    case "ADMIN":
                        SNDiaoBo.Visible = true;
                        SNPanDian.Visible = true;
                        SNZiChanFenLei.Visible = true;
                        SNQuYu.Visible = true;
                        SNBuMen.Visible = true;
                        break;
                }
            }
        }

        public string pagename = "";
        /// <summary>
        /// 跳转到资产列表界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SNAssets_Press(object sender, EventArgs e)
        {
            pagename = ((Panel)sender).Name;
             changePage(pagename);
            //frmAssets frm = new frmAssets();
            //Form.Show(frm);
        }
     
        /// <summary>
        /// 跳转到资产借用界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SNJieyong_Press(object sender, EventArgs e)
        {
            pagename = ((Panel)sender).Name;
           changePage(pagename);
            //frmBorrowOrder frm = new frmBorrowOrder();
            //Form.Show(frm);
        }
        /// <summary>
        /// 跳转到资产归还界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SNGuiHuan_Press(object sender, EventArgs e)
        {
           pagename = ((Panel)sender).Name;
            changePage(pagename); 
            //frmReturnOrder frm = new frmReturnOrder();
            //Form.Show(frm);
        }
        /// <summary>
        /// 跳转到资产领用界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SNLingYong_Press(object sender, EventArgs e)
        {
            pagename = ((Panel)sender).Name;
            changePage(pagename);
            //frmCollarOrder frm = new frmCollarOrder();
            //Form.Show(frm);
        }
        /// <summary>
        /// 跳转到资产退库界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SNTuiKu_Press(object sender, EventArgs e)
        {
            pagename = ((Panel)sender).Name;
            changePage(pagename);
            //frmRestoreOrder frm = new frmRestoreOrder();
            //Form.Show(frm);
        }
        /// <summary>
        /// 固定资产调拨界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SNDiaoBo_Press(object sender, EventArgs e)
        {
            pagename = ((Panel)sender).Name;
           
            changePage(pagename);
            //frmTransferRowsSN frm = new frmTransferRowsSN();
            //this.Form.Show(frm);
        }
        /// <summary>
        /// 固定资产报修界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SNWeiXiu_Press(object sender, EventArgs e)
        {
             pagename = ((Panel)sender).Name;
            changePage(pagename);
            //frmRepairRowsSN frm = new frmRepairRowsSN();
            //this.Form.Show(frm);
        }
        /// <summary>
        /// 固定资产报废界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SNBaoFei_Press(object sender, EventArgs e)
        {
            pagename = ((Panel)sender).Name;
            changePage(pagename);
            //frmScrapRowsSN frm = new frmScrapRowsSN();
            //this.Form.Show(frm);
        }
        /// <summary>
        /// 跳转到资产盘点界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SNInventory_Press(object sender, EventArgs e)
        {
        pagename = ((Panel)sender).Name;
            changePage(pagename);
            //frmAssInventory frm = new frmAssInventory();
            //this.Form.Show(frm);
        }
        /// <summary>
        /// 跳转到资产分类界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SNZiChanFenLei_Press(object sender, EventArgs e)
        {
            pagename = ((Panel)sender).Name;
            changePage(pagename);
            //frmAssetsTypeRows frm = new frmAssetsTypeRows();
            //Form.Show(frm);
        }
        /// <summary>
        /// 跳转到区域界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SNQuYu_Press(object sender, EventArgs e)
        {
           pagename = ((Panel)sender).Name;
            changePage(pagename);
            //frmLocationRows frm = new frmLocationRows();
            //Form.Show(frm);
        }
        /// <summary>
        /// 跳转到部门界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SNBuMen_Press(object sender, EventArgs e)
        {
             pagename = ((Panel)sender).Name;
            changePage(pagename);
            //frmDepartment frm = new frmDepartment();
            //Form.Show(frm);
        }
        /// <summary>
        /// 显示耗材管理子项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Assets_Press(object sender, EventArgs e)
        {
            if (DiaoBo.Visible)
            {
                lblConsumables.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                lblConsumablesShow.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                imgCons.ResourceID = "haocai1";
                DiaoBo.Visible = false;
                HaoCai.Visible = false;
                ruku.Visible = false;
                chuku.Visible = false;
                pandian.Visible = false;
                lblConsumablesShow.Text = ">";
            }
            else
            {
                lblConsumables.ForeColor = System.Drawing.Color.FromArgb(93, 155, 251);
                lblConsumablesShow.ForeColor = System.Drawing.Color.FromArgb(93, 155, 251);
                imgCons.ResourceID = "haocai2";
                lblSNAssetsManager.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                lblSNAssetsShow.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                imgSNAssets.ResourceID = "zichan1";
                HaoCai.Visible = true;
                ruku.Visible = true;
                chuku.Visible = true;
                lblConsumablesShow.Text = "﹀";
                if (Client.Session["Role"].ToString() == "SMOSECUser")
                {
                    DiaoBo.Visible = false;
                    pandian.Visible = false;
                }
                else
                {
                    DiaoBo.Visible = true;
                    pandian.Visible = true;
                }

            }
        }
        /// <summary>
        /// 耗材列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HaoCai_Press(object sender, EventArgs e)
        {
            pagename = ((Panel)sender).Name;
            changePage(pagename);
            //frmConsumables frm = new frmConsumables();
            //Form.Show(frm);
        }
        /// <summary>
        /// 入库单列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ruku_Press(object sender, EventArgs e)
        {
            pagename = ((Panel)sender).Name;
            changePage(pagename);
            //frmWarehouseReceipt frm = new frmWarehouseReceipt();
            //Form.Show(frm);
        }
        /// <summary>
        /// 出库单列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chuku_Press(object sender, EventArgs e)
        {
            pagename = ((Panel)sender).Name;
            changePage(pagename);
            //frmOutboundOrder frm = new frmOutboundOrder();
            //Form.Show(frm);
        }
        /// <summary>
        /// 跳转到耗材调拨界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DiaoBo_Press(object sender, EventArgs e)
        {
             pagename = ((Panel)sender).Name;
            changePage(pagename);
            //frmTransferRows frm = new frmTransferRows();
            //Form.Show(frm);
        }
        /// <summary>
        /// 跳转到耗材盘点界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pandian_Press(object sender, EventArgs e)
        {
             pagename = ((Panel)sender).Name;
            changePage(pagename);
            //frmConInventory frm = new frmConInventory();
            //Form.Show(frm);
        }
        /// <summary>
        /// 显示个人信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void plPerson_Press(object sender, EventArgs e)
        {
             pagename = ((Panel)sender).Name;
            changePage(pagename);
            //frmMessage frm = new frmMessage();
            //Form.Show(frm);
        }
        /// <summary>
        /// 注销账号，返回到登录界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void plZhuXiao_Press(object sender, EventArgs e)
        {
            MessageBox.Show("是否注销当前用户？", "系统提醒", MessageBoxButtons.OKCancel, (object sender1, MessageBoxHandlerArgs args) =>
             {
                 try
                 {
                     if (args.Result == ShowResult.OK)
                         Client.ReStart();
                 }
                 catch (Exception ex)
                 {
                     Toast(ex.Message);
                 }
             });
        }

        private void changePage(string page)
        {
            if (this.Form.Name == "frmAssets")
            {
                switch (page)
                {
                    case "SNAssets":
                        this.Form.CloseDrawer();
                        //frmAssets frm = new frmAssets();
                        //Form.Show(frm, (obj,args) => {
                        //    LeftMenu lf = (LeftMenu)frm.Drawer;
                        //    changePage(lf.pagename); });
                        break;
                    case "SNJieyong":
                        frmBorrowOrder frm1 = new frmBorrowOrder();
                        Form.Show(frm1, (obj, args) => {
                            LeftMenu lf = (LeftMenu)frm1.Drawer;
                            changePage(lf.pagename);
                        });
                        break;
                    case "SNGuiHuan":
                        frmReturnOrder frm2 = new frmReturnOrder();
                        Form.Show(frm2, (obj, args) => {
                            LeftMenu lf = (LeftMenu)frm2.Drawer;
                            changePage(lf.pagename);
                        });
                        break;
                    case "SNLingYong":
                        frmCollarOrder frm3 = new frmCollarOrder();
                        Form.Show(frm3, (obj, args) => {
                            LeftMenu lf = (LeftMenu)frm3.Drawer;
                            changePage(lf.pagename);
                        });
                        break;
                    case "SNTuiKu":
                        frmRestoreOrder frm4 = new frmRestoreOrder();
                        Form.Show(frm4, (obj, args) => {
                            LeftMenu lf = (LeftMenu)frm4.Drawer;
                            changePage(lf.pagename);
                        });
                        break;
                    case "SNDiaoBo":
                        frmTransferRowsSN frm5 = new frmTransferRowsSN();
                        Form.Show(frm5, (obj, args) => {
                            LeftMenu lf = (LeftMenu)frm5.Drawer;
                            changePage(lf.pagename);
                        });
                        break;
                    case "SNWeiXiu":
                        frmRepairRowsSN frm6 = new frmRepairRowsSN();
                        Form.Show(frm6, (obj, args) => {
                            LeftMenu lf = (LeftMenu)frm6.Drawer;
                            changePage(lf.pagename);
                        });
                        break;
                    case "SNBaoFei":
                        frmScrapRowsSN frm7 = new frmScrapRowsSN();
                        Form.Show(frm7, (obj, args) => {
                            LeftMenu lf = (LeftMenu)frm7.Drawer;
                            changePage(lf.pagename);
                        });
                        break;
                    case "SNPanDian":
                        frmAssInventory frm8 = new frmAssInventory();
                        Form.Show(frm8, (obj, args) => {
                            LeftMenu lf = (LeftMenu)frm8.Drawer;
                            changePage(lf.pagename);
                        });
                        break;
                    case "SNZiChanFenLei":
                        frmAssetsTypeRows frm9 = new frmAssetsTypeRows();
                        Form.Show(frm9, (obj, args) => {
                            LeftMenu lf = (LeftMenu)frm9.Drawer;
                            changePage(lf.pagename);
                        });
                        break;

                    case "SNQuYu":
                        frmLocationRows frm10 = new frmLocationRows();
                        Form.Show(frm10, (obj, args) => {
                            LeftMenu lf = (LeftMenu)frm10.Drawer;
                            changePage(lf.pagename);
                        });
                        break;
                    case "SNBuMen":
                        frmDepartment frm11 = new frmDepartment();
                        Form.Show(frm11, (obj, args) => {
                            LeftMenu lf = (LeftMenu)frm11.Drawer;
                            changePage(lf.pagename);
                        });
                        break;
                    case "HaoCai":
                        frmConsumables frm12 = new frmConsumables();
                        Form.Show(frm12, (obj, args) => {
                            LeftMenu lf = (LeftMenu)frm12.Drawer;
                            changePage(lf.pagename);
                        });
                        break;
                    case "ruku":
                        frmWarehouseReceipt frm13 = new frmWarehouseReceipt();
                        Form.Show(frm13, (obj, args) => {
                            LeftMenu lf = (LeftMenu)frm13.Drawer;
                            changePage(lf.pagename);
                        });
                        break;
                    case "chuku":
                        frmOutboundOrder frm14 = new frmOutboundOrder();
                        Form.Show(frm14, (obj, args) => {
                            LeftMenu lf = (LeftMenu)frm14.Drawer;
                            changePage(lf.pagename);
                        });
                        break;
                    case "DiaoBo":
                        frmTransferRows frm15 = new frmTransferRows();
                        Form.Show(frm15, (obj, args) => {
                            LeftMenu lf = (LeftMenu)frm15.Drawer;
                            changePage(lf.pagename);
                        });
                        break;
                    case "pandian":
                        frmConInventory frm16 = new frmConInventory();
                        Form.Show(frm16, (obj, args) => {
                            LeftMenu lf = (LeftMenu)frm16.Drawer;
                            changePage(lf.pagename);
                        });
                        break;
                    case "plPerson":
                        frmMessage frm17 = new frmMessage();
                        Form.Show(frm17, (obj, args) => {
                            LeftMenu lf = (LeftMenu)frm17.Drawer;
                            if(lf!=null)changePage(lf.pagename);
                            this.Form.CloseDrawer();
                        });
                        break;
                }
        }
            else
            {
                this.Form.Close();
            }

}
    }
}