using System;
using Smobiler.Core;
namespace SMOSEC.UI.MasterData
{
    partial class frmLocationRows : Smobiler.Core.Controls.MobileForm
    {
        #region "SmobilerForm generated code "

        public frmLocationRows()
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
            this.Panel1 = new Smobiler.Core.Controls.Panel();
            this.btnCreate = new Smobiler.Core.Controls.Button();
            this.listLocation = new Smobiler.Core.Controls.ListView();
            this.MenuTitle = new SMOSEC.UI.UserControl.MenuTitle();
            // 
            // Panel1
            // 
            this.Panel1.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.btnCreate,
            this.listLocation});
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1.Location = new System.Drawing.Point(0, 162);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(300, 100);
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(146)))), ((int)(((byte)(223)))));
            this.btnCreate.BorderRadius = 4;
            this.btnCreate.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCreate.FontSize = 15F;
            this.btnCreate.Location = new System.Drawing.Point(0, 10);
            this.btnCreate.Margin = new Smobiler.Core.Controls.Margin(10F, 10F, 10F, 0F);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(280, 35);
            this.btnCreate.Text = "创建区域";
            this.btnCreate.Press += new System.EventHandler(this.btnCreate_Press);
            // 
            // listLocation
            // 
            this.listLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listLocation.Location = new System.Drawing.Point(0, 66);
            this.listLocation.Margin = new Smobiler.Core.Controls.Margin(0F, 20F, 0F, 0F);
            this.listLocation.Name = "listLocation";
            this.listLocation.PageSizeTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.listLocation.PageSizeTextSize = 11F;
            this.listLocation.ShowSplitLine = true;
            this.listLocation.Size = new System.Drawing.Size(300, 300);
            this.listLocation.SplitLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.listLocation.TemplateControlName = "frmLcoationRowsLayout";
            // 
            // MenuTitle
            // 
            this.MenuTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(164)))), ((int)(((byte)(229)))));
            this.MenuTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.MenuTitle.FontSize = 15F;
            this.MenuTitle.ForeColor = System.Drawing.Color.White;
            this.MenuTitle.Location = new System.Drawing.Point(74, 74);
            this.MenuTitle.Name = "MenuTitle";
            this.MenuTitle.Size = new System.Drawing.Size(100, 40);
            this.MenuTitle.TitleText = "区域";
            // 
            // frmLocationRows
            // 
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.MenuTitle,
            this.Panel1});
            this.DrawerName = "LeftMenu";
            this.Orientation = Smobiler.Core.Controls.FormOrientation.Portrait;
            this.Statusbar = new Smobiler.Core.Controls.MobileFormStatusbar(Smobiler.Core.Controls.MobileFormStatusbarStyle.Default, System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(164)))), ((int)(((byte)(229))))));
            this.KeyDown += new Smobiler.Core.Controls.KeyDownEventHandler(this.frmLocationRows_KeyDown);
            this.Load += new System.EventHandler(this.frmLocationRows_Load);
            this.Name = "frmLocationRows";

        }
        #endregion

        private UserControl.MenuTitle MenuTitle;
        internal Smobiler.Core.Controls.Panel Panel1;
        private Smobiler.Core.Controls.Button btnCreate;
        internal Smobiler.Core.Controls.ListView listLocation;
    }
}