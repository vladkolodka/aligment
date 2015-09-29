using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

// первая программа на C#

namespace ConsoleApplication2
{
    class Program
    {
        private string file_in = "in.txt";
        private string file_out = "out.txt";

        private int N;
        private string In;
        private string Out;
        private char symbol = ' ';

        static void Main(string[] args)
        {
            Program start = new Program();
            Console.ReadKey();
        }
        Program()
        {
            string[] lines = File.ReadAllLines(file_in);

            N = int.Parse(lines[0]);
            In = lines[1];

            // формируем строку
            createString();

            // проверка
            Console.WriteLine(Out);

            File.WriteAllText(file_out, Out);           
        }
        private string getSymbols(int count, char symbol)
        {
            string symbols = "";

            for (int i = 0; i < count; i++)
                symbols += symbol;

            return symbols;
        }
        private void createString()
        {
            
            // разбиваем строку на слова
            string[] words = In.Split(' ');

            foreach(var word in words) {
                if(word.Length > N) {
                    Console.WriteLine("Ошибка! Текст не помещается в строку.");
                    return;
                }
            }

            for (int i = 0; i < words.Length; i++)
            {
                // для хранения текущей строки (линии)
                List<string> line = new List<string>();
                int count = 0;

                // корректор количества пробелов
                while (count + words[i].Length + (line.Count > 1 ? line.Count : 1) - 1 < N)
                {

                    count += words[i].Length;
                    // добавляем слово в строку
                    line.Add(words[i]);

                    i++;
                    if (i == words.Length) break;
                }

                int fixer = line.Count <= 1 ? 2 : line.Count;
                // получаем строку с необходимым клюичеством пробелов
                double symbols_count = ((double)N - count) / (fixer - 1);
                string spaces = getSymbols((int) symbols_count, symbol);

                for(int j = 0; j < line.Count; j++)
                {
                    Out += line[j];

                    if (j + 2 == line.Count && (int) symbols_count != symbols_count)
                        Out += symbol;
                    if (j + 1 == line.Count) Out += '\n';
                    else Out += spaces;
                }
                i--;
            }
        }
    }
}
