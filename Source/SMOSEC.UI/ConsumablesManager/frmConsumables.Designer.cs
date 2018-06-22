using SMOSEC.UI.UserControl;

namespace SMOSEC.UI.ConsumablesManager
{
    partial class frmConsumables : Smobiler.Core.Controls.MobileForm
    {
        #region "SmobilerForm generated code "

        public frmConsumables()
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
            this.menuTitle1 = new SMOSEC.UI.UserControl.MenuTitle();
            this.ListViewCon = new Smobiler.Core.Controls.ListView();
            this.panel1 = new Smobiler.Core.Controls.Panel();
            this.btnAdd = new Smobiler.Core.Controls.Button();
            // 
            // menuTitle1
            // 
            this.menuTitle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(164)))), ((int)(((byte)(229)))));
            this.menuTitle1.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuTitle1.FontSize = 15F;
            this.menuTitle1.ForeColor = System.Drawing.Color.Black;
            this.menuTitle1.Name = "menuTitle1";
            this.menuTitle1.Size = new System.Drawing.Size(300, 40);
            this.menuTitle1.TitleText = "ºÄ²Ä";
            // 
            // ListViewCon
            // 
            this.ListViewCon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListViewCon.Location = new System.Drawing.Point(0, 73);
            this.ListViewCon.Margin = new Smobiler.Core.Controls.Margin(0F, 5F, 0F, 0F);
            this.ListViewCon.Name = "ListViewCon";
            this.ListViewCon.PageSizeTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.ListViewCon.PageSizeTextSize = 11F;
            this.ListViewCon.Size = new System.Drawing.Size(300, 432);
            this.ListViewCon.TemplateControlName = "frmConsumablesLayout";
            // 
            // panel1
            // 
            this.panel1.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.btnAdd});
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 53);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(146)))), ((int)(((byte)(223)))));
            this.btnAdd.BorderRadius = 4;
            this.btnAdd.FontSize = 15F;
            this.btnAdd.Margin = new Smobiler.Core.Controls.Margin(10F, 10F, 10F, 0F);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(280, 33);
            this.btnAdd.Text = "Ìí¼ÓºÄ²Ä";
            this.btnAdd.Press += new System.EventHandler(this.btnAdd_Press);
            // 
            // frmConsumables
            // 
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.menuTitle1,
            this.panel1,
            this.ListViewCon});
            this.DrawerName = "LeftMenu";
            this.Orientation = Smobiler.Core.Controls.FormOrientation.Portrait;
            this.Statusbar = new Smobiler.Core.Controls.MobileFormStatusbar(Smobiler.Core.Controls.MobileFormStatusbarStyle.Default, System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(164)))), ((int)(((byte)(229))))));
            this.KeyDown += new Smobiler.Core.Controls.KeyDownEventHandler(this.frmConsumables_KeyDown);
            this.Load += new System.EventHandler(this.frmConsumables_Load);
            this.Name = "frmConsumables";

        }
        #endregion

        private UserControl.MenuTitle menuTitle1;
        internal Smobiler.Core.Controls.ListView ListViewCon;
        private Smobiler.Core.Controls.Panel panel1;
        internal Smobiler.Core.Controls.Button btnAdd;
    }
}