<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TopicAdd.aspx.cs" Inherits="WebApp.TopicAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            主题<asp:TextBox ID="TextBoxTitle" runat="server"></asp:TextBox>
            <br />
            内容<asp:TextBox ID="TextBoxContent" runat="server" Height="229px" Width="311px"></asp:TextBox>
            <br />
        </div>
        <asp:Button ID="ButtonOK" runat="server" OnClick="ButtonOK_Click" Text="确定" />
        <asp:Button ID="ButtonBack" runat="server" OnClick="ButtonBack_Click" Text="返回" />
    </form>
</body>
</html>
