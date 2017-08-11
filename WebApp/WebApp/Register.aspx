<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebApp.Register" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            *登录名:<asp:TextBox ID="TxtLoginName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvLoginName" runat="server" ControlToValidate="TxtLoginName" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
            <br />
            *用户名:<asp:TextBox ID="TxtName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="TxtName" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
            <br />
            *密码:<asp:TextBox ID="TxtAddress" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPass" runat="server" ControlToValidate="TxtPass" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
            <br />
            住址:<asp:TextBox ID="TxtHomePage" runat="server"></asp:TextBox>
            <br />
            个人主页:<asp:TextBox ID="TxtPass" runat="server"></asp:TextBox>
            <br />
            电子邮件:<asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="BtnReg" runat="server" OnClick="BtnReg_Click" Text="注册" />
            <asp:Button ID="BtnCancel" runat="server" OnClick="BtnCancel_Click" Text="取消" />
            <asp:Label ID="LblCaution" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
