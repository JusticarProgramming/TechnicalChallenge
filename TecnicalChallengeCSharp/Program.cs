using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnicalChallengeCSharp.Models;

namespace TecnicalChallengeCSharp
{
    class Program
    {



        static void Main(string[] args)
        {   // input will be the product of whatever is in the provided text file. 
            //Console.WriteLine("Generates a grid of any size");

            //RandomInputGenerator(2);


            //Console.WriteLine("Generated random rover positions and now solves");
            var input = new StreamReader(new FileStream("Input.txt", FileMode.OpenOrCreate, FileAccess.Read)).ReadToEnd().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in input)
            {
                Console.WriteLine(item);
            }
            var bounds = new Grid().bounds;

            var dirs = "NESW"; var possibilities = new[] { Tuple.Create(0, 1), Tuple.Create(1, 0), Tuple.Create(0, -1), Tuple.Create(-1, 0) };
            for (int i = 1; i < input.Length; i += 2)
            {
                var start = input[i].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var x = int.Parse(start[0]); var y = int.Parse(start[1]); var d = dirs.IndexOf(start[2]);
                foreach (var operation in input[i + 1])

                    switch (operation)
                    {
                        case 'L': d = (--d + possibilities.Length) % possibilities.Length; break;
                        case 'R': d = ++d % possibilities.Length; break;
                        default: x = Math.Min(bounds[0], Math.Max(0, x + possibilities[d].Item1)); y = Math.Min(bounds[1], Math.Max(0, y + possibilities[d].Item2)); break;
                    }
                Console.WriteLine("Rover position output");
                Console.WriteLine(x + " " + y + " " + dirs[d]);
            }
            Console.Read();

        }

        public static void RandomInputGenerator(int amount)
        {

            StreamWriter sw = new StreamWriter("Input.txt", true);
            Random random = new Random();
            var val1 = 0;
            var val2 = 0;

            var startx = 0;
            var starty = 0;

            var dir = "";

            val1 = random.Next(1000, 500000);
            val2 = random.Next(1000, 500000);
            sw.WriteLine("{0} {1}", val1, val2);
            while (amount != 0)
            {
                while ((startx = random.Next(50000)) > val1)
                {
                    startx = random.Next(50000);
                }
                while ((starty = random.Next(50000)) > val2)
                {
                    starty = random.Next(50000);
                }
                val1 = random.Next(4);
                if (val1 == 0)
                {
                    val1 = random.Next();
                }
                switch (val1)
                {
                    case 1: dir = "N"; break;
                    case 2: dir = "E"; break;
                    case 3: dir = "S"; break;
                    case 4: dir = "W"; break;
                }

                sw.WriteLine("{0} {1} {2}", startx, starty, dir);

                //Simulates the instructions generated that will be sent, can be any number, for demonstrational purposes I'm giving it 10 instructions
                var count = 100;
                string operations = "";
                while (count > -1)
                {
                    val1 = random.Next(1, 4);
                    switch (val1)
                    {
                        case 1: dir = "M"; break;
                        case 2: dir = "L"; break;
                        case 3: dir = "R"; break;
                    }
                    operations = operations + dir;

                    count--;
                }
                sw.WriteLine(operations);
                amount--;


            }
            sw.Dispose();

        }

    }
}
