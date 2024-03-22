var map;
var marker;

function initMap() {
    var initialPosition = { lat: 0, lng: 0 }; // Initial position for the map
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
        updatePosition(marker.getPosition(), 8);
    });

    // Try HTML5 geolocation.
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function (position) {
            var pos = {
                lat: position.coords.latitude,
                lng: position.coords.longitude
            };

            map.setCenter(pos);
            marker.setPosition(pos);
            updatePosition(pos, 8);
        }, function () {
            handleLocationError(true, marker.getPosition());
        });
    } else {
        // Browser doesn't support Geolocation
        handleLocationError(false, marker.getPosition());
    }
}

function updatePosition(position, decimalPlaces) {
    document.getElementById("latitude").value = position.lat().toFixed(decimalPlaces);
    document.getElementById("longitude").value = position.lng().toFixed(decimalPlaces);
}

function handleLocationError(browserHasGeolocation, pos) {
    alert(browserHasGeolocation ?
        'Error: The Geolocation service failed.' :
        'Error: Your browser doesn\'t support geolocation.');
}