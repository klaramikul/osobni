using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassPlayground
{
    internal class Circle : Shape2D
    {
        public float radius;

        public override float CalculateArea()
        {
            return (float)Math.PI * radius * radius;
        }

        public override bool ContainsPoint(float x, float y)
        {
            return Math.Sqrt(x * x + y * y) <= radius;
        }

        public Circle(float radius)
        {
            if (radius == 0) this.radius = 1;
            else if (this.radius < 0) this.radius = -radius;
            else
            {
                this.radius = radius;
            }

        }
    }
}

