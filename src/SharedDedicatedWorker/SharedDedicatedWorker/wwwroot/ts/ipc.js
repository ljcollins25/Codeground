var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var CodexIpc;
(function (CodexIpc) {
    class PromiseCompletionSource {
        constructor() {
            var self = this;
            this.Task = new Promise(function (resolve, reject) {
                self.Resolve = resolve;
                self.Reject = reject;
            });
        }
    }
    var UnknownGlobal = globalThis;
    var WorkerGlobalScope = UnknownGlobal;
    var SharedWorkerGlobalScope = UnknownGlobal;
    var DedicatedWorkerGlobalScope = UnknownGlobal;
    class WorkerClientBase {
        constructor(server, port) {
            this.Id = server.connect(port);
            this.Server = server;
            var proxy = new Proxy(this, {
                get: this.getFunction
            });
            this.Target = proxy;
        }
        getFunction(target, name, receiver) {
            return function (arg) {
                var message = {
                    args: arg,
                    id: target.Id,
                    method: name,
                };
                return target.Server.callClientAsync(message);
            };
        }
    }
    CodexIpc.WorkerClientBase = WorkerClientBase;
    class SharedWorkerClient extends WorkerClientBase {
        constructor(server, startupScript) {
            var worker = new SharedWorker(startupScript);
            super(server, worker.port);
            this.Worker = worker;
            this.Worker.port.start();
        }
    }
    CodexIpc.SharedWorkerClient = SharedWorkerClient;
    class WorkerClient extends WorkerClientBase {
        constructor(server, startupScript) {
            var worker = new Worker(startupScript);
            super(server, worker);
            this.Worker = worker;
        }
    }
    CodexIpc.WorkerClient = WorkerClient;
    class IpcServer {
        constructor(target) {
            this.nextConnectionId = 1;
            this.nextCallId = 1;
            this.connections = new Map();
            this.pendingCalls = new Map();
            this.Target = target;
            var server = this;
            if (WorkerGlobalScope.importScripts) {
                if (SharedWorkerGlobalScope.onconnect) {
                    SharedWorkerGlobalScope.onconnect = function (e) {
                        var port = e.ports[0];
                        server.connect(port);
                    };
                }
                else if (DedicatedWorkerGlobalScope.postMessage) {
                    this.connect(DedicatedWorkerGlobalScope);
                }
            }
        }
        connect(port) {
            var id = this.nextConnectionId++;
            this.connections.set(id, port);
            ;
            var server = this;
            port.onmessage = function (ev) {
                return __awaiter(this, void 0, void 0, function* () {
                    var d = ev.data;
                    if (d.callId) {
                        var response = yield server.Target[d.method](d.args);
                        port.postMessage({
                            returnCallId: d.callId,
                            args: response,
                            method: d.method,
                            id: d.id
                        });
                    }
                    else if (d.returnCallId) {
                        server.pendingCalls.get(d.returnCallId).Resolve(d.args);
                    }
                    else {
                        server.Target[d.method](d.args);
                    }
                });
            };
            return id;
        }
        disconnect(id) {
            this.connections.delete(id);
        }
        callClient(m) {
            this.connections.get(m.id).postMessage(m);
        }
        callClientAsync(m) {
            m.callId = this.nextCallId++;
            var pcs = new PromiseCompletionSource();
            this.pendingCalls.set(m.callId, pcs);
            this.connections.get(m.id).postMessage(m);
            return pcs.Task;
        }
    }
    CodexIpc.IpcServer = IpcServer;
})(CodexIpc || (CodexIpc = {}));
//# sourceMappingURL=ipc.js.map