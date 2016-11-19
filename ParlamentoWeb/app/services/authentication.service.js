(function () {
    'use strict';

    angular
        .module('app')
        .factory('AuthenticationService', service);

    function service($rootScope, $http, $localStorage, $state) {
        return {
            Login: login,
            Logout: logout
        }

        function login(email, password, callback) {
            //$http.post('/api/authenticate', { email: email, password: password })
            $http.post('/usuario', { email: email, password: password })
                .success(function (response) {
                    if (response.token) {
                        $localStorage.currentUser = { fullName: response.fullName, email: email, token: response.token };
                        $http.defaults.headers.common.Authorization = 'Bearer ' + response.token;
                        $state.go("dashboard");
                        callback(true);
                    } else {
                        callback(false);
                    }
                });
        }

        function logout() {
            delete $localStorage.currentUser;
            $http.defaults.headers.common.Authorization = '';
            $state.go("login");
        }
    }
})();