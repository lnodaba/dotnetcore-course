﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
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

    //$(document).on("click", "#plus-button", function () {
    //    var currnetCount = $('#counter').html();
    //    $('#counter').html(parseInt(currnetCount) + 1);
    //});

    //$(document).on("click", "#minus-button", function () {
    //    var currnetCount = $('#counter').html();
    //    $('#counter').html(parseInt(currnetCount) - 1);
    //});



    //$(document).on("click", "#searchButton", function (event) {
    //    event.preventDefault();

    //    var searchTerm = $('input[name="searchTerm"]').val();
    //    $("#movies").html("A filmek ide jonnek a " + searchTerm +  "kereses alapjan");
    //});

    $(document).on("click", ".counter-button", function () {
        var valueToAdd = 1;
        if ($(this).attr('id') === "minus-button") {
            valueToAdd = -1;
        }
        var currnetCount = $('#counter').html();
        $('#counter').html(parseInt(currnetCount) + valueToAdd);
    });


    $(document).on("click", ".delete-movie", function () {
        var element = $(this);
        var id = element.attr("id");

        

        $.post("Movie/DeleteMovie/" + id, function (data) {
            if (data === 1) {
                console.log("Post Finished");
                element.parent().remove();
            } else {
                alert("Something went wrong!");
            }
        });

        console.log("Click function Finished");
    });

    
    $.get("Movie/GetFavorites", function (data) {
        data.forEach(function (movieId) {
            var selector = "#star-" + movieId;
            $(selector).find('.star-svg').toggleClass('favourite');
        });
    });

});




$(".star").click(function () {
    var id = $(this).attr("id");
    var movieId = id.split('-')[1];
    var selector = "#" + id;

    var animation_end = 'webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend';

    $(selector).find('.star-svg').toggleClass('favourite');

    $(selector).find('.spark').toggleClass("explode")
        .one(animation_end, function () {
            $(selector).find('.spark').removeClass("explode");
        });

    $(selector).find('.svg-star').toggleClass("pop")
        .one(animation_end, function () {
            $(selector).find('.svg-star').removeClass("pop");
        });

    var isFavorite = $(selector).find('.star-svg').hasClass("favourite");

    $.post("Movie/Favorite/" + movieId, function (data) {
        if (data === 0) {
            alert("Something went wrong!");
        }
    });


});