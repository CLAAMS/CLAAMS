<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="assetSearch.aspx.cs" Inherits="CD6.assetSearch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Assets</title>
    <link href='http://fonts.googleapis.com/css?family=Droid+Sans' rel='stylesheet' type='text/css' />
    <link href='http://fonts.googleapis.com/css?family=Open+Sans+Condensed:300' rel='stylesheet' type='text/css' />
    <link href="css/fonts.css" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/master.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="row" id="content">
            <div class="col-md-12">
                <div class="row header_row"><div class="col-md-12" id="searchHeader" runat="server" visible="true"><p><h1>Search Assets</h1></p></div></div>
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
                <div class="button_row row"><div class="col-md-12" style="text-align:center;"><asp:Button ID="btnSearch" Text="Search" runat="server" OnClick="btnSearch_Click"/></div></div>
                <div class="row" id="searchResults" runat="server" visible="true"><div class="col-md-12"><br /><h3>Search Results:</h3>
                    <asp:GridView ID="gvSearchResults" runat="server" AutoGenerateColumns="false" CssClass="table">
                        <Columns>
                            <asp:BoundField DataField="assetID" HeaderText="ID" />
                            <asp:BoundField DataField="CLATag" HeaderText="CLA Tag" />
                            <asp:BoundField DataField="Make" HeaderText="Make" />
                            <asp:BoundField DataField="Model" HeaderText="Model" />
                            <asp:BoundField DataField="SerialNumber" HeaderText="Serial" />
                            <asp:BoundField DataField="Status" HeaderText="Status" />
                            <asp:TemplateField HeaderText="Add Assset" >
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkAddAsset" runat="server"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                     </asp:GridView>
                    <div class="button_row row"><div class="col-md-12" style="text-align:center;"><asp:Button ID="btnAddAsset" Text="Add Asset" runat="server" OnClientClick="window.close(); return false;" /></div></div>
                </div></div>
            </div>
        </div>
    </form>
</body>
</html>
