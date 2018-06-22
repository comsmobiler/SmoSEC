using System;
using Smobiler.Core;
namespace SMOSEC.UI.Layout
{
    partial class frmDepAssignUserLayout : Smobiler.Core.Controls.MobileUserControl
    {
        #region "SmobilerForm generated code "

        public frmDepAssignUserLayout()
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
            this.lblPortrait = new Smobiler.Core.Controls.Label();
            this.lblUser = new Smobiler.Core.Controls.Label();
            this.imgPortrait = new Smobiler.Core.Controls.Image();
            this.Check = new Smobiler.Core.Controls.CheckBox();
            this.lblDep = new Smobiler.Core.Controls.Label();
            // 
            // lblPortrait
            // 
            this.lblPortrait.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(146)))), ((int)(((byte)(223)))));
            this.lblPortrait.BorderRadius = 10;
            this.lblPortrait.ForeColor = System.Drawing.Color.White;
            this.lblPortrait.Location = new System.Drawing.Point(4, 7);
            this.lblPortrait.Name = "lblPortrait";
            this.lblPortrait.Size = new System.Drawing.Size(35, 35);
            this.lblPortrait.Visible = false;
            // 
            // lblUser
            // 
            this.lblUser.DataMember = "USER_ID";
            this.lblUser.DisplayMember = "USER_NAME";
            this.lblUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.lblUser.Location = new System.Drawing.Point(47, 0);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(109, 50);
            // 
            // imgPortrait
            // 
            this.imgPortrait.BorderRadius = 10;
            this.imgPortrait.DataMember = "USER_IMAGEID";
            this.imgPortrait.DisplayMember = "USER_IMAGEID";
            this.imgPortrait.Location = new System.Drawing.Point(4, 7);
            this.imgPortrait.Name = "imgPortrait";
            this.imgPortrait.Size = new System.Drawing.Size(35, 35);
            this.imgPortrait.SizeMode = Smobiler.Core.Controls.ImageSizeMode.Cover;
            // 
            // Check
            // 
            this.Check.DataMember = "SelectCheck";
            this.Check.DisplayMember = "SelectCheck";
            this.Check.Location = new System.Drawing.Point(270, 15);
            this.Check.Name = "Check";
            this.Check.Size = new System.Drawing.Size(20, 20);
            // 
            // lblDep
            // 
            this.lblDep.DataMember = "USER_DEPARTMENTID";
            this.lblDep.DisplayMember = "DepName";
            this.lblDep.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.lblDep.Location = new System.Drawing.Point(156, 0);
            this.lblDep.Name = "lblDep";
            this.lblDep.Size = new System.Drawing.Size(108, 50);
            // 
            // frmDepAssignUserLayout
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.lblPortrait,
            this.lblUser,
            this.imgPortrait,
            this.Check,
            this.lblDep});
            this.Size = new System.Drawing.Size(300, 50);
            this.Name = "frmDepAssignUserLayout";

        }
        #endregion

        private Smobiler.Core.Controls.Label lblPortrait;
        private Smobiler.Core.Controls.Image imgPortrait;
        public Smobiler.Core.Controls.CheckBox Check;
        public Smobiler.Core.Controls.Label lblUser;
        public Smobiler.Core.Controls.Label lblDep;
    }
}