namespace tic_tac_toe;

//PlayerInputInt class make sure player input for board coordinates within the valid range

public class PlayerInputInt
{
    string? InputString { get; set; }
    int n { get; set; }
    
    public int PlayerInpInt (string inputString, int n)
    {
        this.InputString = inputString;
        this.n = n;
        
        var inpInt = new InputInt();
        int inputInt = inpInt.InputInteger(inputString);
        
        while (0 >= inputInt || inputInt > n)
        {
            inputInt = inpInt.InputInteger(inputString);
        }
        return inputInt;
    }
}
