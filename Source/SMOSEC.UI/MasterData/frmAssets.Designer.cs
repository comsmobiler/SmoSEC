using System;
using Smobiler.Core;
using SMOSEC.UI.UserControl;

namespace SMOSEC.UI.MasterData
{
    partial class frmAssets : Smobiler.Core.Controls.MobileForm
    {
        #region "SmobilerForm generated code "

        public frmAssets()
            : base()
        {
            //This call is required by the SmobilerForm.
            InitializeComponent();

            //Add any initialization after the InitializeComponent() call
        }

        //SmobilerForm overrides dispose to clean up the component list.
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }


        //NOTE: The following procedure is required by the SmobilerForm
        //It can be modified using the SmobilerForm.  
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            Smobiler.Core.Controls.ActionButtonItem actionButtonItem1 = new Smobiler.Core.Controls.ActionButtonItem();
            Smobiler.Core.Controls.ActionButtonItem actionButtonItem2 = new Smobiler.Core.Controls.ActionButtonItem();
            Smobiler.Core.Controls.ActionButtonItem actionButtonItem3 = new Smobiler.Core.Controls.ActionButtonItem();
            Smobiler.Core.Controls.ActionButtonItem actionButtonItem4 = new Smobiler.Core.Controls.ActionButtonItem();
            Smobiler.Core.Controls.ActionButtonItem actionButtonItem5 = new Smobiler.Core.Controls.ActionButtonItem();
            Smobiler.Core.Controls.ActionButtonItem actionButtonItem6 = new Smobiler.Core.Controls.ActionButtonItem();
            Smobiler.Core.Controls.ActionButtonItem actionButtonItem7 = new Smobiler.Core.Controls.ActionButtonItem();
            this.popCurrentUser = new Smobiler.Core.Controls.PopList();
            this.r2000Scanner1 = new Smobiler.Device.R2000Scanner();
            this.Title1 = new SMOSEC.UI.UserControl.MenuTitle();
            this.panel2 = new Smobiler.Core.Controls.Panel();
            this.fontIcon1 = new Smobiler.Core.Controls.FontIcon();
            this.barcodeScanner1 = new Smobiler.Core.Controls.BarcodeScanner();
            this.fontIcon2 = new Smobiler.Core.Controls.FontIcon();
            this.textBox1 = new Smobiler.Core.Controls.TextBox();
            this.panel3 = new Smobiler.Core.Controls.Panel();
            this.fontIcon3 = new Smobiler.Core.Controls.FontIcon();
            this.txtSnOrName = new Smobiler.Core.Controls.TextBox();
            this.ImgBtnForSN = new Smobiler.Core.Controls.ImageButton();
            this.gridAssRows = new Smobiler.Core.Controls.GridView();
            // 
            // popCurrentUser
            // 
            this.popCurrentUser.Name = "popCurrentUser";
            this.popCurrentUser.Selected += new System.EventHandler(this.popCurrentUser_Selected);
            // 
            // r2000Scanner1
            // 
            this.r2000Scanner1.Name = "r2000Scanner1";
            this.r2000Scanner1.BarcodeDataCaptured += new Smobiler.Device.R2000BarcodeScanEventHandler(this.r2000Scanner1_BarcodeDataCaptured);
            this.r2000Scanner1.RFIDDataCaptured += new Smobiler.Device.R2000RFIDScanEventHandler(this.r2000Scanner1_RFIDDataCaptured);
            // 
            // Title1
            // 
            this.Title1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(164)))), ((int)(((byte)(229)))));
            this.Title1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Title1.FontSize = 15F;
            this.Title1.ForeColor = System.Drawing.Color.Black;
            this.Title1.Name = "Title1";
            this.Title1.Size = new System.Drawing.Size(300, 40);
            this.Title1.TitleText = "资产列表";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.BorderRadius = 8;
            this.panel2.Location = new System.Drawing.Point(70, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(230, 20);
            // 
            // fontIcon1
            // 
            this.fontIcon1.ForeColor = System.Drawing.Color.Silver;
            this.fontIcon1.Location = new System.Drawing.Point(10, 0);
            this.fontIcon1.Name = "fontIcon1";
            this.fontIcon1.ResourceID = "search";
            this.fontIcon1.Size = new System.Drawing.Size(20, 20);
            // 
            // barcodeScanner1
            // 
            this.barcodeScanner1.Name = "barcodeScanner1";
            this.barcodeScanner1.BarcodeScanned += new Smobiler.Core.Controls.BarcodeScannerCallBackHandler(this.barcodeScanner1_BarcodeScanned);
            // 
            // fontIcon2
            // 
            this.fontIcon2.ForeColor = System.Drawing.Color.Silver;
            this.fontIcon2.Location = new System.Drawing.Point(10, 0);
            this.fontIcon2.Name = "fontIcon2";
            this.fontIcon2.ResourceID = "search";
            this.fontIcon2.Size = new System.Drawing.Size(20, 20);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Transparent;
            this.textBox1.Location = new System.Drawing.Point(49, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(170, 20);
            this.textBox1.WaterMarkText = "请输入资产名称或资产条码";
            this.textBox1.WaterMarkTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(181)))), ((int)(((byte)(183)))));
            this.textBox1.TextChanged += new System.EventHandler(this.txtFactor_TextChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel3.BorderRadius = 4;
            this.panel3.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.fontIcon3,
            this.txtSnOrName});
            this.panel3.Location = new System.Drawing.Point(50, 52);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(250, 20);
            // 
            // fontIcon3
            // 
            this.fontIcon3.ForeColor = System.Drawing.Color.Silver;
            this.fontIcon3.Location = new System.Drawing.Point(10, 2);
            this.fontIcon3.Name = "fontIcon3";
            this.fontIcon3.ResourceID = "search";
            this.fontIcon3.Size = new System.Drawing.Size(16, 16);
            // 
            // txtSnOrName
            // 
            this.txtSnOrName.BackColor = System.Drawing.Color.Transparent;
            this.txtSnOrName.Location = new System.Drawing.Point(40, 0);
            this.txtSnOrName.Name = "txtSnOrName";
            this.txtSnOrName.Size = new System.Drawing.Size(200, 20);
            this.txtSnOrName.WaterMarkText = "请输入资产名称或资产条码";
            this.txtSnOrName.WaterMarkTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(181)))), ((int)(((byte)(183)))));
            this.txtSnOrName.TextChanged += new System.EventHandler(this.txtFactor_TextChanged);
            // 
            // ImgBtnForSN
            // 
            this.ImgBtnForSN.BackColor = System.Drawing.Color.White;
            this.ImgBtnForSN.Location = new System.Drawing.Point(15, 48);
            this.ImgBtnForSN.Name = "ImgBtnForSN";
            this.ImgBtnForSN.ResourceID = "scan";
            this.ImgBtnForSN.Size = new System.Drawing.Size(28, 28);
            this.ImgBtnForSN.Press += new System.EventHandler(this.ImgBtnForAssId_Press);
            // 
            // gridAssRows
            // 
            this.gridAssRows.BackColor = System.Drawing.Color.White;
            this.gridAssRows.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.gridAssRows.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.gridAssRows.Location = new System.Drawing.Point(0, 85);
            this.gridAssRows.Name = "gridAssRows";
            this.gridAssRows.PageSizeTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.gridAssRows.PageSizeTextSize = 11F;
            this.gridAssRows.Size = new System.Drawing.Size(300, 425);
            this.gridAssRows.TemplateControlName = "frmAssetsExLayout";
            // 
            // frmAssets
            // 
            this.ActionButton.ButtonSpacing = 12;
            this.ActionButton.Enabled = true;
            actionButtonItem1.ImageType = Smobiler.Core.Controls.ActionButtonImageType.Text;
            actionButtonItem1.Text = "资产新增";
            actionButtonItem2.ImageType = Smobiler.Core.Controls.ActionButtonImageType.Text;
            actionButtonItem2.ResourceID = "";
            actionButtonItem2.Text = "资产复制";
            actionButtonItem3.ImageType = Smobiler.Core.Controls.ActionButtonImageType.Text;
            actionButtonItem3.Text = "资产领用";
            actionButtonItem4.ImageType = Smobiler.Core.Controls.ActionButtonImageType.Text;
            actionButtonItem4.Text = "资产借用";
            actionButtonItem5.ImageType = Smobiler.Core.Controls.ActionButtonImageType.Text;
            actionButtonItem5.Text = "维修登记";
            actionButtonItem6.ImageType = Smobiler.Core.Controls.ActionButtonImageType.Text;
            actionButtonItem6.Text = "资产报废";
            actionButtonItem7.ImageType = Smobiler.Core.Controls.ActionButtonImageType.Text;
            actionButtonItem7.Text = "资产调拨";
            this.ActionButton.Items.AddRange(new Smobiler.Core.Controls.ActionButtonItem[] {
            actionButtonItem1,
            actionButtonItem2,
            actionButtonItem3,
            actionButtonItem4,
            actionButtonItem5,
            actionButtonItem6,
            actionButtonItem7});
            this.ActionButton.ItemSize = 45;
            this.BackColor = System.Drawing.Color.White;
            this.Components.AddRange(new Smobiler.Core.Controls.MobileComponent[] {
            this.popCurrentUser,
            this.r2000Scanner1,
            this.barcodeScanner1});
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.Title1,
            this.panel3,
            this.ImgBtnForSN,
            this.gridAssRows});
            this.DrawerName = "LeftMenu";
            this.Orientation = Smobiler.Core.Controls.FormOrientation.Portrait;
            this.Statusbar = new Smobiler.Core.Controls.MobileFormStatusbar(Smobiler.Core.Controls.MobileFormStatusbarStyle.Default, System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(164)))), ((int)(((byte)(229))))));
            this.KeyDown += new Smobiler.Core.Controls.KeyDownEventHandler(this.frmAssets_KeyDown);
            this.ActionButtonPress += new Smobiler.Core.Controls.ActionButtonPressEventHandler(this.frmAssets_ActionButtonPress);
            this.Load += new System.EventHandler(this.frmAssets_Load);
            this.Name = "frmAssets";

        }
        #endregion

        private MenuTitle Title1;
        internal Smobiler.Core.Controls.PopList popCurrentUser;
        private Smobiler.Device.R2000Scanner r2000Scanner1;
        private Smobiler.Core.Controls.BarcodeScanner barcodeScanner1;
        private Smobiler.Core.Controls.Panel panel2;
        private Smobiler.Core.Controls.FontIcon fontIcon1;
        private Smobiler.Core.Controls.FontIcon fontIcon2;
        private Smobiler.Core.Controls.TextBox textBox1;
        private Smobiler.Core.Controls.Panel panel3;
        private Smobiler.Core.Controls.FontIcon fontIcon3;
        private Smobiler.Core.Controls.TextBox txtSnOrName;
        private Smobiler.Core.Controls.ImageButton ImgBtnForSN;
        internal Smobiler.Core.Controls.GridView gridAssRows;
    }
}