'use strick';
(function() {
    var app = angular.module("thekidsphone");
    app.filter('checkmark', function() {
        return function(input) {
            return input ? '\u2713' : '\u2718';
        };
    });
}());