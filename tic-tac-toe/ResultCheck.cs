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


        for (int i = 0; i < gv.n; i++)
        {
            for (int j = 0; j < gv.n; j++)
            {
                horizontalAmount[i] += gv.BoardLocations[i, j];
                verticalAmount[j] += gv.BoardLocations[j, i];
            }
        }


        int mainDiagonal = 0, antiDiagonal = 0;

        for (int i = 0; i < gv.n; i++)
        {
            mainDiagonal += gv.BoardLocations[i, i];
            antiDiagonal += gv.BoardLocations[i, gv.n - 1 - i];
        }

        if (horizontalAmount.Contains(gv.WinNumber) || verticalAmount.Contains(gv.WinNumber) || mainDiagonal == gv.WinNumber ||
            antiDiagonal == gv.WinNumber)
        {
            Console.WriteLine($"Winer is {player}!");
            Environment.Exit(0);
        }
        else if (!gv.BoardLocations.Cast<int>().Contains(0))
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