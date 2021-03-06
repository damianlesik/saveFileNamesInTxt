using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nazwyPlikow
{
    class Program
    {
        static void Main(string[] args)
        {
            bool done = false;
            while (!done)
            {
                Console.Write("1 - list file names in console\n2 - save file names with extension in txt\n3 - close the application\nSelect mode: ");
                var selectedProgramMode = Console.ReadLine();

                switch (selectedProgramMode)
                {
                    case "1":
                        fileNamesWithoutExtension();
                        break;
                    case "2":
                        saveFileNamesInTxt();
                        break;
                    case "3":
                        done = true;
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Error. Bad option. Try again\n\n");
                        break;
                }
            }
        }
        static void fileNamesWithoutExtension()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var files = Directory.GetFiles(currentDirectory);
            var fileNamesWithoutExtension = new List<string>();
            foreach (var file in files)
            {
                fileNamesWithoutExtension.Add(Path.GetFileNameWithoutExtension(file));
            }
            foreach (var file in fileNamesWithoutExtension)
            {
                Console.WriteLine(file);
            }
        }
        static void saveFileNamesInTxt()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var files = Directory.GetFiles(currentDirectory);
            var fileNames = new List<string>();
            foreach (var file in files)
            {
                fileNames.Add(Path.GetFileName(file));
            }
            FileInfo namesFile = new FileInfo(currentDirectory + "\\names.txt");
            try
            {
                if (namesFile.Exists)
                {
                    namesFile.Delete();
                }
                var streamWriter = namesFile.CreateText();
                foreach (var fileName in fileNames)
                {
                    streamWriter.WriteLine(fileName);
                }
                streamWriter.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Error, cannot write the filenames into TXT");
                throw;
            }
            
        }
    }
}
