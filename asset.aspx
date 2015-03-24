<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="asset.aspx.cs" Inherits="CD6.asset" %>
<%@ MasterType VirtualPath="~/master.Master" %>
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
                    <div class="row header_row"><div class="col-md-12" id="searchHeader" runat="server" visible="true"><p><h1>Search Assets</h1></p></div></div>
                    <div class="row header_row"><div class="col-md-12" id="createHeader" runat="server" visible="true"><p><h1>Create Asset</h1></p></div></div>
                    <div class="row header_row"><div class="col-md-12" id="modifyHeader" runat="server" visible="true"><p><h1>Modify Asset</h1></p></div></div>
                    <div class="col-md-6">
                        <div class="row" id="templateRow" runat="server">
                            <div class="col-xs-9">
                                <asp:Label ID="lblTemplate" Text="Template:" runat="server" CssClass="label" />
                                <asp:DropDownList ID="ddlAssetTemplate" runat="server" AutoPostBack="true" CssClass="dropdown" OnSelectedIndexChanged="ddlAssetTemplate_SelectedIndexChanged"/>
                            </div>
                            <div class="col-xs-3">
                                <a onclick="manageTemplates()">Manage Templates</a> 
                            </div>
                        </div>
                        <div style="height:34px;" runat="server" id="filler">&nbsp</div>
                        <asp:Label ID="lblCLAID" Text="CLA ID:" runat="server" CssClass="label" />
                        <asp:TextBox ID="txtCLAID" runat="server" CssClass="form-control" />
                        <asp:Label ID="lblMake" Text="Make:" runat="server" CssClass="label" />
                        <asp:TextBox ID="txtMake" runat="server" CssClass="form-control" />
                        <asp:Label ID="lblModel" Text="Model:" runat="server" CssClass="label" />
                        <asp:TextBox ID="txtModel" runat="server" CssClass="form-control" />
                        <asp:Label ID="lblSerialLeft" Text="Serial Number:" runat="server" CssClass="label" />
                        <asp:TextBox ID="txtSerialLeft" runat="server" CssClass="form-control" />
                        <div class="row" id="history" runat="server" visible="true"><div class="col-md-12">
                            <asp:Label ID="lblHistory" Text="History:" runat="server" CssClass="label" />
                            <asp:DropDownList runat="server" ID="ddlAssetHistory" CssClass="dropdown">
                                <asp:ListItem Text="10/28/2014 09:08 AM" />
                                <asp:ListItem Text="10/30/2014 01:32 PM" />
                                <asp:ListItem Text="10/30/2014 02:12 PM" />
                            </asp:DropDownList>
                        </div></div> 
                    </div>
                    <div class="col-md-6">
                        <asp:Label ID="lblStatus" Text="Status:" runat="server" CssClass="label" />
                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="dropdown">
                            <asp:ListItem Value="Active" Text="Active" />
                            <asp:ListItem>Out of Service</asp:ListItem>
                        </asp:DropDownList><br />
                        <asp:Label ID="lblSerialRight" Text="Serial Number:" runat="server" CssClass="label" />
                        <asp:TextBox ID="txtSerialRight" runat="server" CssClass="form-control" />
                        <asp:Label ID="lblDescription" Text="Description:" runat="server" CssClass="label" />
                        <asp:TextBox ID="txtDescription" TextMode="MultiLine" Columns="50" Rows="3" runat="server" CssClass="form-control" />
                        <asp:Label ID="lblNotes" Text="Notes:" runat="server" CssClass="label" />
                        <asp:TextBox ID="txtNotes" TextMode="MultiLine" Columns="50" Rows="5" runat="server" CssClass="form-control" />
                    </div>
                    <div class="row"><div id="Div1" class="col-md-12 button_row" style="text-align:center;" runat="server" visible="true">
                        <asp:Label ID="lblInputValidation" runat="server"></asp:Label>
                        <asp:Button ID="btnSubmitModifyAsset" Text="Submit Modification" runat="server" CssClass="btn btn-default" OnClick="btnSubmitModifyAsset_Click"/><asp:Label ID="lblAssetID" Text="" runat="server" CssClass="label" /></div></div>
                    <div class="row"><div id="submit_button" class="col-md-12 button_row" style="text-align:center;" runat="server" visible="true"><asp:Button ID="btnSubmit" Text="Submit" runat="server" CssClass="btn btn-default" OnClick="btnSubmit_Click"/></div></div>
                    <div class="row"><div id="search_button" class="col-md-12 button_row" style="text-align:center;" runat="server" visible="true"><asp:Button ID="btnSearch" Text="Search" runat="server" CssClass="btn btn-default" OnClick="btnSearch_Click"/></div></div>
                </div>
                <div class="row" id="search_results" runat="server" visible="true">
                    <div class="row header_row"><div class="col-xs-12"><p><h1>Asset Search Results</h1></p></div></div>
                    <div class="col-md-12">
                        <asp:GridView ID="gvSearchResults" runat="server" OnRowCommand="gvSearchResult_click" DataKeyNames="assetID"  AutoGenerateColumns="False" CssClass="table">
                            <Columns>
                                <asp:BoundField DataField="assetID" runat="server" Visible="false"></asp:BoundField>  
                                <asp:BoundField DataField="CLATag" HeaderText="CLA Tag" />
                                <asp:BoundField DataField="Make" HeaderText="Make" />
                                <asp:BoundField DataField="Model" HeaderText="Model" />
                                <asp:BoundField DataField="SerialNumber" HeaderText="Serial" />
                                <asp:BoundField DataField="Status" HeaderText="Status" />
                                <asp:ButtonField  ButtonType="Button"  Text="View/Edit" CommandName="modifyRecord" ControlStyle-CssClass="btn btn-default" >

<ControlStyle CssClass="btn btn-default"></ControlStyle>

                                </asp:ButtonField>
                                <asp:ButtonField ButtonType="Button" Text="Archive"  CommandName="deleteRecord" ControlStyle-CssClass="btn btn-danger" >

<ControlStyle CssClass="btn btn-danger"></ControlStyle>

                                </asp:ButtonField>
                                <asp:TemplateField HeaderText="Check-In">
                                    <ItemTemplate>
                                        <asp:Button ID="btnCheckIN" runat="server" OnClick="btnCheckIN_Click" Text="CheckIn" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div class="row"><div class="col-md-12 button_row" style="text-align:center;" ><asp:Button ID="btnNewSearch" Text="New Search" runat="server" CssClass="btn btn-default" OnClick="btnNewSearch_Click"/></div></div>
                </div>
            </form>
        </div> 
    </div>
</asp:Content>