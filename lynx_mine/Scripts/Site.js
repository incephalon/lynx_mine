$(document).ready(function () {
	$("#goButton").on("click", function () {
		$("#" + $(this).attr("data-iframeId"))
			.attr("src", $('#' + $(this).attr("data-textboxId"))[0].value);
	});
	$(".chosen-select").ajaxChosen({
		type: 'GET',
		url: '/Home/Tags',
		dataType: 'json',
		width: '100%'
	}, function (data) {
		var results = [];

		$.each(data, function (i, val) {
			results.push({ value: val.Id, text: val.Name });
		});
		return results;
	});
});
