<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="sosTemplate.aspx.cs" Inherits="CD6.sosTemplate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="content" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row main_content">
        <div class="col-md-8 col-md-offset-2">
            <div class="row header_row"><div class="col-md-12" id="sosCopyHeader" runat="server" visible="true"><p><h1>Edit Sign Sheet</h1></p></div></div>
            <asp:Label ID="lblSOSCopy" Text="Sign Sheet Body:" runat="server" CssClass="label" />
            <asp:TextBox ID="txtSOSCopy" runat="server" TextMode="MultiLine" Rows="20" Columns="100" CssClass="form-control" ValidateRequestMode="Disabled"/>
            <div class="row"><div class="col-md-12 button_row" style="text-align:center;"><asp:Button ID="btnSubmit" Text="Submit" runat="server" CssClass="btn btn-default" OnClientClick="saveChanges()" OnClick="btnSubmit_Click" /></div></div>
        </div>
    </div>
</asp:Content>
