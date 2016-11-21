(function () {
    'use strict';

    angular
        .module('app')
        .controller('Registro', controller);

    function controller($location, $state, AuthenticationService) {
        var vm = this;

        vm.registrar = registrar;

        function registrar() {
            vm.loading = true;
            AuthenticationService.Registrar(vm.nomeCompleto, vm.email, vm.senha, function (result) {
                if (result === true) {
                    $state.go("login");
                } else {
                    vm.error = result;
                    vm.loading = false;
                }
            });
        };
    }
})();