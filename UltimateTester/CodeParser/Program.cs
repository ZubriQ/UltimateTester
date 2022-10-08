using Antlr4.Runtime;
using CodeParser.ANTLR4;

// Run test.
var filePath = "ANTLR4\\CSharpTest1.txt";
var fileContent = File.ReadAllText(filePath);
Console.WriteLine(fileContent);

var inputStream = new AntlrInputStream(fileContent);
var cSharpLexer = new CSharpLexer(inputStream);
var commonTokenStream = new CommonTokenStream(cSharpLexer);
var cSharpParser = new CSharpParser(commonTokenStream);
var tokens = cSharpLexer.GetAllTokens();
foreach(var token in tokens) {
    Console.Write($"{token.Type} {token.Text}");
}
//var programContext = cSharpParser.program();
//var visitor = new CSharpVisitor();
//visitor.Visit(programContext);