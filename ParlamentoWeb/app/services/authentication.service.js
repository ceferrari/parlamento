(function () {
    'use strict';

    angular
        .module('app')
        .factory('AuthenticationService', service);

    function service($rootScope, $http, $localStorage, $state, RestService) {
        return {
            Login: login,
            Logout: logout,
            Registrar: registrar
        }

        function login(email, senha, callback) {
            RestService.post({ controller: "Usuarios", action: "Autenticar" }, { email: email, senha: senha }, function (resultado) {
                if (resultado.Id) {
                    $localStorage.Usuario = { Id: resultado.Id, NomeCompleto: resultado.NomeCompleto, Email: resultado.Email };
                    $state.go("dashboard");
                    callback(true);
                } else {
                    callback(false);
                }
            });

            //$http.post('/api/authenticate', { email: email, password: password })
            //    .success(function (response) {
            //        if (response.token) {
            //            $localStorage.currentUser = { fullName: response.fullName, email: email, token: response.token };
            //            $http.defaults.headers.common.Authorization = 'Bearer ' + response.token;
            //            $state.go("dashboard");
            //            callback(true);
            //        } else {
            //            callback(false);
            //        }
            //    });
        }

        function logout() {
            delete $localStorage.Usuario;
            $http.defaults.headers.common.Authorization = '';
            $state.go("login");
        }

        function registrar(nomeCompleto, email, senha, callback) {
            RestService.post({ controller: "Usuarios", action: "Registrar" }, { nomeCompleto: nomeCompleto, email: email, senha: senha }, function (resultado) {
                if (resultado) {
                    $state.go("login");
                    callback(true);
                } else {
                    callback(false);
                }
            });
        }
    }
})();