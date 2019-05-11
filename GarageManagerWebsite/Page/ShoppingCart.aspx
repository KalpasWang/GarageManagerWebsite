<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="GarageManagerWebsite.Page.ShoppingCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../CSS/CartPage.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:label runat="server" ID="LabelError" text="" ForeColor="Red"></asp:label>
    <asp:panel runat="server" ID="PanelCart"></asp:panel>

    <table>
        <tr>
            <td style="width: 150px;">Price:</td>
            <td>
                <asp:literal ID="LiteralPrice" runat="server"></asp:literal>
            </td>
        </tr>
        <tr>
            <td>VAT:</td>
            <td>
                <asp:literal ID="LiteralVAT" runat="server"></asp:literal>
            </td>
        </tr>
        <tr>
            <td>Shipping:</td>
            <td>
                <asp:literal ID="LiteralShipping" runat="server"></asp:literal>
            </td>
        </tr>
        <tr>
            <td>Total Amount:</td>
            <td>
                <asp:literal ID="LiteralTotal" runat="server"></asp:literal>
            </td>
        </tr>
    </table>
    <br /><br />
    <div>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:button runat="server" ID="ButtonContinue" text="Continue Shopping" CssClass="button"/>
        <asp:button runat="server" ID="ButtonCheckOut" text="Check Out" CssClass="button" OnClick="ButtonCheckOut_Click"/>
    </div>
</asp:Content>
