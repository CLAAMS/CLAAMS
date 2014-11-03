<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="recipient.aspx.cs" Inherits="CD6.recipient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/recipient.css" rel="stylesheet" />
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
                    <li><a href="#">Search</a></li>
                    <li><a href="#">Create</a></li>
                </ul>
            </div><!--/.nav-collapse -->
        </div><!--/.container-fluid -->
    </nav>

    <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <form role="form">
                <div class="row" id="recipient_form">
                    <div class="row"><div class="col-md-12" style="margin-bottom:30px;"><p><h1>Create New Recipient</h1></p></div></div>
                    <div class="col-md-6">
                        <asp:Label ID="lblFirstName" Text="First Name:" runat="server" CssClass="label" />
                        <asp:TextBox ID="txtFirstname" runat="server" CssClass="form-control" />
                        <asp:Label ID="lblEmail" Text="Email:" runat="server" CssClass="label" />
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
                        <asp:Label ID="lblLocation" Text="Location:" runat="server" CssClass="label" />
                        <asp:TextBox ID="txtLocation" runat="server" CssClass="form-control" />
                        <asp:Label ID="lblPrimaryDept" Text="Primary Department Affiliation:" runat="server" CssClass="label" />
                        <asp:DropDownList ID="ddlPrimaryDept" runat="server" CssClass="dropdown" style="width:100%;">
                            <asp:ListItem Value="English" Text="English" />
                            <asp:ListItem Value="Psychology" Text="Psychology" />
                            <asp:ListItem Value="Literature" Text="Literature" />
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-6">
                        <asp:Label ID="lblLastName" Text="Last Name:" runat="server" CssClass="label" />
                        <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" />
                        <asp:Label ID="lblDivision" Text="Division:" runat="server" CssClass="label" />
                        <asp:TextBox ID="txtDivision" runat="server" CssClass="form-control" />
                        <asp:Label ID="lblPhone" Text="Phone:" runat="server" CssClass="label" />
                        <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" />
                        <asp:Label ID="lblSecondaryDept" Text="Secondary Department Affiliation:" runat="server" CssClass="label" />
                        <asp:DropDownList ID="ddlSecondaryDept" runat="server" CssClass="dropdown" style="width:100%;">
                            <asp:ListItem Value="English" Text="English" />
                            <asp:ListItem Value="Psychology" Text="Psychology" />
                            <asp:ListItem Value="Literature" Text="Literature" />
                        </asp:DropDownList>
                    </div>
                    <div class="row button_row"><div class="col-md-12" style="text-align:center;" runat="server" visible="false"><asp:Button ID="btnSubmit" Text="Submit" runat="server" CssClass="btn btn-default" /></div></div>
                    <div class="row button_row"><div class="col-md-12" style="text-align:center;" runat="server" visible="true"><asp:Button ID="btnSearch" Text="Search" runat="server" CssClass="btn btn-default" /></div></div>
                </div>
                <div class="row" id="search_results" runat="server" visible="false">
                    <div class="col-md-12">
                        <asp:GridView ID="gvSearchResults" runat="server" OnRowCommand="gvSearchResult_click" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                                <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                                <asp:BoundField DataField="EmailAddress" HeaderText="Email" />
                                <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" />
                                <asp:BoundField DataField="PrimaryDeptAffiliation" HeaderText="Primary Department" />
                                <asp:BoundField DataField="SecondaryDeptAffiliation" HeaderText="Secondary Department" />
                                <asp:BoundField DataField="Division" HeaderText="Division" />
                                <asp:ButtonField ButtonType="Button" Text="Delete" CommandName="deleteRecord" ControlStyle-CssClass="btn btn-danger" /> 
                                <asp:ButtonField ButtonType="Button" Text="Modify" CommandName="modifyRecord" ControlStyle-CssClass="btn btn-danger" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </form>
        </div>
    </div>
</asp:Content>