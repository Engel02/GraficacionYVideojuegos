using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor__Grafico3
{
    public class Figures
    {
        public Vertex[] Vertex;
        public Vertex[] secondsVertex;
        
        public Figures(Vertex[] inputVertices)
        {

            Vertex = inputVertices;
            secondsVertex = inputVertices;
        }
    }
}
