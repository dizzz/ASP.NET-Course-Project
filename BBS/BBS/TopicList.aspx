<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="TopicList.aspx.cs" Inherits="BBS.TopicList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div>
        </div>
        <asp:GridView ID="GV" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnRowCommand="GV_RowCommand">
            <Columns>
                <asp:BoundField DataField="TopicID" HeaderText="编号" />
                <asp:BoundField DataField="UserLoginName" HeaderText="发帖者" />
                <asp:BoundField DataField="Title" HeaderText="主题" />
                <asp:BoundField DataField="CreateTime" HeaderText="发帖时间" />
                <asp:HyperLinkField DataNavigateUrlFields="TopicId" DataNavigateUrlFormatString="TopicDetail.aspx?topic_id={0}" HeaderText="详细信息" Text="详细信息" />
                <asp:ButtonField CommandName="Delete" Text="删除" />
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
        <asp:Label ID="LabelPages" runat="server"></asp:Label>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/TopicAdd.aspx">发表新帖</asp:HyperLink>
</asp:Content>
