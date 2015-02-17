<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="CD6.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/login.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="content" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-4 col-md-offset-4">
            <div class="row">
                <div class="col-md-10 col-md-offset-1">
                    <form role="form">
                        <div class="form-group">
                            <asp:Label ID="lblLoginName" Text="Username:" runat="server" CssClass="label"/>
                            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"/>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblPassword" Text="Password:" runat="server" CssClass="label"/>
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control"/>
                        </div>
                        <div class="center-block">
                            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-default" OnClick="btnLogin_Click"/>
                            <p><a href="https://accounts.temple.edu/selfcare/identification.jsp">Forgot Password</a></p>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>