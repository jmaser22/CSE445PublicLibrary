<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CSE445PublicLibrary._Default" %>

<%@ Register TagPrefix = "lib" TagName="dueback" src="~/DueBack.ascx" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="CSE445 Library Main Page"></asp:Label>
        </div>
        <p>
            <asp:Label ID="Label3" runat="server" Text="Inventory Search"></asp:Label>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Go!" />
        </p>
        <p>
            <asp:Label ID="Label4" runat="server" Text="Member sign in"></asp:Label>
            <asp:Button ID="Button2" runat="server" Text="Go!" OnClick="Button2_Click" />
        </p>
        <p>
            <asp:Label ID="Label5" runat="server" Text="Staff Maintenance"></asp:Label>
            <asp:Button ID="Button3" runat="server" Text="Go!" OnClick="Button3_Click" />
         </p>
        <p>
            <asp:Button ID="Button4" runat="server" Text="Login" OnClick="Button4_Click" />
            <asp:Button ID="Button5" runat="server" Text="Register" OnClick="Button5_Click" />
        </p>
        <p>
            <lib:dueback ID="DueBack2" runat = "server" />
           
    </form>
</body>
</html>
