using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajorProjectDesktop
{
    internal class Maze
    {
        private int _width;
        private int _height;
        private int _cellSize;
        private Cell[,] _cellList; //Array of all cells
        private int _cellsVisited;
        private int _cellCount;
        private int[] _currentLocation = new int[2];
        private Random rnd = new Random();
        private int _choice;
        private int[][] _displayCells;
        int _displayCellsCount;
        List<char> _around = new List<char>();
        ConsoleRenderer _renderer;


        public int Width { get => _width; set => _width = value; }
        public int Height { get => _height; set => _height = value; }
        public int Cellsize { get => _cellSize; set => _cellSize = value; }

        public Cell[,] CellList { get => _cellList; set => _cellList = value; }
        public int CellsVisited { get => _cellsVisited; set => _cellsVisited = value; }
        public int CellCount { get => _cellCount; set => _cellCount = value; }
        public int[] CurrentLocation { get => _currentLocation; set => _currentLocation = value; }
        public int Choice { get => _choice; set => _choice = value; }
        public Random Rnd { get => rnd; set => rnd = value; }
        public int[][] DisplayCells { get => _displayCells; set => _displayCells = value; }
        public int DisplayCellsCount { get => _displayCellsCount; set => _displayCellsCount = value; }
        public List<char> Around { get => _around; set => _around = value; }

        public enum Direction : int
        {
            N,
            E,
            S,
            W
        }

        public Maze(int h, int w)
        {
            Height = h;
            Width = w;
            Cellsize = 2;
            CellsVisited = 0;
            CellCount = h * w;
            CellList = new Cell[w, h];
            DisplayCells = new int[h * w][];
            DisplayCellsCount = 0;
            _renderer = new ConsoleRenderer(w,h);
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    CellList[x, y] = new Cell(x, y);
                }
            }
        }

        public void Pathfind(int[] start)
        {
            while (CellsVisited < CellCount)
            {
                CurrentLocation[0] = start[0]; CurrentLocation[1] = start[1];
                Nextcell(CurrentLocation[0], CurrentLocation[1]);
            }
        }

        public void Nextcell(int x, int y)
        {
            CellList[x, y].Visited = true;
            CellsVisited++;
            //Render(Height, Width);
            //Thread.Sleep(5);

            while (CellList[x, y].FullyEx == false)
            {
                Around.Clear();
                Around = CellList[x, y].neighbours(CellList); //Finds unvisited cells around itself
                Choice = rnd.Next(CellList[x, y].Around.Count());

                switch (CellList[x, y].Around[Choice])
                {
                    case 'N':
                        //Console.WriteLine("N");
                        CellList[x, y - 1].Walls[1] = false; //Breaks south wall of cell above
                        Nextcell(x, y - 1);
                        break;

                    case 'E':
                        //Console.WriteLine("E");
                        CellList[x, y].Walls[0] = false; //Breaks east wall of current cell
                        Nextcell(x + 1, y);
                        break;

                    case 'S':
                        //Console.WriteLine("S");
                        CellList[x, y].Walls[1] = false; //Breaks south wall of current cell
                        Nextcell(x, y + 1);
                        break;

                    case 'W':
                        //Console.WriteLine("W");
                        CellList[x - 1, y].Walls[0] = false; //Breaks west wall of cell to the right
                        Nextcell(x - 1, y);
                        break;

                    case 'Q':
                        //Console.WriteLine("Q");
                        return;
                        break;

                    default:
                        break;
                }
                Around.Clear();
                Around = CellList[x, y].neighbours(CellList); //Finds unvisited cells around itself
            }

        }

	




        public void Render(int h, int w)
        {
            _renderer.ClearScreen();
            for (int Vcells = 0; Vcells < h; Vcells++) //Increments the row visited
            {
                int CDepth = 0;

                for (int n = 0; n < Cellsize-1; n++) //Prints every cell in this row three times
                {
                    for (int Hcells = 0; Hcells < w; Hcells++) //Goes through every cell in a row
                    {
                        if (CellList[Hcells, Vcells].Walls[0] == true)
                        {
                            for (int cellRow = 0; cellRow < Cellsize - 1; cellRow++) //If this cell has an east wall
                            {
                                _renderer.AddColoredCellToBuffer(ConsoleRenderer.BlueBG);
                            }
                            _renderer.AddColoredCellToBuffer(ConsoleRenderer.WhiteBG);
                        }
                        else
                        {
                            for (int cellRow = 0; cellRow < Cellsize; cellRow++) // If this cell does not have an east wall
                            {
                                _renderer.AddColoredCellToBuffer(ConsoleRenderer.BlueBG);
                            }
                        }
                        //Console.WriteLine();
                    }
                    _renderer.BufferNextLine();
                }
                for (int Hcells = 0; Hcells < w; Hcells++)
                {
                    if (CellList[Hcells, Vcells].Walls[1] == false)
                    {
                        for (int cellRow = 0; cellRow < Cellsize - 1; cellRow++)
                        {
                            _renderer.AddColoredCellToBuffer(ConsoleRenderer.BlueBG);
                        }
                        _renderer.AddColoredCellToBuffer(ConsoleRenderer.WhiteBG);

                    }
                    else
                    {
                        for (int cellRow = 0; cellRow < Cellsize; cellRow++)
                        {
                            _renderer.AddColoredCellToBuffer(ConsoleRenderer.WhiteBG);

                        }
                    }
                }
                _renderer.BufferNextLine();


                CDepth++;
            }

            _renderer.drawBuffer();
        }
    }
}
