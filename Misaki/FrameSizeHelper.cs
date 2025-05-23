namespace Misaki;

public static class FrameSizeHelper
{
    public static T? PickClosest<T>(this IReadOnlyCollection<T> frames, int width, int height) where T : IImageSize
    {
        T? closest = default;
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

    public static T? PickClosestHeight<T>(this IReadOnlyCollection<T> frames, int height) where T : IImageSize
    {
        T? closest = default;
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

    public static T? PickMax<T>(this IReadOnlyCollection<T> frames) where T : IImageSize
    {
        T? max = default;
        var maxArea = 0;
        foreach (var frame in frames)
        {
            var area = frame.Width * frame.Height;
            if (area > maxArea)
            {
                max = frame;
                maxArea = area;
            }
        }
        return max;
    }
}
