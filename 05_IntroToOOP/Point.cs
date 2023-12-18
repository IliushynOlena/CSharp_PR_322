using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_IntroToOOP
{
    partial class Point
    {
        public void SetX(int newX)
        {
            if (newX >= 0)
                this._xCoord = newX;
            else
                _xCoord = 0;
        }
        public void SetY(int newY)
        {
            if (newY >= 0)
                this.yCoord = newY;
            else
                yCoord = 0;
        }
        public int getX() { return _xCoord; }
        public int getY() { return yCoord; }
    }
    partial class Point
    {
        public void Print()
        {
            Console.WriteLine($"X : {_xCoord}. Y : {yCoord}");
        }
        public override string ToString()
        {
            return $"X : {_xCoord}. Y : {yCoord}";
        }
    }
    partial class Point
    {

        public Point() : this(0, 0)
        {
            //default values:
            //number : 0
            //bolean : false
            //references : null

            //_xCoord = 0;
            //yCoord = 0;
        }
        public Point(int value) : this(value, value) { }
        public Point(int x, int y)
        {
            XCoord = x;
            YCoord = y;
            count++;
        }
    }
}

namespace _05_IntroToOOP
{
    partial class Point
    {
        public void PrintWithSetPosition()
        {
            Console.SetCursorPosition(XCoord, YCoord);
            Print();
        }
    }
}
