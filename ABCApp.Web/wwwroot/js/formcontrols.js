$(function () {
    // initialize dropdowns
    $('.country.ui.dropdown')
        .dropdown();
    $('.state.ui.dropdown')
        .dropdown();
    $('.city.ui.dropdown')
        .dropdown();
    $('.products.ui.dropdown')
        .dropdown({
            apiSettings: {
                // this url parses query server side and returns filtered results
                url: '/product/'
            },            
            filterRemoteData: true
        })
    //datepicker
    $('.datepicker').datepicker({
        autoHide: true,
    });
    //set to current date
    $('.datepicker').datepicker('pick');

    $('#country').change(function ()
    {        
        $('#state').dropdown('clear');        
        $('#city').dropdown('clear');
        $('#state').parent().addClass('loading'); 

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
            },
            complete: function ()
            {
                setTimeout(() => {
                    $('#state').parent().removeClass('loading');
                }, 1000);                
            }
           
        });
    });

    $('#state').change(function () {
        
        $('#city').dropdown('clear');        
        $('#city').parent().addClass('loading');

        $.ajax({
            type: "post",
            url: "/Order/GetCities",
            data: { regionCode: $('#state').val() },
            datatype: "json",
            traditional: true,
            success: function (data) {
                $("#city").empty()
                $("#city").append("<option value='' selected='selected'>-- select city --</option>")
                for (var i = 0; i < data.length; i++) {
                    $("#city").append('<option value="'
                        + data[i].value + '">'
                        + data[i].text + '</option>')
                }
            },
            complete: function () {
                setTimeout(() => {
                    $('#city').parent().removeClass('loading');
                }, 1000);
            }
        });
    });


})

