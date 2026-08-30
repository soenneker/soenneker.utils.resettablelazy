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
    /// Publishes a new uninitialized lazy container. The previous value is not disposed.
    /// </summary>
    void Reset();
}
