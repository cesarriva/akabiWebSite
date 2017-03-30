'use strict';

angular.module("mainAppModule").controller('ContactController',
    [
        '$scope',
        '$sce',
        'ContactServiceProvider',
        function ($scope, $sce, ContactServiceProvider) {

            $scope.contactData = {};
            $scope.showServerErrors = false;
            $scope.serverErrorMessage = "";
            $scope.sendingContactMessage = false;

            $scope.submitContactForm = function () {

                $scope.$broadcast('validate-on-submit');

                if ($scope.contactForm.$invalid)
                    return;

                $scope.showServerErrors = false;
                $scope.serverErrorMessage = "";
                $scope.sendingContactMessage = true;

                ContactServiceProvider.sendContactMessage($scope.contactData)
                    .then(
                        function (result) {

                            if (result.success) {
                                cleanForm();
                                $scope.showSuccessToastr(result.message);
                            }
                        },
                        function (errorResult) {
                            $scope.showServerErrors = true;
                            $scope.serverErrorMessage = $sce.trustAsHtml(errorResult.message);
                        })
                    .then(function () {
                        $scope.sendingContactMessage = false;
                    });
            };

            function cleanForm() {
                $scope.contactForm.$setUntouched();
                $scope.contactData = {};
            }

        }
    ]);