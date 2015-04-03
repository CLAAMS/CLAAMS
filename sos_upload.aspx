<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="sos_upload.aspx.cs" Inherits="CD6.sos_upload" %>
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
                    <li><a href="sos_create.aspx">Create Sign Sheet</a></li>
                    <li><a href="sos_search.aspx">Search Sign Sheets</a></li>
                </ul>
            </div><!--/.nav-collapse -->
        </div><!--/.container-fluid -->
    </nav>
    <div class="modal fade" id="imageModal" tabindex="-1" role="dialog" aria-labelledby="imageModal" aria-hidden="true">
        <div class="modal-dialog" style="min-width:800px">
            <div class="modal-content" style="text-align:center;">
                <div class="modal-header">
                    <!--<button type="button" class="close" data-dismiss="modal" aria-hidden="true"/>-->
                    <h4 class="modal-title" id="myModalLabel"><asp:Label ID="lblModal_header" runat="server" /></h4>
                </div>
                <div class="modal-body">
                    <asp:Literal ID="literalImage" runat="server"/><br />
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <div class="row main_content">
        <div class="col-md-8 col-md-offset-2" >
            <form role="form">
                <div class="row" id="sos_form" runat="server">
                    <div class="row header_row">
                        <div class="col-md-12" id="header" runat="server">
                            <h1>Upload Sign Sheet</h1>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <asp:Label ID="lblRecipient" text="Recipient:" runat="server" CssClass="label" />
                            <asp:TextBox ID="txtRecipient" runat="server" CssClass="form-control" ReadOnly="true" />
                            <asp:Label ID="lblAssigner" Text="From:" runat="server" CssClass="label" />
                            <asp:TextBox ID="txtAssigner" runat="server" CssClass="form-control" ReadOnly="true" />
                            <asp:Label ID="lblTerm" Text="Term:" runat="server" CssClass="label" />
                            <asp:TextBox ID="txtTerm" runat="server" CssClass="form-control" ReadOnly="true" />
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:Label ID="lblSOSUpload" Text="Upload Sign Sheet:" runat="server" CssClass="label"/>
                                    <asp:FileUpload ID="fuSignSheet" runat="server" Width="100%" Height="30px"/>
                                </div>
                                <div class="col-md-2 col-md-offset-5" style="margin-top:5px;">
                                    <asp:Button ID="btnUpload" Text="Upload" runat="server" OnClick="btnUpload_Click" CssClass="btn btn-file" />
                                </div>
                            </div>
                            <div class="row" style="text-align:center;" id="signatureFunctions" runat="server">
                                <div class="col-md-6">
                                    <asp:LinkButton ID="linkShowSoS" Text="Show Signature" runat="server" OnClick="linkShowSoS_Click"/>
                                </div>
                                <div class="col-md-6">
                                    <asp:LinkButton ID="linkSendSignature" Text="Email Signature" runat="server" OnClick="linkSendSignature_Click" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:Label ID="lblAssets" Text="Assets:" runat="server" CssClass="label" />
                                    <asp:ListBox ID="lbAssets" CssClass="list-group" runat="server" style="width:100%;" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 calendar">
                                    <asp:label ID="lblIssueDate" Text="Issue Date:" runat="server" CssClass="label" />
                                    <asp:Calendar ID="calIssueDate" runat="server" Enabled="false"/>
                                </div>
                                <div class="col-md-6 calendar" id="calDue" runat="server" visible="false">
                                    <asp:Label ID="lblDueDate" Text="Due Date: *" runat="server" CssClass="label" />
                                    <asp:Calendar ID="calDueDate" runat="server" Enabled="false" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2 col-md-offset-5 button_row">
                            <asp:Button ID="btnClose" Text="Close" runat="server" OnClick="btnClose_Click" CssClass="btn btn-default" />
                        </div>
                    </div>
                </div>
            </form>
        </div>
    </div>
</asp:Content>
