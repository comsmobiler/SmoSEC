using System;
using Smobiler.Core;
namespace SMOSEC.UI.Layout
{
    partial class frmAssTypeChooseLayout : Smobiler.Core.Controls.MobileUserControl
    {
        #region "SmobilerUserControl generated code "

        public frmAssTypeChooseLayout()
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
            this.plTitle = new Smobiler.Core.Controls.Panel();
            this.label1 = new Smobiler.Core.Controls.Label();
            this.plClose = new Smobiler.Core.Controls.Panel();
            this.Image1 = new Smobiler.Core.Controls.Image();
            this.treeAssetsType = new Smobiler.Core.Controls.TreeView();
            // 
            // plContent
            // 
            this.plContent.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.plTitle,
            this.treeAssetsType});
            this.plContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plContent.Location = new System.Drawing.Point(0, 335);
            this.plContent.Name = "plContent";
            this.plContent.Size = new System.Drawing.Size(300, 345);
            // 
            // plTitle
            // 
            this.plTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(164)))), ((int)(((byte)(229)))));
            this.plTitle.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.label1,
            this.plClose});
            this.plTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.plTitle.Location = new System.Drawing.Point(0, 334);
            this.plTitle.Name = "plTitle";
            this.plTitle.Size = new System.Drawing.Size(280, 30);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(164)))), ((int)(((byte)(229)))));
            this.label1.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Center;
            this.label1.Location = new System.Drawing.Point(40, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 30);
            this.label1.Text = "����ѡ��";
            // 
            // plClose
            // 
            this.plClose.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.Image1});
            this.plClose.Location = new System.Drawing.Point(10, 0);
            this.plClose.Name = "plClose";
            this.plClose.Size = new System.Drawing.Size(40, 40);
            this.plClose.Touchable = true;
            this.plClose.Press += new System.EventHandler(this.plClose_Press);
            // 
            // Image1
            // 
            this.Image1.Name = "Image1";
            this.Image1.ResourceID = "back";
            this.Image1.Size = new System.Drawing.Size(30, 30);
            // 
            // treeAssetsType
            // 
            this.treeAssetsType.BackColor = System.Drawing.Color.White;
            this.treeAssetsType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeAssetsType.Name = "treeAssetsType";
            this.treeAssetsType.NodeCollapseIcon = "plus-square-o";
            this.treeAssetsType.NodeCollapseIconColor = System.Drawing.Color.DimGray;
            this.treeAssetsType.NodeExpandIcon = "minus-square-o";
            this.treeAssetsType.NodeExpandIconColor = System.Drawing.Color.DimGray;
            this.treeAssetsType.Size = new System.Drawing.Size(280, 305);
            this.treeAssetsType.NodePress += new Smobiler.Core.Controls.TreeViewNodeClickEventHandler(this.treeAssetsType_NodePress);
            // 
            // frmAssTypeChooseLayout
            // 
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.plContent});
            this.Size = new System.Drawing.Size(280, 345);
            this.Load += new System.EventHandler(this.frmAssTypeChooseLayout_Load);
            this.Name = "frmAssTypeChooseLayout";

        }
        #endregion
        private Smobiler.Core.Controls.Panel plContent;
        private Smobiler.Core.Controls.Panel plTitle;
        private Smobiler.Core.Controls.Label label1;
        private Smobiler.Core.Controls.Panel plClose;
        internal Smobiler.Core.Controls.Image Image1;
        internal Smobiler.Core.Controls.TreeView treeAssetsType;
    }
}