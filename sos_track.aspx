<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="sos_track.aspx.cs" Inherits="CD6.sos_track"  EnableEventValidation="false" %>
<%@ MasterType VirtualPath="~/master.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/sos.css" rel="stylesheet" />
    <link href="css/secondary-nav.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="content" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row main_content">
        <div class="col-md-10 col-md-offset-1">
            <form role="form">
                <div class="row" id="sos_form" runat="server">
                    <div class="header_row">
                        <div class="col-md-12" id="header" runat="server">
                            <h1>Sign Sheet Tracking</h1>
                            <asp:Label ID="lblTrackingDirections" runat="server"  Visible="false" CssClass="instructions" style="padding-bottom: 10px; margin-bottom: 10px; position: relative; display: block;"/>
                        </div>
                    </div>
                    <asp:GridView ID="gvSosTracking" AutoGenerateColumns="false" DataKeyNames="sosID" runat="server" CssClass="table" OnRowCommand="gvSosTracking_RowCommand" >
                        <Columns>
                            <asp:BoundField DataField="sosID" HeaderText="SoS ID" />
                            <asp:BoundField DataField="Recipient" HeaderText="Recipient" />
                            <asp:BoundField DataField="Due" HeaderText="Due" />
                            <asp:BoundField DataField="Days until due:" HeaderText="Days until due:" />
                            <asp:BoundField DataField="Email" HeaderText="Email" />
                            <asp:BoundField DataField="Phone" HeaderText="Phone" />
                            <asp:ButtonField ButtonType="Button" Text="View" CommandName="view" ControlStyle-CssClass="btn-default btn" />
                        </Columns>
                    </asp:GridView>
                    <div style="text-align:right;">
                        <asp:LinkButton ID="linkExport" runat="server" OnClick="linkExport_Click" Text="Export Data" OnClientClick="aspnetForm.target='blank';" />
                    </div>
                </div>
            </form>
        </div>
    </div>
</asp:Content>
