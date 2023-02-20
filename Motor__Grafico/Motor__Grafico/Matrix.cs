using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor__Grafico3
{
    public class Matrix
    {
        private float[,] matrixValues;
        public Matrix(float[,] matrix)
        {
            matrixValues = matrix;
        }
        public static Vertex verMatrix(Vertex vertex, float[,] Matrixf)
        {
            float x = (Matrixf[0, 0] * vertex.X) + (Matrixf[1, 0] * vertex.Y) + (Matrixf[2, 0] * vertex.Z);
            float y = (Matrixf[0, 1] * vertex.X) + (Matrixf[1, 1] * vertex.Y) + (Matrixf[2, 1] * vertex.Z);
            float z = (Matrixf[0, 2] * vertex.X) + (Matrixf[1, 2] * vertex.Y) + (Matrixf[2, 2] * vertex.Z);

            return new Vertex(x, y, z);
        }

        public static Vertex get3DMatrix(Vertex vertice, float[,] M)
        {
            vertice.X = (M[0, 0] * vertice.X) + (M[1, 0] * vertice.Y) + (M[2, 0] * vertice.Z);
            vertice.Y = (M[0, 1] * vertice.X) + (M[1, 1] * vertice.Y) + (M[2, 1] * vertice.Z);
            vertice.Z = (M[0, 2] * vertice.X) + (M[1, 2] * vertice.Y) + (M[2, 2] * vertice.Z);

            return vertice;
        }

        public static float[,] RotationX(float angle)
        {
            float sin = (float)Math.Sin(angle);
            float cos = (float)Math.Cos(angle);

            float[,] rotationX = new float[3, 3] {
                {1, 0, 0},
                {0, cos, -sin},
                {0, sin, cos}
            };
            return rotationX;
        }

        public static float[,] RotationY(float angle)
        {
            float sin = (float)Math.Sin(angle);
            float cos = (float)Math.Cos(angle);

            float[,] rotationY = new float[3, 3] {
                {cos, 0, sin},
                {0, 1, 0},
                {-sin, 0, cos}
            };
            return rotationY;
        }

        public static float[,] RotationZ(float angle)
        {
            float sin = (float)Math.Sin(angle);
            float cos = (float)Math.Cos(angle);

            float[,] rotationZ = new float[3, 3] {
                {cos, -sin, 0},
                {sin, cos, 0},
                {0, 0, 1}
            };
            return rotationZ;
        }

    }
}
