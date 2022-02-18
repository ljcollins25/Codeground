var DefaultWindowTitle = "Index";

namespace CodexIpc {
    export class CodexPage implements ICodexPage {
        private leftPane: HTMLDivElement;
        private rightPane: HTMLDivElement;

        public Server: CodexIpc.IpcServer;

        constructor() {
            this.leftPane = document.getElementById("leftPane") as HTMLDivElement;
            this.rightPane = document.getElementById("rightPane") as HTMLDivElement;

            this.Server = new CodexIpc.IpcServer(this);
        }
        setLeftPane(innerHtml?: string): void {
            if (!innerHtml) {
                innerHtml = "<div></div>";
            }
            this.leftPane.innerHTML = innerHtml;
        }

        setPageTitle(title?): void {
            if (!title) {
                title = DefaultWindowTitle;
            }

            document.title = title;
        }

        setRightPane(innerHtml?: string): void {
            if (!innerHtml) {
                innerHtml = "<div></div>";
            }
            this.rightPane.innerHTML = innerHtml;
        }
    }
}

var CodexPage = new CodexIpc.CodexPage();

var workerClient = new CodexIpc.WorkerClient<CodexIpc.LoggerService>(CodexPage.Server, "./ts/worker.main.js");

workerClient.Target.log("Hi worker").then(r => {
    console.log("Received: " + r);
});

//var SharedWorkerClient = new CodexIpc.SharedWorkerClient(CodexPage.Server, "sharedworker.main.js")

function CxNav(link) {
    var url = link.getAttribute("href");
    console.log("Navigating to: " + url);

}