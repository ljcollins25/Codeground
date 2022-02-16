using System.Reflection;
using System.Reflection.Metadata.Ecma335;

#nullable disable
#nullable enable annotations

namespace BlazorConsoleApp
{
    public class MessageProxy : DispatchProxy
    {
        private ICodex _underlying;

        private Dictionary<string, Invoker> _invokers = new Dictionary<string, Invoker>();


        public void SetCodex(ICodex codex)
        {
            _underlying = codex;
            var a = codex.SearchAsync;
            _invokers[nameof(ICodex.SearchAsync)] = Invoker.Create(a);
        }

        protected override object? Invoke(MethodInfo? targetMethod, object?[]? args)
        {
            return _invokers[targetMethod.Name].Invoke(args);
        }
    }

    public record Invoker<TArg, TResult>(Func<TArg, TResult> Method) : Invoker
    {
        public override object? Invoke(object?[]? args)
        {
            return Method((TArg)args[0]);
        }
    }

    public abstract record Invoker
    {
        public abstract object? Invoke(object?[]? args);

        public static Invoker<TArg, TResult> Create<TArg, TResult>(Func<TArg, TResult> method)
        {
            return new Invoker<TArg, TResult>(method);
        }
    }

    public record TestCodex(int Increment) : ICodex
    {
        public async Task<string> SearchAsync(int input)
        {
            return (Increment + input).ToString();
        }
    }

    public interface ICodex
    {
        public Task<string> SearchAsync(int input);
    }

    
}
