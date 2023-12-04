using System.Collections.Immutable;

namespace AOC2023Day1;

public class Parser
{
    public readonly string[] Lines;
   
    protected const string NumberString = "123456789";

    protected readonly IReadOnlyDictionary<string, char> TextNumbers = new Dictionary<string, char>()
    {
        {"one", '1'},
        {"two", '2'},
        {"three", '3'},
        {"four", '4'},
        {"five", '5'},
        {"six", '6'},
        {"seven", '7'},
        {"eight", '8'},
        {"nine", '9'},
    };

    protected Parser()
    {
        Lines = File.ReadAllLines("input.txt");
    }
}