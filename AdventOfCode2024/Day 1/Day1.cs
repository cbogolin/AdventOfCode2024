namespace AdventOfCode2024.Day_1;

public static class Day1
{
    public static List<int> SortList(List<int> list)
    {
        return list.OrderBy(x => x).ToList();
    }
    
    public static int GetTotalDiffs(List<int> list1, List<int> list2)
    {
        return list1.Select(
            (t, i) => Math.Abs(t - list2[i])
            ).Sum();
    }
}