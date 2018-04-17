using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnicalChallengeCSharp.Models
{
    class Rover
    {
        public string Name { get; set; }
        public Dictionary<int,int> Start { get; set; }
        public int Orientation { get; set; } // N is 1, E is 2, S is 3 and W is 4
        public List<string> Movements { get; set; }
        private int count = 0;
        public Rover()
        {
            var path = "Input.txt";
            Grid grid = new Grid();
            FileStream fs = new FileStream(path,FileMode.Open,FileAccess.Read);
            while (new StreamReader(fs).ReadLine() != string.Empty)
            {
                count++;
                Name = "Rover" + (count % 3).ToString();
                //for (int i = 0; i < count; i++)
                //{
                   
                //}
            }

        }


    }
}
