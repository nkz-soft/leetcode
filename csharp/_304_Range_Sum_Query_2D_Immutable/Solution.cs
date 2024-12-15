using Xunit;
using Assert = Xunit.Assert;

namespace Leetcode._304_Range_Sum_Query_2D_Immutable;

public class Solution
{
    public class NumMatrix {

        private readonly int[,] prefixSumMatrix;

        public NumMatrix(int[][] matrix)
        {
            if (matrix.Length == 0 || matrix[0].Length == 0)
            {
                return;
            }

            var rows = matrix.Length;
            var cols = matrix[0].Length;

            prefixSumMatrix = new int[rows + 1, cols + 1];
            for (var i = 1; i <= rows; ++i)
            {
                for (var j = 1; j <= cols; ++j)
                {
                    prefixSumMatrix[i, j] = prefixSumMatrix[i - 1, j]
                                            + prefixSumMatrix[i, j - 1]
                                            - prefixSumMatrix[i - 1, j - 1]
                                            + matrix[i - 1][j - 1];
                }
            }
        }

        public int SumRegion(int row1, int col1, int row2, int col2)
        {
            return prefixSumMatrix[row2 + 1, col2 + 1]
                   - prefixSumMatrix[row2 + 1, col1]
                   - prefixSumMatrix[row1, col2 + 1]
                   + prefixSumMatrix[row1, col1];
        }
    }

    [Fact]
    public void NumMatrixTest()
    {
        var obj = new NumMatrix(new int[][] { new int[] { 3, 0, 1, 4, 2 }, new int[] { 5, 6, 3, 2, 1 }, new int[] { 1, 2, 0, 1, 5 }, new int[] { 4, 1, 0, 1, 7 }, new int[] { 1, 0, 3, 0, 5 } });
        var result = obj.SumRegion(2, 1, 4, 3);
        Assert.Equal(8, result);
    }
}
