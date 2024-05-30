/*
    The MIT License

    Copyright (c) 2021 MathEval.org

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in
    all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    THE SOFTWARE.
*/
using System;
using System.Collections.Generic;

namespace Org.MathEval
{
    public class Consts
    {
        public const string MSG_WRONG_OP_ACOS = "Value input must be greater than or equal to -1, but less than or equal to 1.";
        public const string MSG_WRONG_OP_PARAM = "The operator {0} is undefined for the argument type(s) {1}, {2}";
        public const string MSG_WRONG_OP_PARAM_EX = "{0} operator can only be applied to {1}";
        public const string MSG_WRONG_METH_PARAM = "Check params for function {0}";
        public const string MSG_METH_NOTFOUND = "Function {0} does not exist";
        public const string MSG_METH_NOT_ALLOWED = "Function {0} is not alowed. Please contact your system\"s administrator";
        public const string MSG_METH_PARAM_INVALID = "The parameter for function {0} is supplied with wrong format.";
        public const string MSG_UNEXPECT_TOKEN = "Unexpected token {0}";
        public const string MSG_UNEXPECT_TOKEN_AT_POS = "Unexpected token {0} at position {1}";
        public const string MSG_CONDITIONAL_WRONG_PARAMS = "Incorrect parameter type for function {0}. Expected {1}, received {2}";
        public const string MSG_IFELSE_WRONG_CONDITION = "Incorrect condition type for function IF. Expected Boolean, received {0}";
        public const string MSG_IFELSE_NESTIF_CONDITION = "Nested 'if' expression in condition param is not accepted!";
        public const string MSG_IFELSE_WRONG_SYNTAX = "Check ifelse syntax";
        public const string MSG_CASE_WRONG_PARAMS = "Incorrect number of parameters for function CASE";
        public const string MSG_UNSUPPORT_CONST = "Unsupported constant type";
        public const string MSG_PAREN_NULL_BODY = "Require parentheses body near position {0}";
        public const string MSG_UNARY_INVALID = "Invalid unary operator";
        public const string MSG_UNABLE_PARSE_EXPR = "Unable to parse expression";
        public const string MSG_RESULT_WRONG = "Result is not a {0}";
        public const string MSG_VAR_NOTSET = "The value for variable {0} was not set!";
        public const string MSG_RETURN_TYPE_NOT_SUPPORT = "Return type of {0} is not supported!";
        public const string ShowMessage = "Check argument for method";


        //-------------------------------------------------
        // Operations
        //-------------------------------------------------
        public const char WhiteSpace = ' ';
        public const string IF = "IF";
        public const string SWITCH = "SWITCH";
        public const string CASE = "CASE";
        public const char BRACKETS_OPEN = '(';
        public const char BRACKETS_CLOSE = ')';
        public const char COMMA = ',';
        public const char PERIODT = '.';
        public const char DOUBLE_QUOTATION = '"';
        public const char SINGLE_QUOTATION = '\'';
        public const string EOF = "EOF";
        public const string OrOperator = "||";
        public const string AndOperator = "&&";
        public const string EqsOperator = "==";
        public const string EqOperator = "=";
        public const string NeqOperator = "!=";
        public const string Neq1Operator = "<>";
        public const string LtOperator = "<";
        public const string LeOperator = "<=";
        public const string GtOperator = ">";
        public const string GeOperator = ">=";
        public const string PlusOperator = "+";
        public const string ConcatOperator = "&";
        public const string MinusOperator = "-";
        public const string MulOperator = "*";
        public const string DivOperator = "/";
        public const string RemainderOperator = "%";
        public const string UnaryPosOperator = "+";
        public const string UnaryNegOperator = "-";
        public const string PowerOperator = "^";


        //-------------------------------------------------
        // DateTime functions
        //-------------------------------------------------
        public const string TODAY = "TODAY";
        public const string NOW = "NOW";
        public const string Second = "second";
        public const string Hour = "hour";
        public const string Minute = "minute";
        public const string Sec = "sec";
        public const string Time = "time";


        //-------------------------------------------------
        // Text functions
        //-------------------------------------------------
        public const string Text = "text";
        public const string LEFT = "left";
        public const string Isblank = "isblank";
        public const string Proper = "proper";
        public const string Substitute = "substitute";
        public const string Search = "search";
        public const string RIGHT = "right";
        public const string Concat = "concat";
        public const string MID = "mid";
        public const string LPAD = "lpad";
        public const string RPAD = "rpad";
        public const string Reverse = "reverse";
        public const string Lower = "lower";
        public const string Upper = "upper";
        public const string Trim = "trim";
        public const string Length = "length";
        public const string Len = "len";
        public const string String = "string";
        public const string Replace = "replace";
        public const string Find = "find";
        public const string Code = "code";  // ascii code



        //-------------------------------------------------
        // Number functions
        //-------------------------------------------------
        public const string Int = "int";
        public const string Abs = "abs";
        public const string Ceiling = "ceiling";
        public const string IsNumeric = "isnumeric";
        public const string IsNumber = "isnumber";
        public const string Value = "value";
        public const string Floor = "floor";
        public const string Sqrt = "sqrt";
        public const string Ln = "ln";
        public const string Log10 = "log10";
        public const string Mod = "mod";
        public const string Power = "power";
        public const string Random = "random";
        public const string Ceil = "ceil";
        public const string Round = "round";
        public const string Exp = "exp";
        public const string Fact = "fact";  



        //-------------------------------------------------
        // Trigonomatric functions
        //-------------------------------------------------
        public const string Acos = "acos";
        public const string Acot = "acot";
        public const string Csc = "csc";
        public const string Cot = "cot";
        public const string Coth = "coth";
        public const string Degrees = "degrees";
        public const string Asin = "asin";
        public const string Atan2 = "atan2";
        public const string Atan = "atan";
        public const string PI = "pi";
        public const string Radians = "radians";
        public const string Tan = "tan";
        public const string Tanh = "tanh";
        public const string Sin = "sin";
        public const string Sinh = "sinh";
        public const string Cos = "cos";
        public const string Cosh = "cosh";


        //-------------------------------------------------
        // Stat functions
        //-------------------------------------------------
        public const string Sum = "sum";
        public const string Min = "min";
        public const string Max = "max";
        public const string Average = "average";


        //-------------------------------------------------
        // Logic functions
        //-------------------------------------------------
        public const string Bool = "bool";
        public const string And = "and";
        public const string Or = "or";
        public const string Not = "not";
        public const string BitAnd = "bitand";
        public const string BitNot = "bitnot";
        public const string BitLShift = "bitlshift";
        public const string BitOr = "bitor";
        public const string BitRShift = "bitrshift";
        public const string BitXor = "bitxor";
        public const string Xor = "xor";

    }
}