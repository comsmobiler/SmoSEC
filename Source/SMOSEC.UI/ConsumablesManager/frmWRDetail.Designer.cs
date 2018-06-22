using SMOSEC.UI.UserControl;

namespace SMOSEC.UI.ConsumablesManager
{
    partial class frmWRDetail : Smobiler.Core.Controls.MobileForm
    {
        #region "SmobilerForm generated code "

        public frmWRDetail()
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
            this.Panel1 = new Smobiler.Core.Controls.Panel();
            this.Panel3 = new Smobiler.Core.Controls.Panel();
            this.Label1 = new Smobiler.Core.Controls.Label();
            this.Label2 = new Smobiler.Core.Controls.Label();
            this.Label7 = new Smobiler.Core.Controls.Label();
            this.Label8 = new Smobiler.Core.Controls.Label();
            this.txtNote = new Smobiler.Core.Controls.TextBox();
            this.DPickerCO = new Smobiler.Core.Controls.DatePicker();
            this.Label4 = new Smobiler.Core.Controls.Label();
            this.txtVendor = new Smobiler.Core.Controls.TextBox();
            this.txtHMan = new Smobiler.Core.Controls.TextBox();
            this.txtLocatin = new Smobiler.Core.Controls.TextBox();
            this.Panel4 = new Smobiler.Core.Controls.Panel();
            this.ListAss = new Smobiler.Core.Controls.ListView();
            // 
            // Title1
            // 
            this.Title1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(164)))), ((int)(((byte)(229)))));
            this.Title1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Title1.FontSize = 15F;
            this.Title1.ForeColor = System.Drawing.Color.White;
            this.Title1.Name = "Title1";
            this.Title1.Size = new System.Drawing.Size(300, 40);
            this.Title1.TitleText = "入库单详情";
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
            this.Label7,
            this.Label8,
            this.txtNote,
            this.DPickerCO,
            this.Label4,
            this.txtVendor,
            this.txtHMan,
            this.txtLocatin});
            this.Panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(300, 153);
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.Color.White;
            this.Label1.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.Label1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Label1.Name = "Label1";
            this.Label1.Padding = new Smobiler.Core.Controls.Padding(5F, 0F, 0F, 0F);
            this.Label1.Size = new System.Drawing.Size(100, 30);
            this.Label1.Text = "供应商";
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
            this.Label2.Text = "业务日期";
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
            this.Label7.Text = "入库区域";
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
            this.txtNote.ReadOnly = true;
            this.txtNote.Size = new System.Drawing.Size(200, 30);
            this.txtNote.WaterMarkText = "(选填)";
            // 
            // DPickerCO
            // 
            this.DPickerCO.BackColor = System.Drawing.Color.White;
            this.DPickerCO.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.DPickerCO.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.DPickerCO.Enabled = false;
            this.DPickerCO.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.DPickerCO.Location = new System.Drawing.Point(100, 30);
            this.DPickerCO.Name = "DPickerCO";
            this.DPickerCO.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 5F, 0F);
            this.DPickerCO.Size = new System.Drawing.Size(200, 30);
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
            this.Label4.Text = "入库处理人";
            // 
            // txtVendor
            // 
            this.txtVendor.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.txtVendor.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.txtVendor.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.txtVendor.Location = new System.Drawing.Point(100, 0);
            this.txtVendor.Name = "txtVendor";
            this.txtVendor.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 5F, 0F);
            this.txtVendor.ReadOnly = true;
            this.txtVendor.Size = new System.Drawing.Size(200, 30);
            this.txtVendor.WaterMarkText = "(选填)";
            // 
            // txtHMan
            // 
            this.txtHMan.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.txtHMan.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.txtHMan.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.txtHMan.Location = new System.Drawing.Point(100, 90);
            this.txtHMan.Name = "txtHMan";
            this.txtHMan.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 5F, 0F);
            this.txtHMan.ReadOnly = true;
            this.txtHMan.Size = new System.Drawing.Size(200, 30);
            this.txtHMan.WaterMarkText = "(选填)";
            // 
            // txtLocatin
            // 
            this.txtLocatin.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.txtLocatin.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.txtLocatin.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.txtLocatin.Location = new System.Drawing.Point(100, 60);
            this.txtLocatin.Name = "txtLocatin";
            this.txtLocatin.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 5F, 0F);
            this.txtLocatin.ReadOnly = true;
            this.txtLocatin.Size = new System.Drawing.Size(200, 30);
            this.txtLocatin.WaterMarkText = "(选填)";
            // 
            // Panel4
            // 
            this.Panel4.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.ListAss});
            this.Panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel4.Location = new System.Drawing.Point(0, 153);
            this.Panel4.Name = "Panel4";
            this.Panel4.Size = new System.Drawing.Size(300, 307);
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
            this.ListAss.TemplateControlName = "OperDetailConLayout";
            // 
            // frmWRDetail
            // 
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.Title1,
            this.Panel1});
            this.Orientation = Smobiler.Core.Controls.FormOrientation.Portrait;
            this.Statusbar = new Smobiler.Core.Controls.MobileFormStatusbar(Smobiler.Core.Controls.MobileFormStatusbarStyle.Default, System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(164)))), ((int)(((byte)(229))))));
            this.KeyDown += new Smobiler.Core.Controls.KeyDownEventHandler(this.frmWRDetail_KeyDown);
            this.Load += new System.EventHandler(this.frmWRDetail_Load);
            this.Name = "frmWRDetail";

        }
        #endregion

        private UserControl.Title Title1;
        internal Smobiler.Core.Controls.Panel Panel1;
        internal Smobiler.Core.Controls.Panel Panel3;
        internal Smobiler.Core.Controls.Label Label1;
        internal Smobiler.Core.Controls.Label Label2;
        internal Smobiler.Core.Controls.Label Label7;
        internal Smobiler.Core.Controls.Label Label8;
        internal Smobiler.Core.Controls.TextBox txtNote;
        internal Smobiler.Core.Controls.DatePicker DPickerCO;
        internal Smobiler.Core.Controls.Label Label4;
        internal Smobiler.Core.Controls.TextBox txtVendor;
        internal Smobiler.Core.Controls.Panel Panel4;
        private Smobiler.Core.Controls.ListView ListAss;
        internal Smobiler.Core.Controls.TextBox txtHMan;
        internal Smobiler.Core.Controls.TextBox txtLocatin;
    }
}