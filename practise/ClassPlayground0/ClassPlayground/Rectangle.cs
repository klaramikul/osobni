using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassPlayground
{
    internal class Rectangle : Shape2D
    {
       private float width, height;

        public Rectangle (float width, float height)
        {
            if (width == 0) this.width = 1;
            else if ( width < 0)
            {
                this.width = -width;

            }
            else
            {
                this.width = width;
            }

            if (height == 0) this.height = 1;
            else if (height < 0)
            {
                this.height = -height;

            }
            else
            {
                this.height = height;
            }
        }

        public override float CalculateArea ()
        {
            return width * height;
        }

        public override float CalculateAspectRatio ()
        {
            
            return width / height;
        }

        public override bool ContainsPoint (float x, float y)
        {
            if (x < width && x > 0 && y < height && y > 0 )
                return true;
            else return false;
        }
    }

}
