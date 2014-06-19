<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WcfStevenClient.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/generic.css" rel="stylesheet" />
    <script src="Scripts/jquery-2.1.1.min.js"></script>
    <script src="Scripts/generic.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="btn-toolbar" role="toolbar">
            <asp:Button ID="btnGetXML" runat="server" Text="Get XML to Table" class="btn btn-custom" OnClick="btnGetXML_Click" />
            <asp:Button ID="btnGV" runat="server" Text="Get XML to GridView" class="btn btn-custom" OnClick="btnGV_Click" />
            <asp:Button ID="btXml" runat="server" Text="XML datasource" class="btn btn-custom" />
            <asp:Button ID="Button4" runat="server" Text="Get ST" class="btn btn-custom" />
            <asp:Button ID="Button5" runat="server" Text="Set XML" class="btn btn-custom" />
            <asp:Button ID="btAge" runat="server" Text="Set Age" class="btn btn-custom" />
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"></asp:ObjectDataSource>
            <br />
            <asp:XmlDataSource ID="XmlDs" runat="server"></asp:XmlDataSource>

        </div>
        <asp:GridView ID="GridViewEm" runat="server"></asp:GridView>
        <asp:Table ID="xmlTable" runat="server"></asp:Table>
        <div id="divResult"></div>
    </form>
    <div class="panel-body">
        <div id="c_VehicleStatusFull">
        </div>
        <div class="overlay" style="display: none">
        </div>
    </div>
</body>
</html>
