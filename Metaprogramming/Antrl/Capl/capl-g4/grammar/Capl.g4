/** 
 * CAPL grammar implementation.
 */

grammar Capl;

/* Capl parser */

primaryExpression
    :	Identifier
    |	AccessToSignalIdentifier
    |	SysvarIdentifier
	|	Constant
	|	StringLiteral+
	|	'(' expression ')'
	|	'(' compoundStatement ')'
	| 	( includeBlock
	    	| variableBlock
			| eventBlock
			| timerBlock
			| errorFrame
			| envBlock
			| functionDefinition
			| enumSpecifier
			| structSpecifier
			| startBlock
			| messageBlock
			| multiplexedMessageBlock
			| stopMeasurement
			| diagRequestBlock
			| diagResponseBlock
			| signalBlock
			| sysvarBlock
			| externalDeclaration
		)+
	;

includeBlock
    :	'includes' '{' IncludeDirective* '}'
    ;

startBlock
    :	'on' 'start' '{' blockItemList? '}'
    ;

variableBlock
    :	'variables' '{' blockItemList? '}'
    ;

eventBlock
    :	'on' keyEventType '{' blockItemList '}'
    ;

timerBlock
    :	'on' timerType '{' blockItemList '}'
    ;

errorFrame
    : 	'on' 'errorFrame' '{' blockItemList? '}'
    ;

messageBlock
    :	'on' messageType '{' blockItemList '}'
    ;

multiplexedMessageBlock
    :	'on' multiplexedMessageType '{' blockItemList '}'
    ;

diagRequestBlock
    :	'on' diagRequestType '{' blockItemList '}'
    ;

diagResponseBlock
    :	'on' diagResponseType '{' blockItemList '}'
    ;

signalBlock
    :	'on' signalType '{' blockItemList '}'
    ;

sysvarBlock
    :	'on' sysvarType '{' blockItemList '}'
    ;

stopMeasurement
    :	'on' 'stopMeasurement' '{' blockItemList '}'
    ;

envBlock
    :	'on' 'envVar' Identifier '{' blockItemList '}'
    ;

postfixExpression
    :	(primaryExpression
			| '(' typeName ')' '{' initializerList ','? '}'
		)
		('[' expression ']'
			| '(' argumentExpressionList? ')'
			| ('++' | '--')
		)*
	;

argumentExpressionList
    :	assignmentExpression (',' assignmentExpression)*
    ;

unaryExpression
    :	('++' | '--')* (postfixExpression | unaryOperator castExpression)
    ;

unaryOperator
    :	'+' | '-' | '~' | '!'
    ;

castExpression
    :	'(' typeName ')' castExpression
	|	unaryExpression
	|	DigitSequence // for
	;

multiplicativeExpression
    :	castExpression (('*' | '/' | '%') castExpression)*
    ;

additiveExpression
    :	multiplicativeExpression (('+' | '-') multiplicativeExpression)*
	;

shiftExpression
    :	additiveExpression (('<<' | '>>') additiveExpression)*
    ;

relationalExpression
    :	shiftExpression (('<' | '>' | '<=' | '>=') shiftExpression)*
    ;

equalityExpression
    :	relationalExpression (('==' | '!=') relationalExpression)*
    ;

andExpression
    :	equalityExpression ( '&' equalityExpression)*
    ;

exclusiveOrExpression
    :	andExpression ('^' andExpression)*
    ;

inclusiveOrExpression
    :	exclusiveOrExpression ('|' exclusiveOrExpression)*
    ;

logicalAndExpression
    :	inclusiveOrExpression ('&&' inclusiveOrExpression)*
    ;

logicalOrExpression
    :	logicalAndExpression ('||' logicalAndExpression)*
    ;

conditionalExpression
    :	logicalOrExpression ('?' expression ':' conditionalExpression)?
	;

assignmentExpression
    :	conditionalExpression
	|	unaryExpression assignmentOperator assignmentExpression
	|	DigitSequence // for
	;

