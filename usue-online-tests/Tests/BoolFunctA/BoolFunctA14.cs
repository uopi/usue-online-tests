using Microsoft.CodeAnalysis.Operations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using Test_Wrapper;

namespace usue_online_tests.Tests.BoolFunctA
{
    public class BoolFunctA14 : ITestCreator, ITest, ITestGroup
    {
        public int TestID { get; set; }
        public string Name { get; } = "Нормальная конъюнктивная форма01";
        public string Description { get; } = "Нормальная конъюнктивная форма";
        public string GroupName { get; set; } = "BoolFunctA";
        public int TimeLimitSeconds { get; set; } = 120;
        private char[] Letters = { 'A', 'B', 'C', 'S', 'T', 'X', 'Y', 'Z' };

        public ITest CreateTest(int randomSeed)
        {
            Random random = new Random(randomSeed);

            List<char> letterL = new List<char>(Letters);
            char letterA = letterL[random.Next(0, letterL.Count)];
            letterL.Remove(letterA);
            char letterB = letterL[random.Next(0, letterL.Count)];
            letterL.Remove(letterB);
            char letterC = letterL[random.Next(0, letterL.Count)];

            int[][] table = GenarateLogicTable(random);

            List<char> fAList = new List<char> { 'P', 'Q', 'R', 'F', 'G', 'H', 'U', 'V', 'W' };
            char functA = fAList[random.Next(0, fAList.Count)];

            ITest result = new BoolFunctA14();
            result.Text =
                "Задайте совершенной нормальной конъюнктивной формой функцию, заданную таблицей" +
                " истинности (конъюнкты должны быть в круглых скобках, не переставляйте конъюнкты" +
                " местами и не переставляйте местами дизъюнкты, \\(\\lor\\) вводите как строчную букву v," +
                " \\(\\land\\) вводите как знак &, пробелов в строке быть не должно):\n " +

                "\\(\\begin{array}{ccc|c|}\\hline\n" +
                $"{letterA} & {letterB} & {letterC} & {functA}\\\\\n\\hline" +
                $"{table[0][0]} & {table[0][1]} & {table[0][2]} & {table[0][3]} \\\\\n" +
                $"{table[1][0]} & {table[1][1]} & {table[1][2]} & {table[1][3]} \\\\\n" +
                $"{table[2][0]} & {table[2][1]} & {table[2][2]} & {table[2][3]} \\\\\n" +
                $"{table[3][0]} & {table[3][1]} & {table[3][2]} & {table[3][3]} \\\\\n" +
                $"{table[4][0]} & {table[4][1]} & {table[4][2]} & {table[4][3]} \\\\\n" +
                $"{table[5][0]} & {table[5][1]} & {table[5][2]} & {table[5][3]} \\\\\n" +
                $"{table[6][0]} & {table[6][1]} & {table[6][2]} & {table[6][3]} \\\\\n" +
                $"{table[7][0]} & {table[7][1]} & {table[7][2]} & {table[7][3]} \\\\\\hline" + "\\end{array}\n\\newline" +
                "Ответ: <Ax:30>\\)";

            return result;
        }

        public int CheckAnswer(int randomSeed, Dictionary<string, string> answers)
        {
            Random random = new Random(randomSeed);

            List<char> letterL = new List<char>(Letters);
            char letterA = letterL[random.Next(0, letterL.Count)];
            letterL.Remove(letterA);
            char letterB = letterL[random.Next(0, letterL.Count)];
            letterL.Remove(letterB);
            char letterC = letterL[random.Next(0, letterL.Count)];

            int[][] table = GenarateLogicTable(random);
            string answ = "";

            foreach (var line in table)
            {
                int a = line[0];
                int b = line[1];
                int c = line[2];
                int f = line[3];
                if (f == 0)
                {
                    answ += "(";
                    answ += a == 0 ? $"{letterA}" : $"-{letterA}";
                    answ += "v";
                    answ += b == 0 ? $"{letterB}" : $"-{letterB}";
                    answ += "v";
                    answ += c == 0 ? $"{letterC}" : $"-{letterC}";
                    answ += ")&";
                }
            }
            answ = answ.Substring(0, answ.Length - 1);

            var total = 0;



            if (answers.TryGetValue("Ax", out var userAnswer0) &&
                userAnswer0.ToLower() == answ.ToLower())
            {
                total++;
            }

            return total;
        }
        private int[][] GenarateLogicTable(Random random)
        {
            int Va = random.Next(3, 7);
            int[] final = new int[8];

            //генерация массива Nn из 0 и 1 рандомно
            for (int i = 0; i < Va; i++)
            {
                final[i] = 1;
            }
            for (int i = Va; i < 8; i++)
            {
                final[i] = 0;
            }
            for (int i = 0; i < final.Length; i++)
            {
                int j = random.Next(i, final.Length);
                (final[i], final[j]) = (final[j], final[i]);
            }
            //закончили 

            int[][] table = new int[8][];
            for (int i = 0; i < table.Length; i++)
            {
                table[i] = new int[4];
            }

            table[0][0] = 0; table[0][1] = 0; table[0][2] = 0; table[0][3] = final[0]; //генерация таблицы вида:
            table[1][0] = 0; table[1][1] = 0; table[1][2] = 1; table[1][3] = final[1]; //a b c | f
            table[2][0] = 0; table[2][1] = 1; table[2][2] = 0; table[2][3] = final[2]; //0 0 0 | 0
            table[3][0] = 0; table[3][1] = 1; table[3][2] = 1; table[3][3] = final[3]; //0 0 1 | 1
            table[4][0] = 1; table[4][1] = 0; table[4][2] = 0; table[4][3] = final[4];
            table[5][0] = 1; table[5][1] = 0; table[5][2] = 1; table[5][3] = final[5];
            table[6][0] = 1; table[6][1] = 1; table[6][2] = 0; table[6][3] = final[6];
            table[7][0] = 1; table[7][1] = 1; table[7][2] = 1; table[7][3] = final[7];
            return table;
        }
        public string Text { get; set; }
        public string[] CheckBoxes { get; set; }
        public List<MemoryStream> Pictures { get; set; }
    }
}
