using System;
using Smobiler.Core;
namespace SMOSEC.UI.MasterData
{
    partial class frmAssetsTypeRows : Smobiler.Core.Controls.MobileForm
    {
        #region "SmobilerForm generated code "

        public frmAssetsTypeRows()
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
            this.plMenu = new Smobiler.Core.Controls.Panel();
            this.Label3 = new Smobiler.Core.Controls.Label();
            this.lblName = new Smobiler.Core.Controls.Label();
            this.IBAdd = new Smobiler.Core.Controls.ImageButton();
            this.IBEdit = new Smobiler.Core.Controls.ImageButton();
            this.plContent = new Smobiler.Core.Controls.Panel();
            this.btnCreate = new Smobiler.Core.Controls.Button();
            this.treeAssetsType = new Smobiler.Core.Controls.TreeView();
            // 
            // MenuTitle
            // 
            this.MenuTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(164)))), ((int)(((byte)(229)))));
            this.MenuTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.MenuTitle.FontSize = 15F;
            this.MenuTitle.ForeColor = System.Drawing.Color.White;
            this.MenuTitle.Location = new System.Drawing.Point(176, 48);
            this.MenuTitle.Name = "MenuTitle";
            this.MenuTitle.Size = new System.Drawing.Size(100, 40);
            this.MenuTitle.TitleText = "资产分类";
            // 
            // plMenu
            // 
            this.plMenu.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.plMenu.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.plMenu.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.Label3,
            this.lblName,
            this.IBAdd,
            this.IBEdit});
            this.plMenu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plMenu.Location = new System.Drawing.Point(0, 284);
            this.plMenu.Name = "plMenu";
            this.plMenu.Size = new System.Drawing.Size(300, 70);
            // 
            // Label3
            // 
            this.Label3.BackColor = System.Drawing.Color.White;
            this.Label3.Border = new Smobiler.Core.Controls.Border(0F, 0F, 0F, 1F);
            this.Label3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Label3.Name = "Label3";
            this.Label3.Padding = new Smobiler.Core.Controls.Padding(5F, 0F, 0F, 0F);
            this.Label3.Size = new System.Drawing.Size(100, 35);
            this.Label3.Text = "当前所选分类";
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.Color.White;
            this.lblName.Border = new Smobiler.Core.Controls.Border(0F, 0F, 0F, 1F);
            this.lblName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblName.ForeColor = System.Drawing.Color.Red;
            this.lblName.Location = new System.Drawing.Point(100, 0);
            this.lblName.Name = "lblName";
            this.lblName.Padding = new Smobiler.Core.Controls.Padding(10F, 0F, 0F, 0F);
            this.lblName.Size = new System.Drawing.Size(200, 35);
            this.lblName.Text = "暂无";
            // 
            // IBAdd
            // 
            this.IBAdd.BackColor = System.Drawing.Color.White;
            this.IBAdd.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(197)))), ((int)(((byte)(118)))));
            this.IBAdd.ImageDirection = Smobiler.Core.Controls.Direction.Left;
            this.IBAdd.ImageType = Smobiler.Core.Controls.ImageEx.ImageStyle.FontIcon;
            this.IBAdd.Location = new System.Drawing.Point(0, 35);
            this.IBAdd.Name = "IBAdd";
            this.IBAdd.Padding = new Smobiler.Core.Controls.Padding(40F, 0F, 40F, 0F);
            this.IBAdd.ResourceID = "plus-circle";
            this.IBAdd.Size = new System.Drawing.Size(150, 35);
            this.IBAdd.Text = "下级";
            this.IBAdd.Press += new System.EventHandler(this.IBAdd_Press);
            // 
            // IBEdit
            // 
            this.IBEdit.BackColor = System.Drawing.Color.White;
            this.IBEdit.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(181)))), ((int)(((byte)(231)))));
            this.IBEdit.ImageDirection = Smobiler.Core.Controls.Direction.Left;
            this.IBEdit.ImageType = Smobiler.Core.Controls.ImageEx.ImageStyle.FontIcon;
            this.IBEdit.Location = new System.Drawing.Point(150, 35);
            this.IBEdit.Name = "IBEdit";
            this.IBEdit.Padding = new Smobiler.Core.Controls.Padding(40F, 0F, 40F, 0F);
            this.IBEdit.ResourceID = "pencil";
            this.IBEdit.Size = new System.Drawing.Size(150, 35);
            this.IBEdit.Text = "编辑";
            this.IBEdit.Press += new System.EventHandler(this.IBEdit_Press);
            // 
            // plContent
            // 
            this.plContent.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.btnCreate,
            this.treeAssetsType});
            this.plContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plContent.Flex = 10000;
            this.plContent.Location = new System.Drawing.Point(0, 162);
            this.plContent.Name = "plContent";
            this.plContent.Size = new System.Drawing.Size(300, 100);
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(146)))), ((int)(((byte)(223)))));
            this.btnCreate.BorderRadius = 4;
            this.btnCreate.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCreate.FontSize = 15F;
            this.btnCreate.Margin = new Smobiler.Core.Controls.Margin(10F, 10F, 10F, 0F);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(280, 35);
            this.btnCreate.Text = "新增资产分类";
            this.btnCreate.Press += new System.EventHandler(this.btnCreate_Press);
            // 
            // treeAssetsType
            // 
            this.treeAssetsType.BackColor = System.Drawing.Color.White;
            this.treeAssetsType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeAssetsType.Location = new System.Drawing.Point(0, 35);
            this.treeAssetsType.Margin = new Smobiler.Core.Controls.Margin(0F, 20F, 0F, 0F);
            this.treeAssetsType.Name = "treeAssetsType";
            this.treeAssetsType.NodeCollapseIcon = "plus-square-o";
            this.treeAssetsType.NodeCollapseIconColor = System.Drawing.Color.DimGray;
            this.treeAssetsType.NodeExpandIcon = "minus-square-o";
            this.treeAssetsType.NodeExpandIconColor = System.Drawing.Color.DimGray;
            this.treeAssetsType.Size = new System.Drawing.Size(300, 320);
            this.treeAssetsType.NodePress += new Smobiler.Core.Controls.TreeViewNodeClickEventHandler(this.treeAssetsType_NodePress);
            // 
            // frmAssetsTypeRows
            // 
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.MenuTitle,
            this.plMenu,
            this.plContent});
            this.DrawerName = "LeftMenu";
            this.Orientation = Smobiler.Core.Controls.FormOrientation.Portrait;
            this.Statusbar = new Smobiler.Core.Controls.MobileFormStatusbar(Smobiler.Core.Controls.MobileFormStatusbarStyle.Default, System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(164)))), ((int)(((byte)(229))))));
            this.KeyDown += new Smobiler.Core.Controls.KeyDownEventHandler(this.frmAssetsTypeRows_KeyDown);
            this.Load += new System.EventHandler(this.frmAssetsTypeRows_Load);
            this.Name = "frmAssetsTypeRows";

        }
        #endregion

        private UserControl.MenuTitle MenuTitle;
        internal Smobiler.Core.Controls.Panel plMenu;
        internal Smobiler.Core.Controls.Label Label3;
        internal Smobiler.Core.Controls.Label lblName;
        internal Smobiler.Core.Controls.ImageButton IBAdd;
        internal Smobiler.Core.Controls.ImageButton IBEdit;
        internal Smobiler.Core.Controls.Panel plContent;
        private Smobiler.Core.Controls.Button btnCreate;
        internal Smobiler.Core.Controls.TreeView treeAssetsType;
    }
}