assignmentOperator
    :	'='
	|	'*='
	|	'/='
	|	'%='
	|	'+='
	|	'-='
	|	'<<='
	|	'>>='
	|	'&='
	|	'^='
	|	'|='
	;

expression
    :	assignmentExpression (',' assignmentExpression)*
    ;

constantExpression
    :	conditionalExpression
    ;

declaration
    :	declarationSpecifiers initDeclaratorList? ';'
    ;

declarationSpecifiers
    :	declarationSpecifier+
    ;

declarationSpecifiers2
    :	declarationSpecifier+
    ;

typeQualifier
	:	'const'
	;

functionSpecifier
    :	'testfunction'
    |	('export')? 'testcase'
    ;

declarationSpecifier
    :	typeSpecifier
    |	typeQualifier
    |	functionSpecifier
    ;

initDeclaratorList
    :	initDeclarator (',' initDeclarator)*
    ;

initDeclarator
    :	declarator ('=' initializer)?
    ;

typeSpecifier
    : 	('void'
	|	'char'
	|	'byte'
	|	'int'
	|	'long'
	|	'int64'
	|	'float'
	|	'double'
	|	'word'
	|	'dword'
	|	'qword'
	|	'timer'
	|	'msTimer'
	|	structSpecifier
	|	enumSpecifier
	|	messageType
	|	multiplexedMessageType
	|	diagRequestType
	|	diagResponseType
	|	signalType
	|	sysvarType)
	;

structSpecifier
    :	structure Identifier? '{' structDeclarationList '}'
    |	structure Identifier
    ;

structure
    :	'struct'
    ;

structDeclarationList
    :	structDeclaration+
    ;

structDeclaration
    :	specifierQualifierList structDeclaratorList? ';'
    ;

specifierQualifierList
    :	(typeSpecifier | typeQualifier) specifierQualifierList?
    ;

structDeclaratorList
    :	structDeclarator (',' structDeclarator)*
    ;

structDeclarator
    :	declarator
    |	declarator? ':' constantExpression
    ;

declarator
    :	directDeclarator
    ;

directDeclarator
    :	Identifier
	|	'(' declarator ')'
	|	directDeclarator '[' assignmentExpression? ']'
	|	directDeclarator '(' parameterTypeList ')'
	|	directDeclarator '(' identifierList? ')'
	;

nestedParenthesesBlock
    :	(~('(' | ')') | '(' nestedParenthesesBlock ')')*
	;

parameterTypeList
    :	parameterList (',' '...')?
    ;

parameterList
    :	parameterDeclaration (',' parameterDeclaration)*
    ;

parameterDeclaration
    :	declarationSpecifiers declarator
	|	declarationSpecifiers2 abstractDeclarator?
	;

identifierList
    :	Identifier (',' Identifier)*
    ;

typeName
    :	specifierQualifierList abstractDeclarator?
    ;

abstractDeclarator
    :	directAbstractDeclarator
    ;

directAbstractDeclarator
    :	'(' abstractDeclarator ')'
	|	'[' assignmentExpression? ']'
	|	'[' '*' ']'
	|	'(' parameterTypeList? ')'
	|	directAbstractDeclarator '[' assignmentExpression? ']'
	|	directAbstractDeclarator '[' '*' ']'
	|	directAbstractDeclarator '(' parameterTypeList? ')'
	;

initializer
    :	assignmentExpression
	|	'{' initializerList ','? '}'
	;

initializerList
    :	designation? initializer (',' designation? initializer)*
    ;

designation
    :	designatorList '='
    ;

designatorList
    :	designator+
    ;

designator
    :	'[' constantExpression ']'
    ;

statement
    :	labeledStatement
	|	compoundStatement
	|	expressionStatement
	|	selectionStatement
	|	iterationStatement
	|	jumpStatement
	;

labeledStatement
    :	Identifier ':' statement
	|	'case' (constantExpression) ':' statement
	|	'default' ':' statement
	;

