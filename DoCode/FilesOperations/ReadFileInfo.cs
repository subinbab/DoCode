using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DoCode.FilesOperations
{
    public class ReadFileInfo
    {
        public static DoCode.Models.FileInfo GetFileInfo()
        {
            DoCode.Models.FileInfo fileInfo = null;
            try
            {
                fileInfo = new DoCode.Models.FileInfo();
                string currentDirectory = "C:\\Users\\Subin Babu\\source\\repos\\DoCode\\DoCode";
                // Search for .cs files in the current directory
                string[] csFiles = Directory.GetFiles(currentDirectory, "*.cs");
                // Check if any .cs files are found
                if (csFiles.Length > 0)
                {
                    foreach (string file in csFiles)
                    {
                        Console.WriteLine($"\nReading file: {file}");
                        // Read the file content
                        string fileContent = File.ReadAllText(file);

                        // Regular expression to find class names
                        Regex regex = new Regex(@"\bclass\s+(\w+)", RegexOptions.Compiled);

                        // Find matches for the class keyword and capture the class name
                        MatchCollection matches = regex.Matches(fileContent);

                        if (matches.Count > 0)
                        {
                            foreach (Match match in matches)
                            {
                                Console.WriteLine($"Class found: {match.Groups[1].Value}");
                                fileInfo.className = match.Groups[1].Value;
                                fileInfo.fileName = csFiles[0];
                            }
                        }
                        else
                        {
                            Console.WriteLine("No classes found in this file.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No .cs files found in the current directory.");
                }

            }
            catch (Exception ex)
            {

            }
            return fileInfo;
        }
    }
}
