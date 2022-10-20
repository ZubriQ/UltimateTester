using Antlr4.Runtime;
using CodeParser.ANTLR4;
using CodeParser.ZhangShasha;

// Run test.
Console.WriteLine("\t[Input]:");
var filePath = "ANTLR4\\CSharpTest1.txt";
var fileContent = File.ReadAllText(filePath);
Console.WriteLine(fileContent);
Console.WriteLine("\n\t[Output]:");

Tree tree = new Tree(fileContent);

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