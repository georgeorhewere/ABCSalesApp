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

    $('#country').change(function () {
        
        $('#state').dropdown('clear');
        $("#state").addClass('loading');
        $.ajax({
            type: "post",
            url: "/Order/GetRegions",
            data: { countryCode: $('#country').val() },
            datatype: "json",
            traditional: true,
            success: function (data) {
                
                $("#state").empty()
                $("#state").append("<option value='' selected='selected'>-- select state --</option>")
                for (var i = 0; i < data.length; i++) {
                    $("#state").append('<option value="'
                        + data[i].value + '">'
                        + data[i].text + '</option>')
                }
                
            }
           
        });
    });


})

