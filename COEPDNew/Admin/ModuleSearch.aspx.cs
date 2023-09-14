﻿//This code behind page is used to Display all Empolyee moduels and to search the Empolyee modules based on Keywords.
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
public partial class ModuleSearch : System.Web.UI.Page
{
    CurrentUser CurrentUser = new CurrentUser();
    protected void Page_PreInit(object sender, EventArgs e)
    {
        Page.Theme = "admin";
    }
   //When page is loading all the employee modules diplayed in Gridview.
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }
    //Used to Add the new module to employee
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("Module.aspx");
    }
    //Based on the keywords we are searching employee modules.
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindData();
    }
    //This Method is used to  bind Empolyee  modules to Gridview and Searching Modules Based on input Keywords.
    protected void BindData()
    {
        clsModule obj = new clsModule();
        obj.keywords = txtSearch.Text;
        gv.DataSource = obj.LoadAll(obj);
        gv.DataBind();
    }
    //GridView RowCommand will fire when click on edit Button.
    protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "cmdEdit")
        {
            Response.Redirect("Module.aspx?ItemId=" + e.CommandArgument);
        }
        //This method is not used now.
        //else if (e.CommandName == "cmdDelete")
        //{
        //    int ItemId = Convert.ToInt16(e.CommandArgument);
        //    clsModule Item = new clsModule();
        //    Item.Remove(ItemId);
        //    BindData();
        //    ErrorMessage.Text = "Item successfully removed";
        //    ErrorMessage.Visible = true;
        //}
    }
}