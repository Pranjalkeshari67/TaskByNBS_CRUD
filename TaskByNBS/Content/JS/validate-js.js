// For Registration Start*
function onSubmitEmployeeRegForm(e, t) {
    debugger;
    var employeeName = $("#EmployeeName").val();
    var employeeSalary = $("#EmployeeSalary").val();
    var employeeDOJ = $("#EmployeeDOJ").val();
    var employeeGender = $("#EmployeeGender").val();
    var employeeProfile = $("#uplodBGFile").text();
    var employeeProfileHidden = $("#EmployeeProfile").val();

    if (employeeName == '') {
        swal("Employee Name is mandatory.");
        return false;
    }


    if (employeeSalary == '') {
        swal("Salary is mandatory.");
        return false;
    }
    

    if (employeeDOJ == '') {
        swal("Date Of Journey is mandatory.");
        return false;
    }

    if (employeeGender == '') {
        swal("Gender is mandatory.");
        return false;
    }
    debugger;

    if (employeeProfile == '') {
        swal("Employee Image is mandatory.");
        return false;
    }

    if (employeeProfileHidden == '') {
        swal("Employee Image is mandatory.");
        return false;
    }

    if (employeeName != '' && employeeSalary != '' && employeeDOJ != '' && employeeGender != '' && employeeProfile != '' && employeeProfileHidden != '') {
        $(t).attr("action", "/Home/Registration");
    }

}
// For Registration End*

// For File Type Check ** Start **
function GetFileNameAndUpload(obj) {
    debugger;
    var img = $(obj).val();
    var extension = img.substring(img.lastIndexOf(".") + 1, img.length);
    if (extension == "jpeg" || extension == "jpg" || extension == "png" || extension == "JPEG" || extension == "JPG" || extension == "PNG") {
        var path = img.substring(img.lastIndexOf("\\") + 1, img.length);
        $("#uplodBGFile").text(path);
        $("#EmployeeProfile").val(path);
        if (window.FormData !== undefined) {
            var path = img.substring(img.lastIndexOf("\\") + 1, img.length);
            $("#uplodBGFile").text(path);
            var fileUpload = $("#BGBannerImgg").get(0);
            var files = fileUpload.files;
            var fileData = new FormData();
            for (var i = 0; i < files.length; i++) {
                fileData.append(files[i].name, files[i]);
            }
            fileData.append('username', 'TaskByNBS');
            $.ajax({
                url: '/Home/UploadFiles',
                type: "POST",
                contentType: false,
                processData: false,
                data: fileData,
                success: function (result) {
                },
                error: function (err) {
                    swal(err.statusText);
                }
            });
        } else {
            swal({ title: "Error", text: "FormData is not supported.", icon: "warning" });
        }
    } else {
        swal({ title: "Error", text: "Please attach only JPEG,JPG or PNG type file !", icon: "warning" });
    }
}
// For File Type Check ** End **


// For Delete ** Start **
function onClickDelete(e, t)
{
    var x = confirm("Are you sure ?");
    if (x) {
        debugger;
        var ob = { EmployeeId: $(t).data("emid") };
        $.ajax({
            url: "/Home/DeleteEmployee",
            method: "POST",
            data: JSON.stringify(ob),
            dataType: "json",
            contentType: "application/json",
            success: function (data) {
                if (data == "ok") {
                    swal("Deleted Successfully !");
                    setTimeout(function () {
                        location.reload(true);
                    }, 1500);
                } else {
                    swal("Sorry ! Unable to delete.")
                }
            },
            error: function (error) {
                swal("Some Error Occurred");
            }
        })
        return true;
    }
    else {
        swal("Make sure to be deleted !");
        return false;
    }

}
// For Delete ** End **


// For Updation Start*
function onSubmitEmployeeUpdateRegForm(e, t) {

    var employeeName = $("#EmployeeName").val();
    var employeeSalary = $("#EmployeeSalary").val();
    var employeeDOJ = $("#EmployeeDOJ").val();
    var employeeGender = $("#EmployeeGender").val();
    var employeeProfile = $("#uplodUpdateBGFile").text();

    if (employeeName == '') {
        swal("Employee Name is mandatory.");
        return false;
    }

    if (employeeSalary == '') {
        swal("Salary is mandatory.");
        return false;
    }

    if (employeeDOJ == '') {
        swal("Date Of Journey is mandatory.");
        return false;
    }

    if (employeeGender == '') {
        swal("Gender is mandatory.");
        return false;
    }

    if (employeeProfile == '') {
        swal("Employee Image is mandatory.");
        return false;
    }

    if (employeeName != '' && employeeSalary != '' && employeeDOJ != '' && employeeGender != '' && ( employeeProfile != '' )) {
        $(t).attr("action", "/Home/UpdateEmployeeDetails");
    }

}
// For Updation End*

// For File Type Check ** Start **
function GetFileNameAndUploadForUpdation(obj) {
    debugger;
    var img = $(obj).val();
    var extension = img.substring(img.lastIndexOf(".") + 1, img.length);
    if (extension == "jpeg" || extension == "jpg" || extension == "png" || extension == "JPEG" || extension == "JPG" || extension == "PNG") {
        var path = img.substring(img.lastIndexOf("\\") + 1, img.length);
        $("#uplodUpdateBGFile").show();
        $("#EmployeeProf").hide();
        $("#uplodUpdateBGFile").text(path);
        $("#UpdateEmployeeProfile").val(path);
        if (window.FormData !== undefined) {
            var path = img.substring(img.lastIndexOf("\\") + 1, img.length);
            $("#uplodUpdateBGFile").text(path);
            var fileUpload = $("#BGBannerImgg").get(0);
            var files = fileUpload.files;
            var fileData = new FormData();
            for (var i = 0; i < files.length; i++) {
                fileData.append(files[i].name, files[i]);
            }
            fileData.append('username', 'TaskByNBS');
            $.ajax({
                url: '/Home/UploadFiles',
                type: "POST",
                contentType: false,
                processData: false,
                data: fileData,
                success: function (result) {
                },
                error: function (err) {
                    swal(err.statusText);
                }
            });
        } else {
            swal({ title: "Error", text: "FormData is not supported.", icon: "warning" });
        }
    } else {
        swal({ title: "Error", text: "Please attach only JPEG,JPG or PNG type file !", icon: "warning" });
    }
}
// For File Type Check ** End **



function onLoginForm(event, obj) {
    debugger;
    var UserName = $("#UserName").val();
    var UserPassword = $("#UserPassword").val();
    
    if (UserName == '') {
        swal("UserName ( Email / Phone ) is mandatory.");
        return false;
    }

    if (UserPassword == '') {
        swal("Password is mandatory.");
        return false;
    }

    if (UserName != '' && UserPassword != '') {
        $(obj).attr("action", "/Home/Login");
    }
}