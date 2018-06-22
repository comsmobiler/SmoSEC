using SMOSEC.UI.UserControl;

namespace SMOSEC.UI.ConsumablesManager
{
    partial class frmWRCreate : Smobiler.Core.Controls.MobileForm
    {
        #region "SmobilerForm generated code "

        public frmWRCreate()
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
            this.Label7 = new Smobiler.Core.Controls.Label();
            this.Label8 = new Smobiler.Core.Controls.Label();
            this.txtNote = new Smobiler.Core.Controls.TextBox();
            this.DPickerCO = new Smobiler.Core.Controls.DatePicker();
            this.Label4 = new Smobiler.Core.Controls.Label();
            this.btnLocation = new Smobiler.Core.Controls.Button();
            this.btnLocation1 = new Smobiler.Core.Controls.Button();
            this.txtVendor = new Smobiler.Core.Controls.TextBox();
            this.btnAdd = new Smobiler.Core.Controls.Button();
            this.txtHMan = new Smobiler.Core.Controls.TextBox();
            this.Panel4 = new Smobiler.Core.Controls.Panel();
            this.listViewCon = new Smobiler.Core.Controls.ListView();
            this.PopLocation = new Smobiler.Core.Controls.PopList();
            // 
            // Title1
            // 
            this.Title1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(164)))), ((int)(((byte)(229)))));
            this.Title1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Title1.FontSize = 15F;
            this.Title1.ForeColor = System.Drawing.Color.White;
            this.Title1.Name = "Title1";
            this.Title1.Size = new System.Drawing.Size(300, 40);
            this.Title1.TitleText = "入库单创建";
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
            this.Panel1.Flex = 1;
            this.Panel1.Location = new System.Drawing.Point(0, 40);
            this.Panel1.Name = "Panel1";
            this.Panel1.Scrollable = true;
            this.Panel1.Size = new System.Drawing.Size(300, 420);
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
            this.btnLocation,
            this.btnLocation1,
            this.txtVendor,
            this.btnAdd,
            this.txtHMan});
            this.Panel3.Flex = 1;
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(300, 195);
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
            // txtVendor
            // 
            this.txtVendor.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.txtVendor.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.txtVendor.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.txtVendor.Location = new System.Drawing.Point(100, 0);
            this.txtVendor.Name = "txtVendor";
            this.txtVendor.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 5F, 0F);
            this.txtVendor.Size = new System.Drawing.Size(200, 30);
            this.txtVendor.WaterMarkText = "(选填)";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(9, 160);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 30);
            this.btnAdd.Text = "添加行项";
            this.btnAdd.Press += new System.EventHandler(this.btnAdd_Press);
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
            // Panel4
            // 
            this.Panel4.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.listViewCon});
            this.Panel4.Flex = 1;
            this.Panel4.Location = new System.Drawing.Point(0, 195);
            this.Panel4.Name = "Panel4";
            this.Panel4.Size = new System.Drawing.Size(300, 225);
            // 
            // listViewCon
            // 
            this.listViewCon.BackColor = System.Drawing.Color.White;
            this.listViewCon.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.listViewCon.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.listViewCon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewCon.Location = new System.Drawing.Point(0, 2);
            this.listViewCon.Name = "listViewCon";
            this.listViewCon.PageSizeTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.listViewCon.PageSizeTextSize = 11F;
            this.listViewCon.ShowSplitLine = true;
            this.listViewCon.Size = new System.Drawing.Size(300, 185);
            this.listViewCon.SplitLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.listViewCon.TemplateControlName = "OperCreateConLayout";
            // 
            // PopLocation
            // 
            this.PopLocation.Name = "PopLocation";
            this.PopLocation.Selected += new System.EventHandler(this.PopLocation_Selected);
            // 
            // frmWRCreate
            // 
            this.Components.AddRange(new Smobiler.Core.Controls.MobileComponent[] {
            this.PopLocation});
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.Title1,
            this.Panel2,
            this.Panel1});
            this.Orientation = Smobiler.Core.Controls.FormOrientation.Portrait;
            this.Statusbar = new Smobiler.Core.Controls.MobileFormStatusbar(Smobiler.Core.Controls.MobileFormStatusbarStyle.Default, System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(164)))), ((int)(((byte)(229))))));
            this.KeyDown += new Smobiler.Core.Controls.KeyDownEventHandler(this.frmWRCreate_KeyDown);
            this.Load += new System.EventHandler(this.frmWRCreate_Load);
            this.Name = "frmWRCreate";

        }
        #endregion

        private UserControl.Title Title1;
        internal Smobiler.Core.Controls.Panel Panel2;
        internal Smobiler.Core.Controls.Button btnSave;
        internal Smobiler.Core.Controls.Panel Panel1;
        internal Smobiler.Core.Controls.Panel Panel3;
        internal Smobiler.Core.Controls.Label Label1;
        internal Smobiler.Core.Controls.Label Label2;
        internal Smobiler.Core.Controls.Label Label7;
        internal Smobiler.Core.Controls.Label Label8;
        internal Smobiler.Core.Controls.TextBox txtNote;
        internal Smobiler.Core.Controls.DatePicker DPickerCO;
        internal Smobiler.Core.Controls.Label Label4;
        internal Smobiler.Core.Controls.Button btnLocation;
        internal Smobiler.Core.Controls.Button btnLocation1;
        internal Smobiler.Core.Controls.Panel Panel4;
        private Smobiler.Core.Controls.ListView listViewCon;
        internal Smobiler.Core.Controls.TextBox txtVendor;
        private Smobiler.Core.Controls.Button btnAdd;
        internal Smobiler.Core.Controls.PopList PopLocation;
        internal Smobiler.Core.Controls.TextBox txtHMan;
    }
}