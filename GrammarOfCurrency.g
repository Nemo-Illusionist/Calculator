grammar GrammarOfCurrency;

options
{
	language = CSharp2;
}
@parser::namespace { Generated }
@lexer::namespace  { Generated }
@header{
	using System;
	using System.Collections;
	using Currencies;
}


public calc returns[string value]
	:  statement {$value = $statement.value;}
	;

statement returns[string value]
	: a1 = expr 
	('=' ID {$a1.value.Convert($ID.text); $value = $a1.value.ToString();} 
	| ('=' {$value = " = ";})? {$value += $a1.value.ToString();}
	) NEWLINE 
	| NEWLINE
	;
	
expr returns[Cur value]	
	: ('-'me1=multExpression {$value = -me1;} 
		| me1=multExpression {$value = me1;})
	('+' me2=multExpression {$value += $me2.value;}
	|'-' me2=multExpression {$value -= $me2.value;})*
	;

multExpression returns[Cur value]
	: a1=atom {$value = $a1.value;}
	('*' a2=atom {$value *= $a2.value;}
		|('/'|':') a2=atom {$value /= $a2.value;}
	)*
	;

atom returns[Cur value]
	: CURRENCY {$value = new Cur($CURRENCY.text);}
	| FLOAT {$value = new Cur(double.Parse($FLOAT.text));}
	| ('(' a1 = expr ')'| '{' a1 = expr '}') 
		{$value = $a1.value;}
	;


ID  :	'a'..'z' 'a'..'z' 'a'..'z'
    ;

CURRENCY: FLOAT ID;

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
