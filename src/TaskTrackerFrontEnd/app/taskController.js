"use strict";

app.controller("taskController", ['$scope', '$location', 'taskService', function ($scope, $location, taskService) {
    $scope.taskList = [];
    $scope.newTask = {};

    $scope.addNewPost = function (input) {
        console.log(input);
        taskService.addNewTask(input).then(function (response) {
            $scope.taskList.unshift(response.data);
            $scope.newTask = null;
        })
    }

    $scope.getAllTasks = function () {
        taskService.getAllTasks().then(function (response) {
            $scope.taskList = response.data;
            console.log(response.data);
        });
    };

    $scope.removeTask = function () {
        taskService.removeTask().then(function (post) {
            $scope.taskList.remove(post)
        })
    }
}]);
