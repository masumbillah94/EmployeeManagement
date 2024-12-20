
$(document).ready(function () {
    loadEmployeeDataPage(1)
});

function loadEmployeeDataPage(pageNumber) {
    const dataQuery = {
        pageNumber: pageNumber,
        pageSize: 10
    };
    loadEmployees(dataQuery);
}


function getRange(currentPage, pageSize, totalItems) {
    console.log(currentPage, pageSize, totalItems);
    const start = totalItems == 0 ? 0 : (currentPage - 1) * pageSize + 1;
    const end = Math.min(currentPage * pageSize, totalItems);
    return `Showing ${start} to ${end} of ${totalItems}`;
}

function loadEmployees(query) {
    CallApi('GET','Employee', query,
        (data) => {
            populateTable(data, query);
        },
        (err) => {
            console.error(err);
        }
    );

}

function getSearchResult() {
    const employeeName = $('#empSearchName').val();
    const departmentId = $('#empSearchDepartment').val();
    const position = $('#empSearchPosition').val();
    const minPerformanceScore = $('#empmin').val();
    const maxPerformanceScore = $('#empmax').val();
    const dataQuery = {
        employeeName,
        departmentId,
        position,
        minPerformanceScore,
        maxPerformanceScore,
        pageNumber: 1,
        pageSize: 10
    };

    CallApi('GET', 'Employee', dataQuery,
        (data) => {
            populateTable(data, dataQuery);

            $('#searchModal').modal('hide');
        },
        (err) => {
            console.error(err);
        }
    );
}


function populateTable(data, query) {
    const employeeTableBody = $('#employeeBody');
    employeeTableBody.empty();
    console.log("emp data", data);

    $.each(data.data, function (index, employee) {
        employeeTableBody.append(
            '<tr>' +
            '<td>' + employee.name + '</td>' +
            '<td>' + employee.email + '</td>' +
            '<td>' + employee.phone + '</td>' +
            '<td>' + employee.gender + '</td>' +
            '<td>' + employee.position + '</td>' +
            '<td>' + employee.departmentName + '</td>' +
            '<td>' + employee.status + '</td>' +
            '<td>' + (employee.joiningDate ? new Date(employee.joiningDate).toLocaleDateString() : '') + '</td>' +
            '<td style="white-space: nowrap;">' +
            '<button class="btn btn-primary btn-sm" onclick="showEditEmployeeModal(' + employee.id + ')"><i class="fas fa-edit"></i></button> ' +
            '<button class="btn btn-danger btn-sm" onclick="showDeleteEmployeeModal(' + employee.id + ')"><i class="fas fa-trash"></i></button> ' +
            '<button class="btn btn-info btn-sm" onclick="showPerformanceReviewModal(' + employee.id + ')"><i class="fas fa-star"></i></button>' +
            '</td>' +
            '</tr>'
        );
    });

    updatePaginationControls(data.count, query.pageSize, query.pageNumber);
}

function updatePaginationControls(totalItems, pageSize, currentPage) {
    const paginationControls = $('#paginationControls');
    paginationControls.empty();
    const totalPages = Math.ceil(totalItems / pageSize)
        //< li class="page-item" > <a class="page-link" href="#">Previous</a></li >
        //<li class="page-item"><a class="page-link" href="#">Next</a></li>
    for (let i = 1; i <= totalPages; i++) {
        paginationControls.append(
            `<li class="page-item ${i === currentPage ? 'active' : ''}">
                <a class="page-link" href="javascript:void(0);" onclick="loadEmployeeDataPage(${i})">${i}</a>
            </li>`
        );
    }

    const labelOfRange = $('#labelOfRange');
    labelOfRange.empty();
    labelOfRange.append(getRange(currentPage, pageSize, totalItems));
}


function showAddEmployeeModal() {
    getDeparmentDropdown((data) => {
        populateDropdown(data.data, '#empDepartment', 'Department')
    });
    $('#addEmployeeModal').modal('show');
}

function showEditEmployeeModal(id) {
    $('#empUpdateId').val(id);
    getDeparmentDropdown((data) => {
        populateDropdown(data.data, '#empUpdateDepartment', 'Department')
    });

    getEmployeeById(id, (res) => {
        const employeeData = res.data;
        const formattedDate = new Date(employeeData.joiningDate).toISOString().split('T')[0];
        console.log("employeeData", employeeData);
        $('#empUpdateName').val(employeeData.name);
        $('#empUpdateEmail').val(employeeData.email);
        $('#empUpdatePhone').val(employeeData.phone);
        $('#empUpdatePosition').val(employeeData.position);
        $('#empUpdateGender').val(employeeData.gender); 
        $('#empUpdateStatus').val(employeeData.status);
        $('#empUpdateJoiningDate').val(formattedDate);
        $('#empUpdateDepartment').val(employeeData.departmentId);
        $('#editEmployeeModal').modal('show');
    });
    $('#editEmployeeModal').modal('show');
}

