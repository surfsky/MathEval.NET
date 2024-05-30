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
namespace Org.MathEval
{
    internal static class Consts
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


        /// <summary>
        /// Default value is white space
        /// </summary>
        //public const string Const_WhiteSpace = " ";
        public const char WhiteSpace = ' ';

        /// <summary>
        /// Condition expression IF
        /// </summary>
        public const string IF = "IF";

        /// <summary>
        /// Condition expression SWITCH
        /// </summary>
        public const string SWITCH = "SWITCH";

        /// <summary>
        /// Condition expression CASE
        /// </summary>
        public const string CASE = "CASE";

        /// <summary>
        /// Condition expression WHEN
        /// </summary>
        //public const string Const_WHEN = "WHEN";

        /// <summary>
        /// Condition expression BRACKETS OPEN
        /// </summary>
        public const char BRACKETS_OPEN = '(';

        /// <summary>
        /// Condition expression BRACKETS CLOSE
        /// </summary>
        public const char BRACKETS_CLOSE = ')';

        /// <summary>
        /// Condition expression COMMA
        /// </summary>
        public const char COMMA = ',';

        /// <summary>
        /// Condition expression PERIODT quotation marks
        /// </summary>
        public const char PERIODT = '.';

        /// <summary>
        /// Double quotation marks
        /// </summary>
        public const char DOUBLE_QUOTATION = '"';

        /// <summary>
        /// Single quotation marks
        /// </summary>
        public const char SINGLE_QUOTATION = '\'';

        /// <summary>
        /// Condition expression EOF
        /// </summary>
        public const string EOF = "EOF";


        /// <summary>
        /// Or
        /// </summary>
        public const string OrOperator = "||";

        /// <summary>
        /// And
        /// </summary>
        public const string AndOperator = "&&";

        /// <summary>
        /// Eqs
        /// </summary>
        public const string EqsOperator = "==";

        /// <summary>
        /// Eq
        /// </summary>
        public const string EqOperator = "=";

        /// <summary>
        /// Neq
        /// </summary>
        public const string NeqOperator = "!=";

        /// <summary>
        /// Neq
        /// </summary>
        public const string Neq1Operator = "<>";

        /// <summary>
        /// Lt
        /// </summary>
        public const string LtOperator = "<";

        /// <summary>
        /// Le
        /// </summary>
        public const string LeOperator = "<=";

        /// <summary>
        /// Gt
        /// </summary>
        public const string GtOperator = ">";

        /// <summary>
        /// Ge
        /// </summary>
        public const string GeOperator = ">=";

        /// <summary>
        /// Plus
        /// </summary>
        public const string PlusOperator = "+";

        /// <summary>
        /// Concat
        /// </summary>
        public const string ConcatOperator = "&";

        /// <summary>
        /// Minus
        /// </summary>
        public const string MinusOperator = "-";

        /// <summary>
        /// Mul
        /// </summary>
        public const string MulOperator = "*";

        /// <summary>
        /// Div
        /// </summary>
        public const string DivOperator = "/";

        /// <summary>
        /// Remainder
        /// </summary>
        public const string RemainderOperator = "%";

        /// <summary>
        /// UnaryPos
        /// </summary>
        public const string UnaryPosOperator = "+";

        /// <summary>
        /// UnaryNeg
        /// </summary>
        public const string UnaryNegOperator = "-";

        /// <summary>
        /// Power
        /// </summary>
        public const string PowerOperator = "^";



        /// <summary>
        /// Funtion Text
        /// </summary>
        public const string Text = "text";

        /// <summary>
        /// Funtion TODAY
        /// </summary>
        public const string TODAY = "TODAY";

        /// <summary>
        /// Funtion TODAY
        /// </summary>
        public const string NOW = "NOW";

        /// <summary>
        /// Funtion left
        /// </summary>
        public const string LEFT = "left";

        /// <summary>
        /// Function Second
        /// </summary>
        public const string Second = "second";

        /// <summary>
        /// Function code
        /// </summary>
        public const string Code = "code";

        /// <summary>
        /// Function hour
        /// </summary>
        public const string Hour = "hour";

        /// <summary>
        /// Function int
        /// </summary>
        public const string Int = "int";

        /// <summary>
        /// Function isblank
        /// </summary>
        public const string Isblank = "isblank";

        /// <summary>
        /// Function Minute
        /// </summary>
        public const string Minute = "minute";


        /// <summary>
        /// Function proper
        /// </summary>
        public const string Proper = "proper";

        /// <summary>
        /// Function substitute
        /// </summary>
        public const string Substitute = "substitute";

        /// <summary>
        /// Function Abs
        /// </summary>
        public const string Abs = "abs";

        /// <summary>
        /// Function Search
        /// </summary>
        public const string Search = "search";

        /// <summary>
        /// Function Acos
        /// </summary>
        public const string Acos = "acos";

        /// <summary>
        /// Function Acot
        /// </summary>
        public const string Acot = "acot";

        /// <summary>
        /// Function Acot
        /// </summary>
        public const string Csc = "csc";


        /// <summary>
        /// Function Cot
        /// </summary>
        public const string Cot = "cot";

        /// <summary>
        /// Function Coth
        /// </summary>
        public const string Coth = "coth";

        /// <summary>
        /// Function Degrees
        /// </summary>
        public const string Degrees = "degrees";

        /// <summary>
        /// Function RIGHT
        /// </summary>
        public const string RIGHT = "right";

        /// <summary>
        /// Function Concat
        /// </summary>
        public const string Concat = "concat";

        /// <summary>
        /// Function MID
        /// </summary>
        public const string MID = "mid";

        /// <summary>
        /// Function LPAD
        /// </summary>
        public const string LPAD = "lpad";