compoundStatement
    :	'{' blockItemList? '}'
    ;

blockItemList
    :	blockItem+
    ;

blockItem
    :	statement | declaration
    ;

expressionStatement
    :	expression? ';'
    ;

selectionStatement
    :	'if' '(' expression ')' statement ('else' statement)?
	|	'switch' '(' expression ')' statement
	;

iterationStatement
    :	While '(' expression ')' statement
	|	Do statement While '(' expression ')' ';'
	|	For '(' forCondition ')' statement
	;

forCondition
    :	(forDeclaration | expression?) ';' forExpression? ';' forExpression?
    ;

forDeclaration
    :	declarationSpecifiers initDeclaratorList?
    ;

forExpression
    :	assignmentExpression (',' assignmentExpression)*
    ;

jumpStatement
    :	(('continue' | 'break') | 'return' expression?) ';'
    ;

compilationUnit
	:	translationUnit? EOF
	;

translationUnit
	:	externalDeclaration+
	;

externalDeclaration
    :	functionDefinition
	|	declaration
	|	';' // stray ;
	;

functionDefinition
    :	declarationSpecifiers? declarator declarationList? compoundStatement
    ;

declarationList
	:	declaration+
	;

/* Capl lexer */

Export : 'export';
Testcase : 'testcase';
Testfunction : 'testfunction';
Includes : 'includes';
Const : 'const';
StopMeasurement : 'stopMeasurement';
Start : 'start';
ErrorFrame : 'errorFrame';
On : 'on';
Variables : 'variables';
Break : 'break';
Case : 'case';
Char : 'char';
Byte : 'byte';
Continue : 'continue';
Default : 'default';
Do : 'do';
Double : 'double';
Else : 'else';
Float : 'float';
For : 'for';
If : 'if';
Int : 'int';
Word : 'word';
Dword : 'dword';
Qword : 'qword';
EnvVar : 'envVar';
MsTimer : 'msTimer';
Long : 'long';
Int64 : 'int64';
Return : 'return';
Switch : 'switch';
Void : 'void';
While : 'while';
Struct : 'struct';

LeftParen : '(';
RightParen : ')';
LeftBracket : '[';
RightBracket : ']';
LeftBrace : '{';
RightBrace : '}';
Less : '<';
LessEqual : '<=';
Greater : '>';
GreaterEqual : '>=';
LeftShift : '<<';
RightShift : '>>';
Plus : '+';
PlusPlus : '++';
Minus : '-';
MinusMinus : '--';
Div : '/';
Mod : '%';
And : '&';
Or : '|';
AndAnd : '&&';
OrOr : '||';
Caret : '^';
Not : '!';
Tilde : '~';
Question : '?';
Colon : ':';
Semi : ';';
Comma : ',';
Assign : '=';
StarAssign : '*=';
DivAssign : '/=';
ModAssign : '%=';
PlusAssign : '+=';
MinusAssign : '-=';
LeftShiftAssign : '<<=';
RightShiftAssign : '>>=';
AndAssign : '&=';
XorAssign : '^=';
OrAssign : '|=';
Star : '*';
Equal : '==';
NotEqual : '!=';
Ellipsis : '...';

enumSpecifier
    :   'enum' Identifier? '{' enumeratorList ','? '}' ';'?
    |   'enum' Identifier
    ;

enumeratorList
    :   enumerator (',' enumerator)*
    ;

enumerator
    :   enumerationConstant ('=' constantExpression)?
    ;

enumerationConstant
    :   Identifier
    ;

Enum : 'enum';

timerType
    :	'timer' Identifier ('.' (Identifier | '*'))?
    ;

Timer : 'timer';

messageType
    :	'message' Identifier ('.' (Identifier | '*'))?
	|	'message' '*'
	|	'message' Constant
	|	'message' Identifier '-' Identifier
	;

Message : 'message';

