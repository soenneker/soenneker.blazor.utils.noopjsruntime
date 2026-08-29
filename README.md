[![](https://img.shields.io/nuget/v/soenneker.blazor.utils.noopjsruntime.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.blazor.utils.noopjsruntime/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blazor.utils.noopjsruntime/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.blazor.utils.noopjsruntime/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.blazor.utils.noopjsruntime.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.blazor.utils.noopjsruntime/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blazor.utils.noopjsruntime/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.blazor.utils.noopjsruntime/actions/workflows/codeql.yml)

# Soenneker.Blazor.Utils.NoOpJSRuntime

An IJSRuntime implementation that returns default values and performs no work.

## Install

```bash
dotnet add package Soenneker.Blazor.Utils.NoOpJSRuntime
```

## Quick start

```csharp
using Soenneker.Blazor.Utils.NoOpJSRuntime.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddNoOpJSRuntimeAsSingleton();
```

Adds `NoOpJSRuntime` as a singleton service.

## What you get

- `NoOpJSRuntimeRegistrar` — An IJSRuntime implementation that returns default values and performs no work.
- `NoOpJSRuntime` — Represents the no op js runtime.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `NoOpJSRuntimeRegistrar.AddNoOpJSRuntimeAsSingleton(services)` | Adds `NoOpJSRuntime` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `NoOpJSRuntimeRegistrar.AddNoOpJSRuntimeAsScoped(services)` | Adds `NoOpJSRuntime` as a scoped service. | The same service collection, so additional registrations can be chained. |
| `NoOpJSRuntime.InvokeAsync(identifier, args)` | Always returns default(`TValue`) and performs no JS invocation. | A task whose result is the value returned by invoke Async. |
| `NoOpJSRuntime.InvokeAsync(identifier, cancellationToken, args)` | Always returns default(`TValue`) and performs no JS invocation. | A task whose result is the value returned by invoke Async. |

## Practical notes

- Cancellation stops pending work; it does not undo work that has already completed.
