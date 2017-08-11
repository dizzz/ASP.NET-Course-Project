<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminLogin.aspx.cs" Inherits="WebApp.adminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-left: 40px">
            <p style="margin-left: 40px">
                管理员登录</p>
        </div>
        用户名:&nbsp;&nbsp; <asp:TextBox ID="TextBoxLoginName" runat="server"></asp:TextBox>
        <p>
            密码:&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password"></asp:TextBox>
        </p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonLogin" runat="server" OnClick="ButtonLogin_Click" Text="登录" BackColor="#C0C0FF" BorderColor="#8080FF" />
    </form>
</body>
</html>
