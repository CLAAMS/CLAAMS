<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="asset.aspx.cs" Inherits="CD6.asset" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/asset.css" rel="stylesheet" />
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
                    <li><asp:LinkButton OnClick="btnNewSearch_Click" Text="Search" runat="server" /></li>
                    <li><asp:LinkButton OnClick="btnCreate_Click" Text="Create" runat="server" /></li>
                </ul>
            </div><!--/.nav-collapse -->
        </div><!--/.container-fluid -->
    </nav>

    <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <form role="form">
                <div class="row" id="asset_form" runat="server" visible="true">
                    <div class="row"><div class="col-md-12" id="searchHeader" runat="server" visible="true"><p><h1>Search Assets</h1></p></div></div>
                    <div class="row"><div class="col-md-12" id="createHeader" runat="server" visible="true"><p><h1>Create Asset</h1></p></div></div>
                    <div class="col-md-6">
                        <div class="row">
                            <div class="col-xs-9">
                                <asp:Label ID="lblTemplate" Text="Template:" runat="server" CssClass="label" />
                                <asp:DropDownList ID="ddlAssetTemplate" runat="server" CssClass="dropdown">
                                    <asp:ListItem Value="Template1" Text="Dell Laptop" />
                                    <asp:ListItem Value="Template2" Text="15in Macbook Pro" />
                                    <asp:ListItem Value="Template3" Text="Dell Desktop" />
                                    <asp:ListItem Value="Template4" Text="24in Dell Monitor" />
                                </asp:DropDownList>
                            </div>
                            <div class="col-xs-3" style="padding-top:21px;">
                                <a href="#" id="btnAddTemplate" runat="server">Add Template</a> 
                            </div>
                        </div>
                        <asp:Label ID="lblCLAID" Text="CLA ID:" runat="server" CssClass="label" />
                        <asp:TextBox ID="txtCLAID" runat="server" CssClass="form-control" />
                        <asp:Label ID="lblMake" Text="Make:" runat="server" CssClass="label" />
                        <asp:TextBox ID="txtMake" runat="server" CssClass="form-control" />
                        <asp:Label ID="lblModel" Text="Model:" runat="server" CssClass="label" />
                        <asp:TextBox ID="txtModel" runat="server" CssClass="form-control" />
                        <asp:Label ID="lblSerial" Text="Serial Number:" runat="server" CssClass="label" />
                        <asp:TextBox ID="txtSerial" runat="server" CssClass="form-control" />
                    </div>
                    <div class="col-md-6">
                        <asp:Label ID="lblStatus" Text="Status:" runat="server" CssClass="label" />
                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="dropdown">
                            <asp:ListItem Value="Active" Text="Active" />
                            <asp:ListItem Value="Inactive" Text="Inactive" />
                        </asp:DropDownList><br />
                        <asp:Label ID="lblDescription" Text="Description:" runat="server" CssClass="label" />
                        <asp:TextBox ID="txtDescription" TextMode="MultiLine" Columns="50" Rows="3" runat="server" CssClass="form-control" />
                        <asp:Label ID="lblNotes" Text="Notes:" runat="server" CssClass="label" />
                        <asp:TextBox ID="txtNotes" TextMode="MultiLine" Columns="50" Rows="5" runat="server" CssClass="form-control" />
                    </div>
                    <div class="row"><div id="submit_button" class="col-md-12 button_row" style="text-align:center;" runat="server" visible="true"><asp:Button ID="btnSubmit" Text="Submit" runat="server" CssClass="btn btn-default" OnClick="btnSubmit_Click"/></div></div>
                    <div class="row"><div id="search_button" class="col-md-12 button_row" style="text-align:center;" runat="server" visible="true"><asp:Button ID="btnSearch" Text="Search" runat="server" CssClass="btn btn-default" OnClick="btnSearch_Click"/></div></div>
                </div>
                <div class="row" id="search_results" runat="server" visible="true">
                    <div class="row"><div class="col-xs-12"><p><h1>Asset Search Results</h1></p></div></div>
                    <div class="col-md-12">
                        <asp:GridView ID="gvSearchResults" runat="server" OnRowCommand="gvSearchResult_click" AutoGenerateColumns="false" CssClass="table">
                            <Columns>
                                <asp:BoundField DataField="assetID" HeaderText="ID" />
                                <asp:BoundField DataField="CLATag" HeaderText="CLA Tag" />
                                <asp:BoundField DataField="Make" HeaderText="Make" />
                                <asp:BoundField DataField="Model" HeaderText="Model" />
                                <asp:BoundField DataField="SerialNumber" HeaderText="Serial" />
                                <asp:BoundField DataField="Status" HeaderText="Status" />
                                <asp:ButtonField ButtonType="Button" Text="Delete" CommandName="deleteRecord" ControlStyle-CssClass="btn btn-danger" /> 
                                <asp:ButtonField ButtonType="Button" Text="View/Edit" CommandName="modifyRecord" ControlStyle-CssClass="btn btn-default" />
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div class="row"><div class="col-md-12 button_row" style="text-align:center;" ><asp:Button ID="btnNewSearch" Text="New Search" runat="server" CssClass="btn btn-default" OnClick="btnNewSearch_Click"/></div></div>
                </div>
            </form>
        </div> 
    </div>
</asp:Content>