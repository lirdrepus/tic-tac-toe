namespace tic_tac_toe;

public class ResultCheck: GlobalVariables
{
    //private static int _n = GlobalVariables.n;

    //private static int[,] _boardLocations = GlobalVariables.BoardLocations;

    //private static int _winNumber = GlobalVariables.WinNumber;

    
    public void AmountCheck(string player) //, ref int human1Total, ref int human2Total)
    {

        int[] horizontalAmount = new int[n];
        int[] verticalAmount = new int[n];


        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                horizontalAmount[i] += BoardLocations[i, j];
                verticalAmount[j] += BoardLocations[j, i];
            }
        }


        int mainDiagonal = 0, antiDiagonal = 0;

        for (int i = 0; i < n; i++)
        {
            mainDiagonal += BoardLocations[i, i];
            antiDiagonal += BoardLocations[i, n - 1 - i];
        }

        if (horizontalAmount.Contains(WinNumber) || verticalAmount.Contains(WinNumber) || mainDiagonal == WinNumber ||
            antiDiagonal == WinNumber)
        {
            Console.WriteLine($"Winer is {player}!");
            Environment.Exit(0);
        }
        else if (!BoardLocations.Cast<int>().Contains(0))
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