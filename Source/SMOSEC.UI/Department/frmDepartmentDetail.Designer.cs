using System;
using Smobiler.Core;
namespace SMOSEC.UI.Department
{
    partial class frmDepartmentDetail : Smobiler.Core.Controls.MobileForm
    {
        #region "SmobilerForm generated code "

        public frmDepartmentDetail()
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
            this.panel1 = new Smobiler.Core.Controls.Panel();
            this.btnEdit = new Smobiler.Core.Controls.Button();
            this.btnDelete = new Smobiler.Core.Controls.Button();
            this.panel2 = new Smobiler.Core.Controls.Panel();
            this.Label4 = new Smobiler.Core.Controls.Label();
            this.lblName = new Smobiler.Core.Controls.Label();
            this.label1 = new Smobiler.Core.Controls.Label();
            this.label6 = new Smobiler.Core.Controls.Label();
            this.imgPortrait = new Smobiler.Core.Controls.Image();
            this.label5 = new Smobiler.Core.Controls.Label();
            this.lblLeader = new Smobiler.Core.Controls.Label();
            this.gridUserData = new Smobiler.Core.Controls.ListView();
            // 
            // title1
            // 
            this.title1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.title1.Direction = Smobiler.Core.Controls.LayoutDirection.Row;
            this.title1.Dock = System.Windows.Forms.DockStyle.Top;
            this.title1.FontSize = 15F;
            this.title1.ForeColor = System.Drawing.Color.White;
            this.title1.Location = new System.Drawing.Point(111, 36);
            this.title1.Name = "title1";
            this.title1.Size = new System.Drawing.Size(100, 50);
            this.title1.TitleText = "部门";
            // 
            // panel1
            // 
            this.panel1.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.btnEdit,
            this.btnDelete});
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 461);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(100, 50);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(146)))), ((int)(((byte)(223)))));
            this.btnEdit.BorderRadius = 4;
            this.btnEdit.FontSize = 17F;
            this.btnEdit.Location = new System.Drawing.Point(10, 10);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(134, 35);
            this.btnEdit.Text = "编辑";
            this.btnEdit.Press += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(158)))), ((int)(((byte)(38)))));
            this.btnDelete.BorderRadius = 4;
            this.btnDelete.FontSize = 17F;
            this.btnDelete.Location = new System.Drawing.Point(156, 10);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(134, 35);
            this.btnDelete.Text = "删除";
            this.btnDelete.Press += new System.EventHandler(this.btnDelete_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.Label4,
            this.lblName,
            this.label1,
            this.label6,
            this.imgPortrait,
            this.label5,
            this.lblLeader,
            this.gridUserData});
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 50);
            this.panel2.Name = "panel2";
            this.panel2.Scrollable = true;
            this.panel2.Size = new System.Drawing.Size(300, 100);
            // 
            // Label4
            // 
            this.Label4.BackColor = System.Drawing.Color.White;
            this.Label4.Border = new Smobiler.Core.Controls.Border(0F, 0F, 0F, 1F);
            this.Label4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.Label4.Name = "Label4";
            this.Label4.Padding = new Smobiler.Core.Controls.Padding(4F, 0F, 0F, 0F);
            this.Label4.Size = new System.Drawing.Size(66, 35);
            this.Label4.Text = "部门名称";
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.Color.White;
            this.lblName.Border = new Smobiler.Core.Controls.Border(0F, 0F, 0F, 1F);
            this.lblName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblName.FontSize = 12F;
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))));
            this.lblName.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.lblName.Location = new System.Drawing.Point(66, 0);
            this.lblName.Name = "lblName";
            this.lblName.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 4F, 0F);
            this.lblName.Size = new System.Drawing.Size(234, 35);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 1F);
            this.label1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.label1.Location = new System.Drawing.Point(0, 45);
            this.label1.Name = "label1";
            this.label1.Padding = new Smobiler.Core.Controls.Padding(4F, 0F, 0F, 0F);
            this.label1.Size = new System.Drawing.Size(66, 35);
            this.label1.Text = "部门头像";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 1F);
            this.label6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.label6.Location = new System.Drawing.Point(66, 45);
            this.label6.Name = "label6";
            this.label6.Padding = new Smobiler.Core.Controls.Padding(4F, 0F, 0F, 0F);
            this.label6.Size = new System.Drawing.Size(234, 35);
            this.label6.ZIndex = 4;
            // 
            // imgPortrait
            // 
            this.imgPortrait.BorderRadius = 10;
            this.imgPortrait.Location = new System.Drawing.Point(266, 47);
            this.imgPortrait.Name = "imgPortrait";
            this.imgPortrait.ResourceID = "bumenicon";
            this.imgPortrait.Size = new System.Drawing.Size(30, 30);
            this.imgPortrait.SizeMode = Smobiler.Core.Controls.ImageSizeMode.Stretch;
            this.imgPortrait.ZIndex = 5;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 1F);
            this.label5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.label5.Location = new System.Drawing.Point(0, 90);
            this.label5.Name = "label5";
            this.label5.Padding = new Smobiler.Core.Controls.Padding(4F, 0F, 0F, 0F);
            this.label5.Size = new System.Drawing.Size(66, 35);
            this.label5.Text = "责任人";
            // 
            // lblLeader
            // 
            this.lblLeader.BackColor = System.Drawing.Color.White;
            this.lblLeader.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 1F);
            this.lblLeader.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblLeader.FontSize = 12F;
            this.lblLeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))));
            this.lblLeader.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.lblLeader.Location = new System.Drawing.Point(66, 90);
            this.lblLeader.Name = "lblLeader";
            this.lblLeader.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 4F, 0F);
            this.lblLeader.Size = new System.Drawing.Size(234, 35);
            // 
            // gridUserData
            // 
            this.gridUserData.BackColor = System.Drawing.Color.White;
            this.gridUserData.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.gridUserData.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.gridUserData.FooterControlName = null;
            this.gridUserData.HeaderControlName = null;
            this.gridUserData.Location = new System.Drawing.Point(0, 135);
            this.gridUserData.Name = "gridUserData";
            this.gridUserData.PageSize = 10;
            this.gridUserData.PageSizeTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.gridUserData.PageSizeTextSize = 11F;
            this.gridUserData.ShowSplitLine = true;
            this.gridUserData.Size = new System.Drawing.Size(300, 265);
            this.gridUserData.SplitLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.gridUserData.TemplateControlName = "frmUserLayout";
            // 
            // frmDepartmentDetail
            // 
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.title1,
            this.panel1,
            this.panel2});
            this.Orientation = Smobiler.Core.Controls.FormOrientation.Portrait;
            this.Statusbar = new Smobiler.Core.Controls.MobileFormStatusbar(Smobiler.Core.Controls.MobileFormStatusbarStyle.Default, System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(164)))), ((int)(((byte)(229))))));
            this.KeyDown += new Smobiler.Core.Controls.KeyDownEventHandler(this.frmDepartmentDetail_KeyDown);
            this.Load += new System.EventHandler(this.frmDepartmentDetail_Load);
            this.Name = "frmDepartmentDetail";

        }
        #endregion
        private SMOSEC.UI.UserControl.Title title1;
        private Smobiler.Core.Controls.Panel panel1;
        private Smobiler.Core.Controls.Button btnEdit;
        private Smobiler.Core.Controls.Button btnDelete;
        private Smobiler.Core.Controls.Panel panel2;
        internal Smobiler.Core.Controls.Label Label4;
        internal Smobiler.Core.Controls.Label lblName;
        internal Smobiler.Core.Controls.Label label1;
        internal Smobiler.Core.Controls.Label label6;
        private Smobiler.Core.Controls.Image imgPortrait;
        internal Smobiler.Core.Controls.Label label5;
        internal Smobiler.Core.Controls.Label lblLeader;
        private Smobiler.Core.Controls.ListView gridUserData;
    }
}