namespace AdventOfCode2024.Day_1;

public class Day1 : AdventDayBase
{
    public override void Run()
    {
        var sortedList1 = SortList(Inputs.List1);
        var sortedList2 = SortList(Inputs.List2);

        Console.WriteLine($"GetTotalDiffs() = {GetTotalDiffs(sortedList1, sortedList2)}");
        Console.WriteLine($"GetSimilarityScore() = {GetSimilarityScore(sortedList2, sortedList1)}");
    }

    private static List<int> SortList(List<int> list)
    {
        return list.OrderBy(x => x).ToList();
    }
    
    private static int GetTotalDiffs(List<int> list1, List<int> list2)
    {
        return list1.Select(
            (t, i) => Math.Abs(t - list2[i])
            ).Sum();
    }

    private static int GetSimilarityScore(List<int> list1, List<int> list2)
    {
        var score = 0;
        var groupedList2 = list2.GroupBy(x => x).ToList();

        foreach (var t in list1)
        {
            score += t * groupedList2.FirstOrDefault(x => x.Key ==  t)?.Count() ?? 0;
        }
        
        return score;
    }
}