multiplexedMessageType
    :	'multiplexed_message' Identifier ('.' (Identifier | '*'))?
	|	'multiplexed_message' '*'
	|	'multiplexed_message' Constant
	|	'multiplexed_message' Identifier '-' Identifier
	;

MultiplexedMessage : 'multiplexed_message';

diagRequestType
    :	'diagRequest' Identifier (('.'|'::') (Identifier | '*'))?
	|	'diagRequest' '*'
	|	'diagRequest' Constant
	|	'diagRequest' Identifier '-' Identifier
	;

DiagRequest : 'diagRequest';

diagResponseType
    :	'diagResponse' Identifier (('.'|'::') (Identifier | '*'))?
	|	'diagResponse' '*'
	|	'diagResponse' Constant
	|	'diagResponse' Identifier '-' Identifier
	;

DiagResponse : 'diagResponse';

signalType
    :	'signal' Identifier (('.'|'::') (Identifier | '*'))?
	|	'signal' '*'
	|	'signal' Constant
	|	'signal' Identifier '-' Identifier
	;

Signal : 'signal';

sysvarType
    :	'sysvar sysvar' '::' Identifier ('::' Identifier)*
	;

keyEventType
    :	'key' Constant
	|	'key' (
			'F1'
		|	'F2'
		|	'F3'
		|	'F4'
		|	'F5'
		|	'F6'
		|	'F7'
		|	'F8'
		|	'F9'
		|	'F10'
		|	'F11'
		|	'F12'
		|	'ctrlF1'
		|	'ctrlF2'
		|	'ctrlF3'
		|	'ctrlF4'
		|	'ctrlF5'
		|	'ctrlF6'
		|	'ctrlF7'
		|	'ctrlF8'
		|	'ctrlF9'
		|	'ctrlF10'
		|	'ctrlF11'
		|	'ctrlF12'
		|	'PageUp'
		|	'PageDown'
		|	'Home')
	|	'key' '*'
	;

Key : 'key';
F1 : 'F1';
F2 : 'F2';
F3 : 'F3';
F4 : 'F4';
F5 : 'F5';
F6 : 'F6';
F7 : 'F7';
F8 : 'F8';
F9 : 'F9';
F10 : 'F10';
F11 : 'F11';
F12 : 'F12';
CtrlF1 : 'ctrlF1';
CtrlF2 : 'ctrlF2';
CtrlF3 : 'ctrlF3';
CtrlF4 : 'ctrlF4';
CtrlF5 : 'ctrlF5';
CtrlF6 : 'ctrlF6';
CtrlF7 : 'ctrlF7';
CtrlF8 : 'ctrlF8';
CtrlF9 : 'ctrlF9';
CtrlF10 : 'ctrlF10';
CtrlF11 : 'ctrlF11';
CtrlF12 : 'ctrlF12';
PageUp : 'PageUp';
PageDown : 'PageDown';
Home : 'Home';

Identifier
    :	IdentifierNondigit (IdentifierNondigit | Digit)*
	|	(('this' | IdentifierNondigit) (IdentifierNondigit | Digit)*) '.' Identifier ('.' (Identifier))*
	|	IdentifierNondigit (IdentifierNondigit | Digit)* '.' Constant
	;

This : 'this';
Dot : '.';

AccessToSignalIdentifier
    :	'$' Identifier ('phys'|'raw'|'raw64'|'rx'|'txrq')?
    ;

Dollar : '$';
Phys : 'phys';
Raw : 'raw';
Raw64 : 'raw64';
Rx : 'rx';
RxRequest : 'txrq';

SysvarIdentifier
    :	'@' 'sysvar' '::' Identifier ('::' Identifier)*
    ;

Sysvar : 'sysvar';
DoubleColon : '::';
AtSign : '@';
DoubleSysvar : 'sysvar sysvar';

fragment IdentifierNondigit: Nondigit | UniversalCharacterName;

fragment Nondigit: [a-zA-Z_];

fragment Digit: [0-9];

