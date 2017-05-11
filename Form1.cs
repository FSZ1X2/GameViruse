using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FSPG;
using try2;
using try2.Properties;


namespace try2
{
    public partial class Form1 : Form
    {
        int unitWidth, unitHeight;
        int xNum, yNum;
        int score;
        Pen bgPen;
        Pen bodyPen;
        Pen whitePen;
        Pen fPen;
        Player player;
        //Point data;
        Pen pPen;
        Enemy point;
        List<float> r;
        Enemy bullet;
        bool die = false;
        Pen redPen;
        List<Enemy> enemies;
        Pen bPen;
        PointF str;
        //List<Enemy> edata;
        string scores;
        int go;

        //Random r = new Random();

        private Map map;

        internal Map Map
        {
            get
            {
                return map;
            }

            set
            {
                map = value;
            }
        }


        public Form1()
        {
            InitializeComponent();

            xNum = 50;
            yNum = 50;
            score = 0;
            bgPen = new Pen(Color.MistyRose);
            whitePen = new Pen(Color.White);
            fPen = new Pen(Color.DarkRed);
            bodyPen = new Pen(Color.Fuchsia);
            pPen = new Pen(Color.DarkBlue);
            redPen = new Pen(Color.Red);
            bPen = new Pen(Color.DarkViolet);
            r=new List<float>();
            enemies = new List<Enemy>();
            go = 3;
            str = new PointF(0, 0);
            //empty = true;

            //edata = new List<Enemy>();
            //bullet = new Enemy[50];

            this.pBox.Image = new System.Drawing.Bitmap(this.pBox.Size.Width, this.pBox.Size.Height);

            Graphics bg = Graphics.FromImage(this.pBox.Image);
            bg.DrawImage(Resources.sprite_1, str);
            this.unitWidth = this.pBox.Image.Width / this.yNum - 1;
            this.unitHeight = this.pBox.Image.Height / this.xNum - 1;

            this.timer1.Enabled = false;
            this.timer2.Enabled = false;      
        }

