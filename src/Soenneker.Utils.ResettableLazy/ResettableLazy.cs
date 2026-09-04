using System;
using System.Threading;
using Soenneker.Utils.ResettableLazy.Abstract;

namespace Soenneker.Utils.ResettableLazy;

/// <inheritdoc cref="IResettableLazy{T}" />
public sealed class ResettableLazy<T> : IResettableLazy<T>
{
    private Lazy<T> _lazy;

    public bool IsValueCreated => Volatile.Read(ref _lazy).IsValueCreated;

    public T Value => Volatile.Read(ref _lazy).Value;

    private readonly Func<T> _valueFactory;

    public ResettableLazy(Func<T> valueFactory)
    {
        _valueFactory = valueFactory;
        Volatile.Write(ref _lazy, new Lazy<T>(_valueFactory, LazyThreadSafetyMode.ExecutionAndPublication));
    }

    public void Reset()
    {
        _lazy = new Lazy<T>(_valueFactory, LazyThreadSafetyMode.ExecutionAndPublication);
    }
}
