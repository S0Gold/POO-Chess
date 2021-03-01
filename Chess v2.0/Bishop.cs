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
    class Bishop : Pieces
    {



        public Bishop(string PC, ArrayList a, Board[,] MyBoard, Button[,] MyButton) : base(PC)
        {
            InitBishop(a, MyBoard, MyButton);
        }

        public Bishop(string PC) : base(PC)
        {


        }
        private void InitBishop(ArrayList a, Board[,] MyBoard, Button[,] MyButton)
        {
            if (color == "Black")
            {
                MyButton[0, 2].Image = Properties.Resources.BlackBishop;
                MyBoard[0, 2].SwapProperties(true, color, "Bishop");
                a.Add(MyBoard[0, 2]);

                MyButton[0, 5].Image = Properties.Resources.BlackBishop;
                MyBoard[0, 5].SwapProperties(true, color, "Bishop");
                a.Add(MyBoard[0, 5]);
            }
            else
            {
                MyButton[7, 2].Image = Properties.Resources.WhiteBishop;
                MyBoard[7, 2].SwapProperties(true, color, "Bishop");
                a.Add(MyBoard[7, 2]);

                MyButton[7, 5].Image = Properties.Resources.WhiteBishop;
                MyBoard[7, 5].SwapProperties(true, color, "Bishop");
                a.Add(MyBoard[7, 5]);
            }
        }


        public override void Move(int Xcoord, int Ycoord, Board[,] MyBoard, Button[,] MyButton)
        {
            //down right move
            for (int i = 1; i < MyBoard[0, 0].Size; i++)
                if (Xcoord + i < MyBoard[0, 0].Size && Ycoord + i < MyBoard[0, 0].Size)
                    if (MyBoard[Xcoord + i, Ycoord + i].GetCurentlyOcupied() == false)
                    {
                        MyButton[Xcoord + i, Ycoord + i].BackColor = Color.Green;
                        MyBoard[Xcoord + i, Ycoord + i].NextLegalMove = true;
                    }
                    else
                        if (MyBoard[Xcoord + i, Ycoord + i].GetPieceColor() != color)
                    {
                        MyButton[Xcoord + i, Ycoord + i].BackColor = Color.Green;
                        MyBoard[Xcoord + i, Ycoord + i].NextLegalMove = true;
                        break;
                    }
                    else
                        break;
                else
                    break;


            //upper right move
            for (int i = 1; i < MyBoard[0, 0].Size; i++)
                if (Xcoord - i >= 0 && Ycoord + i < MyBoard[0, 0].Size)
                    if (MyBoard[Xcoord - i, Ycoord + i].GetCurentlyOcupied() == false)
                    {
                        MyButton[Xcoord - i, Ycoord + i].BackColor = Color.Green;
                        MyBoard[Xcoord - i, Ycoord + i].NextLegalMove = true;
                    }
                    else
                        if (MyBoard[Xcoord - i, Ycoord + i].GetPieceColor() != color)
                    {
                        MyButton[Xcoord - i, Ycoord + i].BackColor = Color.Green;
                        MyBoard[Xcoord - i, Ycoord + i].NextLegalMove = true;
                        break;
                    }
                    else
                        break;
                else
                    break;


            //down left move
            for (int i = 1; i < MyBoard[0, 0].Size; i++)
                if (Xcoord + i < MyBoard[0, 0].Size && Ycoord - i >= 0)
                    if (MyBoard[Xcoord + i, Ycoord - i].GetCurentlyOcupied() == false)
                    {
                        MyButton[Xcoord + i, Ycoord - i].BackColor = Color.Green;
                        MyBoard[Xcoord + i, Ycoord - i].NextLegalMove = true;
                    }
                    else
                        if (MyBoard[Xcoord + i, Ycoord - i].GetPieceColor() != color)
                    {
                        MyButton[Xcoord + i, Ycoord - i].BackColor = Color.Green;
                        MyBoard[Xcoord + i, Ycoord - i].NextLegalMove = true;
                        break;
                    }
                    else
                        break;
                else
                    break;


            //upper left move
            for (int i = 1; i < MyBoard[0, 0].Size; i++)
                if (Xcoord - i >= 0 && Ycoord - i >= 0)
                    if (MyBoard[Xcoord - i, Ycoord - i].GetCurentlyOcupied() == false)
                    {
                        MyButton[Xcoord - i, Ycoord - i].BackColor = Color.Green;
                        MyBoard[Xcoord - i, Ycoord - i].NextLegalMove = true;
                    }
                    else
                        if (MyBoard[Xcoord - i, Ycoord - i].GetPieceColor() != color)
                    {
                        MyButton[Xcoord - i, Ycoord - i].BackColor = Color.Green;
                        MyBoard[Xcoord - i, Ycoord - i].NextLegalMove = true;
                        break;
                    }
                    else
                        break;
                else
                    break;



        }

        public override void canMove(int Xcoord, int Ycoord, Board[,] MyBoard, Button[,] MyButton)
        {
            //down right move
            for (int i = 1; i < MyBoard[0, 0].Size; i++)
                if (Xcoord + i < MyBoard[0, 0].Size && Ycoord + i < MyBoard[0, 0].Size)
                    if (MyBoard[Xcoord + i, Ycoord + i].GetCurentlyOcupied() == false)
                    {
                        //  MyButton[Xcoord + i, Ycoord + i].BackColor = Color.Red;
                        MyBoard[Xcoord + i, Ycoord + i].NextLegalMove = true;
                    }
                    else

                    {
                        // MyButton[Xcoord + i, Ycoord + i].BackColor = Color.Red;
                        MyBoard[Xcoord + i, Ycoord + i].NextLegalMove = true;
                        break;
                    }

                else
                    break;


            //upper right move
            for (int i = 1; i < MyBoard[0, 0].Size; i++)
                if (Xcoord - i >= 0 && Ycoord + i < MyBoard[0, 0].Size)
                    if (MyBoard[Xcoord - i, Ycoord + i].GetCurentlyOcupied() == false)
                    {
                        //  MyButton[Xcoord - i, Ycoord + i].BackColor = Color.Red;
                        MyBoard[Xcoord - i, Ycoord + i].NextLegalMove = true;
                    }
                    else

                    {
                        // MyButton[Xcoord - i, Ycoord + i].BackColor = Color.Red;
                        MyBoard[Xcoord - i, Ycoord + i].NextLegalMove = true;
                        break;
                    }

                else
                    break;


            //down left move
            for (int i = 1; i < MyBoard[0, 0].Size; i++)
                if (Xcoord + i < MyBoard[0, 0].Size && Ycoord - i >= 0)
                    if (MyBoard[Xcoord + i, Ycoord - i].GetCurentlyOcupied() == false)
                    {
                        // MyButton[Xcoord + i, Ycoord - i].BackColor = Color.Red;
                        MyBoard[Xcoord + i, Ycoord - i].NextLegalMove = true;
                    }
                    else

                    {
                        // MyButton[Xcoord + i, Ycoord - i].BackColor = Color.Red;
                        MyBoard[Xcoord + i, Ycoord - i].NextLegalMove = true;
                        break;
                    }

                else
                    break;


            //upper left move
            for (int i = 1; i < MyBoard[0, 0].Size; i++)
                if (Xcoord - i >= 0 && Ycoord - i >= 0)
                    if (MyBoard[Xcoord - i, Ycoord - i].GetCurentlyOcupied() == false)
                    {
                        //  MyButton[Xcoord - i, Ycoord - i].BackColor = Color.Red;
                        MyBoard[Xcoord - i, Ycoord - i].NextLegalMove = true;
                    }
                    else

                    {
                        //  MyButton[Xcoord - i, Ycoord - i].BackColor = Color.Red;
                        MyBoard[Xcoord - i, Ycoord - i].NextLegalMove = true;
                        break;
                    }

                else
                    break;



        }
    }
}
