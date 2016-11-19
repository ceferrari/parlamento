(function () {
    'use strict';

    angular
        .module('app')
        .controller('Main', controller);

    function controller($location, $localStorage, $state, AuthenticationService) {
        var vm = this;

        initController();

        function initController() {
            vm.nomeCompleto = $localStorage.Usuario.nomeCompleto;
            vm.email = $localStorage.Usuario.email;
            vm.logout = logout;
        };

        function logout() {
            AuthenticationService.Logout();
        };
    }
})();