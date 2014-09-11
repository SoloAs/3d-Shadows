using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tao.FreeGlut;
using Tao.OpenGl;
using Tao.Platform.Windows;

namespace Shadows
{ 
    class Drawing
    {
       
 
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
        public void Redraw(float[] vertices)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            int x = Gl.GL_POLYGON;

            Gl.glEnableClientState(Gl.GL_VERTEX_ARRAY);
            Gl.glVertexPointer(3, Gl.GL_FLOAT, 0, vertices);
            Gl.glNormal3f(0.0f, 0.0f, 1);
            Gl.glDrawArrays(x, 0, 4);
            Gl.glNormal3f(0.0f, 0.0f, -1);
            Gl.glDrawArrays(x, 4, 4); 
            Gl.glNormal3f(0.0f, 0.0f, 1);
            Gl.glDrawArrays(x, 8, 4);
            Gl.glNormal3f(0.0f, 0.0f, -1);
            Gl.glDrawArrays(x, 12, 4);
            Gl.glNormal3f(0.0f, 0.0f, 1);
            Gl.glDrawArrays(x, 16, 4);
            Gl.glDrawArrays(x, 20, 4);
            Gl.glFlush();
        }

        public TPoint findProjection(TPoint p1, TPoint p2, float z0)
        {
            float y = (z0 - p1.z) * (p1.y - p2.y) / (p1.z - p2.z) + p1.y;
            float x = (z0 - p1.z) * (p1.x - p2.x) / (p1.z - p2.z) + p1.x;
            return new TPoint(x, y, z0);
        }
    }
}
