<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="TopicAdd.aspx.cs" Inherits="BBS.TopicAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div>
            主题<asp:TextBox ID="TextBoxTitle" runat="server" Width="311px"></asp:TextBox>
            <br />
            内容<asp:TextBox ID="TextBoxContent" runat="server" Width="311px" Height="263px" TextMode="MultiLine"></asp:TextBox>
            <br />
            <br />
        </div>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonOK" runat="server" OnClick="ButtonOK_Click" Text="确定" BackColor="#C0C0FF" BorderColor="#C0C0FF" />
        &nbsp;<asp:Button ID="ButtonBack" runat="server" OnClick="ButtonBack_Click" Text="返回" BackColor="#C0C0FF" BorderColor="#C0C0FF" />
</asp:Content>
