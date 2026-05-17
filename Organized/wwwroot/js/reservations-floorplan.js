let reservationsMap = null;
let reservationsMarkers = [];
let imageWidth = 3000;
let imageHeight = 2500;

window.ReservationsFloorPlan = {
    initialize: function (imageUrl, imgWidth, imgHeight, dotNetHelper) {
        console.log('ReservationsFloorPlan.initialize called');

        imageWidth = imgWidth;
        imageHeight = imgHeight;

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

        const bounds = [[0, 0], [imageHeight, imageWidth]];

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

        L.imageOverlay(imageUrl, bounds, {
            interactive: false
        }).addTo(reservationsMap);

        reservationsMap.fitBounds(bounds);

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

    addMarker: function (tableId, x, y, label, dotNetHelper) {
        if (!reservationsMap) {
            console.error('Map not initialized');
            return false;
        }

        const marker = L.marker([y, x]).addTo(reservationsMap);

        marker.bindPopup(`<b>${label}</b><br>Table #${tableId}<br>Click to reserve`, { closeButton: false });

        marker.on('mouseover', function () {
            this.openPopup();
        });

        marker.on('mouseout', function () {
            this.closePopup();
        });

        marker.on('click', function () {
            console.log('Marker clicked:', tableId);
            dotNetHelper.invokeMethodAsync('OnMarkerClicked', tableId);
        });

        reservationsMarkers.push({ tableId: tableId, marker: marker });
        console.log('Marker added:', { tableId, x, y, label });

        return true;
    },


    highlightMarker: function (tableId) {
        reservationsMarkers.forEach(m => {
            if (m.tableId === tableId) {
                m.marker.openPopup();
            }
        });
    },

    clearHighlights: function () {
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

    previewMap: null,
    previewMarkers: [],
    previewMarkerData: null,
    previewSelectedTableId: 0,
    previewDotNetRef: null,

    initializePreview: function (containerId, imageUrl, imgWidth, imgHeight, markerData, selectedTableId, dotNetHelper) {
        this.previewDotNetRef = dotNetHelper || null;
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

        this.previewMarkerData = markerData || [];
        this.previewSelectedTableId = selectedTableId;

        this._renderPreviewMarkers({}, 0);

        var selected = (markerData || []).find(function (m) { return m.tableId === selectedTableId; });
        if (selected) {
            this.previewMap.setView([selected.y, selected.x], 0);
        }

        return true;
    },

    updatePreviewOccupants: function (occupants, currentUserId, selectedTableId) {
        if (!this.previewMap) return false;
        if (selectedTableId) this.previewSelectedTableId = selectedTableId;

        var occupantsByTable = {};
        (occupants || []).forEach(function (o) {
            occupantsByTable[o.tableId] = o;
        });

        this._renderPreviewMarkers(occupantsByTable, currentUserId);
        return true;
    },

    _renderPreviewMarkers: function (occupantsByTable, currentUserId) {
        var self = this;

        this.previewMarkers.forEach(function (m) { self.previewMap.removeLayer(m); });
        this.previewMarkers = [];

        if (!this.previewMarkerData) return;

        this.previewMarkerData.forEach(function (m) {
            var isSelected = m.tableId === self.previewSelectedTableId;
            var label = m.label || ('Desk ' + m.tableId);
            var occupant = occupantsByTable[m.tableId];

            var iconHtml, popupText, size, isClickable;

            if (isSelected) {
                iconHtml = '<div class="preview-marker preview-marker-selected"><span>' + m.tableId + '</span></div>';
                popupText = '<b>' + label + '</b><br><span class="preview-popup-self">You will be here</span>';
                size = 36;
                isClickable = false;
            } else if (occupant) {
                var isSelf = occupant.userId === currentUserId;
                iconHtml = '<div class="preview-marker preview-marker-booked' + (isSelf ? ' preview-marker-self' : '') + '"><span>' + escapeHtml(occupant.initials || '?') + '</span></div>';
                popupText = '<b>' + label + '</b><br>Reserved by <b>' + escapeHtml(occupant.userName || 'Unknown') + '</b>';
                size = 32;
                isClickable = false;
            } else {
                iconHtml = '<div class="preview-marker preview-marker-available preview-marker-clickable"><span>' + m.tableId + '</span></div>';
                popupText = '<b>' + label + '</b><br><span class="preview-popup-available">Available — click to switch</span>';
                size = 28;
                isClickable = true;
            }

            var icon = L.divIcon({
                className: 'preview-marker-icon',
                html: iconHtml,
                iconSize: [size, size],
                iconAnchor: [size / 2, size / 2]
            });

            var marker = L.marker([m.y, m.x], { icon: icon, interactive: true }).addTo(self.previewMap);
            marker.bindPopup(popupText, { closeButton: false });
            marker.on('mouseover', function () { this.openPopup(); });
            marker.on('mouseout', function () { this.closePopup(); });

            if (isClickable && self.previewDotNetRef) {
                (function (clickedId) {
                    marker.on('click', function () {
                        self.previewDotNetRef.invokeMethodAsync('OnPreviewMarkerClicked', clickedId);
                    });
                })(m.tableId);
            }

            self.previewMarkers.push(marker);
        });
    },

    disposePreview: function () {
        if (this.previewMap) {
            this.previewMap.remove();
            this.previewMap = null;
            this.previewMarkers = [];
            this.previewMarkerData = null;
            this.previewSelectedTableId = 0;
            this.previewDotNetRef = null;
        }
    }
};

function escapeHtml(s) {
    return String(s).replace(/[&<>"']/g, function (c) {
        return { '&': '&amp;', '<': '&lt;', '>': '&gt;', '"': '&quot;', "'": '&#39;' }[c];
    });
}
