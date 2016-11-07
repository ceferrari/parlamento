(function () {
    'use strict';

    angular
        .module('app')
        .run(setupFakeBackend);

    function setupFakeBackend($httpBackend) {
        var testUser = { fullName: 'Carlos Eduardo Ferrari', email: 'carled@gmail.com', password: '123456' };

        $httpBackend.whenPOST('/api/authenticate').respond(function (method, url, data) {
            var params = angular.fromJson(data);

            if (params.email === testUser.email && params.password === testUser.password) {
                return [200, { token: 'fake-jwt-token', fullName: testUser.fullName }, {}];
            } else {
                return [200, {}, {}];
            }
        });

        $httpBackend.whenGET(/^\w+.*/).passThrough();
    }
})();