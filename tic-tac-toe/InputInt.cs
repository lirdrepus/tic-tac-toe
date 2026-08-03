using System.Runtime.CompilerServices;

namespace tic_tac_toe;

public class InputInt
{
    public string inputString { get; set; }
    
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
                inputInt = 0;
                Console.WriteLine("Please enter an integer:");
            }
        }
   
        return inputInt;
    }

}

/*
//varify whether the input is integer or not
   static int InputInt(string inputString)
   {
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
               inputInt = 0;
               Console.WriteLine("Please enter an integer:");
           }
       }
   
       return inputInt;
   }
   
   */