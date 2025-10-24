using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using Test_Wrapper;

namespace usue_online_tests.Tests.PolynomA
{
    public class MakeEquation11 : ITestCreator, ITest, ITestGroup
    {
        public int TestID { get; set; }
        public string Name { get; } = "Стратегия составления уравнения001";
        public string Description { get; } = "Составление уравнений для текстовых задач";
        public string GroupName { get; set; } = "Make Equation";
        public int TimeLimitSeconds { get; set; } = 120;
        public ITest CreateTest(int randomSeed)
        {
            var random = new Random(randomSeed);
            
            ITest result = new MakeEquation11();

            result.Text = $"В сплаве 6 кг {nameA} и 6 кг {nameB}. Во сколько раз нужно " +
                $"увеличить массу {nameB}, " +
                $"чтобы его массовая доля в сплаве выросла в 2 раза. Обозначим через" +
                $" k отношение массы {nameB} к в итоговом сплаве к массе ";

            return result;
        }
        public int CheckAnswer(int randomSeed, Dictionary<string, string> answers)
        {
            int total = 0;

            var random = new Random(randomSeed);
            

            return total;
        }

        public string Text { get; set; }
        public string[] CheckBoxes { get; set; }
        public List<MemoryStream> Pictures { get; set; }
    }
}
