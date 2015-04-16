<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sos_print.aspx.cs" Inherits="CD6.sos_print" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href='http://fonts.googleapis.com/css?family=Droid+Sans' rel='stylesheet' type='text/css' />
    <link href='http://fonts.googleapis.com/css?family=Open+Sans+Condensed:300' rel='stylesheet' type='text/css' />
    <link href="css/fonts.css" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/print.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
            <div class="col-xs-12" style="background-color:#600">
                <img src="img/CLA_logo.png" alt="College of Liberal Arts: Temple University" />
            </div>
        </div>
        <div class="row" style="background-color:lightgrey">
            <div class="col-xs-4">
                <h4>Information Technology</h4>
            </div>
            <div class="col-xs-4 col-xs-offset-4" style="text-align:right">
                <h4>http://www.temple.edu/clait/</h4>
            </div>
        </div>
        <div class="row">
            <div class="md-col-12" style="text-align:center">
                <h2>Delivered Equipment</h2>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-1">
                <h4>To:</h4>
            </div>
            <div class="col-xs-10 col-xs-offset-1">
                <asp:Label ID="lblRecipientName" runat="server" /><br />
                <asp:Label ID="lblRecipientDepartment" runat="server" /><br />
                <asp:Label ID="lblRecipientLocation" runat="server" /><br />
            </div>
        </div>
        <div class="row">
            <div class="col-xs-1">
                <h4>From:</h4>
            </div>
            <div class="col-xs-10 col-xs-offset-1">
                <asp:Label ID="lblAssignerName" runat="server" /><br />
                <asp:Label ID="lblAssignerDept" runat="server" Text="College of Liberal Arts" /><br />
                <asp:Label ID="lblAssignerDivision" runat="server" Text="Information Technology" /><br />
            </div>
        </div>
        <div class="row">
            <div class="col-xs-1">
                <h4>Date:</h4>
            </div>
            <div class="col-xs-10 col-xs-offset-1">
                <asp:Label ID="lblPrintDate" runat="server" /><br />
            </div>
        </div>
        <div class="row" id="divDue">
            <div class="col-xs-2">
                <h4>Date Due:</h4>
            </div>
            <div class="col-xs-9 col-xs-offset-1">
                <asp:Label ID="lblDueDate" runat="server" /><br />
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <div class="row">
                    <div class="col-xs-12">
                        <h4>Items Provided:</h4>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12">
                        <br />
                        <asp:GridView id="gvAssets" runat="server" CssClass="table" AutoGenerateColumns="false" DataKeyNames="Asset, CLATag" >
                            <Columns>
                                <asp:BoundField DataField="Asset" />
                                <asp:BoundField DataField="CLATag" />
                            </Columns>
                        </asp:GridView><br />
                    </div>
                </div>
            </div>
<%--            <div class="col-xs-4">
                <div class="row">
                    <div class="col-xs-12">
                        <h4>Term:</h4>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12">
                        ___ Permanent<br />
                        Note # 3 below.
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12">
                        ___ Temporary<br />
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12">
                        If temporary, scheduled return:<br />
                        <asp:Label ID="lblDueDate" runat="server" />
                    </div>
                </div>
            </div>--%>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <span class="h4">1.</span> I acknowledge that this equipment is property of Temple University and is subject to all College and University Policies.<br />
                <span class="h6">Reference: http://policies.temple.edu/, http://www.temple.edu/cla/policies/, and http://www.temple.edu/cs/policies/</span>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <span class="h4">2.</span>I acknowledge that it is College policy that non-portable equipment (including, but not limited to desktop computers, displays, and printers) can not to be removed from campus.<br />
                <span class="h6">Reference: http://www.temple.edu/cla/policies/</span>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <span class="h4">3.</span>I acknowledge that this equipment will be returned to CLA IT at the end of the loan term or at the end of the equipment’s lifespan, and that any loss or theft will be immediately reported to Police and CLA IT.
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <h4>Please read above and sign stating you understand the policies:</h4>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12" style="text-align:center">
                <h3>Recieved</h3>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-4 col-xs-offset-1" style="text-align:center">
                __________________________________<br />
                Please Sign and Print Name
            </div>
            <div class="col-xs-4 col-xs-offset-1" style="text-align:center">
                __________________________________<br />
                Date
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12" style="text-align:center">
                <h4>Please Return Signed Receipt College of Liberal Arts Information Technology<br />
                    AL-21 Anderson Hall | 215-204-3213 | http://www.temple.edu/clait/</h4>
            </div>
        </div>
    </form>
</body>
</html>
