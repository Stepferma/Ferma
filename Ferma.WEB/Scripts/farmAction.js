$(function () {
    $.ajaxSetup({ cache: false });
    $(".field").click(function(e) {
        $("#divLoader").show();
        e.preventDefault();
        var url = $(this).data('request-url');
        $.get(url,
            function(data) {
                $("#divLoader").hide();
                $('#dialogContent').html(data);
                $('#modDialog').modal('show');
            });
    });

    $("#formPost").submit(function (e) {
        e.preventDefault();
        var form_data = $(this).serialize();
        var url = $(this).data('request-url');
        $.ajax({
            type: "POST",
            url: url, 
            data: form_data,
            success: function () {
                alert('Спасибо, Товар куплен!');
                $('#modDialog').modal('hide');
            }
        });
    });
});
