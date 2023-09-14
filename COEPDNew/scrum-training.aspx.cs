﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;

public partial class scrum_training : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
            BindNewsScroll();
        }
    }
    protected void BindData()
    {
        clsNews obj = new clsNews();
        obj.CMSId = 27;
        dl.DataSource = obj.LoadAll(obj);
        dl.DataBind();
        if (dl.Items.Count == 0)
        {
            divTraningNews.Visible = false;
        }
    }
    protected void BindNewsScroll()
    {
        string strNews = String.Empty;
        List<clsNews> Items = new List<clsNews>();
        clsNews News = new clsNews();
        News.CMSId = 27;
        News.IsFeatured = true;
        News.IsActive = true;
        Items = News.LoadAll(News);
        if (Items != null)
        {
            foreach (clsNews item in Items)
            {
                strNews = strNews + "&nbsp;" + item.NewsDescription + "::& nbsp; &nbsp; ";
            }
            strNews = strNews.Replace("<p>", "");
            strNews = strNews.Replace("<p>", "");
        }

    }
}