<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemAddForm.aspx.cs" Inherits="Presentation.ItemForm" %>

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
    <form id="form2" runat="server">
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
        <br />
        <br />
    
    </div>
        <br />
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetAll" TypeName="Business.ItemTypeMgr"></asp:ObjectDataSource>
&nbsp;<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/ItemForm.aspx">List All Items</asp:HyperLink>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Main.aspx">Back To Main</asp:HyperLink>
    </form>
</body>
</html>
