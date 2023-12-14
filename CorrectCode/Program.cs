using System;

namespace CorrectCode
{
    class Program
    {
        private static bool CheckCode(string text)
        {
            if (String.IsNullOrEmpty(text) || text.Length != 10)
                return false;

            int sum = 0;
            foreach (char c in text)
            {
                if (!Char.IsDigit(c))
                    return false;

                sum += (int)Char.GetNumericValue(c);
            }

            int remainder = sum % 10;

            if (remainder == 0 && text[9] == '0')
                return true;
            else if (remainder == 1 && text[9] == '1')
                return true;
            else if (remainder != 0 && remainder != 1 && text[9] == '9')
                return true;

            return false;
        }

        static void Main(string[] args)
        {
            string[] testCases = {
                "", 
                "123", 
                "123123123123123", 
                "strokasymb", 
                "1234123400", 
                "1234123401", 
                "1234123404", 
                "1234123409", 
                "3000030001", 
                "3000130009" 
            };

            using (StreamWriter outputFile = new StreamWriter("result.txt"))
            {

                foreach (string testCase in testCases)
                {
                    bool result = CheckCode(testCase);
                    outputFile.WriteLine($"\"{testCase}\" => {result}");
                    Console.WriteLine($"{testCase} - {result}");
                }
            }

           

            Console.ReadLine(); 
        }
    }
}
