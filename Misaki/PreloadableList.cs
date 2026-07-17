// Copyright (c) Misaki.
// Licensed under the GPL v3 License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Misaki;

public static class PreloadableList
{
    public delegate Task<IReadOnlyList<T>> AsyncGetter<T>(IMisakiService service);

    public delegate IReadOnlyList<T> ParamGetter<out T, in TParam>(TParam param);

    public delegate Task<TParam> ParamFactory<TParam>(IMisakiService service);

    public static IPreloadableList<T> Empty<T>() => new EmptyPreloadableList<T>();
    
    extension<T>(IReadOnlyList<T> source)
    {
        public IPreloadableList<T> ToPreloadableList() => new Wrapper<T>(source);
    }
    
    public static IPreloadableList<T> ToPreloadableList<T, TParam>(TParam? param, ParamFactory<TParam> paramFactory, ParamGetter<T, TParam> source) where TParam : class
    {
        return param is null
            ? new ParamAsyncWrapper<T, TParam>(paramFactory, source)
            : new Wrapper<T>(source(param));
    }

    public static IPreloadableList<T> ToPreloadableList<T>(AsyncGetter<T> source) => new AsyncWrapper<T>(source);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static IPreloadableList<T> Create<T>(ReadOnlySpan<T> source) => source.Length is 0 ? Empty<T>() : new Wrapper<T>(source.ToArray());

    private class Wrapper<T>(IReadOnlyList<T> source) : IPreloadableList<T>
    {
        public bool IsPreloaded => true;

        public ValueTask PreloadListAsync(IMisakiService service, CancellationToken token = default) => ValueTask.CompletedTask;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<T> GetEnumerator() => source.GetEnumerator();

        public int Count => source.Count;

        public T this[int index] => source[index];
    }

    private abstract class AsyncWrapperBase<T> : IPreloadableList<T>
    {
        private const string NotPreloadedMessage = "The enumerable has not been preloaded yet.";

        protected IReadOnlyList<T>? Cache;

        [MemberNotNullWhen(true, nameof(Cache))]
        public bool IsPreloaded => Cache is not null;

        public abstract ValueTask PreloadListAsync(IMisakiService service, CancellationToken token = default);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<T> GetEnumerator() => IsPreloaded
            ? Cache.GetEnumerator()
            : throw new InvalidOperationException(NotPreloadedMessage);

        public int Count => IsPreloaded
            ? Cache.Count
            : throw new InvalidOperationException(NotPreloadedMessage);

        public T this[int index] => IsPreloaded
            ? Cache[index]
            : throw new InvalidOperationException(NotPreloadedMessage);
    }

    private class AsyncWrapper<T>(AsyncGetter<T> source) : AsyncWrapperBase<T>
    {
        public override async ValueTask PreloadListAsync(IMisakiService service, CancellationToken token = default)
        {
            if (!IsPreloaded)
                Cache = await source(service);
        }
    }
    
    private class ParamAsyncWrapper<T, TParam>(
        ParamFactory<TParam> paramFactory,
        ParamGetter<T, TParam> source) : AsyncWrapperBase<T>
    {
        public override async ValueTask PreloadListAsync(IMisakiService service, CancellationToken token = default)
        {
            if (!IsPreloaded)
                Cache = source(await paramFactory(service));
        }
    }

    private class EmptyPreloadableList<T> : IPreloadableList<T>
    {
        public bool IsPreloaded => true;

        public ValueTask PreloadListAsync(IMisakiService service, CancellationToken token = default) => ValueTask.CompletedTask;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<T> GetEnumerator() => Enumerable.Empty<T>().GetEnumerator();

        public int Count => 0;

        public T this[int index] => throw new IndexOutOfRangeException($"{nameof(EmptyPreloadableList<>)}: {index} out of range");
    }
}
