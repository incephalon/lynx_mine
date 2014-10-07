$(document).ready(function () {
	$("#goTag").on("click", function () {
		window.location = "/Search/Index?term=" + $("#goText").val();
	});

	$("#goButton").on("click", function () {
		$("#" + $(this).attr("data-iframeId"))
			.attr("src", $('#' + $(this).attr("data-textboxId"))[0].value);
	});
	$(".chosen-select").ajaxChosen({
		type: 'GET',
		url: '/Tag/Index',
		dataType: 'json',
		width: '100%'
	}, function (data) {
		var results = [];

		$.each(data, function (i, val) {
			results.push({ value: val, text: val });
		});
		return results;
	});
	$("#goText").autocomplete({
		source: function (request, response) {
			$.get("/Tag/Index", {
				term: request.term
			}, function (data) {
				response(data);
			});
		},
		//select: function (event, ui) {
		//	$(this).val(ui.item.value);
		//	window.location = "/Search/Index?term=aaa";
		//},
		minLength: 2
	});
	$("[name=Note]").summernote({
		height: 300
	});
});

function Reset()
{
	$(".chosen-select").html("");
	$('.note-editable').html("");
	$('select').trigger('chosen:updated');	
}