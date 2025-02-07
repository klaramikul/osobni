using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassPlayground
{
    internal class Shape2D
    {
        public virtual float CalculateArea ()
        {
            Console.WriteLine("Undefined shape - cannot have an area");
            return -1;
        }

        public virtual float CalculateAspectRatio()
        {
            Console.WriteLine("Undefined shape - cannot have an aspect ratio");
            return -1;
        }

        public virtual bool ContainsPoint (float x, float y)
        {
            Console.WriteLine("Cannot decide about a point in undefined shape");
            return false;
        }
    }
}
