namespace Bistrotic.Presentation.Abstractions
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.JSInterop;

    // This class provides an example of how JavaScript functionality can be wrapped in a .NET class
    // for easy consumption. The associated JavaScript module is loaded on demand when first needed.
    //
    // This class can be registered as scoped DI service and then injected into Blazor components
    // for use.

    public class ExampleJsInterop : IAsyncDisposable
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask;

        public ExampleJsInterop(IJSRuntime jsRuntime)
        {
            moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
               "import", "./_content/Bistrotic.Presentation.Abstractions/exampleJsInterop.js").AsTask());
        }

        public async ValueTask DisposeAsync()
        {
            if (moduleTask.IsValueCreated)
            {
                var module = await moduleTask.Value.ConfigureAwait(false);
                await module.DisposeAsync().ConfigureAwait(false);
            }
        }

        public async ValueTask<string> Prompt(string message)
        {
            var module = await moduleTask.Value.ConfigureAwait(false);
            return await module.InvokeAsync<string>("showPrompt", message).ConfigureAwait(false);
        }
    }
}