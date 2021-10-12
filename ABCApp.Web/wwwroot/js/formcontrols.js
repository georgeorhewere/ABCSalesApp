
$(function () {

    // initialize dropdowns
    $('.country.ui.dropdown')
        .dropdown({
            apiSettings: {
                // this url parses query server side and returns filtered results
                url: '/country/countries',
                onSuccess: function (response) {
                    // valid response and response.success = true 
                    var countries = response.results;
                    for (var i = 0; i < countries.length; i++) {
                        $("#country-menu").append('<div class="item" data-value="' + countries[i].value + '"><i class="' + ("" + countries[i].name).toLowerCase() + ' flag"></i>' + countries[i].text + '</div>')
                    }
                }
            },
            filterRemoteData: true,
            onChange: (value, text, $choice) => {
                $('#state').dropdown('clear');
                $('#city').dropdown('clear');
                $('#state').parent().addClass('loading'); 
                
                $.ajax({
                    type: "post",
                    url: "/country/regions",
                    data: { countryId: value },
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
                    complete: function () {
                        setTimeout(() => {
                            $('#state').parent().removeClass('loading');
                        }, 1000);
                    }

                });
            }
        });

    $('.state.ui.dropdown')
        .dropdown({

            onChange: (value, text, $choice) => {
                $('#city').dropdown('clear');
                $('#city').parent().addClass('loading');

                $.ajax({
                    type: "post",
                    url: "/country/cities",
                    data: { regionId: value },
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
            }

        });

    $('.city.ui.dropdown')
        .dropdown();

    $('.products.ui.dropdown')
        .dropdown({
            apiSettings: {
                // this url parses query server side and returns filtered results
                url: '/product/'
            },            
            filterRemoteData: true,
            onChange: (value, text, $choice) => {
                //query product info 
                // console.log(value, text)               
                if (value) {
                    $.ajax({
                        type: "post",
                        url: "/product/productbyid",
                        data: { productId: value },
                        datatype: "json",
                        traditional: true,
                        success: function (data) {
                            $('.order-items').append(data)
                            $('.products').dropdown('clear');

                        },
                        complete: function () {
                            setTimeout(() => {
                                $('#city').parent().removeClass('loading');
                            }, 500);
                        }
                    });
                }
            }
        })

    //datepicker
    $('.datepicker').datepicker({
        autoHide: true,
    });

    //set to current date
    $('.datepicker').datepicker('pick');

 
   



})

