/* AKTİF PASİF DEĞER */
function chkFunc(element) {
    if (!element.checked) {
        document.getElementById("status-result").innerHTML="Pasif";
        document.getElementById("status-result").className = "result-text error";
        document.getElementById("aktifButton").value = false;
    }
    else
    {
        document.getElementById("status-result").innerHTML="Aktif";
        document.getElementById("status-result").className = "result-text success";
        document.getElementById("aktifButton").value = true;
    }
};
function chkFuncx(element) {
    if (!element.checked) {
        document.getElementById("status-result1").innerHTML = "Pasif";
        document.getElementById("status-result1").className = "result-text error";
        document.getElementById("aktifButton1").value = false;
    }
    else {
        document.getElementById("status-result1").innerHTML = "Aktif";
        document.getElementById("status-result1").className = "result-text success";
        document.getElementById("aktifButton1").value = true;
    }
};
function chkFuncy(element) {
    if (!element.checked) {
        document.getElementById("status-result2").innerHTML = "Pasif";
        document.getElementById("status-result2").className = "result-text error";
        document.getElementById("aktifButton3").value = false;
    }
    else {
        document.getElementById("status-result2").innerHTML = "Aktif";
        document.getElementById("status-result2").className = "result-text success";
        document.getElementById("aktifButton3").value = true;
    }
};

$(function () {

    /* SCROLL */
    $(window).on("load", function () {
        if ($(".sidebar-content > a").length > 0) {
            $(".sidebar-content").mCustomScrollbar({
                theme: "light"
            });
        }
    });
    
    /* MENÜ */
    if($(".sidebar-dropdown > a").length > 0){
        $(".sidebar-dropdown > a").click(function () {
            $(".sidebar-submenu").slideUp(200);
            if (
                $(this)
                .parent()
                .hasClass("active")
            ) {
                $(".sidebar-dropdown").removeClass("active");
                $(this)
                    .parent()
                    .removeClass("active");
            } else {
                $(".sidebar-dropdown").removeClass("active");
                $(this)
                    .next(".sidebar-submenu")
                    .slideDown(200);
                $(this)
                    .parent()
                    .addClass("active");
            }
        });
    }

    /* MENÜ */
    if($("#close-sidebar").length > 0){
        $("#close-sidebar").click(function () {
            $(".page-wrapper").removeClass("toggled");
        });
    }

    /* SIDEBAR */
    if($("#show-sidebar").length > 0){
        $("#show-sidebar").click(function () {
            $(".page-wrapper").addClass("toggled");
        });
    }

    /* DATATABLE + LANGUAGE */
    if ($(".datatable").length > 0) {
        $('.datatable').DataTable({
            "language": {
                "decimal": "",
                "emptyTable": "Tabloda herhangi bir veri mevcut değil",
                "info": "_TOTAL_ kayıttan _START_ - _END_ arasındaki kayıtlar gösteriliyor",
                "infoEmpty": "Kayıt yok",
                "infoFiltered": "(_MAX_ kayıt içerisinden bulunan)",
                "infoPostFix": "",
                "thousands": ",",
                "lengthMenu": "Sayfada _MENU_ kayıt göster",
                "loadingRecords": "Yükleniyor...",
                "processing": "İşleniyor...",
                "search": "Ara:",
                "zeroRecords": "Eşleşen kayıt bulunamadı",
                "paginate": {
                    "first": "İlk",
                    "last": "Son",
                    "next": "Sonraki",
                    "previous": "Önceki"
                },
                "aria": {
                    "sortAscending": ": artan sütun sıralamasını aktifleştir",
                    "sortDescending": ": azalan sütun sıralamasını aktifleştir"
                }
            }
        });
    }

    /* BS4 TOOLTIP */
    if($("[data-toggle='tooltip']").length > 0){
        $('[data-toggle="tooltip"]').tooltip();
    }

    /* UPLOAD INPUT */
    if($(".input-file").length > 0){
        $('.input-file').each(function() {
            var $input = $(this),
                $label = $input.next('.js-labelFile'),
                labelVal = $label.html();
            
            $input.on('change', function(element) {
                var fileName = '';
                if (element.target.value) fileName = element.target.value.split('\\').pop();
                fileName ? $label.addClass('has-file').find('.js-fileName').html(fileName) : $label.removeClass('has-file').html(labelVal);
            });
        });
    }

    /* TÜM SHOWHIDE İŞLERİ */
    if($(".showHide").length > 0){
        $(".showHide").on("click", function(){
            $(".showHideArea").fadeToggle();
        });
    }

    /* SELECTBOX PLUGIN */
    if($(".select2").length > 0){
        $('.select2').select2();
    }

    if ($(".date").length > 0) {
        $('.date').datepicker({
            multidate: true,
            format: 'dd-mm-yyyy'
        });
    }


    /* FİNAL */
    console.log("Success");

});


/* MOBIL NAVBAR */
if($(window).innerWidth() <= 767) {
    $(".page-wrapper").removeClass("toggled");
} 