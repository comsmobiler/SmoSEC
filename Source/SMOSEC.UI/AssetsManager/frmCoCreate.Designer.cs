using SMOSEC.UI.UserControl;

namespace SMOSEC.UI.AssetsManager
{
    partial class frmCoCreate : Smobiler.Core.Controls.MobileForm
    {
        #region "SmobilerForm generated code "

        public frmCoCreate()
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
            this.Label3 = new Smobiler.Core.Controls.Label();
            this.Label4 = new Smobiler.Core.Controls.Label();
            this.Label5 = new Smobiler.Core.Controls.Label();
            this.Label6 = new Smobiler.Core.Controls.Label();
            this.Label7 = new Smobiler.Core.Controls.Label();
            this.Label8 = new Smobiler.Core.Controls.Label();
            this.btnLocation = new Smobiler.Core.Controls.Button();
            this.txtDep = new Smobiler.Core.Controls.TextBox();
            this.btnLocation1 = new Smobiler.Core.Controls.Button();
            this.txtPlace = new Smobiler.Core.Controls.TextBox();
            this.txtNote = new Smobiler.Core.Controls.TextBox();
            this.DPickerCO = new Smobiler.Core.Controls.DatePicker();
            this.DPickerRs = new Smobiler.Core.Controls.DatePicker();
            this.btnCOMan = new Smobiler.Core.Controls.Button();
            this.btnCOMan1 = new Smobiler.Core.Controls.Button();
            this.txtHMan = new Smobiler.Core.Controls.TextBox();
            this.panelScan = new Smobiler.Core.Controls.Panel();
            this.image1 = new Smobiler.Core.Controls.Image();
            this.label9 = new Smobiler.Core.Controls.Label();
            this.ListAss = new Smobiler.Core.Controls.ListView();
            this.PopLocation = new Smobiler.Core.Controls.PopList();
            this.PopCOMan = new Smobiler.Core.Controls.PopList();
            this.barcodeScanner1 = new Smobiler.Core.Controls.BarcodeScanner();
            this.r2000Scanner1 = new Smobiler.Device.R2000Scanner();
            // 
            // Title1
            // 
            this.Title1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(164)))), ((int)(((byte)(229)))));
            this.Title1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Title1.FontSize = 15F;
            this.Title1.ForeColor = System.Drawing.Color.White;
            this.Title1.Name = "Title1";
            this.Title1.Size = new System.Drawing.Size(300, 40);
            this.Title1.TitleText = "领用单创建";
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
            this.btnConfirm.Location = new System.Drawing.Point(60, 4);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(178, 30);
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
            this.Panel1.Size = new System.Drawing.Size(300, 326);
            // 
            // Panel3
            // 
            this.Panel3.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.Label1,
            this.Label2,
            this.Label3,
            this.Label4,
            this.Label5,
            this.Label6,
            this.Label7,
            this.Label8,
            this.btnLocation,
            this.txtDep,
            this.btnLocation1,
            this.txtPlace,
            this.txtNote,
            this.DPickerCO,
            this.DPickerRs,
            this.btnCOMan,
            this.btnCOMan1,
            this.txtHMan,
            this.panelScan});
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(300, 278);
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.Color.White;
            this.Label1.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.Label1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Label1.Name = "Label1";
            this.Label1.Padding = new Smobiler.Core.Controls.Padding(5F, 0F, 0F, 0F);
            this.Label1.Size = new System.Drawing.Size(100, 30);
            this.Label1.Text = "领用人";
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
            this.Label2.Text = "领用日期";
            // 
            // Label3
            // 
            this.Label3.BackColor = System.Drawing.Color.White;
            this.Label3.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.Label3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Label3.Location = new System.Drawing.Point(0, 60);
            this.Label3.Name = "Label3";
            this.Label3.Padding = new Smobiler.Core.Controls.Padding(5F, 0F, 0F, 0F);
            this.Label3.Size = new System.Drawing.Size(100, 30);
            this.Label3.Text = "使用部门";
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
            this.Label4.Text = "来源区域";
            // 
            // Label5
            // 
            this.Label5.BackColor = System.Drawing.Color.White;
            this.Label5.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.Label5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Label5.Location = new System.Drawing.Point(0, 120);
            this.Label5.Name = "Label5";
            this.Label5.Padding = new Smobiler.Core.Controls.Padding(5F, 0F, 0F, 0F);
            this.Label5.Size = new System.Drawing.Size(100, 30);
            this.Label5.Text = "存放地点";
            // 
            // Label6
            // 
            this.Label6.BackColor = System.Drawing.Color.White;
            this.Label6.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.Label6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Label6.Location = new System.Drawing.Point(0, 150);
            this.Label6.Name = "Label6";
            this.Label6.Padding = new Smobiler.Core.Controls.Padding(5F, 0F, 0F, 0F);
            this.Label6.Size = new System.Drawing.Size(100, 30);
            this.Label6.Text = "预计退库日期";
            // 
            // Label7
            // 
            this.Label7.BackColor = System.Drawing.Color.White;
            this.Label7.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.Label7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Label7.Location = new System.Drawing.Point(0, 180);
            this.Label7.Name = "Label7";
            this.Label7.Padding = new Smobiler.Core.Controls.Padding(5F, 0F, 0F, 0F);
            this.Label7.Size = new System.Drawing.Size(100, 30);
            this.Label7.Text = "领用处理人";
            // 
            // Label8
            // 
            this.Label8.BackColor = System.Drawing.Color.White;
            this.Label8.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 1F);
            this.Label8.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Label8.Location = new System.Drawing.Point(0, 210);
            this.Label8.Name = "Label8";
            this.Label8.Padding = new Smobiler.Core.Controls.Padding(5F, 0F, 0F, 0F);
            this.Label8.Size = new System.Drawing.Size(100, 30);
            this.Label8.Text = "备注";
            // 
            // btnLocation
            // 
            this.btnLocation.BackColor = System.Drawing.Color.White;
            this.btnLocation.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.btnLocation.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnLocation.BorderRadius = 0;
            this.btnLocation.ForeColor = System.Drawing.Color.Black;
            this.btnLocation.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.btnLocation.Location = new System.Drawing.Point(100, 90);
            this.btnLocation.Name = "btnLocation";
            this.btnLocation.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 2F, 0F);
            this.btnLocation.Size = new System.Drawing.Size(166, 30);
            this.btnLocation.Press += new System.EventHandler(this.btnLocation_Press);
            // 
            // txtDep
            // 
            this.txtDep.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.txtDep.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.txtDep.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.txtDep.Location = new System.Drawing.Point(100, 60);
            this.txtDep.Name = "txtDep";
            this.txtDep.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 5F, 0F);
            this.txtDep.ReadOnly = true;
            this.txtDep.Size = new System.Drawing.Size(200, 30);
            // 
            // btnLocation1
            // 
            this.btnLocation1.BackColor = System.Drawing.Color.White;
            this.btnLocation1.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.btnLocation1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnLocation1.BorderRadius = 0;
            this.btnLocation1.ForeColor = System.Drawing.Color.Black;
            this.btnLocation1.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.btnLocation1.Location = new System.Drawing.Point(266, 90);
            this.btnLocation1.Name = "btnLocation1";
            this.btnLocation1.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 5F, 0F);
            this.btnLocation1.Size = new System.Drawing.Size(34, 30);
            this.btnLocation1.Text = ">";
            this.btnLocation1.Press += new System.EventHandler(this.btnLocation_Press);
            // 
            // txtPlace
            // 
            this.txtPlace.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.txtPlace.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.txtPlace.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.txtPlace.Location = new System.Drawing.Point(100, 120);
            this.txtPlace.Name = "txtPlace";
            this.txtPlace.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 5F, 0F);
            this.txtPlace.Size = new System.Drawing.Size(200, 30);
            this.txtPlace.WaterMarkText = "(选填)";
            // 
            // txtNote
            // 
            this.txtNote.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 1F);
            this.txtNote.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.txtNote.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.txtNote.Location = new System.Drawing.Point(100, 210);
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
            this.DPickerRs.Location = new System.Drawing.Point(100, 150);
            this.DPickerRs.Name = "DPickerRs";
            this.DPickerRs.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 5F, 0F);
            this.DPickerRs.Size = new System.Drawing.Size(200, 30);
            // 
            // btnCOMan
            // 
            this.btnCOMan.BackColor = System.Drawing.Color.White;
            this.btnCOMan.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.btnCOMan.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnCOMan.BorderRadius = 0;
            this.btnCOMan.ForeColor = System.Drawing.Color.Black;
            this.btnCOMan.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.btnCOMan.Location = new System.Drawing.Point(100, 0);
            this.btnCOMan.Name = "btnCOMan";
            this.btnCOMan.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 2F, 0F);
            this.btnCOMan.Size = new System.Drawing.Size(166, 30);
            this.btnCOMan.Press += new System.EventHandler(this.btnCOMan_Press);
            // 
            // btnCOMan1
            // 
            this.btnCOMan1.BackColor = System.Drawing.Color.White;
            this.btnCOMan1.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.btnCOMan1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnCOMan1.BorderRadius = 0;
            this.btnCOMan1.ForeColor = System.Drawing.Color.Black;
            this.btnCOMan1.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.btnCOMan1.Location = new System.Drawing.Point(266, 0);
            this.btnCOMan1.Name = "btnCOMan1";
            this.btnCOMan1.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 5F, 0F);
            this.btnCOMan1.Size = new System.Drawing.Size(34, 30);
            this.btnCOMan1.Text = ">";
            this.btnCOMan1.Press += new System.EventHandler(this.btnCOMan_Press);
            // 
            // txtHMan
            // 
            this.txtHMan.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.txtHMan.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.txtHMan.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.txtHMan.Location = new System.Drawing.Point(100, 180);
            this.txtHMan.Name = "txtHMan";
            this.txtHMan.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 5F, 0F);
            this.txtHMan.ReadOnly = true;
            this.txtHMan.Size = new System.Drawing.Size(200, 30);
            // 
            // panelScan
            // 
            this.panelScan.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.image1,
            this.label9});
            this.panelScan.Location = new System.Drawing.Point(5, 246);
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
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(38, 2);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 25);
            this.label9.Text = "扫码添加";
            // 
            // ListAss
            // 
            this.ListAss.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.ListAss.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.ListAss.Location = new System.Drawing.Point(0, 281);
            this.ListAss.Name = "ListAss";
            this.ListAss.PageSizeTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.ListAss.PageSizeTextSize = 11F;
            this.ListAss.ShowSplitLine = true;
            this.ListAss.Size = new System.Drawing.Size(300, 130);
            this.ListAss.SplitLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.ListAss.TemplateControlName = "OperCreateAssLayout";
            // 
            // PopLocation
            // 
            this.PopLocation.Name = "PopLocation";
            this.PopLocation.Selected += new System.EventHandler(this.PopLocation_Selected);
            // 
            // PopCOMan
            // 
            this.PopCOMan.Name = "PopCOMan";
            this.PopCOMan.Selected += new System.EventHandler(this.PopCOMan_Selected);
            // 
            // barcodeScanner1
            // 
            this.barcodeScanner1.Name = "barcodeScanner1";
            this.barcodeScanner1.BarcodeScanned += new Smobiler.Core.Controls.BarcodeScannerCallBackHandler(this.barcodeScanner1_BarcodeScanned_1);
            // 
            // r2000Scanner1
            // 
            this.r2000Scanner1.Name = "r2000Scanner1";
            this.r2000Scanner1.BarcodeDataCaptured += new Smobiler.Device.R2000BarcodeScanEventHandler(this.r2000Scanner1_BarcodeDataCaptured);
            this.r2000Scanner1.RFIDDataCaptured += new Smobiler.Device.R2000RFIDScanEventHandler(this.r2000Scanner1_RFIDDataCaptured);
            // 
            // frmCoCreate
            // 
            this.Components.AddRange(new Smobiler.Core.Controls.MobileComponent[] {
            this.PopLocation,
            this.PopCOMan,
            this.barcodeScanner1,
            this.r2000Scanner1});
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.Title1,
            this.Panel2,
            this.Panel1});
            this.Orientation = Smobiler.Core.Controls.FormOrientation.Portrait;
            this.Statusbar = new Smobiler.Core.Controls.MobileFormStatusbar(Smobiler.Core.Controls.MobileFormStatusbarStyle.Default, System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(164)))), ((int)(((byte)(229))))));
            this.KeyDown += new Smobiler.Core.Controls.KeyDownEventHandler(this.FrmCoCreate_KeyDown);
            this.Load += new System.EventHandler(this.FrmCoCreate_Load);
            this.Name = "frmCoCreate";

        }
        #endregion

        private Title Title1;
        internal Smobiler.Core.Controls.Panel Panel2;
        internal Smobiler.Core.Controls.Button btnConfirm;
        internal Smobiler.Core.Controls.Panel Panel1;
        internal Smobiler.Core.Controls.Panel Panel3;
        internal Smobiler.Core.Controls.Label Label1;
        internal Smobiler.Core.Controls.Label Label2;
        internal Smobiler.Core.Controls.Label Label3;
        internal Smobiler.Core.Controls.Label Label4;
        internal Smobiler.Core.Controls.Label Label5;
        internal Smobiler.Core.Controls.Label Label6;
        internal Smobiler.Core.Controls.Label Label7;
        internal Smobiler.Core.Controls.Label Label8;
        internal Smobiler.Core.Controls.Button btnLocation;
        internal Smobiler.Core.Controls.TextBox txtDep;
        internal Smobiler.Core.Controls.Button btnLocation1;
        internal Smobiler.Core.Controls.TextBox txtPlace;
        internal Smobiler.Core.Controls.TextBox txtNote;
        internal Smobiler.Core.Controls.DatePicker DPickerCO;
        internal Smobiler.Core.Controls.DatePicker DPickerRs;
        internal Smobiler.Core.Controls.Button btnCOMan;
        internal Smobiler.Core.Controls.Button btnCOMan1;
        internal Smobiler.Core.Controls.PopList PopLocation;
        internal Smobiler.Core.Controls.PopList PopCOMan;
        private Smobiler.Core.Controls.ListView ListAss;
        internal Smobiler.Core.Controls.TextBox txtHMan;
        private Smobiler.Device.R2000Scanner r2000Scanner1;
        private Smobiler.Core.Controls.BarcodeScanner barcodeScanner1;
        internal Smobiler.Core.Controls.Panel panelScan;
        private Smobiler.Core.Controls.Image image1;
        private Smobiler.Core.Controls.Label label9;
    }
}