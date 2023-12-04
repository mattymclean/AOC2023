using System.Text;
using System.Text.RegularExpressions;

namespace AOC2023Day1;

public class RegExParser : Parser
{
    private Regex _rxLeft = new("(one)|(two)|(three)|(four)|(five)|(six)|(seven)|(eight)|(nine)|[0-9]", 
        RegexOptions.Compiled);
    
    private Regex _rxRight = new("(one)|(two)|(three)|(four)|(five)|(six)|(seven)|(eight)|(nine)|[0-9]", 
        RegexOptions.Compiled | RegexOptions.RightToLeft);
    
    public int GetFirstLastDigitNum(string text)
    {
        var firstMatch = _rxLeft.Match(text).ToString();
        var firstDigit = !TextNumbers.TryGetValue(firstMatch, out var v1) ? firstMatch.First() : v1;
        
        var lastMatch = _rxRight.Match(text).ToString();
        var lastDigit = !TextNumbers.TryGetValue(lastMatch, out var v2) ? lastMatch.First() : v2;
    
        var num = int.Parse(GetFastString(firstDigit, lastDigit));
        //Console.WriteLine("{0} = {1}", text, num);
        return num;
    }
    
    private string GetFastString(char firstDigit, char secondDigit)
    {
        var sb = new StringBuilder(2);
        sb.Append(firstDigit);
        sb.Append(secondDigit);
        return sb.ToString();
    }
}