using System.Linq.Expressions;
using Advent_of_Code_2024.day04;

namespace Advent_of_Code_2024.day06;

public static partial class Day06
{
    public static string Part1(bool useExampleData)
    {
        string rawInput = Input.GetInput(useExampleData);
        
        var labMap = new Matrix(rawInput.Split('\n'));
        var avoidingTheGuard = new AvoidingTheGuard(labMap);
        return avoidingTheGuard.VisitedPositions.Count().ToString();
    }

    public static string Part2(bool useExampleData)
    {
        string rawInput = Input.GetInput(useExampleData);
        
        var labMap = new Matrix(rawInput.Split('\n'));
        var avoidingTheGuard = new AvoidingTheGuard(labMap);
        
        // now that we know visited positions, we can try to put an obstacle on each of them

        int waysToLoopTheGuard = 0;
        
        foreach (Pos visitedPos in avoidingTheGuard.VisitedPositions)
        {
            if (labMap.Get(visitedPos) == '^') continue;
            
            labMap.Set(visitedPos, '#');
            
            var loopingTheGuard = new AvoidingTheGuard(labMap);
            if (loopingTheGuard.HasGuardBeenLooped) waysToLoopTheGuard++;
            
            labMap.Set(visitedPos, '.');
        }
        
        return waysToLoopTheGuard.ToString();
    }
}