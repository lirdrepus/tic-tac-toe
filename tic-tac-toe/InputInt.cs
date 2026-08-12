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
        string tempString;
        while (inputInt == 0)
        {
            try
            {
                while (true)
                {
                    tempString = Console.ReadLine().ToUpper();
                    if (tempString == "H")
                    {
                        Console.WriteLine("In the Game, you need to enter integers between 1 and the n you input for row and columns," +
                                          "\nthen Player 1 inputs odd number while Player 2 input even number." +
                                          "\nIf the input number is invalid, it needs to be input again." +
                                          "\nThe first player to complete one of those lines adding up to score point is the winner." +
                                          "\n" +
                                          "\nInput a valid number:");
                    }
                    else if (Convert.ToInt16(tempString) <= 0)
                    {
                        Console.WriteLine("Your input is incorrect, please enter an valid integer:");
                    }
                    else if(tempString != "H")
                    {
                        inputInt = Convert.ToInt16(tempString);
                        break;
                    }
                }
            }
            catch (System.Exception)
            {
                Console.WriteLine("Your input is incorrect, please enter an integer:");
                inputInt = 0;
            }
        }
   
        return inputInt;
    }

}