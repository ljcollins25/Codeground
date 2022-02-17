namespace Codex.Ipc {
    class PromiseCompletionSource {
        Resolve: any;
        Reject: any;
        Task: Promise<any>;
        constructor() {
            var self = this;
            this.Task = new Promise(function (resolve, reject) {
                self.Resolve = resolve;
                self.Reject = reject;
            });
        }
    }

    interface IMessage {
        id: number,
        method: string,
        args: any,
        callId: any
    }

    class IpcServer<T> {
        public Target: T;
        private nextConnectionId = 0;
        private nextCallId = 0;
        private connections = new Map<number, MessagePort>();
        private pendingCalls = new Map<number, PromiseCompletionSource>();

        public connect(port: MessagePort) {
            var id = this.nextConnectionId++;
            this.connections.set(id, port);;
            var server = this;

            port.onmessage = function (ev) {
                var d: IMessage = ev.data;
                server.Target[d.method](d.id, d.args);
            };
        }

        public disconnect(id: number) {
            this.connections.delete(id);
        }

        public callClient(m: IMessage) {
            this.connections.get(m.id).postMessage(m);
        }

        public callClientAsync<T>(m: IMessage) : Promise<T> {
            m.callId = this.nextCallId++;
            var pcs = new PromiseCompletionSource();
            this.pendingCalls.set(m.callId, pcs);

            this.connections.get(m.id).postMessage(m);
            return pcs.Task;
        }

    }
}