(function () {
    'use strict';

    angular
        .module('app')
        .controller('Register', controller);

    function controller($location, AuthenticationService) {
        var vm = this;

        vm.login = login;

        initController();

        function initController() {
            AuthenticationService.Logout();
        };

        function login() {
            vm.loading = true;
            AuthenticationService.Login(vm.email, vm.password, function (result) {
                if (result === true) {
                    $location.path('/');
                } else {
                    vm.error = 'Usuário e/ou senha incorreto(s).';
                    vm.loading = false;
                }
            });
        };
    }
})();