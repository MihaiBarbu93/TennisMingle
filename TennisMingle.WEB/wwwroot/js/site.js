// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// Data Picker Initialization
$(function () {

    // INITIALIZE DATEPICKER PLUGIN
    $('.form-control').datepicker({
        clearBtn: true,
        format: "dd/mm/yyyy"
    });

});
