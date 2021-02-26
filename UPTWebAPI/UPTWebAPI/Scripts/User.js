
    $("#btnSubmit").click(function () {
        var login = new Object();
        var UserName = $('#txtUserName').val();
        var Password = $('#txtPassword').val();

        $.ajax({
        type: "Get",
            url: '/Home/GetUser/',
            data: {UserName: UserName, Password: Password  },
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (value) {
                if (value.RoleID == 1) {

        window.location.href = '/Home/AdminPanel';
                }
                else {
        window.location.href = '/Home/Customer';
                }
            },
            error: function (jqXHR, exception) {
        console.log(exception);
            }
        });


    });

