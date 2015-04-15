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
                    <li><asp:LinkButton ID="LinkButton1" OnClick="btnCreate_Click" Text="Create" runat="server" /></li>
                    <li><asp:LinkButton OnClick="btnNewSearch_Click" Text="Search" runat="server" /></li>
                </ul>
            </div><!--/.nav-collapse -->
        </div><!--/.container-fluid -->
    </nav>
     <div class="modal fade" id="modalArchiveAsset" tabindex="-1" role="dialog" aria-labelledby="modalArchiveAsset" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content" style="text-align:center;">
                        <div class="modal-header">
                            <!--<button type="button" class="close" data-dismiss="modal" aria-hidden="true"/>-->
                            <h4 class="modal-title" id="myModalLabel"><asp:Label ID="lblModal_header" runat="server" /></h4>
                        </div>
                        <div class="modal-body">
                            <h3><asp:label id="lblModal_body" runat="server" /></h3>
                            <asp:Button ID="btnArchiveAssetYes" Text="Yes" runat="server" CssClass="btn btn-default" OnClick="btnArchiveAssetYes_Click"/>
                            <asp:Button ID="btnArchiveAssetNo" Text="No" runat="server" CssClass="btn btn-default" OnClick="btnArchiveAssetNo_Click"/>
                        </div>
                    </div>
                </div>
            </div>
     <div class="modal fade" id="modifyAssetModal" tabindex="-1" role="dialog" aria-labelledby="modifyAssetModal" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content" style="text-align:center;">
                        <div class="modal-header">
                            <!--<button type="button" class="close" data-dismiss="modal" aria-hidden="true"/>-->
                            <h4 class="modal-title" id="modifyModalLabel"><asp:Label ID="lblModifyAssetModal_header" runat="server" /></h4>
                        </div>
                        <div class="modal-body">
                            <h3><asp:label id="lblModifyAssetModal_body" runat="server" /></h3>
                            <asp:Button ID="btnModifyAssetModalYes" Text="Yes" runat="server" CssClass="btn btn-default" OnClick="btnModifyAssetModalYes_Click" />
                            <asp:Button ID="btnModifyAssetModalNo" Text="No" runat="server" CssClass="btn btn-default" OnClick="btnModifyAssetModalNo_Click" />
                        </div>
                    </div>
                </div>
            </div>
    <div class="row main_content">
        <div class="col-md-8 col-md-offset-2">
            <form role="form">
                <div class="row" id="asset_form" runat="server" visible="true">
                    <div class="row header_row">
                        <div class="col-md-12" id="searchHeader" runat="server" visible="true">
                            <p>
                                <h1>Search Assets</h1>
                                <div class="instructions">
                                    <asp:label id="lblSearchAssetsDirections" runat="server" Visible="false" CssClass="instructions"/>
                                </div>
                            </p>
                        </div>
                    </div>
                    <div class="row header_row">
                        <div class="col-md-12" id="createHeader" runat="server" visible="true">
                            <p>
                                <h1>Create Asset</h1>
                                <div class="instructions">
                                    <asp:label id="lblCreateAssetDirections" runat="server" Visible="false" CssClass="instructions"/>
                                </div>
                            </p>
                        </div>
                    </div>
                    <div class="row header_row">
                        <div class="col-md-12" id="modifyHeader" runat="server" visible="true">
                            <p>
                                    <h1>Modify Asset</h1>
                                <div class="instructions">
                                    <asp:label id="lblModifyAssetDirections" runat="server" Visible="false" CssClass="instructions"/>
                                </div>
                            </p>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="row" id="templateRow" runat="server">
                            <div class="col-xs-9">
                                <asp:Label ID="lblTemplate" Text="Template:" runat="server" CssClass="label" />
                                <asp:DropDownList ID="ddlAssetTemplate" runat="server" AutoPostBack="true" CssClass="dropdown" OnSelectedIndexChanged="ddlAssetTemplate_SelectedIndexChanged"/>
                            </div>
                            <div class="col-xs-3">
                                <asp:linkbutton runat="server" id="manage_templates" text="Manage Templates" OnClick="manage_templates_Click" />. 
                            </div>
                        </div>
                        <div style="height:34px;" runat="server" id="filler">&nbsp</div>
                        <asp:Label ID="lblCLAID" Text="CLA Tag:" runat="server" CssClass="label" />
                        <asp:TextBox ID="txtCLAID" runat="server" CssClass="form-control" TabIndex="1"/>
                        <asp:Label ID="lblMake" Text="Make:" runat="server" CssClass="label" />
                        <asp:TextBox ID="txtMake" runat="server" CssClass="form-control" TabIndex="2"/>
                        <asp:Label ID="lblModel" Text="Model:" runat="server" CssClass="label" />
                        <asp:TextBox ID="txtModel" runat="server" CssClass="form-control" TabIndex="3"/>
                        <asp:Label ID="lblSerialLeft" Text="Serial Number:" runat="server" CssClass="label" />
                        <asp:TextBox ID="txtSerialLeft" runat="server" CssClass="form-control" TabIndex="4"/>
                        <div class="row" id="history" runat="server" visible="true">
                            <div class="col-md-12">
                                <asp:Label ID="lblHistory" Text="History:" runat="server" CssClass="label" />
                                <asp:DropDownList runat="server" ID="ddlAssetHistory" CssClass="dropdown" AppendDataBoundItems="true" />
                            </div>
                        </div> 
                    </div>
                    <div class="col-md-6">
                        <asp:Label ID="lblStatus" Text="Status:" runat="server" CssClass="label" />
                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="dropdown" AppendDataBoundItems="true" TabIndex="5">
                            <asp:ListItem Value="Active" Text="Active" />
                            <asp:ListItem Value="Out of Service" Text="Out of Service" />
                        </asp:DropDownList><br />
                        <asp:Label ID="lblSerialRight" Text="Serial Number:" runat="server" CssClass="label" />
                        <asp:TextBox ID="txtSerialRight" runat="server" CssClass="form-control" TabIndex="4"/>
                        <asp:Label ID="lblDescription" Text="Description:" runat="server" CssClass="label" />
                        <asp:TextBox ID="txtDescription" TextMode="MultiLine" Columns="50" Rows="3" runat="server" CssClass="form-control" TabIndex="6"/>
                        <asp:Label ID="lblNotes" Text="Notes:" runat="server" CssClass="label" />
                        <asp:TextBox ID="txtNotes" TextMode="MultiLine" Columns="50" Rows="5" runat="server" CssClass="form-control" TabIndex="7"/>
                    </div>
                    <div class="row">
                        <div id="Div1" class="col-md-12 button_row" style="text-align:center;" runat="server" visible="true">
                            <asp:Label ID="lblInputValidation" runat="server" />
                            <asp:Button ID="btnSubmitModifyAsset" Text="Submit Modification" runat="server" CssClass="btn btn-default" OnClick="btnSubmitModifyAsset_Click"/><asp:Label ID="lblAssetID" Text="" runat="server" CssClass="label" Visible="false" TabIndex="8"/>
                        </div>
                    </div>
                    <div class="row">
                        <div id="submit_button" class="col-md-12 button_row" style="text-align:center;" runat="server" visible="true">
                            <asp:Button ID="btnSubmit" Text="Submit" runat="server" CssClass="btn btn-default" OnClick="btnSubmit_Click" TabIndex="9"/>
                        </div>
                    </div>
                    <div class="row">
                        <div id="search_button" class="col-md-12 button_row" style="text-align:center;" runat="server" visible="true">
                            <asp:Button ID="btnSearch" Text="Search" runat="server" CssClass="btn btn-default" OnClick="btnSearch_Click" TabIndex="10"/>
                        </div>
                    </div>
                </div>
                <div class="row" id="search_results" runat="server" visible="true">
                    <div class="row header_row">
                        <div class="col-xs-12">
                            <p>
                                <h1>Asset Search Results</h1>
                            </p>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <asp:GridView ID="gvSearchResults" runat="server" OnRowCommand="gvSearchResult_click" DataKeyNames="assetID"  AutoGenerateColumns="False" CssClass="table">
                            <Columns>
                                <asp:BoundField DataField="assetID" runat="server" Visible="false"></asp:BoundField>  
                                <asp:BoundField DataField="CLATag" HeaderText="CLA Tag" />
                                <asp:BoundField DataField="Make" HeaderText="Make" />
                                <asp:BoundField DataField="Model" HeaderText="Model" />
                                <asp:BoundField DataField="SerialNumber" HeaderText="Serial" />
                                <asp:BoundField DataField="Status" HeaderText="Status" />
                                <asp:ButtonField ButtonType="Button" Text="View/Edit" CommandName="modifyRecord" ControlStyle-CssClass="btn btn-default" />
                                <asp:ButtonField ButtonType="Button" Text="Archive" CommandName="deleteRecord" ControlStyle-CssClass="btn btn-danger" />
                                <asp:ButtonField ButtonType="Button" Text="Check In" CommandName="checkinRecord" ControlStyle-CssClass="btn btn-default" />
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div class="row"><div class="col-md-12 button_row" style="text-align:center;" ><asp:Button ID="btnNewSearch" Text="New Search" runat="server" CssClass="btn btn-default" OnClick="btnNewSearch_Click"/></div></div>
                </div>
            </form>
        </div> 
    </div>
</asp:Content>