/// <reference path="../jquery-2.1.1.min.js" />

//==========================================================================
//Initialization
//==========================================================================
$(function () {
    //Initialization Scripts
    generalScripts.init();
});

var generalScripts = {
    //Initialization
    init: function () {
        try {
            //no IE, usar o console sem que ele esteja aberto resulta em erro
            if (!window.console) console = { log: function () { } };
            this.materializeInit();
        }
        catch (e) {
            console.log(e);
        };
    },

    //Initialize scripts of materialize
    materializeInit: function () {
        //Apply the materialize select
        $('select').material_select();

        //Button of menu
        $('.button-collapse').sideNav();
    },

    //Confirm Message
    toastrConfirm: function(formSubmit){
        var template = "<h5 style='font-size:1.5rem'>Confirmar exclusão?</h5>" +
                       "<button type='button' id='btnYes' class='btn clear' style='margin:0; margin-right:10px;'>Sim</button>";

        var dialog = toastr.info(template, '', {
            closeButton: true,
            debug: false,
            positionClass: "toast-top-right",
            onclick: null,
            showDuration: "1000",
            hideDuration: "0",
            timeOut: 0,
            extendedTimeOut: 0,
            showEasing: "swing",
            hideEasing: "linear",
            showMethod: "fadeIn",
            hideMethod: "fadeOut",
            tapToDismiss: false,
            allowHtml: true,
            onShown: function (toast) {
                $("#btnYes").click(function () {
                    $(formSubmit).submit();
                });

                $("#btnNo").click(function () {
                    
                });
            }
        });
    }
}