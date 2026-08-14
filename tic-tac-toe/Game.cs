namespace tic_tac_toe;

//Game class controls the main gameplay loop, player actions, human input, board updates, and turns.

public class Game
{
    //Constructor initializes game with global variables and input handler
    private readonly GlobalVariables gv;
    private Player player, computer;
    
    public Game(GlobalVariables globalVariables)
    {
        gv = globalVariables;
        player = new Human(gv);
        computer = new Computer(gv);
    }

    //Runs Human vs Human mode until game ends.
    public void HumanVsHuman()
    {
        //Player player = new Human(gv);
        while (true)
        {
            
            player.Play();
            //Players input for coordinates
            //HumanInput();

            //Players place chosen number on board
            //ProcessInBoard();

            //Switch turn between players
            if (gv.CurrentPlayer == 0)
            {
                gv.CurrentPlayer = 1;
                gv.CurrentNum = "even";
            }
            else
            {
                gv.CurrentPlayer = 0;
                gv.CurrentNum = "odd";
            }
        }
    }
    
    public void HumanVsComputer()
    {
        //var game = new Game(gv);
        //Player player = new Human(gv);
        //Player computer = new Computer(gv);
        
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
            
            //printBoard.PntCurrentBoard();


            if (gv.CurrentPlayer == 1)
            {
                gv.CurrentPlayer = 0;
                gv.CurrentNum = "odd";
            }
        }

    }
}