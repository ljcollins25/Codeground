namespace CodexIpc {
    export interface ICodexPage {
        setLeftPane(innerHtml?: string): void;
        setRightPane(innerHtml?: string): void;
    }

    export class LoggerService {
        async log(message: string) {
            console.log(message);
            return 1234;
        }
    }
}