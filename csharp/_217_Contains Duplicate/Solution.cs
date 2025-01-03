using Xunit;

namespace Leetcode._217_Contains_Duplicate;

public class Solution
{
    public bool ContainsDuplicate(int[] nums)
    {
        var seen = new HashSet<int>();
        foreach (var num in nums) {
            if (!seen.Add(num)) {
                return true;
            }
        }
        return false;
    }

    [Theory]
    [InlineData(new[] {1,2,3,1}, true)]
    [InlineData(new[] {1,2,3,4}, false)]
    [InlineData(new[] {1,1,1,3,3,4,3,2,4,2}, true)]
    public void ContainsDuplicateTest(int[] nums, bool expected)
    {
        var result = ContainsDuplicate(nums);
        Assert.Equal(expected, result);
    }
}
