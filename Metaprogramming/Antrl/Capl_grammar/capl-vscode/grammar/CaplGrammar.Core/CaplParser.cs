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
using System.Diagnostics;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.9.2")]
[System.CLSCompliant(false)]
public partial class CaplParser : Parser {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, FLOAT=6, STRING=7, INT=8, ENUM=9, 
		FOR=10, ID=11, MUL=12, DIV=13, PLUS=14, MINUS=15, LINE_COMMENT=16, COMMENT=17, 
		LEFT_PAREN=18, RIGHT_PAREN=19, LEFT_BLOCK_PAREN=20, RIGHT_BLOCK_PAREN=21, 
		WS=22;
	public const int
		RULE_compilationUnit = 0, RULE_variableSection = 1, RULE_assignmentSet = 2, 
		RULE_assignmentExpr = 3, RULE_type = 4, RULE_expr = 5;
	public static readonly string[] ruleNames = {
		"compilationUnit", "variableSection", "assignmentSet", "assignmentExpr", 
		"type", "expr"
	};

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

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static CaplParser() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}

		public CaplParser(ITokenStream input) : this(input, Console.Out, Console.Error) { }

		public CaplParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	public partial class CompilationUnitContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public VariableSectionContext[] variableSection() {
			return GetRuleContexts<VariableSectionContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public VariableSectionContext variableSection(int i) {
			return GetRuleContext<VariableSectionContext>(i);
		}
		public CompilationUnitContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_compilationUnit; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			ICaplListener typedListener = listener as ICaplListener;
			if (typedListener != null) typedListener.EnterCompilationUnit(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			ICaplListener typedListener = listener as ICaplListener;
			if (typedListener != null) typedListener.ExitCompilationUnit(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICaplVisitor<TResult> typedVisitor = visitor as ICaplVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitCompilationUnit(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public CompilationUnitContext compilationUnit() {
		CompilationUnitContext _localctx = new CompilationUnitContext(Context, State);
		EnterRule(_localctx, 0, RULE_compilationUnit);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 15;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while (_la==T__0) {
				{
				{
				State = 12;
				variableSection();
				}
				}
				State = 17;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class VariableSectionContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode LEFT_BLOCK_PAREN() { return GetToken(CaplParser.LEFT_BLOCK_PAREN, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public AssignmentSetContext assignmentSet() {
			return GetRuleContext<AssignmentSetContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode RIGHT_BLOCK_PAREN() { return GetToken(CaplParser.RIGHT_BLOCK_PAREN, 0); }
		public VariableSectionContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_variableSection; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			ICaplListener typedListener = listener as ICaplListener;
			if (typedListener != null) typedListener.EnterVariableSection(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			ICaplListener typedListener = listener as ICaplListener;
			if (typedListener != null) typedListener.ExitVariableSection(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICaplVisitor<TResult> typedVisitor = visitor as ICaplVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitVariableSection(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public VariableSectionContext variableSection() {
		VariableSectionContext _localctx = new VariableSectionContext(Context, State);
		EnterRule(_localctx, 2, RULE_variableSection);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 18;
			Match(T__0);
			State = 19;
			Match(LEFT_BLOCK_PAREN);
			State = 20;
			assignmentSet();
			State = 21;
			Match(RIGHT_BLOCK_PAREN);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class AssignmentSetContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public AssignmentExprContext[] assignmentExpr() {
			return GetRuleContexts<AssignmentExprContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public AssignmentExprContext assignmentExpr(int i) {
			return GetRuleContext<AssignmentExprContext>(i);
		}
		public AssignmentSetContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_assignmentSet; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			ICaplListener typedListener = listener as ICaplListener;
			if (typedListener != null) typedListener.EnterAssignmentSet(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			ICaplListener typedListener = listener as ICaplListener;
			if (typedListener != null) typedListener.ExitAssignmentSet(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICaplVisitor<TResult> typedVisitor = visitor as ICaplVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitAssignmentSet(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public AssignmentSetContext assignmentSet() {
		AssignmentSetContext _localctx = new AssignmentSetContext(Context, State);
		EnterRule(_localctx, 4, RULE_assignmentSet);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 26;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while (_la==T__3 || _la==T__4) {
				{
				{
				State = 23;
				assignmentExpr();
				}
				}
				State = 28;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class AssignmentExprContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public TypeContext type() {
			return GetRuleContext<TypeContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode ID() { return GetToken(CaplParser.ID, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ExprContext expr() {
			return GetRuleContext<ExprContext>(0);
		}
		public AssignmentExprContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_assignmentExpr; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			ICaplListener typedListener = listener as ICaplListener;
			if (typedListener != null) typedListener.EnterAssignmentExpr(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			ICaplListener typedListener = listener as ICaplListener;
			if (typedListener != null) typedListener.ExitAssignmentExpr(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICaplVisitor<TResult> typedVisitor = visitor as ICaplVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitAssignmentExpr(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public AssignmentExprContext assignmentExpr() {
		AssignmentExprContext _localctx = new AssignmentExprContext(Context, State);
		EnterRule(_localctx, 6, RULE_assignmentExpr);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 29;
			type();
			State = 30;
			Match(ID);
			State = 33;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			if (_la==T__1) {
				{
				State = 31;
				Match(T__1);
				State = 32;
				expr(0);
				}
			}

			State = 35;
			Match(T__2);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class TypeContext : ParserRuleContext {
		public TypeContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_type; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			ICaplListener typedListener = listener as ICaplListener;
			if (typedListener != null) typedListener.EnterType(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			ICaplListener typedListener = listener as ICaplListener;
			if (typedListener != null) typedListener.ExitType(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICaplVisitor<TResult> typedVisitor = visitor as ICaplVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitType(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public TypeContext type() {
		TypeContext _localctx = new TypeContext(Context, State);
		EnterRule(_localctx, 8, RULE_type);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 37;
			_la = TokenStream.LA(1);
			if ( !(_la==T__3 || _la==T__4) ) {
			ErrorHandler.RecoverInline(this);
			}
			else {
				ErrorHandler.ReportMatch(this);
			    Consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ExprContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode LEFT_PAREN() { return GetToken(CaplParser.LEFT_PAREN, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ExprContext[] expr() {
			return GetRuleContexts<ExprContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public ExprContext expr(int i) {
			return GetRuleContext<ExprContext>(i);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode RIGHT_PAREN() { return GetToken(CaplParser.RIGHT_PAREN, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode ID() { return GetToken(CaplParser.ID, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode INT() { return GetToken(CaplParser.INT, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode FLOAT() { return GetToken(CaplParser.FLOAT, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode MUL() { return GetToken(CaplParser.MUL, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode DIV() { return GetToken(CaplParser.DIV, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode PLUS() { return GetToken(CaplParser.PLUS, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode MINUS() { return GetToken(CaplParser.MINUS, 0); }
		public ExprContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_expr; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			ICaplListener typedListener = listener as ICaplListener;
			if (typedListener != null) typedListener.EnterExpr(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			ICaplListener typedListener = listener as ICaplListener;
			if (typedListener != null) typedListener.ExitExpr(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICaplVisitor<TResult> typedVisitor = visitor as ICaplVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitExpr(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ExprContext expr() {
		return expr(0);
	}

	private ExprContext expr(int _p) {
		ParserRuleContext _parentctx = Context;
		int _parentState = State;
		ExprContext _localctx = new ExprContext(Context, _parentState);
		ExprContext _prevctx = _localctx;
		int _startState = 10;
		EnterRecursionRule(_localctx, 10, RULE_expr, _p);
		int _la;
		try {
			int _alt;
			EnterOuterAlt(_localctx, 1);
			{
			State = 47;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case LEFT_PAREN:
				{
				State = 40;
				Match(LEFT_PAREN);
				State = 41;
				expr(0);
				State = 42;
				Match(RIGHT_PAREN);
				}
				break;
			case ID:
				{
				State = 44;
				Match(ID);
				}
				break;
			case INT:
				{
				State = 45;
				Match(INT);
				}
				break;
			case FLOAT:
				{
				State = 46;
				Match(FLOAT);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			Context.Stop = TokenStream.LT(-1);
			State = 57;
			ErrorHandler.Sync(this);
			_alt = Interpreter.AdaptivePredict(TokenStream,5,Context);
			while ( _alt!=2 && _alt!=global::Antlr4.Runtime.Atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( ParseListeners!=null )
						TriggerExitRuleEvent();
					_prevctx = _localctx;
					{
					State = 55;
					ErrorHandler.Sync(this);
					switch ( Interpreter.AdaptivePredict(TokenStream,4,Context) ) {
					case 1:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						PushNewRecursionContext(_localctx, _startState, RULE_expr);
						State = 49;
						if (!(Precpred(Context, 6))) throw new FailedPredicateException(this, "Precpred(Context, 6)");
						State = 50;
						_la = TokenStream.LA(1);
						if ( !(_la==MUL || _la==DIV) ) {
						ErrorHandler.RecoverInline(this);
						}
						else {
							ErrorHandler.ReportMatch(this);
						    Consume();
						}
						State = 51;
						expr(7);
						}
						break;
					case 2:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						PushNewRecursionContext(_localctx, _startState, RULE_expr);
						State = 52;
						if (!(Precpred(Context, 5))) throw new FailedPredicateException(this, "Precpred(Context, 5)");
						State = 53;
						_la = TokenStream.LA(1);
						if ( !(_la==PLUS || _la==MINUS) ) {
						ErrorHandler.RecoverInline(this);
						}
						else {
							ErrorHandler.ReportMatch(this);
						    Consume();
						}
						State = 54;
						expr(6);
						}
						break;
					}
					} 
				}
				State = 59;
				ErrorHandler.Sync(this);
				_alt = Interpreter.AdaptivePredict(TokenStream,5,Context);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			UnrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	public override bool Sempred(RuleContext _localctx, int ruleIndex, int predIndex) {
		switch (ruleIndex) {
		case 5: return expr_sempred((ExprContext)_localctx, predIndex);
		}
		return true;
	}
	private bool expr_sempred(ExprContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0: return Precpred(Context, 6);
		case 1: return Precpred(Context, 5);
		}
		return true;
	}

	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x3', '\x18', '?', '\x4', '\x2', '\t', '\x2', '\x4', '\x3', 
		'\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', '\x5', '\x4', 
		'\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x3', '\x2', '\a', '\x2', 
		'\x10', '\n', '\x2', '\f', '\x2', '\xE', '\x2', '\x13', '\v', '\x2', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x4', '\a', '\x4', '\x1B', '\n', '\x4', '\f', '\x4', '\xE', '\x4', '\x1E', 
		'\v', '\x4', '\x3', '\x5', '\x3', '\x5', '\x3', '\x5', '\x3', '\x5', '\x5', 
		'\x5', '$', '\n', '\x5', '\x3', '\x5', '\x3', '\x5', '\x3', '\x6', '\x3', 
		'\x6', '\x3', '\a', '\x3', '\a', '\x3', '\a', '\x3', '\a', '\x3', '\a', 
		'\x3', '\a', '\x3', '\a', '\x3', '\a', '\x5', '\a', '\x32', '\n', '\a', 
		'\x3', '\a', '\x3', '\a', '\x3', '\a', '\x3', '\a', '\x3', '\a', '\x3', 
		'\a', '\a', '\a', ':', '\n', '\a', '\f', '\a', '\xE', '\a', '=', '\v', 
		'\a', '\x3', '\a', '\x2', '\x3', '\f', '\b', '\x2', '\x4', '\x6', '\b', 
		'\n', '\f', '\x2', '\x5', '\x3', '\x2', '\x6', '\a', '\x3', '\x2', '\xE', 
		'\xF', '\x3', '\x2', '\x10', '\x11', '\x2', '@', '\x2', '\x11', '\x3', 
		'\x2', '\x2', '\x2', '\x4', '\x14', '\x3', '\x2', '\x2', '\x2', '\x6', 
		'\x1C', '\x3', '\x2', '\x2', '\x2', '\b', '\x1F', '\x3', '\x2', '\x2', 
		'\x2', '\n', '\'', '\x3', '\x2', '\x2', '\x2', '\f', '\x31', '\x3', '\x2', 
		'\x2', '\x2', '\xE', '\x10', '\x5', '\x4', '\x3', '\x2', '\xF', '\xE', 
		'\x3', '\x2', '\x2', '\x2', '\x10', '\x13', '\x3', '\x2', '\x2', '\x2', 
		'\x11', '\xF', '\x3', '\x2', '\x2', '\x2', '\x11', '\x12', '\x3', '\x2', 
		'\x2', '\x2', '\x12', '\x3', '\x3', '\x2', '\x2', '\x2', '\x13', '\x11', 
		'\x3', '\x2', '\x2', '\x2', '\x14', '\x15', '\a', '\x3', '\x2', '\x2', 
		'\x15', '\x16', '\a', '\x16', '\x2', '\x2', '\x16', '\x17', '\x5', '\x6', 
		'\x4', '\x2', '\x17', '\x18', '\a', '\x17', '\x2', '\x2', '\x18', '\x5', 
		'\x3', '\x2', '\x2', '\x2', '\x19', '\x1B', '\x5', '\b', '\x5', '\x2', 
		'\x1A', '\x19', '\x3', '\x2', '\x2', '\x2', '\x1B', '\x1E', '\x3', '\x2', 
		'\x2', '\x2', '\x1C', '\x1A', '\x3', '\x2', '\x2', '\x2', '\x1C', '\x1D', 
		'\x3', '\x2', '\x2', '\x2', '\x1D', '\a', '\x3', '\x2', '\x2', '\x2', 
		'\x1E', '\x1C', '\x3', '\x2', '\x2', '\x2', '\x1F', ' ', '\x5', '\n', 
		'\x6', '\x2', ' ', '#', '\a', '\r', '\x2', '\x2', '!', '\"', '\a', '\x4', 
		'\x2', '\x2', '\"', '$', '\x5', '\f', '\a', '\x2', '#', '!', '\x3', '\x2', 
		'\x2', '\x2', '#', '$', '\x3', '\x2', '\x2', '\x2', '$', '%', '\x3', '\x2', 
		'\x2', '\x2', '%', '&', '\a', '\x5', '\x2', '\x2', '&', '\t', '\x3', '\x2', 
		'\x2', '\x2', '\'', '(', '\t', '\x2', '\x2', '\x2', '(', '\v', '\x3', 
		'\x2', '\x2', '\x2', ')', '*', '\b', '\a', '\x1', '\x2', '*', '+', '\a', 
		'\x14', '\x2', '\x2', '+', ',', '\x5', '\f', '\a', '\x2', ',', '-', '\a', 
		'\x15', '\x2', '\x2', '-', '\x32', '\x3', '\x2', '\x2', '\x2', '.', '\x32', 
		'\a', '\r', '\x2', '\x2', '/', '\x32', '\a', '\n', '\x2', '\x2', '\x30', 
		'\x32', '\a', '\b', '\x2', '\x2', '\x31', ')', '\x3', '\x2', '\x2', '\x2', 
		'\x31', '.', '\x3', '\x2', '\x2', '\x2', '\x31', '/', '\x3', '\x2', '\x2', 
		'\x2', '\x31', '\x30', '\x3', '\x2', '\x2', '\x2', '\x32', ';', '\x3', 
		'\x2', '\x2', '\x2', '\x33', '\x34', '\f', '\b', '\x2', '\x2', '\x34', 
		'\x35', '\t', '\x3', '\x2', '\x2', '\x35', ':', '\x5', '\f', '\a', '\t', 
		'\x36', '\x37', '\f', '\a', '\x2', '\x2', '\x37', '\x38', '\t', '\x4', 
		'\x2', '\x2', '\x38', ':', '\x5', '\f', '\a', '\b', '\x39', '\x33', '\x3', 
		'\x2', '\x2', '\x2', '\x39', '\x36', '\x3', '\x2', '\x2', '\x2', ':', 
		'=', '\x3', '\x2', '\x2', '\x2', ';', '\x39', '\x3', '\x2', '\x2', '\x2', 
		';', '<', '\x3', '\x2', '\x2', '\x2', '<', '\r', '\x3', '\x2', '\x2', 
		'\x2', '=', ';', '\x3', '\x2', '\x2', '\x2', '\b', '\x11', '\x1C', '#', 
		'\x31', '\x39', ';',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
} // namespace CaplGrammar.Core