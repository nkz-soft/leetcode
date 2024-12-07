using Xunit;

namespace Leetcode._1_Two_Sum;

using FluentAssertions;

public class Solution
{
    public static int[] TwoSum(int[] nums, int target)
    {
        var dictionary = new Dictionary<int, int>();

        for (var i = 0; i < nums.Length; i++)
        {
            var complement = target - nums[i];
            if (dictionary.TryGetValue(complement, out var value))
                return [value, i,];

            dictionary[nums[i]] = i;
        }
        return [];
    }

    [Theory]
    [InlineData(new[] { 2, 7, 11, 15 }, 9, new[] { 0, 1 })]
    [InlineData(new[] { 3, 2, 4 }, 6, new[] { 1, 2 })]
    [InlineData(new[] { 3, 3 }, 6, new[] { 0, 1 })]
    public void TwoSumTest(int[] nums, int target, int[] expectedResult)
    {
        TwoSum(nums, target).Should().BeEquivalentTo(expectedResult);
    }
}
