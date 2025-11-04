using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NuGet.ContentModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using Test_Wrapper;

namespace usue_online_tests.Tests.PolynomA
{
    public class LinSpace03 : ITestCreator, ITest, ITestGroup, ITimeLimit
    {
        public int TestID { get; set; }
        public string Name { get; } = "Определение подпространства03";
        public string Description { get; } = "Определение подпространства";
        public int TimeLimitSeconds { get; set; } = 60;
        public string GroupName { get; set; } = "LinSpace";
        private static readonly char[] LetterU = { 'U', 'V', 'W', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
        private static readonly char[] LetterA = { 'p', 'q', 'r', 'y', 'z', 't' };
        public ITest CreateTest(int randomSeed)
        {
            Span<char> letters = GenLetters(randomSeed);
            char letterU = letters[0];
            char letterA = letters[1];

            ITest result = new LinSpace03();
            result.Text =
                $"Пусть {letterU} - линейное пространство билинейных форм" +
                $" для некоммутирующих переменных x, y," +
                $" т.е. выражений вида " +
                $"\\(\\alpha x^{{2}}+\\beta xy + \\gamma yx + \\delta y^{{2}}\\)." +
                $"Отметьте щелчком мыши в поле для ввода те пункты, в которых приведено характеристическое свойство \\(\\Phi({letterA}(x, y))\\) подмножества " +
                $"\\(\\left\\{{{letterA}(x, y)\\mid \\Phi({letterA}(x, y))\\right\\}}\\), определяющее подпространство:\n";

            result.CheckBoxes = GenFormuls(randomSeed).Formuls;
            

            return result;
        }

        public int CheckAnswer(int randomSeed, Dictionary<string, string> answers)
        {

            var _gf = GenFormuls(randomSeed);
            int[] nums = { _gf.Ax, _gf.Az, _gf.Ay };
            string[] questions = _gf.Formuls;

            int index = 0;
            int failCheck = 0;
            int total = 0;

            for (int i = 0; i < 6; i++)
            { 
                if (answers.TryGetValue(questions[index - 1], out var va) && va == "on" && nums.Contains(index++))
                {
                    total += 2;
                }
                else
                {
                    failCheck += 1;
                }
            }

            if (failCheck > 2)
            {
                total = 0;
            }
            else
            {
                total = failCheck<=total ? total - failCheck : 0;
            }

            return total;
        }

        private struct TestData
        {
            public string[] Formuls;
            public int Ax;
            public int Ay;
            public int Az;

            public TestData(string[] formuls, int ax, int ay , int az)
            {
                Formuls = formuls;
                Ax = ax;
                Ay = ay;
                Az = az;
            }
        }
        private char[] GenLetters(int seed)
        {
            Random rand = new Random(seed);
            return new char[]
            {
                LetterU[rand.Next(0, LetterU.Length)],
                LetterA[rand.Next(0, LetterA.Length)]
            };
        }
        private TestData GenFormuls(int randomSeed)
        {
            var rand = new Random(randomSeed);

            char letterU = LetterU[rand.Next(0, LetterU.Length)];
            char letterA = LetterA[rand.Next(0, LetterA.Length)];

            List<int> listAB = new List<int> { 1, 2, 3, 4, 5, 6 };
            int Ax = listAB[rand.Next(0, listAB.Count)];
            listAB.Remove(Ax);
            int Ay = listAB[rand.Next(0, listAB.Count)];
            listAB.Remove(Ay);
            int Az = listAB[rand.Next(0, listAB.Count)];
            listAB.Remove(Az);
            int Bx = listAB[rand.Next(0, listAB.Count)];
            listAB.Remove(Bx);
            int By = listAB[rand.Next(0, listAB.Count)];
            listAB.Remove(By);
            int Bz = listAB[0];

            List<int> listCD = new List<int> { -9, -8, -7, -6, -5, -4, -3, -2, 2, 3, 4, 5, 6, 7, 8, 9 };
            int Cx = listCD[rand.Next(0, listCD.Count)];
            listCD.Remove(Cx);
            int Cy = listCD[rand.Next(0, listCD.Count)];
            listCD.Remove(Cy);
            int Cz = listCD[rand.Next(0, listCD.Count)];
            listCD.Remove(Cz);
            int Dx = listCD[rand.Next(0, listCD.Count)];
            listCD.Remove(Dx);
            int Dy = listCD[rand.Next(0, listCD.Count)];
            listCD.Remove(Dy);
            int Dz = listCD[rand.Next(0, listCD.Count)];
            listCD.Remove(Dz);


            string[] formuls = new string[]
            {
                $"\\({letterA}({Cx}, {Cy})=0\\)",
                $"\\({Cz}\\cdot {letterA}({Cx}, {Cy})+{Dz}\\cdot {letterA}({Dx}, {Dy})=0\\)",
                $"\\({Cx}\\cdot {letterA}({Cy}, {Cz})={Dx}\\cdot {letterA}({Dy}, {Dz})\\)",
                $"\\({letterA}({Cy}, {Cx}) = {Dx}\\)",
                $"\\({letterA}(0, 0) = {Cx}\\)",
                $"\\({Cy}\\cdot {letterA}({Cz}, {Cx}) + {Dx}\\cdot {letterA}({Dz}, {Dy}) = {Ax+Bx}\\)"
            }.Select(s => s.Replace("+-", "-").Replace("-+", "-").Replace("--", "+")).ToArray();
            return new TestData(formuls, Ax, Ay, Az);
        }
        public string Text { get; set; }
        public string[] CheckBoxes { get; set; }
        public List<MemoryStream> Pictures { get; set; }
    }
}
