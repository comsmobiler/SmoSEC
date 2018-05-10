using System;
using Smobiler.Core;
namespace SMOSEC.UI.Layout
{
    partial class frmLcoationRowsLayout : Smobiler.Core.Controls.MobileUserControl
    {
        #region "SmobilerUserControl generated code "

        public frmLcoationRowsLayout()
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
            this.lblName = new Smobiler.Core.Controls.Label();
            this.plEdit = new Smobiler.Core.Controls.Panel();
            this.FontIcon2 = new Smobiler.Core.Controls.FontIcon();
            this.Label1 = new Smobiler.Core.Controls.Label();
            this.Image1 = new Smobiler.Core.Controls.Image();
            this.plEnable = new Smobiler.Core.Controls.Panel();
            this.lblEnable = new Smobiler.Core.Controls.Label();
            this.image2 = new Smobiler.Core.Controls.Image();
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.White;
            this.Panel1.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.lblName,
            this.plEdit,
            this.Image1,
            this.plEnable});
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(300, 50);
            this.Panel1.Touchable = true;
            // 
            // lblName
            // 
            this.lblName.DataMember = "LOCATIONID";
            this.lblName.DisplayMember = "NAME";
            this.lblName.Location = new System.Drawing.Point(30, 0);
            this.lblName.Name = "lblName";
            this.lblName.Padding = new Smobiler.Core.Controls.Padding(5F, 0F, 0F, 0F);
            this.lblName.Size = new System.Drawing.Size(170, 50);
            // 
            // plEdit
            // 
            this.plEdit.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.FontIcon2,
            this.Label1});
            this.plEdit.Location = new System.Drawing.Point(200, 0);
            this.plEdit.Name = "plEdit";
            this.plEdit.Size = new System.Drawing.Size(50, 50);
            this.plEdit.Touchable = true;
            this.plEdit.Press += new System.EventHandler(this.plEdit_Press);
            // 
            // FontIcon2
            // 
            this.FontIcon2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(181)))), ((int)(((byte)(231)))));
            this.FontIcon2.Location = new System.Drawing.Point(1, 15);
            this.FontIcon2.Name = "FontIcon2";
            this.FontIcon2.ResourceID = "pencil";
            this.FontIcon2.Size = new System.Drawing.Size(19, 19);
            // 
            // Label1
            // 
            this.Label1.ForeColor = System.Drawing.Color.DimGray;
            this.Label1.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Center;
            this.Label1.Location = new System.Drawing.Point(20, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(30, 50);
            this.Label1.Text = "±‡º≠";
            // 
            // Image1
            // 
            this.Image1.Location = new System.Drawing.Point(5, 12);
            this.Image1.Name = "Image1";
            this.Image1.ResourceID = "quyu";
            this.Image1.Size = new System.Drawing.Size(25, 25);
            // 
            // plEnable
            // 
            this.plEnable.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.lblEnable,
            this.image2});
            this.plEnable.Location = new System.Drawing.Point(250, 0);
            this.plEnable.Name = "plEnable";
            this.plEnable.Size = new System.Drawing.Size(50, 50);
            this.plEnable.Touchable = true;
            this.plEnable.Press += new System.EventHandler(this.plEnable_Press);
            // 
            // lblEnable
            // 
            this.lblEnable.DisplayMember = "TEXTENABLE";
            this.lblEnable.ForeColor = System.Drawing.Color.DimGray;
            this.lblEnable.Location = new System.Drawing.Point(20, 0);
            this.lblEnable.Name = "lblEnable";
            this.lblEnable.Size = new System.Drawing.Size(30, 50);
            this.lblEnable.Text = "∆Ù”√";
            // 
            // image2
            // 
            this.image2.DisplayMember = "IMGENABLE";
            this.image2.Location = new System.Drawing.Point(1, 15);
            this.image2.Name = "image2";
            this.image2.ResourceID = "on";
            this.image2.Size = new System.Drawing.Size(18, 19);
            // 
            // frmLcoationRowsLayout
            // 
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.Panel1});
            this.Size = new System.Drawing.Size(0, 50);
            this.Name = "frmLcoationRowsLayout";

        }
        #endregion

        internal Smobiler.Core.Controls.Panel Panel1;
        internal Smobiler.Core.Controls.Label lblName;
        internal Smobiler.Core.Controls.Panel plEdit;
        internal Smobiler.Core.Controls.FontIcon FontIcon2;
        internal Smobiler.Core.Controls.Label Label1;
        internal Smobiler.Core.Controls.Image Image1;
        internal Smobiler.Core.Controls.Panel plEnable;
        internal Smobiler.Core.Controls.Label lblEnable;
        private Smobiler.Core.Controls.Image image2;
    }
}