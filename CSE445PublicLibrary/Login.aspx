<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CSE445PublicLibrary.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="userLabel" runat="server" Text="Username: "></asp:Label>
            <asp:TextBox ID="usernameBox" runat="server" Width="149px"></asp:TextBox><br/>

            <asp:Label ID="passwordLabel" runat="server" Text="Password: "></asp:Label>
            <asp:TextBox ID="passwordBox" runat="server" Width="149px"></asp:TextBox><br/>
            <asp:Button ID="LoginBtn" runat="server" Text="Login" OnClick="LoginBtn_Click" />
            <br/>
            <asp:CheckBox ID="IsPersistent" runat="server" Text="Keep me signed in" OnCheckedChanged="IsPersistent_CheckedChanged" /><br/>
            <asp:Label ID="ErrorLabel" runat="server" Text="Retry Login" Visible="false"></asp:Label><br/>

            <asp:Button ID="BackBtn" runat="server" Text="Return" OnClick="BackBtn_Click" /><br/>

        </div>
    </form>
</body>
</html>