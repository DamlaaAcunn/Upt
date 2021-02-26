
var InvoicesList = [];

$(document).ready(function () {
    var userViewModel = new Object();
    userViewModel.UserID = $('#UserId').val();
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
    var userViewModel = new Object();
    userViewModel.UserID = $('#UserId').val();
    $.ajax({
        type: "Post",
        url: "https://localhost:44355/api/Invoices/GetExtract",
        data: JSON.stringify(userViewModel),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $('#tblCustomerExtract tbody').empty();

            $.each(data.Result, function (i, item) {
                var rows = "<tr>"
                    + "<td>" + item.InvoiceTitle + "</td>"
                    + "<td>" + item.PaidDate + "</td>"
                    + "<td>" + item.Price + "</td>"
                    + "</tr>";
                $('#tblCustomerExtract tbody').append(rows);
            });

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

