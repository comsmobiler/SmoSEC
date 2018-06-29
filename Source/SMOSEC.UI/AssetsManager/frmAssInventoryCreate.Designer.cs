using System;
using Smobiler.Core;
namespace SMOSEC.UI.AssetsManager
{
    partial class frmAssInventoryCreate : Smobiler.Core.Controls.MobileForm
    {
        #region "SmobilerForm generated code "

        public frmAssInventoryCreate()
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
            this.panel1 = new Smobiler.Core.Controls.Panel();
            this.button1 = new Smobiler.Core.Controls.Button();
            this.panel3 = new Smobiler.Core.Controls.Panel();
            this.Label7 = new Smobiler.Core.Controls.Label();
            this.txtName = new Smobiler.Core.Controls.TextBox();
            this.label1 = new Smobiler.Core.Controls.Label();
            this.label2 = new Smobiler.Core.Controls.Label();
            this.label3 = new Smobiler.Core.Controls.Label();
            this.label4 = new Smobiler.Core.Controls.Label();
            this.btnLocation = new Smobiler.Core.Controls.Button();
            this.btnManager = new Smobiler.Core.Controls.Button();
            this.btnType = new Smobiler.Core.Controls.Button();
            this.btnDep = new Smobiler.Core.Controls.Button();
            this.popMan = new Smobiler.Core.Controls.PopList();
            this.popLocation = new Smobiler.Core.Controls.PopList();
            this.popType = new Smobiler.Core.Controls.PopList();
            this.popDep = new Smobiler.Core.Controls.PopList();
            // 
            // Title1
            // 
            this.Title1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(164)))), ((int)(((byte)(229)))));
            this.Title1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Title1.FontSize = 15F;
            this.Title1.ForeColor = System.Drawing.Color.White;
            this.Title1.Name = "Title1";
            this.Title1.Size = new System.Drawing.Size(300, 40);
            this.Title1.TitleText = "资产盘点单创建";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.panel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.panel1.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.button1});
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 468);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 40);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(56, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(176, 30);
            this.button1.Text = "确定";
            this.button1.Press += new System.EventHandler(this.btnSave_Press);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.Label7,
            this.txtName,
            this.label1,
            this.label2,
            this.label3,
            this.label4,
            this.btnLocation,
            this.btnManager,
            this.btnType,
            this.btnDep});
            this.panel3.Flex = 1;
            this.panel3.Location = new System.Drawing.Point(0, 40);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(300, 150);
            // 
            // Label7
            // 
            this.Label7.BackColor = System.Drawing.Color.White;
            this.Label7.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.Label7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Label7.Name = "Label7";
            this.Label7.Padding = new Smobiler.Core.Controls.Padding(5F, 0F, 0F, 0F);
            this.Label7.Size = new System.Drawing.Size(100, 30);
            this.Label7.Text = "盘点单名称";
            // 
            // txtName
            // 
            this.txtName.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.txtName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.txtName.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.txtName.Location = new System.Drawing.Point(100, 0);
            this.txtName.Name = "txtName";
            this.txtName.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 5F, 0F);
            this.txtName.Size = new System.Drawing.Size(200, 30);
            this.txtName.WaterMarkText = "（必填）";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.label1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.label1.Location = new System.Drawing.Point(0, 90);
            this.label1.Name = "label1";
            this.label1.Padding = new Smobiler.Core.Controls.Padding(5F, 0F, 0F, 0F);
            this.label1.Size = new System.Drawing.Size(100, 30);
            this.label1.Text = "类型";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 1F);
            this.label2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.label2.Location = new System.Drawing.Point(0, 120);
            this.label2.Name = "label2";
            this.label2.Padding = new Smobiler.Core.Controls.Padding(5F, 0F, 0F, 0F);
            this.label2.Size = new System.Drawing.Size(100, 30);
            this.label2.Text = "部门";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.label3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.label3.Location = new System.Drawing.Point(0, 60);
            this.label3.Name = "label3";
            this.label3.Padding = new Smobiler.Core.Controls.Padding(5F, 0F, 0F, 0F);
            this.label3.Size = new System.Drawing.Size(100, 30);
            this.label3.Text = "区域";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.label4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.label4.Location = new System.Drawing.Point(0, 30);
            this.label4.Name = "label4";
            this.label4.Padding = new Smobiler.Core.Controls.Padding(5F, 0F, 0F, 0F);
            this.label4.Size = new System.Drawing.Size(100, 30);
            this.label4.Text = "盘点人";
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
            this.btnLocation.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 5F, 0F);
            this.btnLocation.Size = new System.Drawing.Size(200, 30);
            this.btnLocation.Text = "选择（必填）   > ";
            this.btnLocation.Press += new System.EventHandler(this.btnLocation_Press);
            // 
            // btnManager
            // 
            this.btnManager.BackColor = System.Drawing.Color.White;
            this.btnManager.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.btnManager.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnManager.BorderRadius = 0;
            this.btnManager.ForeColor = System.Drawing.Color.Black;
            this.btnManager.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.btnManager.Location = new System.Drawing.Point(100, 30);
            this.btnManager.Name = "btnManager";
            this.btnManager.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 5F, 0F);
            this.btnManager.Size = new System.Drawing.Size(200, 30);
            this.btnManager.Text = "选择（必填）   > ";
            this.btnManager.Press += new System.EventHandler(this.btnManager_Press);
            // 
            // btnType
            // 
            this.btnType.BackColor = System.Drawing.Color.White;
            this.btnType.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.btnType.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnType.BorderRadius = 0;
            this.btnType.ForeColor = System.Drawing.Color.Black;
            this.btnType.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.btnType.Location = new System.Drawing.Point(100, 90);
            this.btnType.Name = "btnType";
            this.btnType.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 5F, 0F);
            this.btnType.Size = new System.Drawing.Size(200, 30);
            this.btnType.Text = "选择（选填）   > ";
            this.btnType.Press += new System.EventHandler(this.btnType_Press);
            // 
            // btnDep
            // 
            this.btnDep.BackColor = System.Drawing.Color.White;
            this.btnDep.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 1F);
            this.btnDep.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnDep.BorderRadius = 0;
            this.btnDep.ForeColor = System.Drawing.Color.Black;
            this.btnDep.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.btnDep.Location = new System.Drawing.Point(100, 120);
            this.btnDep.Name = "btnDep";
            this.btnDep.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 5F, 0F);
            this.btnDep.Size = new System.Drawing.Size(200, 30);
            this.btnDep.Text = "选择（选填）   > ";
            this.btnDep.Press += new System.EventHandler(this.btnDep_Press);
            // 
            // popMan
            // 
            this.popMan.Name = "popMan";
            this.popMan.Selected += new System.EventHandler(this.popMan_Selected);
            // 
            // popLocation
            // 
            this.popLocation.Name = "popLocation";
            this.popLocation.Selected += new System.EventHandler(this.popLocation_Selected);
            // 
            // popType
            // 
            this.popType.Name = "popType";
            this.popType.Selected += new System.EventHandler(this.popType_Selected);
            // 
            // popDep
            // 
            this.popDep.Name = "popDep";
            this.popDep.Selected += new System.EventHandler(this.popDep_Selected);
            // 
            // frmAssInventoryCreate
            // 
            this.Components.AddRange(new Smobiler.Core.Controls.MobileComponent[] {
            this.popMan,
            this.popLocation,
            this.popType,
            this.popDep});
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.Title1,
            this.panel1,
            this.panel3});
            this.Orientation = Smobiler.Core.Controls.FormOrientation.Portrait;
            this.Statusbar = new Smobiler.Core.Controls.MobileFormStatusbar(Smobiler.Core.Controls.MobileFormStatusbarStyle.Default, System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(164)))), ((int)(((byte)(229))))));
            this.Load += new System.EventHandler(this.frmAssInventoryCreate_Load);
            this.Name = "frmAssInventoryCreate";

        }
        #endregion

        private UserControl.Title Title1;
        internal Smobiler.Core.Controls.Panel panel1;
        internal Smobiler.Core.Controls.Button button1;
        private Smobiler.Core.Controls.Panel panel3;
        internal Smobiler.Core.Controls.Label Label7;
        internal Smobiler.Core.Controls.TextBox txtName;
        internal Smobiler.Core.Controls.Label label1;
        internal Smobiler.Core.Controls.Label label2;
        internal Smobiler.Core.Controls.Label label3;
        internal Smobiler.Core.Controls.Label label4;
        internal Smobiler.Core.Controls.Button btnLocation;
        internal Smobiler.Core.Controls.Button btnManager;
        internal Smobiler.Core.Controls.Button btnType;
        internal Smobiler.Core.Controls.Button btnDep;
        private Smobiler.Core.Controls.PopList popMan;
        private Smobiler.Core.Controls.PopList popLocation;
        private Smobiler.Core.Controls.PopList popType;
        private Smobiler.Core.Controls.PopList popDep;
    }
}