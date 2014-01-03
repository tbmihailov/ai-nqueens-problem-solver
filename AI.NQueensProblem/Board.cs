using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI.NQueensProblem
{
    public class Board
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
                int randomStep = availableRow * availableRow + _boardSize;
                int availableColumn = random.Next(randomStep, figuresToPlace + randomStep) - randomStep;

                int newRow = availableRows[availableRow];
                int newColumn = availableColumns[availableColumn];

                var figure = new Figure(newRow, newColumn, _boardSize, _boardSize - figuresToPlace + 1);
                _figures.Add(figure);
                availableRows.RemoveAt(availableRow);
                availableColumns.RemoveAt(availableColumn);
                figuresToPlace--;
            }

            CalculateCollisions();
        }

        public bool AreInCollision(Figure figure1, Figure figure2)
        {
            throw new NotImplementedException();
        }


        public int CollisionsCnt
        {
            get
            {
                return _collisions.Count;
            }
        }

        Dictionary<Figure, int> _collisions = new Dictionary<Figure, int>();
        public Dictionary<Figure, int> Collisions
        {
            get { return _collisions; }
        }

        public void CalculateCollisions()
        {
            _collisions.Clear();
            var figures = _figures;

            int collisionsCnt = 0;

            //row collisions
            var rowCollisions = from f in figures
                                group f by f.Row into g
                                where g.Count() > 1
                                select new { Row = g.Key, Figures = g.OrderBy(f => f.Column) };
            //collisionsCnt += rowCollisions.Sum(g => g.Figures.Count() - 1);
            foreach (var rowCollision in rowCollisions)
            {
                foreach (var figure in rowCollision.Figures)
                {
                    if (!_collisions.ContainsKey(figure))
                    {
                        _collisions.Add(figure, 0);
                    }
                    _collisions[figure] += 1;
                    collisionsCnt++;
                }
                collisionsCnt--;//collisions are figures-1
            }

            //column collisions
            var columnCollisions = from f in figures
                                   group f by f.Column into g
                                   where g.Count() > 1
                                   select new { Column = g.Key, Figures = g.OrderBy(f => f.Row) };
            //collisionsCnt += columnCollisions.Sum(g => g.Figures.Count() - 1);
            foreach (var colCollision in columnCollisions)
            {
                foreach (var figure in colCollision.Figures)
                {
                    if (!_collisions.ContainsKey(figure))
                    {
                        _collisions.Add(figure, 0);
                    }
                    _collisions[figure] += 1;
                    collisionsCnt++;
                }
                collisionsCnt--;//collisions are figures-1
            }

            //diagonal1 collisions
            var d1Collisions = from f in figures
                               group f by f.Diagonal1 into g
                               where g.Count() > 1
                               select new { Row = g.Key, Figures = g.OrderBy(f => f.Column) };
            //collisionsCnt += d1Collisions.Sum(g => g.Figures.Count() - 1);
            foreach (var d1Collision in d1Collisions)
            {
                foreach (var figure in d1Collision.Figures)
                {
                    if (!_collisions.ContainsKey(figure))
                    {
                        _collisions.Add(figure, 0);
                    }
                    _collisions[figure] += 1;
                    collisionsCnt++;
                }
                collisionsCnt--;//collisions are figures-1
            }

            //column collisions
            var d2Collisions = from f in figures
                               group f by f.Diagonal2 into g
                               where g.Count() > 1
                               select new { Column = g.Key, Figures = g.OrderBy(f => f.Column) };
            //collisionsCnt += d2Collisions.Sum(g => g.Figures.Count() - 1);
            foreach (var d2Collision in d2Collisions)
            {
                foreach (var figure in d2Collision.Figures)
                {
                    if (!_collisions.ContainsKey(figure))
                    {
                        _collisions.Add(figure, 0);
                    }
                    _collisions[figure] += 1;
                    collisionsCnt++;
                }
                collisionsCnt--;//collisions are figures-1
            }

            _collisions = _collisions.OrderByDescending(c => c.Value).ToDictionary(k => k.Key, v => v.Value);
        }



        internal int TestCollisionsForMove(Figure queen, int p, int newColumn)
        {
            throw new NotImplementedException();
        }

        internal bool TryMove(Figure queen, int newRow, int newColumn)
        {
            if (_figures.Any(f => f.Row == newRow && f.Column == newColumn))
            {
                return false;
            }
            else
            {
                queen.SetPosition(newRow, newColumn);
                CalculateCollisions();
                return true;
            }
        }

        public override string ToString()
        {
            StringBuilder boardOutput = new StringBuilder();
            int size = this._boardSize;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    bool hasFigure = (_figures.Any(f => f.Row == i && f.Column == j));
                    boardOutput.Append(hasFigure ? " *" : " _");
                }

                if (i < size - 1)
                {
                    boardOutput.AppendLine();
                }
            }
            return boardOutput.ToString();
        }

    }
}
