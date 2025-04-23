// Copyright (c) Misaki.
// Licensed under the GPL v3 License.

using System.Runtime.CompilerServices;

namespace Misaki;

[CollectionBuilder(typeof(PreloadableList), nameof(PreloadableList.Create))]
public interface IPreloadableList<out T> : IReadOnlyList<T>
{
    bool IsPreloaded { get; }

    ValueTask PreloadListAsync(IMisakiService service);
}
