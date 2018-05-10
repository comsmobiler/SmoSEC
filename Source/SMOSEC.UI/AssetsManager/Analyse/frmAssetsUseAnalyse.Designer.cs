using System;
using Smobiler.Core;
namespace SMOSEC.UI.AssetsManager.Analyse
{
    partial class frmAssetsUseAnalyse : Smobiler.Core.Controls.MobileForm
    {
        #region "SmobilerForm generated code "

        public frmAssetsUseAnalyse()
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
            this.barChart1 = new Smobiler.Core.Controls.BarChart();
            this.segmentedControl1 = new Smobiler.Core.Controls.SegmentedControl();
            // 
            // barChart1
            // 
            this.barChart1.Location = new System.Drawing.Point(0, 100);
            this.barChart1.Name = "barChart1";
            this.barChart1.Size = new System.Drawing.Size(300, 300);
            this.barChart1.XAxisValues = new string[0];
            // 
            // segmentedControl1
            // 
            this.segmentedControl1.Items = new string[] {
        "近一月",
        "近三月",
        "近一年"};
            this.segmentedControl1.Location = new System.Drawing.Point(0, 28);
            this.segmentedControl1.Name = "segmentedControl1";
            this.segmentedControl1.Size = new System.Drawing.Size(300, 35);
            // 
            // frmAssetsUseAnalyse
            // 
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.barChart1,
            this.segmentedControl1});
            this.KeyDown += new Smobiler.Core.Controls.KeyDownEventHandler(this.frmAssetsUseAnalyse_KeyDown);
            this.Load += new System.EventHandler(this.frmAssetsUseAnalyse_Load);
            this.Name = "frmAssetsUseAnalyse";

        }
        #endregion

        private Smobiler.Core.Controls.BarChart barChart1;
        private Smobiler.Core.Controls.SegmentedControl segmentedControl1;
    }
}