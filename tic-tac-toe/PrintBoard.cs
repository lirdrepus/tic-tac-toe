namespace tic_tac_toe;

//Displays the game board of current move
//Builds the format of the board
public class PrintBoard
{
    private GlobalVariables gv;
    private int nSquareLength;
    private string[,] newStringBoard;
    public PrintBoard(GlobalVariables globalVariables)
    {
        gv = globalVariables;
        nSquareLength = (gv.n * gv.n).ToString().Length;
        newStringBoard = new string[gv.n + 1, gv.n + 1];
    }
  
    //Creates and prints the current board.
    public void PntCurrentBoard()
    {
        CreatNewBoard();
        PntBoard();
    }

    private void CreatNewBoard()
    {
        for (int i = 0; i < gv.n; i++)
        {
            newStringBoard[i + 1, 0] = HeaderString(i);
            newStringBoard[0, i + 1] = HeaderString(i);

        }

        newStringBoard[0, 0] = " "
                               + string.Concat(Enumerable.Repeat(" ",
                                   nSquareLength))
                               + " " + "|";
        
        for (int i = 0; i < gv.n; i++)
        {
            for (int j = 0; j < gv.n; j++)
            {
                newStringBoard[i + 1, j + 1] = CellString(i, j);
                newStringBoard[j + 1, i + 1] = CellString(j, i);
            }
        }
    }

    private string HeaderString(int header)
    {
        string headerString = " "
                              + string.Concat(Enumerable.Repeat(" ",
                                  (nSquareLength - (header + 1).ToString().Length)))
                              + $"\e[31m{(header + 1).ToString()}\e[00m"
                              + " " + "|";
        return headerString;
    }

    private string CellString(int row, int col)
    {
        string cellString = " "
                         + string.Concat(Enumerable.Repeat(" ",
                             (nSquareLength - gv.BoardLocations[row, col].ToString().Length)))
                         + gv.BoardLocations[row, col].ToString()
                         + " " + "|";
        return cellString;
    }
    
    //Prints the formatted board to console.
    private void PntBoard()
    {
        string[] boardLine = new string[gv.n + 1];
        
        for (int i = 0; i < gv.n + 1; i++)
        {
            for (int j = 0; j < gv.n + 1; j++)
            {
                boardLine[i] += newStringBoard[i, j];
            }
        }

        Console.WriteLine(string.Concat(Enumerable.Repeat("-", boardLine[1].Length - 10)));
        Console.WriteLine(boardLine[0]);
        Console.WriteLine(string.Concat(Enumerable.Repeat("-", boardLine[1].Length - 10)));
        for (int i = 1; i < gv.n + 1; i++)
        {
            string rplZero = boardLine[i].Replace(" 0 ", "   ");
            
            Console.WriteLine(rplZero);
            
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", boardLine[i].Length - 10)));
        }
        
    }
}