// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$("#submit").click(function () {
    var index = document.getElementById('index').textContent;
    $("#modal_body").html(index);
});


