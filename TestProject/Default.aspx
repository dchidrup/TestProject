<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TestProject.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    
    <asp:Label ID="lblErrorMessage" runat="server"></asp:Label>
    <br/>
    <label>Total : <label><asp:Label ID="lblTotal" runat="server" />
    <br/>
        <br/>
    <div>
        <asp:GridView ID="grdview" runat="server" AllowPaging="true" PageSize="100" OnPageIndexChanging="grdview_PageIndexChanging"></asp:GridView>
    </div>
    </form>
</body>
</html>
