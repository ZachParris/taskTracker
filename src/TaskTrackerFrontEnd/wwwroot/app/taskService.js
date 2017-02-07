"use strict";

app.service("taskService", function ($http) {

    var addTask = function (post) {
        var data = post;
        return $http.post("http://localhost:57091/api/Values", data);
    }
    var getAllTasks = function () {
        return $http.get("http://localhost:57091/api/Values").then(function (results) {
            return results;
        });
    }
    var removeTask = function () {
        return $http.get("http://localhost:57091/api/Values");
    }
    return {
        addTask: addTask,
        getAllTasks: getAllTasks,
        removeTask: removeTask
    }
})