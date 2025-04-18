// Copyright (c) Misaki.
// Licensed under the GPL v3 License.

using System.Runtime.CompilerServices;

namespace Misaki;

[CollectionBuilder(typeof(PreloadableEnumerable), nameof(PreloadableEnumerable.Create))]
public interface IPreloadableEnumerable<out T> : IReadOnlyList<T>, IAsyncEnumerable<T>
{
    bool IsPreloaded { get; }

    ValueTask PreloadEnumerableAsync();
}
