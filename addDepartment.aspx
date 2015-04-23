<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/master.Master" CodeBehind="addDepartment.aspx.cs" Inherits="CD6.addDepartment" %>
<%@ MasterType VirtualPath="~/master.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/recipient.css" rel="stylesheet" />
    <link href="css/secondary-nav.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
        </div><!--/.container-fluid -->
    </nav>
        <div class="row" id="content">
            </div>
            <div class="col-md-10 col-md-offset-1">
                <div class="row header_row">
                    <div class="col-md-12" id="deptManageHeader" runat="server" visible="true">
                            <h1>Add Department</h1>
                            <div class="instructions">
                                <asp:Label ID="lblAddDepartmentDirections" runat="server" Visible="false" CssClass="instructions"/>
                            </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <asp:Label ID="lblDeptName" Text="Department Name:" runat="server" CssClass="label" />
                        <asp:Label ID="lblError" runat="server" CssClass="label" style="color:red" Visible="false"/>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <asp:TextBox ID="txtDeptName" runat="server" CssClass="form-control" />
                    </div>
                </div>
                <div class="button_row row">
                    <div class="col-md-12" style="text-align:center;">
                        <asp:Button ID="btnAdd" Text="Add Department" runat="server" OnClick="btnAdd_Click" CssClass="btn btn-default" />
                    </div>
                </div>
                <div class="row" id="currentDepartments" runat="server" visible="true">
                    <div class="col-md-12">
                        <br />
                        <h3>Current Departments:</h3>
                        <asp:GridView ID="gvDepartments" runat="server" AutoGenerateColumns="False" CssClass="table" DataKeyNames="departmentID"  OnRowCommand="gvDepartments_RowCommand"  OnRowDeleting="gvDepartments_RowDeleting" >
                            <Columns>
                                <asp:BoundField DataField="DepartmentId" HeaderText="ID" />
                                <asp:BoundField DataField="Name" HeaderText="Name" />
                                <asp:ButtonField Text="Modify" ButtonType="Button" ControlStyle-CssClass="btn-danger btn" CommandName="Modify" />
                            </Columns>
                         </asp:GridView>
                        <div class="button_row row">
                            <div class="col-md-12" style="text-align:center;">
                                <asp:Button ID="btnClose" Text="Close" runat="server" OnClick="btnClose_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
</asp:Content>
