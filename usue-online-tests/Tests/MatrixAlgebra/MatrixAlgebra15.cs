using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using Test_Wrapper;

namespace usue_online_tests.Tests.PolynomA
{
    public class MatrixAlgebra15 : ITestCreator, ITest, ITestGroup, ITimeLimit
    {
        public int TestID { get; set; }
        public string Name { get; } = "Детерминант произведения матриц02";
        public string Description { get; } = "Детерминант произведения матриц";
        public string GroupName { get; set; } = "Matrix Algebra";
        public int TimeLimitSeconds { get; set; } = 120;
        public ITest CreateTest(int randomSeed)
        {
            var random = new Random(randomSeed);
            int[] values = GenerateNum(random); // Ax, Ay, Bx, By, Cx, Cy, Dx, Dy, Bz, Cz, Ex, Ey, Fx, Fy, Az 
            int Ax = values[0];
            int Ay = values[1];
            int Bx = values[2];
            int By = values[3];
            int Cx = values[4];
            int Cy = values[5];
            int Dx = values[6];
            int Dy = values[7];
            int Ex = values[10];
            int Ey = values[11];
            int Fx = values[12];
            int Fy = values[13];

            List<char> letters = new() { 'p', 'q', 'r', 'x', 'y', 'z', 't' };
            char letterA = letters[random.Next(0, letters.Count)];
            letters.Remove(letterA);
            char letterB = letters[random.Next(0, letters.Count)];


            ITest result = new MatrixAlgebra15();
            result.CheckBoxes = new string[] { "Да", "Нет" };
            result.Text =
                $"\\(\\begin{{vmatrix}}" +
                $"\\left( \\begin{{array}}{{cc}}" +
                $"{Ax} & {Ay} \\\\" +
                $"{Bx} & {By} \\\\" +
                $"\\end{{array}}\\right) \\cdot " +
                $"\\left( \\begin{{array}}{{cc}}" +
                $"{Cx} & {Cy} \\\\" +
                $"{Dx} & {Dy}" +
                $"\\end{{array}}\\right)\\end{{vmatrix}}" + 
                $"\\hspace{{3pt}}=\\hspace{{3pt}}" +
                $"\\begin{{vmatrix}}" +
                $"{Ex} & {Ey} \\\\" +
                $"{Fx} & {Fy}" +
                $"\\end{{vmatrix}}" +
                $"\\hspace{{5pt}}= " +
                $"<Az:3>\\),\n\n" +

                $"\\(\\begin{{vmatrix}}" +
                $"{Ax} & {Ay} \\\\" +
                $"{Bx} & {By} \\\\" +
                $"\\end{{vmatrix}}\\) = \\(<Bz:3>\\),\\(\\hspace{{2em}}\\)" +
                $"\\(\\begin{{vmatrix}}" +
                $"{Cx} & {Cy} \\\\" +
                $"{Dx} & {Dy}" +
                $"\\end{{vmatrix}}\\) = \\(<Cz:3>\\).\n\n" +

                $"Верно ли в общем случае, что (отметьте щелчком мыши на соответствующем поле для ввода)\n" +
                $"\\(\\begin{{vmatrix}}" +
                $"\\left(\\begin{{array}}{{cc}}" +
                $"{letterA}_{{11}} & {letterA}_{{12}} \\\\" +
                $"{letterA}_{{21}} & {letterA}_{{22}}" +
                $"\\end{{array}}\\right) \\cdot" +
                $"\\left(\\begin{{array}}{{cc}}" +
                $"{letterB}_{{11}} & {letterB}_{{12}} \\\\" +
                $"{letterB}_{{21}} & {letterB}_{{22}}" +
                $"\\end{{array}}\\right)" +
                $"\\end{{vmatrix}}" +
                $"\\hspace{{5pt}}=\\hspace{{5pt}}" +
                $"\\begin{{vmatrix}}" +
                $"{letterA}_{{11}} & {letterA}_{{12}} \\\\" +
                $"{letterA}_{{21}} & {letterA}_{{22}}" +
                $"\\end{{vmatrix}}" +
                $"\\hspace{{3pt}}\\cdot\\hspace{{3pt}}" +
                $"\\begin{{vmatrix}}" +
                $"{letterB}_{{11}} & {letterB}_{{12}} \\\\" +
                $"{letterB}_{{21}} & {letterB}_{{22}}" +
                $"\\end{{vmatrix}}\\).";

            //отладка
            int Az = values[14];
            int Bz = values[8];
            int Cz = values[9];
            Console.WriteLine($"Az={Az}, Bz={Bz}, Cz={Cz}");
            return result;
        }

        public int CheckAnswer(int randomSeed, Dictionary<string, string> answers)
        {
            int total = 0;

            var random = new Random(randomSeed);// 0   1   2    3   4  5    6   7  8    9  10  11   12 13  14
            int[] values = GenerateNum(random); // Ax, Ay, Bx, By, Cx, Cy, Dx, Dy, Bz, Cz, Ex, Ey, Fx, Fy, Az 


            int Az = values[14];
            int Bz = values[8];
            int Cz = values[9];

            if (answers.TryGetValue("Az", out var userAnswer0) &&
                int.TryParse(userAnswer0, out var userNumber0) &&
                userNumber0 == Az)
            {
                total++;
            }
            if (answers.TryGetValue("Bz", out var userAnswer1) &&
                int.TryParse(userAnswer1, out var userNumber1) &&
                userNumber1 == Bz)
            {
                total++;
            }
            if (answers.TryGetValue("Cz", out var userAnswer2) &&
                int.TryParse(userAnswer2, out var userNumber2) &&
                userNumber2 == Cz)
            {
                total++;
            }
            if (answers.TryGetValue("Да", out var userAnswer3) &&
                userAnswer3 == "on")
            {
                total+=2;
            }
            if (answers.TryGetValue("Нет", out var userAnswer4) &&
                userAnswer4 == "on")
            {
                total = total == 0 ? 0 : total-1;
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
            int Bx = values[random.Next(0, values.Count)];
            values.Remove(Bx);
            int By = values[random.Next(0, values.Count)];
            values.Remove(By);
            int Cx = values[random.Next(0, values.Count)];
            values.Remove(Cx);
            int Cy = values[random.Next(0, values.Count)];
            values.Remove(Cy);
            int Dx = values[random.Next(0, values.Count)];
            values.Remove(Dx);
            int Dy = values[random.Next(0, values.Count)];
            values.Remove(Dy);

            if (Ax * By - Ay * Bx == 0) Bx = 10 - Math.Abs(Ax);
            if (Cx * Dy - Cy * Dx == 0) Dy = 10 - Math.Abs(Ax);
            
            int Bz = Ax * By - Ay * Bx;
            int Cz = Cx * Dy - Cy * Dx;
            int Ex = Ax * Cx + Ay * Dx;
            int Ey = Ax * Cy + Ay * Dy;
            int Fx = Bx * Cx + By * Dx;
            int Fy = Bx * Cy + By * Dy;
            int Az = Ex * Fy - Ey * Fx;

            return new int[] { Ax, Ay, Bx, By, Cx, Cy, Dx, Dy, Bz, Cz, Ex, Ey, Fx, Fy, Az };
        }
        public string Text { get; set; }
        public string[] CheckBoxes { get; set; }
        public List<MemoryStream> Pictures { get; set; }
    }
}
