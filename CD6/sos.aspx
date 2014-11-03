<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="sos.aspx.cs" Inherits="CD6.sos" %>
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
                    <li><a href="#">Search</a></li>
                    <li><a href="#">Create</a></li>
                    <li><a href="#">Track</a></li>
                </ul>
            </div><!--/.nav-collapse -->
        </div><!--/.container-fluid -->
    </nav>

    <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <div id="search" runat="server" visible="true">
                <div id="results" runat="server" visible="false">
                    <div class="row">
                        <div class="col-md-12">
                            <asp:GridView ID="gvSearchResults" runat="server" CssClass="table"></asp:GridView>
                        </div>
                    </div>
                    <div id="row">
                        <div class="col-md-2 col-md-offset-5">
                            <asp:Button ID="btnNewSearch" runat="server" Text="New Search" CssClass="btn btn-default"/>
                        </div>
                    </div>
                </div>
                <div id="modify" runat="server" visible="true">
                    <form role="form">
                        <div class="row">
                            <div class="row"><div class="col-md-12" style="margin-bottom:30px;"><p><h1>Create New Sign Sheet</h1></p></div></div>
                            <div class="col-md-6">
                                <div class="row">
                                    <div class="col-xs-2">
                                        <asp:Label ID="lblRecipient" Text="Recipient:" runat="server" CssClass="label" />
                                    </div>
                                    <div class="col-xs-10">
                                        <asp:DropDownList ID="ddlRecipient" runat="server" CssClass="dropdown">
                                            <asp:ListItem Text="Bob Barker" />
                                            <asp:ListItem Text="Henry Hollins" />
                                            <asp:ListItem Text="Mark Mansfield" />
                                        </asp:DropDownList><br />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xs-2">
                                        <asp:Label ID="lblAssigner" Text="From:" runat="server" CssClass="label" />
                                    </div>
                                    <div class="col-xs-10">
                                        <asp:DropDownList ID="ddlAssigner" runat="server" CssClass="dropdown">
                                            <asp:ListItem Text="Joe Schmoe" />
                                            <asp:ListItem Text="Hank Smith" />
                                            <asp:ListItem Text="Jim Jones" />
                                        </asp:DropDownList><br />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xs-2">
                                        <asp:Label ID="lblTerm" Text="Term:" runat="server" CssClass="label" />
                                    </div>
                                    <div class="col-xs-10">
                                        <asp:DropDownList ID="ddlTerm" runat="server" CssClass="dropdown">
                                            <asp:ListItem Value="1" Text="Permanent" />
                                            <asp:ListItem Value="0" Text="Non-Permanent" />
                                        </asp:DropDownList><br />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <asp:Label ID="lblAssets" Text="Assets:" runat="server" CssClass="label" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xs-12">
                                        <asp:ListBox ID="lstbxAssets" runat="server" CssClass="list-group" style="width:100%;" />
                                    </div>
                                </div>
                                <asp:Button ID="btnAddAsset" runat="server" text="Add Asset" CssClass="btn btn-default" />
                            </div>
                            <div class="col-md-6">
                                <div id="term" runat="server" visible="true">
                                    <asp:Label ID="lblDueDate" Text="Due Date:" runat="server" CssClass="label" />
                                    <asp:Calendar ID="calDueDate" runat="server" />
                                </div>
                                <asp:Label ID="lblDate" Text="Issue Date:" runat="server" CssClass="label" />
                                <asp:Calendar ID="calIssueDate" runat="server" SelectedDate="10/28/2014"/>
                            </div>
                        </div>
                        <div class="row button_row">
                            <div class="col-md-12" style="text-align:center;">
                                <asp:Button ID="btnSubmit" Text="Submit" runat="server" CssClass="btn btn-default" />
                            </div>
                        </div>
                    </form>
                </div>
            </div>
            <div id="searching" runat="server" visible="false">
                <div class="row button_row">
                    <div class="col-md-12" style="text-align:center;">
                       <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-default" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
