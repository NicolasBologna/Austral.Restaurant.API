using Austral.Restaurant.API.Models.Enum;

namespace Austral.Restaurant.API.Extensions;

public static class LabelFlagsExtensions
{
    public static Label ToFlags(this IEnumerable<Label>? list)
    => list == null ? Label.None : list.Aggregate(Label.None, (acc, l) => acc | l);

    public static List<Label> ToList(this Label flags)
    {
        var result = new List<Label>();
        foreach (var l in Enum.GetValues<Label>())
        {
            if (l == Label.None) continue;
            if (flags.HasFlag(l)) result.Add(l);
        }
        return result;
    }
}