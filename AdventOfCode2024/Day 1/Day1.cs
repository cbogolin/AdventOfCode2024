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

    public static int GetSimilarityScore(List<int> list1, List<int> list2)
    {
        var score = 0;
        var groupedList2 = list2.GroupBy(x => x);

        foreach (var t in list1)
        {
            score += t * groupedList2.FirstOrDefault(x => x.Key ==  t)?.Count() ?? 0;
        }
        
        return score;
    }
}