using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Seminar3
{
    class Program
    {
       static string [] SplittedText;
        

        static void Main(string[] args)
        {
            //SplittedText = SetSplittedText();
            //Task1();
            //Task2();
            //Task3();
            //Task4();
            //Task5();
            //Task6();
            //Task7();
            //Task8();
            //Task9();
            //Task10();


        }

        static string [] SetSplittedText()
        {
            Console.WriteLine("Vedi Soobshenie");
            string StandardText = Console.ReadLine();
            char[] delimiterChars = { ' ', ',', '.', ':', '\t', '_' };

            return StandardText.Split(delimiterChars);
        }

        /// <summary>
        /// 1.	Определить количество слов в строке, начинающихся и заканчивающихся на одну и ту же букву.
        /// </summary>
        static void Task1()
        {
            string[] Local = SplittedText;

            char Fist;
            char Last;

            int Count=0;


            for (int i = 0; i < Local.Length; i++)
            {
                if (String.IsNullOrEmpty(Local[i])==false && Local[i].Length>1)
                {

                    Fist = Local[i].First();
                    Last = Local[i].Last();

                    if (Fist == Last)
                    {
                        Count++;
                    }
                }
            }

            Console.WriteLine(Count);
        }

        /// <summary>
        /// 2.	Удалить слова заданной длины.
        /// </summary>
        static void Task2()
        {
            Console.WriteLine("Dlina Slov udalenia");
            int Length =Convert.ToInt32(Console.ReadLine());

            List<string> Local = SplittedText.ToList();

            foreach (string Word in Local.ToList())
            {
                if (Word.Length== Length)
                {
                    Local.Remove(Word);
                }
            }

            foreach (string Word in Local)
            {
                Console.WriteLine($"{Word},");
            }
        }

        /// <summary>
        /// 3.	Составить массив из слов, в которых ни одна буква не повторяется.
        /// </summary>
        static void Task3()
        {
            string[] Local = SplittedText;

            Local = Local.Where(x => x.Distinct().Count() == x.Length).ToArray(); 

        }

        /// <summary>
        /// 4.	Составить массив из номеров слов, в которых есть повторяющиеся символы.
        /// </summary>
        static void Task4()
        {
            string[] Local = SplittedText;

            for (int i = 0; i < Local.Length; i++)
            {
                if (Local[i].Distinct().Count()!= Local[i].Length)
                {
                    Console.WriteLine($"Pos in text::{i}, Word::{Local[i]}");
                }
            }                  
        }

        /// <summary>
        /// 5.	Поменять местами i и j слово (номера слов i и j задаются при вводе).
        /// </summary>
        static void Task5()
        {
            string[] Local = SplittedText;

            int i = 0;
            int j = 0;

            string Container;


            Console.WriteLine("Slovo i");
            i = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Slovo j");
            j = Convert.ToInt32(Console.ReadLine());

            Container = Local[i];
            Local[i] = Local[j];
            Local[j] = Container;

            foreach (string Word in Local)
            {
                Console.WriteLine(Word);
            }

        }

        /// <summary>
        /// 6.	Поменять местами слово максимальной и слово минимальной длины.
        /// </summary>
        static void Task6()
        {
            string[] Local = SplittedText;

            int Max = Local.ToList().IndexOf(Local.Max());
            int Min = Local.ToList().IndexOf(Local.Min());
            string Container;

            Container = Local[Max];
            Local[Max] = Local[Min];
            Local[Min] = Container;

            foreach (string Word in Local)
            {
                Console.WriteLine(Word);
            }
        }

        /// <summary>
        /// 7.	Определить слово максимальной длины, в котором все символы различны
        /// </summary>
        static void Task7()
        {
            string[] Local = SplittedText;
            string Word;

            Word = Local.Where(x => x.Distinct().Count() == x.Length).Select(y => y).Max();

            Console.WriteLine(Word);
        }

        /// <summary>
        /// 8.	Определить слова, в которых содержится больше двух гласных букв Пендоского алфавита,мне влом париться с кириллицей + 
        /// у меня система на английском, а на regax это не как не виляет
        /// </summary>
        static void Task8()
        {
            string[] Local = SplittedText;
            string[] Right= new string[SplittedText.Length];
            int Count = 0;

            for (int i = 0; i < Local.Length; i++)
            {
                if (Regex.IsMatch(Local[i], "[aeiouy]+ a|e|i|o|u|y ") || Regex.IsMatch(Local[i], "[aeiouy]{2,}"))
                {
                    Right[i] = SplittedText[i];
                }
            }

            foreach (string Word in Right)
            {
                Console.WriteLine(Word);
            }
        }


        /// <summary>
        /// 9.	Определить номер слова-палиндрома, имеющего максимальную длину.
        /// </summary>
        static void Task9()
        {

            List<string> Local = SplittedText.ToList();

            char[] Letters;

            string LongestWord;
            string ReversedText;
            

            foreach (string Word  in Local)
            {
                Letters = Word.ToCharArray();
                Array.Reverse(Letters);
                ReversedText = new string(Letters);

                if (Word != ReversedText)
                {
                    Local.Remove(Word);
                }

            }

            LongestWord = Local.GroupBy(x => x).Select(x => x.Max()).Max();

            Console.WriteLine(LongestWord);
            
        }


        /// <summary>
        ///10. Удалить все слова-палиндромы, имеющие максимальную длину.Я тут подумал если начать удалять самые длинные словат, то получаеться я начну с самого большого, а закончу уджалением самого маленького, так что я просто удалю самое длинное слово, ок :^) ?
        /// </summary>
        static void Task10()
        {
            List<string> PolidoroWords = new List<string>(10);

            List<string> Local = SplittedText.ToList();
            char[] Letters;

            string ReversedText;


            foreach (string Word in Local)
            {
                Letters = Word.ToCharArray();
                Array.Reverse(Letters);
                ReversedText = new string(Letters);

                if (Word == ReversedText)
                {
                    PolidoroWords.Add(Word);
                }

            }

            Local.Remove(PolidoroWords.Max());
            
            foreach (string Word in Local)
            {
                Console.WriteLine(Word);
            }


        }

    }
}
