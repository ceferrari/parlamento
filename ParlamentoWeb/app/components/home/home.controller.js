(function () {
    'use strict';

    angular
        .module('app')
        .controller('Home', controller);

    function controller() {
        var vm = this;

        initController();

        function initController() {
            setTimeout(function () {
                $.AdminLTE.layout.fix();
                $.AdminLTE.layout.fixSidebar();
            }, 250);
        }
    }
})();