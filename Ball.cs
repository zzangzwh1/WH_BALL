//name : Wonhyuk Cho
//Submission Code :  1211_2300_A03

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDIDrawer;
using System.Drawing;

namespace ICA03_Static_Balls_Of_Fun
{
    class Ball
    {
        //field random, CDrawer and Radious
        private static Random rnd = new Random();
        public static CDrawer gdi = null;
        private static int _bRadius;     
        public static int bRadious {
            set
            {
                // increment and decrement of b Radius
                if(value > 0)
                {             
                    //increment of radious
                    _bRadius += Math.Abs(value);
                    // when ball is bigger than width of gdi or height
                    if(_bRadius *2>= gdi.ScaledWidth || _bRadius*2 >= gdi.ScaledHeight  )
                    _bRadius -= Math.Abs(value);
                }
                else
                {
                    //decrement of radius
                    _bRadius -= Math.Abs(value);
                    //when decrement of radius this code shows minimum size of ball are in gdi other wise ball will be disapear from gdi
                    //due to decrement
                     if(_bRadius *2 <=0)
                    _bRadius += Math.Abs(value);
                }
             
            }
            get { return _bRadius; }
          
        
        }
        //field color, point,location x velocity y velocity and ialive
        private Color _bColor;
        private Point Location;
        private int _xVel;  
        private int _yVel;
        public int yVel
        {
            set
            {
                _yVel = value;
                if (value > 10)
                    _yVel = 10;
                if (value < -10)
                    _yVel = -10;
            }
        }
        private int _iAlive;
        //bool static loading
        public static bool Loading {
            set
            {
                //when trye clear when its not render
                if (value)
                    gdi.Clear();
                else
                {
                    gdi.Render();
                }

            }

            }
        //static ball
        static Ball()
        {
            //random size of width and height of gdi
            gdi = new CDrawer(rnd.Next(600, 901), rnd.Next(500, 801), bContinuousUpdate: false);
            //random num of radious
            _bRadius = rnd.Next(10, 81);
        }
        //constructor of ball
        public Ball()
        {
            //rand color
            this._bColor = RandColor.GetColor();
            //random xvelocity (-10~10)
            this._xVel = rnd.Next(-10, 11);
            //random yvelocity (-10~10)
            this._yVel = rnd.Next(-10, 11);
            //location
            this.Location = new Point(rnd.Next(_bRadius, gdi.ScaledWidth - _bRadius ),rnd.Next(_bRadius, gdi.ScaledHeight - _bRadius ));
            //random nu between 50~127 ialive
            this._iAlive = rnd.Next(50, 128);

        }
        /// <summary>
        /// show ball will provide in gdi centerellise
        /// </summary>
        public void ShowBall()
        {
            if(_bRadius > 0)
            {
             Ball.gdi.AddCenteredEllipse(Location.X, Location.Y, _bRadius * 2, _bRadius * 2, Color.FromArgb(_iAlive, _bColor));
               
            }
        }
           /// <summary>
           /// move ball
           /// </summary>
        public void MoveBall()
        {
            //decrement of ialive
            --_iAlive;
            //when lower than 1
            if(_iAlive <1)
            {
                // location will provide new point
                Location = new Point(rnd.Next(_bRadius, Ball.gdi.ScaledWidth - _bRadius ) , rnd.Next(_bRadius, Ball.gdi.ScaledHeight - _bRadius));
                // ialive will be 50~127
                _iAlive = rnd.Next(50, 128);
            }
            
            if(Location.X +_xVel  <=_bRadius || Location.X+ _xVel > Ball.gdi.ScaledWidth - _bRadius)
            {
                _xVel *= -1;
            }
            Location.X += _xVel;
            if(Location.Y +_yVel <=_bRadius || Location.Y +_yVel > Ball.gdi.ScaledHeight - _bRadius)
            {
                _yVel *= -1;
            }
            Location.Y += _yVel;
            //boundary check
            CheckBorder();
        }
         /// <summary>
         /// boundary check
         /// </summary>
        public void CheckBorder()
        {
            //when x location is smaller than radius location will be radious
            if (Location.X < _bRadius)
                Location.X = _bRadius;
            //when location x is bigger than gdi widh that subtracted by radius
            else if (Location.X > Ball.gdi.ScaledWidth - _bRadius)
                //location x will be gdi scaled 0 radius
                Location.X = Ball.gdi.ScaledWidth - _bRadius;
            //when y location is smaller than radius location will be radious
            if (Location.Y < _bRadius)
               Location.Y = _bRadius;
            //when location Y is bigger than gdi widh that subtracted by radius
            else if (Location.Y > Ball.gdi.ScaledHeight - _bRadius)
                Location.Y = Ball.gdi.ScaledHeight - _bRadius;
        }
   
    }
}

