'use strict'

angular.module("mainAppModule").factory('CareerServiceProvider',
    [
        '$http',
        '$q',
        'akFileUploaderService',
        function ($http, $q, akFileUploaderService) {

            var config = {
                headers: {
                    'X-Requested-With': 'XMLHttpRequest'
                }
            }

            var sendJobApplication = function (jobApplication) {
                return akFileUploaderService.saveModel(jobApplication, "/Career/SubmitSpontaneouslyApplication");
            };

            return {
                sendJobApplication: sendJobApplication
            };
        }
    ]);