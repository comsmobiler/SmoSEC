using System;
using Smobiler.Core;
using SMOSEC.UI.UserControl;

namespace SMOSEC.UI.AssetsManager
{
    partial class frmRtoCreate : Smobiler.Core.Controls.MobileForm
    {
        #region "SmobilerForm generated code "

        public frmRtoCreate()
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
            this.Title1 = new SMOSEC.UI.UserControl.Title();
            this.Panel2 = new Smobiler.Core.Controls.Panel();
            this.btnConfirm = new Smobiler.Core.Controls.Button();
            this.Panel1 = new Smobiler.Core.Controls.Panel();
            this.Panel3 = new Smobiler.Core.Controls.Panel();
            this.Label1 = new Smobiler.Core.Controls.Label();
            this.Label2 = new Smobiler.Core.Controls.Label();
            this.Label7 = new Smobiler.Core.Controls.Label();
            this.Label8 = new Smobiler.Core.Controls.Label();
            this.txtNote = new Smobiler.Core.Controls.TextBox();
            this.DPickerCO = new Smobiler.Core.Controls.DatePicker();
            this.btnBOMan = new Smobiler.Core.Controls.Button();
            this.Label4 = new Smobiler.Core.Controls.Label();
            this.btnBOMan1 = new Smobiler.Core.Controls.Button();
            this.ImgBtnForBarcode = new Smobiler.Core.Controls.ImageButton();
            this.txtHMan = new Smobiler.Core.Controls.TextBox();
            this.txtLocation = new Smobiler.Core.Controls.TextBox();
            this.ListAss = new Smobiler.Core.Controls.ListView();
            this.PopRTMan = new Smobiler.Core.Controls.PopList();
            this.PopHMan = new Smobiler.Core.Controls.PopList();
            this.PopLocation = new Smobiler.Core.Controls.PopList();
            this.r2000Scanner1 = new Smobiler.Device.R2000Scanner();
            this.barcodeScanner1 = new Smobiler.Core.Controls.BarcodeScanner();
            // 
            // Title1
            // 
            this.Title1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(164)))), ((int)(((byte)(229)))));
            this.Title1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Title1.FontSize = 15F;
            this.Title1.ForeColor = System.Drawing.Color.White;
            this.Title1.Name = "Title1";
            this.Title1.Size = new System.Drawing.Size(300, 40);
            this.Title1.TitleText = "归还单创建";
            // 
            // Panel2
            // 
            this.Panel2.BackColor = System.Drawing.Color.White;
            this.Panel2.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.Panel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Panel2.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.btnConfirm});
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel2.Location = new System.Drawing.Point(0, 468);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(300, 40);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(52, 4);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(186, 30);
            this.btnConfirm.Text = "确定";
            this.btnConfirm.Press += new System.EventHandler(this.btnConfirm_Press);
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.White;
            this.Panel1.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.Panel3,
            this.ListAss});
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1.Location = new System.Drawing.Point(0, 62);
            this.Panel1.Name = "Panel1";
            this.Panel1.Scrollable = true;
            this.Panel1.Size = new System.Drawing.Size(300, 244);
            // 
            // Panel3
            // 
            this.Panel3.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.Label1,
            this.Label2,
            this.Label7,
            this.Label8,
            this.txtNote,
            this.DPickerCO,
            this.btnBOMan,
            this.Label4,
            this.btnBOMan1,
            this.ImgBtnForBarcode,
            this.txtHMan,
            this.txtLocation});
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(300, 191);
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.Color.White;
            this.Label1.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.Label1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Label1.Name = "Label1";
            this.Label1.Padding = new Smobiler.Core.Controls.Padding(5F, 0F, 0F, 0F);
            this.Label1.Size = new System.Drawing.Size(100, 30);
            this.Label1.Text = "归还人";
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.Color.White;
            this.Label2.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.Label2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Label2.Location = new System.Drawing.Point(0, 30);
            this.Label2.Name = "Label2";
            this.Label2.Padding = new Smobiler.Core.Controls.Padding(5F, 0F, 0F, 0F);
            this.Label2.Size = new System.Drawing.Size(100, 30);
            this.Label2.Text = "归还日期";
            // 
            // Label7
            // 
            this.Label7.BackColor = System.Drawing.Color.White;
            this.Label7.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.Label7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Label7.Location = new System.Drawing.Point(0, 60);
            this.Label7.Name = "Label7";
            this.Label7.Padding = new Smobiler.Core.Controls.Padding(5F, 0F, 0F, 0F);
            this.Label7.Size = new System.Drawing.Size(100, 30);
            this.Label7.Text = "归还处理人";
            // 
            // Label8
            // 
            this.Label8.BackColor = System.Drawing.Color.White;
            this.Label8.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 1F);
            this.Label8.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Label8.Location = new System.Drawing.Point(0, 120);
            this.Label8.Name = "Label8";
            this.Label8.Padding = new Smobiler.Core.Controls.Padding(5F, 0F, 0F, 0F);
            this.Label8.Size = new System.Drawing.Size(100, 30);
            this.Label8.Text = "备注";
            // 
            // txtNote
            // 
            this.txtNote.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 1F);
            this.txtNote.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.txtNote.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.txtNote.Location = new System.Drawing.Point(100, 120);
            this.txtNote.Name = "txtNote";
            this.txtNote.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 5F, 0F);
            this.txtNote.Size = new System.Drawing.Size(200, 30);
            this.txtNote.WaterMarkText = "(选填)";
            // 
            // DPickerCO
            // 
            this.DPickerCO.BackColor = System.Drawing.Color.White;
            this.DPickerCO.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.DPickerCO.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.DPickerCO.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.DPickerCO.Location = new System.Drawing.Point(100, 30);
            this.DPickerCO.Name = "DPickerCO";
            this.DPickerCO.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 5F, 0F);
            this.DPickerCO.Size = new System.Drawing.Size(200, 30);
            // 
            // btnBOMan
            // 
            this.btnBOMan.BackColor = System.Drawing.Color.White;
            this.btnBOMan.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.btnBOMan.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnBOMan.BorderRadius = 0;
            this.btnBOMan.ForeColor = System.Drawing.Color.Black;
            this.btnBOMan.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.btnBOMan.Location = new System.Drawing.Point(100, 0);
            this.btnBOMan.Name = "btnBOMan";
            this.btnBOMan.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 2F, 0F);
            this.btnBOMan.Size = new System.Drawing.Size(166, 30);
            this.btnBOMan.Press += new System.EventHandler(this.btnBOMan_Press);
            // 
            // Label4
            // 
            this.Label4.BackColor = System.Drawing.Color.White;
            this.Label4.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.Label4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Label4.Location = new System.Drawing.Point(0, 90);
            this.Label4.Name = "Label4";
            this.Label4.Padding = new Smobiler.Core.Controls.Padding(5F, 0F, 0F, 0F);
            this.Label4.Size = new System.Drawing.Size(100, 30);
            this.Label4.Text = "归还到区域";
            // 
            // btnBOMan1
            // 
            this.btnBOMan1.BackColor = System.Drawing.Color.White;
            this.btnBOMan1.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.btnBOMan1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnBOMan1.BorderRadius = 0;
            this.btnBOMan1.ForeColor = System.Drawing.Color.Black;
            this.btnBOMan1.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.btnBOMan1.Location = new System.Drawing.Point(266, 0);
            this.btnBOMan1.Name = "btnBOMan1";
            this.btnBOMan1.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 5F, 0F);
            this.btnBOMan1.Size = new System.Drawing.Size(34, 30);
            this.btnBOMan1.Text = ">";
            this.btnBOMan1.Press += new System.EventHandler(this.btnBOMan_Press);
            // 
            // ImgBtnForBarcode
            // 
            this.ImgBtnForBarcode.DataMember = null;
            this.ImgBtnForBarcode.DisplayFormat = null;
            this.ImgBtnForBarcode.DisplayMember = null;
            this.ImgBtnForBarcode.ImageDirection = Smobiler.Core.Controls.Direction.Left;
            this.ImgBtnForBarcode.Location = new System.Drawing.Point(10, 155);
            this.ImgBtnForBarcode.Name = "ImgBtnForBarcode";
            this.ImgBtnForBarcode.ResourceID = "BarcodeScanner";
            this.ImgBtnForBarcode.Size = new System.Drawing.Size(151, 30);
            this.ImgBtnForBarcode.Text = "扫码添加";
            this.ImgBtnForBarcode.Press += new System.EventHandler(this.ImgBtnForBarcode_Press);
            // 
            // txtHMan
            // 
            this.txtHMan.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.txtHMan.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.txtHMan.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.txtHMan.Location = new System.Drawing.Point(100, 60);
            this.txtHMan.Name = "txtHMan";
            this.txtHMan.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 5F, 0F);
            this.txtHMan.ReadOnly = true;
            this.txtHMan.Size = new System.Drawing.Size(200, 30);
            // 
            // txtLocation
            // 
            this.txtLocation.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.txtLocation.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.txtLocation.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.txtLocation.Location = new System.Drawing.Point(100, 90);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 5F, 0F);
            this.txtLocation.ReadOnly = true;
            this.txtLocation.Size = new System.Drawing.Size(200, 30);
            // 
            // ListAss
            // 
            this.ListAss.BackColor = System.Drawing.Color.White;
            this.ListAss.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.ListAss.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.ListAss.Location = new System.Drawing.Point(0, 191);
            this.ListAss.Name = "ListAss";
            this.ListAss.PageSizeTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.ListAss.PageSizeTextSize = 11F;
            this.ListAss.ShowSplitLine = true;
            this.ListAss.Size = new System.Drawing.Size(300, 220);
            this.ListAss.SplitLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.ListAss.TemplateControlName = "OperCreateAssLayout";
            // 
            // PopRTMan
            // 
            this.PopRTMan.Name = "PopRTMan";
            this.PopRTMan.Selected += new System.EventHandler(this.PopRTMan_Selected);
            // 
            // PopHMan
            // 
            this.PopHMan.Name = "PopHMan";
            this.PopHMan.Selected += new System.EventHandler(this.PopHMan_Selected);
            // 
            // PopLocation
            // 
            this.PopLocation.Name = "PopLocation";
            this.PopLocation.Selected += new System.EventHandler(this.PopLocation_Selected);
            // 
            // r2000Scanner1
            // 
            this.r2000Scanner1.Name = "r2000Scanner1";
            this.r2000Scanner1.BarcodeDataCaptured += new Smobiler.Device.R2000BarcodeScanEventHandler(this.r2000Scanner1_BarcodeDataCaptured);
            this.r2000Scanner1.RFIDDataCaptured += new Smobiler.Device.R2000RFIDScanEventHandler(this.r2000Scanner1_RFIDDataCaptured);
            // 
            // barcodeScanner1
            // 
            this.barcodeScanner1.Name = "barcodeScanner1";
            this.barcodeScanner1.BarcodeScanned += new Smobiler.Core.Controls.BarcodeScannerCallBackHandler(this.barcodeScanner1_BarcodeScanned_1);
            // 
            // frmRtoCreate
            // 
            this.Components.AddRange(new Smobiler.Core.Controls.MobileComponent[] {
            this.PopRTMan,
            this.PopHMan,
            this.PopLocation,
            this.r2000Scanner1,
            this.barcodeScanner1});
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.Title1,
            this.Panel2,
            this.Panel1});
            this.Orientation = Smobiler.Core.Controls.FormOrientation.Portrait;
            this.Statusbar = new Smobiler.Core.Controls.MobileFormStatusbar(Smobiler.Core.Controls.MobileFormStatusbarStyle.Default, System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(164)))), ((int)(((byte)(229))))));
            this.KeyDown += new Smobiler.Core.Controls.KeyDownEventHandler(this.FrmRtoCreate_KeyDown);
            this.Load += new System.EventHandler(this.FrmRtoCreate_Load);
            this.Name = "frmRtoCreate";

        }
        #endregion

        private Title Title1;
        internal Smobiler.Core.Controls.Panel Panel2;
        internal Smobiler.Core.Controls.Button btnConfirm;
        internal Smobiler.Core.Controls.Panel Panel1;
        internal Smobiler.Core.Controls.Panel Panel3;
        internal Smobiler.Core.Controls.Label Label1;
        internal Smobiler.Core.Controls.Label Label2;
        internal Smobiler.Core.Controls.Label Label7;
        internal Smobiler.Core.Controls.Label Label8;
        internal Smobiler.Core.Controls.TextBox txtNote;
        internal Smobiler.Core.Controls.DatePicker DPickerCO;
        internal Smobiler.Core.Controls.Button btnBOMan;
        internal Smobiler.Core.Controls.Label Label4;
        internal Smobiler.Core.Controls.Button btnBOMan1;
        internal Smobiler.Core.Controls.ImageButton ImgBtnForBarcode;
        internal Smobiler.Core.Controls.PopList PopRTMan;
        internal Smobiler.Core.Controls.PopList PopHMan;
        internal Smobiler.Core.Controls.PopList PopLocation;
        private Smobiler.Core.Controls.ListView ListAss;
        internal Smobiler.Core.Controls.TextBox txtHMan;
        internal Smobiler.Core.Controls.TextBox txtLocation;
        private Smobiler.Device.R2000Scanner r2000Scanner1;
        private Smobiler.Core.Controls.BarcodeScanner barcodeScanner1;
    }
}