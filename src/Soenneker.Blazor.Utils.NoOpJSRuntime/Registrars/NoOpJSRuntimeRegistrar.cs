using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.JSInterop;
// ReSharper disable InconsistentNaming

namespace Soenneker.Blazor.Utils.NoOpJSRuntime.Registrars;

/// <summary>
/// An IJSRuntime implementation that returns default values and performs no work.
/// </summary>
public static class NoOpJSRuntimeRegistrar
{
    /// <summary>
    /// Adds <see cref="NoOpJSRuntime"/> as a singleton service. <para/>
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddNoOpJSRuntimeAsSingleton(this IServiceCollection services)
    {
        services.TryAddSingleton<IJSRuntime, NoOpJSRuntime>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="NoOpJSRuntime"/> as a scoped service. <para/>
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddNoOpJSRuntimeAsScoped(this IServiceCollection services)
    {
        services.TryAddScoped<IJSRuntime, NoOpJSRuntime>();

        return services;
    }
}
