using System;
using Smobiler.Core;
namespace SMOSEC.UI.UserControl
{
    partial class MenuTitle : Smobiler.Core.Controls.MobileUserControl
    {
        #region "SmobilerUserControl generated code "

        public MenuTitle()
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
            this.plContent = new Smobiler.Core.Controls.Panel();
            this.Panel1 = new Smobiler.Core.Controls.Panel();
            this.Image1 = new Smobiler.Core.Controls.Image();
            this.label2 = new Smobiler.Core.Controls.Label();
            this.label1 = new Smobiler.Core.Controls.Label();
            // 
            // plContent
            // 
            this.plContent.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.Panel1,
            this.label2,
            this.label1});
            this.plContent.Name = "plContent";
            this.plContent.Size = new System.Drawing.Size(300, 40);
            // 
            // Panel1
            // 
            this.Panel1.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.Image1});
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(40, 40);
            this.Panel1.Touchable = true;
            this.Panel1.Press += new System.EventHandler(this.Panel1_Press);
            // 
            // Image1
            // 
            this.Image1.Name = "Image1";
            this.Image1.ResourceID = "caidan";
            this.Image1.Size = new System.Drawing.Size(40, 40);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(260, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 40);
            // 
            // label1
            // 
            this.label1.FontSize = 15F;
            this.label1.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Center;
            this.label1.Location = new System.Drawing.Point(40, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 40);
            // 
            // MenuTitle
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(164)))), ((int)(((byte)(229)))));
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.plContent});
            this.Size = new System.Drawing.Size(0, 40);
            this.Name = "MenuTitle";

        }
        #endregion

        internal Smobiler.Core.Controls.Panel plContent;
        private Smobiler.Core.Controls.Panel Panel1;
        internal Smobiler.Core.Controls.Image Image1;
        private Smobiler.Core.Controls.Label label2;
        private Smobiler.Core.Controls.Label label1;
    }
}