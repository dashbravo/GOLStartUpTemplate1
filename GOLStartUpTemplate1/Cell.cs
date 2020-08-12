using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLStartUpTemplate1
{
    public class Cell
    {
        private float mGenerations = 0;
        public bool isAlive; 

        public Cell ()
        {
            isAlive = true;
            mGenerations = 0; 
        }

        public Cell(bool alive, int gens)
        {
            isAlive = alive;
            mGenerations = gens;
        }

        


    }
}
