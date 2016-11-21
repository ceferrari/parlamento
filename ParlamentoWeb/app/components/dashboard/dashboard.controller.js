(function () {
    'use strict';

    angular
        .module('app')
        .controller('Dashboard', controller);

    function controller($rootScope) {
        var vm = this;

        (function initController() {
            $rootScope.FixLayout();
        })();
    }
})();