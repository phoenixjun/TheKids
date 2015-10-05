'use strict';
(function() {

    var app = angular.module("thekidsphone");
    var phoneCtrl = function ($routeParams) {
        var vm = this;
        vm.phoneId = $routeParams.phoneId;
    }
    app.controller('thekids-phonedetails-controller', ['$routeParams', phoneCtrl]);
}());