        /// <summary>
        /// Function RPAD
        /// </summary>
        public const string RPAD = "rpad";

        /// <summary>
        /// Function Sec
        /// </summary>
        public const string Sec = "sec";

        /// <summary>
        /// Function Reverse
        /// </summary>
        public const string Reverse = "reverse";

        /// <summary>
        /// Function Isnumeric
        /// </summary>
        public const string IsNumeric = "isnumeric";

        /// <summary>
        /// Function Isnumber
        /// </summary>
        public const string IsNumber = "isnumber";

        /// <summary>
        /// Function Lower
        /// </summary>
        public const string Lower = "lower";

        /// <summary>
        /// Function Upper
        /// </summary>
        public const string Upper = "upper";

        /// <summary>
        /// Function Trim
        /// </summary>
        public const string Trim = "trim";

        /// <summary>
        /// Function Length
        /// </summary>
        public const string Length = "length";

        /// <summary>
        /// Function Len
        /// </summary>
        public const string Len = "len";

        /// <summary>
        /// Function String
        /// </summary>
        public const string String = "string";

        /// <summary>
        /// Function Value
        /// </summary>
        public const string Value = "value";

        /// <summary>
        /// Function Bool
        /// </summary>
        public const string Bool = "bool";

        /// <summary>
        /// Function Ceiling
        /// </summary>
        public const string Ceiling = "ceiling";

        /// <summary>
        /// Function And
        /// </summary>
        public const string And = "and";

        /// <summary>
        /// Function asin
        /// </summary>
        public const string Asin = "asin";

        /// <summary>
        /// Function Atan2
        /// </summary>
        public const string Atan2 = "atan2";

        /// <summary>
        /// Function atan
        /// </summary>
        public const string Atan = "atan";

        /// <summary>
        /// Function Or
        /// </summary>
        public const string Or = "or";

        /// <summary>
        /// Function Pi
        /// </summary>
        public const string PI = "pi";

        /// <summary>
        /// Function Radians
        /// </summary>
        public const string Radians = "radians";

        /// <summary>
        /// Function Replace
        /// </summary>
        public const string Replace = "replace";

        /// <summary>
        /// Function Not
        /// </summary>
        public const string Not = "not";

        /// <summary>
        /// Function Sum
        /// </summary>
        public const string Sum = "sum";

        /// <summary>
        /// Function Min
        /// </summary>
        public const string Min = "min";

        /// <summary>
        /// Function Max
        /// </summary>
        public const string Max = "max";

        /// <summary>
        /// Function Verage
        /// </summary>
        public const string Average = "average";

        /// <summary>
        /// Function Bitand
        /// </summary>
        public const string BitAnd = "bitand";

        /// <summary>
        /// Function Tan
        /// </summary>
        public const string Tan = "tan";

        /// <summary>
        /// Function Tanh
        /// </summary>
        public const string Tanh = "tanh";

        /// <summary>
        /// Function Bitnot
        /// </summary>
        public const string BitNot = "bitnot";

        /// <summary>
        /// Function Bitlshift
        /// </summary>
        public const string BitLShift = "bitlshift";

        /// <summary>
        /// Function Bitor
        /// </summary>
        public const string BitOr = "bitor";

        /// <summary>
        /// Function Bitrshift
        /// </summary>
        public const string BitRShift = "bitrshift";

        /// <summary>
        /// Function Bitxor
        /// </summary>
        public const string BitXor = "bitxor";

        /// <summary>
        /// Function Xor
        /// </summary>
        public const string Xor = "xor";

        /// <summary>
        /// Function Sin
        /// </summary>
        public const string Sin = "sin";

        /// <summary>
        /// Function Sinh
        /// </summary>
        public const string Sinh = "sinh";

        /// <summary>
        /// Function Cos
        /// </summary>
        public const string Cos = "cos";

        /// <summary>
        /// Function Cosh
        /// </summary>
        public const string Cosh = "cosh";

        /// <summary>
        /// Function Sqrt
        /// </summary>
        public const string Sqrt = "sqrt";

        /// <summary>
        /// Function Floor
        /// </summary>
        public const string Floor = "floor";

        /// <summary>
        /// Function Ln
        /// </summary>
        public const string Ln = "ln";

        /// <summary>
        /// Function Log10
        /// </summary>
        public const string Log10 = "log10";

        /// <summary>
        /// Function Mod
        /// </summary>
        public const string Mod = "mod";

        /// <summary>
        /// Function power
        /// </summary>
        public const string Power = "power";

        /// <summary>
        /// Function Random
        /// </summary>
        public const string Random = "random";

        /// <summary>
        /// Function Ceil
        /// </summary>
        public const string Ceil = "ceil";

        /// <summary>
        /// Function Round
        /// </summary>
        public const string Round = "round";


        /// <summary>
        /// Function time
        /// </summary>
        public const string Time = "time";

        /// <summary>
        /// Function Exp
        /// </summary>
        public const string Exp = "exp";

        /// <summary>
        /// Function Fact
        /// </summary>
        public const string Fact = "fact";

        /// <summary>
        /// Function Find
        /// </summary>
        public const string Find = "find";




        /// <summary>
        /// Key is 0
        /// </summary>
        public const string Key0 = "0";

        /// <summary>
        /// Key is 1
        /// </summary>
        public const string Key1 = "1";

        /// <summary>
        /// Key is 2
        /// </summary>
        public const string Key2 = "2";

        /// <summary>
        /// Key is 3
        /// </summary>
        public const string Key3 = "3";

        /// <summary>
        /// Key is 4
        /// </summary>
        public const string Key4 = "4";

        /// <summary>
        /// Key is 5
        /// </summary>
        public const string Key5 = "5";

        /// <summary>
        /// Key is 6
        /// </summary>
        public const string Key6 = "6";
    }
}