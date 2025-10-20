using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using Test_Wrapper;

namespace usue_online_tests.Tests.PolynomA
{
    public class MatrixAlgebra17 : ITestCreator, ITest, ITestGroup, ITimeLimit
    {
        public int TestID { get; set; }
        public string Name { get; } = "Детерминант произведения матриц03";
        public string Description { get; } = "Детерминант произведения матриц1";
        public string GroupName { get; set; } = "Matrix Algebra";
        public int TimeLimitSeconds { get; set; } = 120;
        public ITest CreateTest(int randomSeed)
        {
            var random = new Random(randomSeed);// 0   1   2   3    4   5   6   7  8   9   10  11  12  13  14  15  16  17  18  19  20
            int[] values = GenerateNum(random); // Ax, Ay, Az, Bx, By, Bz, Cx, Cy, Cz, Dx, Dy, Dz, Ex, Ey, Ez, Fx, Fy, Fz, Gx, Gy, Gz

            int Ax = values[0];
            int Ay = values[1];
            int Az = values[2];
            int Bx = values[3];
            int By = values[4];
            int Bz = values[5];
            int Cx = values[6];
            int Cy = values[7];
            int Cz = values[8];
            int Dx = values[9];
            int Dy = values[10];
            int Dz = values[11];
            int Ex = values[12];
            int Ey = values[13];
            int Ez = values[14];
            int Fx = values[15];
            int Fy = values[16];
            int Fz = values[17];
            int Gx = values[18];
            int Gy = values[19];
            int Gz = values[20];

            ITest result = new MatrixAlgebra17();
            result.CheckBoxes = new string[] { "Да, всегда", "Да, для невырожденных матриц", "Да, для квадратных матриц", "Нет, никогда" };
            result.Text =
                $"\\(\\begin{{vmatrix}}" +
                $"\\left( \\begin{{array}}{{cc}}" +
                $"{Ax} & {Bx} \\\\" +
                $"{Ay} & {By} \\\\" +
                $"{Az} & {Bz}" +
                $"\\end{{array}}\\right) \\cdot " +
                $"\\left( \\begin{{array}}{{ccc}}" +
                $"{Cx} & {Cy} & {Cz}\\\\" +
                $"{Dx} & {Dy} & {Dz} \\\\" +
                $"\\end{{array}}\\right)\\end{{vmatrix}}" +
                $"\\hspace{{3pt}}=\\hspace{{3pt}}" +
                $"\\begin{{vmatrix}}" +
                $"{Ex} & {Ey} & {Ey} \\\\" +
                $"{Fx} & {Fy} & {Fy} \\\\" +
                $"{Gx} & {Gy} & {Gy} " +
                $"\\end{{vmatrix}}" +
                $"\\hspace{{5pt}}= " +
                $"<Cz:3>\\),\n\n" +

                "Верно ли в общем случае, что детерминант произведения матриц равен произведению детерминантов (отметьте щелчком мыши на соответствующем поле для ввода)";


            return result;
        }

        public int CheckAnswer(int randomSeed, Dictionary<string, string> answers)
        {
            int total = 0;

            if (answers.TryGetValue("Cz", out var userAnswer0) &&
                int.TryParse(userAnswer0, out var userNumber0) &&
                userNumber0 == 0)
            {
                total++;
            }
            if (answers.TryGetValue("Да, для квадратных матриц", out var userAnswer3) &&
                userAnswer3 == "on")
            {
                total+=4;
            }
            if (answers.TryGetValue("Да, всегда", out var userAnswer4) &&
                userAnswer4 == "on")
            {
                total = total == 0 ? 0 : total - 1;
            }
            if (answers.TryGetValue("Да, для невырожденных матриц", out var userAnswer5) &&
                userAnswer5 == "on")
            {
                total = total == 0 ? 0 : total - 1;
            }
            if (answers.TryGetValue("Нет, никогда", out var userAnswer6) &&
                userAnswer6 == "on")
            {
                total = total == 0 ? 0 : total - 1;
            }


            return total;
        }

        private int[] GenerateNum(Random random)
        {
            List<int> values = new() { -9, -8, -7, -6, -5, -4, -3, -2, -1, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            
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
            int Cx = values[random.Next(0, values.Count)];
            values.Remove(Cx);
            int Cy = values[random.Next(0, values.Count)];
            values.Remove(Cy);
            int Cz = values[random.Next(0, values.Count)];
            values.Remove(Cz);
            int Dx = values[random.Next(0, values.Count)];
            values.Remove(Dx);
            int Dy = values[random.Next(0, values.Count)];
            values.Remove(Dy);
            int Dz = values[random.Next(0, values.Count)];
            values.Remove(Dz);
            
            int Ex = Ax * Cx + Bx * Dx;
            int Ey = Ax * Cy + Bx * Dy;
            int Ez = Ax * Cz + Bx * Dz;
            int Fx = Ay * Cx + By * Dx;
            int Fy = Ay * Cy + By * Dy;
            int Fz = Ay * Cz + By * Dz;
            int Gx = Az * Cx + Bz * Dx;
            int Gy = Az * Cy + Bz * Dy;
            int Gz = Az * Cz + Bz * Dz;

            if (Gx * Fy - Gy * Fx == 0) Bx = 10 - Math.Abs(Ax);

            return new int[] { Ax, Ay, Az, Bx, By, Bz, Cx, Cy, Cz, Dx, Dy, Dz, Ex, Ey, Ez, Fx, Fy, Fz, Gx, Gy, Gz };
        }
        public string Text { get; set; }
        public string[] CheckBoxes { get; set; }
        public List<MemoryStream> Pictures { get; set; }
    }
}
