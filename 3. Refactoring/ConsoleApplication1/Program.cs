namespace MatrixWalk
{
    using System;

    public class Matrix
    {
        public static void Main()
        {
            int cellsNumber = 4;
            StartMatrixWalk(cellsNumber);
        }

        private static void StartMatrixWalk(int cellsNumber)
        {
            int[,] matrix = new int[cellsNumber, cellsNumber];
            int step = cellsNumber,
                stepsCount = 1,
                rowCoordinate = 0,
                colCoordinate = 0,
                deltaX = 1,
                deltaY = 1;

            while (true)
            {
                matrix[rowCoordinate, colCoordinate] = stepsCount;

                bool hasReachedDeadEnd = !HasAvaliableCells(matrix, rowCoordinate, colCoordinate);
                bool hasNoEmptyCells = hasReachedDeadEnd && FindEmptyCell(matrix) == null;

                if (hasNoEmptyCells)
                {
                    PrintMatrixSteps(matrix);
                    break;
                }
                else if (hasReachedDeadEnd)
                {
                    var cellCoordinates = FindEmptyCell(matrix);
                    matrix[cellCoordinates[1], cellCoordinates[2]] = stepsCount;
                }
                else
                {
                    MoveToEmptyCell(matrix, ref rowCoordinate, ref colCoordinate, deltaX, deltaY, cellsNumber, ref stepsCount);
                }
            }
        }

        private static void MoveToEmptyCell(
            int[,] matrix,
            ref int rowCoordinate,
            ref int colCoordinate,
            int deltaX,
            int deltaY,
            int cellsNumber,
            ref int stepsCount)
        {
            while (rowCoordinate + deltaX >= cellsNumber || rowCoordinate + deltaX < 0
                   || colCoordinate + deltaY >= cellsNumber || colCoordinate + deltaY < 0 ||
                   matrix[rowCoordinate + deltaX, colCoordinate + deltaY] != 0)
            {
                ChangeDirection(ref deltaX, ref deltaY);
            }

            rowCoordinate += deltaX;
            colCoordinate += deltaY;

            stepsCount++;
        }

        private static void ChangeDirection(ref int deltaX, ref int deltaY)
        {
            int[] rowDirections = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] colDirections = { 1, 0, -1, -1, -1, 0, 1, 1 };
            int directionIndex = 0;
            int directionsCount = rowDirections.Length;

            for (int i = 0; i < directionsCount; i++)
            {
                if (rowDirections[i] == deltaX && colDirections[i] == deltaY)
                {
                    directionIndex = i;
                    break;
                }
            }

            if (directionIndex == directionsCount - 1)
            {
                deltaX = rowDirections[0];
                deltaY = colDirections[0];
                return;
            }

            deltaX = rowDirections[directionIndex + 1];
            deltaY = colDirections[directionIndex + 1];
        }

        private static bool HasAvaliableCells(int[,] arr, int x, int y)
        {
            int[] directionsX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionsY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            int directionsCount = directionsX.Length;
            int matrixRange = arr.GetLength(0);

            for (int i = 0; i < directionsCount; i++)
            {
                bool isXOutOfRange = x + directionsX[i] >= matrixRange || x + directionsX[i] < 0;
                bool isYOutOfRange = y + directionsY[i] >= matrixRange || y + directionsY[i] < 0;

                if (isXOutOfRange)
                {
                    directionsX[i] = 0;
                }

                if (isYOutOfRange)
                {
                    directionsY[i] = 0;
                }

                bool hasEmptyCellsAround = arr[x + directionsX[i], y + directionsY[i]] == 0;
                if (hasEmptyCellsAround)
                {
                    return true;
                }
            }

            return false;
        }

        private static int[] FindEmptyCell(int[,] matrix)
        {
            int cellsNumber = matrix.GetLength(0);
            int[] cellCoordinates;

            for (int row = 0; row < cellsNumber; row++)
            {
                for (int col = 0; col < cellsNumber; col++)
                {
                    if (matrix[row, col] == 0)
                    {
                        cellCoordinates = new int[] { matrix[row, col], row, col };
                        return cellCoordinates;
                    }
                }
            }

            return null;
        }

        private static void PrintMatrixSteps(int[,] matrix)
        {
            int rowsNumber = matrix.GetLength(0);

            for (int row = 0; row < rowsNumber; row++)
            {
                for (int col = 0; col < rowsNumber; col++)
                {
                    Console.Write("{0,3}", matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}