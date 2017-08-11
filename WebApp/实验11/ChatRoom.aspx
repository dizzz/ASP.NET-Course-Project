<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChatRoom.aspx.cs" Inherits="实验11.ChatRoom" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <style type="text/css">
        .newStyle1
        {
            position: absolute;
            z-index: auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
       <div enableviewstate="false" >
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
      <ContentTemplate>
        <asp:Panel ID="Panel1" runat="server" BorderStyle="Ridge" Height="458px" 
            Width="210px" ScrollBars="Auto" >
            【<span>欢迎</span>】<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <span 
                style="font-weight: bolder; font-size: medium; color: #ff6666; font-family: 隶书, Cursive; background-color: #ffffcc; text-align: left">进入聊天室<br />
            </span>【<span>在线人数为：</span><asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            】<br />
            <asp:ListBox OnClick="SelUser();" ID="ListBox1" runat="server"  BackColor="#FFFFC0" Font-Bold="True" 
                Font-Names="隶书" Font-Size="Large" ForeColor="Red" Height="414px" 
                Width="204px" EnableViewState="False"  ></asp:ListBox>
        </asp:Panel>
            <asp:Panel ID="Panel2" runat="server" BorderStyle="Ridge" 
            
          style="top: 15px; left: 229px; position: absolute; width: 520px; height: 265px; text-align: center;" >
              紫金聊天室欢迎您！<br />
                <br />
                <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Width="513px" 
                    BackColor="#FFFFC0" BorderColor="Fuchsia" 
                    BorderStyle="Outset" BorderWidth="1px" Font-Bold="True" Font-Names="隶书" 
                    ForeColor="Red" Height="225px" ToolTip="公聊显示框" Rows="40" Font-Size="Large" 
                    ReadOnly="True" EnableViewState="False"></asp:TextBox>
            </asp:Panel>
            <asp:Panel ID="Panel3" runat="server" BorderStyle="Ridge" 
                
            style="top: 288px; left: 229px; position: absolute; height: 185px; width: 520px">
                <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine" 
                    BackColor="#FFFFC0" BorderColor="Fuchsia" 
                    BorderStyle="Outset" BorderWidth="1px" Font-Bold="True" Font-Names="隶书" 
                    ForeColor="Red" ReadOnly="True" Rows="10" ToolTip="私聊显示框" 
                    Font-Size="Medium" Width="513px" EnableViewState="False" ></asp:TextBox>
            </asp:Panel>
          <asp:Timer ID="Timer1" runat="server" Interval="2000" ontick="Timer1_Tick">
          </asp:Timer>
        </ContentTemplate>
    </asp:UpdatePanel>    
   
    <asp:Panel ID="Panel4" runat="server" Height="70px" 
        style="top: 480px; left: 10px; position: absolute; width: 739px" 
        BorderStyle="Ridge" BackColor="#FFFF66">
        <br />
        <asp:CheckBox ID="CheckBox1" runat="server" Text="私聊" />
        &nbsp; 对<asp:TextBox ID="TextBox4" runat="server" Width="80px"></asp:TextBox>
        &nbsp; 说:
        <asp:TextBox ID="TextBox3" runat="server" Width="333px"></asp:TextBox>
        &nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" 
    OnClick="Button1_Click" Text="我要发言" />
        <asp:Button ID="Button2" runat="server" 
    OnClick="Button2_Click" Text="退出聊天室" />
    </asp:Panel>
    </div>
    </form>
</body>
</html>
