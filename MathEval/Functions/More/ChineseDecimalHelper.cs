using System;
using System.Collections.Generic;

namespace Org.MathEval.Functions
{
    internal static class ChineseDecimalHelper
    {

        static string[] digitNames = { "零", "壹", "贰", "叁", "肆", "伍", "陆", "柒", "捌", "玖" };
        static string[] unitNames = { "", "拾", "佰", "仟", "万", "亿" };
        static Dictionary<string, int> digitMap = new Dictionary<string, int>
            {
                {"零", 0}, {"壹", 1}, {"贰", 2}, {"叁", 3}, {"肆", 4}, {"伍", 5}, {"陆", 6}, {"柒", 7}, {"捌", 8}, {"玖", 9}
            };

        static Dictionary<string, int> unitMap = new Dictionary<string, int>
            {
                {"拾", 10}, {"佰", 100}, {"仟", 1000}, {"万", 10000}, {"亿", 100000000}
            };


        static bool HasDecimalPart(decimal num)
        {
            return num % 1 != 0;
        }

        /// <summary>Translate number to chinese big number text format</summary>
        public static string ToChineseBigNumber(this decimal num)
        {
            // seperate interger and decimal parts
            string numStr = HasDecimalPart(num) ? num.ToString("0.00") : num.ToString("0");
            string[] parts = numStr.Split('.');
            string integerPart = parts[0];
            string decimalPart = parts.Length > 1 ? parts[1] : "";

            // parse interge part
            string integerChinese = IntegerToChinese(integerPart);

            // parse decimal part
            string decimalChinese = "";
            if (!string.IsNullOrEmpty(decimalPart))
                decimalChinese = "点" + DecimalPartToChinese(decimalPart);

            // return
            return integerChinese + decimalChinese;
        }

        /// <summary>Translate chinese number to decimal</summary>
        public static decimal ParseChineseBigNumber(string chineseNumber)
        {

            string[] parts = chineseNumber.Split('点');
            string integerPart = parts[0];
            string decimalPart = parts.Length > 1 ? parts[1] : "";

            int integerValue = ParseIntegerPart(integerPart);
            int decimalValue = 0;

            if (!string.IsNullOrEmpty(decimalPart))
            {
                decimalValue = ParseDecimalPart(decimalPart);
            }

            return (decimal)integerValue + (decimal)decimalValue / (decimal)Math.Pow(10, decimalPart.Length);
        }

        static string DecimalPartToChinese(string num)
        {
            string result = "";
            foreach (char digit in num)
            {
                int digitValue = int.Parse(digit.ToString());
                result += digitNames[digitValue];
            }
            return result;
        }

        static string IntegerToChinese(string num)
        {
            string result = "";
            int len = num.Length;
            for (int i = 0; i < len; i++)
            {
                int digit = int.Parse(num[i].ToString());
                int unitIndex = (len - i - 1) / 4;
                int digitIndex = (len - i - 1) % 4;

                if (digit != 0)
                {
                    result += digitNames[digit] + unitNames[digitIndex];
                }
                else
                {
                    if (i < len - 1 && int.Parse(num[i + 1].ToString()) != 0 && ((len - i - 1) % 4 != 0))
                    {
                        result += digitNames[digit];
                    }
                }
            }

            return result;
        }

        static int ParseDecimalPart(string decimalPart)
        {
            int value = 0;
            int multiplier = 1;

            for (int i = 0; i < decimalPart.Length; i++)
            {
                string str = decimalPart.Substring(i, 1);

                if (digitMap.ContainsKey(str))
                {
                    value += digitMap[str] * multiplier;
                    multiplier *= 10;
                }
            }

            return value;
        }

        static int ParseIntegerPart(string integerPart)
        {
            int value = 0;
            int unitValue = 1;

            for (int i = integerPart.Length - 1; i >= 0; i--)
            {
                string str = integerPart.Substring(i, 1);

                if (digitMap.ContainsKey(str))
                {
                    value += digitMap[str] * unitValue;
                }
                else if (unitMap.ContainsKey(str))
                {
                    unitValue = unitMap[str];
                }
            }

            return value;
        }
    }
}