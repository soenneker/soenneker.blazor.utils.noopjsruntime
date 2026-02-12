using Microsoft.JSInterop;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Blazor.Utils.NoOpJSRuntime.Tests;

[Collection("Collection")]
public sealed class NoOpJSRuntimeTests : FixturedUnitTest
{
    private readonly IJSRuntime _util;

    public NoOpJSRuntimeTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<IJSRuntime>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
