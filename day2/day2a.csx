#!/usr/bin/env dotnet-script
using System.IO;

String line;
List<string> lines = new System.Collections.Generic.List<string>();

int answer = 0;

private Boolean isValidPassword(int min, int max, string letter, string password) {

    int count = password.Split(char.Parse(letter)).Length - 1;
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
   
        int index1 = line.IndexOf("-");
        int index2 = line.IndexOf(":");

        int min = int.Parse(line.Substring(0, index1));
        int max = int.Parse(line.Substring(index1 + 1, ((line.IndexOf(" ")) - (index1 + 1)) ) );
        
        String letter = line.Substring(index2 - 1, 1);
        String password = line.Substring(index2 + 1);

        if(isValidPassword(min, max, letter, password)) {
            answer++;
        }

    }

    Console.WriteLine(answer);

}

catch(Exception e) {
    Console.WriteLine("Exception: " + e);
}
finally {
    Console.WriteLine("Finished");
}
