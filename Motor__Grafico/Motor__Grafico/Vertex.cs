﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor__Grafico3
{
    public class Vertex
    {
        public float X, Y, Z;
        //internal object v;

        public Vertex(float x, float y, float z) { X = x; Y = y; Z = z; }

        public PointF ConvertToPointF(float x, float y) { return new PointF(x, y); }  

    }
}
