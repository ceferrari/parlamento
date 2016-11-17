(function () {
    'use strict';

    angular
        .module('app')
        .controller('Main', controller);

    function controller($location, $localStorage, $state, AuthenticationService) {
        var vm = this;

        initController();

        function initController() {
            vm.fullName = $localStorage.currentUser.fullName;
            vm.email = $localStorage.currentUser.email;
            vm.logout = logout;
        };

        function logout() {
            AuthenticationService.Logout();
        };
    }
})();