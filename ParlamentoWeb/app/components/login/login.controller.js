(function () {
    'use strict';

    angular
        .module('app')
        .controller('Login', controller);

    function controller($location, AuthenticationService) {
        var vm = this;

        vm.login = login;

        (function initController() {
            AuthenticationService.Logout();
        })();

        function login() {
            vm.loading = true;
            AuthenticationService.Login(vm.email, vm.senha, function (result) {
                if (result === true) {
                    //$location.path('/');
                } else {
                    vm.error = 'E-mail e/ou senha incorreto(s).';
                    vm.loading = false;
                }
            });
        };
    }
})();