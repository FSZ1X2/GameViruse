using System;
using FSPG;


namespace try2
{
    class Map
    {
        const char CellWall  = '█';
        const char CellSpace = ' ';
        const int PercentWalls = 35;

        int mX;
        int mY;
        int mWidth;
        int mHeight;
        char[,] mCells;
        char[,] mBuffer;
        public bool[,] mapping;
        //public bool[,] mapdata;


        public Map(int x, int y, int w, int h)
        {
            mX = x;
            mY = y;
            mWidth = w;
            mHeight = h;

            mCells = new char[mHeight, mWidth];
            mBuffer = new char[mHeight, mWidth];

            mapping = new bool[mHeight, mWidth];

            GenerateNewMap();
           
        }

        public int GetX()
        {
            return mX;
        }

        public int GetY()
        {
            return mY;
        }

        public int GetWidth()
        {
            return mWidth;
        }

        public int GetHeight()
        {
            return mHeight;
        }

        public void Draw()
        {
            for (int row = 0; row < mHeight; row++)
            {
                for (int col = 0; col < mWidth; col++)
                {
                    if (mCells[row, col] == CellWall)
                        mapping[row, col] = true;
                    else
                        mapping[row, col] = false;
                }
            }
        }
        public bool IsCellOpen(int x, int y)
        {
            return mapping[x,y];
        }

        private void GenerateNewMap()
        {
            RandomizeMap();
            //Pause();

            // refine map, but prevent large open areas
            for (int i = 0; i < 4; i++)
            {
                RefineMap(true);
                //Pause();
            }

            // refine map
            for (int i = 0; i < 3; i++)
            {
                RefineMap(false);
                //Pause();
            }
        }
        
        private void RandomizeMap()
        {
            // fill horizontal borders
            for (int i = 0; i < mWidth; i++)
            {
                mCells[0, i] = CellWall;
                mCells[mHeight - 1, i] = CellWall;
            }

            // fill vertical borders
            for (int i = 0; i < mHeight; i++)
            {
                mCells[i, 0] = CellWall;
                mCells[i, mWidth - 1] = CellWall;
            }

            // randomly fill internals of map with percentage of walls
            for (int row = 1; row < mHeight-1; row++)
            {
                for (int col = 1; col < mWidth-1; col++)
                {
                    if (Utility.Rand() % 100 + 1 < PercentWalls)
                        mCells[row, col] = CellWall;
                    else
                        mCells[row, col] = CellSpace;
                }
            }

            // put in a whitespace trip to help prevent disjoing caves
            int midrow = mWidth / 2;
            for (int i = 1; i < mHeight-1; i++)
            {
                mCells[i, midrow - 1] = CellSpace;
                mCells[i, midrow] = CellSpace;
                mCells[i, midrow + 1] = CellSpace;
            }
            int midcol = mHeight / 2;
            for (int j = 1; j < mWidth - 1; j++)
            {
                mCells[midrow - 1, j] = CellSpace;
                mCells[midrow, j] = CellSpace;
                mCells[midrow + 1, j] = CellSpace;
            }
        }

        private void RefineMap(bool preventOpenAreas)
        {
            for (int row = 0; row < mHeight; row++)
            {
                for (int col = 0; col < mWidth; col++)
                {
                    int numWallsD1 = CountNeighborWalls(col, row, 1);
                    int numWallsD2 = CountNeighborWalls(col, row, 2);

                    // handle wall cells
                    if (mCells[row, col] == CellWall)
                    {
                        if (numWallsD1 >= 4)
                            mBuffer[row, col] = CellWall;
                        else
                            mBuffer[row, col] = CellSpace;
                    }
                    // handle space cells
                    else
                    {
                        if (numWallsD1 >= 5)
                            mBuffer[row, col] = CellWall;
                        else if (numWallsD2 <= 1 && preventOpenAreas)
                            mBuffer[row, col] = CellWall;
                        else
                            mBuffer[row, col] = CellSpace;
                    }
                }
            }

            Array.Copy(mBuffer, mCells, mWidth * mHeight);
        }

        private int CountNeighborWalls(int x, int y, int dist)
        {
            int count = 0;

            for (int cy = y-dist; cy <= y+dist; cy++)
            {
                for (int cx = x - dist; cx <= x + dist; cx++)
                {
                    // ignore cell we started at
                    if (cx == x && cy == y)
                        continue;

                    // if cell is off the map, count it as a wall
                    if (cx < 0 || cx >= mWidth ||
                        cy < 0 || cy >= mHeight)
                    {
                        count++;
                        continue;
                    }

                    // finally, count actual walls
                    if (mCells[cy, cx] == CellWall)
                        count++;
                }
            }

            return count;
        }

        /*private void Pause()
        {
            Draw();
            Console.SetCursorPosition(0, 0);
            Console.ReadLine();
        }*/
    }
}