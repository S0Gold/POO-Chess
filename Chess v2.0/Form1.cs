using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_v2._0
{
    public partial class Form1 : Form
    {
        public static Board[,] MyBoard = new Board[8, 8];
        public static Button[,] MyButton = new Button[8, 8];
  
        Button SwapButton;
        Cell SwapCell;
        bool WhiteMove = true;
        bool FirstClick = true;
        bool MyTurn;
        Player PlayerBlack;
        Player PlayerWhite;
        public Player Player;

        //
        int MyData;
        public int SCX;
        public int SCY;
        private TcpClient client;
        public StreamReader STR;
        public StreamWriter STW;
        public string receive;
        public String text_to_send;

        

        public Form1()
        {
            InitializeComponent();
           
            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    textBox1.Text = address.ToString();
                    textBox2.Text = address.ToString();
                   
                }
            }

        }

        private void StartGame(object sender, EventArgs e)
        {
            BoardInitialization();
      
            MyBoard[1,1].PopulateGrid(panel1,MyButton);
            CreateClickEvents();
            PlayerBlack = new Player("Black", MyBoard, MyButton);
            PlayerWhite = new Player("White", MyBoard, MyButton);

            panel1.BackgroundImage = null;

            BtnStart.Hide();
            button1.Hide();
            button2.Hide();
            textBox1.Hide();
            textBox2.Hide();


        }

        public void BoardInitialization()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    MyBoard[i, j] = new Board(i, j);
        }

        public void CreateClickEvents()
        {
            for (int i = 0; i < MyBoard[1, 1].Size; i++)

                for (int j = 0; j < MyBoard[1, 1].Size; j++)
                {
                    int h = i, l = j;
                    //add a click event to each button
                    MyButton[i, j].Click += (sender, EventArgs) => { First_Click(sender, EventArgs, h, l); };
                }
        }

        private void First_Click(object sender, EventArgs eventArgs, int x, int y)
        {
          if(MyTurn)
            //first click
            if (FirstClick )
                //check what piece is on the clickedBtn
                if (MyBoard[x, y].GetCurentlyOcupied() && MyBoard[x, y].GetPieceColor() == Player.GetColor())
                    {
                    
                            Player.PieceMove(MyBoard[x, y].GetPieceName(), x, y, MyBoard, MyButton);
                            SwapCell = MyBoard[x, y];
                            SwapButton = MyButton[x, y];
                            FirstClick = false;  
                    }

                else
                    MessageBox.Show("Not your turn!");
            //second click
            else
            {
                if (x == SwapCell.GetRowNumber() && y == SwapCell.GetCollumNumber())
                    {
                        FirstClick = true;
                        Player.DeleteGreenButtons(MyBoard, MyButton);
                  
                    }

                else
                    if (MyBoard[x, y].NextLegalMove == true)
                        {
                            SCX = x; SCY = y;
                                  
                            //change the button image
                            MyButton[x, y].Image = SwapButton.Image;

                            //change the cell properties
                            MyBoard[x, y].SwapProperties(SwapCell.GetCurentlyOcupied(), SwapCell.GetPieceColor(), SwapCell.GetPieceName());

                            //delete the image from the firstClick Button
                            MyButton[SwapCell.GetRowNumber(), SwapCell.GetCollumNumber()].Image = null;

                            //delete properties from the firstClick cell
                            MyBoard[SwapCell.GetRowNumber(), SwapCell.GetCollumNumber()] = new Board(SwapCell.GetRowNumber(), SwapCell.GetCollumNumber());

                            //delete all the green button
                            Player.DeleteGreenButtons(MyBoard, MyButton);

                            RemovePieces(WhiteMove, x, y, SwapCell.GetRowNumber(), SwapCell.GetCollumNumber());

                            FirstClick = true;

                            //CHANGE THE PLAYER Turn                         
                            MyTurn = !MyTurn;                         
                            SendData();
                }


            }
            else
                MessageBox.Show("Not your turn!");
        }

        private void RemovePieces(Boolean WhiteMove, int x, int y, int GetRowNumber, int GetCollumNumber)
        {
            if (!WhiteMove)
            {
                for (int i = 0; i < PlayerBlack.Pieces.Count; i++)
                {
                    Board NoIDEA = (Board)PlayerBlack.Pieces[i];

                    if (GetRowNumber == NoIDEA.GetRowNumber() && GetCollumNumber == NoIDEA.GetCollumNumber())
                    {
                        PlayerBlack.Pieces.RemoveAt(i);
                        PlayerBlack.Pieces.Insert(i, MyBoard[x, y]);
                    }
                }
                for (int i = 0; i < PlayerWhite.Pieces.Count; i++)
                {
                    Board NoIDEA2 = (Board)PlayerWhite.Pieces[i];
                    if (x == NoIDEA2.GetRowNumber() && y == NoIDEA2.GetCollumNumber())
                        PlayerWhite.Pieces.RemoveAt(i);

                }


            }

            else
            {
                for (int i = 0; i < PlayerWhite.Pieces.Count; i++)
                {
                    Board NoIDEA = (Board)PlayerWhite.Pieces[i];
                    if (GetRowNumber == NoIDEA.GetRowNumber() && GetCollumNumber == NoIDEA.GetCollumNumber())
                    {
                        PlayerWhite.Pieces.RemoveAt(i);
                        Board ss = MyBoard[x, y];
                        PlayerWhite.Pieces.Insert(i, MyBoard[x, y]);
                    }
                }

                for (int i = 0; i < PlayerBlack.Pieces.Count; i++)
                {
                    Board NoIDEA2 = (Board)PlayerBlack.Pieces[i];
                    if (x == NoIDEA2.GetRowNumber() && y == NoIDEA2.GetCollumNumber())
                        PlayerBlack.Pieces.RemoveAt(i);

                }


            }
        }

        public void Chess()
        {
            if (WhiteMove)
            {
                Board first = (Board)PlayerWhite.Pieces[0];
                foreach (Board elem in PlayerBlack.Pieces)
                    PlayerBlack.PiececanMove(elem.GetPieceName(), elem.GetRowNumber(), elem.GetCollumNumber(), MyBoard, MyButton);

                if (MyBoard[first.GetRowNumber(), first.GetCollumNumber()].NextLegalMove == true)
                    MessageBox.Show("Chess!");
            }
            else
            {
                Board first = (Board)PlayerBlack.Pieces[0];
                foreach (Board elem in PlayerWhite.Pieces)
                    PlayerWhite.PiececanMove(elem.GetPieceName(), elem.GetRowNumber(), elem.GetCollumNumber(), MyBoard, MyButton);

                if (MyBoard[first.GetRowNumber(), first.GetCollumNumber()].NextLegalMove == true)
                        MessageBox.Show("Chess!");
            }
        }

        public bool GameOver()
        {
            if (WhiteMove)
            {
                    Board first = (Board)PlayerWhite.Pieces[0];
                    if(MyBoard[first.GetRowNumber(), first.GetCollumNumber()].GetPieceName()!="King")
                            {
                                MessageBox.Show("Game over, Black won!");
                                RemoveClickEvent();
                                return true;
                            }

                }
            else
                {
                    Board first = (Board)PlayerBlack.Pieces[0];
                    if (MyBoard[first.GetRowNumber(), first.GetCollumNumber()].GetPieceName() != "King")
                            {
                                MessageBox.Show("Game over, White won!");
                                RemoveClickEvent();
                                return true;
                            }
                
                   
               
                }
            return false;
        }

        private void RemoveClickEvent()
        {
            for (int i = 0; i < MyBoard[1, 1].Size; i++)

                for (int j = 0; j < MyBoard[1, 1].Size; j++)
                {
                    Button b = MyButton[i, j];
                    FieldInfo f1 = typeof(Control).GetField("EventClick",
               BindingFlags.Static | BindingFlags.NonPublic);
                    object obj = f1.GetValue(b);
                    PropertyInfo pi = b.GetType().GetProperty("Events",
                        BindingFlags.NonPublic | BindingFlags.Instance);
                    EventHandlerList list = (EventHandlerList)pi.GetValue(b, null);
                    list.RemoveHandler(obj, list[obj]);
                }
            
        }

        private void SendData()
        {
           
                int _X1 = SwapCell.GetRowNumber(), _Y1 = SwapCell.GetCollumNumber();
                if (_X1 == 0)
                    _X1 = 9 ;
                if (_Y1 == 0)
                    _Y1 += 9 ;
                if (SCX == 0)
                    SCX = 9 ;
                if (SCY == 0)
                    SCY = 9; 
                MyData = _X1 * 1000 + _Y1 * 100 + SCX * 10 + SCY;

                backgroundWorker2.RunWorkerAsync();
            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) //receive data
        {
            while(client.Connected)
                try
                {
                   
                    string YourData = STR.ReadLine();
                    int Yt= Int32.Parse(YourData);

                    int X1, X2, Y1, Y2;
                    Y2 = Yt % 10; if (Y2 == 9) Y2 = 0; Yt /= 10;      //SCY
                    X2 = Yt % 10; if (X2 == 9) X2 = 0; Yt /= 10;      //SCX
                    Y1 = Yt % 10; if (Y1 == 9) Y1 = 0; Yt /= 10;      //SwapCell.GetCollumNumber()
                    X1 = Yt % 10; if (X1 == 9) X1 = 0; Yt /= 10;      //SwapCell.GetRowNumber()

                    RemovePieces(WhiteMove, X2, Y2, X1, Y1);
                      
                    MyBoard[X2, Y2].SwapProperties(MyBoard[X1, Y1].GetCurentlyOcupied(), MyBoard[X1, Y1].GetPieceColor(), MyBoard[X1, Y1].GetPieceName());
                    MyButton[X2, Y2].Image = MyButton[X1, Y1].Image;

                    MyButton[X1, Y1].Image = null;
                    MyBoard[X1, Y1] = new Board(X1, Y1);

 
                        WhiteMove = !WhiteMove;
                        MyTurn = !MyTurn;
                        Chess();
                        GameOver();
                        Player.DeleteGreenButtons(MyBoard, MyButton);



                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message.ToString());
                }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e) //send data
        {
            if(client.Connected)
            {
                WhiteMove = !WhiteMove;
                STW.WriteLine(MyData.ToString());
                // this.textBox5.Invoke(new MethodInvoker(delegate () { textBox5.AppendText("Me: " + MyData + "\n "); }));
            }
            else
            {
                MessageBox.Show("Send Faild ");
            }
            backgroundWorker2.CancelAsync();
        }
     
        private void button1_Click(object sender, EventArgs e)  //START SERVER
        {
            TcpListener listener = new TcpListener(IPAddress.Any, 2133);
            listener.Start();
            client = listener.AcceptTcpClient();
            STR = new StreamReader(client.GetStream());
            STW = new StreamWriter(client.GetStream());
            STW.AutoFlush = true;
            backgroundWorker1.RunWorkerAsync();                         //start receiving data in background
            backgroundWorker2.WorkerSupportsCancellation = true;        //ability to cancel this thread
            ///////
            BoardInitialization();     
            MyBoard[1, 1].PopulateGrid(panel1, MyButton);
            CreateClickEvents();
            PlayerBlack = new Player("Black", MyBoard, MyButton);
            PlayerWhite = new Player("White", MyBoard, MyButton);
            Player = PlayerWhite;
            WhiteMove = true;
            panel1.BackgroundImage = null;
            MyTurn = true;
            BtnStart.Hide();
            button1.Hide();
            button2.Hide();
            textBox1.Hide();
            textBox2.Hide();
        }

        private void button2_Click(object sender, EventArgs e)  //START CLIENT
        {
            client = new TcpClient();
            IPEndPoint IP_End = new IPEndPoint(IPAddress.Parse(textBox2.Text), 2133);
            try
            {
                client.Connect(IP_End);
                if (client.Connected)
                {                    
                    STW = new StreamWriter(client.GetStream());
                    STR = new StreamReader(client.GetStream());
                    STW.AutoFlush = true;
                    backgroundWorker1.RunWorkerAsync();                         //start receiving data in background
                    backgroundWorker2.WorkerSupportsCancellation = true;        //ability to cancel this thread
                    /////
                    BoardInitialization();
                    MyBoard[1, 1].PopulateGrid(panel1, MyButton);
                    CreateClickEvents();
                    PlayerBlack = new Player("Black", MyBoard, MyButton);
                    PlayerWhite = new Player("White", MyBoard, MyButton);
                    Player = PlayerBlack;
                    WhiteMove = true;
                    panel1.BackgroundImage = null;
                    MyTurn = false;
                    BtnStart.Hide();
                    button1.Hide();
                    button2.Hide();
                    textBox1.Hide();
                    textBox2.Hide();
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message.ToString());
            }
        }
       
    }



}

