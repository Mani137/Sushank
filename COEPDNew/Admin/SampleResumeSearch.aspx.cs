﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
public partial class Admin_SampleResumeSearch : System.Web.UI.Page
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

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindData();
    }

    protected void BindData()
    {
        clsSampleResume obj = new clsSampleResume();
        obj.keywords = txtSearch.Text;
        gv.DataSource = obj.LoadAll(obj);
        gv.DataBind();
    }
    protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "cmdSendResumes")
        {
            Response.Redirect("SampleResumes.aspx?ItemId=" + e.CommandArgument);
        }
      
    }
}