﻿<%@ Page Title="" Language="C#" MasterPageFile="Admin.master" AutoEventWireup="true"
    CodeFile="CMS.aspx.cs" Inherits="CMS" %>
<%@ Register Src="~/Controls/FormMessage.ascx" TagName="FormMessage" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/ErrorMessage.ascx" TagName="ErrorMessage" TagPrefix="uc2" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpLeft" runat="Server">
    <uc1:FormMessage ID="FormMessage" runat="server" Visible="false" />
    <uc2:ErrorMessage ID="ErrorMessage" runat="server" Visible="false" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Row Start -->
    <div class="row">
        <div class="col-lg-12 col-md-12">
            <div class="widget">
                <div class="widget-header">
                    <div class="title">
                        <asp:Label ID="lblTitle" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="widget-body">
                    <div class="form-horizontal no-margin">
                        <div class="form-group">
                            <label class="col-sm-2 control-label">
                                Cannonical Link
                            </label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtCannonicalLink" runat="server" Required=""></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">
                                Meta Title
                            </label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtMetaTitle" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">
                                Meta Description
                            </label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtMetaDescription" runat="server" Height="100" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">
                                Meta keywords
                            </label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtMetaContent" runat="server" Height="100" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">
                                Page Title
                            </label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtCMSTitle" runat="server" Required></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">
                                Page Content
                            </label>
                            <div class="col-sm-10">
                                <CKEditor:CKEditorControl ID="txtCMSData" runat="server" Height="300" Toolbar="Basic">
                                </CKEditor:CKEditorControl>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-offset-2 col-sm-10">
                                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Save" />
                                <asp:Button ID="btnCancel" runat="server" Text="Back to list" UseSubmitBehavior="false"
                                    OnClick="btnCancel_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Row End -->
</asp:Content>