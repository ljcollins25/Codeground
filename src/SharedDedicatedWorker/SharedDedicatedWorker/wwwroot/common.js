
class PromiseCompletionSource {
    Resolve;
    Reject;
    constructor() {
        this.Promise = new Promise(function (resolve, reject) {
            this.Resolve = resolve;
            this.Reject = reject;
        });
    }
}

var NodeService = {
    nextConnectionId: 0,
    nextCallId: 0,
    connections: {},
    calls: {},
    connect: function (port) {
        var id = this.nextConnectionId++;
        this.connections[id] = port;

        port.onmessage = function (e) {
            var d = e.data;
            this[d.method](d.id, d.args);
        };
    },
    disconnect: function (id) {
        delete this.connections[id];
    },
    callClient: function (id, method, args) {
        this.connections[id].postMessage({
            method: method,
            args: args
        });
    },
    callClientAsync: function (id, method, args) {
        var pcs = new PromiseCompletionSource();
        var callId = this.nextCallId++;
        calls[callId] = pcs;

        this.connections[id].postMessage({
            method: method,
            args: args,
            callId: callId
        });

        return pcs.Promise;
    },
    respond: function (args) {
        var pcs = calls[args.callId];
        if (args.resolveResult) {
            pcs.Resolve(args.resolveResult);
        } else {
            pcs.Reject(args.RejectResult);
        }
    },
    sendLog: function (id, args) {
        console.log(`Message [${id}] -> [${args.target}]: ${args.message}`);
        this.callClient(args.target, "writeLog", args.message);
    },
    onmessage: async function (e) {
        var d = e.data;
        if (d.callId) {
            var response = await this[d.method](d.args);
            
        } else {
            this[d.method](d.args);
        }
    },
    writeLog: function (message) {
        console.log(`writeLog: Message ${message}`);
    }
};


function Promise() {
    var deferred = {};
    var promise = new Promise(function (resolve, reject) {
        deferred.resolve = resolve;
        deferred.reject = reject;
    });
    deferred.promise = promise;
    return deferred;
}

class PageNodeService {
    Target;
    constructor(target) {
        this.Target = target;
    }
}

class WorkerNodeClient {
    Worker;
    constructor(startupfile) {
        this.Worker = new Worker(startupFile);
    }
}

class WorkerNodeService {

}

class SharedWorkerNodeClient {
    Worker;
    constructor(startupfile) {
        this.Worker = new Worker(startupFile);
    }
}

class SharedWorkerNodeService {

}

onconnect = function (e) {
    var port = e.ports[0];
    NodeService.connect()

    console.log(`Connected.`);

    port.onmessage = function (e) {
        var d = e.data;
        NodeService[d.method](d.id, port, d.args);

        console.log(`Received [${d.id}] ${d.method}: '${d.args}'`);
        if (d.method !== "disconnect") {
            callClient(d.id, "message", `ACK [${d.id}] ${d.method}: '${d.args}'`);
        }
    };
}