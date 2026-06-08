$(document).ready(function () {
    $('#CityId').on('change', function () {

        var cityId = $(this).val();
        var banksList = $('#BloodBankId');

        banksList.empty();

        if (cityId != '') {
            $.ajax({
                url: '/Donors/GetBanks?CityId=' + cityId,
                success: function (BloodBanks) {

                    if (BloodBanks.length == 0) {
                        banksList.append($('<option> No Banks Here </option>').attr("value", 0));
                    }
                    $.each(BloodBanks, function (i, bank) {
                        banksList.append($('<option></option>').attr("value", bank.value).text(bank.text));
                    });
                }
            });
        }


    });


});