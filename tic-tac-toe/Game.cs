using System.Net.NetworkInformation;

namespace tic_tac_toe;

public class Game: GlobalVariables
{
    //private static int n = GlobalVariables.n;
    
    //private static int[] rowPlayer = GlobalVariables.RowPlayer;
    
    //private static int[] colPlayer = GlobalVariables.ColPlayer;
    
    //private static int CurrentPlayer = GlobalVariables.CurrentPlayer;

    //private static int[,] BoardLocations = GlobalVariables.BoardLocations;

    private NumberInput numInput = new NumberInput();

    //private static string currentNum = GlobalVariables.CurrentNum;
    
    //int[][] OddEvenInNSquare = GlobalVariables.OddEvenInNSquare; //new int[2][];

    //OddEvenInNSquare[0] = GlobalVariables.OddEvenInNSquare[0]; //new int[numbersInPlayer1];

    //OddEvenInNSquare[1] = GlobalVariables.OddEvenInNSquare[1]; //new int[numbersInPlayer2];
    
    public void HumanVsHuman()
        {
            
            //while(human1Total!=总数 并 human2Total != 总数)
            while (true) //human1Total != winNumber && human2Total != winNumber)
            {
                //human1输入一个坐标,单数(验证)(未做)
                HumanInput();
                /*do
                {
                    var playerInputInt = new PlayerInputInt();
                    RowPlayer[CurrentPlayer] =
                        playerInputInt.PlayerInpInt($"Please place a row number for Player{CurrentPlayer + 1}:", n) - 1;

                    ColPlayer[CurrentPlayer] =
                        playerInputInt.PlayerInpInt($"Please place a column number for Player{CurrentPlayer + 1}:", n) -
                        1;
 
                    if (BoardLocations[RowPlayer[CurrentPlayer], ColPlayer[CurrentPlayer]] != 0)
                    {
                        Console.WriteLine("This space has been input a number, try another space");
                    }
                } while (BoardLocations[RowPlayer[CurrentPlayer], ColPlayer[CurrentPlayer]] != 0);*/

                //oddInN去掉那个数
                ProcessInBoard();
                /*do
                {

                    
                    BoardLocations[RowPlayer[CurrentPlayer], ColPlayer[CurrentPlayer]] =
                        numInput.NumInt($"Please enter an {CurrentNum} number:", OddEvenInNSquare[CurrentPlayer]);
                    if (OddEvenInNSquare[CurrentPlayer]
                        .Contains(BoardLocations[RowPlayer[CurrentPlayer], ColPlayer[CurrentPlayer]]))
                    {
                        int index = Array.IndexOf(OddEvenInNSquare[CurrentPlayer],
                            BoardLocations[RowPlayer[CurrentPlayer], ColPlayer[CurrentPlayer]]);
                        OddEvenInNSquare[CurrentPlayer][index] = 0;
                    }
                    else
                    {
                        Console.WriteLine("This number is already in the board, please try again");
                    }

                    ResultCheck resultCheck = new ResultCheck();
                    resultCheck.AmountCheck($"Player {CurrentPlayer + 1}");
                    
                    //AmountCheck($"Player {CurrentPlayer + 1}"); //, ref human1Total, ref human2Total);

                } while (OddEvenInNSquare[CurrentPlayer]
                             .Contains(BoardLocations[RowPlayer[CurrentPlayer], ColPlayer[CurrentPlayer]]) ||
                         BoardLocations[RowPlayer[CurrentPlayer], ColPlayer[CurrentPlayer]] > n * n ||
                         BoardLocations[RowPlayer[CurrentPlayer], ColPlayer[CurrentPlayer]] == 0);
*/
                if (CurrentPlayer == 0)
                {
                    CurrentPlayer = 1;
                    CurrentNum = "even";
                }
                else
                {
                    CurrentPlayer = 0;
                    CurrentNum = "odd";
                }

            }
        }

    public void HumanInput()
    {
        do
        {
            var playerInputInt = new PlayerInputInt();
            RowPlayer[CurrentPlayer] =
                playerInputInt.PlayerInpInt($"Please place a row number for Player{CurrentPlayer + 1}:", n) - 1;

            ColPlayer[CurrentPlayer] =
                playerInputInt.PlayerInpInt($"Please place a column number for Player{CurrentPlayer + 1}:", n) -
                1;
 
            if (BoardLocations[RowPlayer[CurrentPlayer], ColPlayer[CurrentPlayer]] != 0)
            {
                Console.WriteLine("This space has been input a number, try another space");
            }
        } while (BoardLocations[RowPlayer[CurrentPlayer], ColPlayer[CurrentPlayer]] != 0);
    }

    public void ProcessInBoard()
    {
        do
        {
            BoardLocations[RowPlayer[CurrentPlayer], ColPlayer[CurrentPlayer]] =
                numInput.NumInt($"Please enter an {CurrentNum} number:", OddEvenInNSquare[CurrentPlayer]);
            if (OddEvenInNSquare[CurrentPlayer]
                .Contains(BoardLocations[RowPlayer[CurrentPlayer], ColPlayer[CurrentPlayer]]))
            {
                int index = Array.IndexOf(OddEvenInNSquare[CurrentPlayer],
                    BoardLocations[RowPlayer[CurrentPlayer], ColPlayer[CurrentPlayer]]);
                OddEvenInNSquare[CurrentPlayer][index] = 0;
            }
            else
            {
                Console.WriteLine("This number is already in the board, please try again");
            }

            ResultCheck resultCheck = new ResultCheck();
            resultCheck.AmountCheck($"Player {CurrentPlayer + 1}");

            //AmountCheck($"Player {CurrentPlayer + 1}"); //, ref human1Total, ref human2Total);

        } while (OddEvenInNSquare[CurrentPlayer]
                     .Contains(BoardLocations[RowPlayer[CurrentPlayer], ColPlayer[CurrentPlayer]]) ||
                 BoardLocations[RowPlayer[CurrentPlayer], ColPlayer[CurrentPlayer]] > n * n ||
                 BoardLocations[RowPlayer[CurrentPlayer], ColPlayer[CurrentPlayer]] == 0);
    }
}