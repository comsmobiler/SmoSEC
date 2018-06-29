using System;
using Smobiler.Core;
namespace SMOSEC.UI.Department
{
    partial class frmDepartment : Smobiler.Core.Controls.MobileForm
    {
        #region "SmobilerForm generated code "

        public frmDepartment()
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
            this.gridDepData = new Smobiler.Core.Controls.ListView();
            this.btnCreate = new Smobiler.Core.Controls.Button();
            this.lblInfor = new Smobiler.Core.Controls.Label();
            this.treeDepData = new Smobiler.Core.Controls.TreeView();
            this.btnDMode = new Smobiler.Core.Controls.Button();
            this.MenuTitle1 = new SMOSEC.UI.UserControl.MenuTitle();
            // 
            // gridDepData
            // 
            this.gridDepData.BackColor = System.Drawing.Color.White;
            this.gridDepData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDepData.Location = new System.Drawing.Point(2, 95);
            this.gridDepData.Margin = new Smobiler.Core.Controls.Margin(0F, 20F, 0F, 0F);
            this.gridDepData.Name = "gridDepData";
            this.gridDepData.PageSizeTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.gridDepData.PageSizeTextSize = 11F;
            this.gridDepData.ShowSplitLine = true;
            this.gridDepData.Size = new System.Drawing.Size(300, 270);
            this.gridDepData.SplitLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.gridDepData.TemplateControlName = "frmDepartmentLayout";
            this.gridDepData.ZIndex = 2;
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(146)))), ((int)(((byte)(223)))));
            this.btnCreate.BorderRadius = 2;
            this.btnCreate.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCreate.FontSize = 17F;
            this.btnCreate.Location = new System.Drawing.Point(12, 50);
            this.btnCreate.Margin = new Smobiler.Core.Controls.Margin(10F, 10F, 10F, 0F);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(280, 35);
            this.btnCreate.Text = "创建部门";
            this.btnCreate.ZIndex = 1;
            this.btnCreate.Press += new System.EventHandler(this.btnCreate_Click);
            // 
            // lblInfor
            // 
            this.lblInfor.ForeColor = System.Drawing.Color.Silver;
            this.lblInfor.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Center;
            this.lblInfor.Location = new System.Drawing.Point(2, 220);
            this.lblInfor.Name = "lblInfor";
            this.lblInfor.Size = new System.Drawing.Size(300, 30);
            this.lblInfor.Text = "当前暂无部门，请创建！";
            this.lblInfor.Visible = false;
            this.lblInfor.ZIndex = 4;
            // 
            // treeDepData
            // 
            this.treeDepData.BackColor = System.Drawing.Color.White;
            this.treeDepData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeDepData.Flex = 10;
            this.treeDepData.Location = new System.Drawing.Point(2, 95);
            this.treeDepData.Margin = new Smobiler.Core.Controls.Margin(0F, 20F, 0F, 0F);
            this.treeDepData.Name = "treeDepData";
            this.treeDepData.NodeCollapseIcon = "angle-left";
            this.treeDepData.Size = new System.Drawing.Size(300, 413);
            this.treeDepData.ZIndex = 3;
            this.treeDepData.NodePress += new Smobiler.Core.Controls.TreeViewNodeClickEventHandler(this.treeDepData_NodeSelected);
            // 
            // btnDMode
            // 
            this.btnDMode.BackColor = System.Drawing.Color.White;
            this.btnDMode.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.btnDMode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnDMode.BorderRadius = 0;
            this.btnDMode.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(146)))), ((int)(((byte)(223)))));
            this.btnDMode.Name = "btnDMode";
            this.btnDMode.Size = new System.Drawing.Size(300, 50);
            this.btnDMode.Text = "层级展示";
            this.btnDMode.Press += new System.EventHandler(this.btnDLayout_Click);
            // 
            // MenuTitle1
            // 
            this.MenuTitle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(164)))), ((int)(((byte)(229)))));
            this.MenuTitle1.Direction = Smobiler.Core.Controls.LayoutDirection.Row;
            this.MenuTitle1.Dock = System.Windows.Forms.DockStyle.Top;
            this.MenuTitle1.FontSize = 15F;
            this.MenuTitle1.ForeColor = System.Drawing.Color.Black;
            this.MenuTitle1.Location = new System.Drawing.Point(111, 36);
            this.MenuTitle1.Name = "MenuTitle1";
            this.MenuTitle1.Size = new System.Drawing.Size(100, 40);
            this.MenuTitle1.TitleText = "部门";
            // 
            // frmDepartment
            // 
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.MenuTitle1,
            this.btnCreate,
            this.btnDMode,
            this.lblInfor,
            this.gridDepData,
            this.treeDepData});
            this.DrawerName = "LeftMenu";
            this.Orientation = Smobiler.Core.Controls.FormOrientation.Portrait;
            this.Statusbar = new Smobiler.Core.Controls.MobileFormStatusbar(Smobiler.Core.Controls.MobileFormStatusbarStyle.Default, System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(164)))), ((int)(((byte)(229))))));
            this.KeyDown += new Smobiler.Core.Controls.KeyDownEventHandler(this.frmDepartment_KeyDown);
            this.Load += new System.EventHandler(this.frmDepartment_Load);
            this.Name = "frmDepartment";

        }
        #endregion

        private Smobiler.Core.Controls.ListView gridDepData;
        private Smobiler.Core.Controls.Button btnCreate;
        private Smobiler.Core.Controls.Label lblInfor;
        private Smobiler.Core.Controls.TreeView treeDepData;
        private Smobiler.Core.Controls.ToolBarItem tMode;
        private Smobiler.Core.Controls.Button btnDMode;
        private SMOSEC.UI.UserControl.MenuTitle MenuTitle1;
    }
}