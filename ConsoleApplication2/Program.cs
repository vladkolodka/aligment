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


        static void Main(string[] args)
        {
            Program start = new Program();
            Console.ReadKey();
        }
        Program()
        {
            string[] lines = File.ReadAllLines(file_in);

            foreach (string line in lines) {
                Console.WriteLine(line);
            }        
        }
    }
}
