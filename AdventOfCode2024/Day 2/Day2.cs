namespace AdventOfCode2024.Day_2;

public class Day2 : AdventDayBase
{
    public override void Run()
    {
        var data = File.ReadLines(@"Day 2\Day2Input.txt");
        var reportsList = data.Select(line => line.Split(' ').Select(int.Parse).ToArray()).ToList();

        var safeReports = GetCountOfSafeReports(reportsList);
        Console.WriteLine($"SafeReports: {safeReports}");
    }

    private int GetCountOfSafeReports(List<int[]> list)
    {
        return list.Count(report => IsReportSafe(report));
    }

    private bool IsReportSafe(int[] report)
    {
        bool? valueIncreasing = null;
        for (int i = 0; i < report.Length - 1; i++)
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