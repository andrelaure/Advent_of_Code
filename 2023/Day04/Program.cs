using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Day04{

    private static void Main(){

        string file_path = "04_day.txt";
        string[] lines = File.ReadAllLines(file_path);  
        
        double totalPoints = PartOne(lines);
        //int scratchcards = 0;
        

        Console.WriteLine($"totalPoints: {totalPoints}");
    }

    private static double PartOne(string[] lines){
        double totalPoints = 0;
        
        foreach (string line in lines){
            double linePoints = 0;
            int count = 0;
            string[] card = line.Split(':');
            string[] num = card[1].Split('|');

            int[] winNum = num[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] haveNum = num[1].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            count = winNum.Intersect(haveNum).Count();
            if (count > 0)
                linePoints = Math.Pow(2, count-1);

            /*foreach (int numero in haveNum){
                Console.WriteLine(numero);
            }*/

            totalPoints += linePoints;
        }

        return totalPoints;
    }
}
