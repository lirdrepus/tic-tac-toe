namespace tic_tac_toe;

public abstract class Player
{
    protected GlobalVariables gv;
    //protected int currentPlayer;
    protected NumberInput numInput;
    protected PrintBoard printBoard;
    
    
    public abstract void Play();
}