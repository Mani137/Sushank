﻿<%@ Page Title="" Language="C#" MasterPageFile="Participant.master" AutoEventWireup="true"
    CodeFile="RunExam.aspx.cs" Inherits="RunExam" %>

<%@ Register Src="~/Controls/FormMessage.ascx" TagName="FormMessage" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/ErrorMessage.ascx" TagName="ErrorMessage" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <uc1:FormMessage ID="FormMessage" runat="server" Visible="false" />
    <uc2:ErrorMessage ID="ErrorMessage" runat="server" Visible="false" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Row Start -->
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-lg-12 col-md-12">
                    <div class="widget">
                        <div class="widget-header">
                            <div class="title">
                                <asp:Label ID="lblTitle" runat="server"></asp:Label>-&nbsp;
                          Category Name:
                        <asp:Label ID="lblcategory" runat="server" Font-Bold="true"></asp:Label>
                                &nbsp;-&nbsp;
                          Topic Name:
                        <asp:Label ID="lblTopic" runat="server" Font-Bold="true"></asp:Label>
                            </div>
                        </div>
                        <div class="widget-body">
                            <div class="form-horizontal no-margin">
                                <div class="form-group">
                                    <label class="col-sm-2 text-right">
                                        Question
                                    </label>
                                    <div class="col-sm-10 text-info">
                                        <asp:Label ID="lblQuestion" runat="server" Font-Bold="true"></asp:Label>
                                        <asp:Label ID="lblTotalQuestions" runat="server" Font-Bold="true" Visible="false"></asp:Label>
                                        <asp:Label ID="lblCorrectAnswers" runat="server" Font-Bold="true" Visible="false"></asp:Label>
                                        <asp:Label ID="lblMarksPersontage" runat="server" Font-Bold="true" Visible="false"></asp:Label>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-2 text-right">
                                        &nbsp;
                                    </label>
                                    <div class="col-sm-10 text-info">
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-2 text-right">
                                        Answers
                                    </label>
                                    <div class="col-sm-10">
                                        <asp:RadioButtonList ID="rdAnswer" runat="server">
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-offset-2 col-sm-10">
                                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                                            <ProgressTemplate>
                                                <div class="div1" style="margin-left: 10px">
                                                    <asp:Image ID="Image1" ImageUrl="/img/CoepdLoad.gif" AlternateText="Processing" runat="server" />
                                                    <%--<asp:Label ID="Label1" runat="server" Text="The Inputs are Loading so Please Wait"></asp:Label>--%>
                                                </div>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-offset-2 col-sm-10">
                                        <asp:Button ID="BtnPrev" runat="server" OnClick="BtnPrev_Click" Text="Previous" Width="100px" UseSubmitBehavior="false" OnClientClick="this.disabled='true';this.value='Please Wait...';" />&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="BtnNext" runat="server" OnClick="BtnNext_Click" Text="Next" Width="100px" UseSubmitBehavior="false" OnClientClick="this.disabled='true';this.value='Please Wait...';" />&nbsp;
                                <asp:Button ID="BtnFinish" runat="server" OnClick="BtnFinish_Click" OnClientClick="this.disabled='true';this.value='Please Wait...';" Text="Finish"
                                    Width="100px" Visible="false" UseSubmitBehavior="false" />&nbsp;
                                    </div>
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
