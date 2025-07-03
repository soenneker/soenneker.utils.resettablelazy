using System;
using System.Threading;
using Soenneker.Utils.ResettableLazy.Abstract;

namespace Soenneker.Utils.ResettableLazy;

///<inheritdoc cref="IResettableLazy{T}"/>
public sealed class ResettableLazy<T> : IResettableLazy<T>
{
    private Lazy<T> _lazy;

    public bool IsValueCreated => _lazy.IsValueCreated;

    public T Value => _lazy.Value;

    private readonly Func<T> _valueFactory;

    public ResettableLazy(Func<T> valueFactory)
    {
        _valueFactory = valueFactory;
        _lazy = new Lazy<T>(_valueFactory, LazyThreadSafetyMode.ExecutionAndPublication);
    }

    public void Reset()
    {
        _lazy = new Lazy<T>(_valueFactory, LazyThreadSafetyMode.ExecutionAndPublication);
    }
}