(function () {
    'use strict';

    angular
        .module('app')
        .config(routes);

    function routes($stateProvider, $urlRouterProvider, $locationProvider) {
        $urlRouterProvider.otherwise('/dashboard');

        $stateProvider
            .state('login', {
                url: '/login',
                controller: 'Login',
                controllerAs: 'vm',
                templateUrl: 'app/components/login/login.view.html'
            })
            .state('registro', {
                url: '/registro',
                controller: 'Registro',
                controllerAs: 'vm',
                templateUrl: 'app/components/registro/registro.view.html'
            })
            .state('dashboard', {
                url: '/dashboard',
                views: {
                    "header": {
                        controller: 'Main',
                        controllerAs: 'vm',
                        templateUrl: "app/shared/header.partial.html"
                    },
                    "menu": { templateUrl: "app/shared/menu.partial.html" },
                    "content": {
                        controller: 'Dashboard',
                        controllerAs: 'vm',
                        templateUrl: "app/components/dashboard/dashboard.view.html"
                    },
                    "footer": { templateUrl: "app/shared/footer.partial.html" }
                }
            })
            .state('senadores', {
                url: '/senadores',
                views: {
                    "header": {
                        controller: 'Main',
                        controllerAs: 'vm',
                        templateUrl: "app/shared/header.partial.html"
                    },
                    "menu": { templateUrl: "app/shared/menu.partial.html" },
                    "content": {
                        controller: 'Senadores',
                        controllerAs: 'vm',
                        templateUrl: "app/components/senadores/senadores.view.html"
                    },
                    "footer": { templateUrl: "app/shared/footer.partial.html" }
                }
            })
            .state('senador', {
                abstract: true,
                url: '/senador/:id'
                //views: {
                //    "header": {
                //        controller: 'Senador',
                //        controllerAs: 'vm',
                //        templateUrl: "app/shared/header.partial.html"
                //    },
                //    "menu": { templateUrl: "app/shared/menu.partial.html" },
                //    "content": {
                //        controller: 'Votos',
                //        controllerAs: 'vm',
                //        templateUrl: "app/components/senador/senador.view.html"
                //    },
                //    "footer": { templateUrl: "app/shared/footer.partial.html" }
                //}
            })
            .state('senador.votos', {
                url: '/votos',
                views: {
                    "header": {
                        controller: 'Main',
                        controllerAs: 'vm',
                        templateUrl: "app/shared/header.partial.html"
                    },
                    "menu": { templateUrl: "app/shared/menu.partial.html" },
                    "content": {
                        controller: 'Senador.Votos',
                        controllerAs: 'vm',
                        templateUrl: "app/components/senador/votos/votos.view.html"
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