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
	: expr NEWLINE { $value = $expr.value; }
	;

expr returns[double value]	
	: ('-' me1=multExpression {$value = -me1;}|me1=multExpression {$value = me1;})
	('+' me2=multExpression {$value += $me2.value;}
	|'-' me2=multExpression {$value -= $me2.value;})*
	;

multExpression returns[double value]
	: a1=fanc {$value = $a1.value;}
	('*' a2=fanc {$value *= $a2.value;}
	|'/' a2=fanc {$value /= $a2.value;})*
	;
	
fanc returns[double value]
	: exponentiationFanc {$value = $exponentiationFanc.value;}
	| trigonometryFanc {$value = $trigonometryFanc.value;}
	| bracket {$value = $bracket.value;}
	;


bracket returns[double value]
	: FLOAT {$value = double.Parse($FLOAT.text);}
	| '(' expr ')' {$value = $expr.value;}
	| '[' expr ']' {$value = Math.Abs($expr.value);}
	;
	
exponentiationFanc returns[double value]
	: EXP'(' expr ')' {$value = Math.Exp($expr.value);}
	| EXP {$value = Math.E;}
	//| a1 = expr '^' a2 = expr {$value = Math.Pow($a1.value, $a2.value);} 
	| LOG '(' a1 = expr ', ' a2 = expr ')' {$value = Math.Log($a1.value, $a2.value);}
	| LN '(' expr ')' {$value = Math.Log($expr.value);}
	;
	
	
trigonometryFanc returns[double value]
	: Pi  {$value = Math.PI;}
	| standardTrigonometryFanc {$value = $standardTrigonometryFanc.value;}
	| hyperbolicTrigonometryFanc {$value = $hyperbolicTrigonometryFanc.value;}
	| arcTrigonometryFanc {$value = $arcTrigonometryFanc.value;}
	;

standardTrigonometryFanc returns[double value]
	: SIN '(' a1 = expr ')' {$value = Math.Sin($a1.value);}
	| COS '(' a1 = expr ')' {$value = Math.Cos($a1.value+);}
	| TG '(' a1 = expr ')' {$value = Math.Tan($a1.value);}
	| CTG '(' a1 = expr ')' {$value = 1.0/Math.Tan($a1.value);}
	;

hyperbolicTrigonometryFanc returns[double value]
	: SINH '(' a1 = expr ')' {$value = Math.Sinh($a1.value);}
	| COSH '(' a1 = expr ')' {$value = Math.Cosh($a1.value);}
	| TGH '(' a1 = expr ')' {$value = Math.Tanh($a1.value);}
	| CTGH '(' a1 = expr ')' {$value = 1.0/Math.Tanh($a1.value);}
	;
	
arcTrigonometryFanc returns[double value]
	: ASIN '(' a1 = expr ')' {$value = Math.Asin($a1.value);}
	| ACOS '(' a1 = expr ')' {$value = Math.Acos($a1.value);}
	| ATG '(' a1 = expr ')' {$value = Math.Atan($a1.value);}
	| ACTG '(' a1 = expr ')' {$value = 1.0/Math.Atan($a1.value);}
	;

	
/*
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
*/

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
LOG	: ('L'| 'l') 'og';
LN	: ('L'| 'l') 'n';

Pi 	: 'Pi' | 'PI' |'pi';
SIN 	: ('S'|'s') 'in';
COS 	: ('C'|'c') 'os';
TG 	: ('T'|'t') 'g';
CTG 	: ('C'|'c') 'tg';

SINH 	: SIN 'h';
COSH 	: COS 'h';
TGH 	: TG 'h';
CTGH 	: CTG 'h';

ARC 	: ('Arc'| 'arc'| 'A' | 'a');
ASIN 	: ARC SIN;
ACOS 	: ARC COS;
ATG 	: ARC TG;
ACTG 	: ARC CTG;

NEWLINE : '\n' '\r'? ;

