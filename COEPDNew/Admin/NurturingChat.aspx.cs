﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;

public partial class Admin_NurturingChat : System.Web.UI.Page
{
    CurrentUser CurrentUser = new CurrentUser();
    clsNurturingChat Item;
    int ItemId = 0;
    int ParticipantId = 0;
    int NurturingProcessStageId = 0;
    int NurturingProcessStageTaskId = 0;
    string Message = "";
    protected void Page_PreInit(object sender, EventArgs e)
    {
        Page.Theme = "admin";
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        ItemId = Convert.ToInt32(Request.QueryString["ItemId"]);
        Item = new clsNurturingChat();
        if (ItemId > 0)
        {
            Item = Item.Load(ItemId);
            if (Item != null)
            {
                ParticipantId = Item.ParticipantId;
                NurturingProcessStageId = Convert.ToInt32(Item.NurturingProcessStageId);
                NurturingProcessStageTaskId = Convert.ToInt32(Item.NurturingProcessStageTaskId);
                Message = Item.Chat;
                if (Item.SenderImagePath != "")
                    hplSentFile.NavigateUrl = "~/UserDocs/NurturingServiceRequests/" + Item.SenderImagePath;
                else
                    hplSentFile.Visible = false;
                if (Item.ReceiverImagePath != "")
                    hplReplyFile.NavigateUrl = "~/UserDocs/NurturingServiceRequests/" + Item.ReceiverImagePath;
                else
                    hplReplyFile.Visible = false;
            }
            BindData();
        }
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        if (txtChat.Text.Length > 0)
        {
            if (ItemId > 0)
            {
                clsNurturingChat ParticipantNurturingChatUpdate = new clsNurturingChat();
                ParticipantNurturingChatUpdate.NurturingChatId = ItemId;
                ParticipantNurturingChatUpdate.EmployeeId = 0;
                ParticipantNurturingChatUpdate.ParticipantId = ParticipantId;
                ParticipantNurturingChatUpdate.Chat = Message;
                ParticipantNurturingChatUpdate.NurturingProcessStageId = NurturingProcessStageId;
                ParticipantNurturingChatUpdate.NurturingProcessStageTaskId = NurturingProcessStageTaskId;
                ParticipantNurturingChatUpdate.CreatedBy = CurrentUser.CurrentUserId;
                ParticipantNurturingChatUpdate.IsReplied = Convert.ToBoolean(1);
                if (flUpload.HasFile)
                {
                    clsFileUpload Upload = new clsFileUpload();
                    string filePath = Upload.NurturingServiceRequestFileUpload(flUpload);
                    ParticipantNurturingChatUpdate.ReceiverImagePath = filePath;
                }
                ParticipantNurturingChatUpdate.AddUpdate(ParticipantNurturingChatUpdate);
            }

            clsNurturingChat ParticipantNurturingChat = new clsNurturingChat();
            ParticipantNurturingChat.EmployeeId = Convert.ToInt16(CurrentUser.CurrentEmployeeId);
            ParticipantNurturingChat.ParticipantId = ParticipantId;
            ParticipantNurturingChat.Chat = txtChat.Text;
            ParticipantNurturingChat.NurturingProcessStageId = NurturingProcessStageId;
            ParticipantNurturingChat.NurturingProcessStageTaskId = NurturingProcessStageTaskId;
            ParticipantNurturingChat.CreatedBy = CurrentUser.CurrentUserId;
            ParticipantNurturingChat.IsReplied = Convert.ToBoolean(1);
            if (flUpload.HasFile)
            {
                clsFileUpload Upload = new clsFileUpload();
                string filePath = Upload.NurturingServiceRequestFileUpload(flUpload);
                ParticipantNurturingChat.ReceiverImagePath = filePath;
            }
            ParticipantNurturingChat.AddUpdate(ParticipantNurturingChat);
            txtChat.Text = "";
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "randomtext", "alertmeSave()", true);
            //Response.Redirect("NurturingChatChat.aspx?ItemId=" + ItemId);
            BindData();
            flUpload.Enabled = false;
            btnSend.Enabled = false;
            txtChat.Enabled = false;
            //Response.Redirect("NurturingChatSearch.aspx");
        }
    }
    protected void BindData()
    {
        clsNurturingChat Item = new clsNurturingChat();
        Item.ParticipantId = ParticipantId;
        Item.NurturingProcessStageTaskId = NurturingProcessStageTaskId;
        rp.DataSource = Item.LoadAll(Item);
        rp.DataBind();
    }
    protected void rp_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        RepeaterItem item = e.Item;
        if (item.ItemType == ListItemType.AlternatingItem || item.ItemType == ListItemType.Item)
        {
            HiddenField hdnRoleId = (HiddenField)item.FindControl("hdnRoleId");
            int RoleId = Convert.ToInt16(hdnRoleId.Value);

            if (RoleId == 2)
            {
                Panel pnlIn = (Panel)item.FindControl("pnlIn");
                pnlIn.Visible = true;
            }
            else
            {
                Panel PnlOut = (Panel)item.FindControl("PnlOut");
                PnlOut.Visible = true;
            }
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("NurturingChatSearch.aspx");
    }
}