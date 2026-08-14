namespace tic_tac_toe;
//Abstract Player class defines the common structure and behavior
public abstract class Player
{
    protected GlobalVariables gv;
    protected NumberInput numInput;
    protected PrintBoard printBoard;
    private const int Player1 = 0;
    private const int Player2 = 1;
    
    //Abstract method to be implemented by subclasses
    public abstract void Play();
    
    //Switch turn between players
    protected void SwapPlayers()
    {
        if (gv.CurrentPlayer == Player1)
        {
            gv.CurrentPlayer = Player2;
            gv.CurrentNum = "even";
        }
        else if (gv.CurrentPlayer == Player2)
        {
            gv.CurrentPlayer = Player1;
            gv.CurrentNum = "odd";
        }
    }
}