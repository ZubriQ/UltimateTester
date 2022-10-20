﻿using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using CodeParser.ANTLR4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeParser.ZhangShasha
{
    internal class Tree
    {
		Node _root;
		// function l() which gives the Leftmost Leaf for a given node (identified by post-order number).
		Dictionary<int, int> _leftmostLeaf = new Dictionary<int, int>();
		// list of keyroots for a tree root, i.e., nodes with a left sibling, or in the case of the root, the root itself.
		List<int> _keyroots = new List<int>();
		// list of the labels of the nodes used for node comparison.
		Dictionary<int, string> _labels = new Dictionary<int, string>();

		public Tree() 
		{

		}

		public Tree(string cSharpCode)
		{
			var str = new AntlrInputStream(cSharpCode.Trim());
			var lexer = new CSharpLexer(str);
			var tokens = new CommonTokenStream(lexer);
			var parser = new CSharpParser(tokens);
			var tree = parser.compilation_unit();
			var visitor = new CSharpVisitor();
			//_root = visitor.Visit(tree);
			visitor.Visit(tree);
		}

		public void Traverse()
		{
			// put together an ordered list of node labels of the tree
			Traverse(_root, _labels);
		}

		private static Dictionary<int, string> Traverse(Node node, Dictionary<int, string> labels)
		{
			for (int i = 0; i < node.Children.Count; i++)
			{
				labels = Traverse(node.Children[i], labels);
			}
			labels.Add(node.PostorderNumber, node.Label);
			return labels;
		}

		public void ComputePostOrderNumber()
		{
			// index each node in the tree according to traversal method
			ComputePostOrderNumber(_root, 0);
		}

		private static int ComputePostOrderNumber(Node node, int index)
		{
			for (int i = 0; i < node.Children.Count; i++)
			{
				index = ComputePostOrderNumber(node.Children[i], index);
			}
			index++;
			node.PostorderNumber = index;
			return index;
		}

		public void ComputeLeftMostLeaf()
		{
			// put together a function which gives l()
			Leftmost();
			var z = new Dictionary<int, int>();
			_leftmostLeaf = ComputeLeftMostLeaf(_root, z);
		}

		private Dictionary<int, int> ComputeLeftMostLeaf(Node node, Dictionary<int, int> l)
		{
			for (int i = 0; i < node.Children.Count; i++)
			{
				l = ComputeLeftMostLeaf(node.Children[i], l);
			}
			l.Add(node.PostorderNumber, node.Leftmost.PostorderNumber);
			return l;
		}

		private void Leftmost()
		{
			Leftmost(_root);
		}

		private static void Leftmost(Node node)
		{
			if (node == null)
				return;
			for (int i = 0; i < node.Children.Count; i++)
			{
				Leftmost(node.Children[i]);
			}
			if (node.Children.Count == 0)
			{
				node.Leftmost = node;
			}
			else
			{
				node.Leftmost = node.Children[0].Leftmost;
			}
		}

		public void Keyroots()
		{
			// calculate the keyroots
			for (int i = 1; i <= _leftmostLeaf.Count; i++)
			{
				int flag = 0;
				for (int j = i + 1; j <= _leftmostLeaf.Count; j++)
				{
					if (_leftmostLeaf[j] == _leftmostLeaf[i])
					{
						flag = 1;
					}
				}
				if (flag == 0)
				{
					this._keyroots.Add(i);
				}
			}
		}

		static int[,] tree_distance;
		static List<Operation>[,] tree_operations;

		public static (int, List<Operation>) ZhangShasha(Tree tree1, Tree tree2)
		{
			tree1.ComputePostOrderNumber();
			tree1.ComputeLeftMostLeaf();
			tree1.Keyroots();
			tree1.Traverse();

			tree2.ComputePostOrderNumber();
			tree2.ComputeLeftMostLeaf();
			tree2.Keyroots();
			tree2.Traverse();

			Dictionary<int, int> l1 = tree1._leftmostLeaf;
			List<int> keyroots1 = tree1._keyroots;
			Dictionary<int, int> l2 = tree2._leftmostLeaf;
			List<int> keyroots2 = tree2._keyroots;

			// space complexity of the algorithm
			tree_distance = new int[l1.Count + 1, l2.Count + 1];
			tree_operations = new List<Operation>[l1.Count + 1, l2.Count + 1];
			for (int m = 0; m <= l1.Count; ++m)
				for (int n = 0; n <= l2.Count; ++n)
					tree_operations[m, n] = new List<Operation>();

			// solve subproblems
			for (int i1 = 1; i1 <= keyroots1.Count; i1++)
			{
				for (int j1 = 1; j1 <= keyroots2.Count; j1++)
				{
					int i = keyroots1[i1 - 1];
					int j = keyroots2[j1 - 1];
					Treedist(l1, l2, i, j, tree1, tree2);
				}
			}

			return (tree_distance[l1.Count, l2.Count], tree_operations[l1.Count, l2.Count]);
		}

		private static void Treedist(Dictionary<int, int> l1, Dictionary<int, int> l2, int i, int j, Tree tree1, Tree tree2)
		{
			int[,] forest_distance = new int[l1.Count + 1, l2.Count + 1];
			List<Operation>[,] forest_operations = new List<Operation>[l1.Count + 1, l2.Count + 1];
			for (int m = 0; m < l1.Count + 1; ++m)
				for (int n = 0; n < l2.Count + 1; ++n)
					forest_operations[m, n] = new List<Operation>();

			// costs of the three atomic operations
			int Delete = 1;
			int Insert = 1;
			int Relabel = 1;

			for (int i1 = l1[i]; i1 <= i; i1++)
			{
				forest_distance[i1, 0] = forest_distance[i1 - 1, 0] + Delete;
				forest_operations[i1, 0] = new List<Operation>(forest_operations[i1 - 1, 0]);
				forest_operations[i1, 0].Add(new Operation() { O = Operation.Op.Delete, N1 = i1 });
			}
			for (int j1 = l2[j]; j1 <= j; j1++)
			{
				forest_distance[0, j1] = forest_distance[0, j1 - 1] + Insert;
				forest_operations[0, j1] = new List<Operation>(forest_operations[0, j1 - 1]);
				forest_operations[0, j1].Add(new Operation() { O = Operation.Op.Insert, N2 = j1 });
			}
			for (int i1 = l1[i]; i1 <= i; i1++)
			{
				for (int j1 = l2[j]; j1 <= j; j1++)
				{
					if (l1[i1] == l1[i] && l2[j1] == l2[j])
					{
						var z = i1 - 1 < l1[i] ? 0 : i1 - 1;
						var z2 = j1 - 1 < l2[j] ? 0 : j1 - 1;
						var i_temp = forest_distance[z, j1] + Delete;
						var i_list = new List<Operation>(forest_operations[z, j1]);
						i_list.Add(new Operation() { O = Operation.Op.Delete, N1 = i1 });
						var i_op = i_list;

						var j_temp = forest_distance[i1, z2] + Insert;
						var j_list = new List<Operation>(forest_operations[i1, z2]);
						j_list.Add(new Operation() { O = Operation.Op.Insert, N2 = j1 });
						var j_op = j_list;

						var cost = tree1._labels[i1] == tree2._labels[j1] ? 0 : Relabel;
						var k_temp = forest_distance[z, z2] + cost;
						var k_list = new List<Operation>(forest_operations[z, z2]);
						if (cost != 0)
							k_list.Add(new Operation() { O = Operation.Op.Change, N1 = i1, N2 = j1 });
						var k_op = k_list;

						if (i_temp < j_temp)
						{
							if (i_temp < k_temp)
							{
								forest_distance[i1, j1] = i_temp;
								forest_operations[i1, j1] = i_op;
							}
							else
							{
								forest_distance[i1, j1] = k_temp;
								forest_operations[i1, j1] = k_op;
							}
						}
						else
						{
							if (j_temp < k_temp)
							{
								forest_distance[i1, j1] = j_temp;
								forest_operations[i1, j1] = j_op;
							}
							else
							{
								forest_distance[i1, j1] = k_temp;
								forest_operations[i1, j1] = k_op;
							}
						}

						tree_distance[i1, j1] = forest_distance[i1, j1];
						tree_operations[i1, j1] = forest_operations[i1, j1];
					}
					else
					{
						var z = i1 - 1 < l1[i] ? 0 : i1 - 1;
						var z2 = j1 - 1 < l2[j] ? 0 : j1 - 1;
						var i_temp = forest_distance[z, j1] + Delete;
						var i_list = new List<Operation>(forest_operations[z, j1]);
						i_list.Add(new Operation() { O = Operation.Op.Delete, N1 = i1 });
						var i_op = i_list;

						var j_temp = forest_distance[i1, z2] + Insert;
						var j_list = new List<Operation>(forest_operations[i1, z2]);
						j_list.Add(new Operation() { O = Operation.Op.Insert, N2 = j1 });
						var j_op = j_list;

						var k_temp = forest_distance[z, z2] + tree_distance[i1, j1];
						var k_list = new List<Operation>(forest_operations[z, z2]);
						k_list.AddRange(tree_operations[i1, j1]);
						var k_op = k_list;

						if (i_temp < j_temp)
						{
							if (i_temp < k_temp)
							{
								forest_distance[i1, j1] = i_temp;
								forest_operations[i1, j1] = i_op;
							}
							else
							{
								forest_distance[i1, j1] = k_temp;
								forest_operations[i1, j1] = k_op;
							}
						}
						else
						{
							if (j_temp < k_temp)
							{
								forest_distance[i1, j1] = j_temp;
								forest_operations[i1, j1] = j_op;
							}
							else
							{
								forest_distance[i1, j1] = k_temp;
								forest_operations[i1, j1] = k_op;
							}
						}
					}
				}
			}

			tree_distance[i, j] = forest_distance[i, j];
			tree_operations[i, j] = forest_operations[i, j];

			System.Console.WriteLine("====");
			System.Console.WriteLine("i = " + i + " j = " + j);
			System.Console.WriteLine("forest_distance");
			for (int m = 0; m < l1.Count + 1; ++m)
			{
				for (int n = 0; n < l2.Count + 1; ++n)
				{
					System.Console.Write(" " + forest_distance[m, n]);
				}
				System.Console.WriteLine();
			}
			System.Console.WriteLine();
			System.Console.WriteLine("forest_operations");
			for (int m = 0; m < l1.Count + 1; ++m)
			{
				for (int n = 0; n < l2.Count + 1; ++n)
				{
					System.Console.Write(" " + String.Join(",", forest_operations[m, n].Select(o => (o.O == Operation.Op.Change ? "C" : o.O == Operation.Op.Delete ? "D" : "I") + o.N1 + "->" + o.N2)));
				}
				System.Console.WriteLine();
			}
			System.Console.WriteLine();
			System.Console.WriteLine("tree_distance");
			for (int m = 0; m < l1.Count + 1; ++m)
			{
				for (int n = 0; n < l2.Count + 1; ++n)
				{
					System.Console.Write(" " + tree_distance[m, n]);
				}
				System.Console.WriteLine();
			}
			System.Console.WriteLine();
			System.Console.WriteLine("tree_operations");
			for (int m = 0; m < l1.Count + 1; ++m)
			{
				for (int n = 0; n < l2.Count + 1; ++n)
				{
					System.Console.Write(" " + String.Join(",", tree_operations[m, n].Select(o => (o.O == Operation.Op.Change ? "C" : o.O == Operation.Op.Delete ? "D" : "I") + o.N1 + "->" + o.N2)));
				}
				System.Console.WriteLine();
			}
		}
	}
}
