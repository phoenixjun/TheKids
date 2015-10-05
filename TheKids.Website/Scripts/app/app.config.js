'use strict';
var app = angular.module("thekids", ['ngRoute', 'thekidsphone']);
app.config(['$routeProvider',
  function ($routeProvider) {
      $routeProvider.when('/phone/index', {
            templateUrl: '/content/partials/phone-list.html',
            controller: 'thekids-phonelist-controller'
        }).
        when('/phone/:phoneId', {
            templateUrl: '/content/partials/phone-detail.html',
            controller: 'thekids-phonedetails-controller'
        }).
        otherwise({
            redirectTo: '/phone/index'
        });
  }]);