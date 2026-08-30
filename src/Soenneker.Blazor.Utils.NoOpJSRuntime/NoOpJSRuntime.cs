using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Soenneker.Blazor.Utils.NoOpJSRuntime;

// ReSharper disable once InconsistentNaming
/// <summary>
/// A no-op <see cref="IJSRuntime"/> that returns default values without invoking JavaScript.
/// </summary>
public sealed class NoOpJSRuntime : IJSRuntime
{
    /// <summary>
    /// Always returns default(<typeparamref name="TValue"/>) and performs no JS invocation.
    /// </summary>
    /// <typeparam name="TValue">Type of value stored or returned by the operation.</typeparam>
    /// <param name="identifier">Identifier of the target value.</param>
    /// <param name="args">Arguments that would have been passed to JavaScript.</param>
    /// <returns>A completed task containing the default value for <typeparamref name="TValue"/>.</returns>
    public ValueTask<TValue> InvokeAsync<TValue>(string identifier, object?[]? args)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(identifier);
        return new ValueTask<TValue>(default(TValue)!);
    }

    /// <summary>
    /// Always returns default(<typeparamref name="TValue"/>) and performs no JS invocation.
    /// </summary>
    /// <typeparam name="TValue">Type of value stored or returned by the operation.</typeparam>
    /// <param name="identifier">Identifier of the target value.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <param name="args">Arguments that would have been passed to JavaScript.</param>
    /// <returns>A completed task containing the default value for <typeparamref name="TValue"/>, or a cancelled task when cancellation was already requested.</returns>
    public ValueTask<TValue> InvokeAsync<TValue>(string identifier, CancellationToken cancellationToken, object?[]? args)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(identifier);

        return cancellationToken.IsCancellationRequested
            ? ValueTask.FromCanceled<TValue>(cancellationToken)
            : new ValueTask<TValue>(default(TValue)!);
    }
}
