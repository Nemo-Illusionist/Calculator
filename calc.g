grammar calc;

options
{
	language = CSharp2;
}
@parser::namespace { Generated }
@lexer::namespace  { Generated }
@header{
	using System;
	using System.Collections;
}
@members{
	Hashtable memory = new Hashtable();
}

public calc	
	: statement+
	;

statement
	: expr NEWLINE { Console.WriteLine($expr.value); }
	| ID '=' expr NEWLINE { memory.Add($ID.text, $expr.value); }
	| NEWLINE
	;


expr returns[double value]	
	: ('-'me1=multExpression {$value -= me1;}| me1=multExpression {$value = me1;})
	('+' me2=multExpression {$value += $me2.value;}
	|'-' me2=multExpression {$value -= $me2.value;})*
	;

multExpression returns[double value]
	: a1=atom {$value = $a1.value;}
	('*' a2=atom {$value *= $a2.value;}
	|'/' a2=atom {$value /= $a2.value;})*
	;

atom returns[double value]
	: ID {$value = (double)memory[$ID.text];}
	| FLOAT {$value = double.Parse($FLOAT.text);}
	| '(' expr ')' {$value = $expr.value;}
	| '[' expr ']' {$value = Math.Abs($expr.value);}
	;

ID  :	('a'..'z'|'A'..'Z'|'_') ('a'..'z'|'A'..'Z'|'0'..'9'|'_')*
    ;

FLOAT
    :	('0'..'9')+ EXPONENT?
    |   ('0'..'9')+ SEPARATOR ('0'..'9')* EXPONENT?
    |   SEPARATOR ('0'..'9')+ EXPONENT?
    ;

fragment
SEPARATOR :('.'| ',');
fragment
EXPONENT: 'e' ('+'|'-')? ('0'..'9')+ ;

NEWLINE : '\r'? '\n';
