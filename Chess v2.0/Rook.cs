using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_v2._0
{
    class Rook : Pieces
    {





        public Rook(string PC, ArrayList a, Board[,] MyBoard, Button[,] MyButton) : base(PC)
        {
            InitRook(a, MyBoard, MyButton);
        }

        public Rook(string PC) : base(PC)
        {

        }

        public void InitRook(ArrayList a, Board[,] MyBoard, Button[,] MyButton)
        {
            if (color == "Black")
            {
                MyButton[0, 0].Image = Properties.Resources.BlackRook;
                MyBoard[0, 0].SwapProperties(true, color, "Rook");
                a.Add(MyBoard[0, 0]);

                MyButton[0, 7].Image = Properties.Resources.BlackRook;
                MyBoard[0, 7].SwapProperties(true, color, "Rook");
                a.Add(MyBoard[0, 7]);
            }
            else
            {
                MyButton[7, 0].Image = Properties.Resources.WhiteRook;
                MyBoard[7, 0].SwapProperties(true, color, "Rook");
                a.Add(MyBoard[7, 0]);


                MyButton[7, 7].Image = Properties.Resources.WhiteRook;
                MyBoard[7, 7].SwapProperties(true, color, "Rook");
                a.Add(MyBoard[7, 7]);
            }
        }



        public override void Move(int Xcoord, int Ycoord, Board[,] MyBoard, Button[,] MyButton)
        {
            //collum possible move under the rook
            for (int i = 1; i < MyBoard[0, 0].Size; i++)
                if (Xcoord + i < MyBoard[0, 0].Size)
                    if (MyBoard[Xcoord + i, Ycoord].GetCurentlyOcupied() == false)
                    {
                        MyButton[Xcoord + i, Ycoord].BackColor = Color.Green;
                        MyBoard[Xcoord + i, Ycoord].NextLegalMove = true;
                    }
                    else
                        if (MyBoard[Xcoord + i, Ycoord].GetPieceColor() != color)
                    {
                        MyButton[Xcoord + i, Ycoord].BackColor = Color.Green;
                        MyBoard[Xcoord + i, Ycoord].NextLegalMove = true;
                        break;
                    }
                    else
                        break;
                else
                    break;


            //raw possible move to the right of the rook
            for (int i = 1; i < MyBoard[0, 0].Size; i++)
                if (Ycoord + i < MyBoard[0, 0].Size)
                    if (MyBoard[Xcoord, Ycoord + i].GetCurentlyOcupied() == false)
                    {
                        MyButton[Xcoord, Ycoord + i].BackColor = Color.Green;
                        MyBoard[Xcoord, Ycoord + i].NextLegalMove = true;
                    }
                    else
                      if (MyBoard[Xcoord, Ycoord + i].GetPieceColor() != color)
                    {
                        MyButton[Xcoord, Ycoord + i].BackColor = Color.Green;
                        MyBoard[Xcoord, Ycoord + i].NextLegalMove = true;
                        break;
                    }
                    else
                        break;
                else
                    break;

            //collum possible move above the rook
            for (int i = 1; i < MyBoard[0, 0].Size; i++)
                if (Xcoord - i >= 0)
                    if (MyBoard[Xcoord - i, Ycoord].GetCurentlyOcupied() == false)
                    {
                        MyButton[Xcoord - i, Ycoord].BackColor = Color.Green;
                        MyBoard[Xcoord - i, Ycoord].NextLegalMove = true;
                    }
                    else
                         if (MyBoard[Xcoord - i, Ycoord].GetPieceColor() != color)
                    {
                        MyButton[Xcoord - i, Ycoord].BackColor = Color.Green;
                        MyBoard[Xcoord - i, Ycoord].NextLegalMove = true;
                        break;
                    }
                    else
                        break;
                else
                    break;

            //possible move to the left of the rook
            for (int i = 1; i < MyBoard[0, 0].Size; i++)
                if (Ycoord - i >= 0)
                    if (MyBoard[Xcoord, Ycoord - i].GetCurentlyOcupied() == false)
                    {
                        MyButton[Xcoord, Ycoord - i].BackColor = Color.Green;
                        MyBoard[Xcoord, Ycoord - i].NextLegalMove = true;
                    }
                    else
                          if (MyBoard[Xcoord, Ycoord - i].GetPieceColor() != color)
                    {
                        MyButton[Xcoord, Ycoord - i].BackColor = Color.Green;
                        MyBoard[Xcoord, Ycoord - i].NextLegalMove = true;
                        break;
                    }
                    else
                        break;
                else
                    break;


        }

        public override void canMove(int Xcoord, int Ycoord, Board[,] MyBoard, Button[,] MyButton)
        {
            //collum possible move under the rook
            for (int i = 1; i < MyBoard[0, 0].Size; i++)
                if (Xcoord + i < MyBoard[0, 0].Size)
                    if (MyBoard[Xcoord + i, Ycoord].GetCurentlyOcupied() == false)
                    {
                        // MyButton[Xcoord + i, Ycoord].BackColor = Color.Red;
                        MyBoard[Xcoord + i, Ycoord].NextLegalMove = true;
                    }
                    else

                    {
                        // MyButton[Xcoord + i, Ycoord].BackColor = Color.Red;
                        MyBoard[Xcoord + i, Ycoord].NextLegalMove = true;
                        break;
                    }

                else
                    break;


            //raw possible move to the right of the rook
            for (int i = 1; i < MyBoard[0, 0].Size; i++)
                if (Ycoord + i < MyBoard[0, 0].Size)
                    if (MyBoard[Xcoord, Ycoord + i].GetCurentlyOcupied() == false)
                    {
                        // MyButton[Xcoord, Ycoord + i].BackColor = Color.Red;
                        MyBoard[Xcoord, Ycoord + i].NextLegalMove = true;
                    }
                    else

                    {
                        //  MyButton[Xcoord, Ycoord + i].BackColor = Color.Red;
                        MyBoard[Xcoord, Ycoord + i].NextLegalMove = true;
                        break;
                    }

                else
                    break;

            //collum possible move above the rook
            for (int i = 1; i < MyBoard[0, 0].Size; i++)
                if (Xcoord - i >= 0)
                    if (MyBoard[Xcoord - i, Ycoord].GetCurentlyOcupied() == false)
                    {
                        // MyButton[Xcoord - i, Ycoord].BackColor = Color.Red;
                        MyBoard[Xcoord - i, Ycoord].NextLegalMove = true;
                    }
                    else

                    {
                        // MyButton[Xcoord - i, Ycoord].BackColor = Color.Red;
                        MyBoard[Xcoord - i, Ycoord].NextLegalMove = true;
                        break;
                    }

                else
                    break;

            //possible move to the left of the rook
            for (int i = 1; i < MyBoard[0, 0].Size; i++)
                if (Ycoord - i >= 0)
                    if (MyBoard[Xcoord, Ycoord - i].GetCurentlyOcupied() == false)
                    {
                        // MyButton[Xcoord, Ycoord - i].BackColor = Color.Red;
                        MyBoard[Xcoord, Ycoord - i].NextLegalMove = true;
                    }
                    else

                    {
                        // MyButton[Xcoord, Ycoord - i].BackColor = Color.Red;
                        MyBoard[Xcoord, Ycoord - i].NextLegalMove = true;
                        break;
                    }
                else
                    break;


        }

    }
}
