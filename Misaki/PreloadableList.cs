// Copyright (c) Misaki.
// Licensed under the GPL v3 License.

using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace Misaki;

public delegate Task<IReadOnlyList<T>> PreloadableListAsyncGetter<T>(IMisakiService service);


public delegate IReadOnlyList<T> PreloadableListParamGetter<out T, in TParam>(TParam param);


public delegate Task<TParam> PreloadableListParamFactory<TParam>(IMisakiService service);

public static class PreloadableList
{
    public static IPreloadableList<T> Empty<T>() => new EmptyPreloadableList<T>();
    
    public static IPreloadableList<T> ToPreloadableEnumerable<T>(this IReadOnlyList<T> source) => new PreloadableListWrapper<T>(source);
    
    public static IPreloadableList<T> ToPreloadableEnumerable<T, TParam>(TParam? param, PreloadableListParamFactory<TParam> paramFactory, PreloadableListParamGetter<T, TParam> source) where TParam : class
    {
        return param is null
            ? new PreloadableListAsyncParamWrapper<T, TParam>(paramFactory, source)
            : new PreloadableListWrapper<T>(source(param));
    }

    public static IPreloadableList<T> ToPreloadableEnumerable<T>(PreloadableListAsyncGetter<T> source) => new PreloadableListAsyncWrapper<T>(source);

    public static IPreloadableList<T> Create<T>(this ReadOnlySpan<T> source) => source.Length is 0 ? Empty<T>() : new PreloadableListWrapper<T>(source.ToArray());

    private class PreloadableListWrapper<T>(IReadOnlyList<T> source) : IPreloadableList<T>
    {
        public bool IsPreloaded => true;

        public ValueTask PreloadListAsync(IMisakiService service) => ValueTask.CompletedTask;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<T> GetEnumerator() => source.GetEnumerator();

        public int Count => source.Count;

        public T this[int index] => source[index];
    }
    
    private class PreloadableListAsyncWrapper<T>(PreloadableListAsyncGetter<T> source) : IPreloadableList<T>
    {
        private IReadOnlyList<T>? _cache;

        [MemberNotNullWhen(true, nameof(_cache))]
        public bool IsPreloaded => _cache is not null;

        public async ValueTask PreloadListAsync(IMisakiService service)
        {
            if (!IsPreloaded)
                _cache = await source(service);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<T> GetEnumerator() => IsPreloaded
            ? _cache.GetEnumerator()
            : ThrowHelper.InvalidOperation<IEnumerator<T>>("The enumerable has not been preloaded yet.");

        public int Count => IsPreloaded
            ? _cache.Count
            : ThrowHelper.InvalidOperation<int>("The enumerable has not been preloaded yet.");

        public T this[int index] => IsPreloaded
            ? _cache[index]
            : ThrowHelper.InvalidOperation<T>("The enumerable has not been preloaded yet.");
    }
    
    private class PreloadableListAsyncParamWrapper<T, TParam>(
        PreloadableListParamFactory<TParam> paramFactory,
        PreloadableListParamGetter<T, TParam> source) : IPreloadableList<T>
    {
        private IReadOnlyList<T>? _cache;

        [MemberNotNullWhen(true, nameof(_cache))]
        public bool IsPreloaded => _cache is not null;

        public async ValueTask PreloadListAsync(IMisakiService service)
        {
            if (!IsPreloaded)
                _cache = source(await paramFactory(service));
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<T> GetEnumerator() => IsPreloaded
            ? _cache.GetEnumerator()
            : ThrowHelper.InvalidOperation<IEnumerator<T>>("The enumerable has not been preloaded yet.");

        public int Count => IsPreloaded
            ? _cache.Count
            : ThrowHelper.InvalidOperation<int>("The enumerable has not been preloaded yet.");

        public T this[int index] => IsPreloaded
            ? _cache[index]
            : ThrowHelper.InvalidOperation<T>("The enumerable has not been preloaded yet.");
    }

    private class EmptyPreloadableList<T> : IPreloadableList<T>
    {
        public bool IsPreloaded => true;

        public ValueTask PreloadListAsync(IMisakiService service) => ValueTask.CompletedTask;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<T> GetEnumerator() => Enumerable.Empty<T>().GetEnumerator();

        public int Count => 0;

        public T this[int index] => ThrowHelper.IndexOutOfRange<T>($"EmptyPreloadableEnumerable: {index} out of range");
    }
}

internal static class ThrowHelper
{
    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static TReturn Throw<TReturn>(Exception exception) => throw exception;

    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void Throw(Exception exception) => throw exception;

    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static TResult Throw<TException, TResult>(TException e) where TException : Exception
        => throw e;

    /// <exception cref="InvalidOperationException"/>
    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void InvalidOperation(string? message = null)
        => throw new InvalidOperationException(message);

    /// <exception cref="InvalidOperationException"/>
    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static TReturn InvalidOperation<TReturn>(string? message = null)
        => throw new InvalidOperationException(message);

    /// <exception cref="InvalidCastException"/>
    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static TReturn InvalidCast<TReturn>(string? message = null)
        => throw new InvalidCastException(message);

    /// <exception cref="NotSupportedException"/>
    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static TReturn NotSupported<TReturn>(string? message = null)
        => throw new NotSupportedException(message);

    /// <exception cref="NotSupportedException"/>
    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void NotSupported(string? message = null)
        => throw new NotSupportedException(message);

    /// <exception cref="ArgumentException"/>
    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void Argument(string? message = null, Exception? innerException = null)
        => throw new ArgumentException(message, innerException);

    /// <exception cref="ArgumentOutOfRangeException"/>
    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ArgumentOutOfRange<T>(T? actualValue, string? message = null, [CallerArgumentExpression(nameof(actualValue))] string? paraName = null)
        => throw new ArgumentOutOfRangeException(paraName, actualValue, message);

    /// <exception cref="ArgumentOutOfRangeException"/>
    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static TReturn ArgumentOutOfRange<T, TReturn>(T? actualValue, string? message = null, [CallerArgumentExpression(nameof(actualValue))] string? paraName = null)
        => throw new ArgumentOutOfRangeException(paraName, actualValue, message);

    /// <exception cref="FormatException"/>
    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static TReturn Format<TReturn>(string? message = null)
        => throw new FormatException(message);

    /// <exception cref="UriFormatException"/>
    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static TReturn UriFormat<TReturn>(string? message = null)
        => throw new UriFormatException(message);

    /// <exception cref="KeyNotFoundException"/>
    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static TReturn KeyNotFound<TReturn>(string? message = null)
        => throw new KeyNotFoundException(message);

    /// <exception cref="JsonException"/>
    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static TReturn Json<TReturn>(string? message = null)
        => throw new JsonException(message);

    /// <exception cref="IndexOutOfRangeException"/>
    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static TReturn IndexOutOfRange<TReturn>(string? message = null)
        => throw new IndexOutOfRangeException(message);
}
