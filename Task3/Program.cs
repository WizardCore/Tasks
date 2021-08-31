using System;
using System.Text.RegularExpressions;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Не выходи из комнаты, не совершай ошибку 17968.5
            //Завтра утром проведу силовую тренировку 21437.5
            //На сегодня хватит, надо-бы домой собираться. 23328
            //Ночью в лесу опасно, стоит найти место для привала и развести огонь. 83187.5

            string[] ru = { "Не выходи из комнаты, не совершай ошибку",
                "Завтра утром проведу силовую тренировку", 
                "На сегодня хватит, надо-бы домой собираться.", 
                "Ночью в лесу опасно, стоит найти место для привала и развести огонь." };
            double[] arrayIndexRU = new double[ru.Length];
            string[] en = { "One can become a writer only if he is talented. | Comment", 
                "It seems that you have made a rude mistake. | Comment", 
                "Emily can count to ten and write the basic letters. | Comment",
                "They often forget to bring their homework. | Comment",
                "You must have left the phone at the airport. | Comment",
                "Does he play football every day? No, he doesn’t. Comment",
                "The doctor gave her a shot in the buttock. | Comment"};
            double[] arrayIndexEN = new double[en.Length];

            //My sister is having her hair cut at the moment - 24326.5
            //How long has your sister been living in London? 27436
            //If you could be an animal, what animal would you be? - 32000
            //You must have left the phone at the airport 21437.5
            //Have they ever been to Disneyland? 10976
            //Does he play football every day? No, he doesn’t 23328
            //He promised to come on time but he was late again 29658.5
            //The doctor gave her a shot in the buttock. 17968.5

            for (int i = 0; i < ru.Length; i++)
                arrayIndexRU[i] = new Program().DecideIndexPetrenko(ru[i]);

            for (int i = 0; i < en.Length; i++)
                arrayIndexEN[i] = new Program().DecideIndexPetrenko(en[i]);

            for(int i = 0; i < ru.Length; i++)
            {
                bool checkOutput = true;
                string outputString = $"String {ru[i]} has index: {arrayIndexRU[i]}, which equal to the next lines:";
                for (int l = 0; l < en.Length; l++)
                {
                    if (arrayIndexRU[i] == arrayIndexEN[l])
                    {
                        outputString += $"\n{en[l]}";
                        checkOutput = false;
                    }
                }
                if (checkOutput)
                    Console.WriteLine($"String {ru[i]} has index: {arrayIndexRU[i]}. No equivalent indexes were found.");
                else
                    Console.WriteLine(outputString);
            }
        }
        double DecideIndexPetrenko(string str)
        {
            string[] splitString = str.Split('|');
            double indexPetrenko = 0.5;
            double currIndexPetrenko = 0;
            int count = 0;
            for (int i = 0; i < splitString[0].Length; i++)
            {
                if(Regex.IsMatch(splitString[0][i].ToString(), @"\w", RegexOptions.IgnoreCase))
                {
                    currIndexPetrenko += indexPetrenko;
                    indexPetrenko += 1;
                    count++;
                }
            }
            return currIndexPetrenko * count;
        }
    }
}
