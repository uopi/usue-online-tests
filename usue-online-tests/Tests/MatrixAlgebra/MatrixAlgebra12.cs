using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using Test_Wrapper;

namespace usue_online_tests.Tests.PolynomA
{
    public class MatrixAlgebra12 : ITestCreator, ITest, ITestGroup, ITimeLimit
    {
        public int TestID { get; set; }
        public string Name { get; } = "Детерминант02";
        public string Description { get; } = "Уравнение для детерминанта матрицы";
        public int TimeLimitSeconds { get; set; } = 120;
        public string GroupName { get; set; } = "Matrix Algebra";
        public char[] LetterA = { 'p', 'q', 'r', 'x', 'y', 'z', 't' };
        public ITest CreateTest(int randomSeed)
        {
            var random = new Random(randomSeed);
            int[] values = GenerateNum(random);

            int Ax = values[0];
            int Ay = values[1];
            int Bx = values[3];
            int By = values[4];
            int Az = values[2];
            int Dx = values[7];
            int Cy = values[6];
            int Cx = values[5];
            char letterA = LetterA[random.Next(0, LetterA.Length)];

            ITest result = new MatrixAlgebra12();
            result.Text =
                $"Решите уравнение, вычислив детерминант матрицы разложением по {Dx}-й строке (или по {Dx}-му столбцу)\n" +
                $" \\(\\begin{{vmatrix}}" +
                $"{Ax}-{letterA} & {Ay} \\\\" +
                $"{Bx} & {By}-{letterA} \\\\" +
                $"\\end{{vmatrix}} = {Az}\\)\n" +
                $"\\(<answ0:5> \\cdot {letterA}^{{2}} + <answ1:5>\\cdot \\: {letterA} \\: + <answ2:5>={Az}\\),\n " +
                $"\\( {letterA}\\in\\{{<Cx:5>, <Cy:5>\\}}\\), корни перечислите в порядке возрастания";
            return result;
        }

        public int CheckAnswer(int randomSeed, Dictionary<string, string> answers)
        {
            int total = 0;

            var random = new Random(randomSeed);
            int[] answer = GenerateNum(random);
            int Ax = answer[0];
            int Ay = answer[1];
            int Bx = answer[3];
            int By = answer[4];
            int Cy = answer[6];
            int Cx = answer[5];

            if (answers.TryGetValue("answ0", out var userAnswer0) &&
                int.TryParse(userAnswer0, out var userNumber0) &&
                userNumber0 == 1)
            {
                total++;
            }
            if (answers.TryGetValue("answ1", out var userAnswer1) &&
                int.TryParse(userAnswer1, out var userNumber1) &&
                userNumber1 == -Ax - By)
            {
                total++;
            }
            if (answers.TryGetValue("answ2", out var userAnswer2) &&
                int.TryParse(userAnswer2, out var userNumber2) &&
                userNumber2 == Ax * By - Ay * Bx)
            {
                total++;
            }
            if (answers.TryGetValue("Cx", out var userAnswer3) &&
                int.TryParse(userAnswer3, out var userNumber3) &&
                userNumber3 == Cx)
            {
                total++;
            }
            if (answers.TryGetValue("Cy", out var userAnswer4) &&
                int.TryParse(userAnswer4, out var userNumber4) &&
                userNumber4 == Cy)
            {
                total++;
            }

            return total;
        }

        private int[] GenerateNum(Random random)
        {
                                                          // 0   1  2 3  4  5  6  7
            List<int> values = new() { -9, -8, -7, -6, -5, -4, -3, -2, 2, 3, 4, 5, 6, 7, 8, 9 }; // Ax Ay Az Bx By Cx Cy Dx
            int Cx = values[random.Next(0, values.Count)];
            values.Remove(Cx);
            int Cy = values[random.Next(0, values.Count)];
            values.Remove(Cy);
            if (Cx > Cy) (Cx, Cy) = (Cy, Cx);
            int Ax = values[random.Next(0, values.Count)];
            values.Remove(Ax);
            int Ay = values[random.Next(0, values.Count)];
            values.Remove(Ay);
            int Bx = values[random.Next(0, values.Count)];
            values.Remove(Bx);
            int By = Cx + Cy - Ax;
            int Az = (Ax * By - Ay * Bx) - Cx * Cy;
            int Dx = random.Next(1, 3);
            int[] final = { Ax, Ay, Az, Bx, By, Cx, Cy, Dx};
            return final;
        }
        public string Text { get; set; }
        public string[] CheckBoxes { get; set; }
        public List<MemoryStream> Pictures { get; set; }
    }
}
