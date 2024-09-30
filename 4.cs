using System;
public class TalentAssessmentSystem
{
    public static double FindMedianTalentIndex(int[] fireAbility, int[] iceAbility)
    {
        int lenFire = fireAbility.Length;
        int lenIce = iceAbility.Length;
        int len = lenFire + lenIce;
        int posFire = 0;
        int posIce = 0;
        int[] ability = new int[len];
        int i = 0;
        while(posFire < lenFire && posIce < lenIce){
            if(fireAbility[posFire] > iceAbility[posIce]){
                ability[i++] = iceAbility[posIce++];
            }else{
                ability[i++] = fireAbility[posFire++];
            }
        }
        while (posFire < lenFire){
            ability[i++] = fireAbility[posFire++];
        }
        while (posIce < lenIce){
            ability[i++] = iceAbility[posIce++];
        }

        double median = -1;
        if(len % 2 == 0){
            median = (ability[len/2-1] + ability[len/2])/2;
        }else{
            median = ability[len/2];
        }
        return median;
    }
}
 
public class TalentAssessmentSystemTests
{
    [Test]
    public void TestFindMedianTalentIndex1()
    {
        int [] fireAbility = [1,3,7,9,11];
        int [] iceAbility = [2,4,8,10,12,14];
        double actual = TalentAssessmentSystem.FindMedianTalentIndex(fireAbility, iceAbility);
        
        double expected = 8.0;
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void TestFindMedianTalentIndex2()
    {
        int [] fireAbility = [1,3,5];
        int [] iceAbility = [2,4,6,8,10,11,12,13,14,15];
        double actual = TalentAssessmentSystem.FindMedianTalentIndex(fireAbility, iceAbility);
        
        double expected = 8.0;
        Assert.That(actual, Is.EqualTo(expected));
    }
}

// 时间复杂度O(n)，空间复杂度O(n)

// 进阶挑战
// 需要实时更新时，可以采用链表而不是数组，便于更改顺序，用双指针取中位数
// 多个能力值可以采用同样的算法可以完成

// 这个系统鼓励玩家在某些方面均匀加点，至少有半数以上的天赋值高才能使中位数变得更高，最优策略是半数的加点同样高，剩余部分则几乎不动
// 可以根据中位值对玩家进行奖励或者限制，PVP中可以用来匹配相应层次的玩家
// 装备系统上可以根据中位值对装备效果进行加成，同理可以对应魔法加成等
// 采用中位值m，且有n个能力指标时，意味着玩家的加点至少需要达到(n/2)*m才能达到要求，可以以此限制某些任务的门槛数值