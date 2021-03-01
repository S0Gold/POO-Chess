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
    class Pawn : Pieces
    {

        public Pawn(string PC, ArrayList a, Board[,] MyBoard, Button[,] MyButton) : base(PC)
        {

            InitPawn(a, MyBoard, MyButton);
        }



        public void InitPawn(ArrayList a, Board[,] MyBoard, Button[,] MyButton)
        {
            if (color == "Black")

                for (int j = 0; j < MyBoard[0, 0].Size; j++)
                {
                    MyButton[1, j].Image = Properties.Resources.BlackPawn;
                    MyBoard[1, j].SwapProperties(true, color, "Pawn");
                    a.Add(MyBoard[1, j]);

                }
            else
                for (int j = 0; j < MyBoard[0, 0].Size; j++)
                {
                    MyButton[6, j].Image = Properties.Resources.WhitePawn;
                    MyBoard[6, j].SwapProperties(true, color, "Pawn");
                    a.Add(MyBoard[6, j]);

                }
        }

        public override void Move(int Xcoord, int Ycoord, Board[,] MyBoard, Button[,] MyButton)
        {
            if (color == "Black")
            {
                if (Xcoord + 1 < MyBoard[0, 0].Size && MyBoard[Xcoord + 1, Ycoord].GetCurentlyOcupied() == false)
                {
                    MyButton[Xcoord + 1, Ycoord].BackColor = Color.Green;
                    MyBoard[Xcoord + 1, Ycoord].NextLegalMove = true;
                }

                if (Xcoord == 1 && Xcoord + 2 < MyBoard[0, 0].Size && MyBoard[Xcoord + 1, Ycoord].GetCurentlyOcupied() == false  && MyBoard[Xcoord + 2, Ycoord].GetCurentlyOcupied() == false)
                {
                    MyButton[Xcoord + 2, Ycoord].BackColor = Color.Green;
                    MyBoard[Xcoord + 2, Ycoord].NextLegalMove = true;
                }

                if (Xcoord + 1 < MyBoard[0, 0].Size && Ycoord + 1 < MyBoard[0, 0].Size)
                    if (MyBoard[Xcoord + 1, Ycoord + 1].GetCurentlyOcupied() == true && MyBoard[Xcoord + 1, Ycoord + 1].GetPieceColor() != color)
                    {
                        MyButton[Xcoord + 1, Ycoord + 1].BackColor = Color.Green;
                        MyBoard[Xcoord + 1, Ycoord + 1].NextLegalMove = true;

                    }

                if (Xcoord + 1 < MyBoard[0, 0].Size && Ycoord - 1 >= 0)
                    if (MyBoard[Xcoord + 1, Ycoord - 1].GetCurentlyOcupied() == true && MyBoard[Xcoord + 1, Ycoord - 1].GetPieceColor() != color)
                    {
                        MyButton[Xcoord + 1, Ycoord - 1].BackColor = Color.Green;
                        MyBoard[Xcoord + 1, Ycoord - 1].NextLegalMove = true;
                    }
            }

            else
            {
                if (Xcoord - 1 >= 0 && MyBoard[Xcoord - 1, Ycoord].GetCurentlyOcupied() == false)
                {
                    MyButton[Xcoord - 1, Ycoord].BackColor = Color.Green;
                    MyBoard[Xcoord - 1, Ycoord].NextLegalMove = true;
                }

                if (Xcoord == 6 && Xcoord - 2 >= 0 && MyBoard[Xcoord - 1, Ycoord].GetCurentlyOcupied() == false && MyBoard[Xcoord - 2, Ycoord].GetCurentlyOcupied() == false)
                {
                    MyButton[Xcoord - 2, Ycoord].BackColor = Color.Green;
                    MyBoard[Xcoord - 2, Ycoord].NextLegalMove = true;
                }

                if (Xcoord - 1 >= 0 && Ycoord + 1 < MyBoard[0, 0].Size)
                    if (MyBoard[Xcoord - 1, Ycoord + 1].GetCurentlyOcupied() == true && MyBoard[Xcoord - 1, Ycoord + 1].GetPieceColor() != color)
                    {
                        MyButton[Xcoord - 1, Ycoord + 1].BackColor = Color.Green;
                        MyBoard[Xcoord - 1, Ycoord + 1].NextLegalMove = true;
                    }

                if (Xcoord - 1 >= 0 && Ycoord - 1 >= 0)
                    if (MyBoard[Xcoord - 1, Ycoord - 1].GetCurentlyOcupied() == true && MyBoard[Xcoord - 1, Ycoord - 1].GetPieceColor() != color)
                    {
                        MyButton[Xcoord - 1, Ycoord - 1].BackColor = Color.Green;
                        MyBoard[Xcoord - 1, Ycoord - 1].NextLegalMove = true;
                    }
            }
        }

        public override void canMove(int Xcoord, int Ycoord, Board[,] MyBoard, Button[,] MyButton)
        {
            if (color == "Black")
            {
                
                if (Xcoord + 1 < MyBoard[0, 0].Size && Ycoord + 1 < MyBoard[0, 0].Size)
                    if (MyBoard[Xcoord + 1, Ycoord + 1].GetCurentlyOcupied() == true)
                    {
                       // MyButton[Xcoord + 1, Ycoord + 1].BackColor = Color.Red;
                        MyBoard[Xcoord + 1, Ycoord + 1].NextLegalMove = true;

                    }

                if (Xcoord + 1 < MyBoard[0, 0].Size && Ycoord - 1 >= 0)
                    if (MyBoard[Xcoord + 1, Ycoord - 1].GetCurentlyOcupied() == true)
                    {
                       // MyButton[Xcoord + 1, Ycoord - 1].BackColor = Color.Red;
                        MyBoard[Xcoord + 1, Ycoord - 1].NextLegalMove = true;
                    }
            }

            else
            {
 
                if (Xcoord - 1 >= 0 && Ycoord + 1 < MyBoard[0, 0].Size)
                    if (MyBoard[Xcoord - 1, Ycoord + 1].GetCurentlyOcupied() == true)
                    {
                       // MyButton[Xcoord - 1, Ycoord + 1].BackColor = Color.Red;
                        MyBoard[Xcoord - 1, Ycoord + 1].NextLegalMove = true;
                    }

                if (Xcoord - 1 >= 0 && Ycoord - 1 >= 0)
                    if (MyBoard[Xcoord - 1, Ycoord - 1].GetCurentlyOcupied() == true)
                    {
                       // MyButton[Xcoord - 1, Ycoord - 1].BackColor = Color.Red;
                        MyBoard[Xcoord - 1, Ycoord - 1].NextLegalMove = true;
                    }
            }
        }
    }
}
