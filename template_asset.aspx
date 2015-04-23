<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="template_asset.aspx.cs" Inherits="CD6.template_asset" %>
<%@ MasterType VirtualPath="~/master.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/sos.css" rel="stylesheet" />
    <link href="css/secondary-nav.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="content" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body>
        <div class="row">
            <div class="col-md-10 col-md-offset-1">
                <div class="row" id="sos_form" runat="server">
                    <div class="row header_row">
                        <div class="col-md-12" id="header" runat="server">
                            <h1>Manage Templates</h1>
                            <div class="instructions">
                                <asp:Label ID="lblManageTemplateDirections" runat="server"  Visible="false" CssClass="instructions"/>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row" id="Div1">
                    <div class="col-md-12">
                        <div class="row"><div class="col-md-12"><asp:Label ID="lblTemplate" Text="Template Name:" runat="server" CssClass="label" /></div></div>
                        <div class="row"><div class="col-md-12"><asp:TextBox ID="txtTemplate" runat="server" CssClass="form-control" /></div></div>
                        <div class="row"><div class="col-md-12"><asp:Label ID="lblMake" Text="Make:" runat="server" CssClass="label" /></div></div>
                        <div class="row"><div class="col-md-12"><asp:TextBox ID="txtMake" runat="server" CssClass="form-control" /></div></div>
                        <div class="row"><div class="col-md-12"><asp:Label ID="lblModel" Text="Model:" runat="server" CssClass="label" /></div></div>
                        <div class="row"><div class="col-md-12"><asp:TextBox ID="txtModel" runat="server" CssClass="form-control" /></div></div>
                        <div class="row"><div class="col-md-12"><asp:Label ID="lblDescription" Text="Description:" runat="server" CssClass="label" /></div></div>
                        <div class="row"><div class="col-md-12"><asp:TextBox ID="txtDescription" TextMode="MultiLine" Columns="50" Rows="5" runat="server" CssClass="form-control" /></div></div>
                        <div class="button_row row"><div class="col-md-12" style="text-align:center;"><asp:Button ID="btnAddTemplate" Text="Add Template" runat="server" OnClick="btnAddTemplate_Click"/></div></div>
                        <div class="row" id="searchResults" runat="server" visible="true">
                            <div class="col-md-12"><br /><h3>Current Templates:</h3>
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
                             </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-2 col-md-offset-5 button_row" style="text-align:center;">
                        <asp:Button ID="btnClose" Text="Close" runat="server" CssClass="btn btn-default" OnClick="btnClose_Click"/>
                    </div>
                </div>
            </div>
       </div>
   </body>     
</asp:Content>
