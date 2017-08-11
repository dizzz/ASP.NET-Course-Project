<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="TopicAdmin.aspx.cs" Inherits="WebApp.TopicAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div>
        </div>
        <asp:GridView ID="GV" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None" OnRowCommand="GV_RowCommand">
            <Columns>
                <asp:BoundField DataField="TopicID" HeaderText="编号" />
                <asp:BoundField DataField="UserLoginName" HeaderText="发帖者" />
                <asp:BoundField DataField="Title" HeaderText="主题" />
                <asp:BoundField DataField="CreateTime" HeaderText="发帖时间" />
                <asp:HyperLinkField DataNavigateUrlFields="TopicId" DataNavigateUrlFormatString="TopicDetail.aspx?topic_id={0}" HeaderText="详细信息" Text="详细信息" />
                <asp:ButtonField CommandName="Delete" Text="删除" />
            </Columns>
            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
            <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#594B9C" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#33276A" />
        </asp:GridView>
        <asp:Label ID="LabelPages" runat="server"></asp:Label>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/TopicAdd.aspx">发表新帖</asp:HyperLink>
</asp:Content>
