console.log('Running shared worker 2');

var connections = {};

var NodeService = {
    connect: function (id, port, args) {
        connections[id] = port;
    },
    disconnect: function (id, port, args) {
        delete connections[id];
    },
    message: function (id, port, args) {
        console.log(`Message [${id}] -> [${args.target}]: ${args.message}`);
        callClient(args.target, "message", args.message);
    },
};

function callClient(id, method, args) {
    connections[id].postMessage({
        method: method,
        args: args
    });
}

onconnect = function (e) {
    var port = e.ports[0];

    console.log(`Connected.`);

    port.onmessage = function (e) {
        var d = e.data;
        console.log(`Received [${d.id}] ${d.method}: '${d.args}'`);
        NodeService[d.method](d.id, port, d.args);
        if (d.method !== "disconnect") {
            callClient(d.id, "message", `ACK [${d.id}] ${d.method}: '${d.args}'`);
        }
    };
}