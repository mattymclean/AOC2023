using BenchmarkDotNet.Attributes;

namespace AOC2023Day1;

[MemoryDiagnoser(true)] 
[RankColumn]
public class ParserBenchmarks
{
    private SpanParser _spanParser = new();
    private RegExParser _regExParser = new();
    
    [Params("9eighthvxnlvthqjtpsjnleightwokq", "3ninehgveightzppzljfourfour4", "tmht6mfjnnpznrv6jscqfjxkvtgklmprsix", "94rj2")]
    public string TestText { get; set; } 
    
    [Benchmark]
    public int GetFirstLastNum_Span()
    {
        return _spanParser.GetFirstLastDigitNum(TestText);
    }

    [Benchmark]
    public int GetFirstLastNum_Regex()
    {
        return _regExParser.GetFirstLastDigitNum(TestText);
    }
}

