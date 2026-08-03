namespace tic_tac_toe;

public class Game
{
    private static int n = GlobalVariables.n;
    
    private static int[] rowPlayer = GlobalVariables.RowPlayer;
    
    private static int[] colPlayer = GlobalVariables.ColPlayer;
    
    private static int currentPlayer = GlobalVariables.CurrentPlayer;

    private static int[,] boardLocations = GlobalVariables.BoardLocations;

    private NumberInput numInput = new NumberInput();

    private static string currentNum = GlobalVariables.CurrentNum;
    
    int[][] oddEvenInNSquare = GlobalVariables.OddEvenInNSquare; //new int[2][];

    //oddEvenInNSquare[0] = GlobalVariables.OddEvenInNSquare[0]; //new int[numbersInPlayer1];

    //oddEvenInNSquare[1] = GlobalVariables.OddEvenInNSquare[1]; //new int[numbersInPlayer2];
    
    public void HumanVsHuman()
        {
            
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