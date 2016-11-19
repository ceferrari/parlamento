(function () {
    'use strict';

    angular
        .module('app')
        .factory('RestService', service);

    function service($resource) {
        //var provider = "http://localhost:54400/:controller/:action/:id";
        var provider = "http://votossenado.net/api/:controller/:action/:id";
        var params = { "controller": "@controller", "action": "@action", "id": "@id" };
        var methods = {
            'get': { method: "GET" },
            'post': { method: "POST" },
            'put': { method: "PUT" },
            'delete': { method: "DELETE" },
            'getArray': { method: "GET", isArray: true },
            'postAndGetArray': { method: "POST", isArray: true }
        };

        return $resource(provider, params, methods);
    }
})();