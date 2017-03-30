'use strict'

angular.module("mainAppModule").factory('ContactServiceProvider',
    [
        '$http',
        '$q',
        function ($http, $q) {

            var config = {
                headers: {
                    'X-Requested-With': 'XMLHttpRequest'
                }
            }

            var sendContactMessage = function (contactData) {

                var deferred = $q.defer();

                var param = { contactData: contactData };

                $http.post('/ContactUs/SendContactMessage', param, config)
                    .then(function (result) {
                        deferred.resolve(result.data);
                    },
                    function (result) {
                        deferred.reject(result.data);
                    });

                return deferred.promise;
            }

            return {
                sendContactMessage: sendContactMessage
            }
        }
    ]);