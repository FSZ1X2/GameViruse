using System;
using System.Diagnostics;
using FSPG;


namespace try2
{
    class Enemy
    {
        /*public enum Type
        {
            Lurker,
            Stalker,
        }*/

        //const int FireRate = 200;
        Point menemies=new Point(0,0);
        //int direct;
        //int choice; // 0 circle, 1 line, 3 
        //Point[] enemybullets
        //Map mMap;
        //Game mTheGame;
        //Type mType;
        //int mX;
        //int mY;
        //int mVX;
        //int mVY;
        //int mSpeed;
        //bool mIsAlive;
        //Stopwatch mFireTimer;

        public Enemy(int x, int y)
        {
            //mIsAlive = true;
            //mMap = m;
            menemies.X = x;
            menemies.Y = y;
        }

        public int GetX()
        {
            return menemies.X;
        }

        public int GetY()
        {
            return menemies.Y;
        }

        public void SetX(int x)
        {
            menemies.X = x;
        }

        public void SetY(int y)
        {
            menemies.Y = y;
        }

        /*public void Update(int x, int y)
        {
            Point p = menemies;
            switch (choice)
            {
                case 0:
                    
                    break;
                case 1:
                    break;
            }

            //if (Utility.GetKeyState(ConsoleKey.UpArrow))
            //{
            //    if (mFireTimer.ElapsedMilliseconds > FireRate)
            //    {
            //        mTheGame.FireBullet(Bullet.Type.Player, (int)mX, (int)mY - 1);
            //        mFireTimer.Restart();
            //    }
            //}

            /*int newx = mX;
            int newy = mY;

            //Player player = //mTheGame.GetPlayer();

            switch (mType)
            {
                case Type.Lurker:
                    if (Utility.Rand() % 100 + 1 <= 10)
                    {
                        mVX = Utility.Rand() % 3 - 1;
                        mVY = Utility.Rand() % 3 - 1;
                    }
                    if (Utility.Rand() % 100 + 1 <= 30)
                    {
                        newx += mVX;
                        newy += mVY;
                    }
                    break;
                case Type.Stalker:
                    if (Utility.Rand() % 100 + 1 <= 30)
                    {
                        if (player.GetX() > mX)
                            mVX = 1;
                        else if (player.GetX() < mX)
                            mVX = -1;
                        else
                            mVX = 0;

                        if (player.GetY() > mY)
                            mVY = 1;
                        else if (player.GetY() < mY)
                            mVY = -1;
                        else
                            mVY = 0;
                    }
                    if (Utility.Rand() % 100 + 1 <= 50)
                    {
                        newx += mVX;
                        newy += mVY;
                    }
                    break;
                default:
                    break;
            }

            // wall collision
            //if ((int)mX < 0)
            //    mX = Console.WindowWidth - 1;
            //else if ((int)mX > Console.WindowWidth - 1)
            //    mX = 0;
            Map map = mTheGame.GetMap();
            if (map.IsCellOpen(newx, mY))
                mX = newx;
            if (map.IsCellOpen(mX, newy))
                mY = newy;
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

            switch (mType)
            {
                case Type.Lurker:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write('o');
                    break;
                case Type.Stalker:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write('¥');
                    break;
                default:
                    break;
            }

            Console.ForegroundColor = prevFC;
        }*/
    }
}