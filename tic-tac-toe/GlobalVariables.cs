using System.Runtime.CompilerServices;

namespace tic_tac_toe;

public class GlobalVariables
{
    public static int[] KeyPress = [1, 2, 9];

    protected static int n;

    protected static int[,] BoardLocations;

    private static int NumbersInPlayer1;

    private static int NumbersInPlayer2;

    protected static int WinNumber;
    
    protected static int[] RowPlayer = new int [2];
    
    protected static int[] ColPlayer = new int [2];
    
    public static int[][] OddEvenInNSquare = new int[2][];
    
    protected static int CurrentPlayer = 0;
    
    protected static string CurrentNum = "odd";


    public static void Initialize(int nFromProgram)
    {
        n = nFromProgram;
        
        BoardLocations =  new int[n, n];
        
        NumbersInPlayer1 = n * n / 2 + n % 2;
        
        NumbersInPlayer2 = n * n - NumbersInPlayer1;
        
        WinNumber = n * (n * n + 1) / 2;
        
        OddEvenInNSquare[0] = new int[NumbersInPlayer1];

        OddEvenInNSquare[1] = new int[NumbersInPlayer2];
        
        for (int i = 0; i < NumbersInPlayer1; i++)
        {
            OddEvenInNSquare[0][i] = i * 2 + 1;
        }

        for (int i = 0; i < NumbersInPlayer2; i++)
        {
            OddEvenInNSquare[1][i] = i * 2 + 2;
        }
    }
}