using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using Test_Wrapper;

namespace usue_online_tests.Tests.BoolFunctA
{
    public class BoolFunctA11 : ITestCreator, ITest, ITestGroup
    {
        public int TestID { get; set; }
        public string Name { get; } = "Построение таблицы значений01";
        public string Description { get; } = "Построение таблицы значений булевой функции";
        public string GroupName { get; set; } = "BoolFunctA";
        public int TimeLimitSeconds { get; set; } = 120;

        private readonly char[][] Letter = { ['a', 'b' ], ['p', 'q'], ['x', 'y'], ['u', 'v'] };
        public ITest CreateTest(int randomSeed)
        {
            Random random = new Random(randomSeed);
            int index = random.Next(0, Letter.Length);
            char letterA = Letter[index][0];
            char letterB = Letter[index][1];

            //int[][] answ = RandNum(randomSeed);
            //for (int c = 0; c < answ.Length; c++)
            //{
            //    string i = "";
            //    for (int r = 0; r < answ[c].Length; r++)          отладка
            //    {
            //        i = i + answ[c][r] + " ";
            //    }
            //    Console.WriteLine(i);
            //}

            ITest result = new BoolFunctA11();
            result.Text =
                "\\(\\begin{array}{cc|ccccc|}\\hline\n" +
                $"{letterA} & {letterB} & \\land & \\lor & \\to & \\leftrightarrow & \\oplus\\\\\n\\hline" +
                "0 & 0 & <NAa:5> & <NBa:5> & <NCa:5> & <NDa:5> & <NEa:5> \\\\\n" +
                "0 & 1 & <NAb:5> & <NBb:5> & <NCb:5> & <NDb:5> & <NEb:5> \\\\\n" +
                "1 & 0 & <NAc:5> & <NBc:5> & <NCc:5> & <NDc:5> & <NEc:5> \\\\\n" +
                "1 & 1 & <NAd:5> & <NBd:5> & <NCd:5> & <NDd:5> & <NEd:5> \\\\\\hline\\end{array}\\)";

            return result;
        }

        public int CheckAnswer(int randomSeed, Dictionary<string, string> answers)
        {
            int[][] answ = RandNum(randomSeed);
            string[] keys = Keys();
            int index = 0;
            int total = 0;

            for (int r = 0; r < answ[0].Length; r++)
            {
                for (int c = 0; c < answ.Length; c++)
                {
                    if (answers.TryGetValue(keys[index++], out var userAnswer0) &&
                    int.TryParse(userAnswer0, out var userNumber0) &&
                    userNumber0 == answ[c][r]) total++;
                }
            }
            return total;
        }

        private int[][] RandNum(int seed)
        {
            int[][] final = new int[5][];
            for (int i = 0; i < 5; i++)
            {
                final[i] = new int[4];

                switch (i)
                { 
                    case 0:
                        {
                            final[i][0] = LogicAnd(0, 0);
                            final[i][1] = LogicAnd(0, 1);
                            final[i][2] = LogicAnd(1, 0);
                            final[i][3] = LogicAnd(1, 1);
                            break;
                        }
                    case 1:
                        {
                            final[i][0] = LogicOr(0, 0);
                            final[i][1] = LogicOr(0, 1);
                            final[i][2] = LogicOr(1, 0);
                            final[i][3] = LogicOr(1, 1);
                            break;
                        }
                    case 2:
                        {
                            final[i][0] = LogicTo(0, 0);
                            final[i][1] = LogicTo(0, 1);
                            final[i][2] = LogicTo(1, 0);
                            final[i][3] = LogicTo(1, 1);
                            break;
                        }
                    case 3:
                        {
                            final[i][0] = LogicEq(0, 0);
                            final[i][1] = LogicEq(0, 1);
                            final[i][2] = LogicEq(1, 0);
                            final[i][3] = LogicEq(1, 1);
                            break;

                        }
                    case 4:
                        {
                            final[i][0] = LogicXor(0, 0);
                            final[i][1] = LogicXor(0, 1);
                            final[i][2] = LogicXor(1, 0);
                            final[i][3] = LogicXor(1, 1);
                            break;
                        }
                    default:
                        break;
                }
            }
            return final;
        }
        private string[] Keys()
        {
            string[] final = new string[20];
            final = new string[] { "NAa", "NBa", "NCa", "NDa", "NEa",
                                   "NAb", "NBb", "NCb", "NDb", "NEb",
                                   "NAc", "NBc", "NCc", "NDc", "NEc",
                                   "NAd", "NBd", "NCd", "NDd", "NEd" };
            return final;
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
