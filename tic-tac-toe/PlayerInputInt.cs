namespace tic_tac_toe;

public class PlayerInputInt
{
    string inputString { get; set; }
    int n { get; set; }
    
    public int PlayerInpInt (string inputString, int n)
    {
        this.inputString = inputString;
        this.n = n;
        
        var inpInt = new InputInt();
        int inputInt = inpInt.InputInteger(inputString);
        //int inputInt = InputInt(inputString);
        while (0 >= inputInt || inputInt > n)
        {
            inputInt = inpInt.InputInteger(inputString);
        }
        return inputInt;
    }
}

/*/Human input
   static int PlayerInpInt (string inputString, int n)
   {
       int inputInt = InputInt(inputString);
       while (0 >= inputInt || inputInt > n)
       {
           inputInt = InputInt(inputString);
       }
       return inputInt;
   }
   */