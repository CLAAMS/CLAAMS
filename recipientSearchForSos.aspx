<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="recipientSearchForSos.aspx.cs" Inherits="CD6.recipientSearchForSos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/sos.css" rel="stylesheet" />
    <link href="css/secondary-nav.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="content" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row main_content">
        <div class="col-md-10 col-md-offset-1">
            <form role="form">
                <div class="row" id="searchFields" runat="server" >
                    <div class="row header_row">
                        <div class="col-md-12" id="searchHeader" runat="server" visible="true">
                            <p>
                                <h1>Search Recipients</h1>
                                <div class="instructions">
                                    <asp:Label ID="lblSearchRecipientsForSOSDirections" runat="server" Visible="false" CssClass="instructions"/>
                                </div>
                            </p>
                        </div>
                    </div>
                    <div class="row"><div class="col-md-12"><asp:Label ID="lblERROR" runat="server" CssClass="label" Visible="false"/></div></div>
                    <div class="row"><div class="col-md-12"><asp:Label ID="lblFirstName" Text="First Name:" runat="server" CssClass="label" /></div></div>
                    <div class="row"><div class="col-md-12"><asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" TabIndex="1"/></div></div>
                    <div class="row"><div class="col-md-12"><asp:Label ID="lblLastName" Text="Last Name:" runat="server" CssClass="label" /></div></div>
                    <div class="row"><div class="col-md-12"><asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" TabIndex="2"/></div></div>
                    <div class="row"><div class="col-md-12"><asp:Label ID="lblEmail" Text="Email:" runat="server" CssClass="label" /></div></div>
                    <div class="row"><div class="col-md-12"><asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TabIndex="3"/></div></div>
                    <div class="row"><div class="col-md-12"><asp:Label ID="lblDivision" Text="Division:" runat="server" CssClass="label" /></div></div>
                    <div class="row"><div class="col-md-12"><asp:DropDownList ID="ddlDivision" AppendDataBoundItems="true" runat="server" CssClass="dropdown" TabIndex="4"/></div></div>
                    <div class="row"><div class="col-md-12"><asp:Label ID="lblPrimaryDept" Text="Primary Department Affiliation:" runat="server" CssClass="label" /></div></div>
                    <div class="row"><div class="col-md-12"><asp:DropDownList ID="ddlPrimaryDept" AppendDataBoundItems="true" runat="server" CssClass="dropdown" TabIndex="5"/></div></div>
                    <div class="row"><div class="col-md-12"><asp:Label ID="lblSecondaryDept" Text="Secondary Department Affiliation:" runat="server" CssClass="label" /></div></div>
                    <div class="row"><div class="col-md-12"><asp:DropDownList ID="ddlSecondaryDept" AppendDataBoundItems="true" runat="server" CssClass="dropdown" TabIndex="6"/></div></div>
                    <div class="button_row row">
                        <div class="col-md-12" style="text-align:center;">
                            <asp:Button ID="btnSearch" Text="Search" runat="server" OnClick="btnSearch_Click" CssClass="btn btn-default" TabIndex="6"/>
                            <asp:Button ID="btnClose" Text="Close" runat="server" OnClick="btnClose_Click" CssClass="btn btn-default" TabIndex="6"/>
                        </div>
                    </div>
                </div>
                <div class="row header_row" id="searchResults" runat="server" visible="false">
                    <div class="col-md-12">
                        <br />
                        <h3>Search Results:</h3>
                        <div class="instructions">
                            <asp:Label ID="lblSearchRecipientsForSOSSelectDirections" runat="server" Visible="false" CssClass="instructions"/> 
                        </div>
                        <asp:GridView ID="gvSearchResults" runat="server" DataKeyNames="arID" AutoGenerateColumns="False" CssClass="table" OnRowCommand="gvSearchResults_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                                <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                                <asp:BoundField DataField="DivisionName" HeaderText="Division" />
                                <asp:BoundField DataField="PrimaryDept" HeaderText="Primary Department" />
                                <asp:BoundField DataField="SecondaryDept" HeaderText="Secondary Department" />
                                <asp:BoundField DataField="EmailAddress" HeaderText="Email" />
                                <asp:BoundField DataField="Location" HeaderText="Location" />
                                <asp:BoundField DataField="PhoneNumber" HeaderText="Phone" />
                                <asp:ButtonField ButtonType="Button" Text="Select" CommandName="selectRecipient" ControlStyle-CssClass="btn-default btn" />
                            </Columns>
                        </asp:GridView>

                    </div>

                </div>
            </form>
        </div>
    </div>
</asp:Content>
