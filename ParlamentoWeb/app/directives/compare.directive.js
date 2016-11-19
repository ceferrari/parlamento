(function () {
    'use strict';

    angular
        .module('app')
        .directive('compare', directive);

    function directive() {
        return {
            require: "ngModel",
            scope: {
                otherModelValue: "=compare"
            },
            link: function(scope, element, attributes, ngModel) {
                ngModel.$validators.compare = function (modelValue) {
                    return modelValue === scope.otherModelValue;
                };
                scope.$watch("otherModelValue", function() {
                    ngModel.$validate();
                });
            }
        };
    }
})();