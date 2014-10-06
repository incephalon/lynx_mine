$(document).ready(function () {
	$("#goButton").on("click", function () {
		$("#" + $(this).attr("data-iframeId"))
			.attr("src", $('#' + $(this).attr("data-textboxId"))[0].value);
	});
	$("[name=tags]").tagsinput({
	    typeahead: {
	        source: function (query) {
	            return $.get('/tag');
	        }
	    }
	});
});