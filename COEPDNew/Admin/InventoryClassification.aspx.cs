﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
public partial class Admin_InventoryClassification : System.Web.UI.Page
{
    CurrentUser CurrentUser = new CurrentUser();
    clsInventoryClassification Item;
    int ItemId = 0;

    protected void Page_PreInit(object sender, EventArgs e)
    {
        Page.Theme = "admin";
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        ItemId = Convert.ToInt16(Request.QueryString["ItemId"]);
        Item = new clsInventoryClassification();
        if (!IsPostBack)
        {
            if (ItemId > 0)
            {
                lblTitle.Text = "Edit Classification";
                Item = Item.Load(ItemId);
                if (Item != null)
                {
                    txtInventoryClassification.Text = Item.InventoryClassification;
                }
            }
            else
            {
                lblTitle.Text = "Add New Classification";
            }
        }

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (ItemId > 0)
        {
            Item.InventoryClassificationId = Convert.ToInt16(ItemId);
        }

        Item.InventoryClassification = Convert.ToString(txtInventoryClassification.Text);
        Item.CreatedBy = CurrentUser.CurrentUserId;
        Item.AddUpdate(Item);
        Response.Redirect("InventoryClassificationSearch.aspx");
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("InventoryClassificationSearch.aspx");
    }
}