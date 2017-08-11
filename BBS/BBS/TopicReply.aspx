<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="TopicReply.aspx.cs" Inherits="BBS.TopicReply" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 回复<br />
    标题*    <asp:TextBox ID="TextBoxTitle" runat="server"  Width="376px"></asp:TextBox>
    <br />
<br />
    内容* <asp:TextBox ID="TextBoxContent" runat="server" Height="222px" TextMode="MultiLine" Width="376px"></asp:TextBox>
<br />
<asp:Button ID="ButtonOK" runat="server" OnClick="ButtonOK_Click" Text="确定" />
<asp:Button ID="ButtonBack" runat="server" OnClick="ButtonBack_Click" Text="返回" />
<br />
</asp:Content>

