using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Day04{

    private static void Main(){

        string file_path = "005_day.txt";
        string[] lines = File.ReadAllLines(file_path);

        Match match = Regex.Match(lines[0], @"^seeds: ");

        string[] seeds = match.Groups[2].Value.Split(" ");

        Console.WriteLine(match.Groups[0].Value);

        //seeds: (\d)+
        //s2s: (\d \d \d)+
        //s2f: (\d \d \d)+        
        //f2w: (\d \d \d)+
        //w2l: (\d \d \d)+
        //l2t: (\d \d \d)+
        //t2h: (\d \d \d)+
        //h2l: (\d \d \d)+

        /*foreach(string line in lines){
            Console.WriteLine(line);
        }*/
    }
}
