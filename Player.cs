using System;
using System.Diagnostics;
using FSPG;


namespace try2
{
    class Player
    {
        //const int PlayerSpeed = 1;

        //Game mTheGame;
        Point mplayer=new Point(0,0);
        //int mX;
        //int mY;
        //char mIcon;
        bool mIsAlive;
        //Map mMap;
        int direct; // 0 down 1 left 2 up 3 right  
        public int Direct
        {
            get { return direct; }
            set { direct = value; }
        }

        public Player(int x, int y)
        {
            mIsAlive = true;
            //mMap = m;
            mplayer.X = x;
            mplayer.Y = y;
        }

        public bool IsAlive()
        {
            return mIsAlive;
        }

        public int GetX()
        {
            return mplayer.X;
        }

        public int GetY()
        {
            return mplayer.Y;
        }

        public void SetX(int x)
        {
            mplayer.X = x;
        }

        public void SetY(int y)
        {
            mplayer.Y = y;
        }
        public void Kill()
        {
            mIsAlive = false;
        }

        public void left()
        {
            /*if (direct != 3)*/ direct = 1;
        }
        public void right()
        {
            /*if (direct != 1)*/ direct = 3;
        }
        public void up()
        {
            /*if (direct != 0)*/ direct = 2;
        }
        public void down()
        {
            /*if (direct != 2)*/ direct = 0;
        }
        public void stayup()
        {
            direct = 4;
        }
        public void staydown()
        {
            direct = 5;
        }
        public void stayright()
        {
            direct = 6;
        }
        public void stayleft()
        {
            direct = 7;
        }
        /*public Point savedata()
        {
            return mplayer;
        }*/
        public void stay()
        {
            direct = 8;
        }
        public void next()
        {
            Point p = mplayer;
            switch (direct)
            {
                case 0: //down
                    p.X += 1;
                    break;
                case 1: //left
                    p.Y -= 1;
                    break;
                case 2: //up
                    p.X -= 1;
                    break;
                case 3: //right
                    p.Y += 1;
                    break;
                case 4: //sup
                    p.X += 1;
                    break;
                case 5: //sdown
                    p.X -= 1;
                    break;
                case 6: //sright
                    p.Y -= 1;
                    break;
                case 7: //sleft
                    p.Y += 1;
                    break;
                case 8:
                    break;

            }
            mplayer = p;
        }

        /*public void Update()
        {
            //if (Utility.GetKeyState(ConsoleKey.UpArrow))
            //{
            //    if (mFireTimer.ElapsedMilliseconds > FireRate)
            //    {
            //        mTheGame.FireBullet(Bullet.Type.Player, (int)mX, (int)mY - 1);
            //        mFireTimer.Restart();
            //    }
            //}

            int newx = mplayer.X;
            int newy = mplayer.Y;

            if (Utility.GetKeyState(ConsoleKey.LeftArrow))
                newx -= PlayerSpeed;
            else if (Utility.GetKeyState(ConsoleKey.RightArrow))
                newx += PlayerSpeed;

            if (Utility.GetKeyState(ConsoleKey.UpArrow))
                newy -= PlayerSpeed;
            else if (Utility.GetKeyState(ConsoleKey.DownArrow))
                newy += PlayerSpeed;

            mplayer.X = newx;
            mplayer.Y = newy;
            // wall collision
            //if ((int)mX < 0)
            //    mX = Console.WindowWidth - 1;
            //else if ((int)mX > Console.WindowWidth - 1)
            //    mX = 0;
            //Map mmap = mMap.GetMap();
            //if (map.IsCellOpen(newx, mY))
                //mX = newx;
            //if (map.IsCellOpen(mX, newy))
                //mY = newy;
        }

        /*public void Clear()
        {
            ConsoleColor prevFC = Console.ForegroundColor;

            Map map = mTheGame.GetMap();

            Console.SetCursorPosition(map.GetX() + mX, map.GetY() + mY);
            Console.ForegroundColor = Console.BackgroundColor;
            Console.Write(' ');

            Console.ForegroundColor = prevFC;
        }

        public void Draw()
        {
            ConsoleColor prevFC = Console.ForegroundColor;

            Map map = mTheGame.GetMap();

            Console.SetCursorPosition(map.GetX() + mX, map.GetY() + mY);
            Console.ForegroundColor = mColor;
            Console.Write(mIcon);

            Console.ForegroundColor = prevFC;
        }*/
    }
}