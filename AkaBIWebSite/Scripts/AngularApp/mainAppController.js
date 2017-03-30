'use strict';

angular.module("mainAppModule").controller('MainAppController',
    [
        '$scope',
        function ($scope) {

            $scope.showSuccessToastr = function (message, title) {
                toastr.success(message, title);
            }

            $scope.showInfoToastr = function (message, title) {
                toastr.info(message, title);
            }

            $scope.showErrorToastr = function (message, title) {
                toastr.error(message, title);
            }

            $scope.showWarningToastr = function (message, title) {
                toastr.warning(message, title);
            }

        }
    ]);