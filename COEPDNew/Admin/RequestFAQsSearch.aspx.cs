﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;

public partial class Admin_RequestFAQsSearch : System.Web.UI.Page
{
    CurrentUser CurrentUser = new CurrentUser();
    protected void Page_PreInit(object sender, EventArgs e)
    {
        Page.Theme = "admin";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
            
    }

    private void BindData()
    {
        clsRequestFAQs obj = new clsRequestFAQs();
       // obj.KeyWords = txtParticipant.Text;
        if (txtParticipant.Text != "")
        {
            obj.KeyWords = txtParticipant.Text;
        }
        if (txtLocation.Text != "")
        {
            obj.Location = txtLocation.Text;
        }
        if (ddlStatus.SelectedValue != "")
        {
            obj.IsApproved = Convert.ToBoolean(ddlStatus.SelectedValue);
        }
        gv.DataSource = obj.LoadAll(obj);
        gv.DataBind();
    }

    protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "cmdAssign")
        {
            Response.Redirect("RequestFAQs.aspx?itemId=" + e.CommandArgument);
        }
        else if (e.CommandName == "cmdView")
        {
            Response.Redirect("RequestFAQs.aspx?itemId=" + e.CommandArgument);
            //int ItemId = Convert.ToInt16(e.CommandArgument);
            //clsRequestFAQs Item = new clsRequestFAQs();
            //Item.Remove(ItemId);
            //BindData();
            //ErrorMessage.Text = "RequestFAQs successfully removed";
            //ErrorMessage.Visible = true;
        }
    }
    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.DataItem != null)
            {
                HiddenField hdnSendFile = (HiddenField)e.Row.FindControl("hdnSendFile");
                HyperLink hplSendFile = (HyperLink)e.Row.FindControl("hplSendFile");

                if (hdnSendFile.Value == "")
                {
                    hplSendFile.Visible = false;
                }
            }
        }
    }

    protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv.PageIndex = e.NewPageIndex;
        BindData();
    }

    protected void gv_PreRender(object sender, EventArgs e)
    {
        PageNumberHeader.Text = " Displaying Page " + (gv.PageIndex + 1).ToString() + " of " + gv.PageCount.ToString();
        PageNumberHeader.ForeColor = System.Drawing.Color.LightSteelBlue;
        PageNumberHeader.Font.Bold = true;
        PageNumberFooter.Text = " Displaying Page " + (gv.PageIndex + 1).ToString() + " of " + gv.PageCount.ToString();
        PageNumberFooter.ForeColor = System.Drawing.Color.LightSteelBlue;
        PageNumberFooter.Font.Bold = true;
    }

    protected void txtParticipant_TextChanged(object sender, EventArgs e)
    {
        BindData();
    }
    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindData();
    }

    protected void txtLocation_TextChanged(object sender, EventArgs e)
    {
        BindData();
    }


}

   