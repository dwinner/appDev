//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.9.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from Capl.g4 by ANTLR 4.9.2

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace CaplGrammar.Core {
using System;
using System.IO;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.9.2")]
[System.CLSCompliant(false)]
public partial class CaplLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, FLOAT=6, STRING=7, INT=8, ENUM=9, 
		FOR=10, ID=11, MUL=12, DIV=13, PLUS=14, MINUS=15, LINE_COMMENT=16, COMMENT=17, 
		LEFT_PAREN=18, RIGHT_PAREN=19, LEFT_BLOCK_PAREN=20, RIGHT_BLOCK_PAREN=21, 
		WS=22;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"T__0", "T__1", "T__2", "T__3", "T__4", "FLOAT", "STRING", "ESC", "INT", 
		"DIGIT", "ENUM", "FOR", "ID", "ID_LETTER", "MUL", "DIV", "PLUS", "MINUS", 
		"LINE_COMMENT", "COMMENT", "LEFT_PAREN", "RIGHT_PAREN", "LEFT_BLOCK_PAREN", 
		"RIGHT_BLOCK_PAREN", "WS"
	};


	public CaplLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public CaplLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "'variables'", "'='", "';'", "'int'", "'float'", null, null, null, 
		"'enum'", "'for'", null, "'*'", "'/'", "'+'", "'-'", null, null, "'('", 
		"')'", "'{'", "'}'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, "FLOAT", "STRING", "INT", "ENUM", 
		"FOR", "ID", "MUL", "DIV", "PLUS", "MINUS", "LINE_COMMENT", "COMMENT", 
		"LEFT_PAREN", "RIGHT_PAREN", "LEFT_BLOCK_PAREN", "RIGHT_BLOCK_PAREN", 
		"WS"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "Capl.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static CaplLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x2', '\x18', '\xB7', '\b', '\x1', '\x4', '\x2', '\t', '\x2', 
		'\x4', '\x3', '\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', 
		'\x5', '\x4', '\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x4', '\b', 
		'\t', '\b', '\x4', '\t', '\t', '\t', '\x4', '\n', '\t', '\n', '\x4', '\v', 
		'\t', '\v', '\x4', '\f', '\t', '\f', '\x4', '\r', '\t', '\r', '\x4', '\xE', 
		'\t', '\xE', '\x4', '\xF', '\t', '\xF', '\x4', '\x10', '\t', '\x10', '\x4', 
		'\x11', '\t', '\x11', '\x4', '\x12', '\t', '\x12', '\x4', '\x13', '\t', 
		'\x13', '\x4', '\x14', '\t', '\x14', '\x4', '\x15', '\t', '\x15', '\x4', 
		'\x16', '\t', '\x16', '\x4', '\x17', '\t', '\x17', '\x4', '\x18', '\t', 
		'\x18', '\x4', '\x19', '\t', '\x19', '\x4', '\x1A', '\t', '\x1A', '\x3', 
		'\x2', '\x3', '\x2', '\x3', '\x2', '\x3', '\x2', '\x3', '\x2', '\x3', 
		'\x2', '\x3', '\x2', '\x3', '\x2', '\x3', '\x2', '\x3', '\x2', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x4', '\x3', '\x4', '\x3', '\x5', '\x3', 
		'\x5', '\x3', '\x5', '\x3', '\x5', '\x3', '\x6', '\x3', '\x6', '\x3', 
		'\x6', '\x3', '\x6', '\x3', '\x6', '\x3', '\x6', '\x3', '\a', '\x6', '\a', 
		'O', '\n', '\a', '\r', '\a', '\xE', '\a', 'P', '\x3', '\a', '\x3', '\a', 
		'\a', '\a', 'U', '\n', '\a', '\f', '\a', '\xE', '\a', 'X', '\v', '\a', 
		'\x5', '\a', 'Z', '\n', '\a', '\x3', '\b', '\x3', '\b', '\x3', '\b', '\a', 
		'\b', '_', '\n', '\b', '\f', '\b', '\xE', '\b', '\x62', '\v', '\b', '\x3', 
		'\b', '\x3', '\b', '\x3', '\t', '\x3', '\t', '\x3', '\t', '\x3', '\n', 
		'\x6', '\n', 'j', '\n', '\n', '\r', '\n', '\xE', '\n', 'k', '\x3', '\v', 
		'\x3', '\v', '\x3', '\f', '\x3', '\f', '\x3', '\f', '\x3', '\f', '\x3', 
		'\f', '\x3', '\r', '\x3', '\r', '\x3', '\r', '\x3', '\r', '\x3', '\xE', 
		'\x3', '\xE', '\x3', '\xE', '\a', '\xE', '|', '\n', '\xE', '\f', '\xE', 
		'\xE', '\xE', '\x7F', '\v', '\xE', '\x3', '\xF', '\x3', '\xF', '\x3', 
		'\x10', '\x3', '\x10', '\x3', '\x11', '\x3', '\x11', '\x3', '\x12', '\x3', 
		'\x12', '\x3', '\x13', '\x3', '\x13', '\x3', '\x14', '\x3', '\x14', '\x3', 
		'\x14', '\x3', '\x14', '\a', '\x14', '\x8F', '\n', '\x14', '\f', '\x14', 
		'\xE', '\x14', '\x92', '\v', '\x14', '\x3', '\x14', '\x5', '\x14', '\x95', 
		'\n', '\x14', '\x3', '\x14', '\x3', '\x14', '\x3', '\x14', '\x3', '\x14', 
		'\x3', '\x15', '\x3', '\x15', '\x3', '\x15', '\x3', '\x15', '\a', '\x15', 
		'\x9F', '\n', '\x15', '\f', '\x15', '\xE', '\x15', '\xA2', '\v', '\x15', 
		'\x3', '\x15', '\x3', '\x15', '\x3', '\x15', '\x3', '\x15', '\x3', '\x15', 
		'\x3', '\x16', '\x3', '\x16', '\x3', '\x17', '\x3', '\x17', '\x3', '\x18', 
		'\x3', '\x18', '\x3', '\x19', '\x3', '\x19', '\x3', '\x1A', '\x6', '\x1A', 
		'\xB2', '\n', '\x1A', '\r', '\x1A', '\xE', '\x1A', '\xB3', '\x3', '\x1A', 
		'\x3', '\x1A', '\x5', '`', '\x90', '\xA0', '\x2', '\x1B', '\x3', '\x3', 
		'\x5', '\x4', '\a', '\x5', '\t', '\x6', '\v', '\a', '\r', '\b', '\xF', 
		'\t', '\x11', '\x2', '\x13', '\n', '\x15', '\x2', '\x17', '\v', '\x19', 
		'\f', '\x1B', '\r', '\x1D', '\x2', '\x1F', '\xE', '!', '\xF', '#', '\x10', 
		'%', '\x11', '\'', '\x12', ')', '\x13', '+', '\x14', '-', '\x15', '/', 
		'\x16', '\x31', '\x17', '\x33', '\x18', '\x3', '\x2', '\x6', '\b', '\x2', 
		'$', '$', '^', '^', '\x64', '\x64', 'p', 'p', 't', 't', 'v', 'v', '\x3', 
		'\x2', '\x32', ';', '\x5', '\x2', '\x43', '\\', '\x61', '\x61', '\x63', 
		'|', '\x5', '\x2', '\v', '\f', '\xF', '\xF', '\"', '\"', '\x2', '\xBF', 
		'\x2', '\x3', '\x3', '\x2', '\x2', '\x2', '\x2', '\x5', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\a', '\x3', '\x2', '\x2', '\x2', '\x2', '\t', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\v', '\x3', '\x2', '\x2', '\x2', '\x2', '\r', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\xF', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\x13', '\x3', '\x2', '\x2', '\x2', '\x2', '\x17', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\x19', '\x3', '\x2', '\x2', '\x2', '\x2', '\x1B', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\x1F', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '!', '\x3', '\x2', '\x2', '\x2', '\x2', '#', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '%', '\x3', '\x2', '\x2', '\x2', '\x2', '\'', '\x3', '\x2', 
		'\x2', '\x2', '\x2', ')', '\x3', '\x2', '\x2', '\x2', '\x2', '+', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '-', '\x3', '\x2', '\x2', '\x2', '\x2', '/', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\x31', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\x33', '\x3', '\x2', '\x2', '\x2', '\x3', '\x35', '\x3', '\x2', 
		'\x2', '\x2', '\x5', '?', '\x3', '\x2', '\x2', '\x2', '\a', '\x41', '\x3', 
		'\x2', '\x2', '\x2', '\t', '\x43', '\x3', '\x2', '\x2', '\x2', '\v', 'G', 
		'\x3', '\x2', '\x2', '\x2', '\r', 'N', '\x3', '\x2', '\x2', '\x2', '\xF', 
		'[', '\x3', '\x2', '\x2', '\x2', '\x11', '\x65', '\x3', '\x2', '\x2', 
		'\x2', '\x13', 'i', '\x3', '\x2', '\x2', '\x2', '\x15', 'm', '\x3', '\x2', 
		'\x2', '\x2', '\x17', 'o', '\x3', '\x2', '\x2', '\x2', '\x19', 't', '\x3', 
		'\x2', '\x2', '\x2', '\x1B', 'x', '\x3', '\x2', '\x2', '\x2', '\x1D', 
		'\x80', '\x3', '\x2', '\x2', '\x2', '\x1F', '\x82', '\x3', '\x2', '\x2', 
		'\x2', '!', '\x84', '\x3', '\x2', '\x2', '\x2', '#', '\x86', '\x3', '\x2', 
		'\x2', '\x2', '%', '\x88', '\x3', '\x2', '\x2', '\x2', '\'', '\x8A', '\x3', 
		'\x2', '\x2', '\x2', ')', '\x9A', '\x3', '\x2', '\x2', '\x2', '+', '\xA8', 
		'\x3', '\x2', '\x2', '\x2', '-', '\xAA', '\x3', '\x2', '\x2', '\x2', '/', 
		'\xAC', '\x3', '\x2', '\x2', '\x2', '\x31', '\xAE', '\x3', '\x2', '\x2', 
		'\x2', '\x33', '\xB1', '\x3', '\x2', '\x2', '\x2', '\x35', '\x36', '\a', 
		'x', '\x2', '\x2', '\x36', '\x37', '\a', '\x63', '\x2', '\x2', '\x37', 
		'\x38', '\a', 't', '\x2', '\x2', '\x38', '\x39', '\a', 'k', '\x2', '\x2', 
		'\x39', ':', '\a', '\x63', '\x2', '\x2', ':', ';', '\a', '\x64', '\x2', 
		'\x2', ';', '<', '\a', 'n', '\x2', '\x2', '<', '=', '\a', 'g', '\x2', 
		'\x2', '=', '>', '\a', 'u', '\x2', '\x2', '>', '\x4', '\x3', '\x2', '\x2', 
		'\x2', '?', '@', '\a', '?', '\x2', '\x2', '@', '\x6', '\x3', '\x2', '\x2', 
		'\x2', '\x41', '\x42', '\a', '=', '\x2', '\x2', '\x42', '\b', '\x3', '\x2', 
		'\x2', '\x2', '\x43', '\x44', '\a', 'k', '\x2', '\x2', '\x44', '\x45', 
		'\a', 'p', '\x2', '\x2', '\x45', '\x46', '\a', 'v', '\x2', '\x2', '\x46', 
		'\n', '\x3', '\x2', '\x2', '\x2', 'G', 'H', '\a', 'h', '\x2', '\x2', 'H', 
		'I', '\a', 'n', '\x2', '\x2', 'I', 'J', '\a', 'q', '\x2', '\x2', 'J', 
		'K', '\a', '\x63', '\x2', '\x2', 'K', 'L', '\a', 'v', '\x2', '\x2', 'L', 
		'\f', '\x3', '\x2', '\x2', '\x2', 'M', 'O', '\x5', '\x15', '\v', '\x2', 
		'N', 'M', '\x3', '\x2', '\x2', '\x2', 'O', 'P', '\x3', '\x2', '\x2', '\x2', 
		'P', 'N', '\x3', '\x2', '\x2', '\x2', 'P', 'Q', '\x3', '\x2', '\x2', '\x2', 
		'Q', 'Y', '\x3', '\x2', '\x2', '\x2', 'R', 'V', '\a', '\x30', '\x2', '\x2', 
		'S', 'U', '\x5', '\x15', '\v', '\x2', 'T', 'S', '\x3', '\x2', '\x2', '\x2', 
		'U', 'X', '\x3', '\x2', '\x2', '\x2', 'V', 'T', '\x3', '\x2', '\x2', '\x2', 
		'V', 'W', '\x3', '\x2', '\x2', '\x2', 'W', 'Z', '\x3', '\x2', '\x2', '\x2', 
		'X', 'V', '\x3', '\x2', '\x2', '\x2', 'Y', 'R', '\x3', '\x2', '\x2', '\x2', 
		'Y', 'Z', '\x3', '\x2', '\x2', '\x2', 'Z', '\xE', '\x3', '\x2', '\x2', 
		'\x2', '[', '`', '\a', '$', '\x2', '\x2', '\\', '_', '\x5', '\x11', '\t', 
		'\x2', ']', '_', '\v', '\x2', '\x2', '\x2', '^', '\\', '\x3', '\x2', '\x2', 
		'\x2', '^', ']', '\x3', '\x2', '\x2', '\x2', '_', '\x62', '\x3', '\x2', 
		'\x2', '\x2', '`', '\x61', '\x3', '\x2', '\x2', '\x2', '`', '^', '\x3', 
		'\x2', '\x2', '\x2', '\x61', '\x63', '\x3', '\x2', '\x2', '\x2', '\x62', 
		'`', '\x3', '\x2', '\x2', '\x2', '\x63', '\x64', '\a', '$', '\x2', '\x2', 
		'\x64', '\x10', '\x3', '\x2', '\x2', '\x2', '\x65', '\x66', '\a', '^', 
		'\x2', '\x2', '\x66', 'g', '\t', '\x2', '\x2', '\x2', 'g', '\x12', '\x3', 
		'\x2', '\x2', '\x2', 'h', 'j', '\x5', '\x15', '\v', '\x2', 'i', 'h', '\x3', 
		'\x2', '\x2', '\x2', 'j', 'k', '\x3', '\x2', '\x2', '\x2', 'k', 'i', '\x3', 
		'\x2', '\x2', '\x2', 'k', 'l', '\x3', '\x2', '\x2', '\x2', 'l', '\x14', 
		'\x3', '\x2', '\x2', '\x2', 'm', 'n', '\t', '\x3', '\x2', '\x2', 'n', 
		'\x16', '\x3', '\x2', '\x2', '\x2', 'o', 'p', '\a', 'g', '\x2', '\x2', 
		'p', 'q', '\a', 'p', '\x2', '\x2', 'q', 'r', '\a', 'w', '\x2', '\x2', 
		'r', 's', '\a', 'o', '\x2', '\x2', 's', '\x18', '\x3', '\x2', '\x2', '\x2', 
		't', 'u', '\a', 'h', '\x2', '\x2', 'u', 'v', '\a', 'q', '\x2', '\x2', 
		'v', 'w', '\a', 't', '\x2', '\x2', 'w', '\x1A', '\x3', '\x2', '\x2', '\x2', 
		'x', '}', '\x5', '\x1D', '\xF', '\x2', 'y', '|', '\x5', '\x1D', '\xF', 
		'\x2', 'z', '|', '\x5', '\x15', '\v', '\x2', '{', 'y', '\x3', '\x2', '\x2', 
		'\x2', '{', 'z', '\x3', '\x2', '\x2', '\x2', '|', '\x7F', '\x3', '\x2', 
		'\x2', '\x2', '}', '{', '\x3', '\x2', '\x2', '\x2', '}', '~', '\x3', '\x2', 
		'\x2', '\x2', '~', '\x1C', '\x3', '\x2', '\x2', '\x2', '\x7F', '}', '\x3', 
		'\x2', '\x2', '\x2', '\x80', '\x81', '\t', '\x4', '\x2', '\x2', '\x81', 
		'\x1E', '\x3', '\x2', '\x2', '\x2', '\x82', '\x83', '\a', ',', '\x2', 
		'\x2', '\x83', ' ', '\x3', '\x2', '\x2', '\x2', '\x84', '\x85', '\a', 
		'\x31', '\x2', '\x2', '\x85', '\"', '\x3', '\x2', '\x2', '\x2', '\x86', 
		'\x87', '\a', '-', '\x2', '\x2', '\x87', '$', '\x3', '\x2', '\x2', '\x2', 
		'\x88', '\x89', '\a', '/', '\x2', '\x2', '\x89', '&', '\x3', '\x2', '\x2', 
		'\x2', '\x8A', '\x8B', '\a', '\x31', '\x2', '\x2', '\x8B', '\x8C', '\a', 
		'\x31', '\x2', '\x2', '\x8C', '\x90', '\x3', '\x2', '\x2', '\x2', '\x8D', 
		'\x8F', '\v', '\x2', '\x2', '\x2', '\x8E', '\x8D', '\x3', '\x2', '\x2', 
		'\x2', '\x8F', '\x92', '\x3', '\x2', '\x2', '\x2', '\x90', '\x91', '\x3', 
		'\x2', '\x2', '\x2', '\x90', '\x8E', '\x3', '\x2', '\x2', '\x2', '\x91', 
		'\x94', '\x3', '\x2', '\x2', '\x2', '\x92', '\x90', '\x3', '\x2', '\x2', 
		'\x2', '\x93', '\x95', '\a', '\xF', '\x2', '\x2', '\x94', '\x93', '\x3', 
		'\x2', '\x2', '\x2', '\x94', '\x95', '\x3', '\x2', '\x2', '\x2', '\x95', 
		'\x96', '\x3', '\x2', '\x2', '\x2', '\x96', '\x97', '\a', '\f', '\x2', 
		'\x2', '\x97', '\x98', '\x3', '\x2', '\x2', '\x2', '\x98', '\x99', '\b', 
		'\x14', '\x2', '\x2', '\x99', '(', '\x3', '\x2', '\x2', '\x2', '\x9A', 
		'\x9B', '\a', '\x31', '\x2', '\x2', '\x9B', '\x9C', '\a', ',', '\x2', 
		'\x2', '\x9C', '\xA0', '\x3', '\x2', '\x2', '\x2', '\x9D', '\x9F', '\v', 
		'\x2', '\x2', '\x2', '\x9E', '\x9D', '\x3', '\x2', '\x2', '\x2', '\x9F', 
		'\xA2', '\x3', '\x2', '\x2', '\x2', '\xA0', '\xA1', '\x3', '\x2', '\x2', 
		'\x2', '\xA0', '\x9E', '\x3', '\x2', '\x2', '\x2', '\xA1', '\xA3', '\x3', 
		'\x2', '\x2', '\x2', '\xA2', '\xA0', '\x3', '\x2', '\x2', '\x2', '\xA3', 
		'\xA4', '\a', ',', '\x2', '\x2', '\xA4', '\xA5', '\a', '\x31', '\x2', 
		'\x2', '\xA5', '\xA6', '\x3', '\x2', '\x2', '\x2', '\xA6', '\xA7', '\b', 
		'\x15', '\x2', '\x2', '\xA7', '*', '\x3', '\x2', '\x2', '\x2', '\xA8', 
		'\xA9', '\a', '*', '\x2', '\x2', '\xA9', ',', '\x3', '\x2', '\x2', '\x2', 
		'\xAA', '\xAB', '\a', '+', '\x2', '\x2', '\xAB', '.', '\x3', '\x2', '\x2', 
		'\x2', '\xAC', '\xAD', '\a', '}', '\x2', '\x2', '\xAD', '\x30', '\x3', 
		'\x2', '\x2', '\x2', '\xAE', '\xAF', '\a', '\x7F', '\x2', '\x2', '\xAF', 
		'\x32', '\x3', '\x2', '\x2', '\x2', '\xB0', '\xB2', '\t', '\x5', '\x2', 
		'\x2', '\xB1', '\xB0', '\x3', '\x2', '\x2', '\x2', '\xB2', '\xB3', '\x3', 
		'\x2', '\x2', '\x2', '\xB3', '\xB1', '\x3', '\x2', '\x2', '\x2', '\xB3', 
		'\xB4', '\x3', '\x2', '\x2', '\x2', '\xB4', '\xB5', '\x3', '\x2', '\x2', 
		'\x2', '\xB5', '\xB6', '\b', '\x1A', '\x2', '\x2', '\xB6', '\x34', '\x3', 
		'\x2', '\x2', '\x2', '\xF', '\x2', 'P', 'V', 'Y', '^', '`', 'k', '{', 
		'}', '\x90', '\x94', '\xA0', '\xB3', '\x3', '\b', '\x2', '\x2',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
} // namespace CaplGrammar.Core