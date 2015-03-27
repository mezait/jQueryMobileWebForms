<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="jQueryMobile.Default" %>

<asp:Content ID="page" ContentPlaceHolderID="page" runat="server">
    <div data-role="page" id="default">
</asp:Content>
<asp:Content ID="main" ContentPlaceHolderID="main" runat="server">
    <asp:Repeater ID="rptProducts" runat="server">
        <HeaderTemplate>
            <ul data-role="listview" data-split-icon="action" data-split-theme="a" data-inset="true">
        </HeaderTemplate>
        <ItemTemplate>
            <li><a href="#">
                <h2>
                    <%# Eval("Name") %></h2>
                <p>
                    <%# Eval("Description") %>
                </p>
                <p>
                    <strong>
                        <%# Eval("Price", "{0:c}") %></strong>
                </p>
                <p>
                    <small>(<%# Eval("Sku") %>)</small>
                </p>
            </a><a href="#purchase" class="add-to-cart" data-sku='<%# Eval("Sku") %>'>Add to Cart</a>
            </li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
