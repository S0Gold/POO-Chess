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
     public class Player 
  {
    private string color;
    private Pieces King, Pawn, Rook, Knight, Bishop, Queen;
 
    public ArrayList Pieces = new ArrayList();

    public Player(string color, Board[,] MyBoard, Button[,] MyButton)
    {
        this.color = color;
        King = new King(color, Pieces, MyBoard, MyButton);    //first item from ArrList
        Knight = new Knight(color, Pieces, MyBoard, MyButton); 
        Rook = new Rook(color, Pieces, MyBoard, MyButton);
        Bishop = new Bishop(color, Pieces, MyBoard, MyButton);
        Pawn = new Pawn(color, Pieces, MyBoard, MyButton);
        Queen = new Queen(color, Pieces, MyBoard, MyButton);

    }

    public void PieceMove(string Piece, int x, int y, Board[,] MyBoard, Button[,] MyButton)
    {
        switch (Piece)
        {
            case "Pawn":
                Pawn.Move(x, y, MyBoard, MyButton);
                break;
            case "Rook":
                Rook.Move(x, y, MyBoard, MyButton);
                break;
            case "Bishop":
                Bishop.Move(x, y, MyBoard, MyButton);
                break;
            case "Queen":
                Queen.Move(x, y, MyBoard, MyButton);
                break;
            case "King":
                King.Move(x, y, MyBoard, MyButton);
                break;
            case "Knight":
                Knight.Move(x, y, MyBoard, MyButton);
                break;
        }

    }


     public void PiececanMove(string Piece, int x, int y, Board[,] MyBoard, Button[,] MyButton)
        {
            switch (Piece)
            {
                case "Pawn":
                    Pawn.canMove(x, y, MyBoard, MyButton);
                    break;
                case "Rook":
                    Rook.canMove(x, y, MyBoard, MyButton);
                    break;
                case "Bishop":
                    Bishop.canMove(x, y, MyBoard, MyButton);
                    break;
                case "Queen":
                    Queen.canMove(x, y, MyBoard, MyButton);
                    break;
                case "King":
                    King.canMove(x, y, MyBoard, MyButton);
                    break;
                case "Knight":
                    Knight.canMove(x, y, MyBoard, MyButton);
                    break;
            }

        }

     public string GetColor()
    {
        return color;
    }


    public void DeleteGreenButtons(Board[,] MyBoard, Button[,] MyButton)
    {
            for (int i = 0; i < MyBoard[1, 1].Size; i++)
                for (int j = 0; j < MyBoard[1, 1].Size; j++)
                    if ((i + j) % 2 == 0)
                    {
                        MyButton[i, j].BackColor = Color.White;
                        MyBoard[i, j].NextLegalMove = false;
                    }
                    else
                    {
                        MyButton[i, j].BackColor = Color.Black;
                        MyBoard[i, j].NextLegalMove = false;
                    }
        }



  }
}

