using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using Test_Wrapper;

namespace usue_online_tests.Tests.PolynomA
{
    public class MatrixAlgebra16 : ITestCreator, ITest, ITestGroup, ITimeLimit
    {
        public int TestID { get; set; }
        public string Name { get; } = "Детерминант произведения матриц02";
        public string Description { get; } = "Детерминант произведения матриц1";
        public string GroupName { get; set; } = "Matrix Algebra";
        public int TimeLimitSeconds { get; set; } = 120;
        public ITest CreateTest(int randomSeed)
        {
            var random = new Random(randomSeed);//  0   1   2   3   4    5  6   7    8  9   10  11  12  13  14  15  16
            int[] values = GenerateNum(random); //  Ax, Ay, Bx, By, Cx, Cy, Cz, Dx, Dy, Az, Bz, Ex, Ey, Gx, Gy, Fx, Fy 
            int Ax = values[0];
            int Ay = values[1];
            int Bx = values[2];
            int By = values[3];
            int Cx = values[4];
            int Cy = values[5];
            int Dx = values[7];
            int Dy = values[8];
            int Az = values[9];
            int Bz = values[10];
            int Ex = values[11];
            int Ey = values[12];
            int Gx = values[13];
            int Gy = values[14];
            int Fx = values[15];
            int Fy = values[16];

            ITest result = new MatrixAlgebra16();
            result.CheckBoxes = new string[] { "Да, всегда", "Да, для невырожденных матриц", "Да, для квадратных матриц", "Нет, никогда" };
            result.Text =
                $"\\(\\begin{{vmatrix}}" +
                $"\\left( \\begin{{array}}{{ccc}}" +
                $"{Ax} & {Ay} & {Az}\\\\" +
                $"{Bx} & {By} & {Bz}\\\\" +
                $"\\end{{array}}\\right) \\cdot " +
                $"\\left( \\begin{{array}}{{cc}}" +
                $"{Cx} & {Cy} \\\\" +
                $"{Dx} & {Dy} \\\\" +
                $"{Ex} & {Ey}" +
                $"\\end{{array}}\\right)\\end{{vmatrix}}" +
                $"\\hspace{{3pt}}=\\hspace{{3pt}}" +
                $"\\begin{{vmatrix}}" +
                $"{Gx} & {Gy} \\\\" +
                $"{Fx} & {Fy}" +
                $"\\end{{vmatrix}}" +
                $"\\hspace{{5pt}}= " +
                $"<Cz:3>\\),\n\n" +

                "Верно ли в общем случае, что детерминант произведения матриц равен произведению детерминантов (отметьте щелчком мыши на соответствующем поле для ввода)";

            ////отладка
            //int Cz = values[6];
            //Console.WriteLine($"Cz={Cz}");

            return result;
        }

        public int CheckAnswer(int randomSeed, Dictionary<string, string> answers)
        {
            int total = 0;

            var random = new Random(randomSeed);//   0   1   2   3   4  5    6   7  8    9  10  11  12  13  14  15  16
            int[] values = GenerateNum(random); //  Ax, Ay, Bx, By, Cx, Cy, Cz, Dx, Dy, Az, Bz, Ex, Ey, Gx, Gy, Fx, Fy 

            int Cz = values[6];

            if (answers.TryGetValue("Cz", out var userAnswer0) &&
                int.TryParse(userAnswer0, out var userNumber0) &&
                userNumber0 == Cz)
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
            int Dx = values[random.Next(0, values.Count)];
            values.Remove(Dx);
            int Dy = values[random.Next(0, values.Count)];
            values.Remove(Dy);
            int Ex = values[random.Next(0, values.Count)];
            values.Remove(Ex);
            int Ey = values[random.Next(0, values.Count)];
            values.Remove(Ey);
            
            int Gx = Ax * Cx + Ay * Dx + Az * Ex;
            int Gy = Ax * Cy + Ay * Dy + Az * Ey;
            int Fx = Bx * Cx + By * Dx + Bz * Ex;
            int Fy = Bx * Cy + By * Dy + Bz * Ey;
            int Cz = Gx * Fy - Gy * Fx;

            if (Gx * Fx - Gy * Fx == 0) Bx = 10 - Math.Abs(Ax);

            return new int[] { Ax, Ay, Bx, By, Cx, Cy, Cz, Dx, Dy, Az, Bz, Ex, Ey, Gx, Gy, Fx, Fy };
        }
        public string Text { get; set; }
        public string[] CheckBoxes { get; set; }
        public List<MemoryStream> Pictures { get; set; }
    }
}
