var CONSTANT_SUCCESS = "success";
var CONSTANT_ERROR = "error";

var app = angular.module('EpicTime', ['ngRoute', 'dx', 'angular-loading-bar','ngAnimate', 'toastr']);

app.config(function ($routeProvider) {

    $routeProvider.when("/home", {
        templateUrl: "scripts/app/views/home.html"
    });

    $routeProvider.when("/employeeAdmin", {
        controller: "employeeCtrl",
        templateUrl: "scripts/app/views/employeeAdmin.html"
    });

    $routeProvider.when("/clientAdmin", {
        templateUrl: "scripts/app/views/clientAdmin.html"
    });

    $routeProvider.otherwise({ redirectTo: "/home" });

});

