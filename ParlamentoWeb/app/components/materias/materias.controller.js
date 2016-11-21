(function () {
    'use strict';

    angular
        .module('app')
        .controller('Materias', controller);

    function controller($rootScope, RestService) {
        var vm = this;

        (function initController() {
            $rootScope.FixLayout();
        })();

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

        vm.ListarMaterias = function () {
            RestService.getArray({
                controller: "Materias", action: "Listar",
                deslocamento: (vm.Paginacao.Atual - 1) * vm.Paginacao.Limite,
                limite: vm.Paginacao.Limite,
                ordenarPor: vm.Paginacao.Ordem
            }, function (resultado) {
                vm.Materias = resultado;
            });
            RestService.get({
                controller: "Materias", action: "Contar"
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

        vm.LimparFiltros();
    }
})();