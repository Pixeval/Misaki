// Copyright (c) Misaki.
// Licensed under the GPL v3 License.

namespace Misaki;

public readonly record struct TagCategory(string Name, string TranslatedName = "", string Description = "") : ITagCategory;
