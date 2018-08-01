using System;

public static class Bob
{
    public static bool containsLetter(string statement) {
        for (int i=0;i<statement.Length;i++){
            if(Char.IsLetter(statement[i])) {
                return true;
            }
        }
        return false;
    }

    public static bool isWhiteSpace(string statement) {
        for(int i=0;i<statement.Length;i++) {
            if(!(Char.IsWhiteSpace(statement[i]))){
                return false;
            }
        }
        return true;
    }

    public static bool isShouting(string statement) {
        if (statement.ToUpper()==statement && !(isQuestion(statement) || isForcefulQuestion(statement)) && containsLetter(statement))  {
            return true;
        }
        else {
            return false;
        }
    }

    public static bool isQuestion(string statement) {
        if(statement.EndsWith("?") && containsLetter(statement)) {
            if (!(statement.ToUpper()==statement)) {
                return true;
            }
            else {
                return false;
            }
        }
        else if (statement.EndsWith("?")) {
            return true;
        }
        else {
            return false;
        }
    }

    public static bool isForcefulQuestion(string statement) {
        if(statement.EndsWith("?") && statement.ToUpper()==statement && containsLetter(statement)) {
            return true;
        }
        else {
            return false;
        }
    }

    public static string Response(string statement)
    {
        string trim = statement.Trim();
        if(isShouting(trim)){
            return "Whoa, chill out!";
        }
        else if (isQuestion(trim)){
            return "Sure.";
        }
        else if(isForcefulQuestion(statement)) {
            return "Calm down, I know what I'm doing!";
        }
        else if(isWhiteSpace(statement)){
            return "Fine. Be that way!";
        }
        else {
            return "Whatever.";
        }
    }
}