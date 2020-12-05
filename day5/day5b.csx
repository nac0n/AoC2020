#!/usr/bin/env dotnet-script
using System.IO;

String line;
double highestSeatID = 0;
double lowestSeatID = 9999;

private const double startRowNumber = 127;
private const double startColNumber = 7;

List<double> seatIDs = new List<double>();


private double GetRemainingSeatID() {
    for(double i = lowestSeatID; i < highestSeatID; i+= 1) {
        if(!seatIDs.Contains(i)) {
            
            return i;
        }
    }
    return -1;
}

try {

    StreamReader sr = new StreamReader("./day5.txt");

    var lines = sr.ReadToEnd().Split("\n").Select(l => l.Trim());
    
    foreach(var line in lines) {
        double row = 0;
        double col = 0;
        double rowMinNr = 0;
        double rowMaxNr = startRowNumber;
        
        double colMinNr = 0;
        double colMaxNr = startColNumber;
        
        for(int i = 0; i < line.Length - 3; i++) {

            if(i == line.Length - 4) {
                row = line[i] == 'F' ? rowMinNr : rowMaxNr;
            }

            switch (line[i])
            {
                case 'F':
                    rowMaxNr = Math.Floor((rowMaxNr + rowMinNr) / 2);
                    break;
                case 'B':
                    rowMinNr = Math.Ceiling((rowMaxNr + rowMinNr) / 2);
                    break;
            }
        }

        for(int i = line.Length - 3; i < line.Length ; i++) {
            if(i == line.Length - 1) {
                
                col = line[i] == 'L' ? colMinNr : colMaxNr;
                
                seatIDs.Add((row * 8) + col);

                if(((row * 8) + col) > highestSeatID) {
                    highestSeatID = (row * 8) + col;
                }
                if(((row * 8) + col) < lowestSeatID) {
                    lowestSeatID = (row * 8) + col;
                }
                
            }

            switch (line[i])
            {
                case 'L':
                
                    colMaxNr = Math.Floor((colMaxNr + colMinNr) / 2);
                    break;
                case 'R':
                
                    colMinNr = Math.Ceiling((colMaxNr + colMinNr) / 2);
                    break;
            }
        }
    }

    double yourID = GetRemainingSeatID();

    Console.WriteLine(yourID);

}

catch(Exception e) {
    Console.WriteLine("Exception: " + e);
}
finally {
    Console.WriteLine("Finished");
};