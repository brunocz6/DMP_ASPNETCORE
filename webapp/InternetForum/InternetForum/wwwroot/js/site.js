// Write your JavaScript code.

// Menší hack pro přidání potřebných class paging elementům.
$(() => {
	$(".redirector").click(function () {
		window.location = this.dataset.url;
	});

	$(".pagination").find("li").addClass("page-item");
	$(".pagination").find("a").addClass("page-link");
});