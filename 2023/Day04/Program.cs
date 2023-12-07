using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Day04{

    private static void Main(){

        string file_path = "04_day.txt";
        string[] lines = File.ReadAllLines(file_path);  
        
        foreach (line in lines)
            Console.WriteLine(line);
    }
}
