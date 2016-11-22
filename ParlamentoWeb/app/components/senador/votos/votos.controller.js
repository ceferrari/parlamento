(function () {
    'use strict';

    angular
        .module('app')
        .controller('Senador.Votos', controller);

    function controller($rootScope, $state, $stateParams, $timeout, RestService, EstadosBrasileiros) {
        var vm = this;

        vm.Filtros = {
            CodigoSenador: null,
            CodigoMateria: null,
            CodigoSessao: null,
            CodigoAutorMateria: null,
            CodigoAssuntoGeral: null,
            CodigoAssuntoEspecifico: null,
            CodigoSubtipoMateria: null,
            TipoGrafico: 'colunas'
        }

        vm.Votos = {
            Sim: 0,
            Nao: 0,
            Abstencao: 0,
            Pnrv: 0,
            Ausente: 0
        };

        vm.ObterSenadorPorChave = function (id) {
            RestService.get({
                controller: "Senadores", action: "ObterPorChave", id: (id || $stateParams.id)
            }, function (resultado) {
                vm.Senador = resultado;
            });
        };

        vm.ListarMateriasAssuntos = function () {
            RestService.getArray({
                controller: "MateriasAssuntos", action: "Listar",
                ordenarPor: "AssuntoEspecifico"
            }, function (resultado) {
                vm.MateriasAssuntos = resultado;
                //vm.MateriasAssuntosGerais = Array.from(new Set(resultado.map(function (obj) { return obj.AssuntoGeral })));
                vm.MateriasAssuntosGerais = resultado
                    .map(function (obj) { return obj.AssuntoGeral })
                    .filter(function (value, index, self) { return self.indexOf(value) === index; });
            });
        };

        vm.ContarVotos = function () {
            RestService.get({
                controller: "Votos", action: "Contar",
                senador: $stateParams.id,
                materia: vm.Filtros.CodigoMateria,
                sessao: vm.Filtros.CodigoSessao,
                autorMateria: vm.Filtros.CodigoAutorMateria,
                assuntoGeralMateria: vm.Filtros.CodigoAssuntoGeral,
                assuntoEspecificoMateria: vm.Filtros.CodigoAssuntoEspecifico,
                subtipoMateria: vm.Filtros.CodigoSubtipoMateria,
                descricaoVoto: "Sim"
            }, function (resultado) {
                vm.Votos.Sim = resultado.Total;
            });
            RestService.get({
                controller: "Votos", action: "Contar",
                senador: $stateParams.id,
                materia: vm.Filtros.CodigoMateria,
                sessao: vm.Filtros.CodigoSessao,
                autorMateria: vm.Filtros.CodigoAutorMateria,
                assuntoGeralMateria: vm.Filtros.CodigoAssuntoGeral,
                assuntoEspecificoMateria: vm.Filtros.CodigoAssuntoEspecifico,
                subtipoMateria: vm.Filtros.CodigoSubtipoMateria,
                descricaoVoto: "Não"
            }, function (resultado) {
                vm.Votos.Nao = resultado.Total;
            });
            RestService.get({
                controller: "Votos", action: "Contar",
                senador: $stateParams.id,
                materia: vm.Filtros.CodigoMateria,
                sessao: vm.Filtros.CodigoSessao,
                autorMateria: vm.Filtros.CodigoAutorMateria,
                assuntoGeralMateria: vm.Filtros.CodigoAssuntoGeral,
                assuntoEspecificoMateria: vm.Filtros.CodigoAssuntoEspecifico,
                subtipoMateria: vm.Filtros.CodigoSubtipoMateria,
                descricaoVoto: "Abstenção"
            }, function (resultado) {
                vm.Votos.Abstencao = resultado.Total;
            });
            RestService.get({
                controller: "Votos", action: "Contar",
                senador: $stateParams.id,
                materia: vm.Filtros.CodigoMateria,
                sessao: vm.Filtros.CodigoSessao,
                autorMateria: vm.Filtros.CodigoAutorMateria,
                assuntoGeralMateria: vm.Filtros.CodigoAssuntoGeral,
                assuntoEspecificoMateria: vm.Filtros.CodigoAssuntoEspecifico,
                subtipoMateria: vm.Filtros.CodigoSubtipoMateria,
                descricaoVoto: "P-NRV"
            }, function (resultado) {
                vm.Votos.Pnrv = resultado.Total;
            });
            RestService.get({
                controller: "Votos", action: "Contar",
                senador: $stateParams.id,
                materia: vm.Filtros.CodigoMateria,
                sessao: vm.Filtros.CodigoSessao,
                autorMateria: vm.Filtros.CodigoAutorMateria,
                assuntoGeralMateria: vm.Filtros.CodigoAssuntoGeral,
                assuntoEspecificoMateria: vm.Filtros.CodigoAssuntoEspecifico,
                subtipoMateria: vm.Filtros.CodigoSubtipoMateria,
                descricaoVoto: "Ausente"
            }, function (resultado) {
                vm.Votos.Ausente = resultado.Total;
            });
        };

        vm.EstadoPorSigla = function (sigla) {
            var estados = EstadosBrasileiros.filter(function (obj) { return obj.Sigla === sigla });
            return estados ? estados[0].Nome : sigla;
        };

        vm.AtualizarTituloGrafico = function () {
            if (vm.Filtros.CodigoAssuntoEspecifico) {
                return 'Votos sobre Matérias do assunto "' + vm.MateriasAssuntos.filter(function (obj) { return obj.Codigo === vm.Filtros.CodigoAssuntoEspecifico })[0].AssuntoEspecifico + '"';
            } 
            if (vm.Filtros.CodigoAssuntoGeral && !vm.Filtros.CodigoAssuntoEspecifico) {
                return 'Votos sobre Matérias do assunto "' + vm.Filtros.CodigoAssuntoGeral + '"';
            }
            return 'Votos sobre todas as Matérias';
        };

        vm.AtualizarGrafico = function () {
            if (vm.Filtros.TipoGrafico.includes("pizza") || vm.Filtros.TipoGrafico.includes("rosca")) {
                vm.chart.update({
                    chart: {
                        type: 'pie',
                        inverted: false,
                        polar: false,
                        options3d: {
                            enabled: vm.Filtros.TipoGrafico.includes("3d"),
                            alpha: 45,
                            beta: 0,
                            depth: 0
                        }
                    },
                    xAxis: {
                        visible: false
                    },
                    yAxis: {
                        visible: false
                    },
                    plotOptions: {
                        pie: {
                            allowPointSelect: true,
                            cursor: 'pointer',
                            dataLabels: {
                                enabled: true,
                                formatter: function () {
                                    return vm.Filtros.TipoGrafico.includes("pizza")
                                        ? this.point.name + ': ' + Math.round(this.percentage) + ' %'
                                        : Math.round(this.percentage) + ' %';
                                },
                                distance: vm.Filtros.TipoGrafico.includes("pizza") ? 30 : -30,
                                color: vm.Filtros.TipoGrafico.includes("pizza") ? 'black' : 'white'
                            },
                            depth: 45,
                            innerSize: vm.Filtros.TipoGrafico.includes("pizza") ? 0 : 175,
                            showInLegend: true
                        }
                    }
                });
            } else {
                vm.chart.update({
                    chart: {
                        type: 'column',
                        inverted: vm.Filtros.TipoGrafico === "barras",
                        polar: vm.Filtros.TipoGrafico === "polar",
                        options3d: {
                            enabled: vm.Filtros.TipoGrafico.includes("3d"),
                            alpha: 10,
                            beta: 25,
                            depth: 70
                        }
                    },
                    xAxis: {
                        visible: true
                    },
                    yAxis: {
                        visible: true
                    },
                    plotOptions: {
                        pie: {}
                    }
                });
            }
            vm.chart.update({
                title: {
                    text: vm.AtualizarTituloGrafico()
                },
                legend: {
                    enabled: vm.Filtros.TipoGrafico.includes("rosca")
                }
            });
            vm.chart.series[0].remove();
            vm.chart.addSeries({
                name: 'Total',
                animations: true,
                colorByPoint: true,
                data: [
                    { name: 'Sim', y: vm.Votos.Sim },
                    { name: 'Não', y: vm.Votos.Nao },
                    { name: 'Abstenção', y: vm.Votos.Abstencao },
                    { name: 'Não Votou', y: vm.Votos.Pnrv },
                    { name: 'Ausente', y: vm.Votos.Ausente }
                ],
                shadow: {
                    color: 'white',
                    offsetX: 0,
                    offsetY: 0,
                    width: 5
                }
            });
        }

        vm.Atualizar = function () {
            vm.loading = true;
            vm.ContarVotos();
            $timeout(function() {
                vm.AtualizarGrafico();
                vm.loading = false;
            }, 1500);
        };

        (function initController() {
            $rootScope.FixLayout();

            Highcharts.setOptions({
                lang: {
                    months: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
                    shortMonths: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez'],
                    weekdays: ['Domingo', 'Segunda', 'Terça', 'Quarta', 'Quinta', 'Sexta', 'Sábado'],
                    loading: ['Aguarde! Atualizando o gráfico...'],
                    contextButtonTitle: 'Exportar gráfico',
                    decimalPoint: ',',
                    thousandsSep: '.',
                    downloadJPEG: 'Baixar imagem JPEG',
                    downloadPDF: 'Baixar arquivo PDF',
                    downloadPNG: 'Baixar imagem PNG',
                    downloadSVG: 'Baixar vetor SVG',
                    printChart: 'Imprimir gráfico',
                    rangeSelectorFrom: 'De',
                    rangeSelectorTo: 'Até',
                    rangeSelectorZoom: 'Zoom',
                    resetZoom: 'Limpar Zoom',
                    resetZoomTitle: 'Voltar Zoom para nível 1:1'
                }
            });

            vm.chart = new Highcharts.Chart({
                colors: ['#7cb5ec', '#f45b5b', '#434348', '#f7a35c', '#90ed7d', '#e4d354', '#8085e9', '#f15c80', '#2b908f', '#91e8e1'],
                chart: {
                    renderTo: 'grafico',
                    type: 'column',
                    inverted: true,
                    polar: false,
                    animation: {
                        duration: 1000
                    }
                },
                title: {
                    text: vm.AtualizarTituloGrafico(),
                    style: {
                        "color": "#333333",
                        "fontFamily": "sans-serif",
                        "fontSize": "22px",
                        "fontWeight": "bold"
                    }
                },
                subtitle: {
                    text: 'Fonte: <a href="http://legis.senado.leg.br/dadosabertos/docs/index.html" target="_blank">Dados Abertos Legislativos do Senado Federal</a>'
                },
                xAxis: {
                    categories: ['Sim', 'Não', 'Abstenção', 'Não Votou', 'Ausente']
                },
                yAxis: {
                    allowDecimals: false,
                    min: 0,
                    title: {
                        text: 'Número de votos',
                        style: {
                            "color": "#333333",
                            "fontFamily": "sans-serif",
                            "fontSize": "14px",
                            "fontWeight": "bold"
                        }
                    }
                },
                legend: {
                    align: "right",
                    borderWidth: 2,
                    enabled: false,
                    floating: true,
                    layout: 'vertical',
                    //title: {
                    //    style: { "fontWeight": "bold" },
                    //    text: 'Descrição do Voto'
                    //},
                    verticalAlign: 'middle',
                    x: -100,
                    width: 120
                },
                series: [{}],
                credits: {
                    enabled: false
                }
            });

            vm.ObterSenadorPorChave();
            vm.ListarMateriasAssuntos();
            vm.Atualizar();
        })();
    }
})();