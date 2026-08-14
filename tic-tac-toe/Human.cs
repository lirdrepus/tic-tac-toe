namespace tic_tac_toe;

public class Human : Player
{
    public Human(GlobalVariables globalVariables)
    {
        gv = globalVariables;
        printBoard = new PrintBoard(gv);
        numInput = new NumberInput();
    }
    
    public override void Play()
    {
        HumanInput();
        ProcessInBoard();
    }

    //Handles player input for row and column positions and ensures chosen space is not taken place
    private void HumanInput()
    {
        do
        {
            var playerInputInt = new PlayerInputInt();
            gv.RowPlayer[gv.CurrentPlayer] =
                playerInputInt.PlayerInpInt($"Please place a row number for Player{gv.CurrentPlayer + 1}:", gv.n) -
                1;

            gv.ColPlayer[gv.CurrentPlayer] =
                playerInputInt.PlayerInpInt($"Please place a column number for Player{gv.CurrentPlayer + 1}:",
                    gv.n) -
                1;

            if (gv.BoardLocations[gv.RowPlayer[gv.CurrentPlayer], gv.ColPlayer[gv.CurrentPlayer]] != 0)
            {
                Console.WriteLine("This space has been input a number, try another space");
            }
        } while (gv.BoardLocations[gv.RowPlayer[gv.CurrentPlayer], gv.ColPlayer[gv.CurrentPlayer]] != 0);
    }

    //Places the chosen odd/even number into the board makesure the chosen number in the array
    //Updates available number pool and checks for win condition.
    private void ProcessInBoard()
    {
        do
        {
            gv.BoardLocations[gv.RowPlayer[gv.CurrentPlayer], gv.ColPlayer[gv.CurrentPlayer]] =
                numInput.NumInt($"Please enter an {gv.CurrentNum} number:", gv.OddEvenInNSquare[gv.CurrentPlayer]);
            if (gv.OddEvenInNSquare[gv.CurrentPlayer]
                .Contains(gv.BoardLocations[gv.RowPlayer[gv.CurrentPlayer], gv.ColPlayer[gv.CurrentPlayer]]))
            {
                int index = Array.IndexOf(gv.OddEvenInNSquare[gv.CurrentPlayer],
                    gv.BoardLocations[gv.RowPlayer[gv.CurrentPlayer], gv.ColPlayer[gv.CurrentPlayer]]);
                gv.OddEvenInNSquare[gv.CurrentPlayer][index] = 0;
            }
            else
            {
                Console.WriteLine("This number is already in the board, please try again");
            }

            
            printBoard.PntCurrentBoard();

            ResultCheck resultCheck = new ResultCheck(gv);
            resultCheck.AmountCheck($"Player {gv.CurrentPlayer + 1}");

        } while (gv.OddEvenInNSquare[gv.CurrentPlayer]
                     .Contains(gv.BoardLocations[gv.RowPlayer[gv.CurrentPlayer], gv.ColPlayer[gv.CurrentPlayer]]) ||
                 gv.BoardLocations[gv.RowPlayer[gv.CurrentPlayer], gv.ColPlayer[gv.CurrentPlayer]] > gv.n * gv.n ||
                 gv.BoardLocations[gv.RowPlayer[gv.CurrentPlayer], gv.ColPlayer[gv.CurrentPlayer]] == 0);
    }
}