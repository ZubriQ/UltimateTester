using Antlr4.Runtime;
using CodeParser;
using CodeParser.ANTLR4;
using CodeParser.ZhangShasha;
using System.Diagnostics;

// Test.
Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));

Tree tree1 = SetUpTestTree("ANTLR4\\CSharpTest2.txt");
Tree tree2 = SetUpTestTree("ANTLR4\\CSharpTest3.txt");

var (distance, list) = Tree.ZhangShasha(tree1, tree2);
OutputResult(distance);

Tree SetUpTestTree(string codeFilePath)
{
    Trace.WriteLine("\t[Input 1]:");
    var fileContent = File.ReadAllText(codeFilePath);
    Trace.WriteLine(fileContent + "\n");
    Tree tree1 = TreeFactory.ConstructTreeFromString(fileContent);
    return tree1;
}

void OutputResult(int distance)
{
    Trace.WriteLine("\n\t[Output]:");
    Trace.WriteLine("Distance = " + distance);
    foreach (var o in list)
    {
        Trace.WriteLine(o.O.ToString() + " " + o.N1 + " => " + o.N2);
    }
}

// Для Токенов
//var inputStream = new AntlrInputStream(fileContent);
//var cSharpLexer = new CSharpLexer(inputStream);
//var commonTokenStream = new CommonTokenStream(cSharpLexer);
//var cSharpParser = new CSharpParser(commonTokenStream);
//var tokens = cSharpLexer.GetAllTokens();
//var programContext = CSharpParser.;
//var visitor = new CSharpVisitor();
//visitor.Visit(cSharpParser);
//foreach (var token in tokens) {
//    Console.Write($"{token.Type} {token.Text}");
//}

Console.ReadLine();