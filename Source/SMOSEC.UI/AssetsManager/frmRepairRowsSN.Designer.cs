using System;
using Smobiler.Core;
namespace SMOSEC.UI.AssetsManager
{
    partial class frmRepairRowsSN : Smobiler.Core.Controls.MobileForm
    {
        #region "SmobilerForm generated code "

        public frmRepairRowsSN()
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
            this.MenuTitle = new SMOSEC.UI.UserControl.MenuTitle();
            this.spContent = new Smobiler.Core.Controls.Panel();
            this.btnCreate = new Smobiler.Core.Controls.Button();
            this.listRepairOrder = new Smobiler.Core.Controls.ListView();
            // 
            // MenuTitle
            // 
            this.MenuTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(164)))), ((int)(((byte)(229)))));
            this.MenuTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.MenuTitle.FontSize = 15F;
            this.MenuTitle.ForeColor = System.Drawing.Color.White;
            this.MenuTitle.Location = new System.Drawing.Point(140, 122);
            this.MenuTitle.Name = "MenuTitle";
            this.MenuTitle.Size = new System.Drawing.Size(100, 40);
            this.MenuTitle.TitleText = "资产报修单列表";
            // 
            // spContent
            // 
            this.spContent.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.btnCreate,
            this.listRepairOrder});
            this.spContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spContent.Flex = 10000;
            this.spContent.Location = new System.Drawing.Point(0, 162);
            this.spContent.Name = "spContent";
            this.spContent.Size = new System.Drawing.Size(300, 100);
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
            this.btnCreate.Text = "创建报修单";
            this.btnCreate.Press += new System.EventHandler(this.btnCreate_Press);
            // 
            // listRepairOrder
            // 
            this.listRepairOrder.BackColor = System.Drawing.Color.White;
            this.listRepairOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listRepairOrder.Location = new System.Drawing.Point(0, 66);
            this.listRepairOrder.Margin = new Smobiler.Core.Controls.Margin(0F, 20F, 0F, 0F);
            this.listRepairOrder.Name = "listRepairOrder";
            this.listRepairOrder.PageSizeTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.listRepairOrder.PageSizeTextSize = 11F;
            this.listRepairOrder.ShowSplitLine = true;
            this.listRepairOrder.Size = new System.Drawing.Size(300, 300);
            this.listRepairOrder.SplitLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.listRepairOrder.TemplateControlName = "frmRepairRowsLayout";
            // 
            // frmRepairRowsSN
            // 
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.MenuTitle,
            this.spContent});
            this.DrawerName = "LeftMenu";
            this.Orientation = Smobiler.Core.Controls.FormOrientation.Portrait;
            this.Statusbar = new Smobiler.Core.Controls.MobileFormStatusbar(Smobiler.Core.Controls.MobileFormStatusbarStyle.Default, System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(164)))), ((int)(((byte)(229))))));
            this.KeyDown += new Smobiler.Core.Controls.KeyDownEventHandler(this.frmRepairRowsSN_KeyDown);
            this.Load += new System.EventHandler(this.frmRepairRowsSN_Load);
            this.Name = "frmRepairRowsSN";

        }
        #endregion

        private UserControl.MenuTitle MenuTitle;
        internal Smobiler.Core.Controls.Panel spContent;
        private Smobiler.Core.Controls.Button btnCreate;
        internal Smobiler.Core.Controls.ListView listRepairOrder;
    }
}