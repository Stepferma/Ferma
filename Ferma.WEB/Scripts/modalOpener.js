$(function () {
    $.ajaxSetup({ cache: false });
    $(".openModel").click(function (e) {
        $("#divLoader").show();
        e.preventDefault();
        $.get(this.href, function (data) {
            $("#divLoader").hide();
            $('#dialogContent').html(data);
            $('#modDialog').modal('show');
        })
    })
});  