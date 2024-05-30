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
using Org.MathEval;
using Org.MathEval.Functions;
using Org.MathEval.Nodes;
using Org.MathEval.Operators;
using Org.MathEval.Operators.Binop;
using Org.MathEval.Operators.Unary;
using System;
using System.Collections.Generic;
using System.Globalization;
using static Org.MathEval.Common;

namespace Org.MathEval
{
    public class Parser
    {
        /// <summary>
        /// Create object Lexer
        /// </summary>
        private Lexer Lexer;
        
        /// <summary>
        /// Dc
        /// </summary>
        private ExpressionContext Dc;

        /// <summary>
        /// Create Dictionary Operators have key is string and value is interface IOperator
        /// </summary>
        private Dictionary<string, IOperator> Operators = null;

        /// <summary>
        /// Create Dictionary UnaryOperators have key is string and value is interface IOperator
        /// </summary>
        private Dictionary<string, IOperator> UnaryOperators = null;

        /// <summary>
        /// Create Dictionary Constants have key is string and value is interface IOperator
        /// </summary>
        private Dictionary<string, Object> Constants = null;

        /// <summary>
        /// Initializes a new instance structure with no param
        /// </summary>
        public Parser()
        {
            this.InitOperators();
            this.InitConstants();
            this.Dc = new ExpressionContext(6, MidpointRounding.ToEven, "yyyy-MM-dd", "yyyy-MM-dd HH:mm", @"hh\:mm", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Initializes a new instance structure to a specified type string value input expression
        /// </summary>
        /// <param name="formular">formular</param>
        public Parser(string formular)
        {
            this.InitOperators();
            this.InitConstants();
            this.Dc = new ExpressionContext(6, MidpointRounding.ToEven, "yyyy-MM-dd", "yyyy-MM-dd HH:mm", @"hh\:mm", CultureInfo.InvariantCulture);
            this.Lexer = new Lexer(formular, this);
            //this.Lexer.GetToken();
        }

        /// <summary>
        /// Initializes a new instance structure with a <see cref="ExpressionContext"/> instance
        /// </summary>
        public Parser(ExpressionContext dc)
        {
            this.InitOperators();
            this.InitConstants();
            this.Dc = dc;
        }

        /// <summary>
        /// Initializes a new instance structure with a <see cref="ExpressionContext"/> instance and a specified type string value input expression
        /// </summary>
        /// <param name="formular">formular</param>
        public Parser(ExpressionContext dc, string formular)
        {
            this.InitOperators();
            this.InitConstants();
            this.Dc = dc;
            this.Lexer = new Lexer(formular, this);
        }

        /// <summary>
        /// Provide expression for lexer
        /// @param fumular input expression
        /// </summary>
        /// <param name="formular">formular</param>
        public void SetFomular(string formular)
        {
            this.Lexer = new Lexer(formular, this);
            //this.Lexer.GetToken();
        }

        /// <summary>
        /// Add Operator
        /// @param op Operator instance
        /// </summary>
        /// <param name="op">op</param>
        public void AddOperator(IOperator op)
        {
            if (Operators == null)
            {
                Operators = new Dictionary<string, IOperator>();
            }
            Operators.Add(op.GetOp(), op);
        }

        /// <summary>
        /// Add Unary Operator
        /// @param op Unary operator instance
        /// </summary>
        /// <param name="op">op</param>
        public void AddUnaryOperator(IOperator op)
        {
            if (UnaryOperators == null)
            {
                UnaryOperators = new Dictionary<string, IOperator>();
            }
            UnaryOperators.Add(op.GetOp(), op);
        }

        /// <summary>
        /// Get operator list
        /// </summary>
        /// <returns>Dictionary operators</returns>
        public Dictionary<string, IOperator> GetOperators()
        {
            return Operators;
        }

        /// <summary>
        /// Get Unary Operators
        /// </summary>
        /// <returns>Dictionary UnaryOperators</returns>
        public Dictionary<string, IOperator> GetUnaryOperators()
        {
            return UnaryOperators;
        }

        /// <summary>
        /// Get ExpressionContext
        /// </summary>
        /// <returns></returns>
        public ExpressionContext GetExpressionContext()
        {
            return Dc;
        }

        /// <summary>
        /// Add Constant
        /// </summary>
        /// <param name="constantName">constantName constant name</param>
        /// <param name="value">Constant value</param>
        public void AddConstant(string constantName, Object value)
        {
            if (Constants == null)
            {
                Constants = new Dictionary<string, Object>();
            }
            Constants.Add(constantName.ToLowerInvariant(), value);
        }

        /// <summary>
        /// Init Operators
        /// </summary>
        private void InitOperators()
        {
            AddOperator(new OrOperator(Consts.OrOperator, 100, Assoc.LEFT));
            AddOperator(new AndOperator(Consts.AndOperator, 200, Assoc.LEFT));
            AddOperator(new EqOperator(Consts.EqOperator, 300, Assoc.LEFT));
            AddOperator(new EqOperator(Consts.EqsOperator, 300, Assoc.LEFT));
            AddOperator(new NeqOperator(Consts.NeqOperator, 300, Assoc.LEFT));
            AddOperator(new NeqOperator(Consts.Neq1Operator, 300, Assoc.LEFT));
            AddOperator(new LtOperator(Consts.LtOperator, 400, Assoc.LEFT));
            AddOperator(new LeOperator(Consts.LeOperator, 400, Assoc.LEFT));
            AddOperator(new GtOperator(Consts.GtOperator, 400, Assoc.LEFT));
            AddOperator(new GeOperator(Consts.GeOperator, 400, Assoc.LEFT));
            AddOperator(new PlusOperator(Consts.PlusOperator, 500, Assoc.LEFT));
            AddOperator(new ConcatOperator(Consts.ConcatOperator, 500, Assoc.LEFT));
            AddOperator(new MinusOperator(Consts.MinusOperator, 500, Assoc.LEFT));
            AddOperator(new MulOperator(Consts.MulOperator, 600, Assoc.LEFT));
            AddOperator(new DivOperator(Consts.DivOperator, 600, Assoc.LEFT));
            AddOperator(new RemainderOperator(Consts.RemainderOperator, 600, Assoc.LEFT));
            AddUnaryOperator(new UnaryPosOperator(Consts.UnaryPosOperator, 700));
            AddUnaryOperator(new UnaryNegOperator(Consts.UnaryNegOperator, 700));
            AddOperator(new PowerOperator(Consts.PowerOperator, 800, Assoc.RIGHT));
        }

        /// <summary>
        /// Init Constants
        /// </summary>
        private void InitConstants()
        {
            AddConstant("e", Math.E);
            AddConstant("pi", Math.PI);
            AddConstant("true", true);
            AddConstant("false", false);
            AddConstant("null", null);
        }

        /// <summary>
        /// Parse Double Number
        /// </summary>
        /// <returns>Node Base node instance</returns>
        private Nodes.Node ParseDoubleNumber()
        {
            NumberNode nbrNode = new NumberNode(this.Lexer.CurrentToken.DoubleValue, true);
            Lexer.GetToken();
            return nbrNode;
        }

        /// <summary>
        /// Parse String
        /// </summary>
        /// <returns>Node Base node instance</returns>
        private Nodes.Node ParseString()
        {
            StringNode strNode = new StringNode(this.Lexer.CurrentToken.IdentifierValue);
            Lexer.GetToken();
            return strNode;
        }

        /// <summary>
        /// Parse Bool
        /// </summary>
        /// <returns>Node Base node instance</returns>
        private Nodes.Node ParseBool()
        {
            BoolNode boolNode = new BoolNode(this.Lexer.CurrentToken.BoolValue);
            Lexer.GetToken();
            return boolNode;
        }

        /// <summary>
        /// Parse Constant
        /// </summary>
        /// <param name="identifier">identifier</param>
        /// <returns>Node Base node instance</returns>
        private Nodes.Node ParseConstant(string identifier)
        {
            if (Constants.ContainsKey(identifier))
            {
                Object constant = Constants[identifier];
                if (constant == null)
                {
                    return new NullNode();
                }
                else if (Common.IsNumber(constant))
                {
                    if(!identifier.Equals("pi") && !identifier.Equals("e"))
                    {
                        return new NumberNode(Common.ToDecimal(constant, Dc.Culture), true);
                    }
                    else
                    {
                        return new NumberNode(Common.ToDecimal(constant, Dc.Culture), false);
                    }
                }
                else if (constant is string)
                {
                    return new StringNode(constant.ToString());
                }
                else if (constant is Boolean)
                {
                    return new BoolNode((Boolean)constant);
                }
                else
                {
                    throw new Exception(Consts.MSG_UNSUPPORT_CONST);
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Parse variable, function call and constant
        /// </summary>
        /// <returns>Node Base node instance</returns>
        private Nodes.Node ParseIdentifier()
        {
            string identifierStr = this.Lexer.CurrentToken.IdentifierValue;
            this.Lexer.GetToken();
            if (this.Lexer.CurrentToken.Type != TokenType.TOKEN_PAREN_OPEN)
            {
                Nodes.Node constantNode;
                if ((constantNode = this.ParseConstant(identifierStr.ToLowerInvariant())) != null)
                {
                    return constantNode;
                }
                VariableNode node = new VariableNode(identifierStr);
                return node;
            }
            else
            {
                this.Lexer.GetToken();// eat (
                List<Nodes.Node> args = new List<Nodes.Node>();
                if (this.Lexer.CurrentToken.Type != TokenType.TOKEN_PAREN_CLOSE)
                {
                    while (true)
                    {
                        Nodes.Node arg = this.ParseEx();
                        args.Add(arg);
                        if (this.Lexer.CurrentToken.Type == TokenType.TOKEN_PAREN_CLOSE)
                        {
                            break;
                        }
                        if (this.Lexer.CurrentToken.Type != TokenType.TOKEN_COMMA)
                        {
                            throw new Exception(string.Format(Consts.MSG_UNEXPECT_TOKEN_AT_POS, (object[])(new String[] { this.Lexer.CurrentToken.ToString(), Lexer.LexerPosition.ToString() })));
                        }
                        Lexer.GetToken();
                    }
                }
                this.Lexer.GetToken();// eat )

                // 获取方法类
                // TODO: （1）用缓存；（2）实现扩展能力
                IFunction funcExecuter;
                try
                {
                    Type t = Type.GetType("Org.MathEval.Functions." + identifierStr.ToCamelUpper() + "Function", true);
                    object obj = Activator.CreateInstance(t);
                    if (obj == null)
                        throw new Exception();
                    funcExecuter = (IFunction)obj;
                }
                catch (Exception e)
                {
                    throw new Exception(string.Format(Consts.MSG_METH_NOTFOUND, (object[])(new string[] { identifierStr.ToUpperInvariant() })));
                }
                
                // 解析方法定义
                List<FunctionDef> funcs = funcExecuter.GetDefs();
                foreach (FunctionDef func in funcs)
                {
                    //getParamCount() = -1 when params is unlimited
                    if ((func.ArgCount != -1 && args.Count != func.ArgCount) ||
                        (func.ArgCount == -1 && args.Count < 1))
                    {
                        continue;
                    }

                    bool paramsValid = true;
                    for (int i = 0; i < args.Count; i++)
                    {
                        Nodes.Node arg = args[i];
                        Type compareTarget = func.ArgCount == -1 ? func.ArgTypes[0] : func.ArgTypes[i];
                        //if (!arg.ReturnType.Equals(typeof(VariableNode)) &&
                        if (!arg.ReturnType.Equals(typeof(object)) &&
                        !func.ArgTypes[func.ArgCount == -1 ? 0 : i].Equals(typeof(Object)) &&
                        !arg.ReturnType.Equals(compareTarget))
                        {
                            paramsValid = false;
                        }
                    }

                    if (paramsValid)
                    {
                        CallFuncNode callFuncNode = new CallFuncNode(identifierStr, args, func.ReturnType, funcExecuter);
                        return callFuncNode;
                    }
                }

                throw new Exception(string.Format(Consts.MSG_WRONG_METH_PARAM, (object[])(new string[] { identifierStr.ToUpperInvariant() })));
            }
        }

        /// <summary>
        /// Parse Pr of math expression
        /// </summary>
        /// <returns>Node Base node instance</returns>
        private Nodes.Node ParsePr()
        {
            this.Lexer.GetToken();

            //check if Parentheses has null body
            if (this.Lexer.CurrentToken.Type == TokenType.TOKEN_PAREN_CLOSE)
            {
                this.Lexer.GetToken();
                throw new Exception(string.Format(Consts.MSG_PAREN_NULL_BODY, (object[])(new String[] { Lexer.LexerPosition.ToString() })));
            }

            // Parse Parentheses body
            Nodes.Node subNode = this.ParseEx();
            if (this.Lexer.CurrentToken.Type != TokenType.TOKEN_PAREN_CLOSE)
            {
                throw new Exception(string.Format(Consts.MSG_UNEXPECT_TOKEN_AT_POS, (object[])(new String[] { this.Lexer.CurrentToken.ToString(), Lexer.LexerPosition.ToString() })));
            }

            this.Lexer.GetToken();
            return subNode;
        }

        /// <summary>
        /// Parse Top of math expression
        /// </summary>
        /// <returns>Node Base node instance</returns>
        public Nodes.Node ParseTop()
        {
            this.Lexer.resetLexer();
            this.Lexer.GetToken();
            Nodes.Node root = this.ParseEx();
            if (this.Lexer.CurrentToken.Type != TokenType.TOKEN_EOF)
            {
                throw new Exception(string.Format(Consts.MSG_UNEXPECT_TOKEN_AT_POS, (object[])(new string[] { this.Lexer.CurrentToken.ToString(), Lexer.LexerPosition.ToString() })));
            }
            return root;
        }

        /// <summary>
        /// Parse Ex of math expression
        /// </summary>
        /// <returns>Node Base node instance</returns>
        private Nodes.Node ParseEx()
        {
            Nodes.Node lhs = this.ParsePrm();
            if (null != lhs)
            {
                //return this.ParseBo(0, lhs);
                return this.ParseBo(100, lhs);
            }

            throw new Exception(Consts.MSG_UNABLE_PARSE_EXPR);
        }

        /// <summary>
        /// Parse Bo of math expression
        /// </summary>
        /// <param name="inputPrec">inputPrec</param>
        /// <param name="lhs">lhs</param>
        /// <returns>Node Base node instance</returns>
        private Nodes.Node ParseBo(int inputPrec, Nodes.Node lhs)
        {
            while (true)
            {
                IOperator iopCurr = this.GetOperator();
                if (iopCurr == null || iopCurr.GetPrec() < inputPrec)
                {
                    return lhs;
                }

                this.Lexer.GetToken();
                Nodes.Node rhs = this.ParsePrm();
                if (rhs == null)
                {
                    throw new Exception(Consts.MSG_UNABLE_PARSE_EXPR);
                }
                while (true)
                {
                    IOperator iopNext = this.GetOperator();
                    if (iopNext == null || 
                        !(iopCurr.GetPrec() < iopNext.GetPrec() ||
                        (iopCurr.GetPrec() == iopNext.GetPrec() && 
                        iopNext.GetAss() == Assoc.RIGHT)))
                    {
                        break;
                    }
                    //rhs = this.ParseBo(iopCurr.GetPrec(), rhs);
                    rhs = this.ParseBo(iopNext.GetPrec(), rhs);
                }
                //if (!lhs.ReturnType.Equals(typeof(VariableNode)) && !rhs.ReturnType.Equals(typeof(VariableNode)))

                System.Type t = iopCurr.Validate(lhs.ReturnType, rhs.ReturnType);
                if (t == null)
                {
                    throw new Exception(string.Format(Consts.MSG_WRONG_OP_PARAM,
                                    (object[])(new String[] { iopCurr.GetOp(), lhs.ReturnType.ToString(), rhs.ReturnType.ToString() })));
                }
                else
                {
                    lhs = new BinanyNode(iopCurr, lhs, rhs, t);
                }
            }
        }

        /// <summary>
        /// Get relate operator excuter
        /// </summary>
        /// <returns>IOperator operator executer</returns>
        private IOperator GetOperator()
        {
            string op = this.Lexer.CurrentToken.IdentifierValue;
            return (this.Lexer.CurrentToken.Type == TokenType.TOKEN_OP && this.Operators.ContainsKey(op)) ? this.Operators[op] : null;
        }

        /// <summary>
        /// Parse Unary
        /// </summary>
        /// <returns>Node Base node instance</returns>
        private Nodes.Node ParseUnary()
        {
            string op = this.Lexer.CurrentToken.IdentifierValue;
            IOperator iop = this.UnaryOperators[op];
            this.Lexer.GetToken();
            Nodes.Node lhs = this.ParsePrm();
            Nodes.Node expr = this.ParseBo(iop.GetPrec(), lhs);

            if (expr == null)
            {
                throw new Exception(string.Format(Consts.MSG_UNEXPECT_TOKEN_AT_POS,
                              (object[])(new string[] { this.Lexer.CurrentToken.ToString(), Lexer.LexerPosition.ToString() })));
            }

            return new UnaryNode(iop, expr);
        }

        /// <summary>
        /// Parse ifelse condition
        /// Example:
        /// new Afe_Evaluator('IF(abc > 1 && true,if(cde + 1 <6.5, "amazing", "n/a"), "n/a")')
        /// .bind('abc',2).bind('cde',3).eval() -> return "amazing"
        /// </summary>
        /// <returns>Node Base node instance</returns>
        private Nodes.Node ParseIfElse()
        {
            this.Lexer.GetToken();

            //parse IF condition
            if (this.Lexer.CurrentToken.Type != TokenType.TOKEN_PAREN_OPEN)
            {
                throw new Exception(string.Format(Consts.MSG_UNEXPECT_TOKEN_AT_POS,
                                  (object[])(new String[] { this.Lexer.CurrentToken.ToString(), Lexer.LexerPosition.ToString() })));
            }

            this.Lexer.GetToken();//eat (
            Nodes.Node condition = this.ParseEx();

            //parse if true condition
            if (this.Lexer.CurrentToken.Type != TokenType.TOKEN_COMMA)
            {
                throw new Exception(string.Format(Consts.MSG_UNEXPECT_TOKEN_AT_POS,
                              (object[])(new string[] { this.Lexer.CurrentToken.ToString(), Lexer.LexerPosition.ToString() })));
            }

            this.Lexer.GetToken(); //eat ,
            Nodes.Node ifTrueNode = this.ParseEx();

            //parse if false condition
            if (this.Lexer.CurrentToken.Type != TokenType.TOKEN_COMMA)
            {
                throw new Exception(string.Format(Consts.MSG_UNEXPECT_TOKEN_AT_POS,
                              (object[])(new String[] { this.Lexer.CurrentToken.ToString(), this.Lexer.LexerPosition.ToString() })));
            }

            this.Lexer.GetToken(); //eat ,
            Nodes.Node ifFalseNode = this.ParseEx();

            //check endif token
            if (this.Lexer.CurrentToken.Type != TokenType.TOKEN_PAREN_CLOSE)
            {
                throw new Exception(string.Format(Consts.MSG_UNEXPECT_TOKEN_AT_POS,
                              (object[])(new string[] { this.Lexer.CurrentToken.ToString(), this.Lexer.LexerPosition.ToString() })));
            }

            this.Lexer.GetToken(); //eat )
            //if (!condition.ReturnType.Equals(typeof(VariableNode)) && !condition.ReturnType.Equals(typeof(Boolean)))
            if (!condition.ReturnType.Equals(typeof(object)) && !condition.ReturnType.Equals(typeof(Boolean)))
            {
                throw new Exception(string.Format(Consts.MSG_IFELSE_WRONG_CONDITION,
                              (object[])(new string[] { condition.ReturnType.ToString() })));
            }
           // else if (!ifTrueNode.ReturnType.Equals(typeof(VariableNode)) &&
           //          !ifFalseNode.ReturnType.Equals(typeof(VariableNode)) &&
            else if (!ifTrueNode.ReturnType.Equals(typeof(object)) &&
                     !ifFalseNode.ReturnType.Equals(typeof(object)) &&
                     !ifTrueNode.ReturnType.Equals(ifFalseNode.ReturnType))
            {
                throw new Exception(string.Format(Consts.MSG_CONDITIONAL_WRONG_PARAMS,
                              (object[])(new String[] { Consts.IF, ifTrueNode.ReturnType.ToString(), ifFalseNode.ReturnType.ToString() })));
            }

            if (!ifTrueNode.ReturnType.Equals(typeof(object)))
            {
                return new IfElseNode(condition, ifTrueNode, ifFalseNode, ifTrueNode.ReturnType);
            }
            else if (!ifFalseNode.ReturnType.Equals(typeof(object)))
            {
                return new IfElseNode(condition, ifTrueNode, ifFalseNode, ifFalseNode.ReturnType);
            }
            else
            {
                return new IfElseNode(condition, ifTrueNode, ifFalseNode, typeof(object));
            }
        }

        /// <summary>
        /// Parse switch, case condition
        /// Example:
        /// new Afe_Evaluator('CASE(abc,1,"amazing",2,"good",3,"bad","n/a")').bind('abc',2).eval() -> return "good"
        /// </summary>
        /// <returns>Node Base node instance</returns>
        private Nodes.Node ParseSwitchCase()
        {
            this.Lexer.GetToken();//eat Switch, case

            //parse switch condition
            if (this.Lexer.CurrentToken.Type != TokenType.TOKEN_PAREN_OPEN)
            {
                throw new Exception(string.Format(Consts.MSG_UNEXPECT_TOKEN_AT_POS,
                             (object[])(new string[] { this.Lexer.CurrentToken.ToString(), this.Lexer.LexerPosition.ToString() })));
            }

            this.Lexer.GetToken();//eat (
            Nodes.Node condition = this.ParseEx();
            if (condition == null)
            {
                throw new Exception(Consts.MSG_CASE_WRONG_PARAMS);
            }

            //Parse var and result.
            List<Nodes.Node> varResultExprs = new List<Nodes.Node>();
            while (true)
            {
                if (this.Lexer.CurrentToken.Type == TokenType.TOKEN_PAREN_CLOSE)
                {
                    if (varResultExprs.Count < 1)
                    {
                        throw new Exception(Consts.MSG_CASE_WRONG_PARAMS);
                    }
                    else if (varResultExprs.Count % 2 == 0)
                    {
                        throw new Exception(Consts.MSG_CASE_WRONG_PARAMS);
                    }
                    this.Lexer.GetToken(); //eat )  				

                    System.Type temp = varResultExprs[varResultExprs.Count - 1].ReturnType;
                    for (int i = 1; i < varResultExprs.Count - 1; i += 2)
                    {
                        //if (!temp.Equals(typeof(VariableNode)) && !temp.Equals(varResultExprs[i].ReturnType))
                        if (!temp.Equals(typeof(object)) && !temp.Equals(varResultExprs[i].ReturnType))
                        {
                            throw new Exception(string.Format(Consts.MSG_CONDITIONAL_WRONG_PARAMS,
                                          (object[])(new string[] { Consts.SWITCH, temp.ToString(), varResultExprs[i].ReturnType.ToString() })));
                        }
                    }

                    return new SwitchCaseNode(condition, varResultExprs, varResultExprs[varResultExprs.Count - 1], temp);
                }
                if (this.Lexer.CurrentToken.Type != TokenType.TOKEN_COMMA)
                {
                    throw new Exception(string.Format(Consts.MSG_UNEXPECT_TOKEN_AT_POS,
                                 (object[])(new string[] { this.Lexer.CurrentToken.ToString(), Lexer.LexerPosition.ToString() })));
                }

                this.Lexer.GetToken(); //eat ,
                Nodes.Node tempExpr = this.ParseEx();
                varResultExprs.Add(tempExpr);
            }
        }

        /// <summary>
        /// Start parse anything inside a binary expression
        /// </summary>
        /// <returns>Node Base node instance</returns>
        private Nodes.Node ParsePrm()
        {
            if (this.Lexer.CurrentToken.Type == TokenType.TOKEN_IDENTIFIER)
            {
                return this.ParseIdentifier();
            }
            else if (this.Lexer.CurrentToken.Type == TokenType.TOKEN_IF)
            {
                return this.ParseIfElse();
            }
            else if (this.Lexer.CurrentToken.Type == TokenType.TOKEN_CASE)
            {
                return this.ParseSwitchCase();
            }
            else if (this.Lexer.CurrentToken.Type == TokenType.TOKEN_NUMBER_DECIMAL)
            {
                return this.ParseDoubleNumber();
            }
            else if (this.Lexer.CurrentToken.Type == TokenType.TOKEN_STRING)
            {
                return this.ParseString();
            }
            else if (this.Lexer.CurrentToken.Type == TokenType.TOKEN_BOOL)
            {
                return this.ParseBool();
            }
            else if (this.Lexer.CurrentToken.Type == TokenType.TOKEN_PAREN_OPEN)
            {
                return this.ParsePr();
            }
            else if (this.Lexer.CurrentToken.Type == TokenType.TOKEN_UOP)
            {
                return this.ParseUnary();
            }

            throw new Exception(string.Format(Consts.MSG_UNEXPECT_TOKEN_AT_POS,
                (object[])(new String[] { this.Lexer.CurrentToken.ToString(), this.Lexer.LexerPosition.ToString() })));
        }

    }
}
