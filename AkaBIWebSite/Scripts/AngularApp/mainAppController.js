'use strict';

angular.module("mainAppModule").controller('MainAppController',
    [
        '$scope',
        function ($scope) {

            $scope.showSuccessToastr = function (message, title) {
                /*Show red message as success message*/
                toastr.error(message, title);
            }

        }
    ]);