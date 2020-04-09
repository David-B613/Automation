using System;
using System.IO;
using System.Text;

class Test 
{
    public static void Main() 
    {
        string path = @"C:\Users\baber\Desktop\MyTest123.txt";

        // Create the file, or overwrite if the file exists.
        using (FileStream fs = File.Create(path, 1024)) 
        {
            byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");
            // Add some information to the file.
            fs.Write(info, 0, info.Length);
        }

        // Open the stream and read it back.
        using (StreamReader sr = File.OpenText(path)) 
        {
            string s = "";
            while ((s = sr.ReadLine()) != null) 
            {
                Console.WriteLine(s);
            }
        }
    }
}