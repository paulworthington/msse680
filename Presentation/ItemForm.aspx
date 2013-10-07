<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemForm.aspx.cs" Inherits="Presentation.ItemForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 267px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <table>
            <tr>
                <td>Name</td>
                <td><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Type</td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="ObjectDataSource2" DataTextField="ItemTypeID" DataValueField="ItemTypeID">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>First Book</td>
                <td>
                    <asp:DropDownList ID="DropDownList2" runat="server">
                        <asp:ListItem Value="0">Book 1</asp:ListItem>
                        <asp:ListItem Value="1">Book 2</asp:ListItem>
                        <asp:ListItem Value="2">Book 3</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>First Chapter</td>
                <td><asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></td>
            </tr>
        </table>
        <br />
        <asp:Button ID="Button1" runat="server" type="submit" Text="Add" OnClick="Button1_Click" />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1">
            <Columns>
                <asp:CommandField ShowEditButton="True" />
                <asp:BoundField DataField="ItemID" HeaderText="ItemID" SortExpression="ItemID" />
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                <asp:BoundField DataField="type" HeaderText="type" SortExpression="type" />
                <asp:BoundField DataField="firstMentionBook" HeaderText="firstMentionBook" SortExpression="firstMentionBook" />
                <asp:BoundField DataField="firstMentionChapter" HeaderText="firstMentionChapter" SortExpression="firstMentionChapter" />
                <asp:BoundField DataField="eventDate" HeaderText="eventDate" SortExpression="eventDate" />
                <asp:BoundField DataField="ItemDescID" HeaderText="ItemDescID" SortExpression="ItemDescID" />
                <asp:BoundField DataField="ItemInvID" HeaderText="ItemInvID" SortExpression="ItemInvID" />
            </Columns>
        </asp:GridView>
        <br />
        <br />
        <br />
    
    </div>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="DAL.Item" DeleteMethod="Delete" InsertMethod="Insert" SelectMethod="GetAll" TypeName="Business.ItemMgr" UpdateMethod="Update"></asp:ObjectDataSource>
        <br />
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetAll" TypeName="Business.ItemTypeMgr"></asp:ObjectDataSource>
&nbsp;</form>
</body>
</html>
