// The latitude and longitude of your business / place
var position = [28.6323582, 77.22047380000004];

function showGoogleMaps() {

    var latLng = new google.maps.LatLng(position[0], position[1]);

    var mapOptions = {
        zoom: 18, // initialize zoom level - the max value is 21
        streetViewControl: false, // hide the yellow Street View pegman
        scaleControl: true, // allow users to zoom the Google Map
        mapTypeId: google.maps.MapTypeId.HYBRID   ,
        center: latLng,
        tilt: 45
    };
    function rotate90() {
        var heading = map.getHeading() || 0;
        map.setHeading(heading + 90);
    }

    function autoRotate() {
        // Determine if we're showing aerial imagery.
        if (map.getTilt() !== 0) {
            window.setInterval(rotate90, 3000);
        }
    }

    map = new google.maps.Map(document.getElementById('googlemaps'),
        mapOptions);

    // Show the default red marker at the location
    marker = new google.maps.Marker({
        position: latLng,
        map: map,
        draggable: false,
        animation: google.maps.Animation.DROP
    });
}

google.maps.event.addDomListener(window, 'load', showGoogleMaps);