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
            alert("error");
        }
    });
});


$(document).ready(function () {  
    cart.showCount();
});