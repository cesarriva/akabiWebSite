'use strict'

var mainModule = angular.module('mainAppModule', ['angular-ladda', 'akFileUploader']);

mainModule.config(function (laddaProvider) {
    laddaProvider.setOption({
        style: 'expand-right'
    });
});

mainModule.run(function () {
    toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": true,
        "progressBar": false,
        "positionClass": "toast-bottom-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "5000",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }
});