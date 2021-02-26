
    $("#Deposit").hide();
    $("#Close").hide();
    var modal = document.getElementById("myModal");
    //var btn = document.getElementById("myBtn");
    var span = document.getElementsByClassName("close")[0];


    span.onclick = function () {
        modal.style.display = "none";
    }
    window.onclick = function (event) {
        if (event.target == modal) {
        modal.style.display = "none";
        }
    }

    $("#Search").on("keyup", function () {
        var value = $(this).val();
        $("#tblCustomer tr").each(function (index) {
            if (index !== 0) {
                var $row = $(this);
                var matches = $row.find('td').filter(function (ix, item) {
                    return $(item).text().indexOf(value) > -1;
                });
                if (matches.length != 0) {
        $row.show();
                }
                else {
        $row.hide();
                }
            }
        });
    });

    var InvoicesList = [];
    var CustomerClose = [];
    $("#btnCustomer").click(function () {
        var userViewModel = new Object();
        userViewModel.UserName = $('#txtUserName').val();
        userViewModel.IdentityNo = $('#txtIdentity').val();
        userViewModel.TaxNumber = $('#txtTaxNumber').val();
        userViewModel.CustomerStatus = parseInt($('#ddCustomerStatus :selected').val());
        userViewModel.CustomerType = parseInt($('#ddCustomerType :selected').val());
        userViewModel.Email = $('#txtEmail').val();
        userViewModel.Phone = $('#txtPhone').val();
        userViewModel.Adress = $('#txtAdress').val();
        userViewModel.InvoiceNumber = $('#txtInvoiceNumber').val();
        userViewModel.InvoiceTitle = $('#txtInvoiceTitle').val();
        userViewModel.InvoiceDescription = $('#txtDescription').val();
        userViewModel.Price = $('#txtPrice').val();
        userViewModel.Deposit = $('#txtDeposit').val();
        userViewModel.InvoiceType = parseInt($('#ddInvoiceType :selected').val());

        $.ajax({
        type: "Post",
            url: "https://localhost:44355/api/Customer/InsertCustomer",
            data: JSON.stringify(userViewModel),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (value) {
        alert("Abone eklendi");
                window.location.href = '/Home/Customer';
            },
            error: function (jqXHR, exception) {

    }
        });
    });

    $("#btnGetInvoices").click(function () {
        var userViewModel = new Object();

        userViewModel.IdentityNo = $('#txtIdentityNumber').val();
        userViewModel.TaxNumber = $('#txtTaxNumberInvoice').val();

        $.ajax({
        type: "Post",
            url: "https://localhost:44355/api/Invoices/GetInvoices",
            data: JSON.stringify(userViewModel),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
        $('#tblCustomerInvoices tbody').empty();

                $.each(data.Result, function (i, item) {
                    var rows = "<tr>"
                        + "<td>" + item.CustomerId + "</td>"
                        + "<td>" + item.InvoicesId + "</td>"
                        + "<td>" + item.UserName + "</td>"
                        + "<td>" + item.Email + "</td>"
                        + "<td>" + item.Phone + "</td>"
                        + "<td>" + item.TaxNumber + "</td>"
                        + "<td>" + item.IdentityNo + "</td>"
                        + "<td>" + item.InvoiceNumber + "</td>"
                        + "<td>" + item.InvoiceTitle + "</td>"
                        + "<td>" + item.PaymentDate + "</td>"
                        + "<td>" + item.Price + "</td>"
                        + "<td> <input type='checkbox' value='" + item.InvoicesId + "' /> </td>"
                        + "</tr>";
                    $('#tblCustomerInvoices tbody').append(rows);
                });
                $('#tblCustomerInvoices').on('change', 'input[type="checkbox"]', function () {
        InvoicesList.push($(this)[0].value);

                })
            },
            error: function (jqXHR, exception) {

    }
        });
    });
    $(document).ready(function () {
        $.ajax({
            url: "https://localhost:44355/api/Customer/GetCustomer",
            type: 'Get',
            data: {},
            dataType: 'json',
            async: false,
            success: function (data) {
                $('#tblCustomer tbody').empty();
                $.each(data.Result, function (i, item) {
                    var rows = "<tr>"
                        + "<td>" + item.CustomerId + "</td>"
                        + "<td>" + item.UserName + "</td>"
                        + "<td>" + item.Email + "</td>"
                        + "<td>" + item.Phone + "</td>"
                        + "<td>" + item.TaxNumber + "</td>"
                        + "<td>" + item.IdentityNo + "</td>"
                        + "<td>" + item.Register + "</td>"
                        + "<td> <input type='checkbox' id = 'Close' value='" + item.CustomerId + "' /> </td>"
                        + "</tr>";
                    $('#tblCustomer tbody').append(rows);
                });
                $('#tblCustomer').on('change', 'input[type="checkbox"]', function () {
                    if ($(this)[0].checked == true) {
                        CustomerClose.push($(this)[0].value);
                        var modal = document.getElementById("myModal");
                        modal.style.display = "block";
                        var depositData = [];
                        for (var i = 0; i < data.Result.length; i++) {
                            if ($(this)[0].value == data.Result[i].CustomerId) {
                                depositData.push(data.Result[i]);
                            }
                        }
                        $('#tblDeposit tbody').empty();
                        $.each(depositData, function (i, item) {
                            var rows = "<tr>"
                                + "<td>" + item.CustomerId + "</td>"
                                + "<td>" + item.UserName + "</td>"
                                + "<td>" + item.Email + "</td>"
                                + "<td>" + item.Phone + "</td>"
                                + "<td>" + item.TaxNumber + "</td>"
                                + "<td>" + item.IdentityNo + "</td>"
                                + "<td>" + item.Register + "</td>"
                                + "<td>" + item.Deposit + "</td>"
                                + "<td>" + item.IsDepositPayment + "</td>"
                                + "</tr>";
                            $('#tblDeposit tbody').append(rows);
                        });
                        if (depositData[0].IsDepositPayment == "İade Edilmedi") {
                            $("#Deposit").show()
                        }
                        else {
                            $("#Close").hide();
                            $("#Deposit").hide()
                        }
                    }

                })
            },
            error: function (request, status, error) {
                console(error.message);
            }
        });
    });

    $("#btnSubmit").click(function () {
        var login = new Object();
        login.UserName = $('#txtUserName').val();
        login.Password = $('#txtPassword').val();

        $.ajax({
        type: "Post",
            url: "https://localhost:44355/api/Login/GetUsers",
            data: JSON.stringify(login),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (value) {
                if (value.RoleID == 1) {
        window.location.href = '/Home/AdminPanel';
                }
                else {

    }
            },
            error: function (jqXHR, exception) {

    }
        });


    });
    $("#btnInvoices").click(function () {
        var userViewModel = new Object();
        userViewModel.InvoicesIdList = InvoicesList;
        userViewModel.PaymentType = parseInt($('#ddPaymentTypes :selected').val());

        $.ajax({
        type: "Post",
            url: "https://localhost:44355/api/Payment/UpdatePayment",
            data: JSON.stringify(userViewModel),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (value) {
        alert('Fatura Ödendi.');
                InvoicesList = [];
            },
            error: function (jqXHR, exception) {

    }
        });
    });
    $("#Deposit").click(function () {
        var userViewModel = new Object();
        userViewModel.CustomerId = CustomerClose[0];
        $.ajax({
        type: "Post",
            url: "https://localhost:44355/api/Deposit/DepositPayment",
            data: JSON.stringify(userViewModel),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.APIResponse.ResponseDescription != null) {
        alert(data.APIResponse.ResponseDescription);
                }
            },
            error: function (jqXHR, exception) {

    }
        });
    });
