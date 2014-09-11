using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tao.FreeGlut;
using Tao.OpenGl;
using Tao.Platform.Windows;

//namespace Shadows
{
    class Drawing
    {
        public void Resize()
        {
            Gl.glScalef(0.9f, 0.9f, 0.9f);
        }
        public void Redraw(float[] vertices)
        {
        Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glVertexPointer(3, Gl.GL_FLOAT, 0, vertices);
            Gl.glDrawArrays(Gl.GL_POLYGON, 0, 4);
            Gl.glDrawArrays(Gl.GL_POLYGON, 4, 4);
            Gl.glDrawArrays(Gl.GL_POLYGON, 8, 4);
            Gl.glDrawArrays(Gl.GL_POLYGON, 12, 4);
            Gl.glDrawArrays(Gl.GL_POLYGON, 16, 4);
            Gl.glDrawArrays(Gl.GL_POLYGON, 20, 4); 
            
        }
    }
}
