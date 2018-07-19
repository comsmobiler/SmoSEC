using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smobiler.Core;
using Smobiler.Core.Controls;
using SMOSEC.CommLib;
using SMOSEC.UI.MasterData;

namespace SMOSEC.UI.Layout
{
    ////ToolboxItem用于控制是否添加自定义控件到工具箱，true添加，false不添加
    //[System.ComponentModel.ToolboxItem(true)]
    partial class frmLocationRowsButtonLayout : Smobiler.Core.Controls.MobileUserControl
    {
        #region "define"
        public String ID;       //区域编号或者类别编号
        public String LocName;    //区域名称
        public bool Enable = false;    //是否启用
        AutofacConfig autofacConfig = new AutofacConfig();    //调用配置类
        #endregion
        /// <summary>
        /// 编辑此区域
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Press(object sender, EventArgs e)
        {
            if (this.Form.ToString() == "SMOSEC.UI.MasterData.frmLocationRows")
            {
                frmLocationCreateLayout frm = new frmLocationCreateLayout();
                frm.ID = ID;  //区域编码
                frm.isEdit = true;
                this.Close();
                this.Form.ShowDialog(frm);
            }
            else if (this.Form.ToString() == "SMOSEC.UI.MasterData.frmAssetsTypeRows")
            {
                frmAssetsTypeCreateLayout frm = new frmAssetsTypeCreateLayout();
                frm.ID = ID;      //类别编码
                frm.isEdit = true;     //编辑状态
                this.Close();
                this.Form.ShowDialog(frm);
            }
        }
        /// <summary>
        /// 删除此区域
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Press(object sender, EventArgs e)
        {
            this.Close();
            try
            {
                if (this.Form.ToString() == "SMOSEC.UI.MasterData.frmLocationRows")
                {
                    MessageBox.Show("你确定要删除该区域吗?", "系统提醒", MessageBoxButtons.OKCancel, (object sender1, MessageBoxHandlerArgs args) =>
                      {
                          try
                          {
                              if (args.Result == ShowResult.OK)     //删除该区域
                            {
                                  ReturnInfo r = autofacConfig.assLocationService.DeleteAssLocation(ID);
                                  if (r.IsSuccess == true)
                                  {
                                      this.Form.Toast("删除成功");
                                      ((frmLocationRows)Form).Bind();      //刷新数据
                                }
                                  else
                                  {
                                      throw new Exception(r.ErrorInfo);
                                  }
                              }
                          }
                          catch (Exception ex)
                          {
                              Form.Toast(ex.Message);
                          }
                      });
                }
                else if (this.Form.ToString() == "SMOSEC.UI.MasterData.frmAssetsTypeRows")
                {
                    if (Enable)        //禁用该分类
                    {
                        MessageBox.Show("你确定要禁用该分类吗?", "系统提醒", MessageBoxButtons.OKCancel, (object sender1, MessageBoxHandlerArgs args) =>
                        {
                            try
                            {
                                if (args.Result == ShowResult.OK)
                                {
                                    if (autofacConfig.assTypeService.HasAssets(ID))
                                    {
                                        throw new Exception("当前资产分类有相关的资产数据，不允许禁用!");
                                    }
                                    else if (autofacConfig.assTypeService.IsParent(ID))
                                    {
                                        throw new Exception("当前资产分类有子分类，不允许禁用!");
                                    }
                                    else
                                    {
                                        ReturnInfo r = autofacConfig.assTypeService.ChangeEnable(ID, DTOs.Enum.IsEnable.禁用);
                                        if (r.IsSuccess == true)
                                        {
                                            this.Form.Toast("分类禁用成功!");
                                            ((frmAssetsTypeRows)Form).Bind();
                                        }
                                        else
                                        {
                                            throw new Exception(r.ErrorInfo);
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Form.Toast(ex.Message);
                            }
                        });
                    }
                    else        //启用该分类
                    {
                        MessageBox.Show("你确定要启用该分类吗?", "系统提醒", MessageBoxButtons.OKCancel, (object sender1, MessageBoxHandlerArgs args) =>
                        {
                            try
                            {
                                if (args.Result == ShowResult.OK)
                                {
                                    ReturnInfo r = autofacConfig.assTypeService.ChangeEnable(ID, DTOs.Enum.IsEnable.启用);
                                    if (r.IsSuccess == true)
                                    {
                                        this.Form.Toast("分类启用成功!");
                                        ((frmAssetsTypeRows)Form).Bind();
                                    }
                                    else
                                    {
                                        throw new Exception(r.ErrorInfo);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Form.Toast(ex.Message);
                            }
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Form.Toast(ex.Message);
            }
        }
        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmLocationRowsButtonLayout_Load(object sender, EventArgs e)
        {
            if (this.Form.ToString() == "SMOSEC.UI.MasterData.frmLocationRows")
            {
                btnEdit.Text = "编辑此区域";
                btnDelete.Text = "删除此区域";
            }
            else if (this.Form.ToString() == "SMOSEC.UI.MasterData.frmAssetsTypeRows")
            {
                btnEdit.Text = "编辑此分类";
                if (Enable)
                {
                    btnDelete.Text = "禁用此分类";
                }
                else
                {
                    btnDelete.Text = "启用此分类";
                }
            }
        }
    }
}