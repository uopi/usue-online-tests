using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using Test_Wrapper;

namespace usue_online_tests.Tests.PolynomA
{
    public class MatrixAlgebra12 : ITestCreator, ITest, ITestGroup
    {
        public int TestID { get; set; }
        public string Name { get; } = "Детерминант02";
        public string Description { get; } = "Уравнение для детерминанта матрицы";
        public string GroupName { get; set; } = "Matrix Algebra";
        public char[] LetterA = { 'p', 'q', 'r', 'x', 'y', 'z', 't' };
        public ITest CreateTest(int randomSeed)
        {
            var random = new Random();
            int[] values = GenerateNum(random);
            while (values.Length <= 0) values = GenerateNum(random);

            int Ax = values[0];
            int Ay = values[1];
            int Bx = values[3];
            int By = values[4];
            int Az = values[2];
            int Dx = values[7];
            char letterA = LetterA[random.Next(0, LetterA.Length)];

            ITest result = new MatrixAlgebra11();
            result.Text = $@"Решите уравнение, вычислив детерминант матрицы разложением по {Dx}-й строке (или по {Dx}-му столбцу)
                \(
                \begin{{vmatrix}}
                {Ax}-{letterA} & {Ay}  \\
                {Bx} & {By}-{letterA}  \\
                \end{{vmatrix}}
                \;=\;
                {Az}\n\cdot\begin{{vmatrix}}<x2:5>&<x3:5>\\<x4:5>&<x5:5>\end{{vmatrix}}
                - <x6:5>\cdot\begin{{vmatrix}}<x7:5>&<x8:5>\\<x9:5>&<x10:5>\end{{vmatrix}}
                + <x11:5>\cdot\begin{{vmatrix}}<x12:5>&<x13:5>\\<x14:5>&<x15:5>\end{{vmatrix}}
                = <xFinal:5>
                \)";

            result.Text = result.Text.Replace("-  -", "+");
            result.Text = result.Text.Replace("- -", "+");

            return result;
        }

        public int CheckAnswer(int randomSeed, Dictionary<string, string> answers)
        {
            int total = 0;

            var random = new Random(randomSeed);
            int[] answer = GenerateNum(random);
            while (answer.Length <= 0)
            {
                answer = GenerateNum(random);
            }

            char letterA = LetterA[random.Next(0, LetterA.Length)];

            switch (Dx)
            {
                case 1:
                    {
                        break;
                    }
                case 2:
                    {
                        break;
                    }
                case 3:
                    {
                        break;
                    }
                default: break;
            }

            //if (answers.TryGetValue("Ca", out var userAnswer0) &&
            //    int.TryParse(userAnswer0, out var userNumber0) &&
            //    userNumber0 == Ca)
            //{
            //    total++;
            //}

            return total;
        }

        private int[] GenerateNum(Random random)
        {
            int[] final = [8];                                                // 0   1  2 3  4  5  6  7
            List<int> Values = new() { -9, -8, -7, -6, -5, -4, -3, -2, 2, 3, 4, 5, 6, 7, 8, 9 }; // Ax Ay Az Bx By Cx Cy Dx
            int Cx = Values[random.Next(0, Values.Count)];
            Values.Remove(Cx);
            int Cy = Values[random.Next(0, Values.Count)];
            Values.Remove(Cy);
            if (Cx > Cy) return[];
            int Ax = Values[random.Next(0, Values.Count)];
            Values.Remove(Ax);
            int Ay = Values[random.Next(0, Values.Count)];
            Values.Remove(Ay);
            int Bx = Values[random.Next(0, Values.Count)];
            Values.Remove(Bx);
            int By = Cx + Cy - Ax;
            int Az = (Ax * By - Ay * Bx) - Cx * Cy;
            int Dx = random.Next(1, 4);

            final[0] = Ax;
            final[1] = Ay;
            final[2] = Az;
            final[3] = Bx;
            final[4] = By;
            final[5] = Cx;
            final[6] = Cy;
            final[7] = Dx;
            return final;
        }
        public string Text { get; set; }
        public string[] CheckBoxes { get; set; }
        public List<MemoryStream> Pictures { get; set; }
    }
}
