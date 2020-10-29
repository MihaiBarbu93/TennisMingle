// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


function adjust(v) {
    if (v > 9) {
        return v.toString();
    } else {
        return '0' + v.toString();
    }
}


$(document).ready(function () {
    var today = new Date();
    var date = today.getFullYear() + '-' + adjust(today.getMonth() + 1) + '-' + adjust(today.getDate());
    var time = adjust(today.getHours()) + ":" + adjust(today.getMinutes());
    var dateTime = `${date}T${time}`;
    console.log(dateTime);
    //its working

    document.getElementById("followup_next_followup_date").value = dateTime;
    document.getElementById("followup_next_followup_date").setAttribute("min", dateTime);
});

// Initialize and add the map
function initMap() {
    // The location of Uluru
    const uluru = { lat: -25.344, lng: 131.036 };
    // The map, centered at Uluru
    const map = new google.maps.Map(document.getElementById("map"), {
        zoom: 4,
        center: uluru,
    });
    // The marker, positioned at Uluru
    const marker = new google.maps.Marker({
        position: uluru,
        map: map,
    });
}