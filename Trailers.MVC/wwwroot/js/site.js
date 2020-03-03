// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//TODO:
/*
 * Add Button click.
 * Background request to the server.
 * Receive movies.
 * Replace content of the movies div.
 */

$(document).ready(function () {
    $(document).on("click", "#searchButton", function (event) {
        event.preventDefault();

        var searchTerm = $('input[name="searchTerm"]').val();
        $("#movies").html("A filmek ide jonnek a " + searchTerm +  "kereses alapjan");
    });
});