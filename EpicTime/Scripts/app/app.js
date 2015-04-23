var CONSTANT_SUCCESS = "success";
var CONSTANT_ERROR = "error";

var app = angular.module('EpicTime', ['ngRoute', 'dx', 'angular-loading-bar','ngAnimate', 'toastr']);

app.config(function ($routeProvider) {

    $routeProvider.when("/home", {
        controller: "homeController",
        templateUrl: "/app/views/home.html"
    });

    $routeProvider.when("/employeeAdmin", {
        controller: "employeeCtrl",
        templateUrl: "/app/views/employeeAdmin.html"
    });

    $routeProvider.when("/refresh", {
        controller: "refreshController",
        templateUrl: "/app/views/refresh.html"
    });

    $routeProvider.when("/tokens", {
        controller: "tokensManagerController",
        templateUrl: "/app/views/tokens.html"
    });

    $routeProvider.when("/associate", {
        controller: "associateController",
        templateUrl: "/app/views/associate.html"
    });

    $routeProvider.otherwise({ redirectTo: "/home" });

});

