<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="实验10.Register" %>

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
        用户名<asp:TextBox ID="txtUname" runat="server"></asp:TextBox>
        <br />
        密码<asp:TextBox ID="txtPwd" runat="server"></asp:TextBox>
        <br />
        email<asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <br />
        phone<asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
        <asp:Button ID="BtnReg" runat="server" OnClick="BtnReg_Click" Text="注册" />
        <asp:Button ID="BtnCancel" runat="server" Text="取消" OnClick="BtnCancel_Click"/>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
