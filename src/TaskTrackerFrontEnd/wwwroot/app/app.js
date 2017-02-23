var app = angular.module('App', ['ngRoute']);

app.config(function ($routeProvider) {
    $routeProvider.when("/", {
        controller: "taskController",
        templateUrl: "index.html"
    }).otherwise({ redirectTo: "/" });
})