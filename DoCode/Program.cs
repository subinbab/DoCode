// See https://aka.ms/new-console-template for more information
using DoCode.FilesOperations;
using DoCode.XMLOperations;
using System.Diagnostics;
using System.Reflection;
using WebApplication1.Controllers;
using WebApplication1.DoCode;

Console.WriteLine("Hello, World!");
// Get the Type of the class using reflection
Type type = typeof(ExampleClass);
var webQulaifiedName = type.AssemblyQualifiedName.Split(",")[0];
var folderPath = webQulaifiedName.Split(".");
string generatePath = "\\"+String.Join("\\", folderPath)+".cs";
string currentDirectory = Directory.GetCurrentDirectory();
string parentDirectory = "D:\\DoCode";
string filePath = parentDirectory +"\\"+type.AssemblyQualifiedName.Split(",")[1].Replace(" ","")+ generatePath;

Console.WriteLine("Hwllo");
//FileOperationMethod.Run(filePath);
//XMLWrite.Main();
XMLRead.Main();
ReadFileInfo.GetFileInfo();





















//// Fetch and print class name
//Console.WriteLine("Class Name: " + type.Name);
//// Get the file path where this class is defined
//string filePath = GetSourceFilePath(typeof(TestController));

//// Fetch and print class properties
//Console.WriteLine("\nProperties:");
//PropertyInfo[] properties = type.GetProperties();
//foreach (PropertyInfo property in properties)
//{
//    Console.WriteLine($"- {property.Name} ({property.PropertyType})");
//}

//// Fetch and print class methods
//Console.WriteLine("\nMethods:");
//MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
//foreach (MethodInfo method in methods)
//{
//    Console.WriteLine($"- {method.Name} ({method.ReturnType})");
//}

//// Fetch and print class fields (if any)
//Console.WriteLine("\nFields:");
//FieldInfo[] fields = type.GetFields();
//foreach (FieldInfo field in fields)
//{
//    Console.WriteLine($"- {field.Name} ({field.FieldType})");
//}

//// Fetch and print constructors
//Console.WriteLine("\nConstructors:");
//ConstructorInfo[] constructors = type.GetConstructors();
//foreach (ConstructorInfo constructor in constructors)
//{
//    Console.WriteLine($"- {constructor}");
//}
//FileOperationMethod.Run("D:\\DoCode\\example.cs");
static string GetSourceFilePath(Type type)
{
    // Create a dummy stack trace by instantiating the class
    var method = type.GetMethod("PrintDetails");
    // Create an instance of the TestService
    var serviceInstance = new TestService();

    // Add the service instance to the constructor parameters
    var parameters = new object[0 + 1];
    parameters[0] = serviceInstance; // First parameter is the service

    //var constructor = type.GetConstructor(new Type[]{ typeof(ITestService)});
    //TestController instance = (TestController)constructor.Invoke(parameters);
    method.Invoke(Activator.CreateInstance(type), null);

    // Use StackTrace to get the file path information
    StackTrace stackTrace = new StackTrace(true); // 'true' includes file information if available
    StackFrame frame = stackTrace.GetFrame(0);    // Get the first frame

    // Get the file path from the stack frame
    string filePath = frame.GetFileName();
    return filePath;
}
