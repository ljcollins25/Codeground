var DefaultWindowTitle = "Index";
var CodexIpc;
(function (CodexIpc) {
    class CodexPage {
        constructor() {
            this.leftPane = document.getElementById("leftPane");
            this.rightPane = document.getElementById("rightPane");
            this.Server = new CodexIpc.IpcServer(this);
        }
        setLeftPane(innerHtml) {
            if (!innerHtml) {
                innerHtml = "<div></div>";
            }
            this.leftPane.innerHTML = innerHtml;
        }
        setPageTitle(title) {
            if (!title) {
                title = DefaultWindowTitle;
            }
            document.title = title;
        }
        setRightPane(innerHtml) {
            if (!innerHtml) {
                innerHtml = "<div></div>";
            }
            this.rightPane.innerHTML = innerHtml;
        }
    }
    CodexIpc.CodexPage = CodexPage;
})(CodexIpc || (CodexIpc = {}));
var CodexPage = new CodexIpc.CodexPage();
var workerClient = new CodexIpc.WorkerClient(CodexPage.Server, "./ts/worker.main.js");
workerClient.Target.log("Hi worker").then(r => {
    console.log("Received: " + r);
});
//var SharedWorkerClient = new CodexIpc.SharedWorkerClient(CodexPage.Server, "sharedworker.main.js")
function CxNav(link) {
    var url = link.getAttribute("href");
    console.log("Navigating to: " + url);
}
//# sourceMappingURL=page.main.js.map