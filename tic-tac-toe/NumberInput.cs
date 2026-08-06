using System.Globalization;

namespace tic_tac_toe;

public class NumberInput
{
    public int[] Integers { get; set; }
    public string InputString { get; set; }
    //public int PlayerChoice { get; set; }

    public int NumInt(string inputString, int[] integers)
    {
        this.InputString = inputString;
        this.Integers = integers;

        var InputInt = new InputInt();
        int inputInt = InputInt.InputInteger(inputString);
        //int inputInt = InputInt(inputString);
        while (!integers.Contains(inputInt))
        {
            inputInt = InputInt.InputInteger(inputString);
        }

        return inputInt;
    }
}