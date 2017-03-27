var markers = [];

var mapStyle = [
    {
        "featureType": "landscape.natural",
        "elementType": "geometry.fill",
        "stylers": [{
            "color": "#ffffff"
        }]
    },
    {
        "featureType": "landscape.man_made",
        "stylers": [{
            "color": "#ffffff"
        }
            , {
                "visibility": "off"
            }
        ]
    },
    {
        "featureType": "water",
        "stylers": [{
            "color": "#80C8E5"
        }
                    , {
                        "saturation": 0
                    }
        ]
    },
    {
        "featureType": "road.arterial",
        "elementType": "geometry",
        "stylers": [{
            "color": "#999999"
        }
        ]
    },
    {
        "elementType": "labels.text.stroke",
        "stylers": [{
            "visibility": "off"
        }]
    },
    {
        "elementType": "labels.text",
        "stylers": [{
            "color": "#333333"
        }]
    },
    {
        "featureType": "road.local",
        "stylers": [{
            "color": "#dedede"
        }
        ]
    },
    {
        "featureType": "road.local",
        "elementType": "labels.text",
        "stylers": [{
            "color": "#666666"
        }]
    },
    {
        "featureType": "transit.station.bus",
        "stylers": [{
            "saturation": -57
        }]
    },
    {
        "featureType": "road.highway",
        "elementType": "labels.icon",
        "stylers": [{
            "visibility": "off"
        }]
    },
    {
        "featureType": "poi",
        "stylers": [{
            "visibility": "off"
        }]
    }];

var mapMarkerImage = new google.maps.MarkerImage(
  '../Content/images/map-marker-icon.png',
  new google.maps.Size(84, 70),
  new google.maps.Point(0, 0),
  new google.maps.Point(60, 60)
);

function addMarker(map, plain) {
    markers.push(new google.maps.Marker({
        position: plain,
        raiseOnDrag: false,
        icon: mapMarkerImage,
        map: map,
        draggable: false
    }));
}

function createMapOption(coordinates) {
    var mapOptions = {
        backgroundColor: "#ffffff",
        zoom: 15,
        disableDefaultUI: true,
        center: coordinates,
        zoomControl: false,
        scaleControl: false,
        scrollwheel: false,
        disableDoubleClickZoom: true,
        mapTypeId: google.maps.MapTypeId.ROADMAP,
        styles: mapStyle
    };

    return mapOptions;
}

function initialize() {
    var luxCoordinates = new google.maps.LatLng(49.5721359, 6.1621197);
    var mapLuxembourg = new google.maps.Map(document.getElementById('luxembourg-map'), createMapOption(luxCoordinates));
    addMarker(mapLuxembourg, luxCoordinates);

    var belgiumCoordinates = new google.maps.LatLng(50.8155829, 4.3727268);
    var mapBelgium = new google.maps.Map(document.getElementById('belgium-map'), createMapOption(belgiumCoordinates));
    addMarker(mapBelgium, belgiumCoordinates);
}

google.maps.event.addDomListener(window, 'load', initialize);
