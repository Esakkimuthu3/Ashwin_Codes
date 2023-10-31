<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Assignment_1.Default" %>
 
<!DOCTYPE html>
 
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title></title>
</head>
<body>
<form id="form1" runat="server">
<div>
<h2>Select an item:</h2>
<asp:DropDownList ID="ddlItems" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlItems_SelectedIndexChanged">
</asp:DropDownList>
<br />
<br />
<asp:Image ID="imgItem" runat="server" width="700" />
<br />
<br />
<asp:Label ID="lblCost" runat="server"></asp:Label>
<br />
<asp:Button ID="btnShowCost" runat="server" Text="Show Cost" OnClick="btnShowCost_Click" />
</div>
</form>
</body>
</html>