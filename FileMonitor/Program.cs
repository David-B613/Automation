using System;
using System.IO;

namespace FileMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            FileSystemWatcher FO = new FileSystemWatcher(@"C:\"); // The location of where you will monitor this can be changed to anything 
            FO.EnableRaisingEvents = true;
            FO.IncludeSubdirectories = true;


            FO.Changed += FileChanged;     // Method for when something changes in the location 

            FO.Created += FileCreated;     // Method for when something is created in the location

            FO.Deleted += FileDeleted;     // Method for when something changes in the location ** This could mean the file was removed from the folder into a new folder 
                                           // Something I can come back make better.**

            FO.Renamed += FileRenamed;     // Method for when a file name is changed in the location

            Console.Read(); // This is to stop the program from running 


        }

        static void FileRenamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine("File: {0} renamed to {1} at time: {2}", e.OldName, e.Name, DateTime.Now.ToLocalTime());
        }

        static void FileDeleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("File: {0} deleted at time: {1}", e.Name, DateTime.Now.ToLocalTime());
        }

        static void FileCreated(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("File: {0} Created at time {1},", e.Name, DateTime.Now.ToLocalTime());

        }

        static void FileChanged(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("File {0} Changed at time {1}", e.Name, DateTime.Now.ToLocalTime());
        }
    }
}
