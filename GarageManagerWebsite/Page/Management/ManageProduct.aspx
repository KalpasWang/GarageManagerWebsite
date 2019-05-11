<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ManageProduct.aspx.cs" Inherits="GarageManagerWebsite.Page.ManageProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <p>
        Name:</p>
    <p>
        <asp:TextBox ID="TextBoxName" runat="server" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Name Is Required" 
            ControlToValidate="TextBoxName" ForeColor="Red"></asp:RequiredFieldValidator>
    </p>
    <p>
        Type:</p>
    <p>
        <asp:DropDownList ID="DropDownListProductType" runat="server" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="Id" >
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GarageDBConnectionString %>" SelectCommand="SELECT * FROM [ProductType]"></asp:SqlDataSource>
    </p>
    <p>
        Price:</p>
    <p>
        <asp:TextBox ID="TextBoxPrice" runat="server" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Price Is Required"
            ControlToValidate="TextBoxPrice" ForeColor="Red"></asp:RequiredFieldValidator>
    </p>
    <p>
        Image:</p>
    <p>
        <asp:DropDownList ID="DropDownListImage" runat="server" >
        </asp:DropDownList>
    </p>
    <p>
        Description:</p>
    <p>
        <asp:TextBox ID="TextBoxDescription" runat="server" Height="100px" TextMode="MultiLine" Width="330px" ></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click"/>
        &nbsp;
        <input type="reset" id="ResetForm" value="Reset"/>
    </p>
    <p>
        <asp:Label ID="LabelResult" runat="server" ForeColor="Red"></asp:Label>
    </p>

</asp:Content>
