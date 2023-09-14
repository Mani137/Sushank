﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="ActivityTasks.aspx.cs" Inherits="Admin_ActivityTasks" %>

<%@ Register Src="~/Controls/FormMessage.ascx" TagName="FormMessage" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/ErrorMessage.ascx" TagName="ErrorMessage" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpLeft" runat="Server">
    <uc1:FormMessage ID="FormMessage" runat="server" Visible="false" />
    <uc2:ErrorMessage ID="ErrorMessage" runat="server" Visible="false" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="scriptmanager" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-lg-12 col-md-12">
                    <div class="widget">
                        <div class="widget-header">
                            <div class="title">
                                Activity Tasks
                            </div>
                        </div>
                        <div class="widget-body">
                            <div class="row">
                                <div class="form-group">
                                    <div class="col-lg-3 col-md-3">
                                        <asp:TextBox runat="server" ID="txtActivityCategory" MaxLength="500" placeholder="Search By Activity Category" OnTextChanged="txtActivityCategory_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-3 col-md-3">
                                        <asp:TextBox runat="server" ID="txtActivitySubCategory" MaxLength="500" placeholder="Search By Activity Subcategory" OnTextChanged="txtActivitySubCategory_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-3 col-md-3">
                                        <asp:TextBox runat="server" ID="txtActivity" MaxLength="500" placeholder="Search By Activity" OnTextChanged="txtActivity_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-3 col-md-3">
                                        <asp:TextBox runat="server" ID="txtCreatedBy" MaxLength="500" placeholder="Search By Created By" OnTextChanged="txtCreatedBy_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <br />
                                <div class="form-group">
                                    <div class="col-lg-3 col-md-3">
                                        <asp:TextBox runat="server" ID="txtInvolvedEmployees" placeholder="Search By Involved Employees" OnTextChanged="txtInvolvedEmployees_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-3 col-md-3">
                                        <asp:TextBox runat="server" ID="txtInvolvedParticipants" placeholder="Search By Involved Participants" OnTextChanged="txtInvolvedParticipants_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-3 col-md-3">
                                        <asp:TextBox runat="server" ID="txtInvolvedLeads" placeholder="Search By Involved Leads" OnTextChanged="txtInvolvedLeads_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-3 col-md-3">
                                        <asp:TextBox runat="server" ID="txtInvolvedVendors" placeholder="Search By Involved Vendors" OnTextChanged="txtInvolvedVendors_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <br />
                                <div class="form-group">
                                    <div class="col-lg-3 col-md-3">
                                        <asp:TextBox runat="server" ID="txtStatus" MaxLength="100" placeholder="Search By Status" OnTextChanged="txtStatus_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-3 col-md-3">
                                        <asp:TextBox runat="server" ID="txtParticipantsPhone" MaxLength="100" placeholder="Search By Participants Phone Numbers" OnTextChanged="txtParticipantsPhone_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-3 col-md-3">
                                        <asp:TextBox runat="server" ID="txtLeadsPhone" MaxLength="100" placeholder="Search By Leads Phone Number" OnTextChanged="txtLeadsPhone_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-1  col-md-1">
                                        <asp:Button ID="btnAddNew" runat="server" SkinID="addnew" AutoPostBack="True" CausesValidation="false" OnClick="btnAddNew_Click" />
                                    </div>
                                    <div class="col-lg-2 col-md-2">
                                        <asp:Button ID ="btnGoTODailyReport" runat="server" Text="Go To Daily Report" OnClick="btnGoTODailyReport_Click" />
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div>
                                <asp:Label ID="PageNumberHeader" runat="server"></asp:Label>
                            </div>
                            <div class="widget-body">
                                <div class="row">
                                    <div class="table-responsive">

                                        <asp:GridView ID="gv" runat="server" AutoGenerateColumns="false" OnRowCommand="gv_RowCommand" OnPageIndexChanging="gv_PageIndexChanging" PageSize="10" AllowPaging="true" OnRowDataBound="gv_RowDataBound" ShowHeaderWhenEmpty="true" EmptyDataText="No Records Found!" OnPreRender="gv_PreRender">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="150px">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkEdit" runat="server" SkinID="edit" CommandName="cmdEdit"
                                                            CommandArgument='<%#Eval("ActivityInstanceId")%>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="Activity Task Id" DataField="ActivityInstanceId" />
                                                <%--<asp:BoundField HeaderText="Activity Category" DataField="ActivityCategory" />--%>
                                               <%-- <asp:BoundField HeaderText="Activity SubCategory" DataField="ActivitySubCategory" />--%>
                                               <%-- <asp:BoundField HeaderText="Activity" DataField="Activity" />--%>
                                                <%--<asp:BoundField HeaderText="Employee" DataField="Employee" />   --%>
                                                <asp:BoundField HeaderText="Job Description" DataField="JobDescription" />
                                                <asp:BoundField HeaderText="Task Title" DataField="Description" />
                                                <asp:BoundField HeaderText="Target Date" DataField="DateToWorkOn" DataFormatString="{0:dd MMM yyyy}" />
                                                <asp:BoundField HeaderText="Involved Employees" DataField="InvolvedEmployees" />
                                                <asp:BoundField HeaderText="Involved Participants" DataField="InvolvedParticipants" />
                                                <asp:BoundField HeaderText="Involved Leads" DataField="InvolvedLeads" />
                                                <asp:BoundField HeaderText="Involved Vendors" DataField="InvolvedVendors" />
                                                <%--<asp:BoundField HeaderText="ActivityInteractionInputs" DataField="ActivityInteractionInputs" />--%>
                                                <%--<asp:BoundField HeaderText="FollowUpId" DataField="FollowUpId" />--%>
                                                <asp:BoundField HeaderText="Status" DataField="Status" Visible="false" />
                                                <asp:TemplateField HeaderText=" Status" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblstatus" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="Created By" DataField="Fullname" />
                                                <asp:BoundField HeaderText="Created On" DataField="CreatedOn" DataFormatString="{0: dd MMM yyyy hh:mm tt}" />
                                                <%--<asp:BoundField HeaderText="No. of Employees" DataField="NoOfEmployeeId" />
                                                <asp:BoundField HeaderText="No. of Participants" DataField="NoOfParticipantId" />
                                                <asp:BoundField HeaderText="No. of Leads" DataField="NoOfLeads" />
                                                <asp:BoundField HeaderText="No. of Vendors" DataField="NoOfVendors" />--%>
                                                <%--  <asp:BoundField HeaderText="ModifiedOn" DataField="ModifiedOn" />
                        <asp:BoundField HeaderText="ModifiedBy" DataField="ModifiedName" />--%>
                                                <%--<asp:BoundField HeaderText="StartDate" DataField="StartDate" />
                         <asp:BoundField HeaderText="StartTime" DataField="StartTime" DataFormatString="{0:hh:mm:ss}" />
                         <asp:BoundField HeaderText="EndDate" DataField="EndDate" />
                        <asp:BoundField HeaderText="EndTime" DataField="EndTime" DataFormatString="{0:hh:mm:ss}"  />--%>
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
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

