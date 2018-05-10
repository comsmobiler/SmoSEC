using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smobiler.Core;
using Smobiler.Core.Controls;
using SMOSEC.Domain.Entity;
using SMOSEC.CommLib;
using SMOSEC.UI.MasterData;

namespace SMOSEC.UI.Layout
{
    ////ToolboxItem用于控制是否添加自定义控件到工具箱，true添加，false不添加
    //[System.ComponentModel.ToolboxItem(true)]
    partial class frmLocationCreateLayout : Smobiler.Core.Controls.MobileUserControl
    {
        #region "define"
        AutofacConfig autofacConfig = new AutofacConfig();
        public String ID;        //区域编号
        public Boolean isCreate = false;       //页面是否为创建状态
        public Boolean isEdit = false;      //页面是否为编辑状态
        private String OldManger;          //区域原管理员
        #endregion
        /// <summary>
        /// 取消操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Press(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 提交操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Press(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtID.Text)) throw new Exception("区域编号不能为空");
                if (String.IsNullOrEmpty(txtName.Text)) throw new Exception("区域名称不能为空");
                if (btnManager.Tag == null) throw new Exception("区域负责人不能为空");

                AssLocation ass = autofacConfig.assLocationService.GetByManager(btnManager.Tag.ToString());
                String[] data= btnManager.Text.Split(' ');
                if (ass != null) throw new Exception(data[0] + "已经是区域管理员,请选择其他用户！");
                //获取创建区域信息
                AssLocation AssLoc = new AssLocation
                {
                    LOCATIONID = txtID.Text,
                    NAME = txtName.Text,
                    MANAGER = btnManager.Tag.ToString(),
                };
                if (isCreate == true)     //新建区域
                {
                    ReturnInfo r = autofacConfig.assLocationService.AddAssLocation(AssLoc);
                    if (r.IsSuccess == false)
                    {
                        throw new Exception(r.ErrorInfo);
                    }
                    else
                    {
                        this.Close();
                        Form.Toast("区域创建成功");
                    }
                }
                else      //更新区域
                {
                    ReturnInfo r = autofacConfig.assLocationService.UpdateAssLocation(AssLoc,OldManger);
                    if (r.IsSuccess == false)
                    {
                        throw new Exception(r.ErrorInfo);
                    }
                    else
                    {
                        this.Close();
                        Form.Toast("修改区域信息成功");
                    }
                }
                //刷新显示列表
                ((frmLocationRows)Form).Bind();
            }
            catch (Exception ex)
            {
                this.Form.Toast(ex.Message);
            }
        }
        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmLocationCreateLayout_Load(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(ID) == false)    //区域信息编辑
            {
                AssLocation location = autofacConfig.assLocationService.GetByID(ID);
                coreUser core = autofacConfig.coreUserService.GetUserByID(location.MANAGER);
                txtID.ReadOnly = true;                //区域编号不允许修改
                this.txtID.Text = ID;                 //区域编号
                this.txtName.Text = location.NAME;          //区域名称
                this.btnManager.Text = core.USER_NAME + "   > ";     //区域管理者名称
                this.btnManager.Tag = location.MANAGER;    //区域管理者编号
                OldManger = location.MANAGER;        //区域的原管理员
            }
        }
        /// <summary>
        /// 区域负责人选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnManager_Press(object sender, EventArgs e)
        {
            try
            {
                popManager.Groups.Clear();
                popManager.Groups.Clear();       //数据清空
                PopListGroup poli = new PopListGroup();
                popManager.Groups.Add(poli);
                poli.Title = "负责人选择";
                List<coreUser> users = autofacConfig.coreUserService.GetAll();
                foreach (coreUser Row in users)
                {
                    poli.AddListItem(Row.USER_NAME, Row.USER_ID);
                }
                if (btnManager.Tag != null)   //如果已有选中项，则显示选中效果
                {
                    foreach (PopListItem Item in poli.Items)
                    {
                        if (Item.Value == btnManager.Tag.ToString())
                            popManager.SetSelections(Item);
                    }
                }
                popManager.ShowDialog();
            }
            catch(Exception ex)
            {
                Form.Toast(ex.Message);
            }
        }
        /// <summary>
        /// 责任人选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void popManager_Selected(object sender, EventArgs e)
        {
            if(btnManager.Tag == null)
            {
                btnManager.Tag = popManager.Selection.Value;
                btnManager.Text = popManager.Selection.Text + "   > ";
            }
            else if(popManager.Selection.Value != btnManager.Tag.ToString())
            {
                btnManager.Tag = popManager.Selection.Value;
                btnManager.Text = popManager.Selection.Text + "   > ";
            }
        }
    }
}