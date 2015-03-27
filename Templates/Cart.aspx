<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="jQueryMobile.Templates.Cart" %>

<%@ Register Src="../Controls/ShoppingCart.ascx" TagName="ShoppingCart" TagPrefix="uc1" %>
<form runat="server" data-am-role="cart">
<uc1:ShoppingCart ID="ctlShoppingCart" runat="server" />
</form>
