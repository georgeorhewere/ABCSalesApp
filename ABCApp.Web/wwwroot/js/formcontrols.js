$(function () {
    // initialize dropdowns
    $('.ui.dropdown')
        .dropdown();
    //datepicker
    $('.datepicker').datepicker({
        autoHide: true,
    });
    //set to current date
    $('.datepicker').datepicker('pick');


})

