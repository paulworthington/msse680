<%@ Page Language="C#" MasterPageFile ="~/Site.Master" AutoEventWireup ="true" CodeBehind ="ItemAddForm.aspx.cs" Inherits ="Presentation.ItemForm" %>

<asp:Content runat ="server" ID ="BodyContent" ContentPlaceHolderID ="MainContent">
    <hgroup class ="title">
        <h1> Add New Item </h1>
        <h2> - add a new item to the database </h2>
    </hgroup>

    <article>
        <table>
            <tr>
                <td>Name</td>
                <td><asp:TextBox ID ="TextBox1" runat ="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Type of Item</td>
                <td>
                    <asp:DropDownList ID ="DropDownList1" runat ="server">
                        <asp:ListItem Value="1">Person</asp:ListItem>
                        <asp:ListItem Value="2">Place</asp:ListItem>
                        <asp:ListItem Value="3">Thing</asp:ListItem>
                        <asp:ListItem Value="4">Event</asp:ListItem>
                        <asp:ListItem Value="5">Essay</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Book where first mentioned</td>
                <td>
                    <asp:DropDownList ID ="DropDownList2" runat ="server">
                        <asp:ListItem Value ="1">Book 1</asp:ListItem>
                        <asp:ListItem Value ="2">Book 2</asp:ListItem>
                        <asp:ListItem Value ="3">Book 3</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Chapter where first mentioned</td>
                <td>
                    <asp:DropDownList ID ="DropDownList3" runat ="server">
                        <asp:ListItem Value ="1">1</asp:ListItem>
                        <asp:ListItem Value ="2">2</asp:ListItem>
                        <asp:ListItem Value ="3">3</asp:ListItem>
                        <asp:ListItem Value ="4">4</asp:ListItem>
                        <asp:ListItem Value ="5">5</asp:ListItem>
                        <asp:ListItem Value ="6">6</asp:ListItem>
                        <asp:ListItem Value ="7">7</asp:ListItem>
                        <asp:ListItem Value ="8">8</asp:ListItem>
                        <asp:ListItem Value ="9">9</asp:ListItem>
                        <asp:ListItem Value ="10">10</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <asp:Button ID ="Button1" runat ="server" type ="submit" Text ="Add" OnClick ="Button1_Click" />
        <br />
        <br />
        <br />
         <asp:ObjectDataSource ID ="ObjectDataSource2" runat ="server" SelectMethod ="GetAll"  TypeName ="Business.ItemTypeMgr"></asp:ObjectDataSource>
   
    </article>

    <aside>
        <h3>Navigation</h3>
        <ul>
            <li><asp:HyperLink ID ="mainHyperLink2" runat ="server" NavigateUrl ="~/Main.aspx">Back To Main </asp:HyperLink></li>
            <li><asp:HyperLink ID ="itemHyperLink" runat ="server" NavigateUrl ="~/ItemForm.aspx">List All Items </asp:HyperLink></li>
            <li><asp:HyperLink ID ="alphaHyperLink" runat ="server" NavigateUrl ="~/AlphaList.aspx">Browse Items Alphabetically </asp:HyperLink></li>
        </ul>
    </aside>
</asp:Content>
