<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addDepartment.aspx.cs" Inherits="CD6.addDepartment" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Departments</title>
    <link href='http://fonts.googleapis.com/css?family=Droid+Sans' rel='stylesheet' type='text/css' />
    <link href='http://fonts.googleapis.com/css?family=Open+Sans+Condensed:300' rel='stylesheet' type='text/css' />
    <link href="css/fonts.css" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/master.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="row" id="content">
            </div>
            <div class="col-md-12">
                <div class="row header_row">
                    <div class="col-md-12" id="deptManageHeader" runat="server" visible="true">
                        <p>
                            <h1>Add Department</h1>
                            <div class="instructions">
                                <asp:Label ID="lblAddDepartmentDirections" runat="server" Visible="false" CssClass="instructions"/>
                            </div>
                        </p>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <asp:Label ID="lblDeptName" Text="Department ID:" runat="server" CssClass="label" />
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
                                <asp:Button ID="btnClose" Text="Close" runat="server" OnClientClick="window.close(); return false;" OnClick="btnClose_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
