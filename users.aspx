<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="users.aspx.cs" Inherits="CD6.users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                    <li><asp:LinkButton ID="btnCurrent" OnClick="btnCurrent_Click" Text="Current Users" runat="server" /></li>
                    <li><asp:LinkButton ID="btnAdd" OnClick="btnAdd_Click" Text="Add User" runat="server" /></li>
                </ul>
            </div><!--/.nav-collapse -->
        </div><!--/.container-fluid -->
    </nav>

    <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <div class="row" id="UsersList" runat="server" visible="true">
                <div class="row header_row"><div class="col-md-12" id="usersHeader" runat="server" visible="true"><p><h1>Current Users</h1></p></div></div>
                <div class="col-md-12">
                    <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="false" CssClass="table" OnRowCommand="gvUsers_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                            <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                            <asp:BoundField DataField="CLAID" HeaderText="AccessNet ID" />
                            <asp:BoundField DataField="Email" HeaderText="Email" />
                            <asp:ButtonField Text="View/Edit" ButtonType="Button" ControlStyle-CssClass="btn btn-default" CommandName="modify" />
                            <asp:ButtonField Text="Delete" ButtonType="Button" ControlStyle-CssClass="btn btn-danger" CommandName="delet"/>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="row" id="UserForm" runat="server" visible="true">
                <div class="row header_row"><div class="col-md-12" id="createHeader" runat="server" visible="true"><p><h1>Add User</h1></p></div></div>
                <div class="row header_row"><div class="col-md-12" id="modifyHeader" runat="server" visible="true"><p><h1>Modify User</h1></p></div></div>
                <div class="col-md-12">
                    <asp:Label ID="lblCLAID" Text="AccessNet ID:" runat="server" CssClass="label" />
                    <asp:TextBox ID="txtCLAID" runat="server" CssClass="form-control" Enabled="false" />
                    <asp:Label ID="lblFirstName" Text="First Name: *" runat="server" CssClass="label" />
                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" />
                    <asp:Label ID="lblLastName" Text="Last Name: *" runat="server" CssClass="label" />
                    <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" />
                    <asp:Label ID="lblOffice" Text="Office Location:" runat="server" CssClass="label" />
                    <asp:TextBox ID="txtOffice" runat="server" CssClass="form-control" />
                    <asp:Label ID="lblUserStatus" Text="User Status: *" runat="server" CssClass="label" /><br />
                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="dropdown" style="width:100%;">
                        <asp:ListItem Text="Active" />
                        <asp:ListItem Text="Inactive" />
                    </asp:DropDownList><br />
                    <asp:Label ID="lblEmail" Text="Email:" runat="server" CssClass="label" />
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
                    <div class="row"><div class="col-md-12 button_row" style="text-align:center;"><asp:Button ID="btnSubmit" Text="Submit" runat="server" /></div></div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
