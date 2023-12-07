using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class Day01{

    private static Dictionary<string, string> number_dict = new Dictionary<string, string>
        {
            { "one", "one1one" },
            { "two", "two2two" },
            { "three", "three3three" },
            { "four", "four4four" },
            { "five", "five5five" },
            { "six", "six6six" },
            { "seven", "seven7seven" },
            { "eight", "eight8eight" },
            { "nine", "nine9nine" }
        };

    private static void Main(){
   
        string file_path = "01_day.txt";
        string[] lines = File.ReadAllLines(file_path);
        int calibrationValue = 0;
         
        //calibrationValue = PartOne(lines);
        calibrationValue = PartTwo(lines);
        Console.WriteLine($"Calibration Value: {calibrationValue}");
    }


    // part 1    
    private static int PartOne (string[] lines){
        
        int calibrationValue = 0;

        foreach (string line in lines){
            string line_digit = "";
            line_digit += Calibration(line);
            line_digit += Calibration(new string(line.Reverse().ToArray()));

            calibrationValue += int.Parse(line_digit);
        }
        return calibrationValue;
    }

    private static string Calibration (string  line){

        char[] c_line = line.ToCharArray();
        string s_digit = "";
        foreach (char c in c_line){
            if (c >= '0' && c <= '9'){
                s_digit += c;
                break;
            }
        }
        return s_digit;
    }
    

    // part 2
    private static int PartTwo(string[] lines){
        int calibrationValue = 0;
        string line_convert;

        foreach (string line in lines){
            line_convert = Convert_string_to_int(line); //forse problema? 

            string line_digit = "";
            line_digit += Calibration(line_convert);
            line_digit += Calibration(new string(line_convert.Reverse().ToArray()));

            calibrationValue += int.Parse(line_digit);
        }
        return calibrationValue;
    }

    private static string Convert_string_to_int(string line){

        foreach (var dict_elem in number_dict){
            line = line.Replace(dict_elem.Key, dict_elem.Value); 
        }
        return line;
    }
}
