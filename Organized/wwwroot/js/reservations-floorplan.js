// Reservations floor plan using Leaflet.js
let reservationsMap = null;
let reservationsMarkers = [];
let imageWidth = 3000;
let imageHeight = 2500;

window.ReservationsFloorPlan = {
    initialize: function (imageUrl, imgWidth, imgHeight, dotNetHelper) {
        console.log('ReservationsFloorPlan.initialize called');
        
        // Store dimensions for coordinate calculations
        imageWidth = imgWidth;
        imageHeight = imgHeight;
        
        // Remove existing map if any
        if (reservationsMap) {
            reservationsMap.remove();
            reservationsMap = null;
            reservationsMarkers = [];
        }

        const mapContainer = document.getElementById('reservations-floorplan-map');
        if (!mapContainer) {
            console.error('Map container not found');
            return false;
        }

        // Define bounds based on image dimensions (matching original setup)
        const bounds = [[0, 0], [imageHeight, imageWidth]];

        // Create the map with Leaflet's built-in zoom/pan
        reservationsMap = L.map('reservations-floorplan-map', {
            crs: L.CRS.Simple,
            minZoom: -2,
            maxZoom: 2,
            zoomControl: true,
            attributionControl: false,
            dragging: true,
            scrollWheelZoom: true,
            doubleClickZoom: true,
            boxZoom: true
        });

        // Add the floor plan image as an overlay
        L.imageOverlay(imageUrl, bounds, {
            interactive: false
        }).addTo(reservationsMap);

        // Fit the map to the image bounds
        reservationsMap.fitBounds(bounds);

        // DEBUG: Click on map to get coordinates
        reservationsMap.on('click', function(e) {
            const y = e.latlng.lat;
            const x = e.latlng.lng;
            console.log('=== CLICK POSITION ===');
            console.log(`Pixel coordinates: X=${x.toFixed(1)}, Y=${y.toFixed(1)}`);
            console.log('Copy this to tablePositions:');
            console.log(`new TablePosition { TableId = ???, X = ${x.toFixed(1)}, Y = ${y.toFixed(1)} },`);
        });

        console.log('Map initialized with bounds:', bounds);
        console.log('TIP: Click anywhere on the map to see coordinates in console');
        return true;
    },

    // Now accepts pixel X, Y coordinates directly (matching original marker positions)
    addMarker: function (tableId, x, y, label, dotNetHelper) {
        if (!reservationsMap) {
            console.error('Map not initialized');
            return false;
        }

        // Use Leaflet's built-in default marker icon
        const marker = L.marker([y, x]).addTo(reservationsMap);

        // Bind a popup with the label
        marker.bindPopup(`<b>${label}</b><br>Table #${tableId}<br>Click to reserve`);
        
        // Show popup on hover
        marker.on('mouseover', function () {
            this.openPopup();
        });
        
        marker.on('mouseout', function () {
            this.closePopup();
        });

        // Add click handler
        marker.on('click', function () {
            console.log('Marker clicked:', tableId);
            dotNetHelper.invokeMethodAsync('OnMarkerClicked', tableId);
        });

        reservationsMarkers.push({ tableId: tableId, marker: marker });
        console.log('Marker added:', { tableId, x, y, label });

        return true;
    },


    highlightMarker: function (tableId) {
        // With default markers, we can open the popup to highlight
        reservationsMarkers.forEach(m => {
            if (m.tableId === tableId) {
                m.marker.openPopup();
            }
        });
    },

    clearHighlights: function () {
        // Close all popups
        reservationsMarkers.forEach(m => {
            m.marker.closePopup();
        });
    },

    dispose: function () {
        if (reservationsMap) {
            reservationsMap.remove();
            reservationsMap = null;
            reservationsMarkers = [];
        }
    }
};
