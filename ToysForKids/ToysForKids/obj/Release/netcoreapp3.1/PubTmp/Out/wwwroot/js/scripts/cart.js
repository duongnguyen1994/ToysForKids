// Cart

var cart = cart || {};

cart.showCount = function () {
    $.ajax({
        url: '/Cart/CartCount',
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json',
        success: function (result) {
            $('#count').html(result);
        }
    })
}

$(".addcart").click( async function (event) {
    var productid = parseInt($(this).attr('data-productid'));
    await $.ajax({
        url: `/Cart/AddToCart/${productid}`,
        method: 'GET',
        contentType: 'application/json',
        success: function () {           
            bootbox.alert({
                message: "This product has been added to your cart",
                callback: function () {
                    cart.showCount();
                }
            })
        },
        error: function () {
            bootbox.alert("Cant add anymore!");
        }
    });
});

$(".removeproduct").click(function (event) {
    event.preventDefault();
    var productid = $(this).attr("data-productid");
    $.ajax({
        type: "GET",
        url: `/removecart/${productid}`,
        success: function () {
            //cart.showCart();
            location.reload();
        },
        error: function () {
            bootbox.alert("Something wrong! Please try again!")
        }
    })
})

$(".updatecartitem").click(function (event) {
    event.preventDefault();
    var productid = $(this).attr("data-productid");
    var quantity = $(".quantity-" + productid).val();
    $.ajax({
        type: "POST",
        url: `/updatecart/${productid}/${quantity}`,
        data: {
            productid: productid,
            quantity: quantity
        },
        success: function () {
            bootbox.alert({
                message: "Update Successed!",
                callback: function () {
                    //cart.showCart();
                    location.reload();
                }
            })
        },
        error: function () {
            bootbox.alert("Update failed!");
        }
    });
});

cart.showCart = function () {
    $.ajax({
        url: "/Cart/GetCart",
        method: "GET",
        contentType: 'application/json',
        success: function (data) {
            $('.tbody').empty();
            $('#tfoot').empty();
            var totalCount = 0;
            var count = 0;
            for (let item of data) {
                var cost = item.quantity * item.product.unitPrice;
                var quantityofproduct = parseInt(item.quantity)
                totalCount += cost;
                count++;
                $(".tbody").html(`
                        <tr>
                            <td>${count}</td>
                            <td>${item.product.productName}</td>
                            <td>${new Intl.NumberFormat().format(item.product.unitPrice)}</td>
                            <td><input type="number" value="${quantityofproduct}" class="quantity-${parseInt(item.product.productId)}"/></td>
                            <td>${new Intl.NumberFormat().format(cost)}</td>
                            <td>
                                <button class="btn btn-success updatecartitem" data-productid="${parseInt(item.product.productId)}">Update</button>
                                <a data-productid="${parseInt(item.product.productId)}" class="btn btn-danger removeproduct">Remove</a>
                            </td>
                        </tr>
                    `);
            }           
            $('#tfoot').html(`
                    <tr>
                        <td colspan="4" class="text-right">Total Amount</td>
                        <td>${new Intl.NumberFormat().format(totalCount)}</td>
                        <td><a asp-controller="Product" asp-action="Checkout" class="btn btn-success">Checkout</a></td>
                    </tr>
                `);
        }
    });
};

$(document).ready(function () {  
    cart.showCount();
});