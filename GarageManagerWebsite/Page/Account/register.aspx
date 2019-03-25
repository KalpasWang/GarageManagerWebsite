<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="GarageManagerWebsite.Page.Account.register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Literal ID="LiteralResult" runat="server"></asp:Literal>
    <br />
    <br />
    User Name:<br />
    <asp:TextBox ID="TextBoxName" runat="server" CssClass="inputs"></asp:TextBox>
    <br />
    <br />
    password:<br />
    <asp:TextBox ID="TextBoxPassword" runat="server" CssClass="inputs" TextMode="Password"></asp:TextBox>
    <br />
    <br />
    Confirm Password:<br />
    <asp:TextBox ID="TextBoxConfirm" runat="server" CssClass="inputs" TextMode="Password"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" CssClass="button" OnClick="Button1_Click" Text="Submit" />
    <br />
</asp:Content>
