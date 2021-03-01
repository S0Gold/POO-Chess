using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_v2._0
{
    class Queen : Pieces
    {


        public Queen(string PC, ArrayList a, Board[,] MyBoard, Button[,] MyButton) : base(PC)
        {

            InitQueen(a, MyBoard, MyButton);
        }

        private void InitQueen(ArrayList a, Board[,] MyBoard, Button[,] MyButton)
        {
            if (color == "Black")
            {
                MyButton[0, 3].Image = Properties.Resources.BlackQueen;
                MyBoard[0, 3].SwapProperties(true, color, "Queen");
                a.Add(MyBoard[0, 3]);
            }
            else
            {
                MyButton[7, 3].Image = Properties.Resources.WhiteQueen;
                MyBoard[7, 3].SwapProperties(true, color, "Queen");
                a.Add(MyBoard[7, 3]);
            }
        }


        public override void Move(int Xcoord, int Ycoord, Board[,] MyBoard, Button[,] MyButton)
        {
            Rook MyRook = new Rook(color);
            Bishop MyBishop = new Bishop(color);
            MyBishop.Move(Xcoord, Ycoord, MyBoard, MyButton);
            MyRook.Move(Xcoord, Ycoord, MyBoard, MyButton);
        }

        public override void canMove(int Xcoord, int Ycoord, Board[,] MyBoard, Button[,] MyButton)
        {
            Rook MyRook = new Rook(color);
            Bishop MyBishop = new Bishop(color);
            MyBishop.canMove(Xcoord, Ycoord, MyBoard, MyButton);
            MyRook.canMove(Xcoord, Ycoord, MyBoard, MyButton);
        }

    }
}
