using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using Test_Wrapper;

namespace usue_online_tests.Tests.BoolFunctA
{
    public class BoolFunctA12 : ITestCreator, ITest, ITestGroup, ITimeLimit
    {
        public int TestID { get; set; }
        public string Name { get; } = "Построение таблицы значений02";
        public string Description { get; } = "Построение таблицы значений булевой функции";
        public string GroupName { get; set; } = "BoolFunctA";
        public int TimeLimitSeconds { get; set; } = 120;

        private readonly char[][] Letter = { ['a', 'b', 'c' ], ['p', 'q', 'r'], ['x', 'y', 'z'], ['u', 'v', 'w'] };
        private readonly string[] _funct = { "\\land", "\\lor", "\\to", "\\leftrightarrow", "\\oplus" };
        public ITest CreateTest(int randomSeed)
        {
            Random random = new Random(randomSeed);
            string functA = _funct[random.Next(0, _funct.Length)];

            int index = random.Next(0, Letter.Length);
            char letterA = Letter[index][0];
            char letterB = Letter[index][1];
            char letterC = Letter[index][2];

            //int[] answ = RandNum(randomSeed);
            //Console.WriteLine(functA);
            //for (int c = 0; c < answ.Length; c++)     отладка
            //{
            //    Console.WriteLine(answ[c]);
            //}

            ITest result = new BoolFunctA12();
            result.Text =
                "\\(\\begin{array}{ccc|c|}\\hline\n" +
                $"{letterA} & {letterB} & {letterC} & {functA}\\\\\n" +
                $"\\hline" +
                "0 & 0 & 0 & <Na:5> \\\\\n" +
                "0 & 0 & 1 & <Nb:5> \\\\\n" +
                "0 & 1 & 0 & <Nc:5> \\\\\n" +
                "0 & 1 & 1 & <Nd:5> \\\\\n" +
                "1 & 0 & 0 & <Ne:5> \\\\\n" +
                "1 & 0 & 1 & <Nf:5> \\\\\n" +
                "1 & 1 & 0 & <Ng:5> \\\\\n" +
                "1 & 1 & 1 & <Nh:5> \\\\\\hline\\end{array}\\)";

            return result;
        }

        public int CheckAnswer(int randomSeed, Dictionary<string, string> answers)
        {
            string[] keys = { "Na", "Nb", "Nc", "Nd", "Ne", "Nf", "Ng", "Nh" };
            int[] answ = RandNum(randomSeed);
            int index = 0;
            int total = 0;

            for (int r = 0; r < answ.Length; r++)
            {
                if (answers.TryGetValue(keys[index++], out var userAnswer0) &&
                    int.TryParse(userAnswer0, out var userNumber0) &&
                    userNumber0 == answ[r]) total++;
            }

            return total;
        }

        private int[] RandNum(int seed)
        {
            var random = new Random(seed);
            string functA = _funct[random.Next(0, _funct.Length)];  //{ "\\land", "\\lor", "\\to", "\\leftrightarrow", "\\oplus" }

            switch (functA)
            {
                case "\\land":
                    return new int[]
                    {
                        LogicAnd(LogicAnd(0, 0), 0), LogicAnd(LogicAnd(0, 0), 1), LogicAnd(LogicAnd(0, 1), 0),
                        LogicAnd(LogicAnd(0, 1), 1), LogicAnd(LogicAnd(1, 0), 0), LogicAnd(LogicAnd(1, 0), 1),
                        LogicAnd(LogicAnd(1, 1), 0), LogicAnd(LogicAnd(1, 1), 1)
                    };
                case "\\lor":
                    return new int[]
                    {
                        LogicOr(LogicOr(0, 0), 0), LogicOr(LogicOr(0, 0), 1), LogicOr(LogicOr(0, 1), 0),
                        LogicOr(LogicOr(0, 1), 1), LogicOr(LogicOr(1, 0), 0), LogicOr(LogicOr(1, 0), 1),
                        LogicOr(LogicOr(1, 1), 0), LogicOr(LogicOr(1, 1), 1)
                    };
                case "\\to":
                    return new int[]
                    {
                        LogicTo(LogicTo(0, 0), 0), LogicTo(LogicTo(0, 0), 1), LogicTo(LogicTo(0, 1), 0),
                        LogicTo(LogicTo(0, 1), 1), LogicTo(LogicTo(1, 0), 0), LogicTo(LogicTo(1, 0), 1),
                        LogicTo(LogicTo(1, 1), 0), LogicTo(LogicTo(1, 1), 1)
                    };
                case "\\leftrightarrow":
                    return new int[]
                    {
                        LogicEq(LogicEq(0, 0), 0), LogicEq(LogicEq(0, 0), 1), LogicEq(LogicEq(0, 1), 0),
                        LogicEq(LogicEq(0, 1), 1), LogicEq(LogicEq(1, 0), 0), LogicEq(LogicEq(1, 0), 1),
                        LogicEq(LogicEq(1, 1), 0), LogicEq(LogicEq(1, 1), 1)
                    };
                    case "\\oplus":
                        return new int[]
                    {
                        LogicXor(LogicXor(0, 0), 0), LogicXor(LogicXor(0, 0), 1), LogicXor(LogicXor(0, 1), 0),
                        LogicXor(LogicXor(0, 1), 1), LogicXor(LogicXor(1, 0), 0), LogicXor(LogicXor(1, 0), 1),
                        LogicXor(LogicXor(1, 1), 0), LogicXor(LogicXor(1, 1), 1)
                    };
                default: return new int[]  { };
            }
        }
        private int LogicAnd(int x, int y) => x * y;    
        private int LogicOr(int x, int y) => Math.Max(x, y);
        private int LogicTo(int x, int y) => Math.Max(1 - x, y);
        private int LogicEq(int x, int y) => Math.Max((1-x)*(1-y), x*y);
        private int LogicXor(int x, int y) => 1 - Math.Max((1-x)*(1-y), x*y);
        public string Text { get; set; }
        public string[] CheckBoxes { get; set; }
        public List<MemoryStream> Pictures { get; set; }
    }
}
