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
                                <div class="form-group">
                                    <asp:Label ID="lblSOSID" Text="Sign Sheet ID:" runat="server" CssClass="label" />
                                    <asp:TextBox ID="txtSOSID" runat="server" CssClass="form-control" />
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label3" Text="Sign Sheet ID:" runat="server" CssClass="label" />
                                    <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" />
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label4" Text="Sign Sheet ID:" runat="server" CssClass="label" />
                                    <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" />
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label9" Text="Sign Sheet ID:" runat="server" CssClass="label" />
                                    <asp:TextBox ID="TextBox9" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Label ID="Label1" Text="Sign Sheet ID:" runat="server" CssClass="label" />
                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" />
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label5" Text="Sign Sheet ID:" runat="server" CssClass="label" />
                                    <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control" />
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label6" Text="Sign Sheet ID:" runat="server" CssClass="label" />
                                    <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control" />
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label10" Text="Sign Sheet ID:" runat="server" CssClass="label" />
                                    <asp:TextBox ID="TextBox10" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Label ID="Label2" Text="Sign Sheet ID:" runat="server" CssClass="label" />
                                    <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" />
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label7" Text="Sign Sheet ID:" runat="server" CssClass="label" />
                                    <asp:TextBox ID="TextBox7" runat="server" CssClass="form-control" />
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label8" Text="Sign Sheet ID:" runat="server" CssClass="label" />
                                    <asp:TextBox ID="TextBox8" runat="server" CssClass="form-control" />
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label11" Text="Sign Sheet ID:" runat="server" CssClass="label" />
                                    <asp:TextBox ID="TextBox11" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label ID="lblNotes" Text="Notes:" runat="server" CssClass="label" />
                                    <asp:TextBox ID="txtNotes" runat="server" TextMode="MultiLine" Rows="10" CssClass="form-control" />
                                </div>
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
