namespace Misaki;

public static class FrameSizeHelper
{
    public static IImageFrame PickClosest(this IReadOnlyCollection<IImageFrame> frames, int width, int height)
    {
        if (frames.Count is 0)
            return ThrowHelper.InvalidOperation<IImageFrame>("No frames available.");
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
}
