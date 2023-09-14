﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
public partial class CalenderSearch : System.Web.UI.Page
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
            BindCourse();
            BindBatchType();
            BindLocation();
            BindData();
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("Calender.aspx");
    }
    protected void BindCourse()
    {
        clsCourse obj = new clsCourse();
        ddlCourse.DataSource = obj.LoadAll(obj);
        ddlCourse.DataTextField = "Course";
        ddlCourse.DataValueField = "CourseId";
        ddlCourse.DataBind();
        ddlCourse.Items.Insert(0, new ListItem("-- Select Course --", "0"));
    }
    protected void BindBatchType()
    {
        clsBatchType obj = new clsBatchType();
        ddlBatchType.DataSource = obj.LoadAll(obj);
        ddlBatchType.DataTextField = "BatchType";
        ddlBatchType.DataValueField = "BatchTypeId";
        ddlBatchType.DataBind();
        ddlBatchType.Items.Insert(0, new ListItem("-- Select Batch Type --", "0"));
    }
    protected void BindLocation()
    {
        clsLocation obj = new clsLocation();
        ddlLocation.DataSource = obj.LoadAll(obj);
        ddlLocation.DataTextField = "Location";
        ddlLocation.DataValueField = "LocationId";
        ddlLocation.DataBind();
        ddlLocation.Items.Insert(0, new ListItem("-- Select Location --", "0"));
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindData();
    }
    protected void BindData()
    {
        clsCalender obj = new clsCalender();
        obj.IsActive = true;
        obj.CourseId = Convert.ToInt16(ddlCourse.SelectedValue);
        obj.BatchTypeId = Convert.ToInt16(ddlBatchType.SelectedValue);
        obj.LocationId = Convert.ToInt16(ddlLocation.SelectedValue);
        gv.DataSource = obj.LoadAll(obj);
        gv.DataBind();
    }
    protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "cmdEdit")
        {
            Response.Redirect("Calender.aspx?ItemId=" + e.CommandArgument);
        }
        else if (e.CommandName == "cmdDelete")
        {
            clsCalender Item = new clsCalender();
            int ItemId = Convert.ToInt16(e.CommandArgument);
            Item.Remove(ItemId);
            BindData();
            ErrorMessage.Text = "Calender successfully removed";
            ErrorMessage.Visible = true;
        }
    }
    protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv.PageIndex = e.NewPageIndex;
        BindData();
    }
    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindData();
    }
    protected void ddlBatchType_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindData();
    }
    protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindData();
    }
}