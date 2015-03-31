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
    <div class="row main_content">
        <div class="col-md-8 col-md-offset-2">
            <form role="form">
                <div class="row" id="sos_form" runat="server">
                    <div class="row header_row">
                        <div class="col-md-12" id="header" runat="server">
                            <h1>Create Sign Sheet</h1>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <asp:Label ID="lblRecipient" text="Recipient: *" runat="server" CssClass="label" />
                            <asp:DropDownList ID="ddlRecipient" runat="server" CssClass="dropdown" /><br />
                            <asp:Label ID="lblAssigner" Text="From: *" runat="server" CssClass="label" />
                            <asp:DropDownList ID="ddlAssigner" runat="server" CssClass="dropdown" /><br />
                            <asp:Label ID="lblTerm" Text="Term: *" runat="server" CssClass="label" />
                            <asp:DropDownList ID="ddlTerm" runat="server" CssClass="dropdown" OnSelectedIndexChanged="ddlTerm_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Value="1" Text="Permanent" />
                                <asp:ListItem Value="2" Text="Non-Permanent" />
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
                                    <asp:Button ID="btnAddAsset" Text="Add Asset" runat="server" CssClass="btn btn-default" OnClick="btnAddAsset_Click" />
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
                            <asp:button ID="btnSubmit" Text="Submit" runat="server" CssClass="btn btn-default" OnClick="btnSubmit_Click" />
                        </div>
                    </div>
                </div>
            </form>
        </div>
    </div>
</asp:Content>
