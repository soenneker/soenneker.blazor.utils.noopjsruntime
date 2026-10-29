using System;
using System.Threading;
using System.Threading.Tasks;
using AwesomeAssertions;
using Microsoft.JSInterop;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Blazor.Utils.NoOpJSRuntime.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class NoOpJSRuntimeTests : HostedUnitTest
{
    private readonly IJSRuntime _util;

    public NoOpJSRuntimeTests(Host host) : base(host)
    {
        _util = Resolve<IJSRuntime>(true);
    }

    [Test]
    public async ValueTask Returns_default_value(CancellationToken cancellationToken)
    {
        try
        {
            bool value = await _util.InvokeAsync<bool>("test.value", cancellationToken);
            value.Should().BeFalse();
        }
        catch (JSException exception)
        {
            throw new InvalidOperationException("The no-op runtime must not execute JavaScript.", exception);
        }
    }

    [Test]
    public async ValueTask Honors_pre_cancelled_token(CancellationToken cancellationToken)
    {
        using var source = new CancellationTokenSource();
        await source.CancelAsync();

        try
        {
            await _util.InvokeAsync<bool>("test.value", source.Token);
        }
        catch (OperationCanceledException exception)
        {
            exception.CancellationToken.Should().Be(source.Token);
            return;
        }

        throw new InvalidOperationException("The no-op runtime must honor a pre-cancelled token.");
    }
}
