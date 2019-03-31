<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="GarageManagerWebsite.Page.Account.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="LabelResult" runat="server" ForeColor="Red"></asp:Label>
    <br />
    <br />
    User Name:<br />
    <asp:TextBox ID="TextBoxName" runat="server" CssClass="inputs"></asp:TextBox>
    <br />
    <br />
    Password:<br />
    <asp:TextBox ID="TextBoxPassword" runat="server" CssClass="inputs"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" CssClass="button" OnClick="Button1_Click" Text="Submit" />
</asp:Content>
