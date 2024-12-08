using Xunit;

namespace Leetcode._100_Same_Tree;

using System.Collections;
using Common;
using FluentAssertions;

public class Solution
{
    public bool IsSameTree(TreeNode? p, TreeNode? q)
    {
        if (p is null && q is null)
        {
            return true;
        }

        if (p is null || q is null)
        {
            return false;
        }

        if (p.val != q.val)
        {
            return false;
        }
        return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
    }


    [Theory]
    [ClassData(typeof(IsSameTreeTestData))]
    public void IsSameTreeTest(TreeNode p, TreeNode q, bool expected)
    {
        IsSameTree(p, q).Should().Be(expected);
    }

    class IsSameTreeTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return
            [
                new TreeNode(1,
                    new TreeNode(2),
                    new TreeNode(3)
                    ),
                new TreeNode(1,
                    new TreeNode(2),
                    new TreeNode(3)
                ),
                true
            ];
            yield return
            [
                new TreeNode(1,
                    new TreeNode(2)
                ),
                new TreeNode(1,
                    null,
                    new TreeNode(2)
                ),
                false
            ];
            yield return
            [
                new TreeNode(1,
                    new TreeNode(2),
                    new TreeNode(1)
                ),
                new TreeNode(1,
                    new TreeNode(1),
                    new TreeNode(2)
                ),
                false
            ];
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
