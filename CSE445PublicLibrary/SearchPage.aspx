<%@ Page Language="C#" AutoEventWireup="true" Async="true" CodeBehind="SearchPage.aspx.cs" Inherits="CSE445PublicLibrary.SearchPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="CSE445 Library Search"></asp:Label>
        </div>
        <asp:Label ID="Label2" runat="server" Text="Enter a book title or Author Below"></asp:Label>
        <p>
            <asp:TextBox ID="KeywordBox" runat="server"></asp:TextBox>
            <asp:Button ID="SearchButton" runat="server" OnClick="SearchButton_Click" Text="Search" />
        </p>
        <asp:Label ID="Label3" runat="server" Text="Results"></asp:Label>
        <p>
            <asp:Label ID="Label4" runat="server"></asp:Label>
           
    </form>
</body>
</html>

