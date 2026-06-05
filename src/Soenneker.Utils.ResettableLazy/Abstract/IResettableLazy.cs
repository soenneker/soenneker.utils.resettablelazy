namespace Soenneker.Utils.ResettableLazy.Abstract;

/// <summary>
/// A thread-safe resettable lazy implementation
/// </summary>
public interface IResettableLazy<T>
{
    /// <summary>
    /// Gets a value indicating whether the instance is value created.
    /// </summary>
    bool IsValueCreated { get; }

    /// <summary>
    /// Gets value.
    /// </summary>
    T Value { get; }

    /// <summary>
    /// Destroys the lazy's cache (safely), and the lazy's target will be re-initialized when fetching again
    /// </summary>
    void Reset();
}