using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace try2
{
    class Point
    {
        int x, y;
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public Point() { x = y = 0; }
        public Point(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
    }

    /*class PlayBase
    {
        //Point player;
        Point newmap;
        int direct;  // 0 down 1 left 2 up 3 right        
        private Random rand;

        public PlayBase()
        {      
            direct = 0;
            newmap = new Point();
        }
        public void generaterefreshpoint()
        {
            for (int i = 0; i < 50; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    if()
                }
            }
                    newmap.X = rand.Next(50);
            newmap.Y = rand.Next(50);
        }
        public void generatenewplayer()
        {
            newmap.X = rand.Next(50);
            newmap.Y = rand.Next(50);
        }
        /*Point player;   
        private Point newmap;        
        private Random rand;        
        internal Point Refresh        
        {            
	        get { return newmap; }            
	        set { newmap = value; }        
        }   
        internal Point Player       
        {                   
	        get { return player; }        
        } 
               
        int direct;  // 0 down 1 left 2 up 3 right        
        int xNum;        
        int yNum;        
        /*Point head;        
        internal Point Head
        {
            get { return head; }
            set { head = value; }
        }
        public int Direct
        {
            get { return direct; }
            set { direct = value; }
        }
        /*public void initArr(int[,] arr, int x, int y)        
        {
            int _d = 0;
	        for (int i = 0; i < x; i++)            
	        {                
		        for (int j = 0; j < y; j++)                
		        {                    
			        arr[i, j] = _d;                
		        }            
	        }        
        }
        public PlayBase()        
        {            
	        player = new Point(4,1);            
	        xNum = yNum = 50;            
	        direct = 0;            
	        rand = new Random();            
	        newmap = new Point();
            generaterefreshpoint();        
        }
        public void generaterefreshpoint()        
        {        
	        newmap.X = rand.Next(50);            
	        newmap.Y = rand.Next(50);        
        }       
        public void left()
        {            
	        if(direct!=3)direct = 1;        
        }        
        public void right()
        {            
	        if (direct != 1) direct = 3;        
        }        
        public void up()
        {            
	        if (direct != 0) direct = 2;        
        }        
        public void down()        
        {                   
	        if (direct != 2) direct = 0;        
        }
        /*public void next()        
        {            
	        Point p = new Point(head.X,head.Y);            
	        switch (direct)            
	        {                
		        case 0:                    
			        p.X+=1;                    
			        break;
                case 1:
                    p.Y-=1;
                    break;
                case 2:
                    p.X-=1;
                    break;
                case 3:
                    p.Y+=1;
                    break;
            }
            if (p.X == newmap.X && p.Y == newmap.Y)
            {
                generaterefreshpoint();
                eat(p.X, p.Y);
                head = p ;
                return;
            }
            sQ.Insert(0, p);
            sQ.RemoveAt(sQ.Count - 1);
            head = p;
        }
        public void addHead()
        {
            sQ.Insert(0, head);
        } 
        public bool isOver()
        {
            Point p = head;
            bool res = false;
            switch (direct)
            {
                case 0:
                    if (p.X == xNum - 1) res = true ;
                    break;
                case 1:
                    if (p.Y == 0) res = true;
                    break;
                case 2:
                    if (p.X == 0) res = true;
                    break;
                case 3:
                    if (p.Y == yNum - 1) res = true;
                    break;
            }
            return res;
        }
        public void eat(int x, int y)
        {
            Point p = new Point(x, y);
            head = p;
            sQ.Insert(0, p);
        }
    }*/
}
