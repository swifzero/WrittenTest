using System;
using System.Collections.Generic;

public class LeaderboardSystem
{
    public static List<int> GetTopScores(int[] scores, int m)
    {
        if(scores.Length == 0 || m <= 0 || scores.Length < m){
            return [];
        }
        Array.Sort(scores, (a, b) => b.CompareTo(a));
        List<int> topList = new List<int>();
        for (int i = 0; i < m && i < scores.Length; i++)
        {
            topList.Add(scores[i]);
        }
        return topList;
    }
}

public class LeaderboardSystemTests
{
    [Test]
    public void TestGetTopScores1()
    {
        int[] scores = new int[] { };
        int m = 3;
        List<int> topScores = LeaderboardSystem.GetTopScores(scores, m);
        List<int> expected = [];
        Assert.That(topScores, Is.EqualTo(expected));
    }

    [Test]
    public void TestGetTopScores2()
    {
        int[] scores = new int[] { 100, 50, 75, 80, 65 };
        int m = 3;
        List<int> topScores = LeaderboardSystem.GetTopScores(scores, m);
        List<int> expected = [100, 80, 75];
        Assert.That(topScores, Is.EqualTo(expected));
    }
    
    [Test]
    public void TestGetTopScores3()
    {
        int[] scores = new int[] { 100, 50, 75, 80, 65 };
        int m = 6;
        List<int> topScores = LeaderboardSystem.GetTopScores(scores, m);
        List<int> expected = [];
        Assert.That(topScores, Is.EqualTo(expected));
    }

    [Test]
    public void TestGetTopScores4()
    {
        int[] scores = [100, 50, 75, 80, 65];
        int m = -1;
        List<int> topScores = LeaderboardSystem.GetTopScores(scores, m);
        List<int> expected = [];
        Assert.That(topScores, Is.EqualTo(expected));
    }
}

// 时间复杂度取决于Array.Sort的时间复杂度O(nlogn)

// 大规模数据算法优化
// 遍历一次数据，按区间划分
// 然后根据要求的人数，选从高到低取若干个区间，使用上述算法