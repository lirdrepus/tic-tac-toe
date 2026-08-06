using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using tic_tac_toe;

public static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Numerical Tic Tac Toe!");
        Console.WriteLine("Press 1: Human vs Human");
        Console.WriteLine("Press 2: Human vs Computer");
        Console.WriteLine("Press 9: Quit");

        int[] keyPress = GlobalVariables.KeyPress; //[1, 2, 9]; //Created in GV


//调用类NumberInput, 获取所选模式

        var numInput = new NumberInput();
        int modeChoice = numInput.NumInt("Please enter a number 1, 2, or 9", keyPress);
        if (modeChoice == 9) Environment.Exit(0);



        var inpInt = new InputInt();
        int n = inpInt.InputInteger("Please enter a value of n:");
        

        //transfer n to GV
        GlobalVariables.Initialize(n);

        //int[,] boardLocations = GlobalVariables.BoardLocations; //new int[n, n];

        //int numbersInPlayer1 = GlobalVariables.NumbersInPlayer1; //n * n / 2 + n % 2;

        //int numbersInPlayer2 = GlobalVariables.NumbersInPlayer2; //n * n - numbersInPlayer1;

        //int winNumber = GlobalVariables.WinNumber; //n * (n * n + 1) / 2;

        //int[] rowPlayer = GlobalVariables.RowPlayer; //new int [2];

        //int[] colPlayer = GlobalVariables.ColPlayer; //new int [2];

        int[][] oddEvenInNSquare = GlobalVariables.OddEvenInNSquare; //new int[2][];

        oddEvenInNSquare[0] = GlobalVariables.OddEvenInNSquare[0]; //new int[numbersInPlayer1];

        oddEvenInNSquare[1] = GlobalVariables.OddEvenInNSquare[1]; //new int[numbersInPlayer2];
        
        //int currentPlayer = GlobalVariables.CurrentPlayer; //0;

        //string currentNum = GlobalVariables.CurrentNum; //"odd";

        switch (modeChoice)
        {
            case 1:
                //Human vs Human
                //n^2的单数放进oddInN, 双数放进evenInN
                //HumanVsHuman();
                var game = new Game();
                game.HumanVsHuman();
                //human2同样
                
                break;
            case 2:
                var vsCom = new VsComputer();
                vsCom.HumanVsComputer();
                break;
            case 9:
                Environment.Exit(0);
                break;
        }

    }
}