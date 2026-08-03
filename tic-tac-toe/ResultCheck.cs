namespace tic_tac_toe;

public static class ResultCheck
{
    private static int n = GlobalVariables.n;

    private static int[,] boardLocations = GlobalVariables.BoardLocations;

    private static int winNumber = GlobalVariables.WinNumber;

    
    public static void AmountCheck(string player) //, ref int human1Total, ref int human2Total)
    {

        int[] horizontalAmount = new int[n];
        int[] verticalAmount = new int[n];


        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                horizontalAmount[i] += boardLocations[i, j];
                verticalAmount[j] += boardLocations[j, i];
            }
        }


        int mainDiagonal = 0, antiDiagonal = 0;

        for (int i = 0; i < n; i++)
        {
            mainDiagonal += boardLocations[i, i];
            antiDiagonal += boardLocations[i, n - 1 - i];
        }

        if (horizontalAmount.Contains(winNumber) || verticalAmount.Contains(winNumber) || mainDiagonal == winNumber ||
            antiDiagonal == winNumber)
        {
            Console.WriteLine($"Winer is {player}!");
            Environment.Exit(0);
        }
        else if (!boardLocations.Cast<int>().Contains(0))
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