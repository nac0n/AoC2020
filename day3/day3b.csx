#!/usr/bin/env dotnet-script
using System.IO;

String line;
List<string> lines = new System.Collections.Generic.List<string>();

Int64 answer = 0;

private int GetNewHorizontalPos(int prevHorizontalLinePos, int hSteps, string line ) {
    if((prevHorizontalLinePos + hSteps) < line.Count()) {
        return prevHorizontalLinePos + hSteps;
    }
    else {
        return ((prevHorizontalLinePos + hSteps) - line.Count());
    }
}

private int GetTreesBySlope(int right, int down) {
    int prevHorizontalLinePos = 0;
    int newHorizontalLinePos = 0;
    int treeCounter = 0;

    // for every line
    for(int lineIndex = down; lineIndex < lines.Count(); lineIndex += down) {
        newHorizontalLinePos = GetNewHorizontalPos(prevHorizontalLinePos, right, lines[lineIndex]);
        prevHorizontalLinePos = newHorizontalLinePos;
        if(lines[lineIndex][newHorizontalLinePos].CompareTo('#') == 0) {
            treeCounter++;
        }
    }

    return treeCounter;
}

private Int64 GetProductOfTrees(int[] results) {
    Int64 product = 1;

    foreach(int result in results) {
        product = product * result;
    }

    return product;
}

try {

    StreamReader sr = new StreamReader("./day3.txt");
    line = sr.ReadLine();

    while(line != null) {
        lines.Add(line);
        line = sr.ReadLine();
    }
    sr.Close();

    int[] res = new int[5];
    res[0] = GetTreesBySlope(1, 1);
    res[1] = GetTreesBySlope(3, 1);
    res[2] = GetTreesBySlope(5, 1);
    res[3] = GetTreesBySlope(7, 1);
    res[4] = GetTreesBySlope(1, 2);

    answer = GetProductOfTrees(res);

    Console.WriteLine("Answer: " + answer.ToString());

}

catch(Exception e) {
    Console.WriteLine("Exception: " + e);
}
finally {
    Console.WriteLine("Finished");
}