       /* public void ifdie()
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (player.GetX() ==enemies[i].GetX() && player.GetY() == enemies[i].GetY())
                {
                    die = true;

                }
            }
        }*/
        public void gameOver()
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (player.GetX() == enemies[i].GetX() && player.GetY() == enemies[i].GetY())
                {
                    die = true;
                    
                }
            }
        }

        public void drawMap()
        {
            map = new Map(this.pBox.Location.X, this.pBox.Location.Y, this.xNum, this.yNum);
            Map.Draw();
            r = new List<float>();

            int s = 2;
            r.Add(s);

            int x, y;
            int ex, ey;

            do
            {
                x = Utility.Rand() % this.xNum;
                y = Utility.Rand() % this.yNum;
            } while (map.IsCellOpen(x, y)==true);

            player = new Player(x, y);

            do
            {
                do
                {
                    ex = Utility.Rand() % this.xNum;
                    ey = Utility.Rand() % this.yNum;
                } while (ex == x && ey == y);         
            } while (map.IsCellOpen(ex, ey) == true);

            point = new Enemy(ex, ey);


            for (int i = 0; i < 360; i++)
            {
                double rads = i * Math.PI / 180.0;
                double rx = Math.Cos(rads) * 2;
                double ry = Math.Sin(rads) * 2;
                bullet = new Enemy((int)rx+point.GetX(), (int)ry+point.GetY());
                //if (bullet.GetX() % 2 == 0 && bullet.GetY() % 2 == 0)
                //{
                    enemies.Add(bullet);
                    //edata.Add(bullet);
                //}
            }

            enemies = new List<Enemy>();
            /*for(int i=0;i<edata.Count;i++)
              {
                  edata[i] = null;
              }*/

        }
        public void refresh()
        {
            if(die==false)
            {
                if (player.GetX() == point.GetX() && player.GetY() == point.GetY())
                {
                    score = score + 1;
                    drawMap();
                }
            }                        
        }
        public void bulletupdata()
        {
            //int d = Utility.Rand() % 4;
          
                switch (go)
                {
                    case 0:
                        for (int k = 0; k < enemies.Count; k++)
                        {
                            enemies[k].SetX(enemies[k].GetX() + 1);
                            enemies[k].SetY(enemies[k].GetY() + 1);
                            //go = 1;
                        }
                        break;
                    case 1:
                        for (int k = 0; k < enemies.Count; k++)
                        {
                            enemies[k].SetX(enemies[k].GetX() - 1);
                            enemies[k].SetY(enemies[k].GetY() - 1);
                           // go = 2;
                        }
                        break;
                    case 2:
                        for (int k = 0; k < enemies.Count; k++)
                        {
                            enemies[k].SetX(enemies[k].GetX() + 1);
                            enemies[k].SetY(enemies[k].GetY() - 1);
                           // go = 3;
                        }
                        break;
                    case 3:
                        for (int k = 0; k < enemies.Count; k++)
                        {
                            enemies[k].SetX(enemies[k].GetX() - 1);
                            enemies[k].SetY(enemies[k].GetY() + 1);
                            //go = 0;
                        }
                        break;
                }
            
            
        }
        /*public void cirle(float rad)
        {
            enemies = new List<Enemy>();
            for (int i = 0; i < 360; i++)
            {
                double rads = i * Math.PI / 180.0;
                double rx = Math.Cos(rads) * rad;
                double ry = Math.Sin(rads) * rad;
                bullet = new Enemy((int)rx, (int)ry);
                if (bullet.GetX() % 2 == 0 && bullet.GetY() % 2 == 0)
                {
                    enemies.Add(bullet);
                    //edata.Add(bullet);
                }
            }
        }*/

        void reDrawPBox()
        {   
            Graphics g = Graphics.FromImage(pBox.Image);
            Pen otPen = null;
            g.FillRectangle(bgPen.Brush, 0, 0, this.pBox.Image.Width, this.pBox.Image.Height);
            if(die==true)
            {
                player.stay();
                scores = score.ToString();
                //Graphics g = Graphics.FromImage(this.pBox.Image);
                System.Drawing.Font font = new System.Drawing.Font("微软雅黑", 50);
                System.Drawing.Font font2 = new System.Drawing.Font("微软雅黑", 25);
                g.FillRectangle(this.whitePen.Brush, 0, 0, this.pBox.Image.Width, this.pBox.Image.Height);
                g.DrawString("GAME OVER", font, this.redPen.Brush, this.pBox.Image.Width / 2 - 280, this.pBox.Image.Height / 3);
                g.DrawString("Score:" + scores, font2, this.pPen.Brush, this.pBox.Image.Width / 2 - 250, this.pBox.Image.Height / 3 + 100);
                //this.pBox.Refresh();
                font.Dispose();
                //g.Dispose();
            }
            else
            {
                for (int i = 0; i < this.xNum; i++)
                {
                    for (int j = 0; j < this.yNum; j++)
                    {
                        if (Map.mapping[i, j] == true)
                            otPen = fPen;
                        else if (Map.mapping[i, j] == false)
                            otPen = bgPen;
                        g.FillRectangle(otPen.Brush, j * (unitWidth + 1), i * (unitHeight + 1), unitWidth, unitHeight);

                    }
                }

                g.FillRectangle(bodyPen.Brush, point.GetY() * (unitWidth + 1), point.GetX() * (unitHeight + 1), unitWidth, unitHeight);

                for (int k = 0; k < enemies.Count; k++)
                {
                    if (enemies[k] != null)
                        g.FillRectangle(bPen.Brush, enemies[k].GetY() * (unitWidth + 1), enemies[k].GetX() * (unitHeight + 1), unitWidth, unitHeight);
                }

                g.FillRectangle(pPen.Brush, player.GetY() * (unitWidth + 1), player.GetX() * (unitHeight + 1), unitWidth, unitHeight);
            }
            

            //for(int f=0;f<r.Count;f++)
            //{

            //g.FillRectangle(bPen.Brush, (point.GetY() + bullet.GetY()) * (unitWidth + 1), (point.GetX() + bullet.GetX()) * (unitHeight + 1), unitWidth, unitHeight);
            //enemies.Add(bullet);

            //}
            //}
            //if(empty==false)
           // {
                
            //}
            
            //enemies.Add(bullet);
            //g.FillRectangle(bPen.Brush, (point.GetY() + enemies[k].GetY()) * (unitWidth + 1), (point.GetX() + enemies[k].GetX()) * (unitHeight + 1), unitWidth, unitHeight);
            //}

            pBox.Refresh();
            g.Dispose();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void viewHowToPlayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 guide = new Form2();
            guide.Show();
        }

        private void onKeyDown(object sender, KeyEventArgs e)
        {
            // data = player.savedata();
            if (die == false)
            {
                if (e.KeyCode == Keys.NumPad8)
                {
                    if (map.IsCellOpen(player.GetX(), player.GetY()) == false)
                        player.up();
                    if (map.IsCellOpen(player.GetX(), player.GetY()) == true)
                        die = true;
                        //player.stayup();
                }
                else if (e.KeyCode == Keys.NumPad4)
                {
                    if (map.IsCellOpen(player.GetX(), player.GetY()) == false)
                        player.left();
                    if (map.IsCellOpen(player.GetX(), player.GetY()) == true)
                        die = true;//player.stayleft();
                }
                else if (e.KeyCode == Keys.NumPad5)
                {
                    if (map.IsCellOpen(player.GetX(), player.GetY()) == false)
                        player.down();
                    if (map.IsCellOpen(player.GetX(), player.GetY()) == true)
                        die = true;
                       // player.staydown();
                }
                else if (e.KeyCode == Keys.NumPad6)
                {
                    if (map.IsCellOpen(player.GetX(), player.GetY()) == false)
                        player.right();
                    if (map.IsCellOpen(player.GetX(), player.GetY()) == true)
                        die = true;// player.stayright();
                }
            }
            else
              player.stay();            
            player.next();
            //gameOver();          
            refresh();
            //drawMemory();
            gameOver();
            reDrawPBox();
            

        }
        /*private void onKeyDown(object sender, KeyEventArgs e)
        {
            // data = player.savedata();
            if (die == false)
            {
                if (e.KeyCode == Keys.NumPad8)
                {
                    if (player.GetX() != map.GetX()&& player.GetY() != (map.GetY()+unitHeight))
                        player.up();
                    else
                        player.stayup();
                }
                else if (e.KeyCode == Keys.NumPad4)
                {
                    if (player.GetX() != (map.GetX() +unitWidth )&& player.GetY() != map.GetY())
                        player.left();
                    else
                        player.stayleft();
                }
                else if (e.KeyCode == Keys.NumPad5)
                {
                    if (player.GetX() != map.GetX() && player.GetY() != (map.GetY()-unitHeight))
                        player.down();
                    else
                        player.staydown();
                }
                else if (e.KeyCode == Keys.NumPad6)
                {
                    if (player.GetX() != (map.GetX() -unitWidth) && player.GetY() != map.GetY())
                        player.right();
                    else
                        player.stayright();
                }
            }
            else
                player.stay();
            player.next();
            //gameOver();          
            refresh();
            //drawMemory();
            reDrawPBox();
            gameOver();

        }*/
        private void onKeyUp(object sender, KeyEventArgs e)
        {
           // data = player.savedata();

            if (e.KeyCode == Keys.NumPad8&& map.IsCellOpen(player.GetX(), player.GetY()) == true)
            {
                //if (map.IsCellOpen(player.GetX(), player.GetY()) == true)
                    //player.up();
                //else
                    player.stayup();
            }
            else if (e.KeyCode == Keys.NumPad4&& map.IsCellOpen(player.GetX(), player.GetY()) == true)
            {
                //if (map.IsCellOpen(player.GetX(), player.GetY()) == true)
                    //player.left();
                //else
                    player.stayleft();
            }
            else if (e.KeyCode == Keys.NumPad5&& map.IsCellOpen(player.GetX(), player.GetY()) == true)
            {
                //if (map.IsCellOpen(player.GetX(), player.GetY()) == true)
                    //player.down();
                //else
                    player.staydown();
            }
            else if (e.KeyCode == Keys.NumPad6&& map.IsCellOpen(player.GetX(), player.GetY()) == true)
            {
                //if (map.IsCellOpen(player.GetX(), player.GetY()) == true)
                    //player.right();
                //else
                    player.stayright();
            }
        }
        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.timer1.Enabled = true;
            this.timer2.Enabled = true;
            //empty = false;
            score = 0;
            die = false;
            drawMap();
            reDrawPBox();                  
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //gameOver();
            if (die==true)
            {
                this.timer1.Enabled = false;
                return;
            }
            /*for(int i=0;i<r.Count;i++)
            {
                r[i] += 1;
            }*/
            bulletupdata();
            reDrawPBox();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //gameOver();
            if (die == true)
            {
                this.timer2.Enabled = false;
                return;
            }
            //enemies = new List<Enemy>();
            for (int i = 0; i < 360; i++)
            {
                double rads = i * Math.PI / 180.0;
                double rx = Math.Cos(rads) * 2;
                double ry = Math.Sin(rads) * 2;
                bullet = new Enemy((int)rx + point.GetX(), (int)ry + point.GetY());
                //if (bullet.GetX() % 2 == 0 && bullet.GetY() % 2 == 0)
                //{
                    enemies.Add(bullet);
                    //edata.Add(bullet);
                //}
            }
            go = Utility.Rand()%4;
            //float rr = 2;
            //r.Add(rr);
            //cirle(1);
        }

        private void restartRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.timer1.Enabled = true;
            this.timer2.Enabled = true;
            //empty = false;
            die = false;
            enemies = new List<Enemy>();
            score = 0;
            //drawMap();
            reDrawPBox();
        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.pauseToolStripMenuItem.Text == "continue")
            {              
                this.timer1.Enabled = true;              
                this.timer2.Enabled = true;             
                this.pauseToolStripMenuItem.Text = "pause";
            }
            else
            {
                this.timer1.Enabled = false;
                this.timer2.Enabled = false;
                this.pauseToolStripMenuItem.Text = "continue";
            }
        }
    
    }
}
