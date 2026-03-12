namespace Soenneker.Utils.ResettableLazy.Abstract;

/// <summary>
/// A thread-safe resettable lazy implementation
/// </summary>
public interface IResettableLazy<T>
{
    bool IsValueCreated { get; }

    T Value { get; }

    /// <summary>
    /// Destroys the lazy's cache (safely), and the lazy's target will be re-initialized when fetching again
    /// </summary>
    void Reset();
}