namespace SMOSEC.UI.ConsumablesManager
{
    partial class frmConsumablesChoose : Smobiler.Core.Controls.MobileForm
    {
        #region "SmobilerForm generated code "

        public frmConsumablesChoose()
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
            this.Title1 = new SMOSEC.UI.UserControl.Title();
            this.plButton = new Smobiler.Core.Controls.Panel();
            this.plAll = new Smobiler.Core.Controls.Panel();
            this.Checkall = new Smobiler.Core.Controls.CheckBox();
            this.lblCheckall = new Smobiler.Core.Controls.Label();
            this.btnSave = new Smobiler.Core.Controls.Button();
            this.spContent = new Smobiler.Core.Controls.Panel();
            this.listViewCon = new Smobiler.Core.Controls.ListView();
            this.plAssetsSearch = new Smobiler.Core.Controls.Panel();
            this.Label4 = new Smobiler.Core.Controls.Label();
            this.txtFactor = new Smobiler.Core.Controls.TextBox();
            this.plSearch = new Smobiler.Core.Controls.Panel();
            this.fiSearch = new Smobiler.Core.Controls.FontIcon();
            // 
            // Title1
            // 
            this.Title1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(164)))), ((int)(((byte)(229)))));
            this.Title1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Title1.FontSize = 15F;
            this.Title1.ForeColor = System.Drawing.Color.White;
            this.Title1.Name = "Title1";
            this.Title1.Size = new System.Drawing.Size(300, 40);
            this.Title1.TitleText = "耗材选择";
            // 
            // plButton
            // 
            this.plButton.BackColor = System.Drawing.Color.White;
            this.plButton.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.plAll,
            this.btnSave});
            this.plButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plButton.Location = new System.Drawing.Point(0, 382);
            this.plButton.Name = "plButton";
            this.plButton.Size = new System.Drawing.Size(300, 70);
            // 
            // plAll
            // 
            this.plAll.BackColor = System.Drawing.Color.White;
            this.plAll.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.Checkall,
            this.lblCheckall});
            this.plAll.Name = "plAll";
            this.plAll.Size = new System.Drawing.Size(300, 35);
            // 
            // Checkall
            // 
            this.Checkall.Location = new System.Drawing.Point(8, 8);
            this.Checkall.Name = "Checkall";
            this.Checkall.Size = new System.Drawing.Size(20, 20);
            this.Checkall.ZIndex = 2;
            this.Checkall.CheckedChanged += new System.EventHandler(this.Checkall_CheckedChanged);
            // 
            // lblCheckall
            // 
            this.lblCheckall.FontSize = 12F;
            this.lblCheckall.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.lblCheckall.Location = new System.Drawing.Point(42, 0);
            this.lblCheckall.Name = "lblCheckall";
            this.lblCheckall.Size = new System.Drawing.Size(40, 35);
            this.lblCheckall.Text = "全选";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(146)))), ((int)(((byte)(223)))));
            this.btnSave.BorderRadius = 4;
            this.btnSave.FontSize = 17F;
            this.btnSave.Location = new System.Drawing.Point(10, 35);
            this.btnSave.Margin = new Smobiler.Core.Controls.Margin(0F, 0F, 10F, 0F);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(280, 35);
            this.btnSave.Text = "确定";
            this.btnSave.Press += new System.EventHandler(this.btnSave_Press);
            // 
            // spContent
            // 
            this.spContent.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.listViewCon});
            this.spContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spContent.Flex = 10000;
            this.spContent.Location = new System.Drawing.Point(0, 40);
            this.spContent.Name = "spContent";
            this.spContent.Size = new System.Drawing.Size(300, 300);
            // 
            // listViewCon
            // 
            this.listViewCon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewCon.Location = new System.Drawing.Point(0, 35);
            this.listViewCon.Name = "listViewCon";
            this.listViewCon.PageSizeTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.listViewCon.PageSizeTextSize = 11F;
            this.listViewCon.Size = new System.Drawing.Size(300, 300);
            // 
            // plAssetsSearch
            // 
            this.plAssetsSearch.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.Label4,
            this.txtFactor,
            this.plSearch});
            this.plAssetsSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.plAssetsSearch.Name = "plAssetsSearch";
            this.plAssetsSearch.Size = new System.Drawing.Size(300, 35);
            // 
            // Label4
            // 
            this.Label4.BackColor = System.Drawing.Color.White;
            this.Label4.Name = "Label4";
            this.Label4.Padding = new Smobiler.Core.Controls.Padding(5F, 0F, 0F, 0F);
            this.Label4.Size = new System.Drawing.Size(88, 35);
            this.Label4.Text = "耗材选择";
            // 
            // txtFactor
            // 
            this.txtFactor.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.txtFactor.Location = new System.Drawing.Point(88, 0);
            this.txtFactor.Name = "txtFactor";
            this.txtFactor.Padding = new Smobiler.Core.Controls.Padding(5F, 0F, 0F, 0F);
            this.txtFactor.Size = new System.Drawing.Size(172, 35);
            this.txtFactor.WaterMarkText = "请输入资产名称";
            // 
            // plSearch
            // 
            this.plSearch.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.fiSearch});
            this.plSearch.Location = new System.Drawing.Point(260, 0);
            this.plSearch.Name = "plSearch";
            this.plSearch.Size = new System.Drawing.Size(40, 35);
            this.plSearch.Touchable = true;
            this.plSearch.Press += new System.EventHandler(this.plSearch_Press);
            // 
            // fiSearch
            // 
            this.fiSearch.BackColor = System.Drawing.Color.White;
            this.fiSearch.Border = new Smobiler.Core.Controls.Border(1F, 0F, 0F, 0F);
            this.fiSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.fiSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(146)))), ((int)(((byte)(223)))));
            this.fiSearch.Name = "fiSearch";
            this.fiSearch.ResourceID = "search";
            this.fiSearch.Size = new System.Drawing.Size(40, 35);
            // 
            // frmConsumablesChoose
            // 
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.Title1,
            this.plAssetsSearch,
            this.plButton,
            this.spContent});
            this.Orientation = Smobiler.Core.Controls.FormOrientation.Portrait;
            this.Statusbar = new Smobiler.Core.Controls.MobileFormStatusbar(Smobiler.Core.Controls.MobileFormStatusbarStyle.Default, System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(164)))), ((int)(((byte)(229))))));
            this.KeyDown += new Smobiler.Core.Controls.KeyDownEventHandler(this.frmConsumablesChoose_KeyDown);
            this.Load += new System.EventHandler(this.frmConsumablesChoose_Load);
            this.Name = "frmConsumablesChoose";

        }
        #endregion

        private UserControl.Title Title1;
        private Smobiler.Core.Controls.Panel plButton;
        private Smobiler.Core.Controls.Panel plAll;
        internal Smobiler.Core.Controls.CheckBox Checkall;
        internal Smobiler.Core.Controls.Label lblCheckall;
        private Smobiler.Core.Controls.Button btnSave;
        internal Smobiler.Core.Controls.Panel spContent;
        internal Smobiler.Core.Controls.Panel plAssetsSearch;
        internal Smobiler.Core.Controls.Label Label4;
        internal Smobiler.Core.Controls.TextBox txtFactor;
        internal Smobiler.Core.Controls.Panel plSearch;
        internal Smobiler.Core.Controls.FontIcon fiSearch;
        private Smobiler.Core.Controls.ListView listViewCon;
    }
}