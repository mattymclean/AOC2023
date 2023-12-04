using AOC2023Day1;
using BenchmarkDotNet.Running;

//BenchmarkRunner.Run<ParserBenchmarks>();
//return;

//
// SPAN-Y WAY
//

var spanParser = new SpanParser();
var numSum = spanParser.Lines.Sum(spanParser.GetFirstLastDigitNum);
Console.WriteLine("Answer: {0}", numSum);

//
// REGEX
//

var regexParser = new RegExParser();
numSum = regexParser.Lines.Sum(regexParser.GetFirstLastDigitNum);
Console.WriteLine("Answer: {0}", numSum);


