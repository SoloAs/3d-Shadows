using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shadows
{
    abstract class Drawings
    {
        public byte number;
        const double X = 2.255731112119133606 ;
        const double Z = 4.420650808352039932;
        const double face = 3;
        public double[,] vdata4 = new double[12, 3]  //вершины          //икосаэдр
            {
              {-X, 0, Z}, {X, 0, Z}, {-X, 0, -Z}, {X, 0, -Z},
              {0, Z, X}, {0, Z, -X}, {0, -Z, X}, {0, -Z, -X},
              {Z, X, 0}, {-Z, X, 0}, {Z, -X, 0}, {-Z, -X, 0}
            };
        public int[,] tindices4 = new int[20, 3]     //грани
            {
              {0,4,1}, {0,9,4}, {9,5,4}, {4,5,8}, {4,8,1},
              {8,10,1}, {8,3,10}, {5,3,8}, {5,2,3}, {2,7,3},
              {7,10,3}, {7,6,10}, {7,11,6}, {11,0,6}, {0,1,6},
              {6,1,10}, {9,0,11}, {9,11,2}, {9,2,5}, {7,2,11} 
            };

        
        public double[,] vdata2 = new double[8, 3]                         //куб
            {
                {-face, -face, 2*face}, {face, -face, 2*face}, {-face, -face, 0}, {face, -face, 0},
                {face, face, 2*face}, {-face, face, 2*face},{face, face, 0}, {-face, face, 0}   
            };
        public int[,] tindices2 = new int[6, 4]
            {
                {0,1,4,5},{2,3,6,7},
                {0,2,7,5},{1,3,6,4},
                {0,1,3,2},{5,4,6,7}
            };

        public double[,] vdata1 = new double[4, 3]
            {
                {-face, -face, 2*face}, 
                {face, -face, 0}, {face, face, 2*face}, {-face, face, 0}
            };
        public int[,] tindices1 = new int[4, 3]
            {
                {0,1,3}, {0,2,3}, {0,2,1}, {2,1,3}
            };
        public double[,] vdata5 = new double[20, 3]
        {
            { 0.938f,     0.938f,     0.938f},
            { 0.580f,     0.000f,     1.5018f},
            {-1.5018f,    -0.580f,     0.000f},
            { 1.5018f,     0.580f,     0.000f},
            {-0.938f,     0.938f,    -0.938f},
            { 0.000f,    -1.5018f,    -0.580f},
            {-1.5018f,     0.580f,     0.000f},
            { 0.938f,    -0.938f,     0.938f},
            {-0.938f,     0.938f,     0.938f},
            {-0.938f,    -0.938f,     0.938f},
            { 0.938f,    -0.938f,    -0.938f},
            { 0.580f,     0.000f,    -1.5018f},
            {-0.938f,    -0.938f,    -0.938f},
            { 0.000f,    -1.5018f,     0.580f},
            { 0.000f,     1.5018f,    -0.580f},
            {-0.580f,     0.000f,     1.5018f},
            { 1.5018f,    -0.580f,     0.000f},
            {-0.580f,     0.000f,    -1.5018f},
            { 0.938f,     0.938f,    -0.938f},
            { 0.000f,     1.5018f,     0.580f}
        };

        public int[,] tindices5 = new int[12, 5]
            {
                {3,16,10,11,18},{10,11,17,12,5},{11,18,14,4,17},{3,18,14,19,0},{3,16,7,1,0},{10,16,7,13,5},
                {13,5,12,2,9},{0,19,8,15,1},{7,13,9,15,1},{4,17,12,2,6},{14,4,6,8,19},{6,8,15,9,2}
            };



        public double[,] vdata3 = new double[6, 3] //октаэдр
            {
                {0,0,0}, {face,0,0}, {face,0,face}, {0,0,face},
                {face / 2,face / 2 * Math.Sqrt(2),face / 2}, {face / 2,-face / 2 * Math.Sqrt(2),face / 2}
            };

        public int[,] tindices3 = new int[8, 3]
            {
                {0,1,4}, {1,2,4}, {2,3,4}, {3,4,0},
                {0,5,1}, {1,2,5}, {2,3,5}, {3,0,5}
            };

       abstract public void Draw();
    }
}
