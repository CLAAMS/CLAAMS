<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="sos.aspx.cs" Inherits="CD6.sos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/sos.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="content" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-10 col-md-offset-1">
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
                <div id="searching" runat="server" visible="true">
                    <form role="form">
                        <div class="row">
                            <div class="col-md-4">
                                <asp:Label ID="lblRecipient" Text="Recipient:" runat="server" CssClass="label" />
                                <asp:DropDownList ID="ddlRecipient" runat="server" CssClass="dropdown"/>
                                <br />
                                <asp:Label ID="lblAssigner" Text="From:" runat="server" CssClass="label" />
                                <asp:DropDownList ID="ddlAssigner" runat="server" CssClass="dropdown" />
                                <br />
                                <asp:Label ID="lblDate" Text="Issue Date:" runat="server" CssClass="label" />
                                <asp:Calendar ID="calIssueDate" runat="server" SelectedDate="10/28/2014"/>
                                <br />
                                <asp:Label ID="lblTerm" Text="Term:" runat="server" CssClass="label" />
                                <asp:DropDownList ID="ddlTerm" runat="server" CssClass="dropdown">
                                    <asp:ListItem Value="1" Text="Permanent" />
                                    <asp:ListItem Value="0" Text="Non-Permanent" />
                                </asp:DropDownList>
                                <br />
                                <div id="term" runat="server" visible="true">
                                    <asp:Label ID="lblDueDate" Text="Due Date:" runat="server" CssClass="label" />
                                    <asp:Calendar ID="calDueDate" runat="server" />
                                </div>
                                <asp:Label ID="lblAssets" Text="Assets:" runat="server" CssClass="label" />
                                <asp:ListBox ID="lstbxAssets" runat="server" CssClass="list-group" style="width:150px;"></asp:ListBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2 col-md-offset-5" style="text-align:center;">
                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-default" />
                            </div>
                        </div>
                    </form>
                </div>
            </div>
            <div id="modify"></div>
        </div>
    </div>
</asp:Content>
