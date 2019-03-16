﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="GarageManagerWebsite.Page.Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../CSS/detailsPage.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 70%; margin:30px auto;">
        <tr>
            <td  style="width: 50%; min-height: 300px;">
                <asp:image runat="server" ID="imgProduct" CssClass="detailImg"></asp:image>
            </td>
            <td colspan="2">
                <hr />
            </td>
            <td>
                <table style="width: 100%;">
                    <tr>
                        <td colspan="2">
                            <h2><asp:label runat="server" ID="lblTitle"></asp:label></h2>
                        </td>
                    </tr>
                    <tr>
                        <td>Product ID:</td>
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
                <asp:label runat="server" ID="lblAvailable" CssClass="productAvailable">Available</asp:label>
                <br />
                <asp:button runat="server" text="Add" ID="btnAdd" CssClass="button"/>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:label runat="server" ID="lblDescription" CssClass="detailDescription"></asp:label>
            </td>
        </tr>
        <%--<tr>
            <td rowspan="4">
                <asp:image runat="server" ID="imgProduct" CssClass="detailImg"></asp:image>
            </td>
            <td>
                <h2>
                    <asp:label runat="server" ID="lblTitle"></asp:label>
                </h2>
                <hr />
            </td>
        </tr>
        <tr>
            <td>
                <asp:label runat="server" ID="lblDescription" CssClass="detailDescription"></asp:label>
            </td>
            <td>
                <asp:label runat="server" ID="lblPrice" CssClass="detailPrice"></asp:label>
                <br />
                Amount:&nbsp;<asp:dropdownlist runat="server" ID="ddlAmount"></asp:dropdownlist>
                <br />
                <asp:button runat="server" text="Add" ID="btnAdd" CssClass="button"/>
                <br />
                <asp:label runat="server" ID="lblResult"></asp:label>
            </td>
        </tr>
        <tr>
            <td>
                Product ID:&nbsp;<asp:label runat="server" ID="lblProductID"></asp:label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:label runat="server" ID="lblAvailable" CssClass="productAvailable">Available</asp:label>
            </td>
        </tr>--%>
    </table>
</asp:Content>
