'use strict';

myapp.controller('ListController', function ($scope, $http) {
    $scope.Init = function () {
        $scope.GetDataDoc();
        $scope.GetDataRqe();
        $scope.GetDataQua();
        $scope.GetDataInv();
    };

    $scope.GetDataDoc = function () {
        $http.post(window.baseUrl + 'Home/GetData', {})
            .then(function (res) {
                console.log(res.data);
                $scope.dataDoc = res.data;
            });
    }

    $scope.GetDataRqe = function () {
        $http.post(window.baseUrl + 'Home/GetDataRqe', {})
            .then(function (res) {
                console.log(res.data);
                $scope.rqe = res.data;
            });
    }

   

    $scope.GetDataQua = function () {
        $http.post(window.baseUrl + 'Home/GetDataQua', {})
            .then(function (res) {
                console.log(res.data);
                $scope.qua = res.data;
            });
    }

    $scope.GetDataInv = function () {
        $http.post(window.baseUrl + 'Home/GetDataInv', {})
            .then(function (res) {
                console.log(res.data);
                $scope.inv = res.data;
            });
    }

    $scope.ShowModalDetail = function (no) {
        $('#modalDetail').modal('show');
        $http.post(window.baseUrl + 'Home/DataDoc', JSON.stringify(no))
            .then(function (res) {
                $scope.dataPerDoc = res.data;
            });
    }


    $scope.ResetForm = function () {
        $('form')[0].reset();
    };
});