"use strict";

app.service("taskService", function ($http) {

    var addTask = function (post) {
        var data = post;
        return $http.post("http://localhost:50162/api/task", data);
    }
    var getAllTasks = function () {
        return $http.get("http://localhost:50162/api/task").then(function (results) {
            return results;
        });
    }
    var removeTask = function () {
        return $http.get("http://localhost:50162/api/task");
    }
    return {
        addTask: addTask,
        getAllTasks: getAllTasks,
        removeTask: removeTask
    }
})