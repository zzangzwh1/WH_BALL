// Name Wonhyuk Cho
// Submission Code :1211_2300_A03
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDIDrawer;
using System.Threading;

namespace ICA03_Static_Balls_Of_Fun
{
    public partial class Form1 : Form
    {
        //Ball List
        List<Ball> _list = new List<Ball>();

        public Form1()
        {
            InitializeComponent();
            //Form Title
            this.Text = "ICA03_Wonhyuk  Static Balls of Fun ";
            this.Shown += Form1_Shown1;

            //key and mouse wheel events added
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
            this.MouseWheel += Form1_MouseWheel;

            //Thread ball , background true and start
            Thread BallThread = new Thread(new ThreadStart(BallMove));
            BallThread.IsBackground = true;
            BallThread.Start();


        }
        /// <summary>
        /// Thread BallMove
        /// will load the ball when iis true and trhought list it will show and move the ball
        /// </summary>
        private void BallMove()
        {
            while (true) {
                //ball loading 
                Ball.Loading = true;
                //lock list
                lock (_list)
                {
                    foreach (Ball b in _list)
                    {
                        //ball move
                        b.MoveBall();
                        //show ball
                        b.ShowBall();

                    }
                }
                //ball load false
                Ball.Loading = false;
                //thread sleep 25
                Thread.Sleep(25);

            }
        }
        //Mouse wheel event
        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            //Ball b Radious = e.Delta/10
            Ball.bRadious = e.Delta / 10;
            //Ball size will be on title
            this.Text = $"Ball Size : {Ball.bRadious}";
        }

        //Key Down Events
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // when key + code pressed 5 balls will be added from list
            if (e.KeyCode == Keys.Add)
            {
                lock (_list)
                {
                    for (int i = 0; i < 5; ++i)
                    {
                        _list.Add(new Ball());
                    }
                }
            }
                // when - button pressed list will be cleared
                else if (e.KeyCode == Keys.Subtract)
                {
                    _list.Clear();
                }
            
          
        }
        //this will be gdi position
        private void Form1_Shown1(object sender, EventArgs e) => Ball.gdi.Position = new Point(this.Right, this.Top);
  
    }
}
