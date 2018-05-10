using System;
using Smobiler.Core;
namespace SMOSEC.UI.Layout
{
    partial class frmLocationRowsButtonLayout : Smobiler.Core.Controls.MobileUserControl
    {
        #region "SmobilerUserControl generated code "

        public frmLocationRowsButtonLayout()
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
            this.btnEdit = new Smobiler.Core.Controls.Button();
            this.btnDelete = new Smobiler.Core.Controls.Button();
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.White;
            this.btnEdit.BorderRadius = 0;
            this.btnEdit.ForeColor = System.Drawing.Color.DimGray;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(300, 35);
            this.btnEdit.Text = "编辑此区域";
            this.btnEdit.Press += new System.EventHandler(this.btnEdit_Press);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.White;
            this.btnDelete.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.btnDelete.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnDelete.BorderRadius = 0;
            this.btnDelete.ForeColor = System.Drawing.Color.DimGray;
            this.btnDelete.Location = new System.Drawing.Point(0, 35);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(300, 35);
            this.btnDelete.Text = "删除此区域";
            this.btnDelete.Press += new System.EventHandler(this.btnDelete_Press);
            // 
            // frmLocationRowsButtonLayout
            // 
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.btnEdit,
            this.btnDelete});
            this.Size = new System.Drawing.Size(0, 70);
            this.Load += new System.EventHandler(this.frmLocationRowsButtonLayout_Load);
            this.Name = "frmLocationRowsButtonLayout";

        }
        #endregion

        internal Smobiler.Core.Controls.Button btnEdit;
        internal Smobiler.Core.Controls.Button btnDelete;
    }
}