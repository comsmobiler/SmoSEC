using System;
using Smobiler.Core;
using SMOSEC.UI.UserControl;

namespace SMOSEC.UI.AssetsManager
{
    partial class frmBorrowOrder : Smobiler.Core.Controls.MobileForm
    {
        #region "SmobilerForm generated code "

        public frmBorrowOrder()
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
            this.Title1 = new SMOSEC.UI.UserControl.MenuTitle();
            this.ListViewBorrow = new Smobiler.Core.Controls.ListView();
            this.plButton = new Smobiler.Core.Controls.Panel();
            this.btnAdd = new Smobiler.Core.Controls.Button();
            // 
            // Title1
            // 
            this.Title1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(164)))), ((int)(((byte)(229)))));
            this.Title1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Title1.FontSize = 15F;
            this.Title1.ForeColor = System.Drawing.Color.Black;
            this.Title1.Name = "Title1";
            this.Title1.Size = new System.Drawing.Size(300, 40);
            this.Title1.TitleText = "借用单列表";
            // 
            // ListViewBorrow
            // 
            this.ListViewBorrow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListViewBorrow.Location = new System.Drawing.Point(0, 95);
            this.ListViewBorrow.Name = "ListViewBorrow";
            this.ListViewBorrow.PageSizeTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.ListViewBorrow.PageSizeTextSize = 11F;
            this.ListViewBorrow.Size = new System.Drawing.Size(300, 410);
            this.ListViewBorrow.TemplateControlName = "BorrowOrderLayout";
            // 
            // plButton
            // 
            this.plButton.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.btnAdd});
            this.plButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.plButton.Location = new System.Drawing.Point(0, 113);
            this.plButton.Name = "plButton";
            this.plButton.Size = new System.Drawing.Size(300, 55);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(146)))), ((int)(((byte)(223)))));
            this.btnAdd.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnAdd.BorderRadius = 4;
            this.btnAdd.FontSize = 15F;
            this.btnAdd.Margin = new Smobiler.Core.Controls.Margin(10F, 10F, 10F, 0F);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(280, 35);
            this.btnAdd.Text = "新增";
            this.btnAdd.Press += new System.EventHandler(this.btnAdd_Press);
            // 
            // frmBorrowOrder
            // 
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.Title1,
            this.plButton,
            this.ListViewBorrow});
            this.DrawerName = "LeftMenu";
            this.Orientation = Smobiler.Core.Controls.FormOrientation.Portrait;
            this.Statusbar = new Smobiler.Core.Controls.MobileFormStatusbar(Smobiler.Core.Controls.MobileFormStatusbarStyle.Default, System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(164)))), ((int)(((byte)(229))))));
            this.KeyDown += new Smobiler.Core.Controls.KeyDownEventHandler(this.FrmBorrowOrder_KeyDown);
            this.Load += new System.EventHandler(this.FrmBorrowOrder_Load);
            this.Name = "frmBorrowOrder";

        }
        #endregion

        private MenuTitle Title1;
        internal Smobiler.Core.Controls.ListView ListViewBorrow;
        private Smobiler.Core.Controls.Panel plButton;
        internal Smobiler.Core.Controls.Button btnAdd;
    }
}