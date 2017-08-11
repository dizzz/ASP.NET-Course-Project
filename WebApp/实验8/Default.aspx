<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="实验8.Default" %>

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
        <asp:TreeView ID="tvDir" runat="server" OnSelectedNodeChanged="tvDir_SelectedNodeChanged">
        </asp:TreeView>
        <asp:Button ID="btnCreateDir" runat="server" OnClick="btnCreateDir_Click" Text="新建" />
        <asp:Button ID="btnDeleteDir" runat="server" OnClick="btnDeleteDir_Click" Text="删除" />
        <br />
        
        <asp:PlaceHolder ID="phCreate" runat="server" Visible="False">
            <asp:Label ID="labCreate" runat="server">请输入要创建的文件夹名称:</asp:Label><br />
            <asp:TextBox ID="txtCreate" runat="server"></asp:TextBox>
            <asp:Button ID="btnCreateOk" runat="server" OnClick="btnCreateOk_Click" Text="确认" />
            <asp:Button ID="btnCreateCancel" runat="server" OnClick="btnCreateCancel_Click" Text="取消" />
        </asp:PlaceHolder>
        <br />
        <br />
        <br />

        <asp:GridView ID="gridFileList" runat="server" AutoGenerateColumns="False" DataKeyNames="FullName" OnSelectedIndexChanged="gridFileList_SelectedIndexChanged">
            <Columns>
                <asp:ButtonField CommandName="Select" DataTextField="Name" HeaderText="名称" Text="按钮" />
                <asp:BoundField DataField="Length" HeaderText="大小" />
                <asp:BoundField DataField="LastWriteTime" HeaderText="修改时间" />
            </Columns>
        </asp:GridView>
        文件名<asp:TextBox ID="txtNewFileName" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="保  存" />
        <asp:Button ID="btnDeleteFile" runat="server" OnClick="btnDeleteFile_Click" Text="删 除" />
        <asp:TextBox ID="txtFile" runat="server" TextMode="MultiLine"></asp:TextBox>

    </form>
</body>
</html>
