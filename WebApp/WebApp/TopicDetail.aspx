<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TopicDetail.aspx.cs" Inherits="WebApp.TopicDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        【<asp:Label ID="LabelTitle" runat="server"></asp:Label>
        】发帖人:<asp:Label ID="LabelIP" runat="server"></asp:Label>
        <asp:Label ID="LabelCreateTime" runat="server"></asp:Label>
        <asp:Label ID="LabelUserLoginName" runat="server"></asp:Label>
        <br />
        <asp:Label ID="LabelContent" runat="server"></asp:Label>
        <p>
            <asp:Button ID="Button1" runat="server" Text="回复" />
            <asp:Button ID="ButtomBack" runat="server" OnClick="ButtomBack_Click" style="height: 27px" Text="返回" />
        </p>
    </form>
</body>
</html>
