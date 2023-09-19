using System;
using System.IO;

class AdventCode
{
    static void Main()
    {
        Console.Write("Day 08 in esecuzione:\n");
        Day_08.Main08();

        /*Console.Write("Day 09 in esecuzione:\n");
        Day_09.Main09();*/
    }

    public static void printIntRow(int[] row){
        
        Console.Write("row: ");
        for (int i = 0; i < row.Length; i++)
        {
            Console.Write(row[i] + " ");
        }
        Console.WriteLine();
    }

    public static void printIntMatrix(int[,] matrix){

        Console.WriteLine("matrix: ");

        for (int i = 0; i < 99; i++)
        {
            for (int j = 0; j < 99; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
