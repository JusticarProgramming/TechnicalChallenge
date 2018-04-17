using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnicalChallengeCSharp.Models
{
    class Grid
    {
        public int[] bounds = new int[2];

        public Grid()
        {
            var data = new StreamReader(new FileStream("Input.txt", FileMode.Open, FileAccess.Read)).ReadLine().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            var back = data[0].Split(' ');
            int i = 0;
            foreach (var item in back)
            {
                bounds[i] = int.Parse(item);
                i++;
            }
            
        }
    }
}
