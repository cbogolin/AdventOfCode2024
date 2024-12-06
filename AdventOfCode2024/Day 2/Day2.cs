namespace AdventOfCode2024.Day_2;

public class Day2 : AdventDayBase
{
    public override void Run()
    {
        var data = File.ReadLines(@"Day 2\Day2Input.txt");
        var reportsList = data.Select(line => line.Split(' ').Select(int.Parse).ToList()).ToList();

        var safeReports = GetCountOfSafeReports(reportsList);
        Console.WriteLine($"SafeReports: {safeReports}");
        
        safeReports = GetCountOfSafeReportsWithDampener(reportsList);
        Console.WriteLine($"SafeReportsWithDampener: {safeReports}");
    }

    private static int GetCountOfSafeReports(List<List<int>> list)
    {
        return list.Count(IsReportSafe);
    }
    
    private static int GetCountOfSafeReportsWithDampener(List<List<int>> list)
    {
        return list.Count(IsReportSafeWithDampener);
    }

    private static bool IsReportSafeWithDampener(List<int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            var tempReport = new List<int>(list);
            tempReport.RemoveAt(i);
            if (IsReportSafe(tempReport)) return true;
        }

        return false;
    }
    
    private static bool IsReportSafe(List<int> report)
    {
        bool? valueIncreasing = null;
        for (var i = 0; i < report.Count - 1; i++)
        {
            //check if numbers change
            if (report[i] == report[i + 1])
                return false;
            
            //check if difference is too much
            if (Math.Abs(report[i] - report[i + 1]) >= 4)
                return false;
            
            //check if values increasing
            if (report[i + 1] > report[i])
            {
                if (valueIncreasing is null or true)
                {
                    valueIncreasing = true;
                    continue;
                }
                return false;
            }
            
            //check if values decreasing
            if (report[i + 1] < report[i])
            {
                if (valueIncreasing is null or false)
                {
                    valueIncreasing = false;
                    continue;
                }
                return false;
            }
        }
        
        return true;
    }
}