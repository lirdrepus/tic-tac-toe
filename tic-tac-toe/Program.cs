namespace tic_tac_toe;

//Entry point of the Numerical Tic-Tac-Toe game.
//It has Menu display, user input, and game mode selection.

public static class Program
{
    public static void Main(string[] args)
    {
        //Show welcome message and available game modes
        Console.WriteLine("Welcome to Numerical Tic Tac Toe!");
        Console.WriteLine("Press 1: Human vs Human");
        Console.WriteLine("Press 2: Human vs Computer");
        Console.WriteLine("Press 5: Help");
        Console.WriteLine("Press h: In-game Help");
        Console.WriteLine("Press 9: Quit");

        //key presses defined [1, 2, 5, 9]
        var gv = new GlobalVariables();
        int[] keyPress = gv.KeyPress;
        var numInput = new NumberInput();
        int modeChoice = 5;
        while (modeChoice == 5)
        {
            modeChoice = numInput.NumInt("Please enter a number 1, 2, 5 or 9", keyPress);
            if (modeChoice == 9) Environment.Exit(0);
            else if (modeChoice == 5)
            {
                Console.WriteLine("USER GUIDE" +
                                  "\n" +
                                  "\nThe program supports two different modes of play, including: " +
                                  "\nHuman vs Human(Press 1)" +
                                  "\nHuman vs Computer(Press 2)" +
                                  "\nAfter choosing mode, input a integer n to decide the score point" +
                                  "\nin a horizontal, vertical, or diagonal line to win the game." +
                                  "\nTwo players take turns putting odd numbers (player 1)" +
                                  "\nand even numbers (player 2 or computer) into the blank squares of a n x n board" +
                                  "\nwhere two players alternately play by placing one of their numbers on the board of size n." +
                                  "\nThe first player to complete one of those lines adding up to score point is the winner." +
                                  "\nPlayer can also press H to get help in-game any time.");
            }
        }

        //Ask user to input n for board size
        var inpInt = new InputInt();
        int n = inpInt.InputInteger("Please enter a value of n:");
        
        //Initialize global variables
        gv.Initialize(n);
        
        Console.WriteLine($"Then the winning amount is {gv.WinNumber}");
        
        //Print the empty board
        PrintBoard printBoard = new PrintBoard(gv);
        printBoard.PntCurrentBoard();

        //Initialize oddEvenInNSquare array for the odd and even number pools
        int[][] oddEvenInNSquare = gv.OddEvenInNSquare; 
        oddEvenInNSquare[0] = gv.OddEvenInNSquare[0]; 
        oddEvenInNSquare[1] = gv.OddEvenInNSquare[1]; 

        //Select game mode based on user choice
        switch (modeChoice)
        {
            //Human vs Human mode
            case 1:
                var game = new Game(gv);
                game.HumanVsHuman();
                break;
            
            //Human vs Computer mode
            case 2:
                var vsCom = new VsComputer(gv);
                vsCom.HumanVsComputer();
                break;
        }

    }
}