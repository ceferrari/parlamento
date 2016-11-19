(function () {
    'use strict';

    angular
        .module('app')
        .controller('Senador.Votos', controller);

    function controller($rootScope, $state, $stateParams, RestService) {
        var vm = this;
        
        vm.CodigoSenador = null;
        vm.CodigoMateria = null;
        vm.CodigoSessao = null;
        vm.CodigoAutorMateria = null;
        vm.CodigoAssuntoMateria = null;
        vm.CodigoSubtipoMateria = null;

        (function initController() {
            $rootScope.FixLayout();

            RestService.get({
                controller: "Senadores", action: "ObterPorChave", id: $stateParams.id
            }, function (resultado) {
                vm.Senador = resultado;
            });
        })();

        vm.ListarMateriasAssuntos = function () {
            RestService.getArray({
                controller: "MateriasAssuntos", action: "Listar"
            }, function (resultado) {
                console.log(resultado);
                vm.MateriasAssuntos = resultado;
            });
        };

        vm.ListarVotos = function () {
            RestService.getArray({
                controller: "Votos", action: "Listar",
                senador: $stateParams.id,
                materia: vm.CodigoMateria,
                sessao: vm.CodigoSessao,
                autorMateria: vm.CodigoAutorMateria,
                assuntoMateria: vm.CodigoAssuntoMateria,
                subtipoMateria: vm.CodigoSubtipoMateria
            }, function (resultado) {
                vm.Votos = resultado;
            });
        };

        vm.Atualizar = function () {
            if (!event || event.keyCode === 13) {
                vm.ListarVotos();
            }
        };

        vm.ListarMateriasAssuntos();
        vm.ListarVotos();

        //    vm.LimparFiltros = function () {
        //        vm.Paginacao.Limite = 9;
        //        vm.Paginacao.Ordem = "Nome ASC";
        //        vm.Filtros = {
        //            Nome: "",
        //            Partido: "",
        //            Estado: "",
        //            Sexo: ""
        //        };
        //        vm.Atualizar(null, true);
        //    };

        //    vm.LimparFiltros();
        //    vm.ListarPartidos();
        //    vm.ListarEstados();
        //    vm.ListarSexos();
    }
})();