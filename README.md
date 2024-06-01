# 1. About MathEval
[![NuGet version (org.matheval)](https://img.shields.io/nuget/v/org.matheval.svg?style=flat-square)](https://www.nuget.org/packages/MathExpressionEval/)

MathEval is a mathematical expressions evaluator library written in C#. Allows to evaluate mathematical, boolean, string and datetime expressions
Code is written in pure C#, run on the fly. We don't use any third party libraries or packages.


This respository forks from: https://github.com/matheval/expression-evaluator-c-sharp
And make many changes:

1. Reconstruct for csharp-like naming, refolder, simplied, and more readable.
2. Support more DateTime functions, eg: date, now, year, weekday, adddays...
3. Support more operator, eg: ! !=
4. Support more text function,  eg: like 
3. Support custom function plugin.




# 2. Installation

Using Package Manager

```bash
PM> Install-Package MathEval.NET -Version 4.5.0.0
```

# 3. Supported operators, contants, functions

## 3.1 Supported Operators

| Operator | Description                                                              |
|----------|--------------------------------------------------------------------------|
| +        | Additive operator / Unary plus / Concatenate string / Datetime addition
| -        | Subtraction operator / Unary minus / Datetime subtraction
| *        | Multiplication operator, can be omitted in front of an open bracket
| /        | Division operator
| %        | Remainder operator (Modulo)
| ^        | Power operator
| &        | Concatenate string
| !        | Not operator for boolean



## 3.2 Supported conditional statements


| Conditional statement                                            | Description                                              |
|------------------------------------------------------------------|----------------------------------------------------------|
| IF(condition, valueIfTrue, valueIfFalse)                         | Example: `IF(2>1,"Pass","Fail")`
| SWITCH(expression, val1, result1, [val2,result2], …, [default])  | Example: `SWITCH(3+2,5,"Apple",7,"Mango",3,"Good","N/A")`



## 3.3 Supported logical and math functions

<table>
<tbody>
<tr>
<th>Function<sup>*</sup></th>
<th>Description</th>
</tr>
<tr>
<td>AND(logical1, [logical2], …)</td>
<td>Determine if all conditions are TRUE</td>
</tr>
<tr>
<td>OR(logical1, [logical2], …)</td>
<td>Determine if any conditions in a test are TRUE</td>
</tr>
<tr>
<td>NOT(_logical_)</td>
<td>To confirm one value is not equal to another</td>
</tr>
<tr>
<td>XOR(logical1, [logical2], …)</td>
<td>Exclusive OR function</td>
</tr>
<tr>
<td>SUM(number1, [number2],…)</td>
<td>Return sum of numbers supplied</td>
</tr>
<tr>
<td>AVERAGE(number1, [number2],…)</td>
<td>Return average of numbers supplied</td>
</tr>
<tr>
<td>MIN(number1, [number2],…)</td>
<td>Return the smallest value from the numbers supplied</td>
</tr>
<tr>
<td>MAX(number1, [number2],…)</td>
<td>Return the biggest value from the numbers supplied</td>
</tr>
<tr>
<td>MOD(number, divisor)</td>
<td>Get remainder of two given numbers after division operator.</td>
</tr>
<tr>
<td>ROUND(number, num_digits)</td>
<td>Returns the rounded approximation of given number using half-even rounding mode  
( you can change to another rounding mode)</td>
</tr>
<tr>
<td>FLOOR(number, significance)</td>
<td>Rounds a given number towards zero to the nearest multiple of a specified significance</td>
</tr>
<tr>
<td>`CEILING`(number, significance)</td>
<td>Rounds a given number away from zero, to the nearest multiple of a given number</td>
</tr>
<tr>
<td>POWER(number, power)</td>
<td>Returns the result of a number raised to a given power</td>
</tr>
<tr>
<td>RAND()</td>
<td>Produces a random number between 0 and 1</td>
</tr>
<tr>
<td>SIN(number)</td>
<td>Returns the trigonometric sine of the angle given in radians</td>
</tr>
<tr>
<td>SINH(number)</td>
<td>Returns the hyperbolic sine of a number</td>
</tr>
<tr>
<td>ASIN(number)</td>
<td>Returns the arc sine of an angle, in the range of -pi/2 through pi/2</td>
</tr>
<tr>
<td>COS(number)</td>
<td>Returns the trigonometric cos of the angle given in radians</td>
</tr>
<tr>
<td>COSH(number)</td>
<td>Returns the hyperbolic cos of a number</td>
</tr>
<tr>
<td>ACOS(number)</td>
<td>Returns the arc cosine of an angle, in the range of 0.0 through pi</td>
</tr>
<tr>
<td>TAN(number)</td>
<td>Returns the tangent of the angle given in radians</td>
</tr>
<tr>
<td>TANH(number)</td>
<td>Returns the hyperbolic tangent of a number</td>
</tr>
<tr>
<td>ATAN(number)</td>
<td>Returns the arc tangent of an angle given in radians</td>
</tr>
<tr>
<td>ATAN2(x_number, y_number)</td>
<td>Returns the arctangent from x- and y-coordinates</td>
</tr>
<tr>
<td>COT(number)</td>
<td>Returns the cotangent of an angle given in radians.</td>
</tr>
<tr>
<td>COTH(number)</td>
<td>Returns the hyperbolic cotangent of a number</td>
</tr>
<tr>
<td>SQRT(number)</td>
<td>Returns the correctly rounded positive square root of given number</td>
</tr>
<tr>
<td>LN(number)</td>
<td>Returns the natural logarithm (base _e_) of given number</td>
</tr>
<tr>
<td>LOG10(number)</td>
<td>Returns the logarithm (base 10) of given number</td>
</tr>
<tr>
<td>EXP(number)</td>
<td>Returns e raised to the power of given number</td>
</tr>
<tr>
<td>ABS(number)</td>
<td>Returns the absolute value of given number</td>
</tr>
<tr>
<td>FACT(number)</td>
<td>Returns the factorial of a given number</td>
</tr>
<tr>
<td>SEC(number)</td>
<td>Returns the secant of an angle given in radians</td>
</tr>
<tr>
<td>CSC(number)</td>
<td>Returns the cosecant of an angle given in radians</td>
</tr>
<tr>
<td>PI()</td>
<td>Return value of Pi</td>
</tr>
<tr>
<td>RADIANS(degrees)</td>
<td>Convert degrees to radians</td>
</tr>
<tr>
<td>DEGREES(radians)</td>
<td>Convert radians to degrees</td>
</tr>
<tr>
<td>INT(number)</td>
<td>Returns the Integer value of given number</td>
</tr>
</tbody>
</table>

## 3.4 Supported Constants

| Constant | Description                                                              |
|----------|--------------------------------------------------------------------------|
| e        | The value of _e_
| PI       | The value of _PI_
| TRUE     | The boolean true value
| FALSE    | The boolean false value
| NULL     | The null value


## 3.5 Supported text functions

<table>
<tbody>
<tr>
<th>Function</th>
<th>Description</th>
</tr>
<tr>
<td>LEFT(text, num_chars)</td>
<td>Extracts a given number of characters from the left side of a supplied text string</td>
</tr>
<tr>
<td>RIGHT(text, num_chars)</td>
<td>Extracts a given number of characters from the right side of a supplied text string</td>
</tr>
<tr>
<td>MID(text, start_num, num_chars)</td>
<td>Extracts a given number of characters from the middle of a supplied text string</td>
</tr>
<tr>
<td>REVERSE(text)</td>
<td>Reverse a string</td>
</tr>
<tr>
<td>ISNUMBER(text)</td>
<td>Check if a value is a number</td>
</tr>
<tr>
<td>LOWER(text)</td>
<td>Converts all letters in the specified string to lowercase</td>
</tr>
<tr>
<td>UPPER(text)</td>
<td>Converts all letters in the specified string to uppercase</td>
</tr>
<tr>
<td>PROPER(text)</td>
<td>Capitalizes words given text string</td>
</tr>
<tr>
<td>TRIM(text)</td>
<td>Removes extra spaces from text</td>
</tr>
<tr>
<td>LEN(text)</td>
<td>Returns the length of a string/ text</td>
</tr>
<tr>
<td>TEXT(value, [format_text])</td>
<td>Convert a numeric value into a text string. You can use the TEXT function to embed formatted numbers inside text  
Example:  
`<div class="enlighter-default enlighter-v-inline enlighter-t-enlighter "><span class="enlighter"><span class="enlighter-m0">TEXT</span><span class="enlighter-g1">(</span><span class="enlighter-n1">123</span><span class="enlighter-g1">)</span> <span class="enlighter-text">-</span><span class="enlighter-g1">></span> <span class="enlighter-text"></span> <span class="enlighter-n1">123</span></span></div>
`TEXT(123) -> 123`  
<div class="enlighter-default enlighter-v-inline enlighter-t-enlighter "><span class="enlighter"><span class="enlighter-m0">TEXT</span><span class="enlighter-g1">(</span><span class="enlighter-m0">DATEVALUE</span><span class="enlighter-g1">(</span><span class="enlighter-s0">"2021-01-23"</span><span class="enlighter-g1">)</span><span class="enlighter-text">,</span><span class="enlighter-s0">"dd-MM-yyyy"</span><span class="enlighter-g1">)</span> <span class="enlighter-text">-</span><span class="enlighter-g1">></span> <span class="enlighter-text"></span> <span class="enlighter-n1">23</span><span class="enlighter-text">-</span><span class="enlighter-n4">01</span><span class="enlighter-text">-</span><span class="enlighter-n1">2021</span></span></div>
`TEXT(DATEVALUE("2021-01-23"),"dd-MM-yyyy") -> 23-01-2021`  
<div class="enlighter-default enlighter-v-inline enlighter-t-enlighter "><span class="enlighter"><span class="enlighter-m0">TEXT</span><span class="enlighter-g1">(</span><span class="enlighter-n0">2.61</span><span class="enlighter-text">,</span><span class="enlighter-s0">"hh:mm"</span><span class="enlighter-g1">)</span> <span class="enlighter-text">-</span><span class="enlighter-g1">></span> <span class="enlighter-text"></span> <span class="enlighter-n1">14</span><span class="enlighter-text">:</span><span class="enlighter-n1">38</span></span></div>
`TEXT(2.61,"hh:mm") -> 14:38`  
<div class="enlighter-default enlighter-v-inline enlighter-t-enlighter "><span class="enlighter"><span class="enlighter-m0">TEXT</span><span class="enlighter-g1">(</span><span class="enlighter-n0">2.61</span><span class="enlighter-text">,</span><span class="enlighter-s0">"[hh]"</span><span class="enlighter-g1">)</span> <span class="enlighter-text">-</span><span class="enlighter-g1">></span> <span class="enlighter-text"></span> <span class="enlighter-n1">62</span></span></div>
`TEXT(2.61,"[hh]") -> 62`  
<div class="enlighter-default enlighter-v-inline enlighter-t-enlighter "><span class="enlighter"><span class="enlighter-m0">TEXT</span><span class="enlighter-g1">(</span><span class="enlighter-n0">2.61</span><span class="enlighter-text">,</span><span class="enlighter-s0">"hh-mm-ss"</span><span class="enlighter-g1">)</span> <span class="enlighter-text">-</span><span class="enlighter-g1">></span> <span class="enlighter-text"></span> <span class="enlighter-n1">14</span><span class="enlighter-text">-</span><span class="enlighter-n1">38</span><span class="enlighter-text">-</span><span class="enlighter-n1">24</span></span></div>
`TEXT(2.61,"hh-mm-ss") -> 14-38-24`  
<div class="enlighter-default enlighter-v-inline enlighter-t-enlighter "><span class="enlighter"><span class="enlighter-m0">TEXT</span><span class="enlighter-g1">(</span><span class="enlighter-m0">DATEVALUE</span><span class="enlighter-g1">(</span><span class="enlighter-s0">"2021-01-03"</span><span class="enlighter-g1">)</span><span class="enlighter-text">-</span><span class="enlighter-m0">DATEVALUE</span><span class="enlighter-g1">(</span><span class="enlighter-s0">"2021-01-01"</span><span class="enlighter-g1">)</span><span class="enlighter-text">,</span><span class="enlighter-s0">"[h]"</span><span class="enlighter-g1">)</span> <span class="enlighter-text">-</span><span class="enlighter-g1">></span> <span class="enlighter-text"></span> <span class="enlighter-n1">48</span></span></div>
`TEXT(DATEVALUE("2021-01-03")-DATEVALUE("2021-01-01"),"[h]") -> 48`  
<div class="enlighter-default enlighter-v-inline enlighter-t-enlighter "><span class="enlighter"><span class="enlighter-m0">TEXT</span><span class="enlighter-g1">(</span><span class="enlighter-m0">TIME</span><span class="enlighter-g1">(</span><span class="enlighter-n1">12</span><span class="enlighter-text">,</span><span class="enlighter-n4">00</span><span class="enlighter-text">,</span><span class="enlighter-n4">00</span><span class="enlighter-g1">)</span><span class="enlighter-text">-</span><span class="enlighter-m0">TIME</span><span class="enlighter-g1">(</span><span class="enlighter-n1">10</span><span class="enlighter-text">,</span><span class="enlighter-n1">30</span><span class="enlighter-text">,</span><span class="enlighter-n1">10</span><span class="enlighter-g1">)</span><span class="enlighter-text">,</span><span class="enlighter-s0">"hh hours and mm minutes and ss seconds"</span><span class="enlighter-g1">)</span> <span class="enlighter-text">-</span><span class="enlighter-g1">></span> <span class="enlighter-text"></span> <span class="enlighter-s0">"01 hours and 29 minutes and 50 seconds"</span></span></div>
`TEXT(TIME(12,00,00)-TIME(10,30,10),"hh hours and mm minutes and ss seconds") -> "01 hours and 29 minutes and 50 seconds"``</td>
</tr>
<tr>
<td>REPLACE(old_text, start_num, num_chars, new_text)</td>
<td>Replaces characters specified by location in a given text string with another text string</td>
</tr>
<tr>
<td>SUBSTITUTE(text, old_text, new_text)</td>
<td>Replaces a set of characters with another</td>
</tr>
<tr>
<td>FIND(find_text, within_text, [start_num])</td>
<td>Returns the location of a substring in a string (case sensitive)</td>
</tr>
<tr>
<td>SEARCH(find_text, within_text, [start_num])</td>
<td>Returns the location of a substring in a string (case insensitive)</td>
</tr>
<tr>
<td>CONCAT(text1, text2, text3,…)</td>
<td>Combines the text from multiple strings</td>
</tr>
<tr>
<td>ISBLANK(text)</td>
<td>Returns TRUE when a given string is null or empty, otherwise return FALSE</td>
</tr>
<tr>
<td>REPT(text, repeat_time)</td>
<td>Repeats characters a given number of times</td>
</tr>
<tr>
<td>CHAR(char_code)</td>
<td>Return character from ascii code</td>
</tr>
<tr>
<td>CODE(char)</td>
<td>Returns a ascii code of a character</td>
</tr>
<tr>
<td>VALUE(text)</td>
<td>Convert numbers stored as text to numbers</td>
</tr>
</tbody>
</table>

# 3.6 Supported DateTime functions

| Function | Description                                                              |
|----------|--------------------------------------------------------------------------|
| Today()            | Today()
| Now()              | Now()
| Date(.)            | Date('2024-01-01 12:00')
| Year(.)            | Year(Today())
| Month(.)           | Month(Today())
| Day(.)             | Day(Today())
| Hour(.)            | Hour(Today())
| Minute(.)          | Minute(Today())
| Second(.)          | Second(Today())
| Weekday(.)         | Weekday(Today())
| Age(.)             | Age(Today())
| AddYears(..)       | AddYears(Today(), 1)
| AddMonths(..)      | AddMonths(Today(), 1)
| AddDays(..)        | AddDays(Today(), 1)
| AddHours(..)       | AddHours(Today(), 1)
| AddMinutes(..)     | AddMinutes(Today(), 1)
| AddSeconds(..)     | AddSeconds(Today(), 1)
| AddDate(.......)   | AddDate(Today(), 1,0,0,0,0,0)


UnitTest

```csharp
            var expr = new Expression();
            Assert.AreEqual(DateTime.Parse("2020-01-01"), expr.SetFormular("Date('2020-01-01')").Eval<DateTime>());
            Assert.AreEqual(DateTime.Today,               expr.SetFormular("Today()").Eval<DateTime>());
            Assert.AreEqual(DateTime.Now.Day,             expr.SetFormular("Now()").Eval<DateTime>().Day);

            Assert.AreEqual(DateTime.Today.Year,          expr.SetFormular("Year(Today())").Eval<int>());
            Assert.AreEqual(DateTime.Today.Month,         expr.SetFormular("Month(Today())").Eval<int>());
            Assert.AreEqual(DateTime.Today.Day,           expr.SetFormular("Day(Today())").Eval<int>());
            Assert.AreEqual(DateTime.Today.Hour,          expr.SetFormular("Hour(Today())").Eval<int>());
            Assert.AreEqual(DateTime.Today.Minute,        expr.SetFormular("Minute(Today())").Eval<int>());
            Assert.AreEqual(DateTime.Today.Second,        expr.SetFormular("Second(Today())").Eval<int>());
            Assert.AreEqual(0,                            expr.SetFormular("Age(Today())").Eval<int>());
            Assert.AreEqual(DateTime.Today.DayOfWeek,     expr.SetFormular("Weekday(Today())").Eval<DayOfWeek>());
            Assert.AreEqual(DateTime.Today.AddYears(1),   expr.SetFormular("AddYears(Today(), 1)").Eval<DateTime>());
            Assert.AreEqual(DateTime.Today.AddMonths(1),  expr.SetFormular("AddMonths(Today(), 1)").Eval<DateTime>());
            Assert.AreEqual(DateTime.Today.AddDays(1),    expr.SetFormular("AddDays(Today(), 1)").Eval<DateTime>());
            Assert.AreEqual(DateTime.Today.AddHours(1),   expr.SetFormular("AddHours(Today(), 1)").Eval<DateTime>());
            Assert.AreEqual(DateTime.Today.AddMinutes(1), expr.SetFormular("AddMinutes(Today(), 1)").Eval<DateTime>());
            Assert.AreEqual(DateTime.Today.AddSeconds(1), expr.SetFormular("AddSeconds(Today(), 1)").Eval<DateTime>());
            Assert.AreEqual(DateTime.Today.AddYears(1),   expr.SetFormular("AddDate(Today(), 1,0,0,0,0,0)").Eval<DateTime>());

            Assert.AreEqual(2020,                                   expr.SetFormular("Year('2020-01-01 12:00')").Eval<int>());
            Assert.AreEqual(1,                                      expr.SetFormular("Month('2020-01-01 12:00')").Eval<int>());
            Assert.AreEqual(1,                                      expr.SetFormular("Day('2020-01-01 12:00')").Eval<int>());
            Assert.AreEqual(12,                                     expr.SetFormular("Hour('2020-01-01 12:00')").Eval<int>());
            Assert.AreEqual(0,                                      expr.SetFormular("Minute('2020-01-01 12:00')").Eval<int>());
            Assert.AreEqual(0,                                      expr.SetFormular("Second('2020-01-01 12:00')").Eval<int>());
            Assert.AreEqual(DateTime.Now.Year-2020,                 expr.SetFormular("Age('2020-01-01 12:00')").Eval<int>());
            Assert.AreEqual(DayOfWeek.Wednesday,                    expr.SetFormular("Weekday('2020-01-01 12:00')").Eval<DayOfWeek>());
            Assert.AreEqual(DateTime.Parse("2021-01-01 12:00:00"),  expr.SetFormular("AddYears('2020-01-01 12:00', 1)").Eval<DateTime>());
            Assert.AreEqual(DateTime.Parse("2020-02-01 12:00:00"),  expr.SetFormular("AddMonths('2020-01-01 12:00', 1)").Eval<DateTime>());
            Assert.AreEqual(DateTime.Parse("2020-01-02 12:00:00"),  expr.SetFormular("AddDays('2020-01-01 12:00', 1)").Eval<DateTime>());
            Assert.AreEqual(DateTime.Parse("2020-01-01 13:00:00"),  expr.SetFormular("AddHours('2020-01-01 12:00', 1)").Eval<DateTime>());
            Assert.AreEqual(DateTime.Parse("2020-01-01 12:01:00"),  expr.SetFormular("AddMinutes('2020-01-01 12:00', 1)").Eval<DateTime>());
            Assert.AreEqual(DateTime.Parse("2020-01-01 12:00:01"),  expr.SetFormular("AddSeconds('2020-01-01 12:00', 1)").Eval<DateTime>());
            Assert.AreEqual(DateTime.Parse("2021-01-01 12:00:00"),  expr.SetFormular("AddDate('2020-01-01 12:00', 1,0,0,0,0,0)").Eval<DateTime>());

```

# 3.7 Regist custom functions

MathEval.NET support custom functions:

1. Create class to implements IFunction.
2. Regist this class to Expresson object.
3. Write custom function and eval().

Examples:

``` csharp
using System;
using System.Collections.Generic;
using Org.MathEval.Common.Functions;
using static Org.MathEval.Common;
public class DateFunctions : IFunction
{
    public List<FunctionDef> GetDefs()
    {
        return new List<FunctionDef> {
            new FunctionDef("now",        typeof(DateTime), 0, null),
            new FunctionDef("year",       typeof(int),      1, typeof(DateTime)),
            new FunctionDef("AddYears",   typeof(DateTime), 2, typeof(DateTime), typeof(int)),
        };
    }
    public object Execute(List<object> args, ExpressionContext dc, string funcName = "")
    {
        var name = funcName.ToLower();
        switch (name)
        {
            case "now":        return DateTime.Now;
            case "year":       return ToDateTime(args[0]).Year;
            case "addyears":   return ToDateTime(args[0]).AddYears(ToInt(args[1]));
        }
        return DateTime.Now;
    }
}

// regist and use this functions
var expression = new Expression().RegistFunction(new DateFunctions());  // regist date functions
var dt = expression.SetFormula("Now()").Eval<DateTime>();               // eval now() function
```



# 4. Usage examples

## 4.1 Basic evaluator
```cs
using System;
using org.matheval;
					
public class Program
{
	public static void Main()
	{
		var expression = new Expression("(a + b) / 2 ");
		expression.Bind("a", 3);
		expression.Bind("b",5);
		Object value = expression.Eval();
		Console.WriteLine("Result: "+value); //Result: 4
		
	}
}
```

## 4.2 Conditional statements

```cs
using System;
using org.matheval;
					
public class Program
{
	public static void Main()
	{
		Expression expression = new Expression("IF(time>8, (HOUR_SALARY*8) + (HOUR_SALARY*1.25*(time-8)), HOUR_SALARY*time)");
		//bind variable
		expression.Bind("HOUR_SALARY", 10);
		expression.Bind("time", 9);
		//eval
		Decimal salary = expression.Eval<Decimal>();	
		Console.WriteLine(salary); //return 92.5
	}
}
```

## 4.3 Validate expression
```cs
Expression expression = new Expression("SUM(1,2,3) + true");
List<String> errors = expression.GetError(); 
if(errors.Count > 0)
{
  foreach(String error in errors)
  {
  	Console.WriteLine(error);
  }
}	
```

## 4.4 Min, max, sum, avg
```cs
using System;
using org.matheval;
					
public class Program
{
	public static void Main()
	{
		Expression expr = new Expression("MIN(2,3,16)");
		int min = expr.Eval<int>(); 
		Console.WriteLine(min);// return 2 (min)
		
		expr.SetFomular("Max(2,3,16)");
		int max = expr.Eval<int>(); 
		Console.WriteLine(max);// return 16 (max)
		
		expr.SetFomular("Sum(2,3,16)");
		decimal sum = expr.Eval<decimal>(); 
		Console.WriteLine(sum);// return 21	(sum)
		
		expr.SetFomular("average(2,3,16)");
		decimal average = expr.Eval<decimal>(); 
		Console.WriteLine(average);// return 7 (average)	
	}
}
```
## 4.5 Round, floor, ceiling
```cs
using System;
using org.matheval;
					
public class Program
{
	public static void Main()
	{
		Expression expr = new Expression("ROUND(2.149, 1)");
		Object value = expr.Eval<Decimal>(); 
		Console.WriteLine("ROUND(2.149, 1) = "+value); //return 2.1
		
		expr = new Expression("FLOOR(2.149)");
		value = expr.Eval(); 
		Console.WriteLine("FLOOR(2.149) = "+value); //return 2	
		
		expr = new Expression("FLOOR(3.7,2)");
		value = expr.Eval(); 
		Console.WriteLine("FLOOR(3.7,2) = "+value);	//return 2
		
		expr = new Expression("CEILING(2.149)");
		value = expr.Eval(); 
		Console.WriteLine("CEILING(2.149) = "+value); //return 3
		
		expr = new Expression("CEILING(1.5, 0.1)");
		value = expr.Eval(); 
		Console.WriteLine("CEILING(1.5, 0.1) = "+value); //return 1.5	
	}
}
```
## 4.6 Trigonometry
```cs
using System;
using org.matheval;
					
public class Program
{
	public static void Main()
	{
		Expression expr = new Expression("tan(a)^3-((3*sin(a)-sin(3*a))/(3*cos(a)+cos(3*a)))");
		Decimal value = expr.Bind("a", Math.PI/6).Eval<Decimal>(); 
		Console.WriteLine(value); //return 0		
	}
}
```

## 4.7 Deal with string
```cs
using System;
using org.matheval;
					
public class Program
{
	public static void Main()
	{
		Expression taxExpr = new Expression("IF(LOWER(TAX_CODE)='vat',amount*10/100,IF(LOWER(TAX_CODE)='gst',amount*15/100,0))");
		taxExpr.Bind("TAX_CODE","GST");
		taxExpr.Bind("amount", 5005m);
		Decimal value = taxExpr.Eval<Decimal>();
		Console.WriteLine(value);
	}
}
```
## 4.8 Concatenate strings
```cs
using System;
using org.matheval;
					
public class Program
{
	public static void Main()
	{
		Expression expr = new Expression("CONCAT('The United States of ', 'America')");
		String value = expr.Eval<String>();	
		Console.WriteLine(value);//The United States of America	
	}
}
```

# 5.License
MIT license
