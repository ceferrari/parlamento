(function () {
    'use strict';

    angular
        .module('app')
        .controller('Main', controller);

    function controller($location, $localStorage, $state, AuthenticationService) {
        var vm = this;

        vm.nomeCompleto = $localStorage.Usuario.NomeCompleto;
        vm.email = $localStorage.Usuario.Email;
        vm.logout = logout;

        function logout() {
            AuthenticationService.Logout();
        };
    }
})();