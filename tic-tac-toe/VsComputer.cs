namespace tic_tac_toe;

//Controls Human vs Computer gameplay.
//Includes human moves, computer move and win detection logic
public class VsComputer
{
    private readonly GlobalVariables gv;
    private PrintBoard printBoard;
    private Random _rnd;

    public VsComputer(GlobalVariables globalVariables)
    {
        gv = globalVariables;
        printBoard = new PrintBoard(gv);
        _rnd = new Random();
    }
    

    public void HumanVsComputer()
    {
        while (true)
        {
            var game = new Game(gv);
            game.HumanInput();
            game.ProcessInBoard();
            
            if (gv.CurrentPlayer == 0)
            {
                gv.CurrentPlayer = 1;
                gv.CurrentNum = "even";
            }

            BoardCheck();
            ComInput();
            
            printBoard.PntCurrentBoard();


            if (gv.CurrentPlayer == 1)
            {
                gv.CurrentPlayer = 0;
                gv.CurrentNum = "odd";
            }
        }

    }
    
    void ComInput()
    {
        do
        {
            gv.RowPlayer[gv.CurrentPlayer] = _rnd.Next(0, gv.n);

            gv.ColPlayer[gv.CurrentPlayer] = _rnd.Next(0, gv.n);
            
        } while (gv.BoardLocations[gv.RowPlayer[gv.CurrentPlayer], gv.ColPlayer[gv.CurrentPlayer]] != 0);

        do
        {
            int randomIndex = _rnd.Next(0, gv.OddEvenInNSquare[gv.CurrentPlayer].Length);

            gv.BoardLocations[gv.RowPlayer[gv.CurrentPlayer], gv.ColPlayer[gv.CurrentPlayer]] =
                gv.OddEvenInNSquare[gv.CurrentPlayer][randomIndex];
            
            if (gv.OddEvenInNSquare[gv.CurrentPlayer]
                .Contains(gv.BoardLocations[gv.RowPlayer[gv.CurrentPlayer], gv.ColPlayer[gv.CurrentPlayer]]))
            {
                int index = Array.IndexOf(gv.OddEvenInNSquare[gv.CurrentPlayer],
                    gv.BoardLocations[gv.RowPlayer[gv.CurrentPlayer], gv.ColPlayer[gv.CurrentPlayer]]);
                gv.OddEvenInNSquare[gv.CurrentPlayer][index] = 0;
            }
        } while (gv.BoardLocations[gv.RowPlayer[gv.CurrentPlayer], gv.ColPlayer[gv.CurrentPlayer]] == 0);

        Console.WriteLine(
            $"Computer placed {gv.BoardLocations[gv.RowPlayer[gv.CurrentPlayer], gv.ColPlayer[gv.CurrentPlayer]]} at row {gv.RowPlayer[gv.CurrentPlayer] + 1} column {gv.ColPlayer[gv.CurrentPlayer] + 1}");

    }

    

    void BoardCheck()
    {
        int[] horizontalList = new int[gv.n];
        int[] verticalList = new int[gv.n];

        for (int i = 0; i < gv.n; i++)
        {
            for (int j = 0; j < gv.n; j++)
            {
                horizontalList[j] = gv.BoardLocations[i, j];
                verticalList[j] = gv.BoardLocations[j, i];
            }
            int lastHoriEven = gv.WinNumber - horizontalList.Sum();
            int lastVerdiEven = gv.WinNumber - verticalList.Sum();

            if (lastHoriEven != 0 &&
                horizontalList.Count(x => x == 0) == 1 &&
                gv.OddEvenInNSquare[1].Contains(lastHoriEven))
            {
                int indexHori = Array.IndexOf(horizontalList, 0);
                Console.WriteLine(
                    $"Computer placed {lastHoriEven} at row {i + 1} column {indexHori + 1}, Summary of Row {i + 1} is {gv.WinNumber}, Computer Wins!");
                gv.BoardLocations[i, indexHori] = lastHoriEven;
                printBoard.PntCurrentBoard();
                Environment.Exit(0);
            }
            else if (lastVerdiEven != 0 &&
                     verticalList.Count(x => x == 0) == 1 &&
                     gv.OddEvenInNSquare[1].Contains(lastVerdiEven))
            {
                int indexVerdi = Array.IndexOf(verticalList, 0);
                Console.WriteLine($"Computer placed {lastVerdiEven} at row {indexVerdi + 1} column {i + 1}, Summary of Column {i + 1} is {gv.WinNumber}, Computer Wins!");
                gv.BoardLocations[indexVerdi, i] = lastVerdiEven;
                printBoard.PntCurrentBoard();
                Environment.Exit(0);
            }
        }
        
        int[] mainDiagonal = new int[gv.n];
        int[] antiDiagonal = new int[gv.n];
        
        for (int i = 0; i < gv.n; i++)
        {
            mainDiagonal[i] = gv.BoardLocations[i, i];
            antiDiagonal[i] = gv.BoardLocations[i, gv.n - 1 - i];
        }
        
        int lastMainDiaEven = gv.WinNumber - mainDiagonal.Sum();
        int lastAntiDiaEven = gv.WinNumber - antiDiagonal.Sum();

        if (lastMainDiaEven != 0 &&
            mainDiagonal.Count(x => x == 0) == 1 &&
            gv.OddEvenInNSquare[1].Contains(lastMainDiaEven))
        {
            int indexMainDia = Array.IndexOf(mainDiagonal, 0);
            Console.WriteLine(
                $"Computer placed {lastMainDiaEven} at row {indexMainDia + 1} column {indexMainDia + 1}, Summary of Main Diagonal is {gv.WinNumber}, Computer Wins!");
            gv.BoardLocations[indexMainDia, indexMainDia] = lastMainDiaEven;
            printBoard.PntCurrentBoard();
            Environment.Exit(0);
        }
        else if (lastAntiDiaEven != 0 &&
                 antiDiagonal.Count(x => x == 0) == 1 &&
                 gv.OddEvenInNSquare[1].Contains(lastAntiDiaEven))
        {
            int indexAntiDiaEven = Array.IndexOf(antiDiagonal, 0);
            Console.WriteLine(
                $"Computer placed {lastAntiDiaEven} at row {indexAntiDiaEven} column {gv.n - indexAntiDiaEven}, Summary of Anti Diagonal is {gv.WinNumber}, Computer Wins!");
            gv.BoardLocations[indexAntiDiaEven - 1, gv.n - indexAntiDiaEven - 1] = lastAntiDiaEven;
            printBoard.PntCurrentBoard();
            Environment.Exit(0);
        }

    }
    
    
}