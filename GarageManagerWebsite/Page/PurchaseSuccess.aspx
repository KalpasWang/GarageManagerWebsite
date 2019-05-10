<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PurchaseSuccess.aspx.cs" Inherits="GarageManagerWebsite.Page.PurchaseSuccess" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>Your purchase is successful, the total price is <asp:label runat="server" text="Label"></asp:label></p>
    <br />
    <br />
    <asp:button runat="server" text="Back to index page" CssClass="button" />
</asp:Content>
