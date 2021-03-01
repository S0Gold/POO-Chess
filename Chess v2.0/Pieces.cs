using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Chess_v2._0
{
    class Pieces
    {

        protected string color;

        public Pieces(string color)
        {
            this.color = color;
        }

        public string getColor()
        {
            return color;
        }

        public virtual void Move(int Xcoord, int Ycoord, Board[,] MyBoard, Button[,] MyButton)
        {
            Rook MyRook = new Rook(color);
            Bishop MyBishop = new Bishop(color);
            MyBishop.Move(Xcoord, Ycoord, MyBoard, MyButton);
            MyRook.Move(Xcoord, Ycoord, MyBoard, MyButton);
        }

        public virtual void canMove(int Xcoord, int Ycoord, Board[,] MyBoard, Button[,] MyButton)
        {
            Rook MyRook = new Rook(color);
            Bishop MyBishop = new Bishop(color);
            MyBishop.Move(Xcoord, Ycoord, MyBoard, MyButton);
            MyRook.Move(Xcoord, Ycoord, MyBoard, MyButton);
        }

    }
       
}





