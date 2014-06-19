/// <reference path="jquery-2.1.1.js" />
$(document).ready(function () {
    var employees = [];
    $("#btnGetTime").click(function () {
        $.ajax({
            type: "POST",
            url: "Home.aspx/GetCurrentTime",
            data: JSON.stringify({ name: $('#txtUserName').val() }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccess,
            failure: function (response) {
                alert(response.d);
            }
        });

        function OnSuccess(response) {
            alert(response.d);
        }
    });
    $("#btUpdate").click(function () {
        
        packageUser();
        var webMethod = "Home.aspx/updateEmployees";
        $('.overlay').fadeIn(100);
        $.ajax({
            type: "POST",
            url: "Home.aspx/updateEmployees",
            data: "{'lsEMP':" + JSON.stringify(employees) + "}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccess,
            failure: function (response) {
                alert(response.d);
            }
        });
        function OnSuccess(response) {
            alert(response.d);
            $('.overlay').fadeOut();
        }
        
        event.preventDefault();

    });

    $("#btnGV").click(function () {
        $("#xmlTable").hide();
    });
    
    function packageUser() {
        var rowCount = $("#xmlTable tr").length;

        for (var i = 1; i < rowCount; i++) {
            var usr = {
                id: $('#id' + i).html(),
                firstname: $('#firstName' + i).html(),
                lastName: $('#lastName' + i).html(),
                age: $('#age' + i).html(),
                department: $('#department' + i).html()
            };
            employees.push(usr);
        };
        return employees;
    }

    
});


