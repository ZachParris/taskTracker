"use strict";

app.service("taskService", function ($http) {

    var addTask = function (post) {
        var data = post;
        return $http.post("http://localhost:5000/api/Values", data);
    }
    var getAllTasks = function () {
        return $http.get("http://localhost:5000/api/Values").then(function (results) {
            return results;
        });
    }
    var removeTask = function (id) {
        return $http.delete("http://localhost:5000/api/Values/${id}");
    }
    var getTaskByStatus = function () {
        return $http.get("http://localhost:5000/api/Values").then(function (results) {
            return results;
        });
    }
    var editTask = function () {
        return $http.put("http://localhost:5000/api/Values").then(function (results) {
            return results;
        });
    }
    return {
        addTask: addTask,
        getAllTasks: getAllTasks,
        removeTask: removeTask,
        getTaskByStatus: getTaskByStatus,
        editTask: editTask
    }
})