<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemForm.aspx.cs" Inherits="Presentation.ItemForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 145px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="DAL.Item" DeleteMethod="Delete" InsertMethod="Insert" SelectMethod="GetAll" TypeName="Business.ItemMgr" UpdateMethod="Update"></asp:ObjectDataSource>
    </form>
</body>
</html>
