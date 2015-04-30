(function () {
    app.controller('employeeCtrl', function ($scope, $http, toastr) {

        //get employees
        $scope.getEmployees = function () {
            $http.get('api/Employee').
            success(function (data, status, headers, config) {
                $scope.paging.pageIndex = $('#grid').dxDataGrid('instance').pageIndex();
                $scope.paging.pageSize = $('#grid').dxDataGrid('instance').pageSize();
                $scope.employees = data;
            }).
            error(function (data, status, headers, config) {
                console.log(data);
                toastr.error('Having trouble getting employees!', 'Error');
            });
        }

        //update employee
        $scope.updateEmployee = function () {
            var employeeFormIsValid = $("#employeeForm").valid();
            if (employeeFormIsValid) {
                $http.put('api/Employee/' + $scope.employeeForm.employee.id, $scope.employeeForm.employee)
                .success(function () {
                    toastr.success($scope.employeeForm.employee.firstName + " " + $scope.employeeForm.employee.lastName + ' was updated!', 'Success!');
                    $scope.employeeForm.visible = false;
                    $scope.getEmployees();
                })
                .error(function () { toastr.error('Having trouble updating ' + $scope.employeeForm.employee.firstName + " " + $scope.employeeForm.employee.lastName + '!', 'Error'); });
            }

        }

        //create employee
        $scope.createEmployee = function () {
            var employeeFormIsValid = $("#employeeForm").valid();

            if (employeeFormIsValid) {
                $http.post('api/Employee', $scope.employeeForm.employee)
                    .success(function () {
                        toastr.success($scope.employeeForm.employee.firstName + " " + $scope.employeeForm.employee.lastName + ' was created!', 'Success!');
                        $scope.employeeForm.visible = false;
                        $scope.getEmployees();
                    })
                    .error(function () { toastr.error('Having trouble creating ' + $scope.employeeForm.employee.firstName + " " + $scope.employeeForm.employee.lastName + '!', 'Error'); });
            }
        }

        //delete employee
        $scope.deleteEmployee = function () {
            $http.delete('api/Employee/' + $scope.employeeForm.employee.id
            ).success(function () {
                toastr.success($scope.employeeForm.employee.firstName + " " + $scope.employeeForm.employee.lastName + ' was deleted!', 'Success!');
                $scope.deletePopUpVisible = false;
                $scope.getEmployees();
            })
             .error(function () { toastr.error('Having trouble deleting ' + $scope.employeeForm.employee.firstName + " " + $scope.employeeForm.employee.lastName + '!', 'Error'); });
        }

        //grid columns
        $scope.columns = ['firstName', 'lastName', 'email',
            {
                width: "200px",
                alignment: 'center',
                cellTemplate: function (container, options) {
                    $('<button/>').addClass("editButton").addClass('dx-button')
                        .html('<span class="glyphicon glyphicon-edit"></span> Edit')
                        .on('dxclick', function () {
                            $scope.showEmployeeForm("edit", options.data, "Edit Employee");
                        })
                        .appendTo(container);
                    $('<button/>').addClass('dx-button')
                        .html('<span class="glyphicon glyphicon-remove"></span> Delete')
                        .on('dxclick', function () {
                            $scope.showDeleteEmployeePopUp(options.data);
                        })
                        .appendTo(container);
                }
            }];

        //show employee form pop up
        $scope.showEmployeeForm = function (submitMethod, employee, popUpTitle) {
            //remove any errors from previous actions
            $('label.error').remove();
            $('input.error').removeClass('error');

            $scope.employeeForm.submitMethod = submitMethod;
            $scope.employeeForm.employee = employee;
            $scope.employeeForm.popUpTitle = popUpTitle;
            $scope.employeeForm.visible = true;
        }
        //show delete employee pop up
        $scope.showDeleteEmployeePopUp = function (employee) {
            $scope.employeeForm.employee = employee;
            $scope.deletePopUpVisible = true;
        }

        //bind grid
        $scope.employeeForm = { employee: {} };
        $scope.paging = { pageSize: 5, pageIndex: 0 };
        $scope.getEmployees();

    });
})();