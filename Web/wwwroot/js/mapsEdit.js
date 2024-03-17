var map;
var marker;

function initMap() {
    //var location = Html.Raw(jsonLocation); // Deserialize JSON location object
    var initialPosition = { lat: location.Latitude, lng: location.Longitude }; // Get latitude and longitude from location object

    map = new google.maps.Map(document.getElementById('map'), {
        center: initialPosition,
        zoom: 8
    });

    marker = new google.maps.Marker({
        position: initialPosition,
        map: map,
        draggable: true
    });

    google.maps.event.addListener(marker, 'dragend', function () {
        updatePosition(marker.getPosition());
    });
}

function updatePosition(position) {
    document.getElementById("latitude").value = position.lat();
    document.getElementById("longitude").value = position.lng();
}