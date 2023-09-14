﻿using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_HrProcessStageSearch : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        Page.Theme = "Admin";
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
        clsHrProcessStage obj = new clsHrProcessStage();
        if (txtNurturingProcessStageName.Text != "")
            obj.HrProcessStageName = txtNurturingProcessStageName.Text;
        if (txtCreatedName.Text != "")
            obj.CreatedName = txtCreatedName.Text;
        if (txtModifiedName.Text != "")
            obj.ModifiedName = txtModifiedName.Text;
        gv.DataSource = obj.LoadAll(obj);
        gv.DataBind();
    }
    protected void txtNurturingProcessStageName_TextChanged(object sender, EventArgs e)
    {
        BindData();
    }
    protected void txtCreatedName_TextChanged(object sender, EventArgs e)
    {
        BindData();
    }

    protected void txtModifiedName_TextChanged(object sender, EventArgs e)
    {
        BindData();
    }
    protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "cmdEdit")
        {
            Response.Redirect("HrProcessStage.aspx?ItemId=" + e.CommandArgument);
        }
        else if (e.CommandName == "cmdDelete")
        {
            int ItemId = Convert.ToInt32(e.CommandArgument);
            clsHrProcessStage Item = new clsHrProcessStage();
            Item.Remove(ItemId);
            BindData();
            ErrorMessage.Text = "Hr Process Stage successfully removed";
            ErrorMessage.Visible = true;
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

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("HrProcessStage.aspx");
    }
}