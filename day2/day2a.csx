#!/usr/bin/env dotnet-script
using System.IO;

String line;
List<string> lines = new System.Collections.Generic.List<string>();

int counter = 0;

private int getMinForLine(String line) {
    String arr = line.Substring(0, line.IndexOf("-"));
    return int.Parse(arr);
}

private int getMaxForLine(String line) {
    String arr = line.Substring(line.IndexOf("-") + 1, line.IndexOf(" ") - 2);
    return int.Parse(arr);
}

private char getLetterForLine(String line) {
    String arr = line.Substring(line.IndexOf("-") + 1, line.IndexOf(" ") - 2);
    return 'a';
}

private string getPasswordForLine(String line) {
    return "aaasdsdsd";
}

// private char[] getPasswordForLine(String line) {
//     char[] passwordArr = new char[line.Count()];
//     for(int i = 0; i < (line.Count() - 1); i++) {

//     }

//     return passwordArr;
// }

private Boolean isValidPassword(int min, int max, string letter, string password) {

    int count = password.Count(x => Equals(x, password));
    // Console.WriteLine(count);

    if(count >= min && count <= max) {
        return true;
    }

    return false;
}

try {
    StreamReader sr = new StreamReader("./day2.txt");
    line = sr.ReadLine();

    while(line != null) {
        lines.Add(line);
        line = sr.ReadLine();
    }
    sr.Close();

    foreach(String line in lines) {
        int min = int.Parse(line.Substring(0, line.IndexOf("-")));
        int max = int.Parse(line.Substring(line.IndexOf("-") + 1, line.IndexOf(" ") - 2));
        String letter = line.Substring(line.IndexOf(' ') + 1, line.IndexOf(':'));
        
        String password = line.Substring(line.IndexOf(' ', line.IndexOf(' ') + +2));;
        
        Console.WriteLine(letter);
        // min = getMinForLine(line);
        // max = getMaxForLine(line);
        // letter = getLetterForLine(line);
        
        password = getPasswordForLine(line);

        if(isValidPassword(min, max, letter, password)) {
            counter++;
        }
    }

    // Console.WriteLine(counter);

}

catch(Exception e) {
    Console.WriteLine("Exception: " + e);
}
finally {
    Console.WriteLine("Finished");
}
