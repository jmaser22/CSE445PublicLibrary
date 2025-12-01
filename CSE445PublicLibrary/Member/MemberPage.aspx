<%@ Page Language="C#" AutoEventWireup="true" Async="true" CodeBehind="MemberPage.aspx.cs" Inherits="CSE445PublicLibrary.Member.MemberPage" %>

<%@ Register Src="~/Member/CheckoutBook.ascx" TagPrefix="uc" TagName="CheckoutBook" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Welcome to the Member Page!</h1>
        </div>
        <p>
            <uc:CheckoutBook ID="CheckoutBook1" runat="server"/>
        </p>
    </form>
</body>
</html>

