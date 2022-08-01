// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

$(function () {
    $(".fold-table tr.view").on("click", "td:not(.buttons)", function (event) {
        $(this.parentElement).toggleClass("open").next(".fold").toggleClass("open");
    });
});
