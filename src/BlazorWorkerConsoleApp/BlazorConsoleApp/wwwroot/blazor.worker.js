console.log('Running framework in worker');

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

var window = globalThis;
window.addEventListener.addEventListener = function (n, l) {
    console.log("addEventListener: " + n);
}

var Node = {
    COMMENT_NODE: {}
}

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
    querySelector: function (a) {
        return undefined;
    },
    querySelectorAll: function (a) {
        return [];
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

console.log("Importing blazor");
self.importScripts("_framework/blazor.webassembly.js");
console.log("Imported blazor");

