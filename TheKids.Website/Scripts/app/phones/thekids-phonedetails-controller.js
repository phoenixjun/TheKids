'use strict';
(function() {

    var app = angular.module("thekidsphone",[]);
    var phoneCtrl = function($routeParams, $http) {
        var vm = this;
        vm.phoneId = $routeParams.phoneId;

        $http.get('/content/phones/' + vm.phoneId + '.json')
            .success(function(data) {
                vm.phone = data;
                var imgs = new Array();
                angular.forEach(vm.phone.images, function(value, key) {
                    imgs.push('/content/' + value);
                });
                vm.phone.images = imgs;
            });
    }
    app.controller('thekids-phonedetails-controller', ['$routeParams', '$http', phoneCtrl]);
}());