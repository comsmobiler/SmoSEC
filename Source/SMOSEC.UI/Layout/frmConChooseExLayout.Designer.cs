using System;
using Smobiler.Core;
namespace SMOSEC.UI.Layout
{
    partial class frmConChooseExLayout : Smobiler.Core.Controls.MobileUserControl
    {
        #region "SmobilerUserControl generated code "

        public frmConChooseExLayout()
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
            this.CheckBox1 = new Smobiler.Core.Controls.CheckBox();
            this.Label1 = new Smobiler.Core.Controls.Label();
            this.Image = new Smobiler.Core.Controls.Image();
            this.Label3 = new Smobiler.Core.Controls.Label();
            this.lblName = new Smobiler.Core.Controls.Label();
            this.LblCId = new Smobiler.Core.Controls.Label();
            this.label2 = new Smobiler.Core.Controls.Label();
            this.label4 = new Smobiler.Core.Controls.Label();
            this.numeric1 = new Smobiler.Core.Controls.Numeric();
            this.numeric2 = new Smobiler.Core.Controls.Numeric();
            this.label5 = new Smobiler.Core.Controls.Label();
            this.lblQuant = new Smobiler.Core.Controls.Label();
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.White;
            this.Panel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Panel1.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.CheckBox1,
            this.Label1,
            this.Image,
            this.Label3,
            this.lblName,
            this.LblCId,
            this.label2,
            this.label4,
            this.numeric1,
            this.numeric2,
            this.label5,
            this.lblQuant});
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(300, 116);
            // 
            // CheckBox1
            // 
            this.CheckBox1.DataMember = "IsChecked";
            this.CheckBox1.DisplayMember = "IsChecked";
            this.CheckBox1.Location = new System.Drawing.Point(8, 48);
            this.CheckBox1.Name = "CheckBox1";
            this.CheckBox1.Size = new System.Drawing.Size(20, 20);
            this.CheckBox1.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.Color.White;
            this.Label1.FontSize = 12F;
            this.Label1.Location = new System.Drawing.Point(135, 28);
            this.Label1.Name = "Label1";
            this.Label1.Padding = new Smobiler.Core.Controls.Padding(4F, 0F, 0F, 0F);
            this.Label1.Size = new System.Drawing.Size(57, 20);
            this.Label1.Text = "名称";
            // 
            // Image
            // 
            this.Image.DataMember = "IMAGE";
            this.Image.DisplayMember = "IMAGE";
            this.Image.Location = new System.Drawing.Point(35, 8);
            this.Image.Name = "Image";
            this.Image.Size = new System.Drawing.Size(100, 100);
            this.Image.SizeMode = Smobiler.Core.Controls.ImageSizeMode.Cover;
            // 
            // Label3
            // 
            this.Label3.BackColor = System.Drawing.Color.White;
            this.Label3.FontSize = 12F;
            this.Label3.Location = new System.Drawing.Point(135, 8);
            this.Label3.Name = "Label3";
            this.Label3.Padding = new Smobiler.Core.Controls.Padding(4F, 0F, 0F, 0F);
            this.Label3.Size = new System.Drawing.Size(57, 20);
            this.Label3.Text = "耗材编号";
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.Color.White;
            this.lblName.DataMember = "NAME";
            this.lblName.DisplayMember = "NAME";
            this.lblName.FontSize = 12F;
            this.lblName.Location = new System.Drawing.Point(192, 28);
            this.lblName.Name = "lblName";
            this.lblName.Padding = new Smobiler.Core.Controls.Padding(10F, 0F, 0F, 0F);
            this.lblName.Size = new System.Drawing.Size(104, 20);
            this.lblName.Text = "资产条码";
            // 
            // LblCId
            // 
            this.LblCId.BackColor = System.Drawing.Color.White;
            this.LblCId.DataMember = "CID";
            this.LblCId.DisplayMember = "CID";
            this.LblCId.FontSize = 12F;
            this.LblCId.Location = new System.Drawing.Point(192, 8);
            this.LblCId.Name = "LblCId";
            this.LblCId.Padding = new Smobiler.Core.Controls.Padding(10F, 0F, 0F, 0F);
            this.LblCId.Size = new System.Drawing.Size(104, 20);
            this.LblCId.Text = "资产条码";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.FontSize = 12F;
            this.label2.Location = new System.Drawing.Point(135, 48);
            this.label2.Name = "label2";
            this.label2.Padding = new Smobiler.Core.Controls.Padding(4F, 0F, 0F, 0F);
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.Text = "库存";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.FontSize = 12F;
            this.label4.Location = new System.Drawing.Point(135, 68);
            this.label4.Name = "label4";
            this.label4.Padding = new Smobiler.Core.Controls.Padding(4F, 0F, 0F, 0F);
            this.label4.Size = new System.Drawing.Size(57, 20);
            this.label4.Text = "数量";
            // 
            // numeric1
            // 
            this.numeric1.DataMember = "QUANTITY";
            this.numeric1.DisplayMember = "QUANTITY";
            this.numeric1.Location = new System.Drawing.Point(192, 68);
            this.numeric1.MaxValue = 999999F;
            this.numeric1.Name = "numeric1";
            this.numeric1.Size = new System.Drawing.Size(100, 20);
            // 
            // numeric2
            // 
            this.numeric2.DataMember = "MONEY";
            this.numeric2.DisplayMember = "MONEY";
            this.numeric2.Location = new System.Drawing.Point(192, 88);
            this.numeric2.MaxValue = 999999F;
            this.numeric2.Name = "numeric2";
            this.numeric2.Size = new System.Drawing.Size(100, 20);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.FontSize = 12F;
            this.label5.Location = new System.Drawing.Point(135, 88);
            this.label5.Name = "label5";
            this.label5.Padding = new Smobiler.Core.Controls.Padding(4F, 0F, 0F, 0F);
            this.label5.Size = new System.Drawing.Size(57, 20);
            this.label5.Text = "金额";
            // 
            // lblQuant
            // 
            this.lblQuant.BackColor = System.Drawing.Color.White;
            this.lblQuant.DataMember = "QUANT";
            this.lblQuant.DisplayMember = "QUANT";
            this.lblQuant.FontSize = 12F;
            this.lblQuant.Location = new System.Drawing.Point(192, 48);
            this.lblQuant.Name = "lblQuant";
            this.lblQuant.Padding = new Smobiler.Core.Controls.Padding(10F, 0F, 0F, 0F);
            this.lblQuant.Size = new System.Drawing.Size(104, 20);
            this.lblQuant.Text = "资产条码";
            // 
            // frmConChooseExLayout
            // 
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.Panel1});
            this.Size = new System.Drawing.Size(300, 116);
            this.Name = "frmConChooseExLayout";

        }
        #endregion

        internal Smobiler.Core.Controls.Panel Panel1;
        internal Smobiler.Core.Controls.CheckBox CheckBox1;
        internal Smobiler.Core.Controls.Label Label1;
        internal Smobiler.Core.Controls.Image Image;
        internal Smobiler.Core.Controls.Label Label3;
        internal Smobiler.Core.Controls.Label lblName;
        internal Smobiler.Core.Controls.Label LblCId;
        internal Smobiler.Core.Controls.Label label2;
        internal Smobiler.Core.Controls.Label label4;
        internal Smobiler.Core.Controls.Label label5;
        internal Smobiler.Core.Controls.Label lblQuant;
        internal Smobiler.Core.Controls.Numeric numeric1;
        internal Smobiler.Core.Controls.Numeric numeric2;
    }
}