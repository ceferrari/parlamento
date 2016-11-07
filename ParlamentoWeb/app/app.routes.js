(function () {
    'use strict';

    angular
        .module('app')
        .config(routes);

    function routes($stateProvider, $urlRouterProvider, $locationProvider) {
        $urlRouterProvider.otherwise('/');

        $stateProvider
            .state('login', {
                url: '/login',
                controller: 'Login',
                controllerAs: 'vm',
                templateUrl: 'app/components/login/login.view.html'
            })
            .state('register', {
                url: '/register',
                controller: 'Register',
                controllerAs: 'vm',
                templateUrl: 'app/components/register/register.view.html'
            })
            .state('home', {
                url: '/',
                views: {
                    "header": {
                        controller: 'Main',
                        controllerAs: 'vm',
                        templateUrl: "app/shared/header.partial.html"
                    },
                    "menu": { templateUrl: "app/shared/menu.partial.html" },
                    "content": {
                        controller: 'Home',
                        controllerAs: 'vm',
                        templateUrl: "app/components/home/home.view.html"
                    },
                    "footer": { templateUrl: "app/shared/footer.partial.html" }
                }
            });

        //$locationProvider.html5Mode({
        //    enabled: true,
        //    requireBase: false
        //});
    }
})();