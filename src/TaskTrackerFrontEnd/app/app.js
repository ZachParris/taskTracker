var app = angular.module('App', ['ngRoute']);

app.config(function ($routeprovider) {
    $routeProvider.when("/", {
        controller: "taskController"
    }).otherwise({ redirectTo: "/" });
})