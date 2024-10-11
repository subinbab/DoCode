using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoCode.FilesOperations
{
    public class FileOperationMethod
    {
        public static void Run(string path)
        {
            string controlllerPath = path;
            string filePath = @path; 
            string contentToInsert = @"

        public void ExampleMethod2()
        {
            Console.WriteLine(""Hai"");
        }
";

            // Read the content of the file
            string fileContent = File.ReadAllText(filePath);

            // Find the position to insert the code (after the class declaration)
            string classKeyword = "class ";
            int classIndex = fileContent.IndexOf(classKeyword);

            if (classIndex >= 0)
            {
                // Find the position after the opening curly brace of the class
                int insertIndex = fileContent.IndexOf("{", classIndex) + 1;

                // Insert the new code at that position
                string updatedContent = fileContent.Insert(insertIndex, contentToInsert);

                // Write the updated content back to the file
                File.WriteAllText(filePath, updatedContent);

                Console.WriteLine("Code inserted successfully.");
            }
            else
            {
                Console.WriteLine("Class definition not found.");
            }
           

            // Create the file and write content into it
            //CreateFile(filePath, contentToInsert);

            Console.WriteLine($"File created and content written at: {filePath}");
        }

        static void CreateFile(string filePath, string content)
        {
            // Check if file already exists
            if (File.Exists(filePath))
            {
                Console.WriteLine("File already exists. Content will be overwritten.");
            }

            // Write content to the file
            File.WriteAllText(filePath, content);
        }
    }
}
