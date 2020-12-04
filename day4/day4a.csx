#!/usr/bin/env dotnet-script
using System.IO;

String line;
List<string> passports = new System.Collections.Generic.List<string>();
int validPassports = 0;

List<string> validFields = new List<string>();
string[] fieldArray = {"byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid", "cid"};

private void FillValidFieldsList() {
    foreach(string field in fieldArray) {
        validFields.Add(field);
    }
}
private void ResetValidFieldsList() {
    foreach(string field in fieldArray) {
        validFields.RemoveRange(0, validFields.Count);
    }
}
private Dictionary<string, string> GetPassportKeyValues(string passportStr) {
    Dictionary<string, string> passPortDict = new Dictionary<string, string>();

    string[] words = passportStr.Split(' ');
    foreach(string word in words) {
        string[] keyValue = word.Split(':');
        passPortDict.Add(keyValue[0], keyValue[1]);
    }
    return passPortDict;
}

private Boolean isValidPassport(string passportStr) {
    // cid is ok to be missing

    // get string as dict
    Dictionary<string, string> passportDict = GetPassportKeyValues(passportStr);
    FillValidFieldsList();

    // loop fields and validate the key, if not it's false.
    foreach(string field in fieldArray) {
        if(!passportDict.ContainsKey(field) && field != "cid") {
            Console.WriteLine("Not Valid passportStr: " + passportStr);
            Console.WriteLine("Not Valid field: " + field);
            return false;
        }
    }

    ResetValidFieldsList();
    return true;
}

try {
    StreamReader sr = new StreamReader("./day4.txt");
    line = sr.ReadLine();

    string savedLine = "";

    while(line != null) {
        if(line.Length == 0) {
            // passports.Add(savedLine.Trim());
            if(isValidPassport(savedLine.Trim())) {
                // Console.WriteLine("ValidPass: " + savedLine.Trim());
                validPassports++;
            }
            savedLine = "";
        }
        else {
            savedLine += line + " ";
        }
        line = sr.ReadLine();
    }
    sr.Close();

    Console.WriteLine("Answer: " + validPassports.ToString());

}

catch(Exception e) {
    Console.WriteLine("Exception: " + e);
}
finally {
    Console.WriteLine("Finished");
};