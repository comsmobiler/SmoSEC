using System;
using Smobiler.Core;
namespace SMOSEC.UI.AssetsManager
{
    partial class frmRepairDetailSN : Smobiler.Core.Controls.MobileForm
    {
        #region "SmobilerForm generated code "

        public frmRepairDetailSN()
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
            this.plRDMan = new Smobiler.Core.Controls.Panel();
            this.label1 = new Smobiler.Core.Controls.Label();
            this.lblDealMan = new Smobiler.Core.Controls.Label();
            this.plDate = new Smobiler.Core.Controls.Panel();
            this.label5 = new Smobiler.Core.Controls.Label();
            this.DatePicker = new Smobiler.Core.Controls.DatePicker();
            this.plPrice = new Smobiler.Core.Controls.Panel();
            this.label2 = new Smobiler.Core.Controls.Label();
            this.label3 = new Smobiler.Core.Controls.Label();
            this.lblPrice = new Smobiler.Core.Controls.Label();
            this.plContent = new Smobiler.Core.Controls.Panel();
            this.label6 = new Smobiler.Core.Controls.Label();
            this.lblContent = new Smobiler.Core.Controls.Label();
            this.plNote = new Smobiler.Core.Controls.Panel();
            this.Label4 = new Smobiler.Core.Controls.Label();
            this.lblNote = new Smobiler.Core.Controls.Label();
            this.ListAssetsSN = new Smobiler.Core.Controls.ListView();
            // 
            // title1
            // 
            this.title1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(164)))), ((int)(((byte)(229)))));
            this.title1.Dock = System.Windows.Forms.DockStyle.Top;
            this.title1.FontSize = 15F;
            this.title1.ForeColor = System.Drawing.Color.White;
            this.title1.Location = new System.Drawing.Point(160, 50);
            this.title1.Name = "title1";
            this.title1.Size = new System.Drawing.Size(100, 40);
            this.title1.TitleText = "资产报修单详情";
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
            this.btnSave.Location = new System.Drawing.Point(20, 0);
            this.btnSave.Margin = new Smobiler.Core.Controls.Margin(0F, 0F, 10F, 0F);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(260, 35);
            this.btnSave.Text = "维修单确认";
            this.btnSave.Press += new System.EventHandler(this.btnSave_Press);
            // 
            // spContent
            // 
            this.spContent.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.plRDMan,
            this.plDate,
            this.plPrice,
            this.plContent,
            this.plNote,
            this.ListAssetsSN});
            this.spContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spContent.Flex = 10000;
            this.spContent.Location = new System.Drawing.Point(0, 110);
            this.spContent.Name = "spContent";
            this.spContent.Scrollable = true;
            this.spContent.Size = new System.Drawing.Size(300, 100);
            // 
            // plRDMan
            // 
            this.plRDMan.BackColor = System.Drawing.Color.White;
            this.plRDMan.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 1F);
            this.plRDMan.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.plRDMan.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.label1,
            this.lblDealMan});
            this.plRDMan.Name = "plRDMan";
            this.plRDMan.Size = new System.Drawing.Size(300, 35);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.label1.Name = "label1";
            this.label1.Padding = new Smobiler.Core.Controls.Padding(5F, 0F, 0F, 0F);
            this.label1.Size = new System.Drawing.Size(88, 35);
            this.label1.Text = "处理人";
            // 
            // lblDealMan
            // 
            this.lblDealMan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))));
            this.lblDealMan.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.lblDealMan.Location = new System.Drawing.Point(88, 0);
            this.lblDealMan.Name = "lblDealMan";
            this.lblDealMan.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 5F, 0F);
            this.lblDealMan.Size = new System.Drawing.Size(212, 35);
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
            this.DatePicker.Enabled = false;
            this.DatePicker.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))));
            this.DatePicker.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.DatePicker.Location = new System.Drawing.Point(88, 0);
            this.DatePicker.Name = "DatePicker";
            this.DatePicker.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 5F, 0F);
            this.DatePicker.Size = new System.Drawing.Size(212, 35);
            // 
            // plPrice
            // 
            this.plPrice.BackColor = System.Drawing.Color.White;
            this.plPrice.Border = new Smobiler.Core.Controls.Border(0F, 0F, 0F, 1F);
            this.plPrice.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.plPrice.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.label2,
            this.label3,
            this.lblPrice});
            this.plPrice.Location = new System.Drawing.Point(0, 70);
            this.plPrice.Name = "plPrice";
            this.plPrice.Size = new System.Drawing.Size(300, 35);
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.label2.Name = "label2";
            this.label2.Padding = new Smobiler.Core.Controls.Padding(5F, 0F, 0F, 0F);
            this.label2.Size = new System.Drawing.Size(88, 35);
            this.label2.Text = "维修花费";
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))));
            this.label3.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.label3.Location = new System.Drawing.Point(280, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 5F, 0F);
            this.label3.Size = new System.Drawing.Size(20, 35);
            this.label3.Text = "元";
            // 
            // lblPrice
            // 
            this.lblPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))));
            this.lblPrice.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.lblPrice.Location = new System.Drawing.Point(88, 0);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(192, 35);
            // 
            // plContent
            // 
            this.plContent.BackColor = System.Drawing.Color.White;
            this.plContent.Border = new Smobiler.Core.Controls.Border(0F, 0F, 0F, 1F);
            this.plContent.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.plContent.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.label6,
            this.lblContent});
            this.plContent.Location = new System.Drawing.Point(0, 105);
            this.plContent.Name = "plContent";
            this.plContent.Size = new System.Drawing.Size(300, 35);
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.label6.Name = "label6";
            this.label6.Padding = new Smobiler.Core.Controls.Padding(5F, 0F, 0F, 0F);
            this.label6.Size = new System.Drawing.Size(88, 35);
            this.label6.Text = "维修内容";
            // 
            // lblContent
            // 
            this.lblContent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))));
            this.lblContent.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.lblContent.Location = new System.Drawing.Point(88, 0);
            this.lblContent.Name = "lblContent";
            this.lblContent.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 5F, 0F);
            this.lblContent.Size = new System.Drawing.Size(212, 35);
            // 
            // plNote
            // 
            this.plNote.BackColor = System.Drawing.Color.White;
            this.plNote.Border = new Smobiler.Core.Controls.Border(0F, 0F, 0F, 1F);
            this.plNote.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.plNote.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.Label4,
            this.lblNote});
            this.plNote.Location = new System.Drawing.Point(0, 140);
            this.plNote.Name = "plNote";
            this.plNote.Size = new System.Drawing.Size(300, 35);
            // 
            // Label4
            // 
            this.Label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.Label4.Name = "Label4";
            this.Label4.Padding = new Smobiler.Core.Controls.Padding(5F, 0F, 0F, 0F);
            this.Label4.Size = new System.Drawing.Size(88, 35);
            this.Label4.Text = "备注";
            // 
            // lblNote
            // 
            this.lblNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))));
            this.lblNote.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.lblNote.Location = new System.Drawing.Point(88, 0);
            this.lblNote.Name = "lblNote";
            this.lblNote.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 5F, 0F);
            this.lblNote.Size = new System.Drawing.Size(212, 35);
            // 
            // ListAssetsSN
            // 
            this.ListAssetsSN.BackColor = System.Drawing.Color.White;
            this.ListAssetsSN.Location = new System.Drawing.Point(0, 185);
            this.ListAssetsSN.Name = "ListAssetsSN";
            this.ListAssetsSN.PageSizeTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.ListAssetsSN.PageSizeTextSize = 11F;
            this.ListAssetsSN.ShowSplitLine = true;
            this.ListAssetsSN.Size = new System.Drawing.Size(300, 240);
            this.ListAssetsSN.SplitLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.ListAssetsSN.TemplateControlName = "frmAssetsSNShowLayout";
            // 
            // frmRepairDetailSN
            // 
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.title1,
            this.plButton,
            this.spContent});
            this.Orientation = Smobiler.Core.Controls.FormOrientation.Portrait;
            this.Statusbar = new Smobiler.Core.Controls.MobileFormStatusbar(Smobiler.Core.Controls.MobileFormStatusbarStyle.Default, System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(164)))), ((int)(((byte)(229))))));
            this.Load += new System.EventHandler(this.frmRepairDetailSN_Load);
            this.Name = "frmRepairDetailSN";

        }
        #endregion

        private UserControl.Title title1;
        private Smobiler.Core.Controls.Panel plButton;
        private Smobiler.Core.Controls.Button btnSave;
        internal Smobiler.Core.Controls.Panel spContent;
        private Smobiler.Core.Controls.Panel plRDMan;
        private Smobiler.Core.Controls.Label label1;
        internal Smobiler.Core.Controls.Label lblDealMan;
        private Smobiler.Core.Controls.Panel plDate;
        private Smobiler.Core.Controls.Label label5;
        private Smobiler.Core.Controls.DatePicker DatePicker;
        private Smobiler.Core.Controls.Panel plPrice;
        private Smobiler.Core.Controls.Label label2;
        private Smobiler.Core.Controls.Label label3;
        internal Smobiler.Core.Controls.Label lblPrice;
        private Smobiler.Core.Controls.Panel plContent;
        private Smobiler.Core.Controls.Label label6;
        internal Smobiler.Core.Controls.Label lblContent;
        private Smobiler.Core.Controls.Panel plNote;
        private Smobiler.Core.Controls.Label Label4;
        internal Smobiler.Core.Controls.Label lblNote;
        private Smobiler.Core.Controls.ListView ListAssetsSN;
    }
}