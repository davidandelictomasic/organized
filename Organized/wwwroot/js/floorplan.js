// Floor plan interactive map using Leaflet.js
let map = null;
let markers = [];

window.FloorPlanInterop = {
    initialize: function (imageUrl, dotNetHelper, skipImage) {
        console.log('=== FLOORPLAN INIT v2 ===');
        console.log('skipImage:', skipImage);
        
        // Remove existing map if any
        if (map) {
            map.remove();
            map = null;
            markers = [];
        }

        // Define the bounds based on the image's dimensions (matching React setup)
        const bounds = [[0, 0], [2500, 3000]];

        // Create the map
        map = L.map('floorplan-map', {
            crs: L.CRS.Simple,
            minZoom: -2,
            maxZoom: 2,
            zoomControl: true,
            attributionControl: false
        });

        // IMAGE DISABLED FOR TESTING - uncomment when markers work
        // const imageOverlay = L.imageOverlay(imageUrl, bounds, {
        //     opacity: 1,
        //     interactive: false
        // }).addTo(map);

        // Fit the map to the image bounds
        map.fitBounds(bounds);
        
        console.log('Map initialized without image');

        return true;
    },

    addMarker: function (tableId, x, y, label, dotNetHelper) {
        console.log('Adding marker:', { tableId, x, y, label });
        
        if (!map) {
            console.error('Map not initialized!');
            return false;
        }

        // Create a custom icon
        const icon = L.divIcon({
            className: 'custom-marker',
            html: `<div class="marker-circle"><span>${label}</span></div>`,
            iconSize: [50, 50],
            iconAnchor: [25, 25]
        });

        // Create the marker - position is [y, x] in Leaflet (lat, lng)
        const marker = L.marker([y, x], { 
            icon: icon,
            zIndexOffset: 1000  // Ensure markers are above the image
        }).addTo(map);
        
        console.log('Marker added at position:', [y, x]);

        // Add click handler
        marker.on('click', function () {
            console.log('Marker clicked:', tableId);
            dotNetHelper.invokeMethodAsync('OnMarkerClicked', tableId);
        });

        // Add hover effect
        marker.on('mouseover', function () {
            this.getElement().querySelector('.marker-circle').classList.add('hover');
        });

        marker.on('mouseout', function () {
            this.getElement().querySelector('.marker-circle').classList.remove('hover');
        });

        markers.push({ tableId: tableId, marker: marker });

        return true;
    },

    clearMarkers: function () {
        markers.forEach(m => {
            map.removeLayer(m.marker);
        });
        markers = [];
    },

    highlightMarker: function (tableId) {
        markers.forEach(m => {
            const circle = m.marker.getElement()?.querySelector('.marker-circle');
            if (circle) {
                if (m.tableId === tableId) {
                    circle.classList.add('selected');
                } else {
                    circle.classList.remove('selected');
                }
            }
        });
    },

    dispose: function () {
        if (map) {
            map.remove();
            map = null;
            markers = [];
        }
    }
};
