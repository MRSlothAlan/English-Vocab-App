using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/*
 * This class handles the IO operations of files.
 * import text file
 * export encoded tree in format.
 * */

namespace InAppDictionary
{
    public class FileOperations
    {
        // put this to App.config.
        public static string defaultPath;
        public string[] in_text;

        public FileOperations(string in_default_path) {
            defaultPath = in_default_path;
            this.in_text = Enumerable.Repeat((string)"", 0).ToArray();
        }
        public void readDictionary(string in_file_path)
        {
            // just pretent to init.
            this.in_text = Enumerable.Repeat((string)"", 0).ToArray();
            try
            {
                this.in_text = System.IO.File.ReadAllLines(in_file_path).ToArray();
            }
            catch (Exception)
            {
                // use default path
                try
                {
                    Console.WriteLine("[WARNING] path invalid, using default path...");
                    this.in_text = System.IO.File.ReadAllLines(defaultPath);
                }
                catch (Exception)
                {
                    Console.WriteLine("[ERROR] read dict text file failed");
                    return;
                }
            }
            for (int i = 0; i < in_text.Length; i++)
            {
                // this is my first time dealing with C# array
                in_text[i] = in_text[i].ToLower();
            }
        }
    }
}
