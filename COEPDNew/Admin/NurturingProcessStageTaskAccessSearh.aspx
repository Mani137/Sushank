﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="NurturingProcessStageTaskAccessSearh.aspx.cs" Inherits="Admin_NurturingProcessStageTaskAccessSearh" %>

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
                        Assign Nurturing Process Stage Tasks To Employees
                    </div>
                </div>
                <div class="widget-body">
                    <div class="row">
                        <div class="col-lg-1 col-md-1">
                            <h5>
                                Nurturing Process Stage</h5>
                        </div>
                        <div class="col-lg-2 col-md-2">
                            <asp:DropDownList ID="ddlNurturingProcessStage" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlNurturingProcessStage_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="col-lg-5 col-md-5">
                        </div>
                        <div class="col-lg-1 col-md-1">
                            <h5>
                                Employee</h5>
                        </div>
                        <div class="col-lg-3 col-md-3">
                            <asp:DropDownList ID="ddlEmployee" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEmployee_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        &nbsp;
                    </div>
                    <div class="row">
                        <div class="col-lg-6 col-md-6">
                            <div class="row col-lg-offset-3">
                                <h4>
                                    Available Nurturing Process Stage Tasks
                                </h4>
                            </div>
                            <div class="table-responsive">
                            <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" Width="100%" OnRowCommand="gv_RowCommand">
                                <Columns>
                                    <asp:BoundField HeaderText="SNo" DataField="SNo" ItemStyle-Width="50px" />
                                    <asp:BoundField HeaderText="Nurturing Process Stage Task" DataField="NurturingProcessStageTaskName" />
                                    <asp:TemplateField >
                                   
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkSend" runat="server" Text="Assign Task" CommandName="cmdAdd"
                                                CssClass="btn btn-primary" CommandArgument='<%#Eval("NurturingProcessStageTaskId")%>'></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate> <%--This Template is uded to display the message when no records find--%>
                                    <center>
                                        No Records Found
                                    </center>
                                </EmptyDataTemplate>
                            </asp:GridView>
                                </div>
                        </div>
                        <div class="col-lg-6 col-md-6">
                            <div class="row col-lg-offset-3">
                                <h4>
                                    Assigned Nurturing Process Stage Tasks
                                </h4>
                            </div>
                            <div class="table-responsive">
                            <asp:GridView ID="gvAssign" runat="server" AutoGenerateColumns="False" Width="100%"
                                OnRowCommand="gvAssign_RowCommand">
                                <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" />
                                <Columns>
                                    <asp:BoundField HeaderText="SNo" DataField="SNo" ItemStyle-Width="50px" />
                                    <asp:BoundField HeaderText="Employee Nurturing Process Stage Tasks" DataField="NurturingProcessStageTaskName" />
                                    <asp:BoundField HeaderText="Task Priority" DataField="TaskPriority" />
                                    <asp:TemplateField HeaderText="Remove " ItemStyle-HorizontalAlign="Center" ItemStyle-Width="150px">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkSend" runat="server" Text="Un-Assign Task " CommandName="cmdRemove"
                                                CssClass="btn btn-info" CommandArgument='<%#Eval("NurturingProcessStageTaskAccessId")%>'></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                <EmptyDataTemplate> <%--This Template is uded to display the message when no records find--%>
                                    <center>
                                        No Records Found
                                    </center>
                                </EmptyDataTemplate>
                            </asp:GridView>
                                </div>
                        </div>
                    </div>
                    <div class="row">
                        &nbsp;
                    </div>
                    <div class="row">
                        <center>
                         <asp:Button ID="btnEmployeeNurturingProcessStageTasks" runat="server" Text="Go to Assign Task Priority" OnClick="btnEmployeeNurturingProcessStageTasks_Click" />  
                        </center>
                   </div>
                </div>
            </div>
        </div>
    </div>
      <!-- Row End -->
</asp:Content>

