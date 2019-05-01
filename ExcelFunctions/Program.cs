namespace ExcelFunctions
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int sizeOfMatrix = int.Parse(Console.ReadLine());

            string[][] matrix = new string[sizeOfMatrix][];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] matrixData = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

                matrix[row] = matrixData;
            }

            string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string header = command[1];

            if (command[0] == "hide")
            {
                int indexOfHeader = GetIndexOfHeader(matrix, header);

                var matrixAfterDeletion = MatrixHideColumn(matrix, indexOfHeader);

                for (int row = 0; row < matrixAfterDeletion.Length; row++)
                {
                    Console.WriteLine(string.Join(" | ",matrixAfterDeletion[row]));
                }
            }
            else if (command[0] == "sort")
            {
                int indexOfHeader = GetIndexOfHeader(matrix, header);

                string[] headerRow = matrix[0];

                Console.WriteLine(string.Join(" | ", headerRow));

                matrix = matrix.OrderBy(x => x[indexOfHeader]).ToArray();

                foreach (var row in matrix)
                {
                    if (row != headerRow)
                    {
                        Console.WriteLine(string.Join(" | ", row));
                    }
                }

            }
            else if (command[0] == "filter")
            {
                string commandToReturn = command[2];

                string[] headerRow = matrix[0];

                Console.WriteLine(string.Join(" | ", headerRow));

                int indexOfHeader = GetIndexOfHeader(matrix, header);

                for (int row = 0; row < matrix.Length; row++)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        if (col == indexOfHeader && matrix[row][col] == commandToReturn)
                        {
                            Console.WriteLine(string.Join(" | ", matrix[row]));
                        }
                    }
                }

            }
        }

        private static string[][] MatrixHideColumn(string[][] matrix, int indexOfHeader)
        {
            string[][] matrixWithHiddenColumn = new string[matrix.Length][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrixWithHiddenColumn[row] = new string[matrix[row].Length - 1];
                int colIndex = 0;

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (col == indexOfHeader)
                    {
                        continue;
                    }

                    matrixWithHiddenColumn[row][colIndex] = matrix[row][col];
                    colIndex++;
                }
            }

            return matrixWithHiddenColumn;
        }

        private static int GetIndexOfHeader(string[][] matrix, string header)
        {
            int headerIndex = Array.IndexOf(matrix[0], header);

            return headerIndex;
        }
    }
}
