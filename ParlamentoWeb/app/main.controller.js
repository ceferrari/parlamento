(function () {
    'use strict';

    angular
        .module('app')
        .controller('Main', controller);

    function controller($location, $localStorage, AuthenticationService) {
        var vm = this;

        vm.fullName = $localStorage.currentUser.fullName;
        vm.email = $localStorage.currentUser.email;
        vm.logout = logout;

        initController();

        function initController() {

        };

        function logout() {
            AuthenticationService.Logout();
        };
    }
})();