 var  modules = modules || [];
(function () {
    'use strict';
    modules.push('IntakeData');

    angular.module('IntakeData',['ngRoute'])
    .controller('IntakeData_list', ['$scope', '$http', function($scope, $http){

        $http.get('/Api/IntakeData/')
        .then(function(response){$scope.data = response.data;});

    }])
    .controller('IntakeData_details', ['$scope', '$http', '$routeParams', function($scope, $http, $routeParams){

        $http.get('/Api/IntakeData/' + $routeParams.id)
        .then(function(response){$scope.data = response.data;});

    }])
    .controller('IntakeData_create', ['$scope', '$http', '$routeParams', '$location', function($scope, $http, $routeParams, $location){

        $scope.data = {};
        
        $scope.save = function(){
            $http.post('/Api/IntakeData/', $scope.data)
            .then(function(response){ $location.path("IntakeData"); });
        }

    }])
    .controller('IntakeData_edit', ['$scope', '$http', '$routeParams', '$location', function($scope, $http, $routeParams, $location){

        $http.get('/Api/IntakeData/' + $routeParams.id)
        .then(function(response){$scope.data = response.data;});

        
        $scope.save = function(){
            $http.put('/Api/IntakeData/' + $routeParams.id, $scope.data)
            .then(function(response){ $location.path("IntakeData"); });
        }

    }])
    .controller('IntakeData_delete', ['$scope', '$http', '$routeParams', '$location', function($scope, $http, $routeParams, $location){

        $http.get('/Api/IntakeData/' + $routeParams.id)
        .then(function(response){$scope.data = response.data;});
        $scope.save = function(){
            $http.delete('/Api/IntakeData/' + $routeParams.id, $scope.data)
            .then(function(response){ $location.path("IntakeData"); });
        }

    }])

    .config(['$routeProvider', function ($routeProvider) {
            $routeProvider
            .when('/IntakeData', {
                title: 'IntakeData - List',
                templateUrl: '/Static/IntakeData_List',
                controller: 'IntakeData_list'
            })
            .when('/IntakeData/Create', {
                title: 'IntakeData - Create',
                templateUrl: '/Static/IntakeData_Edit',
                controller: 'IntakeData_create'
            })
            .when('/IntakeData/Edit/:id', {
                title: 'IntakeData - Edit',
                templateUrl: '/Static/IntakeData_Edit',
                controller: 'IntakeData_edit'
            })
            .when('/IntakeData/Delete/:id', {
                title: 'IntakeData - Delete',
                templateUrl: '/Static/IntakeData_Delete',
                controller: 'IntakeData_delete'
            })
            .when('/IntakeData/:id', {
                title: 'IntakeData - Details',
                templateUrl: '/Static/IntakeData_Details',
                controller: 'IntakeData_details'
            })
    }])
;

})();
