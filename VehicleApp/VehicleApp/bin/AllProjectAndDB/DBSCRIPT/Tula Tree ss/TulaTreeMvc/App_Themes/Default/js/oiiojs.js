

/*---------20150316-------*/
$(document).ready(function () {
    $("#oiioTable #checkall").click(function () {
        if ($("#oiioTable #checkall").is(':checked')) {
            $("#oiioTable input[type=checkbox]").each(function () {
                $(this).prop("checked", true);
            });

        } else {
            $("#oiioTable input[type=checkbox]").each(function () {
                $(this).prop("checked", false);
            });
        }
    });

    $("[data-toggle=tooltip]").tooltip();
});


/*=================================20150318===================*/

$('.collapse').on('shown.bs.collapse', function () {
    $(this).parent().find(".glyphicon-plus").removeClass("glyphicon-plus").addClass("glyphicon-minus");
}).on('hidden.bs.collapse', function () {
    $(this).parent().find(".glyphicon-minus").removeClass("glyphicon-minus").addClass("glyphicon-plus");
});