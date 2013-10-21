<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Presentation.Main" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h2>Welcome to the Reader's Companion</h2>
            </hgroup>
            <p>
                 The Reader’s Companion serves as a guide to the works of an author, whether that’s one novel or a series of related novels. It’s a sort of encyclopedia that readers can use to gain a deeper understanding of a body of work.
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>Action Menu</h3>
    <ol class="round">
        <li class="one">
            <h5><asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/ItemForm.aspx">List All Items</asp:HyperLink></h5>
        </li>
        <li class="two">
            <h5><asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/AlphaList.aspx">Browse All Items Alphabetically</asp:HyperLink></h5>
        </li>
    </ol>
</asp:Content>