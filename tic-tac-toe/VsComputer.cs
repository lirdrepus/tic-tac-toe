namespace tic_tac_toe;

//Controls Human vs Computer gameplay.
//Includes human moves, computer move and win detection logic
public class VsComputer
{
    private readonly GlobalVariables gv;
    private PrintBoard printBoard;

    public VsComputer(GlobalVariables globalVariables)
    {
        gv = globalVariables;
        printBoard = new PrintBoard(gv);
    }
    

    public void HumanVsComputer()
    {
        //var game = new Game(gv);
        Player player = new Human(gv);
        Player computer = new Computer(gv);
        
        while (true)
        {
            player.Play();
            //game.HumanInput();
            //game.ProcessInBoard();
            
            if (gv.CurrentPlayer == 0)
            {
                gv.CurrentPlayer = 1;
                gv.CurrentNum = "even";
            }

            computer.Play();
            //BoardCheck();
            //ComInput();
            
            printBoard.PntCurrentBoard();


            if (gv.CurrentPlayer == 1)
            {
                gv.CurrentPlayer = 0;
                gv.CurrentNum = "odd";
            }
        }

    }
}