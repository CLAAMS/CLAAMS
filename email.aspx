<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="email.aspx.cs" Inherits="CD6.email" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="content" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row main_content">
        <div class="col-md-8 col-md-offset-2">
            <div class="row header_row"><div class="col-md-12" id="emailHeader" runat="server" visible="true"><p><h1>Edit Email</h1></p></div></div>
            <asp:Label ID="lblEmail" Text="Email Body:" runat="server" CssClass="label" />
            <asp:TextBox ID="txtEmail" runat="server" TextMode="MultiLine" Rows="20" Columns="100" CssClass="form-control"/>
            <div class="row"><div class="col-md-12 button_row" style="text-align:center;"><asp:Button ID="btnSubmit" Text="Submit" runat="server" CssClass="btn btn-default" OnClientClick="saveChanges()"  /></div></div>
        </div>
    </div>
</asp:Content>