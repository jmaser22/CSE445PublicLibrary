<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CheckoutBook.ascx.cs" Inherits="CSE445PublicLibrary.CheckoutBook" %>

Inherits="Library.CheckoutBook" %>

<div>
    <h1>Library Web Application</h1>
    <h2>Checkout:</h2>
    <h3>Enter the title of the book you'd like to check out in the textbox below:</h3>
    <asp:TextBox ID="titleEntry" runat="server" Height="24px" Width="287px"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" Text="Checkout" OnClick="Button1_Click" />
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
</div>
