[![](https://img.shields.io/nuget/v/Soenneker.Utils.ResettableLazy.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Utils.ResettableLazy/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.utils.resettablelazy/main.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.utils.resettablelazy/actions/workflows/main.yml)
[![](https://img.shields.io/nuget/dt/Soenneker.Utils.ResettableLazy.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Utils.ResettableLazy/)

# Soenneker.Utils.ResettableLazy
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