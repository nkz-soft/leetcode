namespace Leetcode._108_Convert_Sorted_Array_to_Binary_Search_Tree;

using System.Collections;
using Common;
using FluentAssertions;
using Xunit;

public class Solution
{
    public TreeNode? SortedArrayToBST(int[] nums)
    {
        var root = BuildTree(nums, 0, nums.Length - 1);
        return root;
    }

    private TreeNode? BuildTree(int[] nums, int leftIndex, int rightIndex)
    {
        if (leftIndex > rightIndex)
        {
            return null;
        }

        var mid = (leftIndex + rightIndex) / 2;

        var leftNode = BuildTree(nums, leftIndex, mid - 1);
        var rightNode = BuildTree(nums, mid + 1, rightIndex);

        return new TreeNode(nums[mid], leftNode, rightNode);
    }

    [Theory]
    [ClassData(typeof(SortedArrayToBSTTestData))]
    public void SortedArrayToBSTTest(int[] nums, TreeNode expected)
    {
        SortedArrayToBST(nums).Should().BeEquivalentTo(expected);
    }

    private class SortedArrayToBSTTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return
            [
                new[] {-10, -3, 0, 5, 9},
                             new TreeNode(
                                 0,
                                 new TreeNode(-10, null, new TreeNode(-3)),
                                 new TreeNode(5, null, new TreeNode(9))
                                 ),
            ];
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}


