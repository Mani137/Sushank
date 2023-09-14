﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="ResumesApprovedSearch.aspx.cs" Inherits="Admin_ResumesApprovedSearch" %>

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
    <div class="row">
        <div class="col-lg-12 col-md-12">
            <div class="widget">
                <div class="widget-header">
                    <div class="title">
                        Approved Resumes
                    </div>
                </div>
                <div class="widget-body">
                    <div class="row">
                       <div class="col-lg-2 col-md-2">
                            <asp:TextBox runat="server" ID="txtSearch" MaxLength="500" placeholder="Search"></asp:TextBox>
                        </div>
                        <div class="col-lg-1 col-md-1">
                           <asp:Button ID="btnSearch" runat="server" Text="Find" OnClick="btnSearch_Click" />
                        </div>
                    </div>
                    <div class="row">
                        &nbsp;
                         
                    </div>
                    <div class="row">
                        <asp:GridView ID="gv" runat="server" OnRowCommand="gv_RowCommand" OnPageIndexChanging="gv_PageIndexChanging"
                            AllowPaging="true" PageSize="20" AutoGenerateColumns="False" Width="100%" >
                            <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" />
                            <Columns>
                               
                                <asp:BoundField HeaderText="SNo" DataField="SNo" ItemStyle-Width="50px" />
                                <asp:BoundField HeaderText="Participant" DataField="Participant" />
                                <asp:BoundField HeaderText="Batch" DataField="StartDate" DataFormatString="{0:dd MMM yyyy}" />
                                <asp:BoundField HeaderText="Location" DataField="Location" />
                                <asp:BoundField HeaderText="Trainer" DataField="Employee" />
                                <asp:BoundField HeaderText="ExpInYears" DataField="ExpInYears" />
                                <asp:BoundField HeaderText="Skills" DataField="Skills" />
                                
                                 <asp:TemplateField HeaderText="Status">
                                 
                                   <ItemTemplate>
                                        <%#Eval("ResumeStatus").ToString() == "False" ? "Pending":"Approved" %>
                                   </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Resume">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkDownload" runat="server" Text="Download" CommandName="cmdDownload"
                                            CommandArgument='<%#Eval("ResumePath")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="150px">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkApprove" runat="server"  Text="View" CssClass="btn btn-success btn-xs" CommandName="cmdView"
                                            CommandArgument='<%#Eval("ResumePreparationId")%>'></asp:LinkButton>
                                       
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                            <EmptyDataTemplate>
                                <center>
                                    No Records Found
                                </center>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Row End -->
</asp:Content>



