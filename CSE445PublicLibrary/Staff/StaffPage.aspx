<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaffPage.aspx.cs" Inherits="CSE445PublicLibrary.Staff.StaffPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <h1>Welcome to the Staff Page</h1>

        </div>

        <asp:Label ID="Label1" runat="server" Text="Add Books to the library"></asp:Label>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Title"></asp:Label>
        <asp:TextBox ID="TitleBox" runat="server"></asp:TextBox>
        </p>
        <asp:Label ID="Label3" runat="server" Text="Author"></asp:Label>
        <asp:TextBox ID="authorBox" runat="server"></asp:TextBox>
        <p>
            <asp:Button ID="addButton" runat="server" OnClick="addButton_Click" Text="Add" />
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Back to home" />
        </p>
    </form>
</body>
</html>
