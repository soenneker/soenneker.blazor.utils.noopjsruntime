using System.Threading;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Soenneker.Blazor.Utils.NoOpJSRuntime;

/// <summary>
/// A no-op <see cref="IJSRuntime"/> implementation that returns default values and performs no work.
/// Useful for tests, prerendering, or environments where JS interop is intentionally disabled.
/// </summary>
// ReSharper disable once InconsistentNaming
public sealed class NoOpJSRuntime : IJSRuntime
{
    /// <summary>
    /// Always returns default(<typeparamref name="TValue"/>) and performs no JS invocation.
    /// </summary>
    public ValueTask<TValue> InvokeAsync<TValue>(string identifier, object?[]? args)
        => new(default(TValue)!);

    /// <summary>
    /// Always returns default(<typeparamref name="TValue"/>) and performs no JS invocation.
    /// </summary>
    public ValueTask<TValue> InvokeAsync<TValue>(string identifier, CancellationToken cancellationToken, object?[]? args)
        => new(default(TValue)!);
}