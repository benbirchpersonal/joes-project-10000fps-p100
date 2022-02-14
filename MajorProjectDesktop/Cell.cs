using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MajorProjectDesktop
{
    internal class Cell
    {
        private bool _visited = false;
        private int[] coord = new int[2];
        private bool[] _walls = { true, true }; //East Wall, South Wall
        private bool[] _available = { false, false, false, false};
        private List<char> _around = new List<char>();
        private bool _fullyEx = false;


        public bool Visited { get => _visited; set => _visited = value; }
        public int[] Coord { get => coord; set => coord = value; }
        public bool[] Walls { get => _walls; set => _walls = value; }
        public bool[] Available { get => _available; set => _available = value; } //Store the direction of available cells in list, then compare this in a switch
        public List<char> Around { get => _around; set => _around = value; }
        public bool FullyEx { get => _fullyEx; set => _fullyEx = value; }

        public Cell(int x, int y)
        {
            Coord[0] = x;
            Coord[1] = y;
        }


        public List<char> neighbours(Cell[,] cellList)
        {
            bool topRow = (coord[0] == 0);
            bool bottomRow = (coord[0] == cellList.GetLength(1) - 1);
            bool rightCol = (coord[1] == cellList.GetLength(0) - 1);
            bool leftCol = (coord[1] == 0);
            Around.Clear();
            if (!(coord[1] == 0))
            {
                if (cellList[Coord[0], Coord[1] - 1].Visited == false) //Checks if North cell is available
                {
                    Around.Add('N');
                }
            }
            if (!(coord[1] == cellList.GetLength(1) - 1))
            {
                if (cellList[Coord[0], Coord[1] + 1].Visited == false) //Checks if South Cell is available
                {
                    Around.Add('S');
                }
            }
            if (!(coord[0] == cellList.GetLength(0) - 1))
            {
                if (cellList[Coord[0] + 1, Coord[1]].Visited == false) //checks if East cell is available
                {
                    Around.Add('E');
                }
            }
            if (!(coord[0] == 0))
            {
                if (cellList[Coord[0] - 1, Coord[1]].Visited == false) //Checks if West cell is available
                {
                    Around.Add('W');
                }
            }
            if (Around.Count() == 0)
            {
                Around.Add('Q');
                FullyEx = true;
            }




            return Around;
        }

        /*
        public List<char> neighbours(Cell[,] celllist)
        {
            Around.Clear();
            try //North cell check
            {
                if (celllist[Coord[0], Coord[1] - 1].Visited == false) //Checks if North cell is available
                {
                    Around.Add('N');
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("No cell north");
            }

            try //South cell check
            {
                if (celllist[Coord[0], Coord[1] + 1].Visited == false) //Checks if South Cell is available
                {
                    Around.Add('S');
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("No cell south");
            }

            try //West cell check
            {
                if (celllist[Coord[0] - 1, Coord[1]].Visited == false) //Checks if West cell is available
                {
                    Around.Add('W');
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("No cell west");
            }

            try //East cell check
            {
                if (celllist[Coord[0] + 1, Coord[1]].Visited == false) //checks if East cell is available
                {
                    Around.Add('E');
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("No cell east");
            }

            if (Around.Count() == 0)
            {
                Around.Add('Q');
                FullyEx = true;
            }

            return Around;
        }

        */
    }
}
