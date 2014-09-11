using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tao.FreeGlut;
using Tao.OpenGl;
using Tao.Platform.Windows;

namespace Shadows
{
    class Figure: Drawings
    { 
        override public void Draw()
        {
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
            int x = 1;

            switch (number)
            {
                case 1: //тетраэдр
                    {for (int i = 0; i < 4; i++)                   
                    {
                        
                        Gl.glBegin(Gl.GL_TRIANGLES);
                        Gl.glNormal3f(0, 0, x=-x);
                        Gl.glVertex3dv(ref vdata1[tindices1[i, 0], 0]);
                        Gl.glNormal3f(0, 0, x = -x);
                        Gl.glVertex3dv(ref vdata1[tindices1[i, 1], 0]);
                        Gl.glNormal3f(0, 0, x = -x);
                        Gl.glVertex3dv(ref vdata1[tindices1[i, 2], 0]);
                        Gl.glEnd();
                    }                    
                    break;
                   }
                case 2: //куб
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            Gl.glBegin(Gl.GL_POLYGON);
                            Gl.glNormal3f(0, 0, x = -x);
                            Gl.glVertex3dv(ref vdata2[tindices2[i, 0], 0]);
                            Gl.glNormal3f(0, 0, x = -x);
                            Gl.glVertex3dv(ref vdata2[tindices2[i, 1], 0]);
                            Gl.glNormal3f(0, 0, x = -x);
                            Gl.glVertex3dv(ref vdata2[tindices2[i, 2], 0]);
                            Gl.glNormal3f(0, 0, x = -x);
                            Gl.glVertex3dv(ref vdata2[tindices2[i, 3], 0]);
                            Gl.glEnd();
                        }
                        break;
                    }
                case 3:  //октаэдр
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            Gl.glBegin(Gl.GL_TRIANGLES);
                            Gl.glNormal3f(0, 0, x = -x);
                            Gl.glVertex3dv(ref vdata3[tindices3[i, 0], 0]);
                            Gl.glNormal3f(0, 0, x = -x);
                            Gl.glVertex3dv(ref vdata3[tindices3[i, 1], 0]);
                            Gl.glNormal3f(0, 0, x = -x);
                            Gl.glVertex3dv(ref vdata3[tindices3[i, 2], 0]);
                            Gl.glEnd();
                        }
                        break;
                    }
                case 4: //икосаэдр
                    {
                          for (int i = 0; i < 20; i++)
                            {
                                Gl.glBegin(Gl.GL_TRIANGLES);
                                Gl.glNormal3f(0, 0, x = -x);
                                Gl.glVertex3dv(ref vdata4[tindices4[i, 0], 0]);
                                Gl.glNormal3f(0, 0, x = -x);
                                Gl.glVertex3dv(ref vdata4[tindices4[i, 1], 0]);
                                Gl.glNormal3f(0, 0, x = -x);
                                Gl.glVertex3dv(ref vdata4[tindices4[i, 2], 0]);
                               Gl.glEnd();
                            }
                          break;
                    }

                case 5:
                    {  
                        for (int i = 0; i < 12; i++)
                        {
                             Gl.glBegin(Gl.GL_POLYGON);
                            Gl.glNormal3f(0, 0, x = -x);
                            Gl.glVertex3dv(ref vdata5[tindices5[i, 0], 0]);
                            Gl.glNormal3f(0, 0, x = -x);
                            Gl.glVertex3dv(ref vdata5[tindices5[i, 1], 0]);
                            Gl.glNormal3f(0, 0, x = -x);
                            Gl.glVertex3dv(ref vdata5[tindices5[i, 2], 0]);
                            Gl.glNormal3f(0, 0, x = -x);
                            Gl.glVertex3dv(ref vdata5[tindices5[i, 3], 0]);
                            Gl.glNormal3f(0, 0, x = -x);
                            Gl.glVertex3dv(ref vdata5[tindices5[i, 4], 0]);  Gl.glEnd();  
                        } 
                        break;
                    }//додекаэдр
            }
        }
    

      
    }
}
