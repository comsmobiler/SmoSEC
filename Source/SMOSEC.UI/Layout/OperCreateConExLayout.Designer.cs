using System;
using Smobiler.Core;
namespace SMOSEC.UI.Layout
{
    partial class OperCreateConExLayout : Smobiler.Core.Controls.MobileUserControl
    {
        #region "SmobilerUserControl generated code "

        public OperCreateConExLayout()
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
            this.lblCId = new Smobiler.Core.Controls.Label();
            this.LblName = new Smobiler.Core.Controls.Label();
            this.LblType = new Smobiler.Core.Controls.Label();
            this.numMoney = new Smobiler.Core.Controls.Numeric();
            this.label1 = new Smobiler.Core.Controls.Label();
            this.txtRNote = new Smobiler.Core.Controls.TextBox();
            this.numQuant = new Smobiler.Core.Controls.Numeric();
            this.label2 = new Smobiler.Core.Controls.Label();
            this.lblQuant = new Smobiler.Core.Controls.Label();
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.White;
            this.Panel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Panel1.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.Image,
            this.Label3,
            this.Label4,
            this.lblCId,
            this.LblName,
            this.LblType,
            this.numMoney,
            this.label1,
            this.txtRNote,
            this.numQuant,
            this.label2,
            this.lblQuant});
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(300, 136);
            this.Panel1.Touchable = true;
            this.Panel1.LongPress += new System.EventHandler(this.Panel1_LongPress);
            // 
            // Image
            // 
            this.Image.DataMember = "IMAGE";
            this.Image.DisplayMember = "IMAGE";
            this.Image.Location = new System.Drawing.Point(8, 8);
            this.Image.Name = "Image";
            this.Image.Size = new System.Drawing.Size(120, 120);
            this.Image.SizeMode = Smobiler.Core.Controls.ImageSizeMode.Cover;
            // 
            // Label3
            // 
            this.Label3.BackColor = System.Drawing.Color.White;
            this.Label3.Location = new System.Drawing.Point(128, 68);
            this.Label3.Name = "Label3";
            this.Label3.Padding = new Smobiler.Core.Controls.Padding(4F, 0F, 0F, 0F);
            this.Label3.Size = new System.Drawing.Size(58, 20);
            this.Label3.Text = "数量";
            // 
            // Label4
            // 
            this.Label4.BackColor = System.Drawing.Color.White;
            this.Label4.Location = new System.Drawing.Point(128, 88);
            this.Label4.Name = "Label4";
            this.Label4.Padding = new Smobiler.Core.Controls.Padding(4F, 0F, 0F, 0F);
            this.Label4.Size = new System.Drawing.Size(58, 20);
            this.Label4.Text = "金额";
            // 
            // lblCId
            // 
            this.lblCId.BackColor = System.Drawing.Color.White;
            this.lblCId.DataMember = "CID";
            this.lblCId.DisplayMember = "CID";
            this.lblCId.Location = new System.Drawing.Point(128, 8);
            this.lblCId.Name = "lblCId";
            this.lblCId.Padding = new Smobiler.Core.Controls.Padding(4F, 0F, 0F, 0F);
            this.lblCId.Size = new System.Drawing.Size(161, 20);
            this.lblCId.Text = "资产条码";
            // 
            // LblName
            // 
            this.LblName.BackColor = System.Drawing.Color.White;
            this.LblName.DataMember = "NAME";
            this.LblName.DisplayMember = "NAME";
            this.LblName.Location = new System.Drawing.Point(128, 28);
            this.LblName.Name = "LblName";
            this.LblName.Padding = new Smobiler.Core.Controls.Padding(4F, 0F, 0F, 0F);
            this.LblName.Size = new System.Drawing.Size(161, 20);
            this.LblName.Text = "资产条码";
            // 
            // LblType
            // 
            this.LblType.BackColor = System.Drawing.Color.White;
            this.LblType.DataMember = "TYPE";
            this.LblType.DisplayMember = "TYPE";
            this.LblType.Location = new System.Drawing.Point(276, 68);
            this.LblType.Name = "LblType";
            this.LblType.Padding = new Smobiler.Core.Controls.Padding(10F, 0F, 0F, 0F);
            this.LblType.Size = new System.Drawing.Size(13, 20);
            this.LblType.Text = "资产条码";
            this.LblType.Visible = false;
            // 
            // numMoney
            // 
            this.numMoney.DataMember = "MONEY";
            this.numMoney.DisplayFormat = null;
            this.numMoney.DisplayMember = "MONEY";
            this.numMoney.FontSize = 13F;
            this.numMoney.Location = new System.Drawing.Point(186, 88);
            this.numMoney.MaxValue = 999999F;
            this.numMoney.MinusIconColor = System.Drawing.Color.Black;
            this.numMoney.Name = "numMoney";
            this.numMoney.Size = new System.Drawing.Size(90, 20);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(128, 108);
            this.label1.Name = "label1";
            this.label1.Padding = new Smobiler.Core.Controls.Padding(4F, 0F, 0F, 0F);
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.Text = "备注";
            // 
            // txtRNote
            // 
            this.txtRNote.Location = new System.Drawing.Point(186, 108);
            this.txtRNote.Name = "txtRNote";
            this.txtRNote.Size = new System.Drawing.Size(103, 20);
            // 
            // numQuant
            // 
            this.numQuant.DataMember = "QUANTITY";
            this.numQuant.DisplayFormat = null;
            this.numQuant.DisplayMember = "QUANTITY";
            this.numQuant.FontSize = 13F;
            this.numQuant.Location = new System.Drawing.Point(186, 68);
            this.numQuant.MaxValue = 999999F;
            this.numQuant.MinusIconColor = System.Drawing.Color.Black;
            this.numQuant.Name = "numQuant";
            this.numQuant.Size = new System.Drawing.Size(90, 20);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(128, 48);
            this.label2.Name = "label2";
            this.label2.Padding = new Smobiler.Core.Controls.Padding(4F, 0F, 0F, 0F);
            this.label2.Size = new System.Drawing.Size(58, 20);
            this.label2.Text = "库存";
            // 
            // lblQuant
            // 
            this.lblQuant.BackColor = System.Drawing.Color.White;
            this.lblQuant.DataMember = "QUANT";
            this.lblQuant.DisplayMember = "QUANT";
            this.lblQuant.Location = new System.Drawing.Point(186, 48);
            this.lblQuant.Name = "lblQuant";
            this.lblQuant.Padding = new Smobiler.Core.Controls.Padding(4F, 0F, 0F, 0F);
            this.lblQuant.Size = new System.Drawing.Size(103, 20);
            this.lblQuant.Text = "资产条码";
            // 
            // OperCreateConExLayout
            // 
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.Panel1});
            this.Size = new System.Drawing.Size(300, 136);
            this.Name = "OperCreateConExLayout";

        }
        #endregion

        internal Smobiler.Core.Controls.Panel Panel1;
        internal Smobiler.Core.Controls.Image Image;
        internal Smobiler.Core.Controls.Label Label3;
        internal Smobiler.Core.Controls.Label Label4;
        internal Smobiler.Core.Controls.Label lblCId;
        internal Smobiler.Core.Controls.Label LblName;
        internal Smobiler.Core.Controls.Label LblType;
        internal Smobiler.Core.Controls.Numeric numMoney;
        internal Smobiler.Core.Controls.Label label1;
        internal Smobiler.Core.Controls.Numeric numQuant;
        internal Smobiler.Core.Controls.Label label2;
        internal Smobiler.Core.Controls.Label lblQuant;
        internal Smobiler.Core.Controls.TextBox txtRNote;
    }
}