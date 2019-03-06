$(function () {
    $.ajaxSetup({ cache: false });
    $(".field").click(function (e) {
          $("#divLoader").show();
        e.preventDefault();
        var url = $(this).data('request-url');
        $.get(url, function (data) {
            $("#divLoader").hide();
            $('#dialogContent').html(data);
            $('#modDialog').modal('show');
        })
    })
});  