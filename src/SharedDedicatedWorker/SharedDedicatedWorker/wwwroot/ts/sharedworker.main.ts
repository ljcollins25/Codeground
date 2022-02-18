
self.importScripts("ipc.ts");
var loggerService = new CodexIpc.LoggerService();
var server = new CodexIpc.IpcServer(loggerService);