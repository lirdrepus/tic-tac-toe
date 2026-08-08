namespace tic_tac_toe;
public class PrintBoard: Game
{
    private static int nSquareLength = (n * n).ToString().Length;
    /*private static string unitText = " "
                      + string.Concat(Enumerable.Repeat(" ",
                          (nSquareLength - BoardLocations[RowPlayer[CurrentPlayer], ColPlayer[CurrentPlayer]]
                              .ToString().Length)))
                      + BoardLocations[RowPlayer[CurrentPlayer], ColPlayer[CurrentPlayer]]
                      + " " + "|";
    private static int unitlength = unitText.Length;*/
    //可以把原二位數組變成列表加座標
    //private static int[,] newBoard = new int[n + 1, n + 1];
    private static string[,] newStringBoard = new string[n + 1, n + 1];
    //private string[] boardLine = new string[n + 1];

    public void PntCurrentBoard()
    {
        CreatNewBoard();
        PntBoard();
    }

    public void CreatNewBoard()
    {
        for (int i = 0; i < n; i++)
        {
            //newBoard[i + 1, 0] = i + 1;
            //newBoard[0, i + 1] = i + 1;
            newStringBoard[i + 1, 0] = " "
                                       + string.Concat(Enumerable.Repeat(" ",
                                           (nSquareLength - (i + 1).ToString().Length)))
                                       + $"\e[31m{(i + 1).ToString()}\e[00m"
                                       + " " + "|";
            newStringBoard[0, i + 1] = " "
                                       + string.Concat(Enumerable.Repeat(" ",
                                           (nSquareLength - (i + 1).ToString().Length)))
                                       + $"\e[31m{(i + 1).ToString()}\e[00m"
                                       + " " + "|";

        }

        newStringBoard[0, 0] = " "
                               + string.Concat(Enumerable.Repeat(" ",
                                   nSquareLength))
                               + " " + "|";
        
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                newStringBoard[i + 1, j + 1] = " "
                                               + string.Concat(Enumerable.Repeat(" ",
                                                   (nSquareLength - BoardLocations[i, j].ToString().Length)))
                                               + BoardLocations[i, j].ToString()
                                               + " " + "|";
                newStringBoard[j + 1, i + 1] = " "
                                               + string.Concat(Enumerable.Repeat(" ",
                                                   (nSquareLength - BoardLocations[j, i].ToString().Length)))
                                               + BoardLocations[j, i].ToString()
                                               + " " + "|";
            }
        }
    }

    
    
    public void PntBoard()
    {
        string[] boardLine = new string[n + 1];
        
        for (int i = 0; i < n + 1; i++)
        {
            for (int j = 0; j < n + 1; j++)
            {
                boardLine[i] += newStringBoard[i, j];
            }
        }

        Console.WriteLine(boardLine[0]);
        Console.WriteLine(string.Concat(Enumerable.Repeat("-", boardLine[1].Length - 10)));
        for (int i = 1; i < n + 1; i++)
        {
            string rplZero = boardLine[i].Replace(" 0 ", "   ");
            
            Console.WriteLine(rplZero);
            
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", boardLine[i].Length - 10)));
        }
        
        
        
    }
}