using System;
using Smobiler.Core;
namespace SMOSEC.UI.Layout
{
    partial class OperDetailAssLayout : Smobiler.Core.Controls.MobileUserControl
    {
        #region "SmobilerUserControl generated code "

        public OperDetailAssLayout()
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
            this.Image = new Smobiler.Core.Controls.Image();
            this.Label2 = new Smobiler.Core.Controls.Label();
            this.Label3 = new Smobiler.Core.Controls.Label();
            this.lblASSID = new Smobiler.Core.Controls.Label();
            this.LblSN = new Smobiler.Core.Controls.Label();
            this.LblName = new Smobiler.Core.Controls.Label();
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.White;
            this.Panel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Panel1.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.Label1,
            this.Image,
            this.Label2,
            this.Label3,
            this.lblASSID,
            this.LblSN,
            this.LblName});
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(300, 76);
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.Color.White;
            this.Label1.FontSize = 12F;
            this.Label1.Location = new System.Drawing.Point(66, 28);
            this.Label1.Name = "Label1";
            this.Label1.Padding = new Smobiler.Core.Controls.Padding(4F, 0F, 0F, 0F);
            this.Label1.Size = new System.Drawing.Size(73, 20);
            this.Label1.Text = "资产条码";
            // 
            // Image
            // 
            this.Image.DataMember = "IMAGE";
            this.Image.DisplayMember = "IMAGE";
            this.Image.Location = new System.Drawing.Point(6, 8);
            this.Image.Name = "Image";
            this.Image.Size = new System.Drawing.Size(60, 60);
            this.Image.SizeMode = Smobiler.Core.Controls.ImageSizeMode.Cover;
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.Color.White;
            this.Label2.FontSize = 12F;
            this.Label2.Location = new System.Drawing.Point(66, 48);
            this.Label2.Name = "Label2";
            this.Label2.Padding = new Smobiler.Core.Controls.Padding(4F, 0F, 0F, 0F);
            this.Label2.Size = new System.Drawing.Size(73, 20);
            this.Label2.Text = "资产名称";
            // 
            // Label3
            // 
            this.Label3.BackColor = System.Drawing.Color.White;
            this.Label3.FontSize = 12F;
            this.Label3.Location = new System.Drawing.Point(66, 8);
            this.Label3.Name = "Label3";
            this.Label3.Padding = new Smobiler.Core.Controls.Padding(4F, 0F, 0F, 0F);
            this.Label3.Size = new System.Drawing.Size(73, 20);
            this.Label3.Text = "SN号";
            // 
            // lblASSID
            // 
            this.lblASSID.BackColor = System.Drawing.Color.White;
            this.lblASSID.DataMember = "ASSID";
            this.lblASSID.DisplayMember = "ASSID";
            this.lblASSID.FontSize = 12F;
            this.lblASSID.Location = new System.Drawing.Point(139, 28);
            this.lblASSID.Name = "lblASSID";
            this.lblASSID.Padding = new Smobiler.Core.Controls.Padding(10F, 0F, 0F, 0F);
            this.lblASSID.Size = new System.Drawing.Size(157, 20);
            this.lblASSID.Text = "资产条码";
            // 
            // LblSN
            // 
            this.LblSN.BackColor = System.Drawing.Color.White;
            this.LblSN.DataMember = "SN";
            this.LblSN.DisplayMember = "SN";
            this.LblSN.FontSize = 12F;
            this.LblSN.Location = new System.Drawing.Point(139, 8);
            this.LblSN.Name = "LblSN";
            this.LblSN.Padding = new Smobiler.Core.Controls.Padding(10F, 0F, 0F, 0F);
            this.LblSN.Size = new System.Drawing.Size(157, 20);
            this.LblSN.Text = "资产条码";
            // 
            // LblName
            // 
            this.LblName.BackColor = System.Drawing.Color.White;
            this.LblName.DataMember = "NAME";
            this.LblName.DisplayMember = "NAME";
            this.LblName.FontSize = 12F;
            this.LblName.Location = new System.Drawing.Point(139, 48);
            this.LblName.Name = "LblName";
            this.LblName.Padding = new Smobiler.Core.Controls.Padding(10F, 0F, 0F, 0F);
            this.LblName.Size = new System.Drawing.Size(157, 20);
            this.LblName.Text = "资产条码";
            // 
            // OperDetailAssLayout
            // 
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.Panel1});
            this.Size = new System.Drawing.Size(300, 76);
            this.Name = "OperDetailAssLayout";

        }
        #endregion

        internal Smobiler.Core.Controls.Panel Panel1;
        internal Smobiler.Core.Controls.Label Label1;
        internal Smobiler.Core.Controls.Image Image;
        internal Smobiler.Core.Controls.Label Label2;
        internal Smobiler.Core.Controls.Label Label3;
        internal Smobiler.Core.Controls.Label lblASSID;
        internal Smobiler.Core.Controls.Label LblSN;
        internal Smobiler.Core.Controls.Label LblName;
    }
}