<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="manageTemplates.aspx.cs" Inherits="CD6.manageTemplates" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Manage Templates</title>
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
                <div class="row header_row"><div class="col-md-12" id="manageTemplatesHeader" runat="server" visible="true"><h1>Manage Templates</h1></div></div>
                <div class="row"><div class="col-md-12"><asp:Label ID="lblTemplate" Text="Template Name:" runat="server" CssClass="label" /></div></div>
                <div class="row"><div class="col-md-12"><asp:TextBox ID="txtTemplate" runat="server" CssClass="form-control" /></div></div>
                <div class="row"><div class="col-md-12"><asp:Label ID="lblMake" Text="Make:" runat="server" CssClass="label" /></div></div>
                <div class="row"><div class="col-md-12"><asp:TextBox ID="txtMake" runat="server" CssClass="form-control" /></div></div>
                <div class="row"><div class="col-md-12"><asp:Label ID="lblModel" Text="Model:" runat="server" CssClass="label" /></div></div>
                <div class="row"><div class="col-md-12"><asp:TextBox ID="txtModel" runat="server" CssClass="form-control" /></div></div>
                <div class="row"><div class="col-md-12"><asp:Label ID="lblDescription" Text="Description:" runat="server" CssClass="label" /></div></div>
                <div class="row"><div class="col-md-12"><asp:TextBox ID="txtDescription" TextMode="MultiLine" Columns="50" Rows="5" runat="server" CssClass="form-control" /></div></div>
                <div class="button_row row"><div class="col-md-12" style="text-align:center;"><asp:Button ID="btnAddTemplate" Text="Add Template" runat="server" OnClick="btnAddTemplate_Click"/></div></div>
                <div class="row" id="searchResults" runat="server" visible="true"><div class="col-md-12"><br /><h3>Current Templates:</h3>
                    <asp:GridView ID="gvTemplates" runat="server" AutoGenerateColumns="false" CssClass="table" OnRowCommand="gvTemplates_RowCommand" DataKeyNames="assetTemplateID">
                        <Columns>
                            <asp:BoundField DataField="Name" HeaderText="Name" />
                            <asp:BoundField DataField="Make" HeaderText="Make" />
                            <asp:BoundField DataField="Model" HeaderText="Model" />
                            <asp:BoundField DataField="Description" HeaderText="Description" />
                            <asp:ButtonField Text="Delete" ButtonType="Button" ControlStyle-CssClass="btn-danger btn" CommandName="delTemplate" />
                            <asp:ButtonField Text="View/Modify" ButtonType="Button" ControlStyle-CssClass="btn-default btn" CommandName="editTemplate" />
                        </Columns>
                     </asp:GridView>
                    <div class="button_row row"><div class="col-md-12" style="text-align:center;"><asp:Button ID="btnClose" Text="Close" runat="server" OnClientClick="window.close(); return false;" /></div></div>
                </div></div>
            </div>
        </div>
    </form>
</body>
</html>