fragment UniversalCharacterName:
	'\\u' HexQuad
	| '\\U' HexQuad HexQuad;

fragment HexQuad:
	HexadecimalDigit HexadecimalDigit HexadecimalDigit HexadecimalDigit;

Constant
	:	IntegerConstant
	|	FloatingConstant
	|	CharacterConstant
	;

fragment IntegerConstant
	:	DecimalConstant IntegerSuffix?
	|	OctalConstant IntegerSuffix?
	|	HexadecimalConstant IntegerSuffix?
	|	BinaryConstant
	;

fragment BinaryConstant: '0' [bB] [0-1]+;

fragment DecimalConstant: NonzeroDigit Digit*;

fragment OctalConstant: '0' OctalDigit*;

fragment HexadecimalConstant: HexadecimalPrefix HexadecimalDigit+;

fragment HexadecimalPrefix: '0' [xX];

fragment NonzeroDigit: [1-9];

fragment OctalDigit: [0-7];

fragment HexadecimalDigit: [0-9a-fA-F];

fragment IntegerSuffix: LongSuffix | LongLongSuffix;

fragment LongSuffix: [lL];

fragment LongLongSuffix: 'll' | 'LL';

fragment FloatingConstant
	:	DecimalFloatingConstant
	|	HexadecimalFloatingConstant
	;

fragment DecimalFloatingConstant
	:	FractionalConstant ExponentPart? FloatingSuffix?
	|	DigitSequence ExponentPart FloatingSuffix?;

fragment HexadecimalFloatingConstant
	:	HexadecimalPrefix (
			HexadecimalFractionalConstant
			| HexadecimalDigitSequence
		) BinaryExponentPart FloatingSuffix?
	;

fragment FractionalConstant
	:	DigitSequence? '.' DigitSequence
	|	DigitSequence '.'
	;

fragment ExponentPart: [eE] Sign? DigitSequence;

fragment Sign: [+-];

DigitSequence : Digit+;

fragment HexadecimalFractionalConstant
	:	HexadecimalDigitSequence? '.' HexadecimalDigitSequence
	|	HexadecimalDigitSequence '.'
	;

fragment BinaryExponentPart: [pP] Sign? DigitSequence;

fragment HexadecimalDigitSequence: HexadecimalDigit+;

fragment FloatingSuffix: [flFL];

fragment CharacterConstant
	:	'\'' CCharSequence '\''
	|	'L\'' CCharSequence '\''
	|	'u\'' CCharSequence '\''
	|	'U\'' CCharSequence '\''
	;

fragment CCharSequence: CChar+;

fragment CChar: ~['\\\r\n] | EscapeSequence;

fragment EscapeSequence
	:	SimpleEscapeSequence
	|	OctalEscapeSequence
	|	HexadecimalEscapeSequence
	|	UniversalCharacterName
	;

fragment SimpleEscapeSequence: '\\' ['"?abfnrtv\\];

fragment OctalEscapeSequence: '\\' OctalDigit OctalDigit? OctalDigit?;

fragment HexadecimalEscapeSequence: '\\x' HexadecimalDigit+;

StringLiteral: EncodingPrefix? '"' SCharSequence? '"';

fragment EncodingPrefix: 'u8' | 'u' | 'U' | 'L';

fragment SCharSequence: SChar+;

fragment SChar
	:	~["\\\r\n]
	|	EscapeSequence
	|	'\\\n' // Added line
	|	'\\\r\n' // Added line
	;

IncludeDirective
	: '#' Whitespace? 'include' Whitespace? (
		('"' ~[\r\n]* '"')
		| ('<' ~[\r\n]* '>')
	) Whitespace? Newline -> channel(HIDDEN);

Whitespace : [ \t]+ -> skip;

Newline : ( '\r' '\n'? | '\n') -> skip;

BlockComment : '/*' .*? '*/' -> skip;

LineComment : '//' ~[\r\n]* -> skip;