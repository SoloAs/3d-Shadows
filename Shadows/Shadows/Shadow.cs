using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tao.FreeGlut;
using Tao.OpenGl;
using Tao.Platform.Windows;

namespace Shadows
{
    class Shadow : Drawings
    {
        float background = -10;
        public float bg
        {
            get { return background; }
            set { background = value; }
        }

        TPoint light = new TPoint(0,0,7);
        public TPoint LightPos
        {
            get { return light; }
            set { light = value; }
        }



        public void initLight()
        {
            // Gl.glNormal3f(0.0f, 0.0f, 1.0f);
            float[] light_ambient = { 0.0f, 0.0f, 0.0f, 1.0f };
            float[] light_diffuse = { 1.0f, 1.0f, 1.0f, 1.0f };
            float[] light_specular = { 1.0f, 1.0f, 1.0f, 1.0f };
            float[] light_position = { 0, 0, 1, 0 };
            float[] mat1_dif = { 1f, 0f, 1f };
            float[] mat1_amb = { 0.2f, 0.2f, 0.2f };
            float[] mat1_spec = { 0.6f, 0.6f, 0.6f };
            float mat1_shininess = 0.5f * 128;
            // параметры источника света
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_AMBIENT, light_ambient);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, light_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_SPECULAR, light_specular);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, light_position);
            // включаем освещение и источник света
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
            // включаем z-буфер
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glShadeModel(Gl.GL_SMOOTH);
            Gl.glMaterialfv(Gl.GL_FRONT_AND_BACK,
            Gl.GL_AMBIENT, mat1_amb); // фоновый цвет материала
            Gl.glMaterialfv(Gl.GL_FRONT_AND_BACK,
            Gl.GL_DIFFUSE, mat1_dif); // диффузионные свойства
            Gl.glMaterialfv(Gl.GL_FRONT_AND_BACK,
            Gl.GL_SPECULAR, mat1_spec); // зеркальные свойства
            Gl.glMaterialf(Gl.GL_FRONT_AND_BACK,
            Gl.GL_SHININESS, mat1_shininess);
        }

        public TPoint findProjection(TPoint p1, TPoint p2, float z0)
        {
            float y = (z0 - p1.z) * (p1.y - p2.y) / (p1.z - p2.z) + p1.y;
            float x = (z0 - p1.z) * (p1.x - p2.x) / (p1.z - p2.z) + p1.x;
            return new TPoint(x, y, z0);
        }

        void DrawShadowPolygone(double[,] vdata)
        {
            List<TPoint> x = new List<TPoint>();  //создание листа точек тени
            for (int i = 0; i < vdata.Length / 3; i++)
            {
                x.Add(findProjection(light, new TPoint((float)vdata[i, 0], (float)vdata[i, 1], (float)vdata[i, 2]), background));
            }

            Gl.glColor3f(0.6f, 0.6f, 0.6f);
            for (int j = 0; j < x.Count; j++)      //создание тени
            {
                Gl.glBegin(Gl.GL_TRIANGLES);
                for (int i = j + 2; i < x.Count; i++)
                {

                    Gl.glVertex3f(x[j].x, x[j].y, x[j].z);
                    Gl.glVertex3f(x[j + 1].x, x[j + 1].y, x[j + 1].z); //!!!
                    Gl.glVertex3f(x[i].x, x[i].y, x[i].z);

                } Gl.glEnd();
             
                Gl.glBegin(Gl.GL_LINES);  //создание линий проекции
                Gl.glColor3f(0, 0, 0);       
                for (int i = 0; i < x.Count; i++)
                {
                    Gl.glVertex3f(light.x, light.y, light.z);
                    Gl.glVertex3f(x[i].x, x[i].y, x[i].z);
                }
                Gl.glColor3f(0.6f, 0.6f, 0.6f);
                Gl.glEnd(); 
            }
            x.Clear();
        }

        override public void Draw()
        {
            if (bg * LightPos.z < 0)
            {
                List<TPoint> x = new List<TPoint>();  //точки полигона тени
                Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
                Gl.glDisable(Gl.GL_LIGHTING);
                Gl.glDisable(Gl.GL_LIGHT0);
                switch (number)
                {
                    case 1:
                        {
                            DrawShadowPolygone(vdata1);
                            break;
                        }
                    case 2:
                        {
                            DrawShadowPolygone(vdata2);
                            break;
                        }
                    case 3:
                        {
                            DrawShadowPolygone(vdata3);
                            break;
                        }
                    case 4:
                        {
                            DrawShadowPolygone(vdata4);
                            break;
                        }
                    case 5:
                        {
                            DrawShadowPolygone(vdata5);
                            break;
                        }
                }
            }

        }
    }
}
