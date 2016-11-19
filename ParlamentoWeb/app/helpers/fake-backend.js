(function () {
    'use strict';

    angular
        .module('app')
        .run(setupFakeBackend);

    function setupFakeBackend($httpBackend) {
        var usuario = { nomeCompleto: 'Carlos Eduardo Ferrari', email: 'carled@gmail.com', senha: '123456' };

        $httpBackend.whenPOST('/api/authenticate').respond(function (method, url, data) {
            var params = angular.fromJson(data);

            if (params.email === usuario.email && params.senha === usuario.senha) {
                return [200, { token: 'fake-jwt-token', nomeCompleto: usuario.nomeCompleto }, {}];
            } else {
                return [200, {}, {}];
            }
        });

        $httpBackend.whenGET(/^\w+.*/).passThrough();
    }
})();