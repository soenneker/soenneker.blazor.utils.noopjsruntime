using System.Threading;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Soenneker.Blazor.Utils.NoOpJSRuntime;

/// <summary>
/// A no-op <see cref="IJSRuntime"/> implementation that returns default values and performs no work.
/// Useful for tests, prerendering, or environments where JS interop is intentionally disabled.
/// </summary>
// ReSharper disable once InconsistentNaming
/// <summary>
/// Represents the no op js runtime.
/// </summary>
public sealed class NoOpJSRuntime : IJSRuntime
{
    /// <summary>
    /// Always returns default(<typeparamref name="TValue"/>) and performs no JS invocation.
    /// </summary>
    /// <typeparam name="TValue">Type of value stored or returned by the operation.</typeparam>
    /// <param name="identifier">Identifier of the target value.</param>
    /// <param name="args">Command-line arguments passed to the application.</param>
    /// <returns>A task whose result is the value returned by invoke Async.</returns>
    public ValueTask<TValue> InvokeAsync<TValue>(string identifier, object?[]? args)
        => new(default(TValue)!);

    /// <summary>
    /// Always returns default(<typeparamref name="TValue"/>) and performs no JS invocation.
    /// </summary>
    /// <typeparam name="TValue">Type of value stored or returned by the operation.</typeparam>
    /// <param name="identifier">Identifier of the target value.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <param name="args">Command-line arguments passed to the application.</param>
    /// <returns>A task whose result is the value returned by invoke Async.</returns>
    public ValueTask<TValue> InvokeAsync<TValue>(string identifier, CancellationToken cancellationToken, object?[]? args)
        => new(default(TValue)!);
}
