namespace _3.Refactoring
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MatrixWalk
    {
        static void ChangeDirections(ref int dx, ref int dy)
        {
            int[] directionX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            int cd = 0;

            for (int count = 0; count < 8; count++)
            {
                if (directionX[count] == dx && directionY[count] == dy)
                {
                    cd = count;
                    break;
                }

            }

            if (cd == 7)
            {
                dx = directionX[0];
                dy = directionY[0];
                return;
            }

            dx = directionX[cd + 1];
            dy = directionY[cd + 1];
        }

        static bool ReturnCoordinatesOfNextEmptyCell(int[,] arr, int x, int y)
        {
            int[] directionX = { 1, 1, 1, 0, -1, -1, -1, 0 }; // { 1, 1, 1, 0, 0, 0, 0, 0 }
            int[] directionY = { 1, 0, -1, -1, -1, 0, 1, 1 }; // { 1, 0, 0, 0, 0, 0, 1, 1 }

            for (int i = 0; i < 8; i++)
            {
                if (x + directionX[i] >= arr.GetLength(0) || x + directionX[i] < 0)
                {
                    directionX[i] = 0;
                }

                if (y + directionY[i] >= arr.GetLength(0) || y + directionY[i] < 0)
                {
                    directionY[i] = 0;
                }
            }

            for (int i = 0; i < 8; i++)
            {
                if (arr[x + directionX[i], y + directionY[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        static void CheckForEmptyCells(int[,] arr, out int x, out int y)
        {
            x = 0;
            y = 0;

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    if (arr[i, j] == 0)
                    {
                        x = i;
                        y = j;
                        return;
                    }
                }
            }
        }

        static void PrintArray(int[,] a)
        {
            Console.WriteLine();

            for (int pp = 0; pp < a.GetLength(0); pp++)
            {
                for (int qq = 0; qq < a.GetLength(1); qq++)
                {
                    Console.Write("{0,3}", a[pp, qq]);
                }
                Console.WriteLine();
            }
        }

        static void Main()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Console.WriteLine("Enter a positive number in the range[1, 100] with no additional symbols.");
            string input = string.Empty; /*= Console.ReadLine();*/
            int n = 0;

            bool requirementsNeedToBeFullfilled = true;
            bool numberIsValidInteger = false;
            bool numberIsInValidRange = false;

            while (requirementsNeedToBeFullfilled)
            {
                input = Console.ReadLine();
                numberIsValidInteger = int.TryParse(input, out n);
                numberIsInValidRange = (1 <= n) && (n <= 100);

                if (numberIsValidInteger && numberIsInValidRange)
                {
                    requirementsNeedToBeFullfilled = false;
                }
                else
                {
                    Console.WriteLine("You haven't entered a correct positive number. Please enter a positive number in the range[1, 100] with no additional symbols.");
                }
            }

            int[,] matrix = new int[n, n];

            int k = 1;
            int i = 0;
            int j = 0;
            int dx = 1;
            int dy = 1;

            while (true)
            {
                matrix[i, j] = k;

                if (!ReturnCoordinatesOfNextEmptyCell(matrix, i, j))
                {
                    k++;
                    break;
                }

                bool indexesMustBeSetInRangeAndEmptyCellMustBeFound = true;

                while (indexesMustBeSetInRangeAndEmptyCellMustBeFound)
                {
                    bool overflowRowRight = (i + dx) >= n;
                    bool overflowRowLeft = (i + dx) < 0;
                    bool overflowColumnDown = (j + dy) >= n;
                    bool overflowColumnUp = (j + dy) < 0;

                    bool overflowRow = overflowRowRight || overflowRowLeft;
                    bool overflowColumn = overflowColumnDown || overflowColumnUp;

                    if (overflowRow || overflowColumn || matrix[i + dx, j + dy] != 0)
                    {
                        ChangeDirections(ref dx, ref dy);
                    }
                    else
                    {
                        indexesMustBeSetInRangeAndEmptyCellMustBeFound = false;
                    }
                }

                i += dx; j += dy; k++;
            }

            CheckForEmptyCells(matrix, out i, out j);

            if (i != 0 && j != 0)
            {
                dx = 1;
                dy = 1;

                while (true)
                {
                    matrix[i, j] = k;

                    if (!ReturnCoordinatesOfNextEmptyCell(matrix, i, j))
                    {
                        break;
                    }

                    while ((i + dx >= n || i + dx < 0 || j + dy >= n || j + dy < 0 || matrix[i + dx, j + dy] != 0))
                    {
                        ChangeDirections(ref dx, ref dy);
                    }

                    i += dx;
                    j += dy;
                    k++;
                }
            }

            PrintArray(matrix);

            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
        }
    }
}