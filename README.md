[![](https://img.shields.io/nuget/v/Soenneker.Utils.ResettableLazy.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Utils.ResettableLazy/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.utils.resettablelazy/publish.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.utils.resettablelazy/actions/workflows/publish.yml)
[![](https://img.shields.io/nuget/dt/Soenneker.Utils.ResettableLazy.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Utils.ResettableLazy/)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Utils.ResettableLazy
### A thread-safe resettable lazy implementation

## Installation

```
Install-Package Soenneker.Utils.ResettableLazy
```

## Usage

```csharp
var _httpClientLazy = new ResettableLazy<HttpClient>(() => httpClientFactory.CreateClient("", true);

// HttpClient is created from the factory at this point
_httpClientLazy.Value.GetAsync("http://google.com");

// flushes the lazy's cache
_httpClientLazy.Reset();

// A new HttpClient is created from the factory again since Reset() was called
_httpClientLazy.Value.GetAsync("http://google.com");

```