<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BBS.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div>
            *登录名&nbsp; <asp:TextBox ID="TxtName" runat="server" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtName" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
            <br />
            *密码&nbsp;&nbsp; <asp:TextBox ID="TxtPass" runat="server" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtPass" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
        </div>
        <asp:Button ID="BtnLogin" runat="server" OnClick="BtnLogin_Click" Text="登录" />
        <asp:Label ID="LblCaution" runat="server"></asp:Label>
</asp:Content>
