using System.Collections;
using Leetcode.Common;
using Xunit;

namespace Leetcode._19_Remove_Nth_Node_From_End_of_List;

using FluentAssertions;

public class Solution
{
    public ListNode RemoveNthFromEnd(ListNode? head, int n)
    {
        ListNode dummy = new(0, head);
        var slow = dummy;
        var fast = dummy;

        for (var i = 0; i < n; i++)
        {
            fast = fast?.next;
        }

        while (fast?.next is not null)
        {
            fast = fast.next;
            slow = slow?.next;
        }

        slow!.next = slow.next?.next;
        return dummy.next!;
    }

    [Theory]
    [ClassData(typeof(HasCycleTestData))]
    public void RemoveNthFromEndTest(ListNode head,int n, ListNode expectedResult)
    {
        RemoveNthFromEnd(head, n).Should().BeEquivalentTo(expectedResult);
    }

    class HasCycleTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return
            [
                new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5))))),
                2,
                new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(5))))
            ];
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
