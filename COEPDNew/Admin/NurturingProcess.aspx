﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="NurturingProcess.aspx.cs" Inherits="Admin_NurturingProcess" %>

<%@ Register Src="~/Controls/FormMessage.ascx" TagName="FormMessage" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/ErrorMessage.ascx" TagName="ErrorMessage" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <style type="text/css">
        .ui-widget-content .ui-icon {
    /*background-image: url("../App_Themes/admin//images/ui-icons_222222_256x240.png")*/ 
    /*background-image:url("../App_Themes/admin/img/ui-icons_444444_256x240.png")*/
     background-image:url("../App_Themes/admin/img/ui-icons_3d80b3_256x240.png")      
            !important;}
    .ui-widget-header .ui-icon {
    /*background-image: url("../App_Themes/admin/img/ui-icons_444444_256x240.png")*/ 
    background-image:url("../App_Themes/admin/img/ui-icons_3d80b3_256x240.png")  
        !important;}
    </style>
    <script type="text/javascript" src="../App_Themes/admin/js/jquery.js"></script>
    <script type="text/javascript" src="../App_Themes/admin/js/jquery-ui-v1.10.3.js"></script>
    <script type="text/javascript">
        $(document).ready(function ($) {
            $("[id*=txtTargetDate]").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy',
                minDate: "0",
            });
        });
    </script>
    <script type="text/javascript">

         function alertmeDuplicate() {
             Swal.fire(
                 ' This SlotStatus is Already Exist',
                 '',
                 'warning'
             )
         }
     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpLeft" Runat="Server">
    <uc1:FormMessage ID="FormMessage" runat="server" Visible="false" />
    <uc2:ErrorMessage ID="ErrorMessage" runat="server" Visible="false" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- Row Start -->
    <div class="row">
        <div class="col-sm-8 col-xs-12">
            <div class="widget">
                <div class="widget-header">
                    <div class="title">
                        <asp:Label ID="lblTitle" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="widget-body">
                    <div class="form-horizontal no-margin">
                        <div class="form-group" id="divParticipant" runat="server">
                            <label class="col-sm-2 control-label">
                                Participant <sup class="sup">*</sup>
                            </label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtSearch" runat="server" required="required" AutoPostBack="true" OnTextChanged="txtSearch_TextChanged"></asp:TextBox>
                            </div>
                           <%-- <div class="col-sm-1">
                                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CausesValidation="false" UseSubmitBehavior="false" />
                            </div>--%>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">
                                Select Participant<sup class="sup">*</sup>
                            </label>
                            <div class="col-sm-10">
                                <asp:DropDownList ID="ddlParticipant" runat="server" required="" OnSelectedIndexChanged="ddlParticipant_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                        </div>
                         <div class="form-group">
                            <label class="col-sm-2 control-label">
                                Select Stage<sup class="sup">*</sup>
                                <asp:HiddenField ID="hdnNurturingProcessSlotsId" Value="0" runat="server" />
                            </label>
                            <div class="col-sm-10">
                                <asp:DropDownList ID="ddlNurturingProcessStage" runat="server" required="" AutoPostBack="true" OnSelectedIndexChanged="ddlNurturingProcessStage_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">
                               Select Stage Task<sup class="sup">*</sup>
                            </label>
                            <div class="col-sm-10">
                                <asp:DropDownList ID="ddlNurturingProcessStageTask" runat="server" required="" AutoPostBack="true" OnSelectedIndexChanged="ddlNurturingProcessStageTask_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group" id="divAttachments" runat="server">
                            <label class="col-sm-2 control-label">
                                Attachments
                            </label>
                            <div class="col-sm-9">
                                <h5>
                                    <asp:HyperLink ID="hplSentFile" runat="server" CssClass="btn btn-success btn-sm" Target="_blank">View Question Paper</asp:HyperLink>
                                    <asp:HyperLink ID="hplReplyFile" runat="server" CssClass="btn btn-primary btn-sm" Target="_blank">View Answer Paper</asp:HyperLink>
                                </h5>
                            </div>
                        </div>
                        <div class="form-group" id="divUpload" runat="server">
                            <label class="col-sm-2 control-label">
                                Upload File
                            </label>
                            <div class="col-sm-4">
                                <asp:FileUpload ID="flUpload" runat="server" />
                                <%--<asp:RequiredFieldValidator runat="server" ID="ReqFileUpload" ControlToValidate="flUpload" ErrorMessage="Upload Question Paper" ForeColor="Red" Font-Names="Verdana" Font-Size="10"></asp:RequiredFieldValidator>--%>
                            </div>
                            <div class="col-sm-6">
                                <small>( Max 10 MB )</small>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">
                               Target Date<sup class="sup">*</sup>
                            </label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtTargetDate" runat="server" required="" autoComplete="off"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">
                                 <asp:Label ID="lblSlot" runat="server" Text="Slot Date-Time:"></asp:Label>
                            </label>
                           
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtSlot" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">
                                Mentor Inputs<sup class="sup">*</sup>
                            </label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtNotes" runat="server" required="" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group" id="divMarks" runat="server">
                            <label class="col-sm-2 control-label">
                                Score 
                            </label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtMarks" runat="server"  Min="1" Max="100" Type="Number"></asp:TextBox>
                            </div>
                        </div>
                         <div class="form-group" id="divReshdule" runat="server">
                            <label class="col-sm-2 control-label">
                                Reschedule Status:
                            </label>
                            <div class="col-sm-10">
                               <asp:DropDownList ID="ddlReshedule"  runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlReshedule_SelectedIndexChanged" >
                                   <asp:ListItem Text="-- select Reschedule Status --" Value="0"></asp:ListItem>
                                   
                                    <asp:ListItem Text="Conducted- Redo-Student Should Improve" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="Approved" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="Reschedule - student not available/ not picked up the call" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="Reschedule - portal not working or others" Value="7"></asp:ListItem>
                                    <asp:ListItem Text="Reschedule - Slot Canceled by Student" Value="8"></asp:ListItem>
                                    <asp:ListItem Text="Conduct-Redo-Doc Not Available" Value="11"></asp:ListItem>
                                      </asp:DropDownList>
                               
                            </div>
                        </div>
                        <td>  
                        <asp:Label ID="lbmsg" runat="server"></asp:Label>  
                            </td>

                        <div class="form-group">
                            <div class="col-sm-offset-2 col-sm-10">
                                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Save" />
                                <%--<asp:Button ID="btnReShedule" runat="server" OnClick="btnReShedule_Click" Text="reschedule" />--%>
                                <asp:Button ID="btnApprove" runat="server" SkinID="btnBack" OnClick="btnApprove_Click" Text="Approve" />
                                <asp:Button ID="btnCancel" runat="server" SkinID="delete" CssClass="btn btn-warning btn-md" Text="Back to list" UseSubmitBehavior="false" CausesValidation="false"
                                    OnClick="btnCancel_Click" />
                                <asp:Button ID="btnBackToSlots" runat="server" OnClick="btnBackToSlots_Click" Text="Back To Slots" UseSubmitBehavior="false" CausesValidation="false" />

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-sm-4 col-xs-12">
            <div class="widget">
                <div class="widget-header">
                    <div class="title">
                        Previous Nurturing Team Inputs
                    </div>
                </div>
                <div class="widget-body" style="height: 300px; overflow-y: scroll">
                    <div class="viewport">
                        <div class="overview">
                            <ul class="chats">
                                <asp:Repeater ID="rp" runat="server" OnItemDataBound="rp_OnItemDataBound">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hdnRoleId" runat="server" Value='<%# Eval("RoleId")%>' />
                                        <asp:Panel ID="pnlIn" runat="server" Visible="false">
                                            <li class="in">
                                                <img class="avatar" alt="" src="../img/profile.png" />
                                                <div class="message">
                                                    <span class="arrow"></span><a href="#" class="name">
                                                        <%# Eval("Employee")%>
                                                    </a><span class="date-time">at
                                                        <%# Eval("CreatedOn", "{0:MMM dd, yyyy hh:mm tt}")%>
                                                    </span><span class="body">
                                                        <%# Eval("Chat") %></span>
                                                </div>
                                            </li>
                                        </asp:Panel>
                                        <asp:Panel ID="PnlOut" runat="server" Visible="false">
                                            <li class="out">
                                                <img class="avatar" alt="" src="../img/profile.png">
                                                <div class="message">
                                                    <span class="arrow"></span><a href="#" class="name">
                                                        <%# Eval("Participant")%>
                                                    </a><span class="date-time">at
                                                        <%# Eval("CreatedOn", "{0:MMM dd, yyyy hh:mm tt}")%>
                                                    </span><span class="body">
                                                        <%# Eval("Chat") %>
                                                    </span>
                                                </div>
                                            </li>
                                        </asp:Panel>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
            <div class="widget" id="divMenterinputs" runat="server">
                <div class="form-horizontal no-margin">
                    <div class="widget-header">
                        <div class="title">
                            Enter Mentor Inputs
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-12">
                            <asp:TextBox ID="txtChat" runat="server" TextMode="MultiLine" Height="120px"
                                placeholder="Enter inputs in detail.">
                            </asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-offset-3 col-sm-9">
                            <asp:Button ID="btnSend" runat="server" Text="Send Inputs" UseSubmitBehavior="false"
                                OnClick="btnSend_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

                <div class="col-sm-4 col-xs-12 col-sm-offset-8 col-xs-offset-12">
            <div class="widget">
                <div class="widget-header">
                    <div class="title">
                        Previous Nurturing Team Inputs
                    </div>
                </div>
                <div class="widget-body" style="height: 300px; overflow-y: scroll">
                    <div class="viewport">
                        <div class="overview">
                            <ul class="chats">
                                <asp:Repeater ID="rpNurturingTeamInputs" runat="server" OnItemDataBound="rpNurturingTeamInputs_ItemDataBound">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hdnNurturingTeamInputsRoleId" runat="server" Value='<%# Eval("RoleId")%>' />
                                        <asp:Panel ID="pnlIn" runat="server" Visible="false">
                                            <li class="in">
                                                <img class="avatar" alt="" src="../img/profile.png" />
                                                <span class="name">Task Name:
                                                        <%# Eval("NurturingProcessStageTaskName") %>
                                                </span>
                                                <div class="message">
                                                    <span class="arrow"></span><a href="#" class="name">
                                                        <%# Eval("Participant")%>
                                                    </a><span class="date-time">at
                                                        <%# Eval("CreatedOn", "{0:MMM dd, yyyy hh:mm tt}")%>
                                                    </span><span class="body">
                                                        <%# Eval("Chat") %></span>

                                                </div>
                                            </li>
                                        </asp:Panel>
                                        <asp:Panel ID="PnlOut" runat="server" Visible="false">
                                            <li class="out">
                                                <img class="avatar" alt="" src="../img/profile.png">
                                                <span class="name">Task Name:
                                                        <%# Eval("NurturingProcessStageTaskName") %>
                                                </span>
                                                <div class="message">
                                                    <span class="arrow"></span><a href="#" class="name">
                                                        <%# Eval("Employee")%>
                                                    </a><span class="date-time">at
                                                        <%# Eval("CreatedOn", "{0:MMM dd, yyyy hh:mm tt}")%>
                                                    </span><span class="body">
                                                        <%# Eval("Chat") %>
                                                    </span>

                                                </div>
                                            </li>
                                        </asp:Panel>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                    </div>
                </div>

            </div>
        </div>

    </div>
    <!-- Row End -->
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {

            $("[id*=btnSend]").click(function () {


                var mesg = $("[id*=txtChat]").val();

                if (mesg.length == 0) {
                    alert('Please Enter Inputs in detail.');
                    $("[id*=txtChat]").focus();
                    //return false;
                }


            });
        });
    </script>

    <script type="text/javascript">
        $(function () {
            $("input[id$=flUpload]").bind('change', function () {
                var size = parseFloat($("input[id$=flUpload]")[0].files[0].size / 1024).toFixed(2);

                if (size > 10240) {
                    alert('File size should be less than 10 MB.');
                    $("input[id$=flUpload]").val("");
                    return false;
                }
                else {
                    return true;
                }

            });
        });
    </script>
</asp:Content>

