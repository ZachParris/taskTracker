"use strict";

app.controller("taskController", ['$scope', '$location', 'taskService', function ($scope, $location, taskService) {
    $scope.taskList = [];
    $scope.newTask = {};

    $scope.addThisTask = function (input) {
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
    $scope.editThisTask = function () {
        taskService.editTask().then(function (post) {
            $scope.taskList.remove(post)
        })
    }
    $scope.getByStatus = function () {
        taskService.getTaskByStatus().then(function (post) {
            $scope.taskList.remove(post)
        })
    }
}]);
