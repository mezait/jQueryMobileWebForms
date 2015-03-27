// http://stackoverflow.com/questions/1038746/equivalent-of-string-format-in-jquery
String.prototype.format = function() {
    var s = this,
        i = arguments.length;

    while (i--) {
        s = s.replace(new RegExp('\\{' + i + '\\}', 'gm'), arguments[i]);
    }
    
    return s;
};

function getFormData($form) {
    // Get the ASP.NET form data excluding viewstate
    return $form
        .find('input,textarea,select')
        .not('#__VIEWSTATE,#__EVENTVALIDATION')
        .serialize();
}

function setCartTotal(qty, total) {
    $('.cart-summary').text('{0} Items, Total: {1}'.format(qty, total));
}

function updateCartHeader() {
    $.ajax({
        type: 'POST',
        url: '/cartfunctions.asmx/GetCart',
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            var json = $.parseJSON(result.d);

            setCartTotal(json.ItemCount, json.SubTotal);
        }
    });
}

(function ($) {
    $(document).on('pagecreate', '#default', function () {
        $('.add-to-cart').click(function () {
            var $this = $(this);

            $.ajax({
                type: 'POST',
                url: '/cartfunctions.asmx/AddToCart',
                contentType: 'application/json; charset=utf-8',
                data: ' { sku: "' + $this.data('sku') + '"}',
                dataType: 'json',
                success: function (result) {
                    var json = $.parseJSON(result.d);

                    setCartTotal(json.ItemCount, json.SubTotal);
                }
            });
        });
    });

    $(document).on('pagecreate', '#cart', function () {
        var $cart = $('div[data-am-role=cart]');

        $cart.on('click', '.remove-cart', function () {
            var data = $(this).data();

            // Remove an item from the cart
            $.ajax({
                type: 'POST',
                url: '/templates/cart.aspx',
                cache: false,
                data: { op: 'remove', sku: data.sku },
                success: function (result) {
                    $cart.html(result).trigger('create');

                    updateCartHeader();
                }
            });
        });

        $cart.on('click', '.update-cart', function () {
            var $form = $('form[data-am-role=cart]');

            $.ajax({
                type: 'POST',
                url: '/templates/cart.aspx',
                cache: false,
                data: getFormData($form),
                success: function (result) {
                    $cart.html(result).trigger('create');

                    updateCartHeader();
                }
            });
        });

        $cart.on('click', '.empty-cart', function () {
            $.ajax({
                type: 'POST',
                url: '/templates/cart.aspx',
                cache: false,
                data: { op: 'removeall' },
                success: function (result) {
                    $cart.html(result).trigger('create');

                    updateCartHeader();
                }
            });
        });
    });

    // Only use this as a last resort
    // $.mobile.ajaxEnabled = false;
})(jQuery);