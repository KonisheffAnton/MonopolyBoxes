using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyBoxes.Entities.Base
{
    public class Container
    {
        public int Id { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        virtual public double Depth { get; set; }
        public double Weight { get; set; }
    }
}
