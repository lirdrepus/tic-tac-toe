using System.Runtime.CompilerServices;

namespace tic_tac_toe;

public static class GlobalVariables
{
    public static int[] KeyPress = [1, 2, 9];

    public static int n;

    public static int[,] BoardLocations;

    public static int NumbersInPlayer1;

    public static int NumbersInPlayer2;

    public static int WinNumber;
    
    public static int[] RowPlayer = new int [2];
    
    public static int[] ColPlayer = new int [2];
    
    public static int[][] OddEvenInNSquare = new int[2][];
    
    public static int CurrentPlayer = 0;
    
    public static string CurrentNum = "odd";


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
    
    //public static int[,] BoardLocations =  new int[n, n];
    
    
    //public static int NumbersInPlayer1 = n * n / 2 + n % 2;
    
    
    //public static int NumbersInPlayer2 = n * n - NumbersInPlayer1;

    
    //public static int WinNumber = n * (n * n + 1) / 2;
    
    
    
    //OddEvenInNSquare[0]= new int[numbersInPlayer1];
    //oddEvenInNSquare[1]= new int[numbersInPlayer2];
//int[][] evenInNSquare = new int[3][numbersInPlayer2];
//int[] alreadyInput = new int[n * n];
    
}