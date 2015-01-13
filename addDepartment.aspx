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
            <div class="col-md-12">
                <div class="row header_row"><div class="col-md-12" id="deptManageHeader" runat="server" visible="true"><p><h1>Add Department</h1></p></div></div>
                <div class="row"><div class="col-md-12"><asp:Label ID="lblDeptName" Text="Department ID:" runat="server" CssClass="label" /></div></div>
                <div class="row"><div class="col-md-12"><asp:TextBox ID="txtDeptName" runat="server" CssClass="form-control" /></div></div>
                <div class="button_row row"><div class="col-md-12" style="text-align:center;"><asp:Button ID="btnAdd" Text="Add Department" runat="server" /></div></div>
                <div class="row" id="currentDepartments" runat="server" visible="true"><div class="col-md-12"><br /><h3>Current Departments:</h3>
                    <asp:GridView ID="gvDepartments" runat="server" AutoGenerateColumns="false" CssClass="table">
                        <Columns>
                            <asp:BoundField DataField="Department" HeaderText="ID" />
                            <asp:ButtonField Text="Delete" ButtonType="Button" ControlStyle-CssClass="btn-danger btn" />
                        </Columns>
                     </asp:GridView>
                    <div class="button_row row"><div class="col-md-12" style="text-align:center;"><asp:Button ID="btnClose" Text="Close" runat="server" OnClientClick="window.close(); return false;" /></div></div>
                </div></div>
            </div>
        </div>
    </form>
</body>
</html>
