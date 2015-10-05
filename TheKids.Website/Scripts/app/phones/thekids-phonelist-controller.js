'use strict';
(function () {

    var app = angular.module("thekidsphone");
    var phoneCtrl = function ($http) {
        
        var vm = this;
        vm.orderProp = 'age';
        $http.get('/Content/phones/phones.json').success(function (data) {
            vm.phones = data.splice(0, 5);
            angular.forEach(vm.phones, function(value, key) {
                value.imageUrl = '/Content/' + value.imageUrl;
            });
        });
    };
    app.controller('thekids-phonelist-controller', ['$http', phoneCtrl]);
}());