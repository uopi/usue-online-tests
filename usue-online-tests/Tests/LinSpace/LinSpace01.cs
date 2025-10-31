using NuGet.ContentModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using Test_Wrapper;

namespace usue_online_tests.Tests.PolynomA
{
    public class LinSpace01 : ITestCreator, ITest, ITestGroup
    {
        public int TestID { get; set; }
        public string Name { get; } = "Определение подпространства01";
        public string Description { get; } = "Определение подпространства";
        public string GroupName { get; set; } = "LinSpace";
        private static readonly char[] LetterU = { 'U', 'V', 'W', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
        private static readonly char[] LetterA = { 'p', 'q', 'r', 'y', 'z', 't' };
        public ITest CreateTest(int randomSeed)
        {
            Span<char> letters = GenLetters(randomSeed);
            char letterU = letters[0];
            char letterA = letters[1];

            ITest result = new LinSpace01();
            result.Text =
                $"Пусть {letterU} - линейное пространство для многочленов степени, не выше 3. " +
                $"Отметьте щелчком мыши в поле для ввода те пункты, в которых приведено" +
                $" характеристическое свойство \\(F({letterA}(x))\\) подмножества " +
                $"\\(\\left\\{{{letterA}(x)\\mid \\Phi({letterA}(x))\\right\\}}\\), определите подпространство:\n";

            result.CheckBoxes = GenFormuls(randomSeed);
            

            return result;
        }

        public int CheckAnswer(int randomSeed, Dictionary<string, string> answers)
        {
            int[] nums = GenNum(randomSeed).Take(3).ToArray();
            //int i = 1;
            //foreach (var num in nums)
            //{
            //    Console.WriteLine($"CheckAnsw {i++} {num}");
            //}

            string[] questions = GenFormuls(randomSeed);
            var total = 0;

            for (int i = 0; i < 6; i++)
                if (answers.TryGetValue(questions[i], out var va) && va == "on" && nums.Contains(i + 1)) total++;

            return total;
        }

        private string[] GenFormuls(int seed)
        {
            
            Span<char> letters = GenLetters(seed);
            Span<int> CD = GenNum(seed);
            int Cx = CD[6];
            int Cy = CD[7];
            int Dx = CD[9];
            int Dy = CD[10];
            int Dz = CD[11];

            char letterU = letters[0];
            char letterA = letters[1];

            return new string[] 
            { 
                $"\\({letterA}({Cx})=0\\)",
                $"\\({Cy}\\cdot {letterA}({Cx})+{Dy}\\cdot {letterA}({Dx})=0\\)",
                $"\\({Cx}\\cdot {letterA}({Cy})={Dx}\\cdot {letterA}({Dy})\\)",
                $"\\({letterA}({Cx}) = {Dx}\\)",
                $"\\({letterA}(0) = {Cx}\\)",
                $"\\({Cy}\\cdot {letterA}({Cx}) + {Dx}\\cdot {letterA}({Dy}) = {Dz}\\)"
            }.Select(s => s.Replace("+-", "-").Replace("-+", "-").Replace("--", "+")).ToArray();
        }
        private char[] GenLetters(int seed)
        {
            var random = new Random(seed);
            return new char[] 
            { 
                LetterU[random.Next(0, LetterU.Length)],
                LetterA[random.Next(0, LetterA.Length)]
            };
        }
        private int[] GenNum(int randomSeed)
        {
            var random = new Random(randomSeed);
            List<int> listAB = new List<int> { 1, 2, 3, 4, 5, 6 };
            List<int> listCD = new List<int> { -9, -8, -7, -6, -5, -4, -3, -2, 2, 3, 4, 5, 6, 7, 8, 9 };

            int Ax = listAB[random.Next(0, listAB.Count)];
            listAB.Remove(Ax);
            int Ay = listAB[random.Next(0, listAB.Count)];
            listAB.Remove(Ay);
            int Az = listAB[random.Next(0, listAB.Count)];
            listAB.Remove(Az);
            int Bx = listAB[random.Next(0, listAB.Count)];
            listAB.Remove(Bx);
            int By = listAB[random.Next(0, listAB.Count)];
            listAB.Remove(By);
            int Bz = listAB[random.Next(0, listAB.Count)];

            int Cx = listCD[random.Next(0, listCD.Count)];
            listCD.Remove(Cx);
            int Cy = listCD[random.Next(0, listCD.Count)];
            listCD.Remove(Cy);
            int Cz = listCD[random.Next(0, listCD.Count)];
            listCD.Remove(Cz);
            int Dx = listCD[random.Next(0, listCD.Count)];
            listCD.Remove(Dx);
            int Dy = listCD[random.Next(0, listCD.Count)];
            listCD.Remove(Dy);
            int Dz = listCD[random.Next(0, listCD.Count)];

            return new int[]
            { 

                            Ax, Ay, Az,
                            Bx, By, Bz,
            
                            Cx, Cy, Cz,
                            Dx, Dy, Dz
            };
        }
        public string Text { get; set; }
        public string[] CheckBoxes { get; set; }
        public List<MemoryStream> Pictures { get; set; }
    }
}
