using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFights.Solutions

{
    internal class Add : Solutions
    {
        public int solution(int param1, int param2)
        {
            int val = param1 + param2;
            return val;
        }

        private bool CheckLimit(int intVal)
        {
            return (intVal <= 1000 && intVal <= -1000);
        }
    }
}
