using SMOSEC.UI.UserControl;

namespace SMOSEC.UI.AssetsManager
{
    partial class frmBoCreate : Smobiler.Core.Controls.MobileForm
    {
        #region "SmobilerForm generated code "

        public frmBoCreate()
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
            this.btnSave = new Smobiler.Core.Controls.Button();
            this.Panel1 = new Smobiler.Core.Controls.Panel();
            this.Panel3 = new Smobiler.Core.Controls.Panel();
            this.Label1 = new Smobiler.Core.Controls.Label();
            this.Label2 = new Smobiler.Core.Controls.Label();
            this.Label6 = new Smobiler.Core.Controls.Label();
            this.Label7 = new Smobiler.Core.Controls.Label();
            this.Label8 = new Smobiler.Core.Controls.Label();
            this.txtNote = new Smobiler.Core.Controls.TextBox();
            this.DPickerCO = new Smobiler.Core.Controls.DatePicker();
            this.DPickerRs = new Smobiler.Core.Controls.DatePicker();
            this.btnBOMan = new Smobiler.Core.Controls.Button();
            this.btnBOMan1 = new Smobiler.Core.Controls.Button();
            this.Label4 = new Smobiler.Core.Controls.Label();
            this.btnLocation = new Smobiler.Core.Controls.Button();
            this.btnLocation1 = new Smobiler.Core.Controls.Button();
            this.txtManager = new Smobiler.Core.Controls.TextBox();
            this.panelScan = new Smobiler.Core.Controls.Panel();
            this.image1 = new Smobiler.Core.Controls.Image();
            this.label3 = new Smobiler.Core.Controls.Label();
            this.Panel4 = new Smobiler.Core.Controls.Panel();
            this.ListAss = new Smobiler.Core.Controls.ListView();
            this.PopBOMan = new Smobiler.Core.Controls.PopList();
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
            this.Title1.TitleText = "借用单创建";
            // 
            // Panel2
            // 
            this.Panel2.BackColor = System.Drawing.Color.White;
            this.Panel2.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.Panel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Panel2.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.btnSave});
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel2.Location = new System.Drawing.Point(0, 468);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(300, 40);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(56, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(176, 30);
            this.btnSave.Text = "确定";
            this.btnSave.Press += new System.EventHandler(this.btnSave_Press);
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.White;
            this.Panel1.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.Panel3,
            this.Panel4});
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1.Location = new System.Drawing.Point(0, 62);
            this.Panel1.Name = "Panel1";
            this.Panel1.Scrollable = true;
            this.Panel1.Size = new System.Drawing.Size(300, 327);
            // 
            // Panel3
            // 
            this.Panel3.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.Label1,
            this.Label2,
            this.Label6,
            this.Label7,
            this.Label8,
            this.txtNote,
            this.DPickerCO,
            this.DPickerRs,
            this.btnBOMan,
            this.btnBOMan1,
            this.Label4,
            this.btnLocation,
            this.btnLocation1,
            this.txtManager,
            this.panelScan});
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(300, 215);
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.Color.White;
            this.Label1.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.Label1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Label1.Name = "Label1";
            this.Label1.Padding = new Smobiler.Core.Controls.Padding(5F, 0F, 0F, 0F);
            this.Label1.Size = new System.Drawing.Size(100, 30);
            this.Label1.Text = "借用人";
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
            this.Label2.Text = "借出日期";
            // 
            // Label6
            // 
            this.Label6.BackColor = System.Drawing.Color.White;
            this.Label6.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.Label6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Label6.Location = new System.Drawing.Point(0, 120);
            this.Label6.Name = "Label6";
            this.Label6.Padding = new Smobiler.Core.Controls.Padding(5F, 0F, 0F, 0F);
            this.Label6.Size = new System.Drawing.Size(100, 30);
            this.Label6.Text = "预计归还日期";
            // 
            // Label7
            // 
            this.Label7.BackColor = System.Drawing.Color.White;
            this.Label7.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.Label7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Label7.Location = new System.Drawing.Point(0, 90);
            this.Label7.Name = "Label7";
            this.Label7.Padding = new Smobiler.Core.Controls.Padding(5F, 0F, 0F, 0F);
            this.Label7.Size = new System.Drawing.Size(100, 30);
            this.Label7.Text = "借出处理人";
            // 
            // Label8
            // 
            this.Label8.BackColor = System.Drawing.Color.White;
            this.Label8.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 1F);
            this.Label8.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Label8.Location = new System.Drawing.Point(0, 150);
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
            this.txtNote.Location = new System.Drawing.Point(100, 150);
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
            // DPickerRs
            // 
            this.DPickerRs.BackColor = System.Drawing.Color.White;
            this.DPickerRs.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.DPickerRs.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.DPickerRs.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.DPickerRs.Location = new System.Drawing.Point(100, 120);
            this.DPickerRs.Name = "DPickerRs";
            this.DPickerRs.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 5F, 0F);
            this.DPickerRs.Size = new System.Drawing.Size(200, 30);
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
            // Label4
            // 
            this.Label4.BackColor = System.Drawing.Color.White;
            this.Label4.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.Label4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Label4.Location = new System.Drawing.Point(0, 60);
            this.Label4.Name = "Label4";
            this.Label4.Padding = new Smobiler.Core.Controls.Padding(5F, 0F, 0F, 0F);
            this.Label4.Size = new System.Drawing.Size(100, 30);
            this.Label4.Text = "来源区域";
            // 
            // btnLocation
            // 
            this.btnLocation.BackColor = System.Drawing.Color.White;
            this.btnLocation.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.btnLocation.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnLocation.BorderRadius = 0;
            this.btnLocation.ForeColor = System.Drawing.Color.Black;
            this.btnLocation.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.btnLocation.Location = new System.Drawing.Point(100, 60);
            this.btnLocation.Name = "btnLocation";
            this.btnLocation.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 2F, 0F);
            this.btnLocation.Size = new System.Drawing.Size(166, 30);
            this.btnLocation.Press += new System.EventHandler(this.btnLocation_Press);
            // 
            // btnLocation1
            // 
            this.btnLocation1.BackColor = System.Drawing.Color.White;
            this.btnLocation1.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.btnLocation1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnLocation1.BorderRadius = 0;
            this.btnLocation1.ForeColor = System.Drawing.Color.Black;
            this.btnLocation1.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.btnLocation1.Location = new System.Drawing.Point(266, 60);
            this.btnLocation1.Name = "btnLocation1";
            this.btnLocation1.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 5F, 0F);
            this.btnLocation1.Size = new System.Drawing.Size(34, 30);
            this.btnLocation1.Text = ">";
            this.btnLocation1.Press += new System.EventHandler(this.btnLocation_Press);
            // 
            // txtManager
            // 
            this.txtManager.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.txtManager.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.txtManager.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.txtManager.Location = new System.Drawing.Point(100, 90);
            this.txtManager.Name = "txtManager";
            this.txtManager.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 5F, 0F);
            this.txtManager.ReadOnly = true;
            this.txtManager.Size = new System.Drawing.Size(200, 30);
            // 
            // panelScan
            // 
            this.panelScan.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.image1,
            this.label3});
            this.panelScan.Location = new System.Drawing.Point(5, 184);
            this.panelScan.Name = "panelScan";
            this.panelScan.Size = new System.Drawing.Size(124, 28);
            this.panelScan.Touchable = true;
            this.panelScan.Press += new System.EventHandler(this.panelScan_Press);
            // 
            // image1
            // 
            this.image1.Location = new System.Drawing.Point(1, 1);
            this.image1.Name = "image1";
            this.image1.ResourceID = "scan";
            this.image1.Size = new System.Drawing.Size(30, 26);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(38, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 25);
            this.label3.Text = "扫码添加";
            // 
            // Panel4
            // 
            this.Panel4.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.ListAss});
            this.Panel4.Location = new System.Drawing.Point(0, 215);
            this.Panel4.Name = "Panel4";
            this.Panel4.Size = new System.Drawing.Size(300, 200);
            // 
            // ListAss
            // 
            this.ListAss.BackColor = System.Drawing.Color.White;
            this.ListAss.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.ListAss.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.ListAss.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListAss.Location = new System.Drawing.Point(0, 2);
            this.ListAss.Name = "ListAss";
            this.ListAss.PageSizeTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.ListAss.PageSizeTextSize = 11F;
            this.ListAss.ShowSplitLine = true;
            this.ListAss.Size = new System.Drawing.Size(300, 185);
            this.ListAss.SplitLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.ListAss.TemplateControlName = "OperCreateAssLayout";
            // 
            // PopBOMan
            // 
            this.PopBOMan.Name = "PopBOMan";
            this.PopBOMan.Selected += new System.EventHandler(this.PopBOMan_Selected);
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
            // frmBoCreate
            // 
            this.Components.AddRange(new Smobiler.Core.Controls.MobileComponent[] {
            this.PopBOMan,
            this.PopLocation,
            this.r2000Scanner1,
            this.barcodeScanner1});
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.Title1,
            this.Panel2,
            this.Panel1});
            this.Orientation = Smobiler.Core.Controls.FormOrientation.Portrait;
            this.Statusbar = new Smobiler.Core.Controls.MobileFormStatusbar(Smobiler.Core.Controls.MobileFormStatusbarStyle.Default, System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(164)))), ((int)(((byte)(229))))));
            this.KeyDown += new Smobiler.Core.Controls.KeyDownEventHandler(this.frmBOCreate_KeyDown);
            this.Load += new System.EventHandler(this.frmBOCreate_Load);
            this.Name = "frmBoCreate";

        }
        #endregion

        private Title Title1;
        internal Smobiler.Core.Controls.Panel Panel2;
        internal Smobiler.Core.Controls.Button btnSave;
        internal Smobiler.Core.Controls.Panel Panel1;
        internal Smobiler.Core.Controls.Panel Panel3;
        internal Smobiler.Core.Controls.Label Label1;
        internal Smobiler.Core.Controls.Label Label2;
        internal Smobiler.Core.Controls.Label Label6;
        internal Smobiler.Core.Controls.Label Label7;
        internal Smobiler.Core.Controls.Label Label8;
        internal Smobiler.Core.Controls.TextBox txtNote;
        internal Smobiler.Core.Controls.DatePicker DPickerCO;
        internal Smobiler.Core.Controls.DatePicker DPickerRs;
        internal Smobiler.Core.Controls.Button btnBOMan;
        internal Smobiler.Core.Controls.Button btnBOMan1;
        internal Smobiler.Core.Controls.Label Label4;
        internal Smobiler.Core.Controls.Button btnLocation;
        internal Smobiler.Core.Controls.Button btnLocation1;
        internal Smobiler.Core.Controls.Panel Panel4;
        internal Smobiler.Core.Controls.PopList PopBOMan;
        internal Smobiler.Core.Controls.PopList PopLocation;
        private Smobiler.Core.Controls.ListView ListAss;
        internal Smobiler.Core.Controls.TextBox txtManager;
        private Smobiler.Device.R2000Scanner r2000Scanner1;
        private Smobiler.Core.Controls.BarcodeScanner barcodeScanner1;
        internal Smobiler.Core.Controls.Panel panelScan;
        private Smobiler.Core.Controls.Image image1;
        private Smobiler.Core.Controls.Label label3;
    }
}