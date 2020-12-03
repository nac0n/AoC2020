#!/usr/bin/env dotnet-script
using System.IO;

String line;
List<string> lines = new System.Collections.Generic.List<string>();

int answer = 0;

private int GetNewHorizontalPos(int prevHorizontalLinePos, string line ) {
    if((prevHorizontalLinePos + 3) < line.Count()) {
        return prevHorizontalLinePos + 3;
    }
    else {
        return ((prevHorizontalLinePos + 3) - line.Count());
    }
}

try {

    StreamReader sr = new StreamReader("./day3.txt");
    line = sr.ReadLine();

    while(line != null) {
        lines.Add(line);
        line = sr.ReadLine();
    }
    sr.Close();

    int prevHorizontalLinePos = 0;
    int newHorizontalLinePos = 0;

    for(int lineIndex = 1; lineIndex < lines.Count(); lineIndex ++) {
        newHorizontalLinePos = GetNewHorizontalPos(prevHorizontalLinePos, lines[lineIndex]);
        prevHorizontalLinePos = newHorizontalLinePos;

        if(lines[lineIndex][newHorizontalLinePos].CompareTo('#') == 0) {
            answer++;
        }
    }

    Console.WriteLine("Answer: " + answer.ToString());

}

catch(Exception e) {
    Console.WriteLine("Exception: " + e);
}
finally {
    Console.WriteLine("Finished");
}