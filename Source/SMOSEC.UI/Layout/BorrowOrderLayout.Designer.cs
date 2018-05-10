using System;
using Smobiler.Core;
namespace SMOSEC.UI.Layout
{
    partial class BorrowOrderLayout : Smobiler.Core.Controls.MobileUserControl
    {
        #region "SmobilerUserControl generated code "

        public BorrowOrderLayout()
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
            this.Label5 = new Smobiler.Core.Controls.Label();
            this.LblID = new Smobiler.Core.Controls.Label();
            this.LblBMan = new Smobiler.Core.Controls.Label();
            this.LblDate = new Smobiler.Core.Controls.Label();
            this.LblLocation = new Smobiler.Core.Controls.Label();
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.White;
            this.Panel1.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.Panel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Panel1.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.Label1,
            this.Label2,
            this.Label3,
            this.Label5,
            this.LblID,
            this.LblBMan,
            this.LblDate,
            this.LblLocation});
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(300, 76);
            this.Panel1.Touchable = true;
            this.Panel1.Press += new System.EventHandler(this.Panel1_Press);
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(10, 8);
            this.Label1.Name = "Label1";
            this.Label1.Padding = new Smobiler.Core.Controls.Padding(10F, 0F, 0F, 0F);
            this.Label1.Size = new System.Drawing.Size(46, 20);
            this.Label1.Text = "单号";
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.Color.White;
            this.Label2.Location = new System.Drawing.Point(165, 8);
            this.Label2.Name = "Label2";
            this.Label2.Padding = new Smobiler.Core.Controls.Padding(10F, 0F, 0F, 0F);
            this.Label2.Size = new System.Drawing.Size(66, 20);
            this.Label2.Text = "借用人";
            // 
            // Label3
            // 
            this.Label3.BackColor = System.Drawing.Color.White;
            this.Label3.Location = new System.Drawing.Point(10, 28);
            this.Label3.Name = "Label3";
            this.Label3.Padding = new Smobiler.Core.Controls.Padding(10F, 0F, 0F, 0F);
            this.Label3.Size = new System.Drawing.Size(46, 20);
            this.Label3.Text = "日期";
            // 
            // Label5
            // 
            this.Label5.BackColor = System.Drawing.Color.White;
            this.Label5.Location = new System.Drawing.Point(10, 48);
            this.Label5.Name = "Label5";
            this.Label5.Padding = new Smobiler.Core.Controls.Padding(10F, 0F, 0F, 0F);
            this.Label5.Size = new System.Drawing.Size(46, 20);
            this.Label5.Text = "来源";
            // 
            // LblID
            // 
            this.LblID.DataMember = "BOID";
            this.LblID.DisplayMember = "BOID";
            this.LblID.Location = new System.Drawing.Point(56, 8);
            this.LblID.Name = "LblID";
            this.LblID.Padding = new Smobiler.Core.Controls.Padding(10F, 0F, 0F, 0F);
            this.LblID.Size = new System.Drawing.Size(109, 20);
            // 
            // LblBMan
            // 
            this.LblBMan.DataMember = "BORROWER";
            this.LblBMan.DisplayMember = "BORROWER";
            this.LblBMan.Location = new System.Drawing.Point(231, 8);
            this.LblBMan.Name = "LblBMan";
            this.LblBMan.Padding = new Smobiler.Core.Controls.Padding(10F, 0F, 0F, 0F);
            this.LblBMan.Size = new System.Drawing.Size(59, 20);
            // 
            // LblDate
            // 
            this.LblDate.DataMember = "BORROWDATE";
            this.LblDate.DisplayMember = "BORROWDATE";
            this.LblDate.Location = new System.Drawing.Point(56, 28);
            this.LblDate.Name = "LblDate";
            this.LblDate.Padding = new Smobiler.Core.Controls.Padding(10F, 0F, 0F, 0F);
            this.LblDate.Size = new System.Drawing.Size(234, 20);
            // 
            // LblLocation
            // 
            this.LblLocation.DataMember = "LOCATIONNAME";
            this.LblLocation.DisplayMember = "LOCATIONNAME";
            this.LblLocation.Location = new System.Drawing.Point(56, 48);
            this.LblLocation.Name = "LblLocation";
            this.LblLocation.Padding = new Smobiler.Core.Controls.Padding(10F, 0F, 0F, 0F);
            this.LblLocation.Size = new System.Drawing.Size(234, 20);
            // 
            // BorrowOrderLayout
            // 
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.Panel1});
            this.Size = new System.Drawing.Size(300, 76);
            this.Name = "BorrowOrderLayout";

        }
        #endregion

        internal Smobiler.Core.Controls.Panel Panel1;
        internal Smobiler.Core.Controls.Label Label1;
        internal Smobiler.Core.Controls.Label Label2;
        internal Smobiler.Core.Controls.Label Label3;
        internal Smobiler.Core.Controls.Label Label5;
        internal Smobiler.Core.Controls.Label LblID;
        internal Smobiler.Core.Controls.Label LblBMan;
        internal Smobiler.Core.Controls.Label LblDate;
        internal Smobiler.Core.Controls.Label LblLocation;
    }
}