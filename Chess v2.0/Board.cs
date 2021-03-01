using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chess_v2._0;

namespace Chess_v2._0
{
    public class Board:Cell
    {
        public int Size=8; 

        public Board(int i,int j):base(i,j)
        {
            
        }
       
        public void PopulateGrid(Panel panel1, Button[,] MyButton)
        {
            //create buttons and place them into panel
            int ButtonSize = panel1.Width / Size;

            //make the panel a perfect square
            panel1.Height = panel1.Width;

            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                {
                    MyButton[i, j] = new Button();
                    MyButton[i, j].Height = ButtonSize;
                    MyButton[i, j].Width = ButtonSize;

                    //add the color on the table
                    if ((i + j) % 2 == 0)
                        MyButton[i, j].BackColor = Color.White;
                    else
                        MyButton[i, j].BackColor = Color.Black;

                    //add the new button to the panel
                    panel1.Controls.Add(MyButton[i, j]);

                    //set the location to the new button
                    MyButton[i, j].Location = new Point (j * ButtonSize, i * ButtonSize);
                }

        }

       

    }
}