using System;
using Smobiler.Core;
namespace SMOSEC.UI.Layout
{
    partial class frmDepartmentLayout : Smobiler.Core.Controls.MobileUserControl
    {
        #region "SmobilerForm generated code "

        public frmDepartmentLayout()
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
            this.panel1 = new Smobiler.Core.Controls.Panel();
            this.imgPortrait = new Smobiler.Core.Controls.Image();
            this.lblId = new Smobiler.Core.Controls.Label();
            this.label1 = new Smobiler.Core.Controls.Label();
            // 
            // panel1
            // 
            this.panel1.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.imgPortrait,
            this.lblId,
            this.label1});
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 60);
            this.panel1.Touchable = true;
            this.panel1.Press += new System.EventHandler(this.panel1_Press);
            // 
            // imgPortrait
            // 
            this.imgPortrait.BorderRadius = 18;
            this.imgPortrait.DataMember = "IMAGEID";
            this.imgPortrait.DisplayMember = "IMAGEID";
            this.imgPortrait.Location = new System.Drawing.Point(8, 10);
            this.imgPortrait.Name = "imgPortrait";
            this.imgPortrait.Size = new System.Drawing.Size(36, 36);
            this.imgPortrait.SizeMode = Smobiler.Core.Controls.ImageSizeMode.Cover;
            // 
            // lblId
            // 
            this.lblId.DataMember = "DEPARTMENTID";
            this.lblId.DisplayMember = "NAME";
            this.lblId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.lblId.Location = new System.Drawing.Point(53, 0);
            this.lblId.Name = "lblId";
            this.lblId.Padding = new Smobiler.Core.Controls.Padding(0F, 10F, 10F, 0F);
            this.lblId.Size = new System.Drawing.Size(256, 30);
            this.lblId.VerticalAlignment = Smobiler.Core.Controls.VerticalAlignment.Top;
            this.lblId.ZIndex = 1;
            // 
            // label1
            // 
            this.label1.DataMember = "MANAGER";
            this.label1.DisplayMember = "MANAGERNAME";
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.label1.Location = new System.Drawing.Point(53, 29);
            this.label1.Name = "label1";
            this.label1.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 10F, 10F);
            this.label1.Size = new System.Drawing.Size(256, 30);
            this.label1.ZIndex = 2;
            // 
            // frmDepartmentLayout
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.panel1});
            this.Size = new System.Drawing.Size(300, 60);
            this.Name = "frmDepartmentLayout";

        }
        #endregion

        private Smobiler.Core.Controls.Panel panel1;
        private Smobiler.Core.Controls.Image imgPortrait;
        private Smobiler.Core.Controls.Label lblId;
        private Smobiler.Core.Controls.Label label1;
    }
}