/// <reference path="../jquery-2.1.1.min.js" />

//==========================================================================
//Initialization
//==========================================================================
$(function () {
    //Initialization Scripts
    productScripts.init();
});


var productScripts = {
    //Initialization
    init: function () {
        try {
            //no IE, usar o console sem que ele esteja aberto resulta em erro
            if (!window.console) console = { log: function () { } };
            this.maskConfig();
        }
        catch (e) {
            console.log(e);
        };
    },

    //Configure mask fields
    maskConfig: function () {
        //Get mask format by culture
        var separator = $("#Culture").val().toLowerCase().search("english") != -1 ? "," : ".";
        var radixPoint = $("#Culture").val().toLowerCase().search("english") != -1 ? "." : ",";
        var prefix = $("#Culture").val().toLowerCase().search("english") != -1 ? "U$ " : "R$ ";

        $(".currency").inputmask('decimal', {
            alias: 'numeric',
            groupSeparator: separator,
            autoGroup: true,
            integerDigits: 10,
            digits: 2,
            radixPoint: radixPoint,
            digitsOptional: false,
            allowMinus: false,
            prefix: prefix,
            placeholder: '',
            removeMaskOnSubmit: true,
        });
    }
}