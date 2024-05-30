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
namespace Org.MathEval.Functions
{
    public class FunctionDef
    {
        /// <summary>
        /// Function name
        /// </summary>
        public string Name;

        /// <summary>
        /// Return type holder
        /// </summary>
        public System.Type ReturnType;

        /// <summary>
        /// Param type holder
        /// </summary>
        public System.Type[] ArgTypes;

        /// <summary>
        /// Param count
        /// </summary>
        public int ArgCount;

        /// <summary>
        /// Function def constructor
        /// </summary>
        /// <param name="name">Function name</param>
        /// <param name="returnType">return datatype</param>
        /// <param name="argCount">param count。If argCount is -1 means unlimited args</param>
        /// <param name="argTypes">Param type</param>
        public FunctionDef(string name, Type returnType, int argCount, params Type[] argTypes)
        {
            Name = name.ToLowerInvariant();
            ReturnType = returnType;
            ArgCount = argCount;
            ArgTypes = argTypes;
        }
    }
}
