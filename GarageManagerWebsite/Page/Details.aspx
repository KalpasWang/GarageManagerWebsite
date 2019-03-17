<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="GarageManagerWebsite.Page.Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../CSS/detailsPage.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 70%; margin:30px auto;">
        <tr>
            <td  style="width: 50%; min-height: 300px;">
                <asp:image runat="server" ID="imgProduct" CssClass="detailImg"></asp:image>
            </td>

            <td>
                <h1><asp:label runat="server" ID="lblTitle"></asp:label></h1>
                <br /><br />
                <table style="width: 100%; background-color: lightgray; border-radius: 5px; padding: 10px;">
                    <tr>
                        <td style="width: 40%">Product ID:</td>
                        <td><asp:label runat="server" ID="lblProductID"></asp:label></td>
                    </tr>
                    <tr>
                        <td>Price:</td>
                        <td><asp:label runat="server" ID="lblPrice" CssClass="detailPrice"></asp:label></td>
                    </tr>
                    <tr>
                        <td>Amount:</td>
                        <td><asp:dropdownlist runat="server" ID="ddlAmount"></asp:dropdownlist></td>
                    </tr>
                </table>
                <br /><br />
                <asp:label runat="server" ID="lblAvailable" CssClass="productAvailable">Available!</asp:label>
                <br /><br />
                <asp:button runat="server" text="Add to cart" ID="btnAdd" CssClass="button"/>
            </td>
        </tr>
        <tr>
            <td colspan="2"><hr /></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:label runat="server" ID="lblDescription" CssClass="detailDescription"></asp:label>
            </td>
        </tr>
    </table>
</asp:Content>
