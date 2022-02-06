var id = "id" + Math.random().toString(16).slice(2);
var sharedWorker = new SharedWorker("sharedworker.js");

var workers = {};

var NodeService = {
    message: function (m) {
        console.log(`Message '${m}'`);
    },
    createWorker: function (args) {
        var worker = new Worker(args.url);
        workers[args.name] = worker;
        callShared("registerWorker", {
            worker.postMessage()
        })
    },
};

sharedWorker.port.onmessage = function (e) {
    var d = e.data;
    console.log(`Received [SharedWorker] ${d.method}: '${d.args}'`);
    NodeService[d.method](d.args);
};

sharedWorker.port.start();

function callShared(method, args) {
    sharedWorker.port.postMessage({
        id: id,
        method: method,
        args: args,
    });
}

callShared("connect", "Connecting to shared worker.");

addEventListener('beforeunload', function () {
    callShared("disconnect", "Disconnecting to shared worker.");
});

function send(target, message) {
    callShared("message", { sender: id, target, message });
}