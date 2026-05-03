window.FlatpickrInterop = {
    instances: {},

    initialize: function (elementId, dotNetHelper, options) {
        const el = document.getElementById(elementId);
        if (!el) return;

        if (this.instances[elementId]) {
            this.instances[elementId].destroy();
        }

        const config = {
            dateFormat: "Y-m-d",
            minDate: options.minDate || "today",
            locale: {
                firstDayOfWeek: 1
            },
            disable: [],
            onChange: function (selectedDates, dateStr) {
                dotNetHelper.invokeMethodAsync("OnDateChanged", dateStr);
            }
        };

        if (options.inline) {
            config.inline = true;
        } else {
            config.altInput = true;
            config.altFormat = "M d, Y";
        }

        if (options.disableWeekends) {
            config.disable.push(function (date) {
                return date.getDay() === 0 || date.getDay() === 6;
            });
        }

        if (options.disabledDates && options.disabledDates.length > 0) {
            options.disabledDates.forEach(function (d) {
                config.disable.push(d);
            });
        }

        this.instances[elementId] = flatpickr(el, config);
    },

    setDate: function (elementId, dateStr) {
        if (this.instances[elementId]) {
            this.instances[elementId].setDate(dateStr, false);
        }
    },

    destroy: function (elementId) {
        if (this.instances[elementId]) {
            this.instances[elementId].destroy();
            delete this.instances[elementId];
        }
    }
};
