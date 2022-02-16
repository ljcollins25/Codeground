if (typeof SharedArrayBuffer === 'undefined') {
    if ("serviceWorker" in navigator) {
        // Register service worker
        navigator.serviceWorker.register("./serviceworker.js").then(
            function (registration) {
                console.log("COOP/COEP Service Worker registered", registration.scope);
                // If the registration is active, but it's not controlling the page
                if (registration.active && !navigator.serviceWorker.controller) {
                    window.location.reload();
                }
            },
            function (err) {
                console.log("COOP/COEP Service Worker failed to register", err);
            }
        );
    } else {
        console.warn("Cannot register a service worker");
    }
}

//console.log("loading blazor");
var worker = new SharedWorker("blazor.worker.js");
