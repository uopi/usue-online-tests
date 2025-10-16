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
        public ITest CreateTest(int randomSeed)
        {
            var random = new Random(randomSeed);
            List<int> Values = new() { -9, -8, -7, -6, -5, -4, -3, -2, 2, 3, 4, 5, 6, 7, 8, 9 };
            int Ax = Values[random.Next(0, Values.Count)];
            Values.Remove(Ax);
            int Ay = Values[random.Next(0, Values.Count)];
            Values.Remove(Ay);
            int Az = Values[random.Next(0, Values.Count)];
            Values.Remove(Az);
            int Bx = Values[random.Next(0, Values.Count)];
            Values.Remove(Bx);
            int By = Values[random.Next(0, Values.Count)];
            Values.Remove(By);
            int Bz = Values[random.Next(0, Values.Count)];
            Values.Remove(Bz);
            int Cx = Values[random.Next(0, Values.Count)];
            Values.Remove(Cx);
            int Cy = Values[random.Next(0, Values.Count)];
            Values.Remove(Cy);
            int Cz = Values[random.Next(0, Values.Count)];
            Values.Remove(Cz);
            int Dx = random.Next(1, 4);
            ITest result = new MatrixAlgebra11();

            result.Text = $@"Решите уравнение, вычислив детерминант матрицы разложением по {Dx}-й строке (или по {Dx}-му столбцу)
                \(
                \begin{{vmatrix}}
                {Ax}-{letterA} & {Ay}  \\
                {Bx} & {By}-{letterA}  \\
                \end{{vmatrix}}
                \;=\;
                <x1:5>\cdot\begin{{vmatrix}}<x2:5>&<x3:5>\\<x4:5>&<x5:5>\end{{vmatrix}}
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
            List<int> Values = new() { -9, -8, -7, -6, -5, -4, -3, -2, 2, 3, 4, 5, 6, 7, 8, 9 };
            int Ax = Values[random.Next(0, Values.Count)];
            Values.Remove(Ax);
            int Ay = Values[random.Next(0, Values.Count)];
            Values.Remove(Ay);
            int Az = Values[random.Next(0, Values.Count)];
            Values.Remove(Az);
            int Bx = Values[random.Next(0, Values.Count)];
            Values.Remove(Bx);
            int By = Values[random.Next(0, Values.Count)];
            Values.Remove(By);
            int Bz = Values[random.Next(0, Values.Count)];
            Values.Remove(Bz);
            int Cx = Values[random.Next(0, Values.Count)];
            Values.Remove(Cx);
            int Cy = Values[random.Next(0, Values.Count)];
            Values.Remove(Cy);
            int Cz = Values[random.Next(0, Values.Count)];
            Values.Remove(Cz);
            int Dx = random.Next(1, 4);
            // x1 x6 x11

            int x1 = answers.TryGetValue("x1", out var value) && int.TryParse(value, out var _value) ? _value : 0;
            int x6 = answers.TryGetValue("x6", out var value1) && int.TryParse(value1, out var _value1) ? _value1 : 0;
            int x11 = answers.TryGetValue("x11", out var value2) && int.TryParse(value2, out var _value2) ? _value2 : 0;

            switch (Dx)
            {
                case 1:
                    {
                        if (x1 == Ax && x6 == Ay && x11 == Az)
                        {

                            if (answers.TryGetValue("x1", out var userAnswer0) &&
                                int.TryParse(userAnswer0, out var userNumber0) &&
                                userNumber0 == Ax)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x2", out var userAnswer1) &&
                                int.TryParse(userAnswer1, out var userNumber1) &&
                                userNumber1 == By)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x3", out var userAnswer14) &&
                                int.TryParse(userAnswer14, out var userNumber14) &&
                                userNumber14 == Bz)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x4", out var userAnswer2) &&
                                int.TryParse(userAnswer2, out var userNumber2) &&
                                userNumber2 == Cy)
                            {
                                total++;
                            }
                            
                            if (answers.TryGetValue("x5", out var userAnswer3) &&
                                int.TryParse(userAnswer3, out var userNumber3) &&
                                userNumber3 == Cz)
                            {
                                total++;
                            }

                            if (answers.TryGetValue("x6", out var userAnswer4) &&
                                int.TryParse(userAnswer4, out var userNumber4) &&
                                userNumber4 == Ay)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x7", out var userAnswer5) &&
                                int.TryParse(userAnswer5, out var userNumber5) &&
                                userNumber5 == Bx)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x8", out var userAnswer6) &&
                                int.TryParse(userAnswer6, out var userNumber6) &&
                                userNumber6 == Bz)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x9", out var userAnswer7) &&
                                int.TryParse(userAnswer7, out var userNumber7) &&
                                userNumber7 == Cz)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x10", out var userAnswer8) &&
                                int.TryParse(userAnswer8, out var userNumber8) &&
                                userNumber8 == Cz)
                            {
                                total++;
                            }

                            if (answers.TryGetValue("x11", out var userAnswer9) &&
                                int.TryParse(userAnswer9, out var userNumber9) &&
                                userNumber9 == Az)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x12", out var userAnswer10) &&
                                int.TryParse(userAnswer10, out var userNumber10) &&
                                userNumber10 == Bx)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x13", out var userAnswer11) &&
                                int.TryParse(userAnswer11, out var userNumber11) &&
                                userNumber11 == By)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x14", out var userAnswer12) &&
                                int.TryParse(userAnswer12, out var userNumber12) &&
                                userNumber12 == Cx)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x15", out var userAnswer13) &&
                                int.TryParse(userAnswer13, out var userNumber13) &&
                                userNumber13 == Cy)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("xFinal", out var userAnswer15) &&
                                int.TryParse(userAnswer15, out var userNumber15) &&
                                userNumber15 == (Ax * (By * Cz - Bz * Cy) - Ay * (Bx * Cz - Bz * Cx) + Az * (Bx * Cy - By * Cx)))
                            {
                                total++;
                            }
                        }
                        else
                        {
                            if (answers.TryGetValue("x1", out var userAnswer0) &&
                                int.TryParse(userAnswer0, out var userNumber0) &&
                                userNumber0 == Ax)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x2", out var userAnswer1) &&
                                int.TryParse(userAnswer1, out var userNumber1) &&
                                userNumber1 == By)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x4", out var userAnswer2) &&
                                int.TryParse(userAnswer2, out var userNumber2) &&
                                userNumber2 == Cy)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x3", out var userAnswer14) &&
                                int.TryParse(userAnswer14, out var userNumber14) &&
                                userNumber14 == Bz)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x5", out var userAnswer3) &&
                                int.TryParse(userAnswer3, out var userNumber3) &&
                                userNumber3 == Cz)
                            {
                                total++;
                            }

                            if (answers.TryGetValue("x6", out var userAnswer4) &&
                                int.TryParse(userAnswer4, out var userNumber4) &&
                                userNumber4 == Bx)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x7", out var userAnswer5) &&
                                int.TryParse(userAnswer5, out var userNumber5) &&
                                userNumber5 == Ay)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x8", out var userAnswer6) &&
                                int.TryParse(userAnswer6, out var userNumber6) &&
                                userNumber6 == Az)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x9", out var userAnswer7) &&
                                int.TryParse(userAnswer7, out var userNumber7) &&
                                userNumber7 == Cy)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x10", out var userAnswer8) &&
                                int.TryParse(userAnswer8, out var userNumber8) &&
                                userNumber8 == Cz)
                            {
                                total++;
                            }

                            if (answers.TryGetValue("x11", out var userAnswer9) &&
                                int.TryParse(userAnswer9, out var userNumber9) &&
                                userNumber9 == Cx)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x12", out var userAnswer10) &&
                                int.TryParse(userAnswer10, out var userNumber10) &&
                                userNumber10 == Ay)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x13", out var userAnswer11) &&
                                int.TryParse(userAnswer11, out var userNumber11) &&
                                userNumber11 == Az)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x14", out var userAnswer12) &&
                                int.TryParse(userAnswer12, out var userNumber12) &&
                                userNumber12 == By)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x15", out var userAnswer13) &&
                                int.TryParse(userAnswer13, out var userNumber13) &&
                                userNumber13 == Bz)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("xFinal", out var userAnswer15) &&
                                int.TryParse(userAnswer15, out var userNumber15) &&
                                userNumber15 == (Ax * (By * Cz - Bz * Cy) - Bx * (Ay * Cz - Az * Cy) + Cx * (Ay * Bz - Az * By)))
                            {
                                total++;
                            }

                        }
                        break;
                    }
                case 2:
                    {
                        if (x1 == Ay && x6 == By && x11 == Cy) //по столбику 
                        {
                            if (answers.TryGetValue("x1", out var userAnswer0) &&
                                int.TryParse(userAnswer0, out var userNumber0) &&
                                userNumber0 == Ay)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x2", out var userAnswer1) &&
                                int.TryParse(userAnswer1, out var userNumber1) &&
                                userNumber1 == Bx)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x3", out var userAnswer14) &&
                                int.TryParse(userAnswer14, out var userNumber14) &&
                                userNumber14 == Bz)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x4", out var userAnswer2) &&
                                int.TryParse(userAnswer2, out var userNumber2) &&
                                userNumber2 == Cx)
                            {
                                total++;
                            }

                            if (answers.TryGetValue("x5", out var userAnswer3) &&
                                int.TryParse(userAnswer3, out var userNumber3) &&
                                userNumber3 == Cz)
                            {
                                total++;
                            }

                            if (answers.TryGetValue("x6", out var userAnswer4) &&
                                int.TryParse(userAnswer4, out var userNumber4) &&
                                userNumber4 == By)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x7", out var userAnswer5) &&
                                int.TryParse(userAnswer5, out var userNumber5) &&
                                userNumber5 == Ax)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x8", out var userAnswer6) &&
                                int.TryParse(userAnswer6, out var userNumber6) &&
                                userNumber6 == Az)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x9", out var userAnswer7) &&
                                int.TryParse(userAnswer7, out var userNumber7) &&
                                userNumber7 == Cx)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x10", out var userAnswer8) &&
                                int.TryParse(userAnswer8, out var userNumber8) &&
                                userNumber8 == Cz)
                            {
                                total++;
                            }

                            if (answers.TryGetValue("x11", out var userAnswer9) &&
                                int.TryParse(userAnswer9, out var userNumber9) &&
                                userNumber9 == Cy)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x12", out var userAnswer10) &&
                                int.TryParse(userAnswer10, out var userNumber10) &&
                                userNumber10 == Ax)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x13", out var userAnswer11) &&
                                int.TryParse(userAnswer11, out var userNumber11) &&
                                userNumber11 == Az)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x14", out var userAnswer12) &&
                                int.TryParse(userAnswer12, out var userNumber12) &&
                                userNumber12 == Bx)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x15", out var userAnswer13) &&
                                int.TryParse(userAnswer13, out var userNumber13) &&
                                userNumber13 == Bz)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("xFinal", out var userAnswer15) &&
                                int.TryParse(userAnswer15, out var userNumber15) &&
                                userNumber15 == (Ay * (Bx * Cz - Bz * Cx) - By * (Ax * Cz - Az * Cx) + Cy * (Ax * Bz - Az * Bx)))
                            {
                                total++;
                            }
                        }
                        else //по строке
                        {
                            if (answers.TryGetValue("x1", out var userAnswer0) &&
                                int.TryParse(userAnswer0, out var userNumber0) &&
                                userNumber0 == Bx)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x2", out var userAnswer1) &&
                                int.TryParse(userAnswer1, out var userNumber1) &&
                                userNumber1 == Ay)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x3", out var userAnswer14) &&
                                int.TryParse(userAnswer14, out var userNumber14) &&
                                userNumber14 == Az)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x4", out var userAnswer2) &&
                                int.TryParse(userAnswer2, out var userNumber2) &&
                                userNumber2 == Cy)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x5", out var userAnswer3) &&
                                int.TryParse(userAnswer3, out var userNumber3) &&
                                userNumber3 == Cz)
                            {
                                total++;
                            }

                            if (answers.TryGetValue("x6", out var userAnswer4) &&
                                int.TryParse(userAnswer4, out var userNumber4) &&
                                userNumber4 == By)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x7", out var userAnswer5) &&
                                int.TryParse(userAnswer5, out var userNumber5) &&
                                userNumber5 == Ax)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x8", out var userAnswer6) &&
                                int.TryParse(userAnswer6, out var userNumber6) &&
                                userNumber6 == Az)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x9", out var userAnswer7) &&
                                int.TryParse(userAnswer7, out var userNumber7) &&
                                userNumber7 == Cx)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x10", out var userAnswer8) &&
                                int.TryParse(userAnswer8, out var userNumber8) &&
                                userNumber8 == Cz)
                            {
                                total++;
                            }

                            if (answers.TryGetValue("x11", out var userAnswer9) &&
                                int.TryParse(userAnswer9, out var userNumber9) &&
                                userNumber9 == Bz)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x12", out var userAnswer10) &&
                                int.TryParse(userAnswer10, out var userNumber10) &&
                                userNumber10 == Ax)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x13", out var userAnswer11) &&
                                int.TryParse(userAnswer11, out var userNumber11) &&
                                userNumber11 == Ay)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x14", out var userAnswer12) &&
                                int.TryParse(userAnswer12, out var userNumber12) &&
                                userNumber12 == Cx)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x15", out var userAnswer13) &&
                                int.TryParse(userAnswer13, out var userNumber13) &&
                                userNumber13 == Cy)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("xFinal", out var userAnswer15) &&
                                int.TryParse(userAnswer15, out var userNumber15) &&
                                userNumber15 == (Bx * (Ay * Cz - Az * Cy) - By * (Ax * Cz - Az * Cx) + Bz * (Ax * Cy - Ay * Cx)))
                            {
                                total++;
                            }
                        }
                        break;
                    }
                case 3:
                    {
                        if (x1 == Az && x6 == Bz && x11 == Cz) //по столбику
                        {
                            if (answers.TryGetValue("x1", out var userAnswer0) &&
                                int.TryParse(userAnswer0, out var userNumber0) &&
                                userNumber0 == Az)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x2", out var userAnswer1) &&
                                int.TryParse(userAnswer1, out var userNumber1) &&
                                userNumber1 == Bx)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x3", out var userAnswer14) &&
                                int.TryParse(userAnswer14, out var userNumber14) &&
                                userNumber14 == By)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x4", out var userAnswer2) &&
                                int.TryParse(userAnswer2, out var userNumber2) &&
                                userNumber2 == Cx)
                            {
                                total++;
                            }

                            if (answers.TryGetValue("x5", out var userAnswer3) &&
                                int.TryParse(userAnswer3, out var userNumber3) &&
                                userNumber3 == Cy)
                            {
                                total++;
                            }

                            if (answers.TryGetValue("x6", out var userAnswer4) &&
                                int.TryParse(userAnswer4, out var userNumber4) &&
                                userNumber4 == Bz)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x7", out var userAnswer5) &&
                                int.TryParse(userAnswer5, out var userNumber5) &&
                                userNumber5 == Ax)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x8", out var userAnswer6) &&
                                int.TryParse(userAnswer6, out var userNumber6) &&
                                userNumber6 == Ay)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x9", out var userAnswer7) &&
                                int.TryParse(userAnswer7, out var userNumber7) &&
                                userNumber7 == Cx)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x10", out var userAnswer8) &&
                                int.TryParse(userAnswer8, out var userNumber8) &&
                                userNumber8 == Cy)
                            {
                                total++;
                            }

                            if (answers.TryGetValue("x11", out var userAnswer9) &&
                                int.TryParse(userAnswer9, out var userNumber9) &&
                                userNumber9 == Cz)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x12", out var userAnswer10) &&
                                int.TryParse(userAnswer10, out var userNumber10) &&
                                userNumber10 == Ax)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x13", out var userAnswer11) &&
                                int.TryParse(userAnswer11, out var userNumber11) &&
                                userNumber11 == Ay)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x14", out var userAnswer12) &&
                                int.TryParse(userAnswer12, out var userNumber12) &&
                                userNumber12 == Bx)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x15", out var userAnswer13) &&
                                int.TryParse(userAnswer13, out var userNumber13) &&
                                userNumber13 == By)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("xFinal", out var userAnswer15) &&
                                int.TryParse(userAnswer15, out var userNumber15) &&
                                userNumber15 == (Az * (Bx * Cy - By * Cx) - Bz * (Ax * Cy - Ay * Cx) + Cz * (Ax * By - Ay * Bx)))
                            {
                                total++;
                            }
                        }
                        else
                        {
                            if (answers.TryGetValue("x1", out var userAnswer0) &&
                                int.TryParse(userAnswer0, out var userNumber0) &&
                                userNumber0 == Cx)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x2", out var userAnswer1) &&
                                int.TryParse(userAnswer1, out var userNumber1) &&
                                userNumber1 == Ay)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x3", out var userAnswer14) &&
                                int.TryParse(userAnswer14, out var userNumber14) &&
                                userNumber14 == Az)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x4", out var userAnswer2) &&
                                int.TryParse(userAnswer2, out var userNumber2) &&
                                userNumber2 == By)
                            {
                                total++;
                            }

                            if (answers.TryGetValue("x5", out var userAnswer3) &&
                                int.TryParse(userAnswer3, out var userNumber3) &&
                                userNumber3 == Bz)
                            {
                                total++;
                            }

                            if (answers.TryGetValue("x6", out var userAnswer4) &&
                                int.TryParse(userAnswer4, out var userNumber4) &&
                                userNumber4 == Cy)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x7", out var userAnswer5) &&
                                int.TryParse(userAnswer5, out var userNumber5) &&
                                userNumber5 == Ax)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x8", out var userAnswer6) &&
                                int.TryParse(userAnswer6, out var userNumber6) &&
                                userNumber6 == Az)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x9", out var userAnswer7) &&
                                int.TryParse(userAnswer7, out var userNumber7) &&
                                userNumber7 == Bx)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x10", out var userAnswer8) &&
                                int.TryParse(userAnswer8, out var userNumber8) &&
                                userNumber8 == Bz)
                            {
                                total++;
                            }

                            if (answers.TryGetValue("x11", out var userAnswer9) &&
                                int.TryParse(userAnswer9, out var userNumber9) &&
                                userNumber9 == Cz)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x12", out var userAnswer10) &&
                                int.TryParse(userAnswer10, out var userNumber10) &&
                                userNumber10 == Ax)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x13", out var userAnswer11) &&
                                int.TryParse(userAnswer11, out var userNumber11) &&
                                userNumber11 == Ay)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x14", out var userAnswer12) &&
                                int.TryParse(userAnswer12, out var userNumber12) &&
                                userNumber12 == Bx)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("x15", out var userAnswer13) &&
                                int.TryParse(userAnswer13, out var userNumber13) &&
                                userNumber13 == By)
                            {
                                total++;
                            }
                            if (answers.TryGetValue("xFinal", out var userAnswer15) &&
                                int.TryParse(userAnswer15, out var userNumber15) &&
                                userNumber15 == (Cx * (Ay * Bz - Az * By) - Cy * (Ax * Bz - Az * Bx) + Cz * (Ax * By - Ay * Bx)))
                            {
                                total++;
                            }
                        }
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

        public string Text { get; set; }
        public string[] CheckBoxes { get; set; }
        public List<MemoryStream> Pictures { get; set; }
    }
}
