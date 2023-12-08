using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Day03{

    private static void Main(){

        string file_path = "03_day.txt";
        string[] lines = File.ReadAllLines(file_path);  
        var MATRIX_SYM = new HashSet<(int, int)>();

        //int sum = PartOne(lines, MATRIX_SYM);
        int sum = PartTwo(lines, MATRIX_SYM);

        //Console.WriteLine($"Somma PartOne: {sum}"); 
        Console.WriteLine($"Somma PartTwo: {sum}"); 
    }

    private static int PartOne(string[] lines, HashSet<(int, int)> MATRIX_SYM){
        int sum = 0;
        int[] ultimaPosizione = {-1,-1};
        for (int j=0; j<lines.Length; j++){ 
            for (int i=0; i<lines[j].Length; i++){
                if (lines[j][i] != '.' && !char.IsDigit(lines[j][i])){
                    MATRIX_SYM.Add((j,i));

                    for (int x= j-1; x<=j+1; x++){ 
                        for (int y= i-1; y<=i+1; y++){
                            if (x >= 0 && x < lines.Length && y >= 0 && y < lines[j].Length && char.IsDigit(lines[x][y])) {
                                if (x != ultimaPosizione[0] || (y != ultimaPosizione[1]-1 && y != ultimaPosizione[1]+1)) {
                                    string number = FindNumber(lines, x, y);
                                    sum += int.Parse(number);    
                                }
                                ultimaPosizione[0] = x;
                                ultimaPosizione[1] = y;
                            }
                        }
                    }
                }
            }
        }
        return sum;
    }

    private static int PartTwo(string[] lines, HashSet<(int, int)> MATRIX_SYM){
        int sum = 0;
        int[] ultimaPosizione = {-1,-1};
        for (int j=0; j<lines.Length; j++){ 
            for (int i=0; i<lines[j].Length; i++){
                if (lines[j][i] == '*'){
                    MATRIX_SYM.Add((j,i));
                    int mul = 1;
                    int counter = 0;

                    for (int x= j-1; x<=j+1; x++){ 
                        for (int y= i-1; y<=i+1; y++){
                            if (x >= 0 && x < lines.Length && y >= 0 && y < lines[j].Length && char.IsDigit(lines[x][y])) {
                                if (x != ultimaPosizione[0] || (y != ultimaPosizione[1]-1 && y != ultimaPosizione[1]+1)) {
                                    string number = FindNumber(lines, x, y);
                                    mul *= int.Parse(number);
                                    counter ++;                                  
                                }
                                ultimaPosizione[0] = x;
                                ultimaPosizione[1] = y;
                            }
                        }
                    }
                    if (counter == 2){
                        sum += mul;
                    }
                }
            }
        }
        return sum;
    }


    private static string FindNumber(string[] lines, int x, int y) {
        string numero = lines[x][y].ToString();

        for (int i = y - 1; i >= 0 && char.IsDigit(lines[x][i]); i--) {
            numero = lines[x][i] + numero;
        }

        for (int i = y + 1; i < lines[x].Length && char.IsDigit(lines[x][i]); i++) {
            numero = numero + lines[x][i];
        }
        return numero;
    }

}
