﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="AssignAwardSearch.aspx.cs" Inherits="Admin_AssignAwardSearch" %>
<%@ Register Src="~/Controls/FormMessage.ascx" TagName="FormMessage" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/ErrorMessage.ascx" TagName="ErrorMessage" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpLeft" Runat="Server">
    <uc1:FormMessage ID="FormMessage" runat="server" Visible="false" />
    <uc2:ErrorMessage ID="ErrorMessage" runat="server" Visible="false" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="scriptmanager" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-lg-12 col-md-12">
                    <div class="widget">
                        <div class="widget-header">
                            <div class="title">
                                Assign Award
                            </div>
                        </div>
                        <div class="widget-body">
                            <div class="row">
                                <div class="col-lg-2 col-md-2">
                                    <asp:TextBox runat="server" ID="txtEmployeeName" placeholder="Search By Employee Name" OnTextChanged="txtEmployeeName_TextChanged" AutoPostBack="true" ></asp:TextBox>
                                </div>
                                <div class="col-lg-2 col-md-2">
                                    <asp:TextBox runat="server" ID="txtAward" placeholder="Search By Award" OnTextChanged="txtEmployeeName_TextChanged" AutoPostBack="true" ></asp:TextBox>
                                </div>
                                <div class="col-md-2 col-lg-2">
                                    <asp:TextBox runat="server" ID="txtCreatedByName" placeholder="Search By Created By Name" OnTextChanged="txtEmployeeName_TextChanged" AutoPostBack="true" ></asp:TextBox>
                                </div>
                                <div class="col-lg-2 col-md-2">
                                     <asp:TextBox runat="server" ID="txtModifiedByName" placeholder="Search By Modified By Name" OnTextChanged="txtEmployeeName_TextChanged" AutoPostBack="true" ></asp:TextBox>
                                </div>
                                <div class="col-lg-2 col-md-2">
                                   
                                </div>
                                <div class="col-lg-2 col-md-2">
                                    <asp:Button ID="btnAddNew" runat="server"  SkinID="btnGreen" OnClick="btnAddNew_Click" Text="Add New" />
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

                                         <asp:BoundField HeaderText="Employee" DataField="Employee" />
                                         <asp:BoundField HeaderText="Award" DataField="AwardName"/>
                                         <asp:BoundField HeaderText="Certificate Id" DataField="CertificateId" />
                                         <asp:BoundField HeaderText="Date Of issued" DataField="DateOfIssued" DataFormatString="{0: dd MMM yyyy}" />
                                         <asp:BoundField HeaderText="Issued For the Month" DataField="IssuedFortheMonth" DataFormatString="{0: MMM yyyy}" />
                                         <asp:BoundField HeaderText="Created On" DataField="CreatedOn" DataFormatString="{0: dd MMM yyyy hh:mm tt}" />
                                         <asp:BoundField HeaderText="Created By" DataField="CreatedByName" />
                                         <asp:BoundField HeaderText="Modified On" DataField="ModifiedOn" DataFormatString="{0: dd MMM yyyy hh:mm tt}" />
                                          <asp:BoundField HeaderText="Modified By" DataField="ModifiedByName" />
                                         <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="150px">
                                             <ItemTemplate>
                                                 <asp:LinkButton ID="lnkEdit" runat="server" SkinID="edit" CommandName="cmdEdit"
                                                CommandArgument='<%#Eval("AssignAwardId")%>'></asp:LinkButton>
                                                <%-- <asp:LinkButton ID="lnkDelete" runat="server" SkinID="delete" CommandName="cmdDelete"
                                                CommandArgument='<%#Eval("AssignAwardId")%>' OnClientClick="return confirm('Are you sure you want to Un Assign this Award?');"></asp:LinkButton>--%>
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
</asp:Content>

