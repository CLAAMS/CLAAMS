<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="sos.aspx.cs" Inherits="CD6.sos" %>
<%@ MasterType VirtualPath="~/master.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/sos.css" rel="stylesheet" />
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
                    <li><asp:LinkButton runat="server" Text="Search" OnClick="btnNewSearch_Click"/></li>
                    <li><asp:LinkButton runat="server" Text="Create" OnClick="Page_Load"/></li>
                    <li><asp:LinkButton runat="server" Text="Track" OnClick="btnTrack_Click"/></li>
                </ul>
            </div><!--/.nav-collapse -->
        </div><!--/.container-fluid -->
    </nav>

    <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <form role="form">
                <div class="row" id="sos_form" runat="server" visible="false">
                    <div class="row header_row"><div class="col-md-12" id="searchHeader" runat="server" visible="true"><h1>Search Sign Sheets</h1></div></div>
                    <div class="row header_row"><div class="col-md-12" id="createHeader" runat="server" visible="true"><h1>Create Sign Sheet</h1></div></div>
                    <div class="row header_row"><div class="col-md-12" id="modifyHeader" runat="server" visible="true"><h1>Modify Sign Sheet</h1></div></div>
                    <div class="col-md-6">
                        <asp:Label ID="lblRecipient" Text="Recipient: *" runat="server" CssClass="label" />
                        <div id="recipientCreate" runat="server">
                            <asp:DropDownList ID="ddlRecipient" runat="server" CssClass="dropdown">
                                
                            </asp:DropDownList><br />
                        </div>
                        
                        <asp:Label ID="lblAssigner" Text="From: *" runat="server" CssClass="label" />
                        <asp:DropDownList ID="ddlAssigner" runat="server" CssClass="dropdown">
                            
                        </asp:DropDownList><br />
                        <asp:Label ID="lblTerm" Text="Term: *" runat="server" CssClass="label" />
                        <asp:DropDownList ID="ddlTerm" runat="server" CssClass="dropdown" OnSelectedIndexChanged="ddlTerm_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="true">
                            
                            <asp:ListItem Value="1" Text="Permanent" />
                            <asp:ListItem Value="2" Text="Non-Permanent" />
                        </asp:DropDownList><br />
                        <div class="row" id="uploadSheet" runat="server" visible="true">
                            <div class="col-md-12">
                                <asp:Label ID="lblSOSUpload" Text="Upload Sign Sheet:" runat="server" CssClass="label"/>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="input-group">
                                            <span class="input-group-btn">
                                                <span class="btn btn-primary btn-file">Browse<asp:FileUpload runat="server" ID="upSOS" /></span>
                                            </span>
                                            <input type="text" class="form-control" readonly />
                                        </div>
                                    </div>
                                </div>
                                <div class="row"><div class="col-md-12 button_row" style="text-align:center;"><asp:Button ID="btnUpload" Text="Upload" runat="server" OnClientClick="uploadSoS()" /></div></div>
                                <div class="row">
                                    <div class="col-md-4" style="text-align:center;"><a onclick="viewSheet()">View Signature</a></div>
                                    <div class="col-md-4" style="text-align:center;"><a onclick="downloadSheet()">Download Sign Sheet</a></div>
                                    <div class="col-md-4" style="text-align:center;"><a onclick="emailSheet()">Email Sign Sheet</a></div>
                                </div>
                                <div class="row"><div class="col-md-12">
                                    <asp:Label Text="History:" runat="server" CssClass="label" />
                                    <asp:DropDownList runat="server" ID="ddlSOSHistory" CssClass="dropdown">
                                        <asp:ListItem Text="10/28/2014 09:08 AM" />
                                        <asp:ListItem Text="10/30/2014 01:32 PM" />
                                        <asp:ListItem Text="10/30/2014 02:12 PM" />
                                    </asp:DropDownList>
                                </div></div> 
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <asp:Label ID="lblAssets" Text="Assets: *" runat="server" CssClass="label" />
                        <div id="AssetListBox" runat="server" Visible="false">
                            <asp:ListBox ID="lstbxAssets" runat="server" CssClass="list-group" style="width:100%;" />
                            <div class="row">
                                <div class="col-xs-6" style="text-align:left;"><asp:Button ID="btnRemoveAsset" Text="Remove Asset" runat="server" CssClass="btn btn-default" OnClick="btnRemoveAsset_Click" /></div>
                                <div class="col-xs-6" style="text-align:right;"><asp:Button ID="btnAddAsset" runat="server"  text="Add Asset" CssClass="btn btn-default" OnClick="btnAddAsset_Click" /></div>
                            </div>
                       </div> 
                        <asp:TextBox ID="txtSearchAsset" runat="server" CssClass="form-control" />
                        <div class="row">
                            <div class="col-xs-3 calendar">
                                <br />
                                <asp:Label ID="lblDate" Text="Issue Date: *" runat="server" CssClass="label" />
                                <asp:Calendar ID="calIssueDate" runat="server" />
                            </div>
                            <div class="col-xs-3 col-xs-offset-3 calendar" id="dueCal" runat="server" visible="true">
                                <br />
                                <asp:Label ID="lblDueDate" Text="Due Date: *" runat="server" CssClass="label" />
                                <asp:Calendar ID="calDueDate" runat="server"/>
                            </div>
                        </div>
                    </div>
                    <div class="row"><div class="col-md-12 button_row" id="button_submit" style="text-align:center;" runat="server" visible="true"><asp:Button ID="btnSubmit" Text="Submit" runat="server" CssClass="btn btn-default" OnClick="btnSubmit_Click" /></div></div>
                    <div class="row"><div class="col-md-12 button_row" id="button_search" style="text-align:center;" runat="server" visible="true"><asp:Button ID="btnSearch" Text="Search" runat="server" CssClass="btn btn-default" OnClick="btnSearch_Click" /></div></div>
                </div>
                <div class="row" id="search_results" runat="server" visible="true">
                    <div class="row header_row"><div class="col-md-12" id="trackingHeader" runat="server" visible="true"><h1>Sign Sheet Tracking</h1></div></div>
                    <div class="row header_row"><div class="col-md-12" id="searchResultsHeader" runat="server" visible="true"><h1>Sign Sheet Search Results</h1></div></div>
                    <div class="col-md-12">
                        <asp:GridView ID="gvSearchResults" runat="server" CssClass="table" AutoGenerateColumns="False" DataKeyNames="sosID" OnRowCommand="gvSearchResults_Click"  OnRowDeleting="gvSearchResults_RowDeleting" >
                            <Columns>
                                <asp:BoundField DataField="sosID" HeaderText="SoS ID" />
                                <asp:BoundField DataField="claID" HeaderText="Assigner" />
                                <asp:BoundField DataField="arID" HeaderText="Recipient" />
                                <asp:BoundField DataField="DateCreated" HeaderText="Date Created" />
                                <asp:BoundField DataField="DateDue" HeaderText="Date Due" />
                                <asp:BoundField DataField="Status" HeaderText="Status" />
                                <asp:ButtonField ButtonType="Button" Text="View/Edit" CommandName="modify" ControlStyle-CssClass="btn-default btn" />
                                <asp:ButtonField ButtonType="Button" Text="Archive" CommandName="Delete" ControlStyle-CssClass="btn-danger btn"/>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div class="row" id="searchButtons" runat="server" visible="true">
                        <div class="row"><div class="col-md-12 button_row" style="text-align:center;"><asp:Button ID="btnExport" Text="Export Results" runat="server" CssClass="btn btn-default" /></div></div>
                        <div class="row"><div class="col-md-12 button_row" style="text-align:center;"><asp:Button ID="btnNewSearch" Text="New Search" runat="server" OnClick="btnNewSearch_Click" CssClass="btn btn-default" /></div></div>
                    </div>
                </div> 
            </form>
        </div>
    </div>
</asp:Content>
