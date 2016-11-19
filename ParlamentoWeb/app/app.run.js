(function () {
    'use strict';

    angular
        .module('app')
        .run(run);

    function run($rootScope, $http, $location, $localStorage, $state, $stateParams, $timeout) {
        $rootScope.$state = $state;
        $rootScope.$stateParams = $stateParams;

        $rootScope.Compare = function (a, b) {
            return angular.equals(a, b);
        }

        $rootScope.FixLayout = function () {
            $timeout(function () {
                $.AdminLTE.layout.fix();
                $.AdminLTE.layout.fixSidebar();
            }, 250);
        }

        //if ($localStorage.Usuario) {
        //    $http.defaults.headers.common.Authorization = 'Bearer ' + $localStorage.Usuario.token;
        //}

        $rootScope.$on('$locationChangeStart', function (event, next, current) {
            var publicPages = ['/login'];
            var restrictedPage = publicPages.indexOf($location.path()) === -1;
            if (restrictedPage && !$localStorage.Usuario) {
                $location.path('/login');
            }
        });
    }
})();