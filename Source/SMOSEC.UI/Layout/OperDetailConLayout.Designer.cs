using System;
using Smobiler.Core;
namespace SMOSEC.UI.Layout
{
    partial class OperDetailConLayout : Smobiler.Core.Controls.MobileUserControl
    {
        #region "SmobilerUserControl generated code "

        public OperDetailConLayout()
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
            this.Image = new Smobiler.Core.Controls.Image();
            this.Label3 = new Smobiler.Core.Controls.Label();
            this.Label4 = new Smobiler.Core.Controls.Label();
            this.lblCID = new Smobiler.Core.Controls.Label();
            this.LblName = new Smobiler.Core.Controls.Label();
            this.label1 = new Smobiler.Core.Controls.Label();
            this.lblQuant = new Smobiler.Core.Controls.Label();
            this.lblMoney = new Smobiler.Core.Controls.Label();
            this.lblNote = new Smobiler.Core.Controls.Label();
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.White;
            this.Panel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Panel1.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.Image,
            this.Label3,
            this.Label4,
            this.lblCID,
            this.LblName,
            this.label1,
            this.lblQuant,
            this.lblMoney,
            this.lblNote});
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(300, 116);
            this.Panel1.Touchable = true;
            this.Panel1.LongPress += new System.EventHandler(this.Panel1_LongPress);
            // 
            // Image
            // 
            this.Image.DataMember = "IMAGE";
            this.Image.DisplayMember = "IMAGE";
            this.Image.Location = new System.Drawing.Point(8, 8);
            this.Image.Name = "Image";
            this.Image.Size = new System.Drawing.Size(99, 100);
            this.Image.SizeMode = Smobiler.Core.Controls.ImageSizeMode.Cover;
            // 
            // Label3
            // 
            this.Label3.BackColor = System.Drawing.Color.White;
            this.Label3.Location = new System.Drawing.Point(107, 48);
            this.Label3.Name = "Label3";
            this.Label3.Padding = new Smobiler.Core.Controls.Padding(4F, 0F, 0F, 0F);
            this.Label3.Size = new System.Drawing.Size(58, 20);
            this.Label3.Text = "数量";
            // 
            // Label4
            // 
            this.Label4.BackColor = System.Drawing.Color.White;
            this.Label4.Location = new System.Drawing.Point(107, 68);
            this.Label4.Name = "Label4";
            this.Label4.Padding = new Smobiler.Core.Controls.Padding(4F, 0F, 0F, 0F);
            this.Label4.Size = new System.Drawing.Size(58, 20);
            this.Label4.Text = "金额";
            // 
            // lblCID
            // 
            this.lblCID.BackColor = System.Drawing.Color.White;
            this.lblCID.DataMember = "CID";
            this.lblCID.DisplayMember = "CID";
            this.lblCID.Location = new System.Drawing.Point(107, 8);
            this.lblCID.Name = "lblCID";
            this.lblCID.Padding = new Smobiler.Core.Controls.Padding(4F, 0F, 0F, 0F);
            this.lblCID.Size = new System.Drawing.Size(182, 20);
            this.lblCID.Text = "资产条码";
            // 
            // LblName
            // 
            this.LblName.BackColor = System.Drawing.Color.White;
            this.LblName.DataMember = "NAME";
            this.LblName.DisplayMember = "NAME";
            this.LblName.Location = new System.Drawing.Point(107, 28);
            this.LblName.Name = "LblName";
            this.LblName.Padding = new Smobiler.Core.Controls.Padding(4F, 0F, 0F, 0F);
            this.LblName.Size = new System.Drawing.Size(182, 20);
            this.LblName.Text = "资产条码";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(107, 88);
            this.label1.Name = "label1";
            this.label1.Padding = new Smobiler.Core.Controls.Padding(4F, 0F, 0F, 0F);
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.Text = "备注";
            // 
            // lblQuant
            // 
            this.lblQuant.BackColor = System.Drawing.Color.White;
            this.lblQuant.DataMember = "QUANTITY";
            this.lblQuant.DisplayMember = "QUANTITY";
            this.lblQuant.Location = new System.Drawing.Point(165, 48);
            this.lblQuant.Name = "lblQuant";
            this.lblQuant.Padding = new Smobiler.Core.Controls.Padding(4F, 0F, 0F, 0F);
            this.lblQuant.Size = new System.Drawing.Size(124, 20);
            this.lblQuant.Text = "资产条码";
            // 
            // lblMoney
            // 
            this.lblMoney.BackColor = System.Drawing.Color.White;
            this.lblMoney.DataMember = "MONEY";
            this.lblMoney.DisplayMember = "MONEY";
            this.lblMoney.Location = new System.Drawing.Point(165, 68);
            this.lblMoney.Name = "lblMoney";
            this.lblMoney.Padding = new Smobiler.Core.Controls.Padding(4F, 0F, 0F, 0F);
            this.lblMoney.Size = new System.Drawing.Size(124, 20);
            this.lblMoney.Text = "资产条码";
            // 
            // lblNote
            // 
            this.lblNote.BackColor = System.Drawing.Color.White;
            this.lblNote.DataMember = "NOTE";
            this.lblNote.DisplayMember = "NOTE";
            this.lblNote.Location = new System.Drawing.Point(165, 88);
            this.lblNote.Name = "lblNote";
            this.lblNote.Padding = new Smobiler.Core.Controls.Padding(4F, 0F, 0F, 0F);
            this.lblNote.Size = new System.Drawing.Size(124, 20);
            this.lblNote.Text = "资产条码";
            // 
            // OperDetailConLayout
            // 
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.Panel1});
            this.Size = new System.Drawing.Size(300, 116);
            this.Name = "OperDetailConLayout";

        }
        #endregion

        internal Smobiler.Core.Controls.Panel Panel1;
        internal Smobiler.Core.Controls.Image Image;
        internal Smobiler.Core.Controls.Label Label3;
        internal Smobiler.Core.Controls.Label Label4;
        internal Smobiler.Core.Controls.Label lblCID;
        internal Smobiler.Core.Controls.Label LblName;
        internal Smobiler.Core.Controls.Label label1;
        internal Smobiler.Core.Controls.Label lblQuant;
        internal Smobiler.Core.Controls.Label lblMoney;
        internal Smobiler.Core.Controls.Label lblNote;
    }
}