namespace Misaki;

public static class FrameSizeHelper
{
    private static void ThrowIfEmpty(IReadOnlyCollection<IImageFrame> frames)
    {
        if (frames.Count is 0)
            ThrowHelper.InvalidOperation("No frames available.");
    }

    public static IImageFrame PickClosest(this IReadOnlyCollection<IImageFrame> frames, int width, int height)
    {
        ThrowIfEmpty(frames);
        IImageFrame closest = null!;
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

    public static IImageFrame PickClosestHeight(this IReadOnlyCollection<IImageFrame> frames, int height)
    {
        ThrowIfEmpty(frames);
        IImageFrame closest = null!;
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
}
