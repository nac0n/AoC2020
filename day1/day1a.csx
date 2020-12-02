using System.IO;
String line;
List<int> lines = new System.Collections.Generic.List<int>();

private int[] FindTwoNumbers(List<int> lines) {
    int[] temp = new int[2];
    for (int i = 0; i < lines.Count; i++) {
        for (int x = (i + 1); x < lines.Count; x++) {
            
            if(lines[i]+ lines[x] == 2020) {
                temp[0] = lines[i];
                temp[1] = lines[x];
                return temp;
            }
        }
    }
    temp[0] = 0;
    temp[1] = 0;
    return temp;
}

try {
    StreamReader sr = new StreamReader("./day1.txt");
    line = sr.ReadLine();

    while(line != null) {
        lines.Add(Int32.Parse(line));
        line = sr.ReadLine();
    }
    
    int[] twoNumbers = FindTwoNumbers(lines);
    int twoNumbersSum = (twoNumbers[0] * twoNumbers[1]);
    Console.WriteLine(twoNumbersSum.ToString());
    sr.Close();
}

catch(Exception e) {
    Console.WriteLine("Exception: " + e.Message);
}
finally {
    Console.WriteLine("Finished reading blocks");
}
