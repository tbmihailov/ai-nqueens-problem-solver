using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI.NQueensProblem
{
    class Board
    {
        private int _boardSize;

        HashSet<Figure> _figures;


        public Board(int boardSize)
        {
            this._boardSize = boardSize;
        }

        internal void InitFigurePositions()
        {
            List<int> availableRows = new List<int>();
            List<int> availableColumns = new List<int>();
            for (int i = 0; i < _boardSize; i++)
            {
                availableRows.Add(i);
                availableColumns.Add(i);
            }

            _figures = new HashSet<Figure>();
            int figuresToPlace = _boardSize;
            while (figuresToPlace > 0)
            {
                var random = new Random();
                int availableRow = random.Next(figuresToPlace);
                int availableColumn = random.Next(10, figuresToPlace+10)-10;

                int newRow = availableRows[availableRow];
                int newColumn = availableColumns[availableColumn];

                var figure = new Figure(newRow,newColumn,_boardSize,_boardSize - figuresToPlace + 1);
                _figures.Add(figure);
                availableRows.RemoveAt(availableRow);
                availableColumns.RemoveAt(availableColumn);
                figuresToPlace--;
            }
        }


        public bool AreInCollision(Figure figure1, Figure figure2)
        {
            throw new NotImplementedException();
        }

        internal int Collisions()
        {
            throw new NotImplementedException();
        }

        internal Figure GetQueenWithMaxCollisions()
        {
            throw new NotImplementedException();
        }

        internal int TestCollisionsForMove(Figure queen, int p, int newColumn)
        {
            throw new NotImplementedException();
        }

        internal void Move(Figure queen, int p, int newColumn)
        {
            throw new NotImplementedException();
        }

    }
}
