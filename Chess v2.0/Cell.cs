using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_v2._0
{
    public class Cell
    {
        private int RowNumber;
        private int CollumNumber;
        private bool CurentlyOcupied;
        public bool NextLegalMove;
        private string PieceName;
        private string PieceColor;

        public Cell()
        {
            CurentlyOcupied = false;
            PieceName = "NULL";
            PieceColor = "NULL";

        }

        public Cell(int x, int y)
        {
            RowNumber = x;
            CollumNumber = y;
            CurentlyOcupied = false;
            PieceName = "NULL";
            PieceColor = "NULL";

        }

        public Cell(int x, int y, bool CurentlyOcupied, string PieceName, string PieceColor)
        {
            RowNumber = x;
            CollumNumber = y;
            this.CurentlyOcupied = CurentlyOcupied;
            this.PieceName = PieceName;
            this.PieceColor = PieceColor;

        }


        public void SwapProperties(bool CurentlyOcupied, string PieceColor, string PieceName)
        {
            this.CurentlyOcupied = CurentlyOcupied;
            this.PieceName = PieceName;
            this.PieceColor = PieceColor;

        }

        public int GetRowNumber()
        {
            return RowNumber;
        }

        public int GetCollumNumber()
        {
            return CollumNumber;
        }

        public bool GetCurentlyOcupied()
        {
            return CurentlyOcupied;
        }

        public string GetPieceName()
        {
            return PieceName;
        }

        public string GetPieceColor()
        {
            return PieceColor;
        }


      
    }
}

