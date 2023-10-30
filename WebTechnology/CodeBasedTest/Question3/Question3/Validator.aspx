<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Validator.aspx.cs" Inherits="Question3.Validator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       

        <div>
            <h3>Insert your Details</h3>
            <br />
            <label for="txtName">Name:</label>
            <asp:TextBox ID="txtName" runat="server" placeholder="Name"></asp:TextBox><br />
            <br />
            <label for="txtFamilyName">Family Name:</label>
            <asp:TextBox ID="txtFamilyName" runat="server" placeholder="Family Name"></asp:TextBox><br />  
            <br />
            <label for="txtAddress">Address:</label>
            <asp:TextBox ID="txtAddress" runat="server" placeholder="Address"></asp:TextBox><br />  
            <br />
            <label for="txtCity">City:</label>
            <asp:TextBox ID="txtCity" runat="server" placeholder="City"></asp:TextBox><br />   
            <br />
            <label for="txtZipCode">Zip Code:</label>
            <asp:TextBox ID="txtZipCode" runat="server" placeholder="Zip Code"></asp:TextBox><br /> 
            <br />
            <label for="txtPhone">Phone:</label>
            <asp:TextBox ID="txtPhone" runat="server" placeholder="Phone"></asp:TextBox><br />  
            <br />
            <label for="txtEmail">E-mail:</label>
            <asp:TextBox ID="txtEmail" runat="server" placeholder="Email" ></asp:TextBox><br /> 
            <br />
            <asp:Button ID="Button1" runat="server" Text="Check" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
