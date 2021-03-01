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
    class King : Pieces
    {

        public King(string PC, ArrayList a, Board[,] MyBoard, Button[,] MyButton) : base(PC)
        {

            InitKing(a, MyBoard, MyButton);
        }

        private void InitKing(ArrayList a, Board[,] MyBoard, Button[,] MyButton)
        {
            if (color == "Black")
            {
                MyButton[0, 4].Image = Properties.Resources.BlackKing;
                MyBoard[0, 4].SwapProperties(true, color, "King");
                a.Add(MyBoard[0, 4]);
            }
            else
            {
                MyButton[7, 4].Image = Properties.Resources.WhiteKing;
                MyBoard[7, 4].SwapProperties(true, color, "King");
                a.Add(MyBoard[7, 4]);
            }
        }



        public override void Move(int Xcoord, int Ycoord, Board[,] MyBoard, Button[,] MyButton)
        {
            //down move
            if (Xcoord + 1 < MyBoard[0, 0].Size)
                if (MyBoard[Xcoord + 1, Ycoord].GetCurentlyOcupied() == false)
                {
                    MyButton[Xcoord + 1, Ycoord].BackColor = Color.Green;
                    MyBoard[Xcoord + 1, Ycoord].NextLegalMove = true;

                }
                else
                    if (MyBoard[Xcoord + 1, Ycoord].GetPieceColor() != color)
                {
                    MyButton[Xcoord + 1, Ycoord].BackColor = Color.Green;
                    MyBoard[Xcoord + 1, Ycoord].NextLegalMove = true;

                }


            //upper move
            if (Xcoord - 1 >= 0)
                if (MyBoard[Xcoord - 1, Ycoord].GetCurentlyOcupied() == false)
                {
                    MyButton[Xcoord - 1, Ycoord].BackColor = Color.Green;
                    MyBoard[Xcoord - 1, Ycoord].NextLegalMove = true;

                }
                else
                    if (MyBoard[Xcoord - 1, Ycoord].GetPieceColor() != color)
                {
                    MyButton[Xcoord - 1, Ycoord].BackColor = Color.Green;
                    MyBoard[Xcoord - 1, Ycoord].NextLegalMove = true;

                }


            //right move
            if (Ycoord + 1 < MyBoard[0, 0].Size)
                if (MyBoard[Xcoord, Ycoord + 1].GetCurentlyOcupied() == false)
                {
                    MyButton[Xcoord, Ycoord + 1].BackColor = Color.Green;
                    MyBoard[Xcoord, Ycoord + 1].NextLegalMove = true;

                }
                else
                     if (MyBoard[Xcoord, Ycoord + 1].GetPieceColor() != color)
                {
                    MyButton[Xcoord, Ycoord + 1].BackColor = Color.Green;
                    MyBoard[Xcoord, Ycoord + 1].NextLegalMove = true;

                }


            //left move
            if (Ycoord - 1 >= 0)
                if (MyBoard[Xcoord, Ycoord - 1].GetCurentlyOcupied() == false)
                {
                    MyButton[Xcoord, Ycoord - 1].BackColor = Color.Green;
                    MyBoard[Xcoord, Ycoord - 1].NextLegalMove = true;

                }
                else
                     if (MyBoard[Xcoord, Ycoord - 1].GetPieceColor() != color)
                {
                    MyButton[Xcoord, Ycoord - 1].BackColor = Color.Green;
                    MyBoard[Xcoord, Ycoord - 1].NextLegalMove = true;

                }


            //down right move
            if (Xcoord + 1 < MyBoard[0, 0].Size && Ycoord + 1 < MyBoard[0, 0].Size)
                if (MyBoard[Xcoord + 1, Ycoord + 1].GetCurentlyOcupied() == false)
                {
                    MyButton[Xcoord + 1, Ycoord + 1].BackColor = Color.Green;
                    MyBoard[Xcoord + 1, Ycoord + 1].NextLegalMove = true;

                }
                else
                      if (MyBoard[Xcoord + 1, Ycoord + 1].GetPieceColor() != color)
                {
                    MyButton[Xcoord + 1, Ycoord + 1].BackColor = Color.Green;
                    MyBoard[Xcoord + 1, Ycoord + 1].NextLegalMove = true;

                }


            //upper right move
            if (Xcoord - 1 >= 0 && Ycoord + 1 < MyBoard[0, 0].Size)
                if (MyBoard[Xcoord - 1, Ycoord + 1].GetCurentlyOcupied() == false)
                {
                    MyButton[Xcoord - 1, Ycoord + 1].BackColor = Color.Green;
                    MyBoard[Xcoord - 1, Ycoord + 1].NextLegalMove = true;

                }
                else
                      if (MyBoard[Xcoord - 1, Ycoord + 1].GetPieceColor() != color)
                {
                    MyButton[Xcoord - 1, Ycoord + 1].BackColor = Color.Green;
                    MyBoard[Xcoord - 1, Ycoord + 1].NextLegalMove = true;

                }


            //down left move
            if (Xcoord + 1 < MyBoard[0, 0].Size && Ycoord - 1 >= 0)
                if (MyBoard[Xcoord + 1, Ycoord - 1].GetCurentlyOcupied() == false)
                {
                    MyButton[Xcoord + 1, Ycoord - 1].BackColor = Color.Green;
                    MyBoard[Xcoord + 1, Ycoord - 1].NextLegalMove = true;

                }
                else
                     if (MyBoard[Xcoord + 1, Ycoord - 1].GetPieceColor() != color)
                {
                    MyButton[Xcoord + 1, Ycoord - 1].BackColor = Color.Green;
                    MyBoard[Xcoord + 1, Ycoord - 1].NextLegalMove = true;

                }

            //upper left move
            if (Xcoord - 1 >= 0 && Ycoord - 1 >= 0)
                if (MyBoard[Xcoord - 1, Ycoord - 1].GetCurentlyOcupied() == false)
                {
                    MyButton[Xcoord - 1, Ycoord - 1].BackColor = Color.Green;
                    MyBoard[Xcoord - 1, Ycoord - 1].NextLegalMove = true;

                }
                else
                    if (MyBoard[Xcoord - 1, Ycoord - 1].GetPieceColor() != color)
                {
                    MyButton[Xcoord - 1, Ycoord - 1].BackColor = Color.Green;
                    MyBoard[Xcoord - 1, Ycoord - 1].NextLegalMove = true;

                }

        }

        public override void canMove(int Xcoord, int Ycoord, Board[,] MyBoard, Button[,] MyButton)
        {
            //down move
            if (Xcoord + 1 < MyBoard[0, 0].Size)
                if (MyBoard[Xcoord + 1, Ycoord].GetCurentlyOcupied() == false)
                {
                    //   MyButton[Xcoord + 1, Ycoord].BackColor = Color.Green;
                    MyBoard[Xcoord + 1, Ycoord].NextLegalMove = true;

                }
                else

                {
                    //  MyButton[Xcoord + 1, Ycoord].BackColor = Color.Green;
                    MyBoard[Xcoord + 1, Ycoord].NextLegalMove = true;

                }


            //upper move
            if (Xcoord - 1 >= 0)
                if (MyBoard[Xcoord - 1, Ycoord].GetCurentlyOcupied() == false)
                {
                    //  MyButton[Xcoord - 1, Ycoord].BackColor = Color.Green;
                    MyBoard[Xcoord - 1, Ycoord].NextLegalMove = true;

                }
                else

                {
                    //   MyButton[Xcoord - 1, Ycoord].BackColor = Color.Green;
                    MyBoard[Xcoord - 1, Ycoord].NextLegalMove = true;

                }


            //right move
            if (Ycoord + 1 < MyBoard[0, 0].Size)
                if (MyBoard[Xcoord, Ycoord + 1].GetCurentlyOcupied() == false)
                {
                    // MyButton[Xcoord, Ycoord + 1].BackColor = Color.Green;
                    MyBoard[Xcoord, Ycoord + 1].NextLegalMove = true;

                }
                else

                {
                    //   MyButton[Xcoord, Ycoord + 1].BackColor = Color.Green;
                    MyBoard[Xcoord, Ycoord + 1].NextLegalMove = true;

                }


            //left move
            if (Ycoord - 1 >= 0)
                if (MyBoard[Xcoord, Ycoord - 1].GetCurentlyOcupied() == false)
                {
                    //   MyButton[Xcoord, Ycoord - 1].BackColor = Color.Green;
                    MyBoard[Xcoord, Ycoord - 1].NextLegalMove = true;

                }
                else

                {
                    //  MyButton[Xcoord, Ycoord - 1].BackColor = Color.Green;
                    MyBoard[Xcoord, Ycoord - 1].NextLegalMove = true;

                }


            //down right move
            if (Xcoord + 1 < MyBoard[0, 0].Size && Ycoord + 1 < MyBoard[0, 0].Size)
                if (MyBoard[Xcoord + 1, Ycoord + 1].GetCurentlyOcupied() == false)
                {
                    //  MyButton[Xcoord + 1, Ycoord + 1].BackColor = Color.Green;
                    MyBoard[Xcoord + 1, Ycoord + 1].NextLegalMove = true;

                }
                else

                {
                    //  MyButton[Xcoord + 1, Ycoord + 1].BackColor = Color.Green;
                    MyBoard[Xcoord + 1, Ycoord + 1].NextLegalMove = true;

                }


            //upper right move
            if (Xcoord - 1 >= 0 && Ycoord + 1 < MyBoard[0, 0].Size)
                if (MyBoard[Xcoord - 1, Ycoord + 1].GetCurentlyOcupied() == false)
                {
                    //  MyButton[Xcoord - 1, Ycoord + 1].BackColor = Color.Green;
                    MyBoard[Xcoord - 1, Ycoord + 1].NextLegalMove = true;

                }
                else

                {
                    // MyButton[Xcoord - 1, Ycoord + 1].BackColor = Color.Green;
                    MyBoard[Xcoord - 1, Ycoord + 1].NextLegalMove = true;

                }


            //down left move
            if (Xcoord + 1 < MyBoard[0, 0].Size && Ycoord - 1 >= 0)
                if (MyBoard[Xcoord + 1, Ycoord - 1].GetCurentlyOcupied() == false)
                {
                    //  MyButton[Xcoord + 1, Ycoord - 1].BackColor = Color.Green;
                    MyBoard[Xcoord + 1, Ycoord - 1].NextLegalMove = true;

                }
                else

                {
                    //  MyButton[Xcoord + 1, Ycoord - 1].BackColor = Color.Green;
                    MyBoard[Xcoord + 1, Ycoord - 1].NextLegalMove = true;

                }

            //upper left move
            if (Xcoord - 1 >= 0 && Ycoord - 1 >= 0)
                if (MyBoard[Xcoord - 1, Ycoord - 1].GetCurentlyOcupied() == false)
                {
                    //   MyButton[Xcoord - 1, Ycoord - 1].BackColor = Color.Green;
                    MyBoard[Xcoord - 1, Ycoord - 1].NextLegalMove = true;

                }
                else

                {
                    //  MyButton[Xcoord - 1, Ycoord - 1].BackColor = Color.Green;
                    MyBoard[Xcoord - 1, Ycoord - 1].NextLegalMove = true;

                }

        }

        public bool chessMove(int Xcoord, int Ycoord, Board[,] MyBoard, Button[,] MyButton)
        {
            //down move
            if (Xcoord + 1 < MyBoard[0, 0].Size)
                if (MyBoard[Xcoord + 1, Ycoord].NextLegalMove == false)
                {
                    return true;

                }



            //upper move
            if (Xcoord - 1 >= 0)
                if (MyBoard[Xcoord - 1, Ycoord].NextLegalMove == false)
                {
                    return true;

                }



            //right move
            if (Ycoord + 1 < MyBoard[0, 0].Size)
                if (MyBoard[Xcoord, Ycoord + 1].NextLegalMove == false)
                {
                    return true;

                }



            //left move
            if (Ycoord - 1 >= 0)
                if (MyBoard[Xcoord, Ycoord - 1].NextLegalMove == false)
                {
                    return true;

                }



            //down right move
            if (Xcoord + 1 < MyBoard[0, 0].Size && Ycoord + 1 < MyBoard[0, 0].Size)
                if (MyBoard[Xcoord + 1, Ycoord + 1].NextLegalMove == false)
                {
                    return true;

                }



            //upper right move
            if (Xcoord - 1 >= 0 && Ycoord + 1 < MyBoard[0, 0].Size)
                if (MyBoard[Xcoord - 1, Ycoord + 1].NextLegalMove == false)
                {
                    return true;

                }



            //down left move
            if (Xcoord + 1 < MyBoard[0, 0].Size && Ycoord - 1 >= 0)
                if (MyBoard[Xcoord + 1, Ycoord - 1].NextLegalMove == false)
                {
                    return true;

                }


            //upper left move
            if (Xcoord - 1 >= 0 && Ycoord - 1 >= 0)
                if (MyBoard[Xcoord - 1, Ycoord - 1].NextLegalMove == false)
                {
                    return true;

                }
            return false;

        }


    }
}
