﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="BranchPoliciesSearch.aspx.cs" Inherits="Admin_BranchPoliciesSearch" %>
<%@ Register Src="~/Controls/FormMessage.ascx" TagName="FormMessage" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/ErrorMessage.ascx" TagName="ErrorMessage" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpLeft" Runat="Server">
    <uc1:FormMessage ID="FormMessage" runat="server" Visible="false" />
    <uc2:ErrorMessage ID="ErrorMessage" runat="server" Visible="false" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- Row Start -->
    <asp:ScriptManager ID="scriptmanager" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel" runat="server">
    <ContentTemplate>
    <div class="row">
        <div class="col-lg-12 col-md-12">
            <div class="widget">
                <div class="widget-header">
                    <div class="title">
                          Branch Policies
                    </div>
                </div>
                
                <div class="widget-body">
                    <div class="row">
                         <div class="col-lg-2 col-md-2">
                            <asp:TextBox runat="server" ID="txtLocation" MaxLength="500" placeholder="Search Location" OnTextChanged="txtLocation_TextChanged" AutoPostBack="true" ></asp:TextBox>
                        </div>
                        <div class="col-lg-2 col-md-2">
                            <asp:TextBox runat="server" ID="txtBranch" MaxLength="500" placeholder="Search by Branch" OnTextChanged="txtBranch_TextChanged" AutoPostBack="true" ></asp:TextBox>
                        </div>
                          <div class="col-lg-2 col-md-2">
                            <asp:TextBox runat="server" ID="txtPageTitle" MaxLength="500" placeholder="Search By Page Title" OnTextChanged="txtPageTitle_TextChanged" AutoPostBack="true"></asp:TextBox>
                        </div>
                        <div class="col-lg-2 col-md-2">
                            <asp:TextBox runat="server" ID="txtFullname" MaxLength="500" placeholder="Search By Created By" OnTextChanged="txtFullname_TextChanged" AutoPostBack="true" ></asp:TextBox>
                        </div>
                        <div class="col-lg-2 col-md-2">
                            <asp:TextBox runat="server" ID="txtModified" MaxLength="500" placeholder="Search By ModifiedBy" OnTextChanged="txtModified_TextChanged" AutoPostBack="true"></asp:TextBox>
                        </div>
                        <div class="col-lg-2  col-md-2">
                            <asp:Button ID="Button1" runat="server"  SkinID="addnew" AutoPostBack="True" CausesValidation="false" OnClick="Button1_Click"/>
                        </div>
                    </div>
                    <div class="row">
                        &nbsp;
                    </div>
                    <div>
                        <asp:Label ID="PageNumberHeader" runat="server"></asp:Label>
                    </div>
                      <div class="row"> 
                          <asp:GridView ID="gv" runat="server" AutoGenerateColumns="false" PageSize="20" HeaderStyle-HorizontalAlign="Center" Width="100%" AllowPaging="true" AllowSorting="true" OnRowCommand="gv_RowCommand" OnPageIndexChanging="gv_PageIndexChanging" ShowHeaderWhenEmpty="true" EmptyDataText="No Records Found!" OnPreRender="gv_PreRender">
                              <Columns>                                  
                                  <asp:BoundField HeaderText="S.No" DataField="SNo" />
                                  <asp:BoundField HeaderText="Location Name" DataField="Location" />
                                  <asp:BoundField HeaderText="Branch Name" DataField="Branch" />
                                  <asp:BoundField HeaderText="Page Title" DataField="PolicyTitle" />
                                  <asp:BoundField HeaderText="Created By" DataField="Fullname" />
                                   <asp:BoundField HeaderText="Created On" DataField="CreatedOn" DataFormatString="{0: dd MMM yyyy hh:mm tt}" />
                                    <asp:BoundField HeaderText="Modified By" DataField="Modifiedname" />
                                  <asp:BoundField HeaderText="Modified On" DataField="ModifiedOn" DataFormatString="{0: dd MMM yyyy hh:mm tt}" />
                                   <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="150px">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkEdit" runat="server" SkinID="edit" CommandName="cmdEdit"
                                            CommandArgument='<%#Eval("PolicyId")%>'> </asp:LinkButton>
                                        <%--<asp:LinkButton ID="lnkDelete" runat="server" SkinID="delete" CommandName="cmdDelete"
                                            CommandArgument='<%#Eval("PolicyId")%>' OnClientClick="return confirm('Are you sure you want to delete this Branch Policies?');"></asp:LinkButton>--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                              </Columns>
                          </asp:GridView>
                          <div>
                              <asp:Label ID="PageNumberFooter" runat="server"></asp:Label>
                          </div>
                      </div>
                    </div>
                       
                </div>
            </div>
        </div>
     </ContentTemplate>
    </asp:UpdatePanel>
    <!-- Row End -->
</asp:Content>