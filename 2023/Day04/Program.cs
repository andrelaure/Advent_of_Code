using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

class Day04{

    private static void Main(){

        string file_path = "004_day.txt";
        string[] lines = File.ReadAllLines(file_path); 
        //int scratchcards = 0; 
        
        //double totalPoints = PartOne(lines);
        double totalPoints = PartTwo(lines);

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

            totalPoints += linePoints;
        }

        return totalPoints;
    }
    
    private static double PartTwo(string[] lines){
        Dictionary<int, int> scratchcardCopies = new Dictionary<int, int>();

        for (int i=0; i<lines.Length; i++){  //foreach (string line in lines){

            int count = 0;
            string[] card = lines[i].Split(':');
            string[] num = card[1].Split('|');
            int[] winNum = num[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] haveNum = num[1].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            count = winNum.Intersect(haveNum).Count();

            if (!scratchcardCopies.ContainsKey(i)){
                scratchcardCopies.Add(i, 0);
            }
            
            for (int j=i; j<=i+count; j++){
                
                if (scratchcardCopies.ContainsKey(j)){
                    scratchcardCopies[j] ++;
                }
                else{
                    scratchcardCopies.Add(j, 1);
                }

                foreach (var dict in scratchcardCopies){
                    Console.WriteLine($"dict: {dict} at round {j}");
                }
                
            }
            Console.WriteLine("----");
        
        }
        
        
        int result = scratchcardCopies.Values.Sum();
        return result;
    }
}
