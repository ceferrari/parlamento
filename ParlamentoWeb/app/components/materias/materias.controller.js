(function () {
    'use strict';

    angular
        .module('app')
        .controller('Materias', controller);

    function controller($rootScope, RestService) {
        var vm = this;

        vm.Paginacao = {
            Total: 0,
            Atual: 1,
            Limite: 25,
            Ordem: "Ano DESC, Codigo ASC",
            Calcular: function () {
                var atual = !this.Total ? 0 : 1 + ((this.Atual - 1) * this.Limite);
                var limite = this.Atual * this.Limite >= this.Total ? this.Total : this.Atual * this.Limite;
                return "Exibindo " + atual + " - " + limite + " de " + this.Total;
            }
        };

        vm.Filtros = {
            Ano: null,
            CodigoAssuntoGeral: null,
            CodigoAssuntoEspecifico: null,
            CodigoSubtipo: null
        }

        vm.ListarAnos = function () {
            RestService.getArray({
                controller: "Materias", action: "ListarAnos"
            }, function (resultado) {
                vm.Anos = resultado;
            });
        }

        vm.ListarMateriasAssuntos = function () {
            RestService.getArray({
                controller: "MateriasAssuntos", action: "Listar",
                ordenarPor: "AssuntoEspecifico"
            }, function (resultado) {
                vm.MateriasAssuntos = resultado;
                vm.MateriasAssuntosGerais = resultado
                    .map(function (obj) { return obj.AssuntoGeral })
                    .filter(function (value, index, self) { return self.indexOf(value) === index; });
            });
        };

        vm.ListarMateriasSubtipos = function () {
            RestService.getArray({
                controller: "MateriasSubtipos", action: "Listar",
                ordenarPor: "Descricao"
            }, function (resultado) {
                vm.MateriasSubtipos = resultado;
            });
        };

        vm.ListarMaterias = function () {
            RestService.getArray({
                controller: "Materias", action: "Listar",
                deslocamento: (vm.Paginacao.Atual - 1) * vm.Paginacao.Limite,
                limite: vm.Paginacao.Limite,
                ordenarPor: vm.Paginacao.Ordem,
                ano: vm.Filtros.Ano,
                assuntoGeral: vm.Filtros.CodigoAssuntoGeral,
                assuntoEspecifico: vm.Filtros.CodigoAssuntoEspecifico,
                subtipo: vm.Filtros.CodigoSubtipo
            }, function (resultado) {
                vm.Materias = resultado;
            });
            RestService.get({
                controller: "Materias", action: "Contar",
                ano: vm.Filtros.Ano,
                assuntoGeral: vm.Filtros.CodigoAssuntoGeral,
                assuntoEspecifico: vm.Filtros.CodigoAssuntoEspecifico,
                subtipo: vm.Filtros.CodigoSubtipo
            }, function (resultado) {
                vm.Paginacao.Total = resultado.Total;
            });
        }

        vm.Atualizar = function (event, pagina1) {
            if (pagina1) {
                vm.Paginacao.Atual = 1;
            }
            if (!event || event.keyCode === 13) {
                vm.ListarMaterias();
            }
        };

        vm.LimparFiltros = function () {
            vm.Paginacao.Limite = 25;
            vm.Paginacao.Ordem = "Ano DESC, Codigo ASC";
            //vm.Filtros = {
            //    Nome: "",
            //    Partido: "",
            //    Estado: "",
            //    Sexo: ""
            //};
            vm.Atualizar(null, true);
        };

        (function initController() {
            $rootScope.FixLayout();

            vm.ListarAnos();
            vm.ListarMateriasAssuntos();
            vm.ListarMateriasSubtipos();
            vm.LimparFiltros();
        })();
    }
})();