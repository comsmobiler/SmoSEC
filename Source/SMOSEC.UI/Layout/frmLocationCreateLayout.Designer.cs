using System;
using Smobiler.Core;
namespace SMOSEC.UI.Layout
{
    partial class frmLocationCreateLayout : Smobiler.Core.Controls.MobileUserControl
    {
        #region "SmobilerUserControl generated code "

        public frmLocationCreateLayout()
            : base()
        {
            //This call is required by the SmobilerUserControl.
            InitializeComponent();

            //Add any initialization after the InitializeComponent() call
        }

        //SmobilerUserControl overrides dispose to clean up the component list.
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }


        //NOTE: The following procedure is required by the SmobilerUserControl
        //It can be modified using the SmobilerUserControl.  
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.Panel1 = new Smobiler.Core.Controls.Panel();
            this.Label1 = new Smobiler.Core.Controls.Label();
            this.Label2 = new Smobiler.Core.Controls.Label();
            this.Label3 = new Smobiler.Core.Controls.Label();
            this.Label4 = new Smobiler.Core.Controls.Label();
            this.txtID = new Smobiler.Core.Controls.TextBox();
            this.txtName = new Smobiler.Core.Controls.TextBox();
            this.btnCancel = new Smobiler.Core.Controls.Button();
            this.btnSave = new Smobiler.Core.Controls.Button();
            this.label5 = new Smobiler.Core.Controls.Label();
            this.btnManager = new Smobiler.Core.Controls.Button();
            this.popManager = new Smobiler.Core.Controls.PopList();
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(140)))), ((int)(((byte)(255)))));
            this.Panel1.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.Label1,
            this.Label2,
            this.Label3,
            this.Label4,
            this.txtID,
            this.txtName,
            this.btnCancel,
            this.btnSave,
            this.label5,
            this.btnManager});
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(280, 220);
            // 
            // Label1
            // 
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Center;
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(280, 35);
            this.Label1.Text = "区域管理";
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.Color.White;
            this.Label2.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.Label2.Location = new System.Drawing.Point(0, 35);
            this.Label2.Name = "Label2";
            this.Label2.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 5F, 0F);
            this.Label2.Size = new System.Drawing.Size(75, 50);
            this.Label2.Text = "区域编码";
            // 
            // Label3
            // 
            this.Label3.BackColor = System.Drawing.Color.White;
            this.Label3.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.Label3.Location = new System.Drawing.Point(0, 135);
            this.Label3.Name = "Label3";
            this.Label3.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 5F, 0F);
            this.Label3.Size = new System.Drawing.Size(75, 50);
            this.Label3.Text = "区域负责人";
            // 
            // Label4
            // 
            this.Label4.BackColor = System.Drawing.Color.White;
            this.Label4.Location = new System.Drawing.Point(75, 35);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(205, 150);
            // 
            // txtID
            // 
            this.txtID.Border = new Smobiler.Core.Controls.Border(1F);
            this.txtID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(140)))), ((int)(((byte)(255)))));
            this.txtID.BorderRadius = 4;
            this.txtID.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.txtID.Location = new System.Drawing.Point(75, 45);
            this.txtID.Name = "txtID";
            this.txtID.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 5F, 0F);
            this.txtID.Size = new System.Drawing.Size(195, 30);
            this.txtID.WaterMarkText = "区域编码";
            // 
            // txtName
            // 
            this.txtName.Border = new Smobiler.Core.Controls.Border(1F);
            this.txtName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(140)))), ((int)(((byte)(255)))));
            this.txtName.BorderRadius = 4;
            this.txtName.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.txtName.Location = new System.Drawing.Point(75, 95);
            this.txtName.Name = "txtName";
            this.txtName.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 5F, 0F);
            this.txtName.Size = new System.Drawing.Size(195, 30);
            this.txtName.WaterMarkText = "区域名称";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.Border = new Smobiler.Core.Controls.Border(0F, 1F, 1F, 0F);
            this.btnCancel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnCancel.BorderRadius = 0;
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(0, 185);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(140, 35);
            this.btnCancel.Text = "取消";
            this.btnCancel.Press += new System.EventHandler(this.btnCancel_Press);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.btnSave.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnSave.BorderRadius = 0;
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(140)))), ((int)(((byte)(255)))));
            this.btnSave.Location = new System.Drawing.Point(140, 185);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(140, 35);
            this.btnSave.Text = "确定";
            this.btnSave.Press += new System.EventHandler(this.btnSave_Press);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.label5.Location = new System.Drawing.Point(0, 85);
            this.label5.Name = "label5";
            this.label5.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 5F, 0F);
            this.label5.Size = new System.Drawing.Size(75, 50);
            this.label5.Text = "区域名称";
            // 
            // btnManager
            // 
            this.btnManager.BackColor = System.Drawing.Color.Transparent;
            this.btnManager.Border = new Smobiler.Core.Controls.Border(1F);
            this.btnManager.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(140)))), ((int)(((byte)(255)))));
            this.btnManager.BorderRadius = 4;
            this.btnManager.ForeColor = System.Drawing.Color.Black;
            this.btnManager.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.btnManager.Location = new System.Drawing.Point(75, 145);
            this.btnManager.Name = "btnManager";
            this.btnManager.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 5F, 0F);
            this.btnManager.Size = new System.Drawing.Size(195, 30);
            this.btnManager.Text = "选择（必填）   > ";
            this.btnManager.Press += new System.EventHandler(this.btnManager_Press);
            // 
            // popManager
            // 
            this.popManager.Name = "popManager";
            this.popManager.Selected += new System.EventHandler(this.popManager_Selected);
            // 
            // frmLocationCreateLayout
            // 
            this.BorderRadius = 8;
            this.Components.AddRange(new Smobiler.Core.Controls.MobileComponent[] {
            this.popManager});
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.Panel1});
            this.Size = new System.Drawing.Size(280, 220);
            this.Load += new System.EventHandler(this.frmLocationCreateLayout_Load);
            this.Name = "frmLocationCreateLayout";

        }
        #endregion

        internal Smobiler.Core.Controls.Panel Panel1;
        internal Smobiler.Core.Controls.Label Label1;
        internal Smobiler.Core.Controls.Label Label2;
        internal Smobiler.Core.Controls.Label Label3;
        internal Smobiler.Core.Controls.Label Label4;
        internal Smobiler.Core.Controls.TextBox txtID;
        internal Smobiler.Core.Controls.TextBox txtName;
        internal Smobiler.Core.Controls.Button btnCancel;
        internal Smobiler.Core.Controls.Button btnSave;
        internal Smobiler.Core.Controls.Label label5;
        internal Smobiler.Core.Controls.Button btnManager;
        internal Smobiler.Core.Controls.PopList popManager;
    }
}