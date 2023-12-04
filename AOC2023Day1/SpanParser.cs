using System.Buffers;
using System.Text;

namespace AOC2023Day1;

public class SpanParser : Parser
{
    private static readonly SearchValues<char> SearchValues = System.Buffers.SearchValues.Create(NumberString);

    public int GetFirstLastDigitNum(string text)
    {
        var textSpan = text.AsSpan();
        var first = GetChar(textSpan, true);
        var last = GetChar(textSpan, false);

        var num = int.Parse(GetFastString(first, last));
        //Console.WriteLine("{0} = {1}", textSpan.ToString(), num);
        return num;
    }

    private char GetChar(ReadOnlySpan<char> textSpan, bool isFirst)
    {
        char? firstDigitChar = null;
    
        var firstDigitIndex = isFirst
            ? textSpan.IndexOfAny(SearchValues)
            : textSpan.LastIndexOfAny(SearchValues);

        int? matchedTextDigitIndex = null;
        foreach (var textNumber in TextNumbers.Keys)
        {
            var firstTextDigitIndex = isFirst
                ? textSpan.IndexOf(textNumber)
                : textSpan.LastIndexOf(textNumber);

            if (firstTextDigitIndex <= -1
                || (!matchedTextDigitIndex.HasValue || isFirst
                    ? firstTextDigitIndex >= matchedTextDigitIndex
                    : firstTextDigitIndex <= matchedTextDigitIndex)
                || (isFirst
                    ? firstTextDigitIndex >= firstDigitIndex
                    : firstTextDigitIndex <= firstDigitIndex)) continue;
        
            firstDigitChar = TextNumbers[textNumber];
            matchedTextDigitIndex = firstTextDigitIndex;
        }
    
        firstDigitChar ??= textSpan[firstDigitIndex];
    
        return firstDigitChar.Value;
    }
    
    private string GetFastString(char firstDigit, char secondDigit)
    {
        var sb = new StringBuilder(2);
        sb.Append(firstDigit);
        sb.Append(secondDigit);
        return sb.ToString();
    }
}