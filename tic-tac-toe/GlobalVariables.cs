namespace tic_tac_toe;

//GlobalVariables.cs stores all variables for game state and configuration
//such as board size, playing data and win conditions

public class GlobalVariables
{
    //Set values for menu options
    public int[] KeyPress { get; set; } = [1, 2, 5, 9];
    //n for the board input size
    public int n { get; private set; }
    //2D array for storing board positions and placed numbers
    public int[,]? BoardLocations { get; private set; }
    //Stores the winning number of n * (n * n + 1) / 2
    public int WinNumber { get; set; }
    //Stores the row and column positions of the current player's move.
    public int[] RowPlayer { get; set; } = new int [2];
    public int[] ColPlayer { get; set; }= new int [2];
    //Stores odd and even numbers for each player
    public int[][] OddEvenInNSquare { get; set; }= new int[2][];
    //Player's turn: 0 is Player 1, 1 is Player 2 and current player using string "odd" or "even" 
    public int CurrentPlayer { get; set; } = 0;
    public string CurrentNum { get; set; } = "odd";

    // Initializes the game state based with board size n.
    public void Initialize(int nFromProgram)
    {
        n = nFromProgram;
        
        BoardLocations =  new int[n, n];
        
        //Calculate how many numbers each player has
        int numbersInPlayer1 = n * n / 2 + n % 2;
        int numbersInPlayer2 = n * n - numbersInPlayer1;
        
        WinNumber = n * (n * n + 1) / 2;
        
        //Initialize oddEvenInNSquare array for the odd and even number pools
        OddEvenInNSquare[0] = new int[numbersInPlayer1];
        OddEvenInNSquare[1] = new int[numbersInPlayer2];
        
        for (int i = 0; i < numbersInPlayer1; i++)
        {
            OddEvenInNSquare[0][i] = i * 2 + 1;
        }

        for (int i = 0; i < numbersInPlayer2; i++)
        {
            OddEvenInNSquare[1][i] = i * 2 + 2;
        }
    }
}