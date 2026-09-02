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
    public async Task Returns_default_value(CancellationToken cancellationToken)
    {
        bool value = await _util.InvokeAsync<bool>("test.value", cancellationToken);
        value.Should().BeFalse();
    }

    [Test]
    public async Task Honors_pre_cancelled_token()
    {
        using var source = new CancellationTokenSource();
        await source.CancelAsync();

        Func<Task> act = async () => await _util.InvokeAsync<bool>("test.value", source.Token);

        await act.Should().ThrowAsync<OperationCanceledException>();
    }
}
