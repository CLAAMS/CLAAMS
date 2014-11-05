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
                    <li><asp:LinkButton runat="server" Text="Search" OnClick="btnNewSearch_Click"/></li>
                    <li><asp:LinkButton runat="server" Text="Create" OnClick="Page_Load"/></li>
                    <li><asp:LinkButton runat="server" Text="Track" OnClick="btnTrack_Click"/></li>
                </ul>
            </div><!--/.nav-collapse -->
        </div><!--/.container-fluid -->
    </nav>

    <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <form role="form">
                <div class="row" id="sos_form" runat="server" visible="false">
                    <div class="row header_row"><div class="col-md-12" id="searchHeader" runat="server" visible="true"><h1>Search Sign Sheets</h1></div></div>
                    <div class="row header_row"><div class="col-md-12" id="createHeader" runat="server" visible="true"><h1>Create Sign Sheet</h1></div></div>
                    <div class="col-md-6">
                        <asp:Label ID="lblRecipient" Text="Recipient:" runat="server" CssClass="label" />
                        <asp:DropDownList ID="ddlRecipient" runat="server" CssClass="dropdown">
                            <asp:ListItem Text="Bob Barker" />
                            <asp:ListItem Text="Henry Hollins" />
                            <asp:ListItem Text="Mark Mansfield" />
                        </asp:DropDownList><br />
                        <asp:Label ID="lblAssigner" Text="From:" runat="server" CssClass="label" />
                        <asp:DropDownList ID="ddlAssigner" runat="server" CssClass="dropdown">
                            <asp:ListItem Text="Joe Schmoe" />
                            <asp:ListItem Text="Hank Smith" />
                            <asp:ListItem Text="Jim Jones" />
                        </asp:DropDownList><br />
                        <asp:Label ID="lblTerm" Text="Term:" runat="server" CssClass="label" />
                        <asp:DropDownList ID="ddlTerm" runat="server" CssClass="dropdown" OnSelectedIndexChanged="ddlTerm_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Value="1" Text="Permanent" />
                            <asp:ListItem Value="0" Text="Non-Permanent" />
                        </asp:DropDownList><br />
                    </div>
                    <div class="col-md-6">
                        <asp:Label ID="lblAssets" Text="Assets:" runat="server" CssClass="label" />
                        <asp:ListBox ID="lstbxAssets" runat="server" CssClass="list-group" style="width:100%;" />
                        <div class="row"><div class="col-xs-12" style="text-align:right;"><asp:Button ID="btnAddAsset" runat="server" text="Add Asset" CssClass="btn btn-default" /></div></div>
                        <div class="row">
                            <div class="col-xs-6 calendar">
                                <asp:Label ID="lblDate" Text="Issue Date:" runat="server" CssClass="label" />
                                <asp:Calendar ID="calIssueDate" runat="server" SelectedDate="10/28/2014"/>
                            </div>
                            <div class="col-xs-6 calendar" id="dueCal" runat="server" visible="true">
                                <asp:Label ID="lblDueDate" Text="Due Date:" runat="server" CssClass="label" />
                                <asp:Calendar ID="calDueDate" runat="server"/>
                            </div>
                        </div>
                    </div>
                    <div class="row"><div class="col-md-12 button_row" id="button_submit" style="text-align:center;" runat="server" visible="true"><asp:Button ID="btnSubmit" Text="Submit" runat="server" CssClass="btn btn-default" /></div></div>
                    <div class="row"><div class="col-md-12 button_row" id="button_search" style="text-align:center;" runat="server" visible="true"><asp:Button ID="btnSearch" Text="Search" runat="server" CssClass="btn btn-default" OnClick="btnSearch_Click" /></div></div>
                </div>
                <div class="row" id="search_results" runat="server" visible="true">
                    <div class="row header_row"><div class="col-md-12" id="trackingHeader" runat="server" visible="true"><h1>Sign Sheet Tracking</h1></div></div>
                    <div class="row header_row"><div class="col-md-12" id="searchResultsHeader" runat="server" visible="true"><h1>Sign Sheet Search Results</h1></div></div>
                    <div class="col-md-12">
                        <asp:GridView ID="gvSearchResults" runat="server" CssClass="table" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField DataField="sosID" HeaderText="SoS ID" />
                                <asp:BoundField DataField="assetID" HeaderText="Assets" />
                                <asp:BoundField DataField="claID" HeaderText="Assigner" />
                                <asp:BoundField DataField="arID" HeaderText="Recipient" />
                                <asp:BoundField DataField="DateCreated" HeaderText="Date Created" />
                                <asp:BoundField DataField="DateDue" HeaderText="Date Due" />
                                <asp:BoundField DataField="Status" HeaderText="Status" />
                                <asp:ButtonField ButtonType="Button" Text="Delete" ControlStyle-CssClass="btn-danger btn" />
                                <asp:ButtonField ButtonType="Button" Text="View/Edit" ControlStyle-CssClass="btn-default btn" />
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div class="row" id="searchButtons" runat="server" visible="true">
                        <div class="row"><div class="col-md-12 button_row" style="text-align:center;"><asp:Button ID="btnExport" Text="Export Results" runat="server" CssClass="btn btn-default" /></div></div>
                        <div class="row"><div class="col-md-12 button_row" style="text-align:center;"><asp:Button ID="btnNewSearch" Text="New Search" runat="server" OnClick="btnNewSearch_Click" CssClass="btn btn-default" /></div></div>
                    </div>
                </div> 
            </form>
        </div>
    </div>
</asp:Content>
