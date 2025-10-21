// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

Console.WriteLine("Hello, World!");

//string filePath = "C:\\Arquivos\\example.txt";
string filePath = @"example.txt";
string directoryPath = @"C:\Arquivos\";

try 
{
    if (!Directory.Exists(directoryPath))
    {
        Directory.CreateDirectory(directoryPath);
    }
}
catch (Exception e)
{
    Console.WriteLine(e.StackTrace);
    Console.WriteLine(e.Message);
}

var fullPath = Path.Combine(directoryPath, filePath);

//StreamReader reader = new StreamReader(filePath);
//using (reader)
//{
//    string content = reader.ReadToEnd();
//    Console.WriteLine(content);
//    reader.Close();
//}

StreamWriter writer = new StreamWriter(fullPath, append: true);

writer.WriteLine("Aqui eu adicionei uma linha no meu arquivo!");
writer.WriteLine("Aqui eu adicionei uma linha de novo mais uma linha no meu arquivo!");
writer.Close();

StreamReader sr = new StreamReader(fullPath);
using (sr)
{
    string content = sr.ReadToEnd();
    Console.WriteLine(content);
    sr.Close();
}