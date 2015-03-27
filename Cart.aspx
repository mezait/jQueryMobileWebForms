<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs"
    Inherits="jQueryMobile.Cart" %>

<%@ Register Src="Controls/ShoppingCart.ascx" TagName="ShoppingCart" TagPrefix="uc1" %>
<asp:Content ID="page" ContentPlaceHolderID="page" runat="server">
    <div data-role="page" id="cart" data-dom-cache="false">
</asp:Content>
<asp:Content ID="main" ContentPlaceHolderID="main" runat="server">
    <div data-am-role="cart">
        <form id="Form1" runat="server" data-am-role="cart">
        <uc1:ShoppingCart ID="ctlShoppingCart" runat="server" />
        </form>
    </div>
</asp:Content>
