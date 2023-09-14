﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;

public partial class LocationSearch : System.Web.UI.Page
{
    //CurrentUser CurrentUser = new CurrentUser();
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

    protected void BindData()
    {
        clsLocation obj = new clsLocation();
        if (txtLocation.Text != "")
            obj.Location = txtLocation.Text;
        if (txtFullname.Text != "")
            obj.Fullname = txtFullname.Text;
        if (textModified.Text != "")
            obj.Modifiedname = textModified.Text;
        gv.DataSource = obj.LoadAll(obj);
        gv.DataBind();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("Location.aspx");
    }

    protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv.PageIndex = e.NewPageIndex;
        BindData();
    }
    protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "cmdEdit")
        {

            Response.Redirect("Location.aspx?ItemId=" + e.CommandArgument);
        }
        else if (e.CommandName == "cmdDelete")
        {

            int ItemId = Convert.ToInt16(e.CommandArgument);
            clsLocation Item = new clsLocation();
            Item.Remove(ItemId);
            BindData();
            FormMessage.Text = "Location successfully removed";
            ErrorMessage.Visible = false;
            FormMessage.Visible = true;
        }
    }

    protected void txtLocation_TextChanged(object sender, EventArgs e)
    {
        BindData();
    }
    protected void txtFullname_TextChanged(object sender, EventArgs e)
    {
        BindData();

    }
    protected void textModified_TextChanged(object sender, EventArgs e)
    {
        BindData();
    }
    protected void gv_PreRender(object sender, EventArgs e)
    {
        PageNumberHeader.Text = " Displaying Page " + (gv.PageIndex + 1).ToString() + " of " + (gv.PageCount).ToString();
        PageNumberHeader.ForeColor = System.Drawing.Color.LightSteelBlue;
        PageNumberHeader.Font.Bold = true;
        PageNumberFooter.Text = " Displaying Page " + (gv.PageIndex + 1).ToString() + " of " + (gv.PageCount).ToString();
        PageNumberFooter.ForeColor = System.Drawing.Color.LightSteelBlue;
        PageNumberFooter.Font.Bold = true;
    }
}