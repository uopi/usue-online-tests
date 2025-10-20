using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using Test_Wrapper;

namespace usue_online_tests.Tests.PolynomA
{
    public class MatrixAlgebra13 : ITestCreator, ITest, ITestGroup, ITimeLimit
    {
        public int TestID { get; set; }
        public string Name { get; } = "Детерминант01";
        public string Description { get; } = "Детерминант матрицы1";
        public string GroupName { get; set; } = "Matrix Algebra";
        public int TimeLimitSeconds { get; set; } = 120;
        public ITest CreateTest(int randomSeed)
        {
            var random = new Random(randomSeed);
            int[] values = GenerateNum(random); //Ax, Ay, Az, Bx, By, Bz, Fx, Fy, Fz, Cy, Cz, Dy, Dz, Ey, Ez

            int Ax = values[0];
            int Ay = values[1];
            int Az = values[2];
            int Bx = values[3];
            int By = values[4];
            int Bz = values[5];
            int Fx = values[6];
            int Fy = values[7];
            int Fz = values[8];
            int Cy = values[9];
            int Cz = values[10];
            int Dy = values[11];
            int Dz = values[12];
            int Ey = values[13];
            int Ez = values[14];
            int Dx = values[15];

            ITest result = new MatrixAlgebra13();
            result.Text =
                $"Решите уравнение, вычислив детерминант матрицы разложением по {Dx}-й строке (или по {Dx}-му столбцу)\n" +
                $" \\(\\begin{{vmatrix}}" +
                $"{Ax} & {Ay} & {Az} \\\\" +
                $"{Fy * Ax} & {Dy} & {Dz} \\\\" +
                $"{Fz * Ax} & {Ey} & {Ez} \\\\" +
                $"\\end{{vmatrix}} = \\begin{{vmatrix}}" +
                $"{Ax} & {Bx} & {By} \\\\" +
                $"0 & <Ay:3> & <Bz:3> \\\\" +
                $"0 & <Cy:3> & <Cz:3>\\\\" +
                $"\\end{{vmatrix}} = \\begin{{vmatrix}}" +
                $"{Ax} & {Bx} & {By} \\\\" +
                $"0 & {Ay} & <Bz1:3> \\\\" +
                $"0 & 0 & <Az:3>\\\\" +
                $"\\end{{vmatrix}} = <answ0:3>" +
                $"\\)";
            return result;
        }

        public int CheckAnswer(int randomSeed, Dictionary<string, string> answers)
        {
            int total = 0;

            var random = new Random(randomSeed);
            int[] values = GenerateNum(random); //Ax, Ay, Az, Bx, By, Bz, Fx, Fy, Fz, Cy, Cz, Dy, Dz, Ey, Ez

            int Ax = values[0];
            int Ay = values[1];
            int Az = values[2];
            int Bz = values[5];
            int Cy = values[9];
            int Cz = values[10];

            if (answers.TryGetValue("Ay", out var userAnswer0) &&
                int.TryParse(userAnswer0, out var userNumber0) &&
                userNumber0 == Ay)
            {
                total++;
            }
            if (answers.TryGetValue("Bz", out var userAnswer1) &&
                int.TryParse(userAnswer1, out var userNumber1) &&
                userNumber1 == Bz)
            {
                total++;
            }
            if (answers.TryGetValue("Cy", out var userAnswer2) &&
                int.TryParse(userAnswer2, out var userNumber2) &&
                userNumber2 == Cy)
            {
                total++;
            }
            if (answers.TryGetValue("Cz", out var userAnswer3) &&
                int.TryParse(userAnswer3, out var userNumber3) &&
                userNumber3 == Cz)
            {
                total++;
            }
            if (answers.TryGetValue("Bz1", out var userAnswer4) &&
                int.TryParse(userAnswer4, out var userNumber4) &&
                userNumber4 == Bz)
            {
                total++;
            }
            if (answers.TryGetValue("Az", out var userAnswer6) &&
                int.TryParse(userAnswer6, out var userNumber6) &&
                userNumber6 == Az)
            {
                total++;
            }
            if (answers.TryGetValue("answ0", out var userAnswer5) &&
                int.TryParse(userAnswer5, out var userNumber5) &&
                userNumber5 == Ax * Ay * Az )
            {
                total++;
            }

            return total;
        }

        private int[] GenerateNum(Random random)
        {
            List<int> values = new() { -9, -8, -7, -6, -5, -4, -3, -2, 2, 3, 4, 5, 6, 7, 8, 9 };
            
            int Ax = values[random.Next(0, values.Count)];
            values.Remove(Ax);
            int Ay = values[random.Next(0, values.Count)];
            values.Remove(Ay);
            int Az = values[random.Next(0, values.Count)];
            values.Remove(Az);
            int Bx = values[random.Next(0, values.Count)];
            values.Remove(Bx);
            int By = values[random.Next(0, values.Count)];
            values.Remove(By);
            int Bz = values[random.Next(0, values.Count)];
            values.Remove(Bz);

            values = new() { -5, -4, -3, -2, -1, 2, 3, 4, 5 };
            int Fx = values[random.Next(0, values.Count)];
            values.Remove(Fx);
            int Fy = values[random.Next(0, values.Count)];
            values.Remove(Fy);
            int Fz = values[random.Next(0, values.Count)];
            values.Remove(Fz);

            int Cy = Fx * Ay;
            int Cz = Az + Fx * Bz;
            int Dy = Ay + Fy * Ay;
            int Dz = Bz + Fy * Az;
            int Ey = Cy + Fz * Ay;
            int Ez = Cz + Fz * Az;

            int Dx = random.Next(1, 4);
            return new int[] { Ax, Ay, Az, Bx, By, Bz, Fx, Fy, Fz, Cy, Cz, Dy, Dz, Ey, Ez, Dx };
        }
        public string Text { get; set; }
        public string[] CheckBoxes { get; set; }
        public List<MemoryStream> Pictures { get; set; }
    }
}
