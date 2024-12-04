// See https://aka.ms/new-console-template for more information

using AdventOfCode2024.Day_1;

Console.WriteLine("Hello, World!");

var sortedList1 = Day1.SortList(Inputs.List1);
var sortedList2 = Day1.SortList(Inputs.List2);

Console.WriteLine($"GetTotalDiffs() = {Day1.GetTotalDiffs(sortedList1, sortedList2)}");