using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using Test_Wrapper;

namespace usue_online_tests.Tests.PolynomA
{
    public class MatrixAlgebra18 : ITestCreator, ITest, ITestGroup, ITimeLimit
    {
        public int TestID { get; set; }
        public string Name { get; } = "Детерминант произведения матрицы на число01";
        public string Description { get; } = "Детерминант произведения матрицы на число";
        public string GroupName { get; set; } = "Matrix Algebra";
        public int TimeLimitSeconds { get; set; } = 120;
        public ITest CreateTest(int randomSeed)
        {
            var random = new Random(randomSeed);  //  0   1   2  3    4   5  6
            int[] values = GenerateNum(random);   // Ax, Ay, Az, Bx, By, Bz, Cz

            int Ax = values[0];
            int Ay = values[1];
            int Az = values[2];
            int Bx = values[3];
            int By = values[4];
            int Bz = values[5];
            int Cz = values[6];

            ITest result = new MatrixAlgebra18();
            result.Text =
                $"\\(\\begin{{array}}{{|cc|}}" +
                $"{Az}\\cdot{Ax} & {Az}\\cdot{Ay} \\\\" +
                $"{Az}\\cdot{Bx} & {Az}\\cdot{By}" +
                $"\\end{{array}}\\hspace{{5pt}}=\\hspace{{5pt}}<Cz:3>" +
                $"\\hspace{{5pt}}=\\hspace{{5pt}}<Az:3>\\cdot\\hspace{{5pt}}" +
                $"\\begin{{array}}{{|cc|}}" +
                $"{Ax} & {Ay} \\\\" +
                $"{Bx} & {By}" +
                $"\\end{{array}}\\)\n\n "+
                $"\\(\\begin {{array}}{{|cc|}}" +
                $"{Ax} & {Ay} \\\\" +
                $"{Bx} & {By}" +
                $"\\end{{array}}\\hspace{{5pt}}=<Bz:3>\\)";

            //Console.WriteLine($"{Cz} {Az*Az} {Bz} ");


            return result;
        }

        public int CheckAnswer(int randomSeed, Dictionary<string, string> answers)
        {
            // Ax, Ay, Az, Bx, By, Bz, Cz
            int[] answer = GenerateNum(new Random(randomSeed));
            int Az = answer[2];
            int Bz = answer[5];
            int Cz = answer[6];
            int total = 0;

            if (answers.TryGetValue("Bz", out var userAnswer0) &&
                int.TryParse(userAnswer0, out var userNumber0) &&
                userNumber0 == Bz)
            {
                total++;
            }
            if (answers.TryGetValue("Cz", out var userAnswer1) &&
                int.TryParse(userAnswer1, out var userNumber1) &&
                userNumber1 == Cz)
            {
                total++;
            }
            if (answers.TryGetValue("Az", out var userAnswer2) &&
                int.TryParse(userAnswer2, out var userNumber2) &&
                userNumber2 == Az*Az)
            {
                total++;
            }


            return total;
        }

        private int[] GenerateNum(Random random)
        {
            List<int> values = new() { -9, -8, -7, -6, -5, -4, -3, -2, -1, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] listAz = { -6, -5, -4, -3, -2, 2, 3, 4, 5, 6 };

            int Ax = values[random.Next(0, values.Count)];
            values.Remove(Ax);
            int Ay = values[random.Next(0, values.Count)];
            values.Remove(Ay);
            
            int Bx = values[random.Next(0, values.Count)];
            values.Remove(Bx);
            int By = values[random.Next(0, values.Count)];
            values.Remove(By);
            int Bz = values[random.Next(0, values.Count)];
            values.Remove(Bz);
            int Cx = values[random.Next(0, values.Count)];
            values.Remove(Cx);
            int Cy = values[random.Next(0, values.Count)];
            values.Remove(Cy);
            int Dx = values[random.Next(0, values.Count)];
            values.Remove(Dx);
            int Dy = values[random.Next(0, values.Count)];
            values.Remove(Dy);
            int Ex = values[random.Next(0, values.Count)];
            values.Remove(Ex);
            int Ey = values[random.Next(0, values.Count)];
            values.Remove(Ey);

            int Az = listAz[random.Next(0, listAz.Length)];

            int Gx = Ax * Cx + Ay * Dx + Az * Ex;
            int Gy = Ax * Cy + Ay * Dy + Az * Ey;
            int Fx = Bx * Cx + By * Dx + Bz * Ex;
            int Fy = Bx * Cy + By * Dy + Bz * Ey;
            int Cz = Gx * Fy - Gy * Fx;

            if (Gx * Fy - Gy * Fx == 0) Bx = 10 - Math.Abs(Ax);

            return new int[] { Ax, Ay, Az, Bx, By, Bz, Cz};
        }
        public string Text { get; set; }
        public string[] CheckBoxes { get; set; }
        public List<MemoryStream> Pictures { get; set; }
    }
}
