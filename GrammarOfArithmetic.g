grammar GrammarOfArithmetic;

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

public calc returns[double value]	
	: addition NEWLINE { $value = $expr.value; }
	;
		
addition returns[double value]	
	: m1=multiplication {$value = $m1;}
	('+' m2=multiplication {$value += $m2.value;}
	|'-' m2=multiplication {$value -= $m2.value;})*
	;

multiplication returns[double value]
	: a1=atom {$value = $a1.value;}
	('*' a2=atom {$value *= $a2.value;}
	|'/' a2=atom {$value /= $a2.value;})*
	;
	
atom returns[double value]
	: exponentiationFanc {$value = $exponentiationFanc.value;}
	| trigonometryFanc {$value = $trigonometryFanc.value;}
	| bracket '!' {
                    double factorial = 1;
                    for (int i = 1; i <= $bracket.value; i++){
                        factorial *= i;
                    }
                $valu = factorial;
                }
        | bracket {$value = $bracket.value; }
	;

bracket	returns[double value]
	: FLOAT {$value = double.Parse($FLOAT.text);}
	| '(' addition ')' {$value = $addition.value);}
	| '[' addition ']' {$value = Math.Abs($addition.value);}
	;

exponentiationFanc returns[double value]
	: EXP {$value = Math.E;}
	| a1 = bracket '^' a2 = bracket {$value = Math.Pow($a1.value, $a2.value);} 
	| LOG '(' a1 = addition ', ' a2 = addition ')' {$value = Math.Log($a1.value, $a2.value);}
	| LN '(' addition ')' {$value = Math.Log($addition.value);}
	;

trigonometryFanc returns[double value]
	: Pi  {$value = Math.Pi;}
	| SIN '(' addition ')' {$value = Math.Sin($addition.value);}
	| COS '(' addition ')' {$value = Math.Cos($addition.value);}
	| TG '(' addition ')' {$value = Math.Tan($addition.value);}
	| CTG '(' addition ')' {$value = 1.0/Math.Tan($addition.value);}
	;


FLOAT
    :	('0'..'9')+ EXPONENT?
    |   ('0'..'9')+ SEPARATOR ('0'..'9')* EXPONENT?
    |   SEPARATOR ('0'..'9')+ EXPONENT?
    ;

fragment
SEPARATOR :('.'| ',');
fragment
EXPONENT: EXP ('+'|'-')? ('0'..'9')+ ;
EXP 	: ('e'|'E');
Pi 	: 'Pi' | 'PI' |'pi';

SIN 	: ('S'|'s') 'in';
COS 	: ('C'|'c') 'os';
TG 	: ('T'|'t') 'g';
CTG 	: ('C'|'c') 'tg';
LN	: ('L'| 'l') 'n';
LOG	: ('L'| 'l') 'og';

NEWLINE : '\r'? '\n';

