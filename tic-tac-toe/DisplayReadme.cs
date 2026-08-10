namespace tic_tac_toe;

//Displays Readme from txt file

public class DisplayReadme
{
    private string? readFile { get; set; }

    public void PrintReadme(string txtFile)
    {
        readFile = txtFile;

        using (StreamReader sr = new StreamReader(readFile))
        {
            string content = sr.ReadToEnd();
            Console.WriteLine(content);
        }
    }
}