(function () {
    'use strict';

    angular
        .module('app')
        .controller('Registro', controller);

    function controller($location, AuthenticationService) {
        var vm = this;

        initController();

        function initController() {
            vm.registrar = registrar;
        };

        function registrar() {
            vm.loading = true;
            AuthenticationService.Registrar(vm.nomeCompleto, vm.email, vm.senha, function (result) {
                if (result === true) {
                    //$location.path('/login');
                } else {
                    vm.error = 'Erro.';
                    vm.loading = false;
                }
            });
        };
    }
})();