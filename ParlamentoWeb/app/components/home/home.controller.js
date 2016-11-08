(function () {
    'use strict';

    angular
        .module('app')
        .controller('Home', controller);

    function controller(RestService) {
        var vm = this;

        initController();

        function initController() {
            setTimeout(function () {
                $.AdminLTE.layout.fix();
                $.AdminLTE.layout.fixSidebar();
            }, 250);

            RestService.getArray({ controller: "Senadores", action: "Listar" }, function (resultado) {
                vm.Senadores = resultado;
            });
        }
    }
})();