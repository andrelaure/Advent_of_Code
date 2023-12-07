using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Day03{

    private static void Main(){

        string file_path = "03_day.txt";
        string[] lines = File.ReadAllLines(file_path);

        var MATRIX_SYM = new HashSet<(int, int)>();

        foreach (string line in lines){

            /*MatchCollection symbols = Regex.Matches(line, @"[^\d.]");
            foreach (Match symbol in symbols){
                Console.WriteLine(symbol);
            }*/

            

            for (int i=0; i<line.Length; i++){
                for (int j=0; j<lines.Length; j++){
                    if (line[i] == '*')
                        MATRIX_SYM.Add((i,j));
                }
            }
            
            foreach ((int,int) symbol in MATRIX_SYM)
            {
                Console.WriteLine(symbol);
            }

        }

        

    }
}
