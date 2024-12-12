using Xunit;

namespace Leetcode._112_Path_Sum;

using System.Collections;
using Common;
using FluentAssertions;

public class Solution
{
    public bool HasPathSum(TreeNode? root, int targetSum)
    {
        if (root is null)
        {
            return false;
        }

        targetSum -= root.val;
        if (targetSum == 0 && root.left is null && root.right is null)
        {
            return true;
        }
        return HasPathSum(root.left, targetSum) || HasPathSum(root.right, targetSum);
    }

    [Theory]
    [ClassData(typeof(HasPathSumTestData))]
    public void HasPathSumTest(TreeNode root, int targetSum, bool expected)
    {
        HasPathSum(root, targetSum).Should().Be(expected);
    }

    class HasPathSumTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return
            [
                new TreeNode(5,
                    new TreeNode(4,
                        new TreeNode(11,
                            new TreeNode(7),
                            new TreeNode(2))),
                    new TreeNode(8,
                        new TreeNode(13),
                        new TreeNode(4,
                            null,
                            new TreeNode(1)))
                    ),
                22,
                true
            ];

            yield return
            [
                new TreeNode(1,
                    new TreeNode(2),
                    new TreeNode(3)
                    ),
                5,
                false
            ];
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
