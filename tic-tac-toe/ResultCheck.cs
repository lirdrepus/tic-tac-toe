namespace tic_tac_toe;

//Checks current player win or draw after each move
//Determines the game result from the amount of rows, columns and diagonals.

public class ResultCheck
{
    private readonly GlobalVariables gv;
    public ResultCheck(GlobalVariables globalVariables)
    {
        gv = globalVariables;
    }
    
    
    public void AmountCheck(string player) 
    {

        int[] horizontalAmount = new int[gv.n];
        int[] verticalAmount = new int[gv.n];
        int horiAmount = 0, vertAmount = 0;
        
        bool containZero = false;
        for (int i = 0; i < gv.n; i++)
        {
            if (gv.BoardLocations[gv.RowPlayer[gv.CurrentPlayer], i] == 0)
            {
                containZero = true;
                break;
            }

            horiAmount += gv.BoardLocations[gv.RowPlayer[gv.CurrentPlayer], i];
        }

        if (!containZero && horiAmount == gv.WinNumber)
        {
            Console.WriteLine($"Winer is {player}!");
            Environment.Exit(0);
        }
        
        containZero = false;
        for (int i = 0; i < gv.n; i++)
        {
            if (gv.BoardLocations[i, gv.ColPlayer[gv.CurrentPlayer]] == 0)
            {
                containZero = true;
                break;
            }

            vertAmount += gv.BoardLocations[i, gv.ColPlayer[gv.CurrentPlayer]];
        }

        if (!containZero && vertAmount == gv.WinNumber)
        {
            Console.WriteLine($"Winer is {player}!");
            Environment.Exit(0);
        }

        int mainDiagonal = 0, antiDiagonal = 0;
        
        containZero = false;
        for (int i = 0; i < gv.n; i++)
        {
            if (gv.BoardLocations[i, i] == 0)
            {
                containZero = true;
                break;
            }

            mainDiagonal += gv.BoardLocations[i, i];
        }

        if (!containZero && mainDiagonal == gv.WinNumber)
        {
            Console.WriteLine($"Winer is {player}!");
            Environment.Exit(0);
        }
        
        containZero = false;
        for (int i = 0; i < gv.n; i++)
        {
            if (gv.BoardLocations[i, gv.n - 1 - i] == 0)
            {
                containZero = true;
                break;
            }

            antiDiagonal += gv.BoardLocations[i, gv.n - 1 - i];
        }

        if (!containZero && antiDiagonal == gv.WinNumber)
        {
            Console.WriteLine($"Winer is {player}!");
            Environment.Exit(0);
        }
        
        if (!gv.BoardLocations.Cast<int>().Contains(0))
        {
            Console.WriteLine("Draw Game!");
            Environment.Exit(0);
        }
        else
        {
            Console.WriteLine("Next player will go on to input!");
        }
    }
}