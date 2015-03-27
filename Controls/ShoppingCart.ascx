<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShoppingCart.ascx.cs"
    Inherits="jQueryMobile.Controls.ShoppingCart" %>
<asp:Repeater runat="server" ID="rptCartItems">
    <HeaderTemplate>
        <table data-role="table" data-mode="reflow" class="ui-responsive">
            <thead>
                <tr>
                    <th>
                        Qty
                    </th>
                    <th>
                        Product
                    </th>
                    <th>
                        Price
                    </th>
                    <th>
                        Total
                    </th>
                    <th>
                        &nbsp;
                    </th>
                </tr>
            </thead>
            <tbody>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td>
                <input name="sku" type="hidden" value='<%# Eval("Product.Sku") %>' />
                <input name="quantity" type="number" value='<%# Eval("Quantity") %>' maxlength="2" />
            </td>
            <td>
                <%# Eval("Product.Name") %>
            </td>
            <td>
                <%# Eval("Price", "{0:c}")%>
            </td>
            <td>
                <%# Eval("SubTotal", "{0:c}") %>
            </td>
            <td>
                <a href="#" class="remove-cart" data-sku='<%# Eval("Product.Sku") %>'>Remove</a>
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </tbody> </table>
    </FooterTemplate>
</asp:Repeater>
<a href="#" class="update-cart">Update</a> | <a href="#" class="empty-cart">Empty</a>