using System;
using Smobiler.Core;
namespace SMOSEC.UI.Layout
{
    partial class CollarOrderLayout : Smobiler.Core.Controls.MobileUserControl
    {
        #region "SmobilerUserControl generated code "

        public CollarOrderLayout()
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
            this.Panel1 = new Smobiler.Core.Controls.Panel();
            this.Label1 = new Smobiler.Core.Controls.Label();
            this.Label2 = new Smobiler.Core.Controls.Label();
            this.Label3 = new Smobiler.Core.Controls.Label();
            this.Label4 = new Smobiler.Core.Controls.Label();
            this.Label5 = new Smobiler.Core.Controls.Label();
            this.Label6 = new Smobiler.Core.Controls.Label();
            this.LblID = new Smobiler.Core.Controls.Label();
            this.LblBMan = new Smobiler.Core.Controls.Label();
            this.LblDate = new Smobiler.Core.Controls.Label();
            this.LblDep = new Smobiler.Core.Controls.Label();
            this.LblLocation = new Smobiler.Core.Controls.Label();
            this.LblPlace = new Smobiler.Core.Controls.Label();
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.White;
            this.Panel1.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.Panel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Panel1.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.Label1,
            this.Label2,
            this.Label3,
            this.Label4,
            this.Label5,
            this.Label6,
            this.LblID,
            this.LblBMan,
            this.LblDate,
            this.LblDep,
            this.LblLocation,
            this.LblPlace});
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(300, 96);
            this.Panel1.Touchable = true;
            this.Panel1.Press += new System.EventHandler(this.Panel1_Press);
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(10, 8);
            this.Label1.Name = "Label1";
            this.Label1.Padding = new Smobiler.Core.Controls.Padding(10F, 0F, 0F, 0F);
            this.Label1.Size = new System.Drawing.Size(52, 20);
            this.Label1.Text = "单号";
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.Color.White;
            this.Label2.Location = new System.Drawing.Point(176, 8);
            this.Label2.Name = "Label2";
            this.Label2.Padding = new Smobiler.Core.Controls.Padding(10F, 0F, 0F, 0F);
            this.Label2.Size = new System.Drawing.Size(52, 20);
            this.Label2.Text = "领用人";
            // 
            // Label3
            // 
            this.Label3.BackColor = System.Drawing.Color.White;
            this.Label3.Location = new System.Drawing.Point(10, 28);
            this.Label3.Name = "Label3";
            this.Label3.Padding = new Smobiler.Core.Controls.Padding(10F, 0F, 0F, 0F);
            this.Label3.Size = new System.Drawing.Size(52, 20);
            this.Label3.Text = "日期";
            // 
            // Label4
            // 
            this.Label4.BackColor = System.Drawing.Color.White;
            this.Label4.Location = new System.Drawing.Point(10, 68);
            this.Label4.Name = "Label4";
            this.Label4.Padding = new Smobiler.Core.Controls.Padding(10F, 0F, 0F, 0F);
            this.Label4.Size = new System.Drawing.Size(52, 20);
            this.Label4.Text = "部门";
            // 
            // Label5
            // 
            this.Label5.BackColor = System.Drawing.Color.White;
            this.Label5.Location = new System.Drawing.Point(10, 48);
            this.Label5.Name = "Label5";
            this.Label5.Padding = new Smobiler.Core.Controls.Padding(10F, 0F, 0F, 0F);
            this.Label5.Size = new System.Drawing.Size(52, 20);
            this.Label5.Text = "区域";
            // 
            // Label6
            // 
            this.Label6.BackColor = System.Drawing.Color.White;
            this.Label6.Location = new System.Drawing.Point(176, 48);
            this.Label6.Name = "Label6";
            this.Label6.Padding = new Smobiler.Core.Controls.Padding(10F, 0F, 0F, 0F);
            this.Label6.Size = new System.Drawing.Size(52, 20);
            this.Label6.Text = "地点";
            // 
            // LblID
            // 
            this.LblID.DataMember = "COID";
            this.LblID.DisplayMember = "COID";
            this.LblID.Location = new System.Drawing.Point(62, 8);
            this.LblID.Name = "LblID";
            this.LblID.Padding = new Smobiler.Core.Controls.Padding(10F, 0F, 0F, 0F);
            this.LblID.Size = new System.Drawing.Size(114, 20);
            // 
            // LblBMan
            // 
            this.LblBMan.DataMember = "USERID";
            this.LblBMan.DisplayMember = "USERID";
            this.LblBMan.Location = new System.Drawing.Point(228, 8);
            this.LblBMan.Name = "LblBMan";
            this.LblBMan.Padding = new Smobiler.Core.Controls.Padding(10F, 0F, 0F, 0F);
            this.LblBMan.Size = new System.Drawing.Size(62, 20);
            // 
            // LblDate
            // 
            this.LblDate.DataMember = "COLLARDATE";
            this.LblDate.DisplayMember = "COLLARDATE";
            this.LblDate.Location = new System.Drawing.Point(62, 28);
            this.LblDate.Name = "LblDate";
            this.LblDate.Padding = new Smobiler.Core.Controls.Padding(10F, 0F, 0F, 0F);
            this.LblDate.Size = new System.Drawing.Size(228, 20);
            // 
            // LblDep
            // 
            this.LblDep.DataMember = "InUsedDep";
            this.LblDep.DisplayMember = "InUsedDep";
            this.LblDep.Location = new System.Drawing.Point(62, 68);
            this.LblDep.Name = "LblDep";
            this.LblDep.Padding = new Smobiler.Core.Controls.Padding(10F, 0F, 0F, 0F);
            this.LblDep.Size = new System.Drawing.Size(228, 20);
            // 
            // LblLocation
            // 
            this.LblLocation.DataMember = "LOCATIONNAME";
            this.LblLocation.DisplayMember = "LOCATIONNAME";
            this.LblLocation.Location = new System.Drawing.Point(62, 48);
            this.LblLocation.Name = "LblLocation";
            this.LblLocation.Padding = new Smobiler.Core.Controls.Padding(10F, 0F, 0F, 0F);
            this.LblLocation.Size = new System.Drawing.Size(114, 20);
            // 
            // LblPlace
            // 
            this.LblPlace.DataMember = "PLACE";
            this.LblPlace.DisplayMember = "PLACE";
            this.LblPlace.Location = new System.Drawing.Point(228, 48);
            this.LblPlace.Name = "LblPlace";
            this.LblPlace.Padding = new Smobiler.Core.Controls.Padding(10F, 0F, 0F, 0F);
            this.LblPlace.Size = new System.Drawing.Size(62, 20);
            // 
            // CollarOrderLayout
            // 
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.Panel1});
            this.Size = new System.Drawing.Size(300, 96);
            this.Name = "CollarOrderLayout";

        }
        #endregion

        internal Smobiler.Core.Controls.Panel Panel1;
        internal Smobiler.Core.Controls.Label Label1;
        internal Smobiler.Core.Controls.Label Label2;
        internal Smobiler.Core.Controls.Label Label3;
        internal Smobiler.Core.Controls.Label Label4;
        internal Smobiler.Core.Controls.Label Label5;
        internal Smobiler.Core.Controls.Label Label6;
        internal Smobiler.Core.Controls.Label LblID;
        internal Smobiler.Core.Controls.Label LblBMan;
        internal Smobiler.Core.Controls.Label LblDate;
        internal Smobiler.Core.Controls.Label LblDep;
        internal Smobiler.Core.Controls.Label LblLocation;
        internal Smobiler.Core.Controls.Label LblPlace;
    }
}