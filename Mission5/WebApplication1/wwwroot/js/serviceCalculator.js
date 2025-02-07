// takes inputs for time etc to calculate how much I would charge for college basketball services

$(document).ready(function () {
    $('#calculate').click(function () {
        let hours = $('#hours').val();

        if (hours >= 1 && hours <= 24) {
            let totalCost = hours * 50;
            $('#totalCost').text('Total Cost: $' + totalCost.toFixed(2))
                .css("display", "block"); // Explicitly set display
            console.log(totalCost);
        } else {
            alert("Please enter a valid number between 1-24 hours.");
        }
    });
});
