
self.importScripts("./ipc.js", "./definitions.js");

var loggerService = new CodexIpc.LoggerService();
var server = new CodexIpc.IpcServer(loggerService);