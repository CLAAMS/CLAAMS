<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="sos_create.aspx.cs" Inherits="CD6.sos_create" %>
<%@ MasterType VirtualPath="~/master.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/sos.css" rel="stylesheet" />
    <link href="css/secondary-nav.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="content" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav class="navbar navbar-default navbar-secondary" role="navigation">
        <div class="container-fluid">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#subnavbar" aria-expanded="false" aria-controls="subnavbar">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
            </div>
            <div id="subnavbar" class="navbar-collapse collapse">
                <ul class="nav navbar-nav">
                    <li><a href="sos_create.aspx">Create Sign Sheet</a></li>
                    <li><a href="sos_search.aspx">Search Sign Sheets</a></li>
                </ul>
            </div><!--/.nav-collapse -->
        </div><!--/.container-fluid -->
    </nav>
    <div class="modal fade" id="confirmationModal" tabindex="-1" role="dialog" aria-labelledby="confirmationModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content" style="text-align:center;">
                <div class="modal-header">
                    <!--<button type="button" class="close" data-dismiss="modal" aria-hidden="true"/>-->
                    <h4 class="modal-title" id="myModalLabel"><asp:Label ID="lblModal_header" runat="server" /></h4>
                </div>
                <div class="modal-body">
                    <asp:label ID="lblModal_Body" runat="server" /><br />
                    <asp:LinkButton ID="linkPrintSos" runat="server" OnClick="link_ClickPrintSos" OnClientClick="aspnetForm.target='blank';" Text="Print Sign Sheet" /><br />
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <div class="row main_content">
        <div class="col-md-10 col-md-offset-1">
            <form role="form">
                <div class="row" id="sos_form" runat="server">
                    <div class="row header_row">
                        <div class="col-md-12" id="header" runat="server">
                            <h1>Create Sign Sheet</h1>
                            <div class="instructions">
                                <asp:Label ID="lblCreateSOSDirections" runat="server" Visible="false" CssClass="instructions"/>
                            </div>
                            <div class="instructions">
                                <asp:Label ID="lblCreateError" runat="server" Visible="true" CssClass="instructions" ForeColor="Red"/>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-6">
                                    <asp:Label ID="lblRecipient" text="Recipient: *" runat="server" CssClass="label" />
                                </div>
                                <div class="col-md-6" style="text-align: right;">
                                    <asp:LinkButton ID="linkRecipientSearch" runat="server" Text="Search for Recipients" OnClick="linkRecipientSearch_Click"/>
                                </div>
                            </div>
                            <asp:DropDownList ID="ddlRecipient" runat="server" CssClass="dropdown" TabIndex="1"/><br />
                            <asp:Label ID="lblAssigner" Text="From: *" runat="server" CssClass="label" />
                            <asp:DropDownList ID="ddlAssigner" runat="server" CssClass="dropdown" TabIndex="2"/><br />
                            <asp:Label ID="lblTerm" Text="Term: *" runat="server" CssClass="label" />
                            <asp:DropDownList ID="ddlTerm" runat="server" CssClass="dropdown" OnSelectedIndexChanged="ddlTerm_SelectedIndexChanged" AutoPostBack="true" TabIndex="3">
                                <asp:ListItem Value="1" Text="Permanent" />
                                <asp:ListItem Value="0" Text="Non-Permanent" />
                            </asp:DropDownList><br />
                        </div>
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:Label ID="lblAssets" Text="Assets: *" runat="server" CssClass="label" />
                                    <asp:ListBox ID="lbAssets" SelectionMode="Single" CssClass="list-group" runat="server" style="width:100%;" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-6 button_row" style="text-align:left;">
                                    <asp:Button ID="btnAddAsset" Text="Add Asset" runat="server" CssClass="btn btn-default" OnClick="btnAddAsset_Click" TabIndex="4"/>
                                </div>
                                <div class="col-xs-6 button_row" style="text-align:right;">
                                    <asp:Button ID="btnRemoveAsset" Text="Remove Asset" runat="server" CssClass="btn btn-default" OnClick="btnRemoveAsset_Click" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-6 calendar">
                                    <asp:label ID="lblIssueDate" Text="Issue Date:" runat="server" CssClass="label" />
                                    <asp:Calendar ID="calIssueDate" runat="server" />
                                </div>
                                <div class="col-xs-6 calendar" style="text-align:right" id="calDue" runat="server" visible="false">
                                    <asp:Label ID="lblDueDate" Text="Due Date: *" runat="server" CssClass="label" /><br/>
                                    <asp:Calendar ID="calDueDate" runat="server" style="float:right" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2 col-md-offset-5 button_row" style="text-align:center;">
                            <asp:button ID="btnSubmit" Text="Submit" runat="server" CssClass="btn btn-default" OnClick="btnSubmit_Click" TabIndex="5"/>
                        </div>
                    </div>
                </div>
            </form>
        </div>
    </div>
</asp:Content>
