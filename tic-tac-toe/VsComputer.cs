namespace tic_tac_toe;

public class VsComputer: Game
{
    //private static int n = GlobalVariables.n;
    
    //private static int[] rowPlayer = GlobalVariables.RowPlayer;
    
    //private static int[] colPlayer = GlobalVariables.ColPlayer;
    
    //private static int CurrentPlayer = GlobalVariables.CurrentPlayer;

    //private static int[,] BoardLocations = GlobalVariables.BoardLocations;

    //private NumberInput numInput = new NumberInput();

    //private static string currentNum = GlobalVariables.CurrentNum;
    
    //int[][] OddEvenInNSquare = GlobalVariables.OddEvenInNSquare; //new int[2][];

    //OddEvenInNSquare[0] = GlobalVariables.OddEvenInNSquare[0]; //new int[numbersInPlayer1];

    //OddEvenInNSquare[1] = GlobalVariables.OddEvenInNSquare[1]; //new int[numbersInPlayer2];
    
    
    
    Random _rnd = new Random();
    
    //Human Input
    public void HumanVsComputer()
    {
        while (true)
        {
            HumanInput();
            ProcessInBoard();
            
            if (CurrentPlayer == 0)
            {
                CurrentPlayer = 1;
                CurrentNum = "even";
            }

            BoardCheck();
            ComInput();



            if (CurrentPlayer == 1)
            {
                CurrentPlayer = 0;
                CurrentNum = "odd";
            }
        }

    }
    
    void ComInput()
    {
        
        do
        {

            RowPlayer[CurrentPlayer] = _rnd.Next(0, n);

            ColPlayer[CurrentPlayer] = _rnd.Next(0, n);
            
        } while (BoardLocations[RowPlayer[CurrentPlayer], ColPlayer[CurrentPlayer]] != 0);

        do
        {
            int randomIndex = _rnd.Next(0, OddEvenInNSquare[CurrentPlayer].Length);

            BoardLocations[RowPlayer[CurrentPlayer], ColPlayer[CurrentPlayer]] =
                OddEvenInNSquare[CurrentPlayer][randomIndex];
                //numInput.NumInt($"Please enter an {CurrentNum} number:", OddEvenInNSquare[CurrentPlayer]);
            if (OddEvenInNSquare[CurrentPlayer]
                .Contains(BoardLocations[RowPlayer[CurrentPlayer], ColPlayer[CurrentPlayer]]))
            {
                int index = Array.IndexOf(OddEvenInNSquare[CurrentPlayer],
                    BoardLocations[RowPlayer[CurrentPlayer], ColPlayer[CurrentPlayer]]);
                OddEvenInNSquare[CurrentPlayer][index] = 0;
            }
        } while (BoardLocations[RowPlayer[CurrentPlayer], ColPlayer[CurrentPlayer]] == 0);

        Console.WriteLine(
            $"Computer placed {BoardLocations[RowPlayer[CurrentPlayer], ColPlayer[CurrentPlayer]]} at row {RowPlayer[CurrentPlayer] + 1} column {ColPlayer[CurrentPlayer] + 1}");

    }

    

    void BoardCheck()
    {
        //把横竖数分别放进数组, 检查到有切只有一个0, 要是电脑有相应的偶数能填入, 记录位置, 输出电脑用该偶数填入该位置, 电脑赢
        int[] horizontalList = new int[n];
        int[] verticalList = new int[n];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                horizontalList[j] = BoardLocations[i, j];
                verticalList[j] = BoardLocations[j, i];
            }
            int lastHoriEven = WinNumber - horizontalList.Sum();
            int lastVerdiEven = WinNumber - verticalList.Sum();
            
            if (horizontalList.Count(x => x == 0) == 1 && OddEvenInNSquare[1].Contains(lastHoriEven))
            {
                int indexHori = Array.IndexOf(horizontalList, 0);
                Console.WriteLine($"Computer placed {lastHoriEven} at row {i + 1} column {indexHori + 1}, Summary of row {i + 1} is {WinNumber}, Computer Wins!");
                Environment.Exit(0);
            }
            else if (verticalList.Count(x => x == 0) == 1 && OddEvenInNSquare[1].Contains(lastVerdiEven))
            {
                int indexVerdi = Array.IndexOf(verticalList, 0);
                Console.WriteLine($"Computer placed {lastVerdiEven} at row {indexVerdi + 1} column {i + 1}, Summary of column {i + 1} is {WinNumber}, Computer Wins!");
                Environment.Exit(0);
            }
        }
        
        int[] mainDiagonal = new int[n];
        int[] antiDiagonal = new int[n];
        
        for (int i = 0; i < n; i++)
        {
            mainDiagonal[i] = BoardLocations[i, i];
            antiDiagonal[i] = BoardLocations[i, n - 1 - i];
        }
        
        int lastMainDiaEven = WinNumber - mainDiagonal.Sum();
        int lastAntiDiaEven = WinNumber - antiDiagonal.Sum();
        
        if (mainDiagonal.Count(x => x == 0) == 1 && OddEvenInNSquare[0].Contains(lastMainDiaEven))
        {
            int indexMainDia = Array.IndexOf(mainDiagonal, 0);
            Console.WriteLine($"Computer placed {lastMainDiaEven} at row {indexMainDia + 1} column {indexMainDia + 1}, Summary of Main Diagonal is {WinNumber}, Computer Wins!");
            Environment.Exit(0);
        }
        else if (antiDiagonal.Count(x => x == 0) == 1 && OddEvenInNSquare[1].Contains(lastAntiDiaEven))
        {
            int indexAntiDiaEven = Array.IndexOf(antiDiagonal, 0);
            Console.WriteLine($"Computer placed {lastAntiDiaEven} at row {indexAntiDiaEven} column {n - indexAntiDiaEven}, Summary of Anti Diagonal is {WinNumber}, Computer Wins!");
            Environment.Exit(0);
        }
        
    }
    
    
}