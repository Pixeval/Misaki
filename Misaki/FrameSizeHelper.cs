namespace Misaki;

public static class FrameSizeHelper
{
    private static void ThrowIfEmpty<T>(IReadOnlyCollection<T> frames)
    {
        if (frames.Count is 0)
            ThrowHelper.InvalidOperation("No frames available.");
    }

    public static T PickClosest<T>(this IReadOnlyCollection<T> frames, int width, int height) where T : IImageSize
    {
        ThrowIfEmpty(frames);
        T closest = default!;
        var closestDiff = int.MaxValue;
        foreach (var frame in frames)
        {
            var xDiff = frame.Width - width;
            var yDiff = frame.Height - height;
            var diff = xDiff * xDiff + yDiff * yDiff;
            if (diff < closestDiff)
            {
                closest = frame;
                closestDiff = diff;
            }
        }
        return closest;
    }

    public static T PickClosestHeight<T>(this IReadOnlyCollection<T> frames, int height) where T : IImageSize
    {
        ThrowIfEmpty(frames);
        T closest = default!;
        var closestDiff = int.MaxValue;
        foreach (var frame in frames)
        {
            var yDiff = Math.Abs(frame.Height - height);
            if (yDiff < closestDiff)
            {
                closest = frame;
                closestDiff = yDiff;
            }
        }
        return closest;
    }

    public static T PickMax<T>(this IReadOnlyCollection<T> frames) where T : IImageSize
    {
        ThrowIfEmpty(frames);
        T max = default!;
        var maxDiff = int.MaxValue;
        foreach (var frame in frames)
        {
            var diff = frame.Width * frame.Height;
            if (diff > maxDiff)
            {
                max = frame;
                maxDiff = diff;
            }
        }
        return max;
    }
}
