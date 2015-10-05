'use strict';
(function() {
    var app = angular.module("thekids");
    var kidsCtrl = function() {
        var vm = this;
        vm.kids = [
            { firstname: 'first', lastname: 'last' },
            { firstname: 'first1', lastname: 'last1' }
        ];
        vm.title = 'this is a title';
    };
    
    app.controller("thekids-kids-controller", kidsCtrl);
}());

