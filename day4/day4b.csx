#!/usr/bin/env dotnet-script


using System.Text.RegularExpressions;
using System.IO;

String line;
List<string> passports = new System.Collections.Generic.List<string>();
int validPassports = 0;

List<string> validFields = new List<string>();
string[] fieldArray = {"byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid", "cid"};

private Dictionary<string, string> GetPassportKeyValues(string passportStr) {
    Dictionary<string, string> passPortDict = new Dictionary<string, string>();

    string[] words = passportStr.Split(' ');
    foreach(string word in words) {
        string[] keyValue = word.Split(':');
        passPortDict.Add(keyValue[0], keyValue[1]);
    }
    return passPortDict;
}

private string[] GetHgtSplit(string str) {
    for(int i = 0; i < str.Length; i++) {
        if (str[i] < '0' || str[i] > '9'){
            return new string[]{str.Substring(0, i), str.Substring(i)};
        }
    }
    return new string[]{ "-1", ""};
}

private Boolean isValidPassport(string passportStr) {
    // cid is ok to be missing

    // get string as dict
    Dictionary<string, string> passportDict = GetPassportKeyValues(passportStr);

    // loop fields and validate the key
    foreach(string field in fieldArray) {

        if(!passportDict.ContainsKey(field) && field != "cid") {
            return false;
        }

        if(field == "byr") {
            if(!Int32.TryParse(passportDict[field], out int number) || passportDict[field].Length != 4 ||
                    (number < 1920 || number > 2002)) {
                return false;
            }
        }
        else if(field == "iyr") {
            if(!Int32.TryParse(passportDict[field], out int number) || passportDict[field].Length != 4 ||
                    (number < 2010 || number > 2020)) {
                return false;
            }
           
        }
        else if(field == "eyr") {
            if(!Int32.TryParse(passportDict[field], out int number) || passportDict[field].Length != 4 ||
                    (number < 2020 || number > 2030)) {
                return false;
            }
            
        }
        else if(field == "hgt") {
            string[] hgtArray = GetHgtSplit(passportDict[field]);
            if(!(hgtArray[1] == "cm" && Int32.TryParse(hgtArray[0], out int numberCm) && numberCm <= 193 && numberCm >= 150) &&
                    !(hgtArray[1] == "in" && Int32.TryParse(hgtArray[0], out int numberIn) && numberIn <= 76 && numberIn >= 59)) {
                        
                return false;
            } 
        }
        else if(field == "hcl") {
            if(passportDict[field][0] != '#') {
                return false;
            }

            string[] temp = passportDict[field].Split('#');

            if(temp[1].Length == 6 ) {
                var pattern = string.Format("[0-9a-f]", temp[1]);
                var r = new Regex(pattern);
                
                if(!r.IsMatch(temp[1])) {
                    return false;
                }
            }
            else {
                return false;
            }
        }
        else if(field == "ecl") {
            string[] eyeColors = new string[]{"amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
            if(!eyeColors.Contains<string>(passportDict[field])) {
                return false;
            }
        }
        else if(field == "pid") {
            if(passportDict[field].Length != 9 || !Int32.TryParse(passportDict[field], out int number)) {
                
                return false;
            }
            
        }
    }

    return true;
}

try {

    StreamReader sr = new StreamReader("./day4.txt");

    var lines = sr.ReadToEnd().Split("\n\n").Select(l => l.Trim());
    
    foreach(var line in lines) {
            string cleanedLine = line.Replace("\n", " ").Replace("\r", " ");
            if(isValidPassport(cleanedLine.Trim())) {

            validPassports++;
        }
    }

    Console.WriteLine("Answer: " + validPassports.ToString());

}

catch(Exception e) {
    Console.WriteLine("Exception: " + e);
}
finally {
    Console.WriteLine("Finished");
};