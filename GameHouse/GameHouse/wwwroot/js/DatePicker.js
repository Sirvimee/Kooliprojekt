$(function () {

    function WireUpDatePicker() {

        const addMonths = 3;
        var currDate = new Date();

        $('.datepicker').datepicker(
            {
                dateFormat: 'dd-mm-yy',
                minDate: currDate,
                maxDate: AddSubtractMonths(currDate, addMonths)
            }
        );
    }

    WireUpDatePicker();

});