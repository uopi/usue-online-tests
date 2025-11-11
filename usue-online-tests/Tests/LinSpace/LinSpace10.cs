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
    public class LinSpace09 : ITestCreator, ITest, ITestGroup, ITimeLimit
    {
        public int TestID { get; set; }
        public string Name { get; } = "Базис подпространства01.6";
        public string Description { get; } = "Базис подпространства";
        public int TimeLimitSeconds { get; set; } = 120;
        public string GroupName { get; set; } = "LinSpace";
        private static readonly char[] LetterU = { 'U', 'V', 'W', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
        private static readonly char[] LetterA = { 'p', 'q', 'r', 'y', 'z', 't' };
        private static readonly int[] Values = { -9, -8, -7, -6, -5, -4, -3, -2, 2, 3, 4, 5, 6, 7, 8, 9 };
        public ITest CreateTest(int randomSeed)
        {
            var rand = new Random(randomSeed);

            List<int> values = [.. Values];
            int Cy = values[rand.Next(0, values.Count)];
            values.Remove(Cy);
            int Dx = values[rand.Next(0, values.Count)];
            values.Remove(Dx);
            int Dy = values[rand.Next(0, values.Count)];
            char letterA = LetterA[rand.Next(0, LetterA.Length)];
            char letterU = LetterU[rand.Next(0, LetterA.Length)];

            ITest result = new LinSpace09(); 
            result.Text =
                $"Пусть {letterU} - линейное пространство многочленов степени, не выше 3. " +
                $"Заполните поля для ввода, чтобы получить один из базисов подпространства " +
                $"\\(\\left\\{{ {letterA}(x) \\mid {letterA}({Cy})={Dx}\\cdot {letterA}'({Dy})\\right\\}}\\): \n" +
                $"\\(\\left\\{{ x - <form1:3>, x^{{2}} - <form2:3>, x^{{3}}-<form3:3>\\right\\}}\\).";
            
            return result;
        }

        public int CheckAnswer(int randomSeed, Dictionary<string, string> answers)
        {
            var rand = new Random(randomSeed);

            List<int> values = [.. Values];
            int Cy = values[rand.Next(0, values.Count)];
            values.Remove(Cy);
            int Dx = values[rand.Next(0, values.Count)];
            values.Remove(Dx);
            int Dy = values[rand.Next(0, values.Count)];
            int total = 0;

            if (answers.TryGetValue("form1", out var va) && int.TryParse(va, out var va1) && va1 == Cy-Dx) total++;
            if (answers.TryGetValue("form2", out var va2) && int.TryParse(va2, out var va21) && va21 == (Cy*Cy-2*Dx*Dy)) total++;
            if (answers.TryGetValue("form3", out var va3) && int.TryParse(va3, out var va31) && va31 == (Cy*Cy*Cy-3*Dx*Dy*Dy)) total++;

            return total;
        }

        public string Text { get; set; }
        public string[] CheckBoxes { get; set; }
        public List<MemoryStream> Pictures { get; set; }
    }
}
