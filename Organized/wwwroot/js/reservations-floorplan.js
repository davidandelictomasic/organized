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
    },

    // Preview map for the reservation modal (read-only)
    previewMap: null,
    previewMarkers: [],

    initializePreview: function (containerId, imageUrl, imgWidth, imgHeight, markerData, selectedTableId) {
        // Clean up existing preview
        if (this.previewMap) {
            this.previewMap.remove();
            this.previewMap = null;
            this.previewMarkers = [];
        }

        const container = document.getElementById(containerId);
        if (!container) return false;

        const bounds = [[0, 0], [imgHeight, imgWidth]];

        this.previewMap = L.map(containerId, {
            crs: L.CRS.Simple,
            minZoom: -2,
            maxZoom: 2,
            zoomControl: false,
            attributionControl: false,
            dragging: true,
            scrollWheelZoom: true,
            doubleClickZoom: false,
            boxZoom: false,
            keyboard: false
        });

        L.imageOverlay(imageUrl, bounds, { interactive: false }).addTo(this.previewMap);
        this.previewMap.fitBounds(bounds);

        // Add markers (non-clickable)
        if (markerData && markerData.length > 0) {
            markerData.forEach(function (m) {
                var isSelected = m.tableId === selectedTableId;

                var icon = L.divIcon({
                    className: 'preview-marker-icon',
                    html: '<div class="preview-marker ' + (isSelected ? 'preview-marker-selected' : '') + '">' +
                          '<span>' + (m.tableId - 99) + '</span></div>',
                    iconSize: [isSelected ? 36 : 28, isSelected ? 36 : 28],
                    iconAnchor: [isSelected ? 18 : 14, isSelected ? 18 : 14]
                });

                var marker = L.marker([m.y, m.x], { icon: icon, interactive: true }).addTo(this.previewMap);
                var popupText = isSelected
                    ? '<b>Desk ' + (m.tableId - 99) + '</b><br><span style="color:#667eea;">You will be here</span>'
                    : '<b>Desk ' + (m.tableId - 99) + '</b>';
                marker.bindPopup(popupText);

                marker.on('mouseover', function () { this.openPopup(); });
                marker.on('mouseout', function () { this.closePopup(); });

                this.previewMarkers.push(marker);
            }.bind(this));
        }

        // Center on the selected table
        var selected = markerData.find(function (m) { return m.tableId === selectedTableId; });
        if (selected) {
            this.previewMap.setView([selected.y, selected.x], 0);
        }

        return true;
    },

    disposePreview: function () {
        if (this.previewMap) {
            this.previewMap.remove();
            this.previewMap = null;
            this.previewMarkers = [];
        }
    }
};
