using System;
using System.Collections;
using System.IO;
using System.Reflection.Emit;
using System.Runtime.InteropServices.Marshalling;

class Day_09 
{
    public static void Main09()
    {
        string file = File.ReadAllText("09_input.txt");
        string[] lines = file.Split('\n');
        Array.Resize(ref lines, lines.Length - 1);

        char[] commands = new char[lines.Count()];
        int[] distances = new int[lines.Count()];

        for (int i=0; i<lines.Count(); i++)
        {
            string[] aux_line = lines[i].Split(' ');
            commands[i] = char.Parse(aux_line[0]);
            distances[i] = int.Parse(aux_line[1]);
            //Console.WriteLine("Command: " + commands[i] + "\tDistance: " + distances[i]);
        }
        
        //var s_origin = (0, 0);
        var H_position = (0, 0);
        var T_position = (0, 0);
        var visited = new Dictionary<(int, int), bool>();
        visited.TryAdd((T_position.Item1, T_position.Item2), true);

        for (int i=0; i<lines.Count(); i++){
            switch (commands[i]){
                case 'L':
                    Move_Left(ref visited, ref H_position, ref T_position, distances[i]);
                    break;
                case 'R':
                    Move_Right(ref visited, ref H_position, ref T_position, distances[i]);
                    break;
                case 'U':
                    Move_Up(ref visited, ref H_position, ref T_position, distances[i]);
                    break;
                case 'D':
                    Move_Down(ref visited, ref H_position, ref T_position, distances[i]);
                    break;
            }
        }

        Console.Write("positions visited by Tail (2 knots): " + visited.Count);

        //part 2

        H_position = (0, 0);
        T_position = (0, 0);
        visited = new Dictionary<(int, int), bool>();
        visited.TryAdd((T_position.Item1, T_position.Item2), true);

        Console.Write("positions visited by Tail (10 knots): " + visited.Count);
    }

    static void Move_Left(ref Dictionary<(int,int), bool> visited, ref (int,int) H_position, ref (int,int) T_position, int dist){
        for (int i=0; i<dist; i++){
            H_position.Item1 --;
            if (Math.Abs(T_position.Item1 - H_position.Item1) < 2 && Math.Abs(T_position.Item2 - H_position.Item2) < 2)
                continue;

            if (Math.Abs(T_position.Item1 - H_position.Item1) == 2){
                if(T_position.Item2 == H_position.Item2)
                    T_position.Item1 --;
                else{
                    T_position.Item1 --;
                    if(T_position.Item2 > H_position.Item2)
                        T_position.Item2 --;
                    else
                        T_position.Item2 ++;
                }
                //update positions visited by T --- var visited
                visited.TryAdd((T_position.Item1, T_position.Item2), true);
            }
        }
    }

    static void Move_Right(ref Dictionary<(int,int), bool> visited, ref (int,int) H_position, ref (int,int) T_position, int dist){
        for (int i=0; i<dist; i++){
            H_position.Item1 ++;
            if (Math.Abs(T_position.Item1 - H_position.Item1) < 2 && Math.Abs(T_position.Item2 - H_position.Item2) < 2)
                continue;

            if (Math.Abs(T_position.Item1 - H_position.Item1) == 2){
                if(T_position.Item2 == H_position.Item2)
                    T_position.Item1 ++;
                else{
                    T_position.Item1 ++;
                    if(T_position.Item2 > H_position.Item2)
                        T_position.Item2 --;
                    else
                        T_position.Item2 ++;
                }
                //update positions visited by T --- var visited
                visited.TryAdd((T_position.Item1, T_position.Item2), true);
            }
        }
    }

    static void Move_Up(ref Dictionary<(int,int), bool> visited, ref (int,int) H_position, ref (int,int) T_position, int dist){
        for (int i=0; i<dist; i++){
            H_position.Item2 ++;
            if (Math.Abs(T_position.Item1 - H_position.Item1) < 2 && Math.Abs(T_position.Item2 - H_position.Item2) < 2)
                continue;

            if (Math.Abs(T_position.Item2 - H_position.Item2) == 2){
                if(T_position.Item1 == H_position.Item1)
                    T_position.Item2 ++;
                else{
                    T_position.Item2 ++;
                    if(T_position.Item1 > H_position.Item1)
                        T_position.Item1 --;
                    else
                        T_position.Item1 ++;
                }
                //update positions visited by T --- var visited
                visited.TryAdd((T_position.Item1, T_position.Item2), true);
            }
        }
    }

    static void Move_Down(ref Dictionary<(int,int), bool> visited, ref (int,int) H_position, ref (int,int) T_position, int dist){
        for (int i=0; i<dist; i++){
            H_position.Item2 --;
            if (Math.Abs(T_position.Item1 - H_position.Item1) < 2 && Math.Abs(T_position.Item2 - H_position.Item2) < 2)
                continue;

            if (Math.Abs(T_position.Item2 - H_position.Item2) == 2){
                if(T_position.Item1 == H_position.Item1)
                    T_position.Item2 --;
                else{
                    T_position.Item2 --;
                    if(T_position.Item1 > H_position.Item1)
                        T_position.Item1 --;
                    else
                        T_position.Item1 ++;
                }
                //update positions visited by T --- var visited
                visited.TryAdd((T_position.Item1, T_position.Item2), true);
            }
        }
    }
}
