'use strict'

angular.module("mainAppModule").directive('validateOnSubmit', function () {
    return {
        restrict: 'A',
        require: '^form',
        link: function (scope, el, attrs, formCtrl) {

            var inputEl = el[0].querySelector("[name]");
            var inputNgEl = angular.element(inputEl);
            var inputName = inputNgEl.attr('name');

            scope.$on('validate-on-submit', function () {
                el.toggleClass('has-error', formCtrl[inputName].$invalid);
            });

        }
    }
});