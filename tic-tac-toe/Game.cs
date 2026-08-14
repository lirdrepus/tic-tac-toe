namespace tic_tac_toe;

//Game class controls the main gameplay loop, player actions, human input, board updates, and turns.

public class Game
{
    //Constructor initializes game with global variables and input handler
    private readonly GlobalVariables gv;
    private Player human, computer;
    
    public Game(GlobalVariables globalVariables)
    {
        gv = globalVariables;
        human = new Human(gv);
        computer = new Computer(gv);
    }

    //Runs Human vs Human mode until game ends.
    public void HumanVsHuman()
    {
        while (true)
        { 
            human.Play();
        }
    }
    
    //Runs Human vs Computer mode until game ends.
    public void HumanVsComputer()
    {
        while (true)
        {
            human.Play();
            computer.Play();
        }
    }
}