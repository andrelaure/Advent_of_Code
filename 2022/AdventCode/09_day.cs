using System;
using System.IO;

class Day_09 
{
    
    public static void Main09()
    {
        string file = File.ReadAllText("09_input.txt");
        string[] lines = file.Split('\n');
        Array.Resize(ref lines, lines.Length - 1);

        string[] command = new string[lines.Count()];
        int[] distance = new int[lines.Count()];

        for (int i=0; i<lines.Count(); i++)
        {
            string[] aux_line = lines[i].Split(' ');
            command[i] = aux_line[0];
            distance[i] = int.Parse(aux_line[1]);
            Console.WriteLine("Command: " + command[i] + "\tDistance: " + distance[i]);
        }

    }

    static void Move_Left(){

    }

    static void Move_Right(){

    }

    static void Move_Up(){

    }

    static void Move_Down(){

    }

    
}
