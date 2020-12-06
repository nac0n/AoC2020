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
        string result = group.Replace("\n", "");
        string comparisonString = new string(result.Distinct().ToArray());
        int peopleAmount = group.Count(f => (f == '\n')) + 1;

        foreach(char c in comparisonString) {
            if(result.Count(f => (f == c)) == peopleAmount) {
                qCount++;
            }
        }
    }

    Console.WriteLine("Answer: " + qCount.ToString());

}

catch(Exception e) {
    Console.WriteLine("Exception: " + e);
}
finally {
    Console.WriteLine("Finished");
};