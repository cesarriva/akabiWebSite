'use strict';

angular.module("mainAppModule").controller('SpontaneousApplicationJobController',
    [
        '$scope',
        '$sce',
        '$window',
        'CareerServiceProvider',
        function ($scope, $sce, $window, CareerServiceProvider) {

            $scope.jobApplication = {};
            $scope.showServerErrors = false;
            $scope.serverErrorMessage = "";
            $scope.sendingApplication = false;

            $scope.data = {
                availableLocations: [
                    { id: '1', name: 'Luxembourg' },
                    { id: '2', name: 'Belgium' }
                ],
                selectedLocation: { id: '1', name: 'Luxembourg' }
            };

            $scope.$watch('data.selectedLocation', function (newVal, oldVal) {
                $scope.jobApplication.selectedLocation = newVal.name;
            })

            $scope.submitApplicationForm = function () {

                $scope.$broadcast('validate-on-submit');


                if ($scope.jobApplyForm.$invalid)
                    return;

                $scope.showServerErrors = false;
                $scope.serverErrorMessage = "";
                $scope.sendingApplication = true;

                CareerServiceProvider.sendJobApplication($scope.jobApplication)
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
                        $scope.sendingApplication = false;
                    });
            };

            function cleanForm() {
                $scope.jobApplyForm.$setUntouched();
                $scope.jobApplication = {};
                
                var form = $('#job-apply-form').get(0);
                form.reset();

            }

        }
    ]);