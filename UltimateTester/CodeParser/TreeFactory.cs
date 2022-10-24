using Antlr4.Runtime;
using CodeParser.ANTLR4;
using CodeParser.ZhangShasha;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeParser
{
    internal class TreeFactory
    {
        public static Tree ConstructTreeFromString(string cSharpCode)
        {
			var str = new AntlrInputStream(cSharpCode.Trim());
			var lexer = new CSharpLexer(str);
			var tokens = new CommonTokenStream(lexer);
			var parser = new CSharpParser(tokens);
			var tree = parser.compilation_unit();
			var visitor = new TreeConverterVisitor();
			var root = visitor.Visit(tree);
			return new Tree(root);
		}
	}
}
