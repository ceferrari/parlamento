(function () {
    'use strict';

    angular
        .module('app')
        .controller('Senadores', controller);

    function controller(RestService) {
        var vm = this;

        initController();

        function initController() {
            setTimeout(function () {
                $.AdminLTE.layout.fix();
                $.AdminLTE.layout.fixSidebar();
            }, 250);

            vm.Paginacao = {
                Total: 0,
                Atual: 1,
                Limite: 9,
                Ordem: "Nome ASC",
                Calcular: function () {
                    var atual = !this.Total ? 0 : 1 + ((this.Atual - 1) * this.Limite);
                    var limite = this.Atual * this.Limite >= this.Total ? this.Total : this.Atual * this.Limite;
                    return "Exibindo " + atual + " - " + limite + " de " + this.Total;
                }
            };

            vm.ListarPartidos = function () {
                RestService.getArray({
                    controller: "Senadores", action: "ListarPartidos"
                }, function (resultado) {
                    vm.Partidos = resultado;
                });
            }

            vm.ListarEstados = function () {
                RestService.getArray({
                    controller: "Senadores", action: "ListarEstados"
                }, function (resultado) {
                    vm.Estados = resultado;
                });
            }

            vm.ListarSexos = function () {
                RestService.getArray({
                    controller: "Senadores", action: "ListarSexos"
                }, function (resultado) {
                    vm.Sexos = resultado;
                });
            }

            vm.ListarSenadores = function () {
                RestService.getArray({
                    controller: "Senadores", action: "Listar",
                    deslocamento: (vm.Paginacao.Atual - 1) * vm.Paginacao.Limite,
                    limite: vm.Paginacao.Limite,
                    ordenarPor: vm.Paginacao.Ordem + ",Nome",
                    nome: vm.Filtros.Nome,
                    siglaPartido: vm.Filtros.Partido,
                    ufMandato: vm.Filtros.Estado,
                    sexo: vm.Filtros.Sexo
                }, function (resultado) {
                    vm.Senadores = resultado;
                });
                RestService.get({
                    controller: "Senadores", action: "Contar",
                    nome: vm.Filtros.Nome,
                    siglaPartido: vm.Filtros.Partido,
                    ufMandato: vm.Filtros.Estado,
                    sexo: vm.Filtros.Sexo
                }, function (resultado) {
                    vm.Paginacao.Total = resultado.Total;
                });
            }

            vm.Atualizar = function (event, pagina1) {
                if (pagina1) {
                    vm.Paginacao.Atual = 1;
                }
                if (!event || event.keyCode === 13) {
                    vm.ListarSenadores();
                }
            };

            vm.LimparFiltros = function () {
                vm.Paginacao.Ordem = "Nome ASC";
                vm.Filtros = {
                    Nome: "",
                    Partido: "",
                    Estado: "",
                    Sexo: ""
                };
                vm.Atualizar(null, true);
            };

            vm.LimparFiltros();
            vm.ListarPartidos();
            vm.ListarEstados();
            vm.ListarSexos();
        }
    }
})();