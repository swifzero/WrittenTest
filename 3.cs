using System;
public class TreasureHuntSystem
{
    public static int MaxTreasureValue(int[] treasures)
    {
        int prev3 = treasures[0];
        int prev2 = treasures[1];
        int prev = treasures[2] + treasures[0];
        for(int i = 3; i < treasures.Length; i++){
            int temp = Math.Max(prev2, prev3) + treasures[i];
            prev3 = prev2;
            prev2 = prev;
            prev = temp;
        }
        return Math.Max(prev, prev2);
    }
}

public class TreasureHuntSystemTests
{
    [Test]
    public void TestMaxTreasureValue1()
    {
        int [] treasures = [3, 1, 5, 2, 4];
        int actual = TreasureHuntSystem.MaxTreasureValue(treasures);
        int expected = 12;
        Assert.That(actual, Is.EqualTo(expected));
    }
}

// 时间复杂度O(n),空间复杂度O(1)

// 进阶挑战
// 1.可以先算一遍没有用钥匙的最佳方案，然后再算一遍用钥匙的最佳方案
// 对于用钥匙的情况，可以视为将相邻两个箱子“捆绑销售”，对每种捆绑方式进行一次上述算法
// 2.对负值宝箱，由于选择必定是亏损，可以直接跳过选取，同时接下来下一个箱子可以从prev，prev2，prev3中选取最大者

// 创意思考
// 和前面能量场类似，可以在选取某个箱子以后显示附近若干个箱子的内容
// 这样大致策略可以分为：尽可能往更大的可视范围选择，最后来补选前面的大箱子；或者每一步都选择最大的，贪心选取