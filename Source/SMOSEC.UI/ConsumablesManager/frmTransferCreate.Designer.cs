using System;
using Smobiler.Core;
namespace SMOSEC.UI.ConsumablesManager
{
    partial class frmTransferCreate : Smobiler.Core.Controls.MobileForm
    {
        #region "SmobilerForm generated code "

        public frmTransferCreate()
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
            this.title1 = new SMOSEC.UI.UserControl.Title();
            this.plButton = new Smobiler.Core.Controls.Panel();
            this.btnSave = new Smobiler.Core.Controls.Button();
            this.spContent = new Smobiler.Core.Controls.Panel();
            this.plTDInMan = new Smobiler.Core.Controls.Panel();
            this.label1 = new Smobiler.Core.Controls.Label();
            this.btnDealInMan = new Smobiler.Core.Controls.Button();
            this.plDate = new Smobiler.Core.Controls.Panel();
            this.label5 = new Smobiler.Core.Controls.Label();
            this.DatePicker = new Smobiler.Core.Controls.DatePicker();
            this.plLocation = new Smobiler.Core.Controls.Panel();
            this.label2 = new Smobiler.Core.Controls.Label();
            this.btnLocation = new Smobiler.Core.Controls.Button();
            this.plNote = new Smobiler.Core.Controls.Panel();
            this.label6 = new Smobiler.Core.Controls.Label();
            this.txtNote = new Smobiler.Core.Controls.TextBox();
            this.plTDMan = new Smobiler.Core.Controls.Panel();
            this.Label3 = new Smobiler.Core.Controls.Label();
            this.btnDealMan = new Smobiler.Core.Controls.Button();
            this.plAdd = new Smobiler.Core.Controls.Panel();
            this.btnAdd = new Smobiler.Core.Controls.Button();
            this.betGet = new Smobiler.Core.Controls.Button();
            this.ListAssets = new Smobiler.Core.Controls.ListView();
            this.popDealMan = new Smobiler.Core.Controls.PopList();
            this.popDealInMan = new Smobiler.Core.Controls.PopList();
            this.popLocation = new Smobiler.Core.Controls.PopList();
            this.BarcodeScanner1 = new Smobiler.Core.Controls.BarcodeScanner();
            this.popConLoc = new Smobiler.Core.Controls.PopList();
            // 
            // title1
            // 
            this.title1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(164)))), ((int)(((byte)(229)))));
            this.title1.Dock = System.Windows.Forms.DockStyle.Top;
            this.title1.FontSize = 15F;
            this.title1.ForeColor = System.Drawing.Color.White;
            this.title1.Location = new System.Drawing.Point(54, 0);
            this.title1.Name = "title1";
            this.title1.Size = new System.Drawing.Size(100, 40);
            this.title1.TitleText = "耗材调拨单创建";
            // 
            // plButton
            // 
            this.plButton.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.btnSave});
            this.plButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plButton.Location = new System.Drawing.Point(0, 382);
            this.plButton.Name = "plButton";
            this.plButton.Size = new System.Drawing.Size(300, 35);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(146)))), ((int)(((byte)(223)))));
            this.btnSave.BorderRadius = 4;
            this.btnSave.FontSize = 17F;
            this.btnSave.Location = new System.Drawing.Point(10, 0);
            this.btnSave.Margin = new Smobiler.Core.Controls.Margin(0F, 0F, 10F, 0F);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(280, 35);
            this.btnSave.Text = "提交";
            this.btnSave.Press += new System.EventHandler(this.btnSave_Press);
            // 
            // spContent
            // 
            this.spContent.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.plTDInMan,
            this.plDate,
            this.plLocation,
            this.plNote,
            this.plTDMan,
            this.plAdd,
            this.ListAssets});
            this.spContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spContent.Flex = 10000;
            this.spContent.Location = new System.Drawing.Point(0, 110);
            this.spContent.Name = "spContent";
            this.spContent.Scrollable = true;
            this.spContent.Size = new System.Drawing.Size(300, 100);
            // 
            // plTDInMan
            // 
            this.plTDInMan.BackColor = System.Drawing.Color.White;
            this.plTDInMan.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 1F);
            this.plTDInMan.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.plTDInMan.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.label1,
            this.btnDealInMan});
            this.plTDInMan.Name = "plTDInMan";
            this.plTDInMan.Size = new System.Drawing.Size(300, 35);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.label1.Name = "label1";
            this.label1.Padding = new Smobiler.Core.Controls.Padding(5F, 0F, 0F, 0F);
            this.label1.Size = new System.Drawing.Size(88, 35);
            this.label1.Text = "调入管理员";
            // 
            // btnDealInMan
            // 
            this.btnDealInMan.BackColor = System.Drawing.Color.Transparent;
            this.btnDealInMan.BorderRadius = 0;
            this.btnDealInMan.ForeColor = System.Drawing.Color.Black;
            this.btnDealInMan.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.btnDealInMan.Location = new System.Drawing.Point(88, 0);
            this.btnDealInMan.Name = "btnDealInMan";
            this.btnDealInMan.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 5F, 0F);
            this.btnDealInMan.Size = new System.Drawing.Size(212, 35);
            this.btnDealInMan.Text = "选择（必填）   > ";
            this.btnDealInMan.Press += new System.EventHandler(this.btnDealInMan_Press);
            // 
            // plDate
            // 
            this.plDate.BackColor = System.Drawing.Color.White;
            this.plDate.Border = new Smobiler.Core.Controls.Border(0F, 0F, 0F, 1F);
            this.plDate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.plDate.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.label5,
            this.DatePicker});
            this.plDate.Location = new System.Drawing.Point(0, 35);
            this.plDate.Name = "plDate";
            this.plDate.Size = new System.Drawing.Size(300, 35);
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.label5.Name = "label5";
            this.label5.Padding = new Smobiler.Core.Controls.Padding(5F, 0F, 0F, 0F);
            this.label5.Size = new System.Drawing.Size(88, 35);
            this.label5.Text = "业务日期";
            // 
            // DatePicker
            // 
            this.DatePicker.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.DatePicker.Location = new System.Drawing.Point(88, 0);
            this.DatePicker.Name = "DatePicker";
            this.DatePicker.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 5F, 0F);
            this.DatePicker.Size = new System.Drawing.Size(212, 35);
            // 
            // plLocation
            // 
            this.plLocation.BackColor = System.Drawing.Color.White;
            this.plLocation.Border = new Smobiler.Core.Controls.Border(0F, 0F, 0F, 1F);
            this.plLocation.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.plLocation.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.label2,
            this.btnLocation});
            this.plLocation.Location = new System.Drawing.Point(0, 70);
            this.plLocation.Name = "plLocation";
            this.plLocation.Size = new System.Drawing.Size(300, 35);
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.label2.Name = "label2";
            this.label2.Padding = new Smobiler.Core.Controls.Padding(5F, 0F, 0F, 0F);
            this.label2.Size = new System.Drawing.Size(88, 35);
            this.label2.Text = "调入区域";
            // 
            // btnLocation
            // 
            this.btnLocation.BackColor = System.Drawing.Color.Transparent;
            this.btnLocation.BorderRadius = 0;
            this.btnLocation.ForeColor = System.Drawing.Color.Black;
            this.btnLocation.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.btnLocation.Location = new System.Drawing.Point(88, 0);
            this.btnLocation.Name = "btnLocation";
            this.btnLocation.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 5F, 0F);
            this.btnLocation.Size = new System.Drawing.Size(212, 35);
            this.btnLocation.Text = "选择（必填）   > ";
            this.btnLocation.Press += new System.EventHandler(this.btnLocation_Press);
            // 
            // plNote
            // 
            this.plNote.BackColor = System.Drawing.Color.White;
            this.plNote.Border = new Smobiler.Core.Controls.Border(0F, 0F, 0F, 1F);
            this.plNote.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.plNote.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.label6,
            this.txtNote});
            this.plNote.Location = new System.Drawing.Point(0, 140);
            this.plNote.Name = "plNote";
            this.plNote.Size = new System.Drawing.Size(300, 70);
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.label6.Name = "label6";
            this.label6.Padding = new Smobiler.Core.Controls.Padding(5F, 5F, 0F, 0F);
            this.label6.Size = new System.Drawing.Size(88, 70);
            this.label6.Text = "备注";
            this.label6.VerticalAlignment = Smobiler.Core.Controls.VerticalAlignment.Top;
            // 
            // txtNote
            // 
            this.txtNote.BackColor = System.Drawing.Color.Transparent;
            this.txtNote.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.txtNote.Location = new System.Drawing.Point(88, 0);
            this.txtNote.MaxLength = 200;
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Padding = new Smobiler.Core.Controls.Padding(0F, 5F, 5F, 0F);
            this.txtNote.Size = new System.Drawing.Size(212, 70);
            this.txtNote.WaterMarkText = "（选填）";
            // 
            // plTDMan
            // 
            this.plTDMan.BackColor = System.Drawing.Color.White;
            this.plTDMan.Border = new Smobiler.Core.Controls.Border(0F, 0F, 0F, 1F);
            this.plTDMan.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.plTDMan.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.Label3,
            this.btnDealMan});
            this.plTDMan.Location = new System.Drawing.Point(0, 105);
            this.plTDMan.Name = "plTDMan";
            this.plTDMan.Size = new System.Drawing.Size(300, 35);
            // 
            // Label3
            // 
            this.Label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.Label3.Name = "Label3";
            this.Label3.Padding = new Smobiler.Core.Controls.Padding(5F, 0F, 0F, 0F);
            this.Label3.Size = new System.Drawing.Size(88, 35);
            this.Label3.Text = "处理人";
            // 
            // btnDealMan
            // 
            this.btnDealMan.BackColor = System.Drawing.Color.Transparent;
            this.btnDealMan.BorderRadius = 0;
            this.btnDealMan.ForeColor = System.Drawing.Color.Black;
            this.btnDealMan.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.btnDealMan.Location = new System.Drawing.Point(88, 0);
            this.btnDealMan.Name = "btnDealMan";
            this.btnDealMan.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 5F, 0F);
            this.btnDealMan.Size = new System.Drawing.Size(212, 35);
            this.btnDealMan.Text = "选择（必填）   > ";
            this.btnDealMan.Press += new System.EventHandler(this.btnDealMan_Press);
            // 
            // plAdd
            // 
            this.plAdd.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.btnAdd,
            this.betGet});
            this.plAdd.Location = new System.Drawing.Point(0, 210);
            this.plAdd.Name = "plAdd";
            this.plAdd.Size = new System.Drawing.Size(300, 35);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(10, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(130, 35);
            this.btnAdd.Text = "资产选择";
            this.btnAdd.Press += new System.EventHandler(this.btnAdd_Press);
            // 
            // betGet
            // 
            this.betGet.Location = new System.Drawing.Point(160, 0);
            this.betGet.Name = "betGet";
            this.betGet.Size = new System.Drawing.Size(130, 35);
            this.betGet.Text = "扫码添加";
            this.betGet.Press += new System.EventHandler(this.betGet_Press);
            // 
            // ListAssets
            // 
            this.ListAssets.BackColor = System.Drawing.Color.White;
            this.ListAssets.Location = new System.Drawing.Point(0, 245);
            this.ListAssets.Name = "ListAssets";
            this.ListAssets.PageSizeTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.ListAssets.PageSizeTextSize = 11F;
            this.ListAssets.ShowSplitLine = true;
            this.ListAssets.Size = new System.Drawing.Size(300, 180);
            this.ListAssets.SplitLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.ListAssets.TemplateControlName = "frmOrderCreateLayout";
            // 
            // popDealMan
            // 
            this.popDealMan.Name = "popDealMan";
            this.popDealMan.Selected += new System.EventHandler(this.popDealMan_Selected);
            // 
            // popDealInMan
            // 
            this.popDealInMan.Name = "popDealInMan";
            this.popDealInMan.Selected += new System.EventHandler(this.popDealInMan_Selected);
            // 
            // popLocation
            // 
            this.popLocation.Name = "popLocation";
            this.popLocation.Selected += new System.EventHandler(this.popLocation_Selected);
            // 
            // BarcodeScanner1
            // 
            this.BarcodeScanner1.Name = "BarcodeScanner1";
            this.BarcodeScanner1.BarcodeScanned += new Smobiler.Core.Controls.BarcodeScannerCallBackHandler(this.BarcodeScanner1_BarcodeScanned);
            // 
            // popConLoc
            // 
            this.popConLoc.Name = "popConLoc";
            this.popConLoc.Selected += new System.EventHandler(this.popConLoc_Selected);
            // 
            // frmTransferCreate
            // 
            this.Components.AddRange(new Smobiler.Core.Controls.MobileComponent[] {
            this.popDealMan,
            this.popDealInMan,
            this.popLocation,
            this.BarcodeScanner1,
            this.popConLoc});
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.title1,
            this.plButton,
            this.spContent});
            this.Orientation = Smobiler.Core.Controls.FormOrientation.Portrait;
            this.Statusbar = new Smobiler.Core.Controls.MobileFormStatusbar(Smobiler.Core.Controls.MobileFormStatusbarStyle.Default, System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(164)))), ((int)(((byte)(229))))));
            this.Name = "frmTransferCreate";

        }
        #endregion

        private UserControl.Title title1;
        private Smobiler.Core.Controls.Panel plButton;
        private Smobiler.Core.Controls.Button btnSave;
        internal Smobiler.Core.Controls.Panel spContent;
        private Smobiler.Core.Controls.Panel plTDInMan;
        private Smobiler.Core.Controls.Label label1;
        internal Smobiler.Core.Controls.Button btnDealInMan;
        private Smobiler.Core.Controls.Panel plDate;
        private Smobiler.Core.Controls.Label label5;
        private Smobiler.Core.Controls.DatePicker DatePicker;
        private Smobiler.Core.Controls.Panel plLocation;
        private Smobiler.Core.Controls.Label label2;
        internal Smobiler.Core.Controls.Button btnLocation;
        private Smobiler.Core.Controls.Panel plNote;
        private Smobiler.Core.Controls.Label label6;
        private Smobiler.Core.Controls.TextBox txtNote;
        private Smobiler.Core.Controls.Panel plTDMan;
        private Smobiler.Core.Controls.Label Label3;
        internal Smobiler.Core.Controls.Button btnDealMan;
        internal Smobiler.Core.Controls.Panel plAdd;
        internal Smobiler.Core.Controls.Button btnAdd;
        internal Smobiler.Core.Controls.Button betGet;
        private Smobiler.Core.Controls.ListView ListAssets;
        internal Smobiler.Core.Controls.PopList popDealMan;
        internal Smobiler.Core.Controls.PopList popDealInMan;
        internal Smobiler.Core.Controls.PopList popLocation;
        internal Smobiler.Core.Controls.BarcodeScanner BarcodeScanner1;
        private Smobiler.Core.Controls.PopList popConLoc;
    }
}