function showDeleteEmployeeModal(id) {
    $('#empDeleteId').val(id);
    $('#deleteEmployeeModal').modal('show');
}

function showPerformanceReviewModal(id) {
    $('#empPRId').val(id);
    $('#performanceReviewModal').modal('show');
}

function showSearchModal() {
    getDeparmentDropdown((data) => {
        populateDropdown(data.data, '#empSearchDepartment', 'Department')
    });
    $('#searchModal').modal('show');
}



function deleteEmployee() {
    const id = $('#empDeleteId').val();
    const data = { id };
    CallApi('DELETE', 'Employee', data,
        (data) => {
            $('#empDeleteId').val(0);
            const queryData = { pageNumber: 1, pageSize: 10 };
            loadEmployees(queryData);
            $('#deleteEmployeeModal').modal('hide');
        },
        (err) => {
            console.error(err);
        }
    );
}

function saveEmployee() {
    const empName = $('#empName').val();
    const empEmail = $('#empEmail').val();
    const empPhone = $('#empPhone').val();
    const empPosition = $('#empPosition').val();
    const empGender = $('#empGender').val();
    const empDepartment = $('#empDepartment').val();
    const empStatus = $('#empStatus').val();
    const empJoiningDate = $('#empJoiningDate').val();
    const inputIds = [
        '#empName',
        '#empEmail',
        '#empPhone',
        '#empPosition',
        '#empGender',
        '#empDepartment',
        '#empStatus',
        '#empJoiningDate'
    ];
    if (!validateForm(inputIds)) {
        retturn;
    }


    const employeeData = {
        Name: empName,
        Email: empEmail,
        Phone: empPhone,
        Position: empPosition,
        Gender: empGender,
        DepartmentId: empDepartment,
        Status: empStatus,
        JoiningDate: empJoiningDate
    };

    CallApi('POST', 'Employee', employeeData,
        (data) => {
            const queryData = { pageNumber: 1, pageSize: 10 };
            loadEmployees(queryData);
            $('#addEmployeeModal').modal('hide');
        },
        (err) => {
            console.log(err);
        }
    )
}

function saveReview() {
    const reviewScore = $('#reviewScore').val();
    const reviewNote = $('#reviewNote').val();
    const empPRId = $('#empPRId').val();
    if (reviewScore > 10 || reviewScore < 0) {
        $('#reviewScore').val(0);
        $('#reviewScore').addClass('is-invalid');
        return
    }
    const reviewData = {
        ReviewScore: reviewScore,
        ReviewNote: reviewNote,
        EmployeeId: empPRId
    };

    CallApi('POST', 'PerformanceReview', reviewData,
        (data) => {
            const queryData = { pageNumber: 1, pageSize: 10 };
            loadEmployees(queryData);
            $('#performanceReviewModal').modal('hide');
        },
        (err) => {
            console.log(err);
        }
    )
}

function updateEmployee() {
    const empId = $('#empUpdateId').val();
    const empName = $('#empUpdateName').val();
    const empEmail = $('#empUpdateEmail').val();
    const empPhone = $('#empUpdatePhone').val();
    const empPosition = $('#empUpdatePosition').val();
    const empGender = $('#empUpdateGender').val();
    const empDepartment = $('#empUpdateDepartment').val();
    const empStatus = $('#empUpdateStatus').val();
    const empJoiningDate = $('#empUpdateJoiningDate').val();

    const employeeData = {
        Id: empId,
        Name: empName,
        Email: empEmail,
        Phone: empPhone,
        Position: empPosition,
        Gender: empGender,
        DepartmentId: empDepartment,
        Status: empStatus,
        JoiningDate: empJoiningDate
    };
    CallApi('PUT', 'Employee', employeeData,
        (data) => {
            const queryData = { pageNumber: 1, pageSize: 10 };
            loadEmployees(queryData);
            $('#editEmployeeModal').modal('hide');
        },
        (err) => {
            console.log(err);
        }
    )
}


function getDeparmentDropdown(sucess) {
    CallApi('GET', 'Department/Dropdown', null,
    
        (data) => {
            sucess(data);
        },
        (err) => {
            console.log(err);
        }
    )
}


function getEmployeeById(employeeId, success) {
    const queryData = { id: employeeId };
    CallApi('GET', 'Employee/ById', queryData,
        (data) => {
            success(data);  
        },
        (err) => {
            console.log(err);  
        }
    );  
}

function populateDropdown(data, id, defaultText = 'One') {
    var dropdown = $(id);

    dropdown.empty();

    dropdown.append('<option value="" selected disabled>Select ' + defaultText +'</option>');
    $.each(data, function (index, item) {
        dropdown.append(
            '<option value="' + item.value + '">' + item.text + '</option>'
        );
    });
}

function validateForm(fields) {
    let isValid = true;

    $('input').removeClass('is-invalid');
    $('select').removeClass('is-invalid');

    $.each(fields, function (index, item) {

        if (!$(item).val()) {
            $(item).addClass('is-invalid');
            isValid = false;
        }
    });

    return isValid;
}

