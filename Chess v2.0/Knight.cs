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
    class Knight : Pieces
    {

        public Knight(string PC, ArrayList a, Board[,] MyBoard, Button[,] MyButton) : base(PC)
        {

            InitKnight(a, MyBoard, MyButton);
        }

        private void InitKnight(ArrayList a, Board[,] MyBoard, Button[,] MyButton)
        {

            if (color == "Black")
            {
                MyButton[0, 1].Image = Properties.Resources.BlackKnight;
                MyBoard[0, 1].SwapProperties(true, color, "Knight");
                a.Add(MyBoard[0, 1]);


                MyButton[0, 6].Image = Properties.Resources.BlackKnight;
                MyBoard[0, 6].SwapProperties(true, color, "Knight");
                a.Add(MyBoard[0, 6]);
            }
            else
            {
                MyButton[7, 1].Image = Properties.Resources.WhiteKnight;
                MyBoard[7, 1].SwapProperties(true, color, "Knight");
                a.Add(MyBoard[7, 1]);

                MyButton[7, 6].Image = Properties.Resources.WhiteKnight;
                MyBoard[7, 6].SwapProperties(true, color, "Knight");
                a.Add(MyBoard[7, 6]);
            }
        }


        public override void Move(int Xcoord, int Ycoord, Board[,] MyBoard, Button[,] MyButton)
        {
            //upper right
            if (Xcoord - 2 >= 0 && Ycoord + 1 < MyBoard[0, 0].Size)
                if (MyBoard[Xcoord - 2, Ycoord + 1].GetCurentlyOcupied() == false)
                {
                    MyButton[Xcoord - 2, Ycoord + 1].BackColor = Color.Green;
                    MyBoard[Xcoord - 2, Ycoord + 1].NextLegalMove = true;
                }
                else
                    if (MyBoard[Xcoord - 2, Ycoord + 1].GetPieceColor() != color)
                {
                    MyButton[Xcoord - 2, Ycoord + 1].BackColor = Color.Green;
                    MyBoard[Xcoord - 2, Ycoord + 1].NextLegalMove = true;
                }

            //upper left
            if (Xcoord - 2 >= 0 && Ycoord - 1 >= 0)
                if (MyBoard[Xcoord - 2, Ycoord - 1].GetCurentlyOcupied() == false)
                {
                    MyButton[Xcoord - 2, Ycoord - 1].BackColor = Color.Green;
                    MyBoard[Xcoord - 2, Ycoord - 1].NextLegalMove = true;
                }
                else
                    if (MyBoard[Xcoord - 2, Ycoord - 1].GetPieceColor() != color)
                {
                    MyButton[Xcoord - 2, Ycoord - 1].BackColor = Color.Green;
                    MyBoard[Xcoord - 2, Ycoord - 1].NextLegalMove = true;
                }

            //lower right
            if (Xcoord + 2 < MyBoard[0, 0].Size && Ycoord + 1 < MyBoard[0, 0].Size)
                if (MyBoard[Xcoord + 2, Ycoord + 1].GetCurentlyOcupied() == false)
                {
                    MyButton[Xcoord + 2, Ycoord + 1].BackColor = Color.Green;
                    MyBoard[Xcoord + 2, Ycoord + 1].NextLegalMove = true;
                }
                else
                    if (MyBoard[Xcoord + 2, Ycoord + 1].GetPieceColor() != color)
                {
                    MyButton[Xcoord + 2, Ycoord + 1].BackColor = Color.Green;
                    MyBoard[Xcoord + 2, Ycoord + 1].NextLegalMove = true;
                }

            ///lower left
            if (Xcoord + 2 < MyBoard[0, 0].Size && Ycoord - 1 >= 0)
                if (MyBoard[Xcoord + 2, Ycoord - 1].GetCurentlyOcupied() == false)
                {
                    MyButton[Xcoord + 2, Ycoord - 1].BackColor = Color.Green;
                    MyBoard[Xcoord + 2, Ycoord - 1].NextLegalMove = true;
                }
                else
                    if (MyBoard[Xcoord + 2, Ycoord - 1].GetPieceColor() != color)
                {
                    MyButton[Xcoord + 2, Ycoord - 1].BackColor = Color.Green;
                    MyBoard[Xcoord + 2, Ycoord - 1].NextLegalMove = true;
                }

            //left upper
            if (Xcoord - 1 >= 0 && Ycoord - 2 >= 0)
                if (MyBoard[Xcoord - 1, Ycoord - 2].GetCurentlyOcupied() == false)
                {
                    MyButton[Xcoord - 1, Ycoord - 2].BackColor = Color.Green;
                    MyBoard[Xcoord - 1, Ycoord - 2].NextLegalMove = true;
                }
                else
                      if (MyBoard[Xcoord - 1, Ycoord - 2].GetPieceColor() != color)
                {
                    MyButton[Xcoord - 1, Ycoord - 2].BackColor = Color.Green;
                    MyBoard[Xcoord - 1, Ycoord - 2].NextLegalMove = true;
                }


            //left down
            if (Xcoord + 1 < MyBoard[0, 0].Size && Ycoord - 2 >= 0)
                if (MyBoard[Xcoord + 1, Ycoord - 2].GetCurentlyOcupied() == false)
                {
                    MyButton[Xcoord + 1, Ycoord - 2].BackColor = Color.Green;
                    MyBoard[Xcoord + 1, Ycoord - 2].NextLegalMove = true;
                }
                else
                      if (MyBoard[Xcoord + 1, Ycoord - 2].GetPieceColor() != color)
                {
                    MyButton[Xcoord + 1, Ycoord - 2].BackColor = Color.Green;
                    MyBoard[Xcoord + 1, Ycoord - 2].NextLegalMove = true;
                }

            //right upper
            if (Xcoord - 1 >= 0 && Ycoord + 2 < MyBoard[0, 0].Size)
                if (MyBoard[Xcoord - 1, Ycoord + 2].GetCurentlyOcupied() == false)
                {
                    MyButton[Xcoord - 1, Ycoord + 2].BackColor = Color.Green;
                    MyBoard[Xcoord - 1, Ycoord + 2].NextLegalMove = true;
                }
                else
                      if (MyBoard[Xcoord - 1, Ycoord + 2].GetPieceColor() != color)
                {
                    MyButton[Xcoord - 1, Ycoord + 2].BackColor = Color.Green;
                    MyBoard[Xcoord - 1, Ycoord + 2].NextLegalMove = true;
                }

            //right down
            if (Xcoord + 1 < MyBoard[0, 0].Size && Ycoord + 2 < MyBoard[0, 0].Size)
                if (MyBoard[Xcoord + 1, Ycoord + 2].GetCurentlyOcupied() == false)
                {
                    MyButton[Xcoord + 1, Ycoord + 2].BackColor = Color.Green;
                    MyBoard[Xcoord + 1, Ycoord + 2].NextLegalMove = true;
                }
                else
                      if (MyBoard[Xcoord + 1, Ycoord + 2].GetPieceColor() != color)
                {
                    MyButton[Xcoord + 1, Ycoord + 2].BackColor = Color.Green;
                    MyBoard[Xcoord + 1, Ycoord + 2].NextLegalMove = true;
                }

        }

        public override void canMove(int Xcoord, int Ycoord, Board[,] MyBoard, Button[,] MyButton)
        {
            //upper right
            if (Xcoord - 2 >= 0 && Ycoord + 1 < MyBoard[0, 0].Size)
                if (MyBoard[Xcoord - 2, Ycoord + 1].GetCurentlyOcupied() == false)
                {
                    //  MyButton[Xcoord - 2, Ycoord + 1].BackColor = Color.Green;
                    MyBoard[Xcoord - 2, Ycoord + 1].NextLegalMove = true;
                }
                else

                {
                    //  MyButton[Xcoord - 2, Ycoord + 1].BackColor = Color.Green;
                    MyBoard[Xcoord - 2, Ycoord + 1].NextLegalMove = true;
                }

            //upper left
            if (Xcoord - 2 >= 0 && Ycoord - 1 >= 0)
                if (MyBoard[Xcoord - 2, Ycoord - 1].GetCurentlyOcupied() == false)
                {
                    //  MyButton[Xcoord - 2, Ycoord - 1].BackColor = Color.Green;
                    MyBoard[Xcoord - 2, Ycoord - 1].NextLegalMove = true;
                }
                else

                {
                    //  MyButton[Xcoord - 2, Ycoord - 1].BackColor = Color.Green;
                    MyBoard[Xcoord - 2, Ycoord - 1].NextLegalMove = true;
                }

            //lower right
            if (Xcoord + 2 < MyBoard[0, 0].Size && Ycoord + 1 < MyBoard[0, 0].Size)
                if (MyBoard[Xcoord + 2, Ycoord + 1].GetCurentlyOcupied() == false)
                {
                    //  MyButton[Xcoord + 2, Ycoord + 1].BackColor = Color.Green;
                    MyBoard[Xcoord + 2, Ycoord + 1].NextLegalMove = true;
                }
                else

                {
                    //  MyButton[Xcoord + 2, Ycoord + 1].BackColor = Color.Green;
                    MyBoard[Xcoord + 2, Ycoord + 1].NextLegalMove = true;
                }

            ///lower left
            if (Xcoord + 2 < MyBoard[0, 0].Size && Ycoord - 1 >= 0)
                if (MyBoard[Xcoord + 2, Ycoord - 1].GetCurentlyOcupied() == false)
                {
                    //  MyButton[Xcoord + 2, Ycoord - 1].BackColor = Color.Green;
                    MyBoard[Xcoord + 2, Ycoord - 1].NextLegalMove = true;
                }
                else

                {
                    //  MyButton[Xcoord + 2, Ycoord - 1].BackColor = Color.Green;
                    MyBoard[Xcoord + 2, Ycoord - 1].NextLegalMove = true;
                }

            //left upper
            if (Xcoord - 1 >= 0 && Ycoord - 2 >= 0)
                if (MyBoard[Xcoord - 1, Ycoord - 2].GetCurentlyOcupied() == false)
                {
                    //   MyButton[Xcoord - 1, Ycoord - 2].BackColor = Color.Green;
                    MyBoard[Xcoord - 1, Ycoord - 2].NextLegalMove = true;
                }
                else

                {
                    //  MyButton[Xcoord - 1, Ycoord - 2].BackColor = Color.Green;
                    MyBoard[Xcoord - 1, Ycoord - 2].NextLegalMove = true;
                }


            //left down
            if (Xcoord + 1 < MyBoard[0, 0].Size && Ycoord - 2 >= 0)
                if (MyBoard[Xcoord + 1, Ycoord - 2].GetCurentlyOcupied() == false)
                {
                    //   MyButton[Xcoord + 1, Ycoord - 2].BackColor = Color.Green;
                    MyBoard[Xcoord + 1, Ycoord - 2].NextLegalMove = true;
                }
                else

                {
                    //   MyButton[Xcoord + 1, Ycoord - 2].BackColor = Color.Green;
                    MyBoard[Xcoord + 1, Ycoord - 2].NextLegalMove = true;
                }

            //right upper
            if (Xcoord - 1 >= 0 && Ycoord + 2 < MyBoard[0, 0].Size)
                if (MyBoard[Xcoord - 1, Ycoord + 2].GetCurentlyOcupied() == false)
                {
                    //   MyButton[Xcoord - 1, Ycoord + 2].BackColor = Color.Green;
                    MyBoard[Xcoord - 1, Ycoord + 2].NextLegalMove = true;
                }
                else

                {
                    //  MyButton[Xcoord - 1, Ycoord + 2].BackColor = Color.Green;
                    MyBoard[Xcoord - 1, Ycoord + 2].NextLegalMove = true;
                }

            //right down
            if (Xcoord + 1 < MyBoard[0, 0].Size && Ycoord + 2 < MyBoard[0, 0].Size)
                if (MyBoard[Xcoord + 1, Ycoord + 2].GetCurentlyOcupied() == false)
                {
                    //   MyButton[Xcoord + 1, Ycoord + 2].BackColor = Color.Green;
                    MyBoard[Xcoord + 1, Ycoord + 2].NextLegalMove = true;
                }
                else

                {
                    //    MyButton[Xcoord + 1, Ycoord + 2].BackColor = Color.Green;
                    MyBoard[Xcoord + 1, Ycoord + 2].NextLegalMove = true;
                }

        }
    }
}
