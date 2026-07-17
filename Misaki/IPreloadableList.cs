// Copyright (c) Misaki.
// Licensed under the GPL v3 License.

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Misaki;

[CollectionBuilder(typeof(PreloadableList), nameof(PreloadableList.Create))]
public interface IPreloadableList<out T> : IReadOnlyList<T>
{
    bool IsPreloaded { get; }

    ValueTask PreloadListAsync(IMisakiService service, CancellationToken token = default);
}
