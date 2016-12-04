grammar GrammarOfArithmetic;

options
{
	language = CSharp2;
}
@parser::namespace { Generated }
@lexer::namespace  { Generated }

public calc	
	: statement+
	;

statement
	: expr NEWLINE
	| ID '=' expr NEWLINE
	| NEWLINE
	;
	
expr
	: multExpression 
	('+' multExpression 
	|'-' multExpression)*
	;

multExpression
	: a1=atom ('*' a2=atom | '/' a2=atom)*
	;
	
atom
	: ID
	| INT
	| '(' expr ')'
	;

ID  :	('a'..'z'|'A'..'Z'|'_') ('a'..'z'|'A'..'Z'|'0'..'9'|'_')*
    ;

INT :	'0'..'9'+
    ;

FLOAT
    :   ('0'..'9')+ '.' ('0'..'9')* EXPONENT?
    |   '.' ('0'..'9')+ EXPONENT?
    |   ('0'..'9')+ EXPONENT
    ;

fragment
EXPONENT : ('e'|'E') ('+'|'-')? ('0'..'9')+ ;

NEWLINE : '\r'? '\n'
	;

