using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor__Grafico3
{
    public class Scene
    {
        public static List<Figures> figure = new List<Figures>();
        public Scene(Figures figures)
        {
            figure.Add(figures);

        }
    }
}
