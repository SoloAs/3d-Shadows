using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Tao.FreeGlut;
using Tao.OpenGl;
using Tao.Platform.Windows;

namespace Shadows
{
    struct TPoint
    {
        public float x;
        public float y;
        public float z;
        public TPoint(float x, float y, float z)
        {
            this.x = x; this.y = y; this.z = z;
        }
    }

    

    public partial class Form1 : Form
    {

 
        bool rotating = false;
        MouseEventArgs e0;
        Figure _figure = new Figure();
        Shadow _shadow = new Shadow();
        Shadow shadow = new Shadow();

     

        public Form1()
        {
            InitializeComponent();
            myCtr.InitializeContexts();
        }

   

      
        void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0) Gl.glScalef(0.9f, 0.9f, 0.9f);
            else if (e.Delta < 0) Gl.glScalef(1.1f, 1.1f, 1.1f);
            Redraw();
            myCtr.Invalidate();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
          //  TPoint temp = new TPoint();
         //   temp.x = 0; temp.y = 0; temp.z = 8;
        //    shadow.LightPos = temp;
            MouseWheel += new MouseEventHandler(Form1_MouseWheel);
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);

            Gl.glClearColor(255, 255, 255, 1);

            Gl.glViewport(0, 0, myCtr.Width, myCtr.Height);

            Gl.glMatrixMode(Gl.GL_PROJECTION);

            Gl.glLoadIdentity();

            float ratio = (float)myCtr.Width / (float)myCtr.Height;
            Glu.gluPerspective(45, ratio, 0.1, 200);

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glColor3f(0, 0, 0);
            Gl.glTranslatef(0, 0, -15);
            _shadow.initLight();
         //   shadow.initLight();
        }

        void Redraw()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            _shadow.Draw();
            _figure.Draw();
         //  shadow.Draw();
        }



        private void myCtr_MouseDown(object sender, MouseEventArgs e)
        {
            rotating = true;
            e0 = e;
        }

        private void myCtr_MouseUp(object sender, MouseEventArgs e)
        {
            rotating = false;
        }

        private void myCtr_MouseMove(object sender, MouseEventArgs e)
        {   
            int dx, dy;
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
            if (rotating)
            {
                dx = e.X - e0.X; dy = e.Y - e0.Y;
                Gl.glRotatef(dx/10, 1, 0, 0);
                Gl.glRotatef(dy/10, 0, 1, 0);
                Gl.glRotatef((dx / 2 + dy / 2)/10, 0, 0, 1);
                Redraw();
                myCtr.Invalidate();
            }
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            _figure.number = _shadow.number = 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            _figure.number = _shadow.number =  2;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            _figure.number = _shadow.number = 3;     
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            _figure.number = _shadow.number = 4;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            _figure.number = _shadow.number = 5;
        }

        private void myCtr_KeyPress(object sender, KeyPressEventArgs e)
        {
            const float delta = 0.2f;
            TPoint temp = _shadow.LightPos;
            switch (e.KeyChar)
            {
                case '=':
                    {   _shadow.bg--;
                        break;

                    }
                case '-':
                    {
                        _shadow.bg++;
                        break;
                    }

                case 'w':
                    {
                        temp.y += delta; 
                        break;
                    }
                case 's':
                    {
                        temp.y -= delta;
                        break;
                    }
                case 'd':
                    {
                        temp.x += delta;
                        break;
                    }
                case 'a':
                    {
                        temp.x -= delta;
                        break;
                    }
                case 'e':
                    {
                        temp.z += delta;
                        break;
                    }
                case 'q':
                    {
                        temp.z -= delta;
                        break;
                    }
            }
            _shadow.LightPos = temp;
            Redraw();
            myCtr.Invalidate();
            }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            myCtr.Dispose();
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glDisable(Gl.GL_LIGHTING);
            Gl.glDisable(Gl.GL_LIGHT0);
            Gl.glDisable(Gl.GL_DEPTH_TEST);
            
        }

       
        }

    
    }

