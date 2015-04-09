<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="assetSearchForSoS.aspx.cs" Inherits="CD6.WebForm1" %>
<%@ MasterType VirtualPath="~/master.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/sos.css" rel="stylesheet" />
    <link href="css/secondary-nav.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="content" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row main_content">
        <div class="col-md-8 col-md-offset-2">
            <form role="form">
                <div class="row" id="searchFields" runat="server" >
                    <div class="row header_row">
                        <div class="col-md-12" id="searchHeader" runat="server" visible="true">
                            <p>
                                <h1>Search Assets</h1>
                                <div class="instructions">
                                    <asp:Label ID="lblSearchAssetsForSOSDirections" runat="server" Visible="false" CssClass="label instructions"/>
                                </div>
                            </p>
                        </div>
                    </div>
                    <div class="row"><div class="col-md-12"><asp:Label ID="lblERROR" runat="server" CssClass="label" Visible="false"/></div></div>
                    <div class="row"><div class="col-md-12"><asp:Label ID="lblAssetID" Text="Asset ID:" runat="server" CssClass="label" /></div></div>
                    <div class="row"><div class="col-md-12"><asp:TextBox ID="txtAssetID" runat="server" CssClass="form-control" /></div></div>
                    <div class="row"><div class="col-md-12"><asp:Label ID="lblAssetName" Text="Asset Name:" runat="server" CssClass="label" /></div></div>
                    <div class="row"><div class="col-md-12"><asp:TextBox ID="txtAssetName" runat="server" CssClass="form-control" /></div></div>
                    <div class="row"><div class="col-md-12"><asp:Label ID="lblAssetType" Text="Asset Type:" runat="server" CssClass="label" /></div></div>
                    <div class="row"><div class="col-md-12"><asp:TextBox ID="txtAssetType" runat="server" CssClass="form-control" /></div></div>
                    <div class="row"><div class="col-md-12"><asp:Label ID="lblCLATag" Text="CLA Tag:" runat="server" CssClass="label" /></div></div>
                    <div class="row"><div class="col-md-12"><asp:TextBox ID="txtCLATag" runat="server" CssClass="form-control" /></div></div>
                    <div class="row"><div class="col-md-12"><asp:Label ID="lblSerial" Text="Serial:" runat="server" CssClass="label" /></div></div>
                    <div class="row"><div class="col-md-12"><asp:TextBox ID="txtSerial" runat="server" CssClass="form-control" /></div></div>
                    <div class="button_row row">
                        <div class="col-md-12" style="text-align:center;">
                            <asp:Button ID="btnSearch" Text="Search" runat="server" OnClick="btnSearch_Click" CssClass="btn btn-default"/>
                        </div>
                    </div>
                </div>
                <div class="row header_row" id="searchResults" runat="server" visible="true">
                    <div class="col-md-12">
                        <br />
                        <h3>Search Results:</h3>
                        <div class="instructions">
                            <asp:Label ID="lblSearchAssetsForSOSSelectDirections" runat="server" Visible="false" CssClass="label instructions"/> 
                        </div>
                    <asp:GridView ID="gvSearchResults" runat="server" AutoGenerateColumns="False" CssClass="table">
                        <Columns>
                            <asp:BoundField DataField="assetID" HeaderText="ID" />
                            <asp:BoundField DataField="CLATag" HeaderText="CLA Tag" />
                            <asp:BoundField DataField="Make" HeaderText="Make" />
                            <asp:BoundField DataField="Model" HeaderText="Model" />
                            <asp:BoundField DataField="SerialNumber" HeaderText="Serial" />
                            <asp:BoundField DataField="Status" HeaderText="Status" />
                            <asp:TemplateField HeaderText="Add Asset" >
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkAddAsset" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <div class="row button_row">
                        <div class="col-md-1 col-md-offset-4" style="text-align:center;">
                            <asp:Button ID="btnAddAsset" Text="Add Asset" runat="server" OnClick="btnAddAsset_Click" CssClass="btn btn-default" />
                        </div>
                        <div class="col-md-1"></div>
                        <div class="col-md-1" style="text-align:center;">
                            <asp:Button ID="btnNewSearch" Text="New Search" runat="server" OnClick="btnNewSearch_Click" CssClass="btn btn-default" />
                        </div>
                    </div>
                </div></div>
            </form>
        </div>
    </div>
</asp:Content>
