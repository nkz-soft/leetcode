using Xunit;

namespace Leetcode._20_Valid_Parentheses;

using FluentAssertions;

public class Solution
{
    public bool IsValid(string s) {
        var chars = new Stack<char>(s.Length);
        foreach (var curChar in s)
        {
            switch (curChar)
            {
                case '(':
                case '{':
                case '[':
                    chars.Push(curChar);
                    break;
                case ')' when chars.Count > 0 && chars.Peek() == '(':
                case '}' when chars.Count > 0 && chars.Peek() == '{':
                case ']' when chars.Count > 0 && chars.Peek() == '[':
                    chars.Pop();
                    break;
                default:
                    return false;
            }
        }
        return chars.Count == 0;
    }

    [Theory]
    [InlineData("()", true)]
    [InlineData("()[]{}", true)]
    [InlineData("(]", false)]
    [InlineData("([)]", false)]
    [InlineData("([]{})", true)]
    public void GetConcatenationTest(string s, bool expectedResult)
    {
        IsValid(s).Should().Be(expectedResult);
    }
}
