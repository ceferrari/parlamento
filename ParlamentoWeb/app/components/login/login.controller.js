(function () {
    'use strict';

    angular
        .module('app')
        .controller('Login', controller);

    function controller($location, $state, AuthenticationService) {
        var vm = this;

        vm.login = login;

        (function initController() {
            AuthenticationService.Logout();
        })();

        function login() {
            vm.loading = true;
            AuthenticationService.Login(vm.email, vm.senha, function (resultado) {
                if (resultado === true) {
                    $state.go("dashboard");
                } else {
                    vm.error = 'E-mail e/ou senha incorreto(s).';
                    vm.loading = false;
                }
            });
        };
    }
})();