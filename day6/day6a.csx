#!/usr/bin/env dotnet-script
using System.IO;

String line;
double highestSeatID = 0;

private const double startRowNumber = 127;
private const double startColNumber = 7;

int qCount = 0;

try {

    StreamReader sr = new StreamReader("./day6.txt");

    var groups = sr.ReadToEnd().Split("\n\n").Select(l => l.Trim());
    
    foreach(var group in groups) {
        string temp = group.Replace("\n", "");
        string result = new string(temp.Distinct().ToArray());
        qCount += result.Length;
    }

    Console.WriteLine(qCount);

}

catch(Exception e) {
    Console.WriteLine("Exception: " + e);
}
finally {
    Console.WriteLine("Finished");
};