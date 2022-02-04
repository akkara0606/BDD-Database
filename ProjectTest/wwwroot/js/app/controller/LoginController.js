'use strict';
myapp.controller('LoginController', function ($scope, $http) {

    $scope.Init = function () {
    };

    $scope.GetLgEmp = function () {
        var obj = {
            employee_id: $scope.employee,
            emp_Password: $scope.password,
        }
        console.log(obj)
        $http.post(window.baseUrl + 'Home/GetLgEmp', JSON.stringify(obj))
            .then(function (res) {
                console.log(res.data);
                if (res.data == true) {
                    window.location = window.baseUrl + 'Home/Index';
                } else {
                    Swal.fire({
                        icon: 'error',
                        title: 'Invalid Username or Password'
                        
                    }).then((result) => {
                        console.log(result);
                        if (result.value == true) {
                            window.location.reload();
                        }
                           
                    });

                }
                
            });
    }

});