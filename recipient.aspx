<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="recipient.aspx.cs" Inherits="CD6.recipient" %>
<%@ MasterType VirtualPath="~/master.Master" %>
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
                    <li><asp:LinkButton Text="Create" runat="server" OnClick="btnCreate_Click"/></li>
                    <li><asp:LinkButton Text="Search" runat="server" OnClick="btnNewSearch_Click"/></li>
                </ul>
            </div><!--/.nav-collapse -->
        </div><!--/.container-fluid -->
    </nav>
       <div class="modal fade" id="modifyRecipientModal" tabindex="-1" role="dialog" aria-labelledby="modifyrecipientModal" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content" style="text-align:center;">
                        <div class="modal-header">
                            <!--<button type="button" class="close" data-dismiss="modal" aria-hidden="true"/>-->
                            <h4 class="modal-title" id="modifyRecipientModalLabel"><asp:Label ID="lblModifyRecipient_header" runat="server" /></h4>
                        </div>
                        <div class="modal-body">
                            <h3><asp:label id="lblModifyRecipient_body" runat="server" /></h3>
                            <asp:Button ID="btnModifyRecipientModalYes" Text="Yes" runat="server" CssClass="btn btn-default" OnClick="btnModifyRecipientModalYes_Click"/>
                            <asp:Button ID="btnModifyRecipientModalNo" Text="No" runat="server" CssClass="btn btn-default"  OnClick="btnModifyRecipientModalNo_Click"/>
                        </div>
                    </div>
                </div>
            </div>
    <div class="row main_content">
        <div class="col-md-8 col-md-offset-2">
            <form role="form">
                <div class="row" id="recipient_form" runat="server" visible="true">
                    <div class="row header_row"><div class="col-md-12" id="searchHeader" runat="server" visible="true"><h1>Search Recipients</h1></div><div class="instructions"><asp:label id="lblSearchRecipientsDirections" runat="server" Visible="false" CssClass="label instructions" /></div></div>
                    <div class="row header_row"><div class="col-md-12" id="createHeader" runat="server" visible="true"><h1>Create Recipient</h1></div><div class="instructions"><asp:label id="lblCreateRecipientsDirections" runat="server" Visible="false" CssClass="label instructions" /></div></div>
                    <div class="row header_row"><div class="col-md-12" id="modifyHeader" runat="server" visible="true"><h1>Modify Recipient</h1></div><div class="instructions"><asp:label id="lblModifyRecipientsDirections" runat="server" Visible="false" CssClass="label instructions" /></div></div>
                    <div class="col-md-6">
                        <div class="row">
                            <div class="col-md-2">
                                <asp:Label ID="lblTitle" Text="Title:" runat="server" CssClass="label" />
                                <asp:DropDownList ID="ddlTitle" runat="server" CssClass="dropdown">
                                    <asp:ListItem Text="Mr." />
                                    <asp:ListItem Text="Mrs." />
                                    <asp:ListItem Text="Dr." />
                                    <asp:ListItem Text="Prof." />
                                    <asp:ListItem Text="" Selected="True" />
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-10">
                        <asp:Label ID="lblFirstName" Text="First Name: *" runat="server" CssClass="label" />
                        <asp:TextBox ID="txtFirstname" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                        <asp:Label ID="lblEmail" Text="Email: *" runat="server" CssClass="label" />
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
                        <asp:Label ID="lblLocation" Text="Location: *" runat="server" CssClass="label" />
                        <asp:TextBox ID="txtLocation" runat="server" CssClass="form-control" />
                        <div class="row">
                            <div class="col-md-6">
                                <asp:Label ID="lblPrimaryDept" Text="Primary Department Affiliation: *" runat="server" CssClass="label" />
                            </div>
                            <div class="col-md-6" style="text-align:right;">
                                <a onclick="addDepartment()">Add Department</a>
                            </div>
                        </div>
                        <asp:DropDownList ID="ddlPrimaryDept" runat="server" CssClass="dropdown" style="width:100%;" AppendDataBoundItems="true" />
                    </div>
                    <div class="col-md-6">
                        <asp:Label ID="lblLastName" Text="Last Name: *" runat="server" CssClass="label" />
                        <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" />
                        <asp:Label ID="lblDivision" Text="Division:" runat="server" CssClass="label" />
                        <asp:TextBox ID="txtDivision" runat="server" CssClass="form-control" />
                        <asp:Label ID="lblPhone" Text="Phone:" runat="server" CssClass="label" />
                        <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" />
                        <asp:Label ID="lblSecondaryDept" Text="Secondary Department Affiliation:" runat="server" CssClass="label" />
                        <asp:DropDownList ID="ddlSecondaryDept" runat="server" CssClass="dropdown" style="width:100%;" AppendDataBoundItems="true" />
                    </div>
                    <div class="row">
                        <div class="col-md-12 button_row" id="button_submit" style="text-align:center;" runat="server" visible="true">
                            <asp:Button ID="btnSubmitCreate" Text="Submit" runat="server" CssClass="btn btn-default" OnClick="btnSubmit_Click" Width="92px"/><asp:Label ID="lblARID" runat="server" Visible="False"/>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12 button_row" id="button_search" style="text-align:center;" runat="server" visible="true">
                            <asp:Button ID="btnSearch" Text="Search" runat="server" CssClass="btn btn-default" OnClick="btnSearch_Click" />
                        </div>
                    </div>
                </div>
                <div class="row" id="search_results" runat="server" visible="true">
                    <div class="row header_row"><div class="col-md-12"><h1>Recipient Search Results</h1></div></div>
                    <div class="col-md-12">
                        <asp:GridView ID="gvSearchResults" runat="server" DataKeyNames="ArID" OnRowCommand="gvSearchResult_click"  AutoGenerateColumns="False" CssClass="table"   >
                            <Columns>
                                <asp:BoundField HeaderText="Location" Visible="False" />
                                <asp:BoundField DataField="ArID" runat="server" Visible="false"></asp:BoundField>
                                <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                                <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                                <asp:BoundField DataField="EmailAddress" HeaderText="Email" />
                                <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" />
                                <asp:BoundField DataField="PrimaryDeptAffiliation" HeaderText="Primary Department" />
                                <asp:BoundField DataField="SecondaryDeptAffiliation" HeaderText="Secondary Department" />
                                <asp:BoundField DataField="Division" HeaderText="Division" />
                                <asp:ButtonField ButtonType="Button" Text="View/Edit" CommandName="modifyRecord" ControlStyle-CssClass="btn btn-default"/>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div class="row">
                        <div class="col-md-12 button_row" style="text-align:center;">
                            <asp:Button ID="btnNewSearch" Text="New Search" runat="server" OnClick="btnNewSearch_Click" CssClass="btn btn-default" />
                        </div>
                    </div>
                </div>
            </form>
        </div>
    </div>
</asp:Content>