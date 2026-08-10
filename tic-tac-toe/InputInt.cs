namespace tic_tac_toe;

//InputInt class handles integer input from the console.
//It makes sure user enters a valid integer and re-prompts till valid.

public class InputInt
{
    public string? inputString { get; set; }
    
    public int InputInteger(string inputString)
    {
        this.inputString = inputString;
        
        Console.WriteLine(inputString);
        int inputInt = 0;
        while (inputInt == 0)
        {
            try
            {
                inputInt = Convert.ToInt16(Console.ReadLine());
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Your input is incorrect, please enter an integer:");
                inputInt = 0;
            }
        }
   
        return inputInt;
    }

}