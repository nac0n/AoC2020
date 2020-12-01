using System.IO;
String line;
List<int> lines = new System.Collections.Generic.List<int>();

private int[] FindThreeNumbers(List<int> lines) {
    int[] temp = new int[3];
    for (int i = 0; i < lines.Count; i++) {
        for (int x = (i + 1); x < lines.Count; x++) {
            
            for (int y = (i + 2); y < lines.Count; y++) {
            
                if(lines[i] + lines[x] + lines[y] == 2020) {
                    Console.WriteLine(lines[i].ToString() + " " + lines[x].ToString() + " " + lines[y].ToString());
                    temp[0] = lines[i];
                    temp[1] = lines[x];
                    temp[2] = lines[y];
                    return temp;
                }
            }
        }
    }
    temp[0] = 0;
    temp[1] = 0;
    temp[2] = 0;
    return temp;
}

try {
    StreamReader sr = new StreamReader("./day1.txt");
    line = sr.ReadLine();

    while(line != null) {
        // Console.WriteLine(line);
        lines.Add(Int32.Parse(line));
        line = sr.ReadLine();
    }
     //close the file
    int[] threeNumbers = FindThreeNumbers(lines);
    int threeNumbersSum = (threeNumbers[0] * threeNumbers[1] * threeNumbers[2]);
    Console.WriteLine(threeNumbersSum.ToString());
    sr.Close();
}

catch(Exception e) {
    Console.WriteLine("Exception: " + e.Message);
}
finally {
    Console.WriteLine("Finished reading blocks");
}
