<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="sos_search.aspx.cs" Inherits="CD6.sos_search" %>
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
                    <li><asp:LinkButton runat="server" Text="Search"/></li>
                    <li><asp:LinkButton runat="server" Text="Create"/></li>
                    <li><asp:LinkButton runat="server" Text="Track"/></li>
                </ul>
            </div><!--/.nav-collapse -->
        </div><!--/.container-fluid -->
    </nav>

    <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <form role="form">
                <div class="row" id="sos_form" runat="server">
                    <div class="row header_row">
                        <div class="col-md-12" id="header" runat="server">
                            <h1>Search Sign Sheets</h1>
                        </div>
                    </div>
                    <asp:Label ID="lblRecipient" Text="Recipient:" runat="server" CssClass="label" />
                    <asp:DropDownList ID="ddlRecipient" runat="server" CssClass="dropdown" /><br/>
                    <asp:Label ID="lblAssigner" text="From:" runat="server" CssClass="label" />
                    <asp:DropDownList ID="ddlAssigner" runat="server" CssClass="dropdown" /><br />
                    <asp:Label ID="lblTerm" text="Term:" runat="server" CssClass="label" />
                    <asp:DropDownList ID="ddlTerm" runat="server" CssClass="dropdown">
                        <asp:ListItem Value="1" Text="Permanent" />
                        <asp:ListItem Value="2" Text="Non-Permanent" />
                    </asp:DropDownList><br />
                    <div class="col-md-6">
                        <div class="row">
                            <div class="col-xs-3 calendar">
                                <br />
                                <asp:Label ID="lblDate" Text="Issue Date:" runat="server" CssClass="label" />
                                <asp:Calendar ID="calIssueDate" runat="server" />
                            </div>
                            <div class="col-xs-3 col-xs-offset-3 calendar" id="dueCal" runat="server" visible="false">
                                <br />
                                <asp:Label ID="lblDueDate" Text="Due Date:" runat="server" CssClass="label" />
                                <asp:Calendar ID="calDueDate" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12 button_row" id="button_submit" style="text-align:center;" runat="server">
                            <asp:Button ID="btnSubmit" Text="Submit" runat="server" CssClass="btn btn-default" OnClick="btnSubmit_Click" />
                        </div>
                    </div>
                </div>
            </form>
        </div>
    </div>
</asp:Content>
