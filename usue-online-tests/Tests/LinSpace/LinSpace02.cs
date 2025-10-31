using NuGet.ContentModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using Test_Wrapper;

namespace usue_online_tests.Tests.PolynomA
{
    public class LinSpace02 : ITestCreator, ITest, ITestGroup
    {
        public int TestID { get; set; }
        public string Name { get; } = "Определение подпространства02";
        public string Description { get; } = "Определение подпространства";
        public string GroupName { get; set; } = "LinSpace";
        private static readonly char[] LetterU = { 'U', 'V', 'W', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
        private static readonly char[] LetterB = { 'M', 'P', 'Q', 'X', 'Y', 'Z', 'T' };
        public ITest CreateTest(int randomSeed)
        {
            Span<char> letters = GenLetters(randomSeed);
            char letterU = letters[0];
            char letterB = letters[1];

            ITest result = new LinSpace02();
            result.Text =
                $"Пусть {letterU} - линнейное пространство матриц размерности 2 x 2." +
                $"Отметьте щелчком мыши в поле для ввода те пункты," +
                $" в которых приведено характеристическое свойство " +
                $"\\(\\Phi(\\textbf{{{letterB}}})\\) подмножества " +
                $"\\(\\left\\{{\\textbf{{{letterB}}}(x)\\mid \\Phi(\\textbf{{{letterB}}})\\right\\}}\\), определяющие подпространство:";

            result.CheckBoxes = GenFormuls(randomSeed);
            

            return result;
        }

        public int CheckAnswer(int randomSeed, Dictionary<string, string> answers)
        {

            string[] questions = GenFormuls(randomSeed);
            var total = 0;

            

            return total;
        }

        private string[] GenFormuls(int seed)
        {
            var rand = new Random(seed);

            char letterU = LetterU[rand.Next(0, LetterU.Length)];
            char letterB = LetterB[rand.Next(0, LetterB.Length)];

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
            int Dx = listCD[rand.Next(0, listCD.Count)];
            listCD.Remove(Dx);
            int Dy = listCD[rand.Next(0, listCD.Count)];
            listCD.Remove(Dy);
            int Ex = listCD[rand.Next(0, listCD.Count)];
            listCD.Remove(Ex);
            int Ey = listCD[rand.Next(0, listCD.Count)];
            listCD.Remove(Ey);
            int Fx = listCD[rand.Next(0, listCD.Count)];
            listCD.Remove(Fx);
            int Fy = listCD[rand.Next(0, listCD.Count)];


            return new string[]
            {
                $"\\(\\textbf{{{letterB}}}\\cdot" +          //Ax
                $"\\left(\\begin{{array}}{{cc}}" +
                $"{Cx} & {Cy} \\\\" +
                $"{Dx} & {Dy} \\\\" +
                $"\\end{{array}}\\right)\\) = " +
                $"\\(\\left(\\begin{{array}}{{cc}}" +
                $"0 & 0 \\\\" +
                $"0 & 0 \\\\" +
                $"\\end{{array}}\\right)\\)",

                $"\\(\\left(\\begin{{array}}{{cc}}" +        //Ay
                $"{Cx} & {Cy} \\\\" +
                $"{Dx} & {Dy} " +
                $"\\end{{array}}\\right)\\cdot\\textbf{{{letterB}}}\\) = " +
                $"\\(\\left(\\begin{{array}}{{cc}}" +
                $"0 & 0 \\\\" +
                $"0 & 0 " +
                $"\\end{{array}}\\right)\\)",

                $"\\(\\textbf{{{letterB}}}\\cdot" +         //Az
                $"\\left(\\begin{{array}}{{cc}}" +
                $"{Cx} & {Cy} \\\\" +
                $"{Dx} & {Dy}" +
                $"\\end{{array}}\\right)\\) + " +
                $"\\(\\left(\\begin{{array}}{{cc}}" +
                $"{Cx} & {Cy} \\\\" +
                $"{Dx} & {Dy}" +
                $"\\end{{array}}\\right)\\cdot\\textbf{{{letterB}}}\\) = " +
                $"\\(\\left(\\begin{{array}}{{cc}}" +
                $"0 & 0 \\\\" +
                $"0 & 0 \\\\" +
                $"\\end{{array}}\\right)\\)",

                $"\\(\\textbf{{{letterB}}}\\cdot" +        //Bx
                $"\\left(\\begin{{array}}{{cc}}" +
                $"{Cx} & {Cy} \\\\" +
                $"{Dx} & {Dy}" +
                $"\\end{{array}}\\right)\\) = " +
                $"\\(\\left(\\begin{{array}}{{cc}}" +
                $"{Ex} & {Ey} \\\\" +
                $"{Fx} & {Fy}" +
                $"\\end{{array}}\\right)\\)",

                $"\\(\\left(\\begin{{array}}{{cc}}" +        //By
                $"{Cx} & {Cy} \\\\" +
                $"{Dx} & {Dy} " +
                $"\\end{{array}}\\right)\\cdot\\textbf{{{letterB}}}\\) = " +
                $"\\(\\left(\\begin{{array}}{{cc}}" +
                $"{Ex} & {Ey} \\\\" +
                $"{Fx} & {Fy} " +
                $"\\end{{array}}\\right)\\)",

                $"\\(\\textbf{{{letterB}}}\\cdot" +         //Bz
                $"\\left(\\begin{{array}}{{cc}}" +
                $"{Cx} & {Cy} \\\\" +
                $"{Dx} & {Dy}" +
                $"\\end{{array}}\\right)\\) + " +
                $"\\(\\left(\\begin{{array}}{{cc}}" +
                $"{Cx} & {Cy} \\\\" +
                $"{Dx} & {Dy}" +
                $"\\end{{array}}\\right)\\cdot\\textbf{{{letterB}}}\\) = " +
                $"\\(\\left(\\begin{{array}}{{cc}}" +
                $"{Ex} & {Ey} \\\\" +
                $"{Fx} & {Fy} \\\\" +
                $"\\end{{array}}\\right)\\)"
            };
        }

        private char[] GenLetters(int seed)
        {
            Random rand = new Random(seed);
            return new char[]
            {
                LetterU[rand.Next(0, LetterU.Length)],
                LetterB[rand.Next(0, LetterB.Length)]
            };
        }
        
        public string Text { get; set; }
        public string[] CheckBoxes { get; set; }
        public List<MemoryStream> Pictures { get; set; }
    }
}
