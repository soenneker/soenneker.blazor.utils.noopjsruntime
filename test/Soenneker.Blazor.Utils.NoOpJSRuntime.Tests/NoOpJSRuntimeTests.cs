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
    public void Default()
    {

    }
}
