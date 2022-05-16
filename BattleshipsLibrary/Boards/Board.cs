﻿namespace Battleships.Library.Boards
{
    public class Board
    {
        public List<Cell> Cells { get; set; }

        public Board()
        {
            Cells = new List<Cell>();
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    Cells.Add(new Cell(i, j));
                }
            }
        }
    }
}
