namespace tic_tac_toe;

//Entry point of the Numerical Tic-Tac-Toe game.
//It has Menu display, user input, and game mode selection.

public static class Program
{
    public static void Main(string[] args)
    {
        //Display readme
        /*var displayReadme = new DisplayReadme();
        string baseDir = AppContext.BaseDirectory;
        string readmePath = Path.Combine(baseDir, "Readme.txt");
        displayReadme.PrintReadme(readmePath);*/
        //displayReadme.PrintReadme("../../../Readme.txt");
        
        //Show welcome message and available game modes
        Console.WriteLine("Welcome to Numerical Tic Tac Toe!");
        Console.WriteLine("Press 1: Human vs Human");
        Console.WriteLine("Press 2: Human vs Computer");
        Console.WriteLine("Press 9: Quit");

        //key presses defined [1, 2, 9]
        var gv = new GlobalVariables();
        int[] keyPress = gv.KeyPress;
        var numInput = new NumberInput();
        int modeChoice = numInput.NumInt("Please enter a number 1, 2, or 9", keyPress);
        if (modeChoice == 9) Environment.Exit(0);
        
        //Ask user to input n for board size
        var inpInt = new InputInt();
        int n = inpInt.InputInteger("Please enter a value of n:");
        
        //Initialize global variables
        gv.Initialize(n);
        
        Console.WriteLine($"Then the winning number is {gv.WinNumber}");
        
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
            
            //Quit Game
            case 9:
                Environment.Exit(0);
                break;
        }

    }
}