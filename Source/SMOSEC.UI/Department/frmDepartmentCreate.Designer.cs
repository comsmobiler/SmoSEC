using System;
using Smobiler.Core;
namespace SMOSEC.UI.Department
{
    partial class frmDepartmentCreate : Smobiler.Core.Controls.MobileForm
    {
        #region "SmobilerForm generated code "

        public frmDepartmentCreate()
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
            this.popLeader = new Smobiler.Core.Controls.PopList();
            this.cameraPortrait = new Smobiler.Core.Controls.Camera();
            this.title1 = new SMOSEC.UI.UserControl.Title();
            this.panel1 = new Smobiler.Core.Controls.Panel();
            this.label3 = new Smobiler.Core.Controls.Label();
            this.btnLeader = new Smobiler.Core.Controls.Button();
            this.btnSave = new Smobiler.Core.Controls.Button();
            this.btnUp = new Smobiler.Core.Controls.Button();
            this.Label4 = new Smobiler.Core.Controls.Label();
            this.txtDep_Name = new Smobiler.Core.Controls.TextBox();
            this.label5 = new Smobiler.Core.Controls.Label();
            this.label6 = new Smobiler.Core.Controls.Label();
            this.imgPortrait = new Smobiler.Core.Controls.Image();
            this.btnAssignUser = new Smobiler.Core.Controls.Button();
            // 
            // popLeader
            // 
            this.popLeader.Name = "popLeader";
            this.popLeader.Selected += new System.EventHandler(this.popLeader_Selected);
            // 
            // cameraPortrait
            // 
            this.cameraPortrait.Name = "cameraPortrait";
            this.cameraPortrait.ImageCaptured += new Smobiler.Core.Controls.CameraOnlineCallBackHandler(this.cameraPortrait_ImageCaptured);
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
            this.title1.Size = new System.Drawing.Size(100, 40);
            this.title1.TitleText = "部门";
            // 
            // panel1
            // 
            this.panel1.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.label3,
            this.btnLeader,
            this.btnSave,
            this.btnUp,
            this.Label4,
            this.txtDep_Name,
            this.label5,
            this.label6,
            this.imgPortrait,
            this.btnAssignUser});
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Name = "panel1";
            this.panel1.Scrollable = true;
            this.panel1.Size = new System.Drawing.Size(300, 100);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 1F);
            this.label3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.label3.Location = new System.Drawing.Point(0, 100);
            this.label3.Name = "label3";
            this.label3.Padding = new Smobiler.Core.Controls.Padding(4F, 0F, 0F, 0F);
            this.label3.Size = new System.Drawing.Size(66, 35);
            this.label3.Text = "责任人";
            // 
            // btnLeader
            // 
            this.btnLeader.BackColor = System.Drawing.Color.White;
            this.btnLeader.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 1F);
            this.btnLeader.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnLeader.BorderRadius = 0;
            this.btnLeader.FontSize = 12F;
            this.btnLeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))));
            this.btnLeader.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.btnLeader.Location = new System.Drawing.Point(66, 100);
            this.btnLeader.Name = "btnLeader";
            this.btnLeader.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 4F, 0F);
            this.btnLeader.Size = new System.Drawing.Size(234, 35);
            this.btnLeader.Text = "选择（必填）   > ";
            this.btnLeader.Press += new System.EventHandler(this.btnLeader_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(146)))), ((int)(((byte)(223)))));
            this.btnSave.BorderRadius = 4;
            this.btnSave.FontSize = 17F;
            this.btnSave.Location = new System.Drawing.Point(10, 190);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(280, 35);
            this.btnSave.Text = "下一步";
            this.btnSave.Press += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUp
            // 
            this.btnUp.BackColor = System.Drawing.Color.White;
            this.btnUp.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 1F);
            this.btnUp.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnUp.BorderRadius = 0;
            this.btnUp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))));
            this.btnUp.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.btnUp.Location = new System.Drawing.Point(275, 55);
            this.btnUp.Name = "btnUp";
            this.btnUp.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 4F, 0F);
            this.btnUp.Size = new System.Drawing.Size(25, 35);
            this.btnUp.Text = ">";
            this.btnUp.Press += new System.EventHandler(this.btnUp_Click);
            // 
            // Label4
            // 
            this.Label4.BackColor = System.Drawing.Color.White;
            this.Label4.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 1F);
            this.Label4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.Label4.Location = new System.Drawing.Point(0, 10);
            this.Label4.Name = "Label4";
            this.Label4.Padding = new Smobiler.Core.Controls.Padding(4F, 0F, 0F, 0F);
            this.Label4.Size = new System.Drawing.Size(66, 35);
            this.Label4.Text = "部门名称";
            this.Label4.ZIndex = 1;
            // 
            // txtDep_Name
            // 
            this.txtDep_Name.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 1F);
            this.txtDep_Name.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.txtDep_Name.FontSize = 12F;
            this.txtDep_Name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))));
            this.txtDep_Name.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.txtDep_Name.Location = new System.Drawing.Point(66, 10);
            this.txtDep_Name.Name = "txtDep_Name";
            this.txtDep_Name.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 4F, 0F);
            this.txtDep_Name.ReturnKeyType = Smobiler.Core.Controls.ReturnKeyType.Done;
            this.txtDep_Name.Size = new System.Drawing.Size(234, 35);
            this.txtDep_Name.WaterMarkText = "（必填）";
            this.txtDep_Name.ZIndex = 2;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 1F);
            this.label5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.label5.Location = new System.Drawing.Point(0, 55);
            this.label5.Name = "label5";
            this.label5.Padding = new Smobiler.Core.Controls.Padding(4F, 0F, 0F, 0F);
            this.label5.Size = new System.Drawing.Size(66, 35);
            this.label5.Text = "部门头像";
            this.label5.ZIndex = 3;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 1F);
            this.label6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.label6.Location = new System.Drawing.Point(66, 55);
            this.label6.Name = "label6";
            this.label6.Padding = new Smobiler.Core.Controls.Padding(4F, 0F, 0F, 0F);
            this.label6.Size = new System.Drawing.Size(209, 35);
            this.label6.ZIndex = 4;
            // 
            // imgPortrait
            // 
            this.imgPortrait.BorderRadius = 10;
            this.imgPortrait.Location = new System.Drawing.Point(242, 57);
            this.imgPortrait.Name = "imgPortrait";
            this.imgPortrait.ResourceID = "bumenicon";
            this.imgPortrait.Size = new System.Drawing.Size(31, 31);
            this.imgPortrait.SizeMode = Smobiler.Core.Controls.ImageSizeMode.Stretch;
            this.imgPortrait.ZIndex = 5;
            // 
            // btnAssignUser
            // 
            this.btnAssignUser.BackColor = System.Drawing.Color.White;
            this.btnAssignUser.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 1F);
            this.btnAssignUser.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnAssignUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(146)))), ((int)(((byte)(223)))));
            this.btnAssignUser.Location = new System.Drawing.Point(0, 145);
            this.btnAssignUser.Name = "btnAssignUser";
            this.btnAssignUser.Size = new System.Drawing.Size(300, 35);
            this.btnAssignUser.Text = "分配部门人员";
            this.btnAssignUser.Press += new System.EventHandler(this.btnAssignUser_Click);
            // 
            // frmDepartmentCreate
            // 
            this.Components.AddRange(new Smobiler.Core.Controls.MobileComponent[] {
            this.cameraPortrait,
            this.popLeader});
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.title1,
            this.panel1});
            this.Orientation = Smobiler.Core.Controls.FormOrientation.Portrait;
            this.Statusbar = new Smobiler.Core.Controls.MobileFormStatusbar(Smobiler.Core.Controls.MobileFormStatusbarStyle.Default, System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(164)))), ((int)(((byte)(229))))));
            this.KeyDown += new Smobiler.Core.Controls.KeyDownEventHandler(this.frmDepartmentCreate_KeyDown);
            this.Load += new System.EventHandler(this.frmDepartmentCreate_Load);
            this.Name = "frmDepartmentCreate";

        }
        #endregion
        private Smobiler.Core.Controls.PopList popLeader;
        private Smobiler.Core.Controls.Camera cameraPortrait;
        private SMOSEC.UI.UserControl.Title title1;
        private Smobiler.Core.Controls.Panel panel1;
        internal Smobiler.Core.Controls.Label label3;
        internal Smobiler.Core.Controls.Button btnLeader;
        private Smobiler.Core.Controls.Button btnSave;
        internal Smobiler.Core.Controls.Button btnUp;
        internal Smobiler.Core.Controls.Label Label4;
        internal Smobiler.Core.Controls.TextBox txtDep_Name;
        internal Smobiler.Core.Controls.Label label5;
        internal Smobiler.Core.Controls.Label label6;
        private Smobiler.Core.Controls.Image imgPortrait;
        private Smobiler.Core.Controls.Button btnAssignUser;
    }
}