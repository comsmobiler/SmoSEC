using System;
using Smobiler.Core;
namespace SMOSEC.UI.Layout
{
    partial class OperCreateAssExLayout : Smobiler.Core.Controls.MobileUserControl
    {
        #region "SmobilerUserControl generated code "

        public OperCreateAssExLayout()
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
            this.plRow = new Smobiler.Core.Controls.Panel();
            this.Label1 = new Smobiler.Core.Controls.Label();
            this.Image = new Smobiler.Core.Controls.Image();
            this.Label2 = new Smobiler.Core.Controls.Label();
            this.Label3 = new Smobiler.Core.Controls.Label();
            this.lblASSID = new Smobiler.Core.Controls.Label();
            this.LblSN = new Smobiler.Core.Controls.Label();
            this.LblName = new Smobiler.Core.Controls.Label();
            this.LblType = new Smobiler.Core.Controls.Label();
            this.label4 = new Smobiler.Core.Controls.Label();
            this.lblCurrentUser = new Smobiler.Core.Controls.Label();
            // 
            // plRow
            // 
            this.plRow.BackColor = System.Drawing.Color.White;
            this.plRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.plRow.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.Label1,
            this.Image,
            this.Label2,
            this.Label3,
            this.lblASSID,
            this.LblSN,
            this.LblName,
            this.LblType,
            this.label4,
            this.lblCurrentUser});
            this.plRow.Name = "plRow";
            this.plRow.Size = new System.Drawing.Size(300, 96);
            this.plRow.Touchable = true;
            this.plRow.LongPress += new System.EventHandler(this.Panel1_LongPress);
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.Color.White;
            this.Label1.FontSize = 12F;
            this.Label1.Location = new System.Drawing.Point(88, 28);
            this.Label1.Name = "Label1";
            this.Label1.Padding = new Smobiler.Core.Controls.Padding(4F, 0F, 0F, 0F);
            this.Label1.Size = new System.Drawing.Size(63, 20);
            this.Label1.Text = "资产条码";
            // 
            // Image
            // 
            this.Image.DataMember = "IMAGE";
            this.Image.DisplayMember = "IMAGE";
            this.Image.Location = new System.Drawing.Point(8, 8);
            this.Image.Name = "Image";
            this.Image.Size = new System.Drawing.Size(80, 80);
            this.Image.SizeMode = Smobiler.Core.Controls.ImageSizeMode.Cover;
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.Color.White;
            this.Label2.FontSize = 12F;
            this.Label2.Location = new System.Drawing.Point(88, 48);
            this.Label2.Name = "Label2";
            this.Label2.Padding = new Smobiler.Core.Controls.Padding(4F, 0F, 0F, 0F);
            this.Label2.Size = new System.Drawing.Size(63, 20);
            this.Label2.Text = "资产名称";
            // 
            // Label3
            // 
            this.Label3.BackColor = System.Drawing.Color.White;
            this.Label3.FontSize = 12F;
            this.Label3.Location = new System.Drawing.Point(88, 8);
            this.Label3.Name = "Label3";
            this.Label3.Padding = new Smobiler.Core.Controls.Padding(4F, 0F, 0F, 0F);
            this.Label3.Size = new System.Drawing.Size(63, 20);
            this.Label3.Text = "SN号";
            // 
            // lblASSID
            // 
            this.lblASSID.BackColor = System.Drawing.Color.White;
            this.lblASSID.DataMember = "ASSID";
            this.lblASSID.DisplayMember = "ASSID";
            this.lblASSID.FontSize = 12F;
            this.lblASSID.Location = new System.Drawing.Point(151, 28);
            this.lblASSID.Name = "lblASSID";
            this.lblASSID.Padding = new Smobiler.Core.Controls.Padding(10F, 0F, 0F, 0F);
            this.lblASSID.Size = new System.Drawing.Size(138, 20);
            this.lblASSID.Text = "资产条码";
            // 
            // LblSN
            // 
            this.LblSN.BackColor = System.Drawing.Color.White;
            this.LblSN.DataMember = "SN";
            this.LblSN.DisplayMember = "SN";
            this.LblSN.FontSize = 12F;
            this.LblSN.Location = new System.Drawing.Point(151, 8);
            this.LblSN.Name = "LblSN";
            this.LblSN.Padding = new Smobiler.Core.Controls.Padding(10F, 0F, 0F, 0F);
            this.LblSN.Size = new System.Drawing.Size(138, 20);
            this.LblSN.Text = "资产条码";
            // 
            // LblName
            // 
            this.LblName.BackColor = System.Drawing.Color.White;
            this.LblName.DataMember = "NAME";
            this.LblName.DisplayMember = "NAME";
            this.LblName.FontSize = 12F;
            this.LblName.Location = new System.Drawing.Point(151, 48);
            this.LblName.Name = "LblName";
            this.LblName.Padding = new Smobiler.Core.Controls.Padding(10F, 0F, 0F, 0F);
            this.LblName.Size = new System.Drawing.Size(138, 20);
            this.LblName.Text = "资产条码";
            // 
            // LblType
            // 
            this.LblType.DataMember = "TYPE";
            this.LblType.DisplayMember = "TYPE";
            this.LblType.Location = new System.Drawing.Point(291, 10);
            this.LblType.Name = "LblType";
            this.LblType.Size = new System.Drawing.Size(5, 35);
            this.LblType.Text = "Label4";
            this.LblType.Visible = false;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.FontSize = 12F;
            this.label4.Location = new System.Drawing.Point(88, 68);
            this.label4.Name = "label4";
            this.label4.Padding = new Smobiler.Core.Controls.Padding(4F, 0F, 0F, 0F);
            this.label4.Size = new System.Drawing.Size(63, 20);
            this.label4.Text = "持有人";
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.BackColor = System.Drawing.Color.White;
            this.lblCurrentUser.DataMember = "USERNAME";
            this.lblCurrentUser.DisplayMember = "USERNAME";
            this.lblCurrentUser.FontSize = 12F;
            this.lblCurrentUser.Location = new System.Drawing.Point(151, 68);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Padding = new Smobiler.Core.Controls.Padding(10F, 0F, 0F, 0F);
            this.lblCurrentUser.Size = new System.Drawing.Size(138, 20);
            this.lblCurrentUser.Text = "资产条码";
            // 
            // OperCreateAssExLayout
            // 
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.plRow});
            this.Size = new System.Drawing.Size(300, 96);
            this.Name = "OperCreateAssExLayout";

        }
        #endregion

        internal Smobiler.Core.Controls.Panel plRow;
        internal Smobiler.Core.Controls.Label Label1;
        internal Smobiler.Core.Controls.Image Image;
        internal Smobiler.Core.Controls.Label Label2;
        internal Smobiler.Core.Controls.Label Label3;
        internal Smobiler.Core.Controls.Label lblASSID;
        internal Smobiler.Core.Controls.Label LblSN;
        internal Smobiler.Core.Controls.Label LblName;
        internal Smobiler.Core.Controls.Label LblType;
        internal Smobiler.Core.Controls.Label label4;
        internal Smobiler.Core.Controls.Label lblCurrentUser;
    }
}