<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ItemForm.aspx.cs" Inherits="Presentation.ItemForm" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1>List All Items</h1>
        <h2>- all items in the database</h2>
    </hgroup>

    <article>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="425px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowEditButton="True" />
                <asp:BoundField DataField="name" HeaderText="Item name" SortExpression="name" >
                </asp:BoundField>
                <asp:BoundField DataField="firstMentionBook" HeaderText="Book where first mentioned" SortExpression="firstMentionBook" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="firstMentionChapter" HeaderText="Chapter where first mentioned" SortExpression="firstMentionChapter">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
        <br />
        <br />
        <br />
    
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAll" TypeName="Business.ItemMgr" DataObjectTypeName="DAL.Item" UpdateMethod="Update"></asp:ObjectDataSource>
        <br />
        <br />

    </article>

    <aside>
        <h3>Navigation</h3>
        <ul>
            <li><asp:HyperLink ID="mainHyperLink" runat="server" NavigateUrl="~/Main.aspx">Back To Main</asp:HyperLink></li>
            <li><asp:HyperLink ID="itemaddHyperLink" runat="server" NavigateUrl="~/ItemAddForm.aspx">Add An Item</asp:HyperLink></li>
        </ul>
    </aside>
</asp:Content>




