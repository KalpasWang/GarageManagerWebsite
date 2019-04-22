<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="GarageManagerWebsite.Page.ShoppingCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:label runat="server" ID="LabelError" text="" ForeColor="Red"></asp:label>
    <asp:panel runat="server"></asp:panel>

    <table>
        <tr>
            <td>Price:</td>
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
        <tr>
            <td>
                <asp:button runat="server" ID="ButtonContinue" text="Continue Shopping" CssClass="button"/>
                <asp:button runat="server" ID="ButtonCheckOut" text="Check Out" CssClass="button"/>
            </td>
        </tr>
    </table>
</asp:Content>
