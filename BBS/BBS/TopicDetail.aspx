<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="TopicDetail.aspx.cs" Inherits="BBS.TopicDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div>
        </div>
        【<asp:Label ID="LabelTitle" runat="server"></asp:Label>】
    发帖人 
        <asp:Label ID="LabelUserLoginName" runat="server"></asp:Label>|
        <asp:Label ID="LabelIP" runat="server"></asp:Label>|
        <asp:Label ID="LabelCreateTime" runat="server"></asp:Label><br />
        <asp:Label ID="LabelContent" runat="server"></asp:Label><br />
       
        <p>以下为本主题回复信息</p><br />
        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
             <ItemTemplate>
               【<%#Eval("Title") %>】  回复人 <%#Eval("UserLoginName")%>|<%#Eval("IP") %>|<%#Eval("CreateTime")%><br />
                <%#Eval("Content")%><br />

             </ItemTemplate>
        </asp:Repeater>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyBBS_DataConnectionString %>" SelectCommand="SELECT [TopicID], [UserLoginName], [Title], [Content], [CreateTime], [IP] FROM [Reply] WHERE ([TopicID] = @TopicID)">
            <SelectParameters>
                <asp:QueryStringParameter Name="TopicID" QueryStringField="topic_id" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <p>
            <asp:Button ID="Button1" runat="server" Text="回复" OnClick="Button1_Click" />
            <asp:Button ID="ButtomBack" runat="server" OnClick="ButtomBack_Click" style="height: 27px" Text="返回" />
        </p>
</asp:Content>
