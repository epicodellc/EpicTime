
app.controller('employeeCtrl', function ($scope, $http, toastr) {
    $scope.employees = [];


    //get employees
    $http.get('api/Employee').
    success(function (data, status, headers, config) {
        $scope.employees = data;
    }).
    error(function (data, status, headers, config) {
        // log error
        console.log("error");
    });

    //update employee
    $scope.updateEmployee = function (rowInfo) {
        //set up new employee object
        var newEmployee = rowInfo.oldData;
        for (var attrname in rowInfo.newData) { newEmployee[attrname] = rowInfo.newData[attrname] };

        $http.put('api/Employee/' + rowInfo.key.id, rowInfo.oldData)
            .success(function () { toastr.success('Employee updated!', 'Success!'); })
            .error(function () { toastr.error('Having trouble updating an employee!', 'Error'); });
    }

    //create employee
    $scope.createEmployee = function (rowInfo) {
        console.log(rowInfo);
        $http.post('api/Employee', rowInfo.data)
            .success(function () { toastr.success('Employee created!', 'Success!'); })
            .error(function () { toastr.error('Having trouble creating an employee!', 'Error'); });

    }

    //delete employee
    $scope.deleteEmployee = function (rowInfo) {
        $http.delete('api/Employee/' + rowInfo.key.id
        ).success(function () { toastr.success('Employee deleted!', 'Success!'); })
         .error(function () { toastr.error('Having trouble deleting an employee!', 'Error'); });
    }




});
