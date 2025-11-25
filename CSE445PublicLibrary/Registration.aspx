<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="CSE445PublicLibrary.Registration" %>

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
            <asp:Button ID="RegisterBtn" runat="server" Text="Register" OnClick="RgstrBtn_Click" />
            <br/>

            <asp:CheckBox ID="IsStaff" runat="server" Text="Check for staff, else regular member" OnCheckedChanged="IsStaff_CheckedChanged" /><br/>

            <asp:Label ID="ErrorLabel" runat="server" Text="Retry Register" Visible="false"></asp:Label><br/>

            <asp:Label ID="GoBack" runat="server" Text="Press the button to go back to the default page and login with your new account!" Visible="false"></asp:Label><br/>
            <asp:Button ID="DefaultBtn" runat="server" Text="Go back to default page" OnClick="ReturnBtn_Click" Width="151px"/>
        
        </div>
    </form>
</body>
</html>
