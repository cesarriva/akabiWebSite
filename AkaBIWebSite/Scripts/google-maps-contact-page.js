jQuery(function ($) {
    // Asynchronously Load the map API 
    var script = document.createElement('script');
    script.src = "//maps.googleapis.com/maps/api/js?key=AIzaSyAaR88NGQFG4NH8LRgR_rvHhdRsMvcuL8c&callback=initialize";
    document.body.appendChild(script);
});

function initialize() {
    var map;
    var bounds = new google.maps.LatLngBounds();
    var mapOptions = {
        mapTypeId: 'roadmap'
    };

    // Display a map on the page
    map = new google.maps.Map(document.getElementById("map_canvas"), mapOptions);
    map.setTilt(45);

    // Multiple Markers
    var markers = [
        ['AkaBI Luxembourg', 49.5721359, 6.1621197],
        ['AkaBI Belgium', 50.8155829, 4.3727268]
    ];

    // Info Window Content
    var infoWindowContent = [
        [
            '<div class="info_content">' +
                '<h3>AkaBI Luxembourg</h3>' +
                '<a href="http://www.google.com/maps/place/49.5721359,6.1621197" target="_blank">Rue Roger Wercollier, 15 - L-5890 - Hesperange</a>' +
            '</div>'
        ],
        [
            '<div class="info_content">' +
                '<h3>AkaBI Belgium</h3>' +
                '<a href="http://www.google.com/maps/place/50.8155829,4.3727268" target="_blank">Boulevard de la Cambre, 74 - B-1000 -  Bruxelles</a>' +
            '</div>'
        ],
    ];

    // Display multiple markers on a map
    var infoWindow = new google.maps.InfoWindow(), marker, i;

    // Loop through our array of markers & place each one on the map  
    for (i = 0; i < markers.length; i++) {
        var position = new google.maps.LatLng(markers[i][1], markers[i][2]);
        bounds.extend(position);
        marker = new google.maps.Marker({
            position: position,
            map: map,
            title: markers[i][0]
        });

        // Allow each marker to have an info window    
        google.maps.event.addListener(marker, 'click', (function (marker, i) {
            return function () {
                infoWindow.setContent(infoWindowContent[i][0]);
                infoWindow.open(map, marker);
            }
        })(marker, i));

        // Automatically center the map fitting all markers on the screen
        map.fitBounds(bounds);
    }

    // Override our map zoom level once our fitBounds function runs (Make sure it only runs once)
    var boundsListener = google.maps.event.addListener((map), 'bounds_changed', function (event) {
        this.setZoom(7);
        google.maps.event.removeListener(boundsListener);
    });

}
