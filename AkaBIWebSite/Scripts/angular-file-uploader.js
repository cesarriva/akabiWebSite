﻿(function () {

    "use strict"

    angular.module("akFileUploader", [])

           .factory("akFileUploaderService", ["$q", "$http",
               function ($q, $http) {

                   var getModelAsFormData = function (data) {
                       var dataAsFormData = new FormData();
                       angular.forEach(data, function (value, key) {
                           dataAsFormData.append(key, value);
                       });
                       return dataAsFormData;
                   };

                   var saveModel = function (data, url) {
                       var deferred = $q.defer();
                       $http({
                           url: url,
                           method: "POST",
                           data: getModelAsFormData(data),
                           transformRequest: angular.identity,
                           headers: {
                               'Content-Type': undefined,
                               'X-Requested-With': 'XMLHttpRequest'
                           }
                       })
                       .then(function (result) {
                           deferred.resolve(result.data);
                       },
                       function (result) {
                           deferred.reject(result.data);
                       });

                       return deferred.promise;
                   };

                   return {
                       saveModel: saveModel
                   }
               }])

         .directive("akFileModel", ["$parse",
                function ($parse) {
                    return {
                        restrict: "A",
                        link: function (scope, element, attrs) {
                            var model = $parse(attrs.akFileModel);
                            var modelSetter = model.assign;
                            element.bind("change", function () {
                                scope.$apply(function () {
                                    modelSetter(scope, element[0].files[0]);
                                });
                            });
                        }
                    };
                }])

        .directive('validFile', function () {
            return {
                require: 'ngModel',
                link: function (scope, el, attrs, ngModel) {
                    el.bind('change', function () {
                        scope.$apply(function () {
                            ngModel.$setViewValue(el.val());
                            ngModel.$render();
                        });
                    });
                }
            }
        });
})(window, document);