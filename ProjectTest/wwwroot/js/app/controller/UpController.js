'use strict';

myapp.controller('UpController', function ($scope, $http) {

    $scope.pageSize = 5;
    $scope.currentPage = 1;

    $scope.Init = function () {
        $scope.GetDataDoc();
        $scope.GetNameFile();
        $scope.GetDepartment();
        $scope.GetResponsi();
        $scope.GetLocker();
        $scope.GetUploader();
        

    };

    $scope.GetDataDoc = function () {
        $http.post(window.baseUrl + 'Home/GetData', {})
            .then(function (res) {
                console.log(res.data);
                $scope.dataDoc = res.data;
            });
    }



    $scope.AddNew = function (doc) {
        
        var obj = {
            No: doc.no,
            RQE: doc.rqe,
            Nameproj: doc.nameproj,
            Name: doc.name,
            Department: doc.department,
            Responsible: doc.responsible,
            Locker: doc.locker,
            Tdate: doc.tdate,
            Uploader: doc.uploader,
            Year: doc.year,

        }
       
        $http.post(window.baseUrl + 'Home/AddNewDoc', JSON.stringify(obj))
            .then(function (res) {
                if (res.data == true) {
                    Swal.fire({
                        icon: 'success',
                        title: 'Save successfully'
                    })
                } else {
                    Swal.fire({
                        icon: 'error',
                        title: 'Can Not Save'
                    })
                }
                $scope.GetDataDoc();
                $scope.doc.no = null;
                $scope.doc.rqe = null;
                $scope.doc.name = null;
                $scope.doc.nameproj = null;
                $scope.doc.department = null;
                $scope.doc.responsible = null;
                $scope.doc.locker = null;
                $scope.doc.tdate = null;
                $scope.doc.uploader = null;
                $scope.doc.year = null;
                $('#modalAdd').modal('hide');
            });
    }

    $scope.Delete = function (no) {
        Swal.fire({
            title: 'Do you want to delete this Document?',
            text: "",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes'
        }).then(function (result) {
            if (result.value) {
                $http.post(window.baseUrl + 'Home/DeleteDoc', JSON.stringify(no)).then(function (res) {
                    if (res.data == true) {
                        Swal.fire({
                            icon: 'success',
                            title: 'Success'
                        })

                    }
                    $scope.GetDataDoc();
                });
            } else {
                $scope.GetDataDoc();
            }
        })
    }

    $scope.ShowModalEdit = function (name) {
        $('#modalEdit').modal('show');
        $http.post(window.baseUrl + 'Home/DataDoc', JSON.stringify(name))
            .then(function (res) {
                $scope.dataPerDoc = res.data;

                var d = new Date($scope.dataPerDoc.tdate);
                var date = ("0" + d.getDate()).slice(-2);
                var month = ("0" + (d.getMonth() + 1)).slice(-2);
                var year = d.getFullYear();
                $scope.dataPerDoc.tdate = date + '/' + month + '/' + year;
            });
    }

    $scope.GetNameFile = function () {
        $http.post(window.baseUrl + 'Home/GetNameFile', {})
            .then(function (res) {
                console.log(res.data);
                $scope.name = res.data;
            });
    }

    $scope.GetDepartment = function () {
        $http.post(window.baseUrl + 'Home/GetDepartment', {})
            .then(function (res) {
                console.log(res.data);
                $scope.department = res.data;
            });
    }

    $scope.GetResponsi = function () {
        $http.post(window.baseUrl + 'Home/GetRespons', {})
            .then(function (res) {
                console.log(res.data);
                $scope.responsi = res.data;
            });
    }

    $scope.GetLocker = function () {
        $http.post(window.baseUrl + 'Home/GetLocker', {})
            .then(function (res) {
                console.log(res.data);
                $scope.locker = res.data;
            });
    }

    $scope.GetUploader = function () {
        $http.post(window.baseUrl + 'Home/GetUploader', {})
            .then(function (res) {
                console.log(res.data);
                $scope.uploader = res.data;
            });
    }

    $scope.Update = function (dataPerDoc) {

        var d = dataPerDoc.tdate.substr(0, 2);
        var d2 = dataPerDoc.tdate.substr(3, 2);
        var d3 = dataPerDoc.tdate.substr(6, 4);
        $scope.newTdate = d3 + '-' + d2 + '-' + d;
        var obj = {
            No: dataPerDoc.no,
            Name: dataPerDoc.name,
            Department: dataPerDoc.department,
            Locker: dataPerDoc.locker,
            Responsible: dataPerDoc.responsible,
            Tdate: new Date($scope.newTdate),
        }
        $http.post(window.baseUrl + 'Home/UpdateDoc', JSON.stringify(obj))
            .then(function (res) {
                if (res.data == true) {
                    Swal.fire({
                        icon: 'success',
                        title: 'Save successfully'
                    })
                } else {
                    Swal.fire({
                        icon: 'error',
                        title: 'Can Not Save'
                    })
                }
                $scope.GetDataDoc();
                $('#modalEdit').modal('hide');
            });
    }

    $scope.ShowModalAdd = function () {
        $('#modal').modal('show');
    }
    $scope.ResetForm = function () {
        $('form')[0].reset();
    };
});