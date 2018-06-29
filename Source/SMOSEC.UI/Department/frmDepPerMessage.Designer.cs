using System;
using Smobiler.Core;
namespace SMOSEC.UI.Department
{
    partial class frmDepPerMessage : Smobiler.Core.Controls.MobileForm
    {
        #region "SmobilerForm generated code "

        public frmDepPerMessage()
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
            this.title1 = new SMOSEC.UI.UserControl.Title();
            this.spContent = new Smobiler.Core.Controls.Panel();
            this.plSex = new Smobiler.Core.Controls.Panel();
            this.label1 = new Smobiler.Core.Controls.Label();
            this.lblSex = new Smobiler.Core.Controls.Label();
            this.plAddress = new Smobiler.Core.Controls.Panel();
            this.label5 = new Smobiler.Core.Controls.Label();
            this.lblAddress = new Smobiler.Core.Controls.Label();
            this.plBirthday = new Smobiler.Core.Controls.Panel();
            this.label4 = new Smobiler.Core.Controls.Label();
            this.dpkBirthday = new Smobiler.Core.Controls.DatePicker();
            this.label6 = new Smobiler.Core.Controls.Label();
            this.plUser = new Smobiler.Core.Controls.Panel();
            this.label7 = new Smobiler.Core.Controls.Label();
            this.lblID = new Smobiler.Core.Controls.Label();
            this.plTel = new Smobiler.Core.Controls.Panel();
            this.Label2 = new Smobiler.Core.Controls.Label();
            this.lblPhone = new Smobiler.Core.Controls.Label();
            this.plEmail = new Smobiler.Core.Controls.Panel();
            this.label3 = new Smobiler.Core.Controls.Label();
            this.lblEmail = new Smobiler.Core.Controls.Label();
            this.Panel1 = new Smobiler.Core.Controls.Panel();
            this.lblName = new Smobiler.Core.Controls.Label();
            this.imgUser = new Smobiler.Core.Controls.Image();
            this.plLocation = new Smobiler.Core.Controls.Panel();
            this.label9 = new Smobiler.Core.Controls.Label();
            this.lblLocation = new Smobiler.Core.Controls.Label();
            // 
            // title1
            // 
            this.title1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(164)))), ((int)(((byte)(229)))));
            this.title1.Dock = System.Windows.Forms.DockStyle.Top;
            this.title1.FontSize = 15F;
            this.title1.ForeColor = System.Drawing.Color.White;
            this.title1.Location = new System.Drawing.Point(107, 51);
            this.title1.Name = "title1";
            this.title1.Size = new System.Drawing.Size(100, 40);
            this.title1.TitleText = "个人信息";
            // 
            // spContent
            // 
            this.spContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.spContent.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.plSex,
            this.plAddress,
            this.plBirthday,
            this.label6,
            this.plUser,
            this.plTel,
            this.plEmail,
            this.Panel1,
            this.plLocation});
            this.spContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spContent.Location = new System.Drawing.Point(0, 180);
            this.spContent.Name = "spContent";
            this.spContent.Scrollable = true;
            this.spContent.Size = new System.Drawing.Size(300, 40);
            // 
            // plSex
            // 
            this.plSex.BackColor = System.Drawing.Color.White;
            this.plSex.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 1F);
            this.plSex.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.plSex.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.label1,
            this.lblSex});
            this.plSex.Location = new System.Drawing.Point(0, 140);
            this.plSex.Name = "plSex";
            this.plSex.Size = new System.Drawing.Size(300, 35);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(59)))), ((int)(((byte)(106)))));
            this.label1.Name = "label1";
            this.label1.Padding = new Smobiler.Core.Controls.Padding(10F, 0F, 0F, 0F);
            this.label1.Size = new System.Drawing.Size(80, 35);
            this.label1.Text = "性别";
            // 
            // lblSex
            // 
            this.lblSex.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.lblSex.Location = new System.Drawing.Point(80, 0);
            this.lblSex.Name = "lblSex";
            this.lblSex.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 10F, 0F);
            this.lblSex.Size = new System.Drawing.Size(220, 35);
            // 
            // plAddress
            // 
            this.plAddress.BackColor = System.Drawing.Color.White;
            this.plAddress.Border = new Smobiler.Core.Controls.Border(0F, 0F, 0F, 1F);
            this.plAddress.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.plAddress.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.label5,
            this.lblAddress});
            this.plAddress.Location = new System.Drawing.Point(0, 175);
            this.plAddress.Name = "plAddress";
            this.plAddress.Size = new System.Drawing.Size(300, 35);
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(59)))), ((int)(((byte)(106)))));
            this.label5.Name = "label5";
            this.label5.Padding = new Smobiler.Core.Controls.Padding(10F, 0F, 0F, 0F);
            this.label5.Size = new System.Drawing.Size(80, 35);
            this.label5.Text = "地址";
            // 
            // lblAddress
            // 
            this.lblAddress.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.lblAddress.Location = new System.Drawing.Point(80, 0);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 10F, 0F);
            this.lblAddress.Size = new System.Drawing.Size(220, 35);
            // 
            // plBirthday
            // 
            this.plBirthday.BackColor = System.Drawing.Color.White;
            this.plBirthday.Border = new Smobiler.Core.Controls.Border(0F, 0F, 0F, 1F);
            this.plBirthday.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.plBirthday.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.label4,
            this.dpkBirthday});
            this.plBirthday.Location = new System.Drawing.Point(0, 210);
            this.plBirthday.Name = "plBirthday";
            this.plBirthday.Size = new System.Drawing.Size(300, 35);
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(59)))), ((int)(((byte)(106)))));
            this.label4.Name = "label4";
            this.label4.Padding = new Smobiler.Core.Controls.Padding(10F, 0F, 0F, 0F);
            this.label4.Size = new System.Drawing.Size(80, 35);
            this.label4.Text = "出生日期";
            // 
            // dpkBirthday
            // 
            this.dpkBirthday.Enabled = false;
            this.dpkBirthday.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.dpkBirthday.Location = new System.Drawing.Point(80, 0);
            this.dpkBirthday.Name = "dpkBirthday";
            this.dpkBirthday.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 10F, 0F);
            this.dpkBirthday.Size = new System.Drawing.Size(220, 35);
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(0, 280);
            this.label6.Name = "label6";
            this.label6.Padding = new Smobiler.Core.Controls.Padding(10F, 0F, 0F, 0F);
            this.label6.Size = new System.Drawing.Size(300, 30);
            this.label6.Text = "基本信息";
            // 
            // plUser
            // 
            this.plUser.BackColor = System.Drawing.Color.White;
            this.plUser.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 1F);
            this.plUser.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.plUser.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.label7,
            this.lblID});
            this.plUser.Location = new System.Drawing.Point(0, 310);
            this.plUser.Name = "plUser";
            this.plUser.Size = new System.Drawing.Size(300, 35);
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(59)))), ((int)(((byte)(106)))));
            this.label7.Name = "label7";
            this.label7.Padding = new Smobiler.Core.Controls.Padding(10F, 0F, 0F, 0F);
            this.label7.Size = new System.Drawing.Size(80, 40);
            this.label7.Text = "账号";
            // 
            // lblID
            // 
            this.lblID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(144)))), ((int)(((byte)(145)))));
            this.lblID.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.lblID.Location = new System.Drawing.Point(80, 0);
            this.lblID.Name = "lblID";
            this.lblID.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 10F, 0F);
            this.lblID.Size = new System.Drawing.Size(220, 40);
            // 
            // plTel
            // 
            this.plTel.BackColor = System.Drawing.Color.White;
            this.plTel.Border = new Smobiler.Core.Controls.Border(0F, 0F, 0F, 1F);
            this.plTel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.plTel.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.Label2,
            this.lblPhone});
            this.plTel.Location = new System.Drawing.Point(0, 345);
            this.plTel.Name = "plTel";
            this.plTel.Size = new System.Drawing.Size(300, 35);
            // 
            // Label2
            // 
            this.Label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(59)))), ((int)(((byte)(106)))));
            this.Label2.Name = "Label2";
            this.Label2.Padding = new Smobiler.Core.Controls.Padding(10F, 0F, 0F, 0F);
            this.Label2.Size = new System.Drawing.Size(80, 35);
            this.Label2.Text = "电话";
            // 
            // lblPhone
            // 
            this.lblPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(144)))), ((int)(((byte)(145)))));
            this.lblPhone.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.lblPhone.Location = new System.Drawing.Point(80, 0);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 10F, 0F);
            this.lblPhone.Size = new System.Drawing.Size(220, 40);
            // 
            // plEmail
            // 
            this.plEmail.BackColor = System.Drawing.Color.White;
            this.plEmail.Border = new Smobiler.Core.Controls.Border(0F, 0F, 0F, 1F);
            this.plEmail.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.plEmail.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.label3,
            this.lblEmail});
            this.plEmail.Location = new System.Drawing.Point(0, 380);
            this.plEmail.Name = "plEmail";
            this.plEmail.Size = new System.Drawing.Size(300, 35);
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(59)))), ((int)(((byte)(106)))));
            this.label3.Name = "label3";
            this.label3.Padding = new Smobiler.Core.Controls.Padding(10F, 0F, 0F, 0F);
            this.label3.Size = new System.Drawing.Size(80, 40);
            this.label3.Text = "邮箱";
            // 
            // lblEmail
            // 
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(144)))), ((int)(((byte)(145)))));
            this.lblEmail.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.lblEmail.Location = new System.Drawing.Point(80, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 10F, 0F);
            this.lblEmail.Size = new System.Drawing.Size(220, 40);
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(164)))), ((int)(((byte)(229)))));
            this.Panel1.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.lblName,
            this.imgUser});
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(300, 140);
            // 
            // lblName
            // 
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Center;
            this.lblName.Location = new System.Drawing.Point(106, 100);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(80, 31);
            // 
            // imgUser
            // 
            this.imgUser.Location = new System.Drawing.Point(106, 10);
            this.imgUser.Name = "imgUser";
            this.imgUser.Size = new System.Drawing.Size(88, 88);
            // 
            // plLocation
            // 
            this.plLocation.BackColor = System.Drawing.Color.White;
            this.plLocation.Border = new Smobiler.Core.Controls.Border(0F, 0F, 0F, 1F);
            this.plLocation.BorderColor = System.Drawing.Color.LightGray;
            this.plLocation.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.label9,
            this.lblLocation});
            this.plLocation.Location = new System.Drawing.Point(0, 245);
            this.plLocation.Name = "plLocation";
            this.plLocation.Size = new System.Drawing.Size(300, 35);
            // 
            // label9
            // 
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.label9.Name = "label9";
            this.label9.Padding = new Smobiler.Core.Controls.Padding(10F, 0F, 0F, 0F);
            this.label9.Size = new System.Drawing.Size(80, 35);
            this.label9.Text = "所属区域";
            // 
            // lblLocation
            // 
            this.lblLocation.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Right;
            this.lblLocation.Location = new System.Drawing.Point(80, 0);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Padding = new Smobiler.Core.Controls.Padding(0F, 0F, 10F, 0F);
            this.lblLocation.Size = new System.Drawing.Size(220, 35);
            // 
            // frmDepPerMessage
            // 
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.title1,
            this.spContent});
            this.Statusbar = new Smobiler.Core.Controls.MobileFormStatusbar(Smobiler.Core.Controls.MobileFormStatusbarStyle.Default, System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(164)))), ((int)(((byte)(229))))));
            this.Load += new System.EventHandler(this.frmDepPerMessage_Load);
            this.Name = "frmDepPerMessage";

        }
        #endregion

        private UserControl.Title title1;
        private Smobiler.Core.Controls.Panel spContent;
        internal Smobiler.Core.Controls.Panel plSex;
        private Smobiler.Core.Controls.Label label1;
        internal Smobiler.Core.Controls.Panel plAddress;
        private Smobiler.Core.Controls.Label label5;
        internal Smobiler.Core.Controls.Panel plBirthday;
        private Smobiler.Core.Controls.Label label4;
        internal Smobiler.Core.Controls.DatePicker dpkBirthday;
        private Smobiler.Core.Controls.Label label6;
        internal Smobiler.Core.Controls.Panel plUser;
        private Smobiler.Core.Controls.Label label7;
        private Smobiler.Core.Controls.Label lblID;
        internal Smobiler.Core.Controls.Panel plTel;
        private Smobiler.Core.Controls.Label Label2;
        private Smobiler.Core.Controls.Label lblPhone;
        internal Smobiler.Core.Controls.Panel plEmail;
        private Smobiler.Core.Controls.Label label3;
        private Smobiler.Core.Controls.Label lblEmail;
        internal Smobiler.Core.Controls.Panel Panel1;
        internal Smobiler.Core.Controls.Label lblName;
        private Smobiler.Core.Controls.Panel plLocation;
        private Smobiler.Core.Controls.Label label9;
        private Smobiler.Core.Controls.Image imgUser;
        private Smobiler.Core.Controls.Label lblSex;
        private Smobiler.Core.Controls.Label lblAddress;
        private Smobiler.Core.Controls.Label lblLocation;
    }
}