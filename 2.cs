using System;
using NUnit.Framework.Internal.Commands;
public class EnergyFieldSystem
{
    public static float MaxEnergyField(int[] heights)
    {
        int maxSize = 0;
        int len = heights.Length;
        for(int i = 0; i < len; i++){
            for(int j = i+1; j < len; j++){
                int size = (heights[i] + heights[j]) * (j - i);
                maxSize = Math.Max(size, maxSize);
            }
        }
        float maxField = maxSize/2.0f;
        return maxField;
    }
}
 
public class EnergyFieldSystemTests
{
    [Test]
    public void TestMaxEnergyField()
    {
        int [] heights = [1,8,6,2,5,4,8,3,7];
        float actual = EnergyFieldSystem.MaxEnergyField(heights);
        float expected = 52.5f;
        Assert.That(actual, Is.EqualTo(expected));
    }
}

// 时间复杂度O(n^2)

// 进阶挑战
// 1.临时改变高度不需要修改遍历模式，因为本质上还是选两座塔
// 如果增加的是定值，只需要在两座塔的总和上加上增加的部分；如果是比例，可以以左侧塔为标准确定增加量
// 2.不会造成影响，上述代码可以正常工作（建筑限制不是能量场限制，三角形可以视为梯形的特例）

// 创意思考
// 玩家会尽可能选择面积更大的梯形设计能量塔；
// 目的上可以令玩家持续的根据能量场的面积获得收益；
// 可以和其他机制联合，如限制某块区域能量场不生效或降低收益;
// 可以限制玩家获取的信息，如选择了第5座塔，才能看到第4和第6座塔的高度。同时需要拆除一座旧的塔才能建造一座新的塔