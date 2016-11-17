(function () {
    'use strict';

    angular
        .module('app')
        .directive('convertToNumber', directive);

    function directive() {
        return {
            require: 'ngModel',
            link: function (scope, element, attrs, ngModel) {
                ngModel.$parsers.push(function (val) {
                    return val === null ? null : parseInt(val, 10);
                });
                ngModel.$formatters.push(function (val) {
                    return val === null ? null : '' + val;
                });
            }
        };
    }
})();