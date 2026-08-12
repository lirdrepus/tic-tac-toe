namespace tic_tac_toe;

//NumberInput class checks user input matches one of the integers in the array.
//It ensures players only choose numbers from odd and even pools.

public class NumberInput
{
    public int[]? Integers { get; set; }
    public string? InputString { get; set; }
    

    public int NumInt(string inputString, int[] integers)
    {
        this.InputString = inputString;
        this.Integers = integers;

        var inpInt = new InputInt();
        int inputInt = inpInt.InputInteger(inputString);
        
        while (!integers.Contains(inputInt))
        {
            Console.WriteLine("please enter a valid integer");
            inputInt = inpInt.InputInteger(inputString);
        }

        return inputInt;
    }
}