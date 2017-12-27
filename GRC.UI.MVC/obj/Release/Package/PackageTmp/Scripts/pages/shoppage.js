/// <reference path="../jquery-2.1.1.min.js" />

//==========================================================================
//Initialization
//==========================================================================
$(function () {
    //Initialization Scripts
    shopScripts.init();
});


var shopScripts = {
    //Initialization
    init: function () {
        try {
            //no IE, usar o console sem que ele esteja aberto resulta em erro
            if (!window.console) console = { log: function () { } };
            this.basket();
            this.sortableBasket();
        }
        catch (e) {
            console.log(e);
        };
    },

    //Put/Remove the products in the basket
    basket: function () {
        $(".container").on("click", ".putBasket", function () {
            var productId = $(this).attr("productId");
            var categoryId = $(this).attr("categoryId");
            var basket = $(this).is(':checked');
            
            if (productId && categoryId) {
                $.ajax({
                    type: 'POST',
                    url: 'http://' + window.location.host + '/Shop/PutBasket/',
                    data: {
                        productId: productId,
                        basket: basket,
                        categoryId: categoryId
                    },
                    success: function (result) {
                        if (result.success) {
                            window.location.reload();
                        }
                        else {
                            toastr.error(result.message);
                        }
                    },
                });
            }
        });
    },

    //Reorder the itens of the basket
    sortableBasket: function () {
        $("#basket").sortable({
            revert: true,
            update: function (event, ui) {
                var ids = [];

                //Get the new position of itens
                $("#basket li").each(function (index, element) {
                    var productId = $(element).find("input[type='checkbox']").attr("productId")

                    if (productId) {
                        ids.push(productId);
                    }
                });

                if (ids && ids.length > 0) {
                    $.ajax({
                        type: 'POST',
                        url: 'http://' + window.location.host + '/Shop/SortBasket/',
                        data: {
                            ids: ids
                        },
                        success: function (result) {
                            if (!result.success) {
                                toastr.error(result.message);
                            }
                        },
                    });
                }
            }
        });
    }
}