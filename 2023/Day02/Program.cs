using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Day02{

    private static Dictionary<string, int> GAMES = new Dictionary<string, int>
        {
            { "red", 12 },
            { "green", 13 },
            { "blue", 14 }
        };
    private static void Main(){
        string file_path = "02_day.txt";
        string[] lines = File.ReadAllLines(file_path);
        int IDsum = 0;
        int cubePower = 0;
        int[] arr_result = {};

        foreach (string line in lines){
                        
            arr_result = PartOne(line);
            IDsum += arr_result[0];
            cubePower += arr_result[1];
        }
        
        //part 1
        Console.WriteLine($"La somma degli ID è: {IDsum}");

        //part 2
        Console.WriteLine($"La potenza dei cubi è: {cubePower}");
    }

     
    //part 1
    private static int[] PartOne(string line){
        
        int IDsum = 0;
        int single_cubePower = 0;
        Match match = Regex.Match(line, @"Game (\d+): (.+)");
        //int gameNumber = 
        bool allMovesValid = true;

        int maxR = 0; int maxG = 0; int maxB = 0;

        MatchCollection gameDataMatches = Regex.Matches(match.Groups[2].Value, @"(\d+ \w+)");

        foreach (Match gameDataMatch in gameDataMatches)
        {
            string[] move = gameDataMatch.Groups[1].Value.Split(' ');
            for (int i=0; i < move.Length; i+=2){
                foreach (var dict_elem in GAMES){
                    int moveNumber = int.Parse(move[i]);

                    if (dict_elem.Key == move[i+1]){
                        if (moveNumber > dict_elem.Value) 
                            allMovesValid = false;
                    }

                    //part 2
                    if (move[i+1] == "red" && moveNumber > maxR)
                        maxR = moveNumber;
                    else if (move[i+1] == "green" && moveNumber > maxG)
                        maxG = moveNumber;
                    else if (move[i+1] == "blue" && moveNumber > maxB)
                        maxB = moveNumber;
                    
                }
            }
        }

        if (allMovesValid)
            IDsum += int.Parse(match.Groups[1].Value); 
        
        single_cubePower = maxR * maxG * maxB;
        int[] result = {IDsum, single_cubePower};

        return result;
    }
}
