(function () {
    'use strict';

    angular
        .module('app')
        .controller('Senador.Votos', controller);

    function controller($rootScope, $state, $stateParams, $timeout, RestService, EstadosBrasileiros) {
        var vm = this;
        
        vm.CodigoSenador = null;
        vm.CodigoMateria = null;
        vm.CodigoSessao = null;
        vm.CodigoAutorMateria = null;
        vm.CodigoAssuntoMateria = null;
        vm.CodigoSubtipoMateria = null;
        vm.MateriaAssuntoGeral = null;
        vm.MateriaAssuntoEspecifico = null;
        vm.TipoGrafico = "colunas";
        vm.TituloGrafico = 'Votos sobre todas as Matérias';
        vm.Votos = {
            Sim: 0,
            Nao: 0,
            Abstencao: 0,
            Pnrv: 0,
            Ausente: 0
        };

        (function initController() {
            $rootScope.FixLayout();

            RestService.get({
                controller: "Senadores", action: "ObterPorChave", id: $stateParams.id
            }, function (resultado) {
                vm.Senador = resultado;
            });

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
        })();

        vm.EstadoPorSigla = function (sigla) {
            var estados = EstadosBrasileiros.filter(function (obj) { return obj.Sigla === sigla });
            return estados ? estados[0].Nome : sigla;
        };

        vm.ListarMateriasAssuntos = function () {
            RestService.getArray({
                controller: "MateriasAssuntos", action: "Listar",
                ordenarPor: "AssuntoEspecifico"
            }, function (resultado) {
                vm.MateriasAssuntos = resultado;
                vm.MateriasAssuntosGerais = Array.from(new Set(resultado.map(function (obj) { return obj.AssuntoGeral })));
            });
        };

        vm.ContarVotos = function () {
            RestService.get({
                controller: "Votos", action: "Contar",
                senador: $stateParams.id,
                materia: vm.CodigoMateria,
                sessao: vm.CodigoSessao,
                autorMateria: vm.CodigoAutorMateria,
                assuntoGeralMateria: vm.MateriaAssuntoGeral,
                assuntoEspecificoMateria: vm.CodigoAssuntoMateria,
                subtipoMateria: vm.CodigoSubtipoMateria,
                descricaoVoto: "Sim"
            }, function (resultado) {
                vm.Votos.Sim = resultado.Total;
            });
            RestService.get({
                controller: "Votos", action: "Contar",
                senador: $stateParams.id,
                materia: vm.CodigoMateria,
                sessao: vm.CodigoSessao,
                autorMateria: vm.CodigoAutorMateria,
                assuntoGeralMateria: vm.MateriaAssuntoGeral,
                assuntoEspecificoMateria: vm.CodigoAssuntoMateria,
                subtipoMateria: vm.CodigoSubtipoMateria,
                descricaoVoto: "Não"
            }, function (resultado) {
                vm.Votos.Nao = resultado.Total;
            });
            RestService.get({
                controller: "Votos", action: "Contar",
                senador: $stateParams.id,
                materia: vm.CodigoMateria,
                sessao: vm.CodigoSessao,
                autorMateria: vm.CodigoAutorMateria,
                assuntoGeralMateria: vm.MateriaAssuntoGeral,
                assuntoEspecificoMateria: vm.CodigoAssuntoMateria,
                subtipoMateria: vm.CodigoSubtipoMateria,
                descricaoVoto: "Abstenção"
            }, function (resultado) {
                vm.Votos.Abstencao = resultado.Total;
            });
            RestService.get({
                controller: "Votos", action: "Contar",
                senador: $stateParams.id,
                materia: vm.CodigoMateria,
                sessao: vm.CodigoSessao,
                autorMateria: vm.CodigoAutorMateria,
                assuntoGeralMateria: vm.MateriaAssuntoGeral,
                assuntoEspecificoMateria: vm.CodigoAssuntoMateria,
                subtipoMateria: vm.CodigoSubtipoMateria,
                descricaoVoto: "P-NRV"
            }, function (resultado) {
                vm.Votos.Pnrv = resultado.Total;
            });
            RestService.get({
                controller: "Votos", action: "Contar",
                senador: $stateParams.id,
                materia: vm.CodigoMateria,
                sessao: vm.CodigoSessao,
                autorMateria: vm.CodigoAutorMateria,
                assuntoGeralMateria: vm.MateriaAssuntoGeral,
                assuntoEspecificoMateria: vm.CodigoAssuntoMateria,
                subtipoMateria: vm.CodigoSubtipoMateria,
                descricaoVoto: "Ausente"
            }, function (resultado) {
                vm.Votos.Ausente = resultado.Total;
            });
        };

        vm.AtualizarTituloGrafico = function () {
            if (vm.CodigoAssuntoMateria) {
                //vm.MateriaAssuntoGeral = vm.MateriasAssuntos.filter(function (obj) { return obj.Codigo === vm.CodigoAssuntoMateria })[0].AssuntoGeral;
                vm.MateriaAssuntoEspecifico = vm.MateriasAssuntos.filter(function (obj) { return obj.Codigo === vm.CodigoAssuntoMateria })[0].AssuntoEspecifico;
                vm.TituloGrafico = 'Votos sobre Matérias do assunto "' + vm.MateriaAssuntoEspecifico + '"';
            } else {
                if (vm.MateriaAssuntoGeral && !vm.CodigoAssuntoMateria) {
                    vm.TituloGrafico = 'Votos sobre Matérias do assunto "' + vm.MateriaAssuntoGeral + '"';
                } else {
                    vm.TituloGrafico = 'Votos sobre todas as Matérias';
                }
            }
        };

        vm.OpcoesGrafico = {
            colors: ['#7cb5ec', '#f45b5b', '#434348', '#f7a35c', '#90ed7d', '#e4d354', '#8085e9', '#f15c80', '#2b908f', '#91e8e1'],
            chart: {
                renderTo: 'grafico',
                type: 'column',
                inverted: true,
                polar: false
            },
            title: {
                text: vm.TituloGrafico,
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
            series: [{
                name: 'Total',
                colorByPoint: true,
                data: [
                    { name: 'Sim', y: vm.Votos.Sim },
                    { name: 'Não', y: vm.Votos.Nao },
                    { name: 'Abstenção', y: vm.Votos.Abstencao },
                    { name: 'Não Votou', y: vm.Votos.Pnrv },
                    { name: 'Ausente', y: vm.Votos.Ausente }
                ],
                shadow: {
                    width: 5,
                    offsetX: 0,
                    offsetY: 0
                }
            }],
            credits: {
                enabled: false
            }
        };

        vm.CriarGrafico = function() {
            vm.chart = new Highcharts.Chart(vm.OpcoesGrafico);
        };

        vm.AtualizarGrafico = function () {
            vm.chart.update({
                title: {
                    text: vm.TituloGrafico
                },
                legend: {
                    enabled: vm.TipoGrafico.includes("rosca")
                },
                series: [{
                    data: [
                        { name: 'Sim', y: vm.Votos.Sim },
                        { name: 'Não', y: vm.Votos.Nao },
                        { name: 'Abstenção', y: vm.Votos.Abstencao },
                        { name: 'Não Votou', y: vm.Votos.Pnrv },
                        { name: 'Ausente', y: vm.Votos.Ausente }
                    ]
                }]
            });
            if (vm.TipoGrafico.includes("pizza") || vm.TipoGrafico.includes("rosca")) {
                vm.chart.update({
                    chart: {
                        type: 'pie',
                        inverted: false,
                        polar: false,
                        options3d: {
                            enabled: vm.TipoGrafico.includes("3d"),
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
                                    return vm.TipoGrafico.includes("pizza")
                                        ? this.point.name + ': ' + Math.round(this.percentage) + ' %'
                                        : Math.round(this.percentage) + ' %';
                                },
                                distance: vm.TipoGrafico.includes("pizza") ? 30 : -30,
                                color: vm.TipoGrafico.includes("pizza") ? 'black' : 'white'
                            },
                            depth: 45,
                            innerSize: vm.TipoGrafico.includes("pizza") ? 0 : 175,
                            showInLegend: true
                        }
                    }
                });
            } else {
                vm.chart.update({
                    chart: {
                        type: 'column',
                        inverted: vm.TipoGrafico === "barras",
                        polar: vm.TipoGrafico === "polar",
                        options3d: {
                            enabled: vm.TipoGrafico.includes("3d"),
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
        }

        vm.Atualizar = function (event) {
            if (!event || event.keyCode === 13) {
                vm.loading = true;
                vm.ContarVotos();
                vm.AtualizarTituloGrafico();
                $timeout(function() {
                    vm.AtualizarGrafico();
                    vm.loading = false;
                }, 500);
            }
        };

        vm.ListarMateriasAssuntos();
        vm.CriarGrafico();
        vm.Atualizar();
    }
})();