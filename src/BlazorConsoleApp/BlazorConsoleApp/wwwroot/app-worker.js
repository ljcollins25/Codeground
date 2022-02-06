console.log('Running worker in framework');

var oldFetch = fetch;

fetch = function (resource, init = undefined) {
    //if (!resource.startsWith("_framework/")) {
    //    resource = "_framework/" + resource;
    //}

    let url = new URL(resource, self.location);
    if (!url.pathname.startsWith("/_framework")) {
        url.pathname = "/_framework" + url.pathname;
    }

    if (init === undefined) {
        return oldFetch(url);
    } else {
        return oldFetch(url, init);
    }
}

var window = {
    addEventListener: function (n, l) {

    }
};
var document = {
    location: self.location,
    baseURI: self.location.href,
    addEventListener: function (n, l) { },
    createElement: function (n) {
        return {
            kind: n
        };
    },
    createElementNS: function (ns, n) { return {}; },
    hasChildNodes: function () {
        return false;
    },
    body: {
        appendChild: function (c) {
            if (c.kind === "script") {
                if (c.text) {
                    eval(c.text);
                } else if (c.src) {
                    self.importScripts(c.src);
                }
            }
        }
    },
    currentScript: {
        getAttribute: function (n) {
            if (n === "autostart") {
                return true;
            }

            return false;
        }
    }
};

var sab = new SharedArrayBuffer(1024);
const sab32 = new Int32Array(sab);

console.log("Created buffer");

console.log("Importing blazor");
self.importScripts("_framework/blazor.webassembly.js");
console.log("Imported blazor");


onmessage = function (e) {
    console.log(`Worker: Message received from main script [${e.data}]`);

    console.log(`Sending request and waiting`);

    postMessage({ message: "from app worker", sab: sab32, url: "./data.txt" });

    Atomics.wait(sab32, 0, 0);
    console.log(sab32[0]); // 123

}