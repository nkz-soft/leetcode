using System.Text;

namespace Leetcode.Common;

public class ListNode
{
    public int val; 
    public ListNode? next;
    
    public ListNode(int x, ListNode? nextNode = null) {
         val = x;
         next = nextNode;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        var current = this;
        while (current is not null)
        {
            sb.Append(current.val + " -> ");
            current = current.next;
        }
        return sb.ToString();
    }
}