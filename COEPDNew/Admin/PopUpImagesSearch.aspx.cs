﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;

public partial class Admin_PopUpImagesSearch : System.Web.UI.Page
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
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("PopUpImages.aspx");
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindData();
    }
    protected void BindData()
    {
        clsPopUpImages obj = new clsPopUpImages();
      //  obj.Keywords = txtSearch.Text;
        gv.DataSource = obj.LoadAll(obj);
        gv.DataBind();
    }
    protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "cmdEdit")
        {
            Response.Redirect("PopUpImages.aspx?ItemId=" + e.CommandArgument);
        }
        else if (e.CommandName == "cmdDelete")
        {
            clsPopUpImages Item = new clsPopUpImages();
            int ItemId = Convert.ToInt16(e.CommandArgument);
            Item.Remove(ItemId);
            BindData();
            ErrorMessage.Text = "Pop Up Image successfully removed";
            ErrorMessage.Visible = true;
        }
    }
}