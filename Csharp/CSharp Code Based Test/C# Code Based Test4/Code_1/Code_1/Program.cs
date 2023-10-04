using System;
using System.IO;

class Program
{
    static void Main()
    {
        
        string path = "D:/ics programs/ASHWIN_Codes/Csharp/CSharp Code Based Test/C# Code Based Test4/Code_1/Code_1/Textfile.txt";
        string content = "Hey there! hi.";
        try
        {
            File.WriteAllText(path, content);
            
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                string textToAppend = "Hi , Its Ashwin Here.";

                writer.WriteLine(textToAppend);

                writer.Close();
            }

            Console.WriteLine("Text appended to the file successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}