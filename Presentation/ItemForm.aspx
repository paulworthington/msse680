<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemForm.aspx.cs" Inherits="Presentation.ItemForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body {
            font-family: Arial;
        }
        #form1 {
            height: 267px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/ItemAddForm.aspx">Add An Item</asp:HyperLink>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Main.aspx">Back To Main</asp:HyperLink>
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1">
            <Columns>
                <asp:CommandField ShowEditButton="True" />
                <asp:BoundField DataField="ItemID" HeaderText="Item ID" SortExpression="ItemID" />
                <asp:BoundField DataField="name" HeaderText="Item name" SortExpression="name" />
                <asp:BoundField DataField="firstMentionBook" HeaderText="First book" SortExpression="firstMentionBook" />
                <asp:BoundField DataField="firstMentionChapter" HeaderText="First chapter" SortExpression="firstMentionChapter" />
                <asp:BoundField DataField="eventDate" HeaderText="eventDate" SortExpression="eventDate" />
                <asp:BoundField DataField="ItemDescID" HeaderText="ItemDescID" SortExpression="ItemDescID" />
            </Columns>
        </asp:GridView>
        <br />
        <br />
        <br />
    
    </div>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAll" TypeName="Business.ItemMgr" DataObjectTypeName="DAL.Item" DeleteMethod="Delete" UpdateMethod="Update"></asp:ObjectDataSource>
        <br />
        <br />

    </form>
</body>
</html>
