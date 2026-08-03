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

/*int modeChoice = Convert.ToInt16(Console.ReadLine());

while (!keyPress.Contains(modeChoice))
{
    Console.WriteLine("Please enter a number 1, 2, or 0");
    modeChoice = Convert.ToInt16(Console.ReadLine());
}*/
//调用类NumberInput, 获取所选模式

        var numInput = new NumberInput();
        int modeChoice = numInput.NumInt("Please enter a number 1, 2, or 9", keyPress);
        if (modeChoice == 9) Environment.Exit(0);

//int modeChoice = NumInt("Please enter a number 1, 2, or 0", keyPress);
//Console.WriteLine("Enter n");
//int inputInt = Convert.ToInt16(Console.ReadLine());

        var inpInt = new InputInt();
        int n = inpInt.InputInteger("Please enter a value of n:");

//int n = InputInt("Please enter a value of n:");

//transfer n to GV
        GlobalVariables.Initialize(n);

        int[,] boardLocations = GlobalVariables.BoardLocations; //new int[n, n];

        int numbersInPlayer1 = GlobalVariables.NumbersInPlayer1; //n * n / 2 + n % 2;

        int numbersInPlayer2 = GlobalVariables.NumbersInPlayer2; //n * n - numbersInPlayer1;

        int winNumber = GlobalVariables.WinNumber; //n * (n * n + 1) / 2;

//int human1Total = 0;
//int human2Total = 0;

        int[] rowPlayer = GlobalVariables.RowPlayer; //new int [2];

        int[] colPlayer = GlobalVariables.ColPlayer; //new int [2];

        int[][] oddEvenInNSquare = GlobalVariables.OddEvenInNSquare; //new int[2][];

        oddEvenInNSquare[0] = GlobalVariables.OddEvenInNSquare[0]; //new int[numbersInPlayer1];

        oddEvenInNSquare[1] = GlobalVariables.OddEvenInNSquare[1]; //new int[numbersInPlayer2];

//int[][] evenInNSquare = new int[3][numbersInPlayer2];
//int[] alreadyInput = new int[n * n];
        int currentPlayer = GlobalVariables.CurrentPlayer; //0;

        string currentNum = GlobalVariables.CurrentNum; //"odd";

        switch (modeChoice)
        {
            case 1:
                //Human vs Human
                //
                //n^2的单数放进oddInN, 双数放进evenInN
                //HumanVsHuman();
                var game = new Game();
                game.HumanVsHuman();
                //human2同样

                //int humanInpOdd = NumInt("Please enter a number of odd numbers:", oddInN);
                goto default;
            case 2:
                goto default;
            case 9:
                Environment.Exit(0);
                break;
            default:
                break;
        }
        /*
        void AmountCheck(string player)//, ref int human1Total, ref int human2Total)
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

            /*if (currentPlayer == 0)
            {
                human1Total = winNumber;
            }
            else if (currentPlayer == 1)
            {
                human2Total = winNumber;
            }*/


        
        void HumanVsHuman()
        {
            /*
            for (int i = 0; i < numbersInPlayer1; i++)
            {
                oddEvenInNSquare[0][i] = i * 2 + 1;
            }

            for (int i = 0; i < numbersInPlayer2; i++)
            {
                oddEvenInNSquare[1][i] = i * 2 + 2;
            }
*/
            //while(human1Total!=总数 并 human2Total != 总数)
            while (true) //human1Total != winNumber && human2Total != winNumber)
            {
                //human1输入一个坐标,单数(验证)(未做)
                do
                {
                    var playerInputInt = new PlayerInputInt();
                    rowPlayer[currentPlayer] =
                        playerInputInt.PlayerInpInt($"Please place a row number for Player{currentPlayer + 1}:", n) - 1;
                    //rowPlayer[currentPlayer] =
                    //PlayerInpInt($"Please place a row number for Player{currentPlayer + 1}:", n) - 1;
                    colPlayer[currentPlayer] =
                        playerInputInt.PlayerInpInt($"Please place a column number for Player{currentPlayer + 1}:", n) -
                        1;
                    //colPlayer[currentPlayer] =
                    //PlayerInpInt($"Please place a column number for Player{currentPlayer + 1}:", n) - 1;
                    if (boardLocations[rowPlayer[currentPlayer], colPlayer[currentPlayer]] != 0)
                    {
                        Console.WriteLine("This space has been input a number, try another space");
                    }
                } while (boardLocations[rowPlayer[currentPlayer], colPlayer[currentPlayer]] != 0);

                //oddInN去掉那个数(未做)
                do
                {

                    boardLocations[rowPlayer[currentPlayer], colPlayer[currentPlayer]] =
                        numInput.NumInt($"Please enter an {currentNum} number:", oddEvenInNSquare[currentPlayer]);
                    if (oddEvenInNSquare[currentPlayer]
                        .Contains(boardLocations[rowPlayer[currentPlayer], colPlayer[currentPlayer]]))
                    {
                        int index = Array.IndexOf(oddEvenInNSquare[currentPlayer],
                            boardLocations[rowPlayer[currentPlayer], colPlayer[currentPlayer]]);
                        oddEvenInNSquare[currentPlayer][index] = 0;
                    }
                    else
                    {
                        Console.WriteLine("This number is already in the board, please try again");
                    }

                    ResultCheck.AmountCheck($"Player {currentPlayer + 1}");
                    
                    //AmountCheck($"Player {currentPlayer + 1}"); //, ref human1Total, ref human2Total);

                } while (oddEvenInNSquare[currentPlayer]
                             .Contains(boardLocations[rowPlayer[currentPlayer], colPlayer[currentPlayer]]) ||
                         boardLocations[rowPlayer[currentPlayer], colPlayer[currentPlayer]] > n * n ||
                         boardLocations[rowPlayer[currentPlayer], colPlayer[currentPlayer]] == 0);

                if (currentPlayer == 0)
                {
                    currentPlayer = 1;
                    currentNum = "even";
                }
                else
                {
                    currentPlayer = 0;
                    currentNum = "odd";
                }

            }
        }

    }
    
    
}