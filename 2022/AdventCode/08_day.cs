
//costruire matrice nxn con n= 99
//evitare controlli sui valori perimetrali (x,y) --> (0,?) - (98,?) - (?,0) - (?,98)
//costruire bitmap di supporto per alberi visitati
//if curr_tree = 0 && not in perimeter then skip ()
//if curr_tree = 9 skip all other trees

//costruisco prima matrice riga per riga e posso fare già conteggio alberi dx->sx e sx->dx

//bitforest:    bitmap matrix
//forest:       dynamic matrix
//counter:      integer  -- if non ancora considerato then contuer ++
//curr_tree: integer
//heighest_tree: integer


using System;
using System.IO;

class Day_08
{
    static int counter = 0;
    static int[,] bitforest = new int[99,99];
    static int[,] forest = new int[99,99];

    public static void Main08()
    {
        string filePath = "08_input.txt";
        string file = File.ReadAllText(filePath);
        string[] lines = file.Split('\n');
        Array.Resize(ref lines, lines.Length - 1);
        
        for (var i = 0; i < 99; i++){
                char[] trees = lines[i].ToCharArray();
                int[] currentRow = new int[99];

                for (var j = 0; j < 99; j++){
                    currentRow[j] = int.Parse(trees[j].ToString());
                    forest[i, j] = currentRow[j];
                }
                TreeWatcher_Horizontal(currentRow, ref counter, i, ref bitforest);
        }

        //AdventCode.printIntMatrix(bitforest);
        TreeWatcher_Vertical(ref counter, ref bitforest, forest);
        Console.Write("counter: ");
        Console.Write(counter);
    }

    static void TreeWatcher_Horizontal(int[] row, ref int counter, int i, ref int[,] bitforest){
        //AdventCode.printIntRow(row);

        // left -> right
        int curr_tree = 0;
        int heighest_tree = -1;
        for (int j = 0; j < row.Length; j++){
            curr_tree = row[j];
            if (heighest_tree < curr_tree){
                if (bitforest[i,j] == 0){
                    counter ++;
                    bitforest[i,j] = 1;
                }
                heighest_tree = curr_tree;
            }
            if (heighest_tree == 9)
                break;
        }

        // right -> left
        curr_tree = 0;
        heighest_tree = -1;
        for (int k = row.Length-1; k >= 0; k--){
            curr_tree = row[k];
            if (heighest_tree < curr_tree){
                if (bitforest[i,k] == 0){
                    counter ++;
                    bitforest[i,k] = 1;
                }
                heighest_tree = curr_tree;
            }
            if (heighest_tree == 9)
                break;
        }
    }

    static void TreeWatcher_Vertical(ref int counter, ref int[,] bitforest, int[,] forest){

        // up -> down
        
        for (int j = 0; j < 99; j++){
            if (j == 0 || j == 98){
                    continue;
                }
            int curr_tree = 0;
            int heighest_tree = -1;
            for (int i = 0; i < 99; i++){
                curr_tree = forest[i,j];
                if (heighest_tree < curr_tree){
                    if (bitforest[i,j] == 0){
                        counter ++;
                        bitforest[i,j] = 1;
                    }
                    heighest_tree = curr_tree;
                }
                if (heighest_tree == 9)
                    break;
            }
        }

        // down -> up
        for (int j = 98; j >= 0; j--){
            if (j == 0 || j == 98){
                    continue;
                }
            int curr_tree = 0;
            int heighest_tree = -1;
            for (int i = 98; i >= 0; i--){
                
                curr_tree = forest[i,j];
                if (heighest_tree < curr_tree){
                    if (bitforest[i,j] == 0){
                        counter ++;
                        bitforest[i,j] = 1;
                    }
                    heighest_tree = curr_tree;
                }
                if (heighest_tree == 9)
                    break;
            }
        }       
    }
}
