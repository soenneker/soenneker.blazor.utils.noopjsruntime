[![](https://img.shields.io/nuget/v/soenneker.blazor.utils.noopjsruntime.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.blazor.utils.noopjsruntime/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blazor.utils.noopjsruntime/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.blazor.utils.noopjsruntime/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.blazor.utils.noopjsruntime.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.blazor.utils.noopjsruntime/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blazor.utils.noopjsruntime/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.blazor.utils.noopjsruntime/actions/workflows/codeql.yml)

# Soenneker.Blazor.Utils.NoOpJSRuntime

An `IJSRuntime` stub that performs no JavaScript invocation and immediately returns `default(TValue)`.

Use it in tests or deliberately non-browser rendering paths where JavaScript effects are irrelevant and callers already tolerate default results. It does not emulate a browser or verify which calls were made.

## Installation

```bash
dotnet add package Soenneker.Blazor.Utils.NoOpJSRuntime
```

## Direct use

```csharp
IJSRuntime jsRuntime = new NoOpJSRuntime();

bool result = await jsRuntime.InvokeAsync<bool>("feature.isAvailable");
// result is false; JavaScript was not called.
```

Return behavior follows `default(TValue)`:

- `bool` returns `false`.
- Numeric value types return zero.
- Nullable and reference types return `null`.
- `InvokeVoidAsync` completes successfully.

Arguments are ignored and are not serialized. Invalid argument shapes that would fail real Blazor interop therefore do not fail here.

The cancellation-token overload returns a cancelled task when its token is already cancelled. Because every invocation otherwise completes synchronously, cancellation requested after the call cannot affect it.

## Dependency injection

Register one stateless instance for the application:

```csharp
using Soenneker.Blazor.Utils.NoOpJSRuntime.Registrars;

services.AddNoOpJSRuntimeAsSingleton();
```

A scoped registrar is also available:

```csharp
services.AddNoOpJSRuntimeAsScoped();
```

Both registrars use `TryAdd`, so they do not replace an `IJSRuntime` registration that already exists. In a test host where replacement is intentional, remove the existing descriptor first:

```csharp
using Microsoft.Extensions.DependencyInjection.Extensions;

services.RemoveAll<IJSRuntime>();
services.AddNoOpJSRuntimeAsSingleton();
```

## When not to use it

Do not use this runtime when the code under test must import an `IJSObjectReference`, read a non-null string or object, mutate browser state, or prove that a JavaScript call occurred. Default reference results can cause later null failures, while void calls can create false confidence that work succeeded.

Use a configurable or recording mock when assertions about identifiers, arguments, return values, or call counts matter. In production prerendering, prefer deferring browser-dependent work until interactive rendering rather than silently pretending that required JavaScript completed.

This runtime is not a security boundary. Replacing interop with a no-op must never bypass server-side authorization, validation, or required integrity checks.
