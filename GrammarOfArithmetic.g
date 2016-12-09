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
	private static Hashtable memory = new Hashtable();
	
	private double Factorial(double n)
        {
            double f = 1;
            for (int i = 1; i <= (int)n; i++)
            {
                f *= i;
            }
            return f;
        }

        private double DoubleFactorial(double n)
        {
            double f = 1;
            for (int i = (int)n \% 2==0?2:1; i <= (int)n; i+=2)
            {
                f *= i;
            }
            return f;
        }
}

public calc returns[string value]
	:  {$value = "";} (statement {$value += $statement.value;})+
	;

statement returns[string value]
	: expr {$value = " = ";}('='{$value = " ";})? NEWLINE { $value += $expr.value; }
	| ID '=' a1 = expr {$value = '=' + $a1.value.ToString();} NEWLINE 
		{ if(!memory.ContainsKey($ID.text))
			memory.Add($ID.text, $a1.value);
		  else
			memory[$ID.text] = $a1.value;}
	| NEWLINE
	;


expr returns[double value]	
	: ('-'me1=multExpression {$value = -me1;} 
		| me1=multExpression {$value = me1;})
	('+' me2=multExpression {$value += $me2.value;}
	|'-' me2=multExpression {$value -= $me2.value;})*
	;

multExpression returns[double value]
	: a1=fanc {$value = $a1.value;}
	('^' a2=fanc {$value = Math.Pow($value, $a2.value);}
		|'*' a2=fanc {$value *= $a2.value;}
		|('/'|':') a2=fanc {$value /= $a2.value;}
		| 'div' a2 = fanc {$value = (int)$a1.value/(int)$a2.value;}
		| 'mod' a2 = fanc {$value = (int)$a1.value\%(int)$a2.value;}
		| '>' a2 = fanc {$value = Math.Max($a1.value, $a2.value);}
		| '<' a2 = fanc {$value = Math.Min($a1.value, $a2.value);}
	)*
	;

fanc returns[double value]
	: (exponentiationFanc {$value = $exponentiationFanc.value;}
	| trigonometryFanc {$value = $trigonometryFanc.value;}
	| bracket {$value = $bracket.value;})
	('!!' {$value = DoubleFactorial($value);}
		|'!'  {$value = Factorial($value);})?
	;

bracket returns[double value]
	: ID {$value = (double)memory[$ID.text];}
	| FLOAT {$value = double.Parse($FLOAT.text);}
	|('(' a1 = expr ')'|'{' a1 = expr '}') {$value = $a1.value;}
	| '[' expr ']' {$value = Math.Abs($expr.value);}
	| 'abs(' expr ')' {$value = Math.Abs($expr.value);}
	| 'max('a1 = expr (SEPARATOR a2 = expr {a1 = Math.Max(a1, a2);})+ ')' {$value = a1;}
	| 'min('a1 = expr (SEPARATOR a2 = expr {a1 = Math.Min(a1, a2);})+ ')' {$value = a1;}
	| 'div(' a1 = expr SEPARATOR a2 = expr ')' {$value = (int)$a1.value/(int)$a2.value;}
	| 'mod(' a1 = expr SEPARATOR a2 = expr ')' {$value = (int)$a1.value\%(int)$a2.value;}
	;
	
exponentiationFanc returns[double value]
	: 'exp(' expr ')' {$value = Math.Exp($expr.value);}
	| 'e' {$value = Math.E;}
	| 'pow(' a1 = expr SEPARATOR a2 = expr ')' {$value = Math.Pow($a1.value, $a2.value);}
	| 'root(' a1 = expr SEPARATOR a2 = expr ')' {$value = Math.Pow($a1.value, 1.0/$a2.value);}
	| 'sqrt(' a1 = expr ')' {$value = Math.Pow($a1.value, 1.0/2.0);}
	| 'sqr(' a1 = expr ')' {$value = Math.Pow($a1.value, 2.0);}
	| 'log(' a1 = expr SEPARATOR a2 = expr ')'{$value = Math.Log($a1.value, $a2.value);}
	| 'lg(' a1 = expr ')' {$value = Math.Log10($a1.value);}
	| 'ln(' expr ')' {$value = Math.Log($expr.value);}
	;	
	
trigonometryFanc returns[double value]
	: 'pi'  {$value = Math.PI;}
	| standardTrigonometryFanc {$value = $standardTrigonometryFanc.value;}
	| hyperbolicTrigonometryFanc {$value = $hyperbolicTrigonometryFanc.value;}
	| arcTrigonometryFanc {$value = $arcTrigonometryFanc.value;}
	;

standardTrigonometryFanc returns[double value]
	: 'sin(' a1 = expr ')' {$value = Math.Sin($a1.value);}
	| 'cos(' a1 = expr ')' {$value = Math.Cos($a1.value);}
	| 'tg(' a1 = expr ')' {$value = Math.Tan($a1.value);}
	| 'ctg(' a1 = expr ')' {$value = 1.0/Math.Tan($a1.value);}
	| 'sec(' a1 = expr ')' {$value = 1.0/Math.Cos($a1.value);}
	| 'cosec(' a1 = expr ')' {$value = 1.0/Math.Sin($a1.value);}
	;

hyperbolicTrigonometryFanc returns[double value]
	: 'sh(' a1 = expr ')' {$value = Math.Sinh($a1.value);}
	| 'ch(' a1 = expr ')' {$value = Math.Cosh($a1.value);}
	| 'th(' a1 = expr ')' {$value = Math.Tanh($a1.value);}
	| 'cth(' a1 = expr ')' {$value = 1.0/Math.Tanh($a1.value);}
	| 'sech(' a1 = expr ')' {$value = 1.0/Math.Cosh($a1.value);}
	| 'csch(' a1 = expr ')' {$value = 1.0/Math.Sinh($a1.value);}
	;
	
arcTrigonometryFanc returns[double value]
	: 'asin(' a1 = expr ')' {$value = Math.Asin($a1.value);}
	| 'acos(' a1 = expr ')' {$value = Math.Acos($a1.value);}
	| 'atg2('  a1 = expr SEPARATOR a2 = expr  ')' {$value = Math.Atan2($a1.value, $a2.value);}
	| 'atg(' a1 = expr ')' {$value = Math.Atan($a1.value);}
	| 'actg(' a1 = expr ')' {$value = 1.0/Math.Atan($a1.value);}
	;

ID  :	('a'..'z'|'à'..'ÿ'|'_') ('a'..'z'|'à'..'ÿ'|'0'..'9'|'_')*;

FLOAT
    :	('0'..'9')+ EXPONENT?
    |   ('0'..'9')+ FLOATSEPARATOR ('0'..'9')* EXPONENT?
    |   FLOATSEPARATOR ('0'..'9')+ EXPONENT?
    ;
    
fragment
FLOATSEPARATOR :'.'| ',';
SEPARATOR :';';
fragment
EXPONENT: 'e' ('+'|'-')? ('0'..'9')+ ;

NEWLINE : '\r'? '\n';
