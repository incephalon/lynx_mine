function init_manage_page() {
    $("#goButton").on("click", function () {
        $("#" + $(this).attr("data-iframeId"))
            .attr("src", $('#' + $(this).attr("data-textboxId"))[0].value);
    });

    $(".chosen-select").tokenfield({
        autocomplete: {
            source: function (request, response) {
                $.get("/Tag/Index", {
                    term: request.term
                }, function (data) {
                    response(data);
                });
            },
            minLength: 2,
            delay: 200
        }
    });

    $("[name=Note]").summernote({
        height: 300
    });
}

function Reset() {
    $(".chosen-select").tokenfield('setTokens', null);
    $('.note-editable').html("");
}