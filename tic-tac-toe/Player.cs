namespace tic_tac_toe;

public class Player
{
    public string Name { get; set; }
    
    public int NumbersInPlayer { get; set; }
    
    public int ContainNumbers  { get; set; }
    
    public void NumInPlayer(int number)
    {
        NumbersInPlayer = number;
    }
}