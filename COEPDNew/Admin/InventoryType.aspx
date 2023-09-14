﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="InventoryType.aspx.cs" Inherits="Admin_InventoryType" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Register Src="~/Controls/FormMessage.ascx" TagName="FormMessage" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/ErrorMessage.ascx" TagName="ErrorMessage" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function checkSpcialChar(event) {
            if (!((event.keyCode >= 65) && (event.keyCode <= 90) || (event.keyCode >= 97) && (event.keyCode <= 122) || (event.keyCode == 32))) {
                event.returnValue = false;
                return;
            }
            event.returnValue = true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpLeft" runat="Server">
    <uc1:FormMessage ID="FormMessage" runat="server" Visible="false" />
    <uc2:ErrorMessage ID="ErrorMessage" runat="server" Visible="false" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                                Inventory Type
                            </label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtInventoryType" runat="server" MaxLength="500" Required=""></asp:TextBox>
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
    <div class="box-theme">
        <div class="box-title">
            <div class="box-head">
            </div>
        </div>
        <div class="form-group">
            <div class="form-horizontal no-margin">
            </div>
        </div>
    </div>
</asp:Content>
