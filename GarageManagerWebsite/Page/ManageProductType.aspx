<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ManageProductType.aspx.cs" Inherits="GarageManagerWebsite.Page.ManageProductType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Product Type Name:</p>
    <p>
        <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
         ErrorMessage="the name of new product type is required" ForeColor="Red" 
         ControlToValidate="TextBoxName" EnableViewState="False"></asp:RequiredFieldValidator>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
    </p>
    <p>
        <asp:Label ID="LabelResult" runat="server"></asp:Label>
    </p>
</asp:Content>
