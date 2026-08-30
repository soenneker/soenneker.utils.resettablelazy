[![](https://img.shields.io/nuget/v/Soenneker.Utils.ResettableLazy.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Utils.ResettableLazy/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.utils.resettablelazy/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.utils.resettablelazy/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/Soenneker.Utils.ResettableLazy.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Utils.ResettableLazy/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.utils.resettablelazy/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.utils.resettablelazy/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Utils.ResettableLazy

A synchronous `Lazy<T>` using execution-and-publication semantics that can publish a fresh lazy generation.

## Installation

```bash
dotnet add package Soenneker.Utils.ResettableLazy
```

## Usage

```csharp
using Soenneker.Utils.ResettableLazy;

var settings = new ResettableLazy<AppSettings>(LoadSettings);

AppSettings first = settings.Value; // LoadSettings runs once for this generation
bool loaded = settings.IsValueCreated; // true

settings.Reset();

AppSettings refreshed = settings.Value; // LoadSettings runs for the new generation
```

Within one generation, concurrent `Value` calls use `LazyThreadSafetyMode.ExecutionAndPublication`:
one caller runs the factory and the others receive the published result. A factory exception is
cached by that generation and rethrown by later `Value` calls until `Reset` publishes a new one.

## Reset semantics

`Reset` atomically publishes a new, uninitialized `Lazy<T>`. It does not wait for initialization of
the previous generation. A caller already evaluating or reading the old generation can still
receive its value while a later caller initializes the new generation, so code around the values
must tolerate that overlap.

The old value is not disposed, canceled, or otherwise invalidated. This is important for
`IDisposable` values: retain and coordinate ownership elsewhere if replaced generations require
cleanup. Do not use `Reset` as a resource-disposal mechanism.

`IsValueCreated` describes the generation observed by that property read. A concurrent reset can
make the next `Value` call refer to a different generation. The factory is synchronous; use an
async-lazy abstraction when initialization itself must be awaited.
